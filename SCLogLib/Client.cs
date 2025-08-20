using System;
using System.Collections.Generic;
using System.Linq;

namespace SCLogLib
{
  /// <summary>
  /// Describes one Client of SimConnect
  /// </summary>
  public class Client
  {
    /// <summary>
    /// Return the Catalog of clients
    /// </summary>
    /// <param name="log">A LogFile</param>
    /// <returns>A ClientCat from the log</returns>
    public static ClientCat ClientList( LogFile log )
    {
      var ret = new ClientCat( );

      var opens = log.Where( ll => ll.LogLineType == LineType.Open );
      foreach (var openLine in opens) {
        var llines = log.Where( ll => ll.ClientNumber == openLine.ClientNumber );
        var client = new Client( openLine.ClientNumber, openLine.Arguments.FirstOrDefault( p => p.Argument == ArgName.NameS ).ArgS, llines.Count( ) );
        ret.Add( openLine.ClientNumber, client );
      }
      return ret;
    }

    /// <summary>
    /// ClientNumber - Logfile ID of this Client
    /// </summary>
    public long ClientNumber { get; protected set; }

    /// <summary>
    /// Name of this Client
    /// </summary>
    public string ClientName { get; protected set; }

    /// <summary>
    /// Number of LogLines in the file
    /// </summary>
    public long NumberOfLogLines { get; protected set; }

    /// <summary>
    /// cTor:
    /// </summary>
    public Client( long clientNumber, string clientName, long numLines )
    {
      ClientNumber = clientNumber;
      ClientName = clientName;
      NumberOfLogLines = numLines;
    }

    /// <inheritdoc/>
    public override string ToString( )
    {
      return $"{ClientNumber,-5}: {ClientName} ({NumberOfLogLines:###,###,##0} lines)";
    }

  }
}
