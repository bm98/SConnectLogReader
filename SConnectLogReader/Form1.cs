using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using SCLogLib;

namespace SConnectLogReader
{
  public partial class Form1 : Form
  {
    private const decimal cMB = 1_048_576.0m;
    // Max logfile size when nothing is ignored
    private const decimal c_maxFileSize = 100 * cMB; // 100MB for now

    // log reader
    private SCL_Reader _reader;
    // the captured logfile
    private LogFile _log;
    // catalog of captured clients of this log
    private ClientCat _clientCat;

    // debug/measure performance
    private readonly Stopwatch _stopwatch = new Stopwatch( );

    /// <summary>
    /// cTor: partial
    /// </summary>
    public Form1( )
    {
      InitializeComponent( );
    }

    // form is loading
    private void Form1_Load( object sender, EventArgs e )
    {
      tlp.Dock = DockStyle.Fill;

      PBar_FromThread( 0 );

      clbIgnore.Items.Clear( );
      foreach (var item in _ignoreableItems) {
        int index = clbIgnore.Items.Add( item );
        // set all checked
        //clbIgnore.SetItemChecked( index, true );
      }
    }

    // items which may be ignored - usually happen very often and are not always of value to capture
    // reduces the memory footprint for huge logfiles
    private LineType[] _ignoreableItems =  {
      // SimConnect server replies
      LineType.ScEventFrame,
      LineType.ScEvent,

      LineType.ScClientData,

      LineType.ScObjectAddRemove,
      LineType.ScObjectData,
      LineType.ScObjectDataByType,
      LineType.ScFacilities_Request, // reply FacilityList
      LineType.ScICAO_Request,

      // SimConnect client commands
      LineType.RequestDataOnSimObject,
      LineType.RequestDataOnSimObjectType,
      LineType.RequestFacilityData,
      LineType.RequestFacilityData_EX1,

      LineType.SetClientData,
      LineType.SetDataOnSimObject,

      LineType.TransmitClientEvent,
      LineType.TransmitClientEvent_EX1,
    };

    // list of items to ignore while processing (snapshot when starting the scan)
    private List<LineType> _ignoredItems = new List<LineType>( );

    // snapshot the lines to be ignored for processing
    private void GetIgnoredItems( )
    {
      _ignoredItems.Clear( );
      foreach (var item in clbIgnore.CheckedItems) {
        _ignoredItems.Add( (LineType)item );
      }
    }

    // clean up GUI for a new scan
    private void InitGui( )
    {
      txFocusClient.Text = "";
      txNumEntries.Text = "";
      txNumExc.Text = "";
      txNumOpen.Text = "";

      RTB_Info.Text = "";
      clbClients.Items.Clear( );
      RTB_EExit.Text = "";
      RTB_Dump.Text = "";
    }

    private void btSelAll_Click( object sender, EventArgs e )
    {
      for (int i = 0; i < clbIgnore.Items.Count; i++) { clbIgnore.SetItemChecked( i, true ); }
    }

    private void btSelNone_Click( object sender, EventArgs e )
    {
      for (int i = 0; i < clbIgnore.Items.Count; i++) { clbIgnore.SetItemChecked( i, false ); }
    }

    // create a list where only one can be checked, also carry the checked one to the focus field
    private void clbClients_ItemCheck( object sender, ItemCheckEventArgs e )
    {
      if (e.NewValue == CheckState.Checked) {
        // about to check a new one - unckeck the current one
        for (var i = 0; i < clbClients.Items.Count; i++) {
          if (e.Index == i) continue; // don't handle the calling item
          clbClients.SetItemChecked( i, false ); // unconditionally uncheck
        }
        txFocusClient.Text = clbClients.Items[e.Index].ToString( );
        txFocusClient.Tag = clbClients.Items[e.Index];
      }
      else {
        txFocusClient.Text = "";
        txFocusClient.Tag = null;
      }
    }

    // return true if found in the ignore checked list
    private bool ToBeIgnored( LogLine logLine )
    {
      // sanity
      if (logLine == null) return true;
      if (logLine.LogLineType == LineType.None) return true;

      return _ignoredItems.Contains( logLine.LogLineType );
    }

    // cancel the busy BGW
    private void btCancel_Click( object sender, EventArgs e )
    {
      if (BGW_Main.IsBusy) BGW_Main.CancelAsync( );
      if (BGW_RTB.IsBusy) BGW_RTB.CancelAsync( );
    }

    // open a logfile
    private void btScan_Click( object sender, EventArgs e )
    {
      // sanity
      if (BGW_Main.IsBusy) return;

      OFD.Title = "Open Logfile";
      if (OFD.ShowDialog( this ) == DialogResult.OK) {
        txNumEntries.Text = "---";

        InitGui( ); // clear all
        tabC.SelectTab( "tP_Info" );

        _reader = new SCL_Reader( OFD.FileName );
        _reader.LineCountUpdate += _reader_LineCountUpdate;

        if (clbIgnore.CheckedItems.Count == 0) {
          if (_reader.FileSize > c_maxFileSize) {
            RTB_Info.Text = $"File is too long ({_reader.FileSize / cMB:#,##0.0}) MB\n";
            RTB_Info.Text += $"Max size supported is:  {c_maxFileSize / cMB:#,##0.0} MB\n\n";
            RTB_Info.Text += $"Try to shorten the file for processing\n";
            RTB_Info.Text += $"OR ignore some and we will try to run anyway\n\n";
            RTB_Info.Text += $"which may cause an abort with an OutOfMemory Exception (no check is done for this)\n";
            return;
          }
        }
        BGW_Main.RunWorkerAsync( );
      }
    }

    private const decimal c_memLimit = 2_700 * cMB;
    private long _memAllocated = 0;
    private bool _memAlert = false;

    private void _reader_LineCountUpdate( object sender, EventArgs e )
    {
      SetText_FromThread( txNumEntries, _reader.LinesRead.ToString( "###,###,##0" ) );
      PBar_FromThread( _reader.PercentRead );
      // check for mem size
      _memAllocated = Environment.WorkingSet;
      if (_memAllocated > c_memLimit) _memAlert = true;
    }

    private void btWriteJSON_Click( object sender, EventArgs e )
    {
      // sanity
      if (BGW_Main.IsBusy) return;

      SFD.Title = "Write to JSON";
      SFD.FileName = "LogDump.json";
      if (SFD.ShowDialog( ) == DialogResult.OK) {
        if (txFocusClient.Tag is Client vCL) {

          var clNumber = vCL.ClientNumber;
          var llines = _log.Where( l => l.ClientNumber == clNumber );
          _log.WriteToJson( SFD.FileName, clNumber );
        }
      }
    }

    // Show all Open/Disconnect entries
    private void btSchowOpen_Click( object sender, EventArgs e )
    {
      // sanity
      if (BGW_Main.IsBusy) return;

      PBar_FromThread( 0 );

      var inOut = _log.Where( ll => ll.LogLineType == LineType.Open || ll.LogLineType == LineType.ScDisconnected )
                      .OrderBy( l => l.Timestamp );

      // short enough to do this in process
      foreach (var l in inOut) {
        string clint = _clientCat.GetClientName( l.ClientNumber );

        string ee = (l.LogLineType == LineType.Open) ? "OPEN:  "
           : (l.LogLineType == LineType.ScDisconnected) ? "DISCO: "
           : "?????: "; // should never happen ..
        AddText_FromThread( RTB_EExit, $"{ee}{clint}: {l.LoggedLine}\n" );

        // switch tab
        tabC.SelectTab( "tP_EntryExit" );
      }
    }

    #region Dump Logfile

    // dump focused lines
    private void btFocDump_Click( object sender, EventArgs e )
    {
      // sanity
      if (BGW_Main.IsBusy) return;
      if (BGW_RTB.IsBusy) return;

      RTB_Dump.Clear( );
      tabC.SelectTab( "tP_Dump" );
      tabC.Cursor = Cursors.WaitCursor;

      BGW_RTB.RunWorkerAsync( new RTB_JobDescriptor( Job_DumpFocusLog ) );

      PBar_FromThread( 0 );
    }

    // job to list all log lines of the focused client
    private void Job_DumpFocusLog( )
    {
      if (txFocusClient.Tag == null) return;

      string rtb = "";
      int blockCount = 0;
      long clNumber = -1;
      long lineCounter = 0;

      // also ignore on Dump
      GetIgnoredItems( );

      if (txFocusClient.Tag is Client vCL) {

        clNumber = vCL.ClientNumber;
        var llines = _log.Where( l => l.ClientNumber == clNumber );
        var _count = llines.Count( );

        foreach (var lline in llines) {
          if (BGW_RTB.CancellationPending) break;

          if (!ToBeIgnored( lline )) rtb += $"{lline.LoggedLine}\n";

          lineCounter++;

          // send in chunks
          if (++blockCount > 50) {
            AddText_FromThread( RTB_Dump, rtb );
            blockCount = 0;
            rtb = "";
            PBar_FromThread( (lineCounter * 100.0) / _count );

          }

        }
        // final append
        AddText_FromThread( RTB_Dump, rtb );
        PBar_FromThread( 100 );
      }
    }

    #endregion

    #region Show Exceptions

    // collect and show exceptions
    private void btShowExc_Click( object sender, EventArgs e )
    {
      // sanity
      if (BGW_Main.IsBusy) return;
      if (BGW_RTB.IsBusy) return;

      RTB_Exceptions.Clear( );
      tabC.SelectTab( "tP_Exceptions" );
      tabC.Cursor = Cursors.WaitCursor;

      BGW_RTB.RunWorkerAsync( new RTB_JobDescriptor( Job_ListExceptions ) );
    }

    // job to list all exceptions and causing lines if found
    private void Job_ListExceptions( )
    {
      string rtb = "";
      int lcount = 0;

      var exceptions = _log.Where( ll => ll.LogLineType == LineType.ScException );
      foreach (var excLine in exceptions) {
        if (BGW_RTB.CancellationPending) break;

        string clint = _clientCat.GetClientName( excLine.ClientNumber );

        var exID = excLine.Arguments.FirstOrDefault( p => p.Argument == ArgName.EXCEPTION )?.ArgI;
        string exS = ScExceptions.GetExceptionS( exID ?? 0 );
        string culpritS = "unkown or ignored cause line";

        // try get the causing line
        var sendID = excLine.Arguments.FirstOrDefault( p => p.Argument == ArgName.SendID )?.ArgI;
        if (sendID.HasValue && (sendID.Value > 0)) {
          var clintLines = _log.Where( ll => ll.ClientNumber == excLine.ClientNumber );
          var culprit = clintLines.FirstOrDefault( cl => cl.ClientSendID == sendID.Value );
          if (culprit != null) {
            culpritS = MakePrintableCtrlChars( culprit.LoggedLine ); // seen Ctrl Chars in some strings...
          }
        }
        else {
          culpritS = "unkown cause line (SendID=0)";
        }

        rtb += $"{clint}: {exS} -{excLine.LoggedLine}\n";
        rtb += $"  caused by: {culpritS}\n\n";

        // send in chunks
        if (++lcount > 50) {
          AddText_FromThread( RTB_Exceptions, rtb );
          lcount = 0;
          rtb = "";
        }
      }
      // final append
      AddText_FromThread( RTB_Exceptions, rtb );
    }

    #endregion

    #region RTB Job Handling

    // a RTB Job (used to fill RTB when many lines are to be supplied)
    private class RTB_JobDescriptor
    {
      public Action Job { get; set; }
      public RTB_JobDescriptor( Action job ) { this.Job = job; }
    }

    // RTB Appender
    private void BGW_RTB_DoWork( object sender, DoWorkEventArgs e )
    {
      if (e.Argument is RTB_JobDescriptor job) {
        job.Job?.Invoke( );
      }
    }

    private void BGW_RTB_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
    {
      tabC.Cursor = Cursors.Default;
    }

    #endregion

    #region Scan Job Handling

    private void BGW_Main_DoWork( object sender, DoWorkEventArgs e )
    {
      SetText_FromThread( RTB_Info, "START READING\n" );

      // reset mem tracking - will update when reading lines
      _memAlert = false;
      _memAllocated = 0;

      GetIgnoredItems( );
      _log = new LogFile( );

      _stopwatch.Restart( );
      string line = _reader.ReadLine( );
      while (!string.IsNullOrEmpty( line )) {
        if (_memAlert || BGW_Main.CancellationPending) break;

        var lline = new LogLine( line );
        if (!ToBeIgnored( lline )) _log.Add( lline );

        // next
        line = _reader.ReadLine( );
      }

      PBar_FromThread( 100 );
    }

    private void BGW_Main_ProgressChanged( object sender, ProgressChangedEventArgs e )
    {

    }

    private void BGW_Main_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
    {
      _stopwatch.Stop( );

      _reader.Dispose( );
      _reader = null;

      if (_memAlert) {
        RTB_Info.Text += $"  ** Aborted: reached WorkingSet limit ({c_memLimit / cMB:#,##0.0} MB)\n";
      }

      RTB_Info.Text += "FINISHED READING\n";
      RTB_Info.Text += $"Process WorkingSet: {_memAllocated / cMB:#,##0.0} MB allocated)\n";
      RTB_Info.Text += $"Lines read:  {_log.Count:###,###,##0}\n";
      txNumEntries.Text = _log.Count.ToString( "###,###,##0" );

      // create the client catalog
      _clientCat = Client.ClientList( _log );

      // fill some info items
      txNumOpen.Text = (_log.NumOpen( ) + _log.NumDisconnect( )).ToString( "###,###,##0" );
      txNumExc.Text = _log.NumException( ).ToString( "###,###,##0" );
      // fill client tab
      clbClients.Items.Clear( );
      foreach (var clint in _clientCat.Values) {
        int index = clbClients.Items.Add( clint );
      }

      RTB_Info.Text += $"Time used: {_stopwatch.ElapsedMilliseconds / 1000.0:##,##0.000} sec\n";
    }

    #endregion

    #region Tools

    // using invoke where required
    private void SetText_FromThread( Control ctrl, string text )
    {
      if (ctrl.InvokeRequired) {
        ctrl.Invoke( (MethodInvoker)delegate { ctrl.Text = text; } );
      }

      else {
        ctrl.Text = text;
      }
    }

    // using invoke where required
    private void AddText_FromThread( Control ctrl, string text )
    {
      if (ctrl.InvokeRequired) {
        if (ctrl is RichTextBox vRTB) {
          ctrl.Invoke( (MethodInvoker)delegate { vRTB.AppendText( text ); } ); // should be faster than += ??
        }
        else {
          ctrl.Invoke( (MethodInvoker)delegate { ctrl.Text += text; } );
        }
      }

      else {
        if (ctrl is RichTextBox vRTB) {
          vRTB.AppendText( text ); // should be faster than += ??
        }
        else {
          ctrl.Text += text;
        }
      }
    }

    // using invoke where required
    private void PBar_FromThread( double value )
    {
      if (pBar.InvokeRequired) {
        pBar.Invoke( (MethodInvoker)delegate { pBar.Value = (int)Math.Max( Math.Min( value, 100 ), 0 ); } );
      }
      else {
        pBar.Value = (int)Math.Max( Math.Min( value, 100 ), 0 );
      }
    }


    // using the Unicode Control chars range U+2400 .. U+2426
    // implies usage of a font that supports the Controls Set
    // Arial Unicode MS, Segoe UI Symbol, 
    private static string MakePrintableCtrlChars( string text )
    {
      return Regex.Replace(
        text,
       @"\p{Cc}",
        m => {
          int code = (int)(m.Value[0]) + 0x2400;

          return Convert.ToChar( code ).ToString( );
        } );
    }

    #endregion

    private void mSelAll_Click( object sender, EventArgs e )
    {
      RichTextBox rtb = null;
      if (tabC.SelectedTab.Name == "tP_Info") rtb = RTB_Info;
      else if (tabC.SelectedTab.Name == "tP_EntryExit") rtb = RTB_EExit;
      else if (tabC.SelectedTab.Name == "tP_Exceptions") rtb = RTB_Exceptions;
      else if (tabC.SelectedTab.Name == "tP_Dump") rtb = RTB_Dump;

      if (rtb != null) {
        rtb.SelectAll( );
      }
    }

    private void mCopy_Click( object sender, EventArgs e )
    {
      RichTextBox rtb = null;
      if (tabC.SelectedTab.Name == "tP_Info") rtb = RTB_Info;
      else if (tabC.SelectedTab.Name == "tP_EntryExit") rtb = RTB_EExit;
      else if (tabC.SelectedTab.Name == "tP_Exceptions") rtb = RTB_Exceptions;
      else if (tabC.SelectedTab.Name == "tP_Dump") rtb = RTB_Dump;

      if (rtb != null) {
        Clipboard.SetText( rtb.SelectedText );
      }
    }

    private void mCopyAll_Click( object sender, EventArgs e )
    {
      RichTextBox rtb = null;
      if (tabC.SelectedTab.Name == "tP_Info") rtb = RTB_Info;
      else if (tabC.SelectedTab.Name == "tP_EntryExit") rtb = RTB_EExit;
      else if (tabC.SelectedTab.Name == "tP_Exceptions") rtb = RTB_Exceptions;
      else if (tabC.SelectedTab.Name == "tP_Dump") rtb = RTB_Dump;

      if (rtb != null) {
        Clipboard.SetText( rtb.Text );
      }
    }
  }
}
