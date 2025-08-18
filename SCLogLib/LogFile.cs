using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SCLogLib
{
  /// <summary>
  /// Defines a type for a Log File
  /// </summary>
  public class LogFile : List<LogLine>
  {
    /// <summary>
    /// Number of Open cmds
    /// </summary>
    public long NumOpen( ) => this.Where( ll => ll.LogLineType == LineType.Open ).LongCount( );

    /// <summary>
    /// Number of Disconnects received
    /// </summary>
    public long NumDisconnect( ) => this.Where( ll => ll.LogLineType == LineType.ScDisconnected ).LongCount( );

    /// <summary>
    /// Number of Exceptions received
    /// </summary>
    public long NumException( ) => this.Where( ll => ll.LogLineType == LineType.ScException ).LongCount( );


    /// <summary>
    /// Write the Log to a file in JSON format - will be overwritten
    /// </summary>
    /// <param name="filename">An filename to write to</param>
    public void WriteToJson( string filename )
    {
      using (var writer = new StreamWriter( filename, false )) {
        WriteToJson( writer );
      }
    }

    /// <summary>
    /// Write the Log to an open StreamWriter in JSON format   Write into the 
    /// </summary>
    /// <param name="writer">An open StreamWriter</param>
    public void WriteToJson( StreamWriter writer )
    {
      // sanity
      if (writer == null) return;
      if (this.Count <= 0) return;

      /*
      logLines:[
        { lineType: "", arguments: [ { arg: "", value: "" }, .. { arg: "", value: "" } ] },
        ..
        { lineType: "", arguments: [ { arg: "", value: "" }, .. { arg: "", value: "" } ] }
      ]
       */
      writer.WriteLine( $"{{ \"logLines\":[" );
      string lls = "";
      foreach (var lline in this) {
        // write last captured so we can omit the ending comma below
        if (!string.IsNullOrEmpty( lls )) {
          writer.WriteLine( lls );
        }
        lls = lline.AsJson + ", ";
      }
      lls = lls.TrimEnd( new char[] { ' ', ',' } ); // remove ending comma
      if (!string.IsNullOrEmpty( lls )) {
        writer.WriteLine( lls );
      }
      writer.WriteLine( $"]}}" );
      writer.Flush( );
    }

  }
}
