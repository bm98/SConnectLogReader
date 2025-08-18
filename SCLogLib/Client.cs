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
      foreach (var l in opens) {
        var client = new Client( l.ClientNumber, l.Arguments.FirstOrDefault( p => p.Argument == ArgNames.NameS ).ArgS );
        ret.Add( l.ClientNumber, client );
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
    /// cTor:
    /// </summary>
    public Client( long clientNumber, string clientName )
    {
      ClientNumber = clientNumber;
      ClientName = clientName;
    }

    /// <inheritdoc/>
    public override string ToString( )
    {
      return $"{ClientNumber,-5}: {ClientName}";
    }

  }
}
