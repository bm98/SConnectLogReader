using System;
using System.Collections.Generic;

namespace SCLogLib
{
  /// <summary>
  /// Defines a type for a Client Catalog
  /// </summary>
  public class ClientCat : Dictionary<long, Client>
  {
    /// <summary>
    /// Returns the Client name from it's number
    /// </summary>
    /// <param name="clientNumber">The ClientNumber</param>
    /// <returns>A string</returns>
    public string GetClientName(long clientNumber )
    {
      string clint = "unknown client";
      if (this.ContainsKey( clientNumber )) {
        clint = this[clientNumber].ClientName;
      }
      return clint;
    }

  }
}
