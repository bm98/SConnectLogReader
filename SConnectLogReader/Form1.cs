using SCLogLib;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Net.Mime.MediaTypeNames;

namespace SConnectLogReader
{
  public partial class Form1 : Form
  {
    // Max logfile size when nothing is ignored
    private const long c_maxFileSize = 100 * 1024 * 1000; // 100MB for now
    // log reader
    private SCL_Reader _reader;
    // the captured logfile
    private LogFile _log;
    // catalog of captured clients of this log
    private ClientCat _clientCat;

    // debug/measure performance
    private readonly Stopwatch _stopwatch = new Stopwatch( );


    public Form1( )
    {
      InitializeComponent( );
    }

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
    // reduces the memory footpring for huge logfiles
    private LineType[] _ignoreableItems =  {
      // SimConnect server replies
      LineType.ScEventFrame,
      LineType.ScEvent,

      LineType.ScClientData,
      LineType.ScObjectData,
      LineType.ScObjectDataByType,
      LineType.ScFacilities_Request, // reply FacilityList

      // SimConnect client commands
      LineType.RequestDataOnSimObject,
      LineType.RequestDataOnSimObjectType,
      LineType.RequestFacilityData,
      LineType.RequestFacilityData_EX1,
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

    // open a logfile
    private void btScan_Click( object sender, EventArgs e )
    {
      // sanity
      if (BGW_Main.IsBusy) return;

      OFD.Title = "Open Logfile";
      if (OFD.ShowDialog( this ) == DialogResult.OK) {
        txNumEntries.Text = "---";

        _reader = new SCL_Reader( OFD.FileName );
        _reader.LineCountUpdate += _reader_LineCountUpdate;

        if (clbIgnore.CheckedItems.Count == 0) {
          if (_reader.FileSize > c_maxFileSize) {
            RTB.Text = $"File is too long ({_reader.FileSize:###,###,###,##0}) Bytes\n";
            RTB.Text += $"Max size supported is:  {c_maxFileSize:###,###,###,##0} Bytes\n\n";
            RTB.Text += $"Try to shorten the file for processing\n";
            RTB.Text += $"OR ignore some and we will try to run anyway\n\n";
            RTB.Text += $"which may cause an abort with an OutOfMemory Exception (no check is done for this)\n";
            return;
          }
        }
        BGW_Main.RunWorkerAsync( );
      }
    }

    private void _reader_LineCountUpdate( object sender, EventArgs e )
    {
      SetText_FromThread( txNumEntries, _reader.LinesRead.ToString( "###,###,##0" ) );
      PBar_FromThread( _reader.PercentRead );
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

      RTB.Text = "";
      PBar_FromThread( 0 );

      var inOut = _log.Where( ll => ll.LogLineType == LineType.Open || ll.LogLineType == LineType.ScDisconnected )
                      .OrderBy( l => l.Timestamp );

      foreach (var l in inOut) {
        string clint = _clientCat.GetClientName( l.ClientNumber );

        string ee = (l.LogLineType == LineType.Open) ? "OPEN:  "
           : (l.LogLineType == LineType.ScDisconnected) ? "DISCO: "
           : "?????: "; // should never happen ..
        RTB.Text += $"{ee}{clint}: {l.LoggedLine}\n";
      }
    }

    #region Dump Logfile

    // dump focused lines
    private void btFocDump_Click( object sender, EventArgs e )
    {
      // sanity
      if (BGW_Main.IsBusy) return;
      if (BGW_RTB.IsBusy) return;

      RTB.Clear( );
      RTB.Cursor = Cursors.WaitCursor;
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

      if (txFocusClient.Tag is Client vCL) {

        clNumber = vCL.ClientNumber;
        var llines = _log.Where( l => l.ClientNumber == clNumber );
        var _count = llines.Count( );

        foreach (var line in llines) {
          if (BGW_RTB.CancellationPending) return;

          rtb += $"{line.LoggedLine}\n";
          lineCounter++;

          // send in chunks
          if (++blockCount > 50) {
            AddText_FromThread( RTB, rtb );
            blockCount = 0;
            rtb = "";
            PBar_FromThread( (lineCounter * 100.0) / _count );

          }

        }
        // final append
        AddText_FromThread( RTB, rtb );
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

      RTB.Clear( );
      RTB.Cursor = Cursors.WaitCursor;
      BGW_RTB.RunWorkerAsync( new RTB_JobDescriptor( Job_ListExceptions ) );
    }

    // job to list all exceptions and causing lines if found
    private void Job_ListExceptions( )
    {
      string rtb = "";
      int lcount = 0;

      var exceptions = _log.Where( ll => ll.LogLineType == LineType.ScException );
      foreach (var excLine in exceptions) {
        if (BGW_RTB.CancellationPending) return;

        string clint = _clientCat.GetClientName( excLine.ClientNumber );

        var exID = excLine.Arguments.FirstOrDefault( p => p.Argument == ArgNames.EXCEPTION )?.ArgI;
        string exS = ScExceptions.GetExceptionS( exID ?? 0 );
        string culpritS = "unkown or ignored cause line";

        // try get the causing line
        var sendID = excLine.Arguments.FirstOrDefault( p => p.Argument == ArgNames.SendID )?.ArgI;
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
          AddText_FromThread( RTB, rtb );
          lcount = 0;
          rtb = "";
        }
      }
      // final append
      AddText_FromThread( RTB, rtb );
    }

    #endregion

    #region RTB Job Handling

    private void btCancel_Click( object sender, EventArgs e )
    {
      BGW_RTB.CancelAsync( );
    }

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
      RTB.Cursor = Cursors.Default;
    }

    #endregion

    #region Scan Job Handling

    private void BGW_Main_DoWork( object sender, DoWorkEventArgs e )
    {
      SetText_FromThread( RTB, "START READING" );

      GetIgnoredItems( );
      _log = new LogFile( );

      _stopwatch.Restart( );
      string line = _reader.ReadLine( );
      while (!string.IsNullOrEmpty( line )) {

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

      txNumEntries.Text = _log.Count.ToString( "###,###,##0" );
      RTB.Text = "FINISHED READING";

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

      txTimeUsed.Text = $"Used: {_stopwatch.ElapsedMilliseconds / 1000.0:##,##0.000} sec";
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
        ctrl.Invoke( (MethodInvoker)delegate { ctrl.Text += text; } );
      }
      else {
        ctrl.Text += text;
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

  }
}
