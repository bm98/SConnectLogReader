using System;
using System.IO;

namespace SCLogLib
{
  /// <summary>
  /// SimConnect Log Reader
  /// </summary>
  public class SCL_Reader : IDisposable
  {
    private const int c_lineReporting = 1000; // modulo const for reported lines

    // debug store the filename
    private string _filename = "";
    // the created reader
    private StreamReader _reader = null;
    // read line counter
    private long _lineCount = 0;
    private double _byteCount = 0;

    /// <summary>
    /// Fired when the line counter is updated (every 1000 lines for now)
    /// </summary>
    public event EventHandler<EventArgs> LineCountUpdate;

    /// <summary>
    /// cTor: empty
    /// </summary>
    public SCL_Reader( )
    {
      _lineCount = 0;
      _byteCount = 0;
    }

    /// <summary>
    /// cTor: with file
    /// </summary>
    /// <param name="filename">Fully qualified file</param>
    public SCL_Reader( string filename )
    {
      _lineCount = 0;
      if (!OpenLog( filename )) {
        _reader?.Dispose( );
        _reader = null;
      }
    }

    /// <summary>
    /// number of lines returned
    /// </summary>
    public long LinesRead => _lineCount;

    /// <summary>
    /// Returns the percentage of the file read
    /// </summary>
    public double PercentRead => Math.Min( (_byteCount / _reader.BaseStream.Length) * 100.0, 100.0 );

    /// <summary>
    /// Size of the file opened or -1
    /// </summary>
    public long FileSize {
      get {
        if (_reader == null) return -1;
        return _reader.BaseStream.Length;
      }
    }

    /// <summary>
    /// Open a Logfile from file path
    /// </summary>
    /// <param name="filename">Fully qualified file</param>
    /// <returns>True if opened</returns>
    public bool OpenLog( string filename )
    {
      // sanity 
      if (string.IsNullOrEmpty( filename )) return false;
      if (!File.Exists( filename )) return false;

      _filename = filename;

      // already open
      if (_reader != null) {
        _reader.Close( );
        _reader.Dispose( );
        _reader = null;
      }

      _reader = new StreamReader( filename );
      _reader.BaseStream.Seek( 0, SeekOrigin.Begin );

      return true;
    }

    /// <summary>
    /// Read a line, skip empty ones
    /// </summary>
    /// <returns></returns>
    public string ReadLine( )
    {
      if (_reader == null) return "";
      if (_reader.EndOfStream) return "";

      try {
        string line = _reader.ReadLine( );
        _byteCount += line.Length + 2; // file is ASCII/ANSI not multibyte Unicode +crlf
        line = RemoveNULL( line );

        while (string.IsNullOrEmpty( line )) {
          line = RemoveNULL( _reader.ReadLine( ) );
          _byteCount += 2; // crlf
        }
        _lineCount++;

        if ((_lineCount % c_lineReporting) == 0) LineCountUpdate?.Invoke( this, EventArgs.Empty );

        return line;
      }
      catch (Exception ex){
        ;
      }
      return "";
    }

    // dam file has a line with a NULL char in it ...
    private string RemoveNULL( string line )
    {
      if (line.Length == 1) return "";
      else return line;
    }


    #region DISPOSE

    private bool disposedValue;

    /// <inheritdoc/>
    protected virtual void Dispose( bool disposing )
    {
      if (!disposedValue) {
        if (disposing) {
          // TODO: dispose managed state (managed objects)
          _reader.Dispose( );
        }

        // TODO: free unmanaged resources (unmanaged objects) and override finalizer
        // TODO: set large fields to null
        disposedValue = true;
      }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~SCL_Reader()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    /// <inheritdoc/>
    public void Dispose( )
    {
      // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
      Dispose( disposing: true );
      GC.SuppressFinalize( this );
    }

    #endregion

  }
}
