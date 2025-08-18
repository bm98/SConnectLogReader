using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using static SCLogLib.LogLineArgument;

namespace SCLogLib
{
  /// <summary>
  /// Decomposer For SimConnect Log Lines
  /// 
  /// Handle all special cases here to present an uniform format
  /// see below for handled 'issues'
  /// 
  /// </summary>
  internal class Tokenizer
  {
    private string _rawLine = ""; // stored here for debugging

    // token list
    private readonly List<string> _tokens = new List<string>( );

    // indexer for retrieving (set to 0 on create)
    // right now there is no peek or skip or other means than NextToken()
    private int _nextTokenIndex = 0;

    /*
     So far seen:
      Log lines have either a < SimConnect SENT (OUT), > SimConnect RECEIVED (IN), or NO mark as the first char
      below those 3 are handled separately
      
      all lines have a timestamp (seconds I assume)
       will be reported as number token

      there is a Client Reference [N] and received ones may carry a SendID [N, S] to id the sending line
       will be reported as ClientNumber=N and if available ClientSendID=S

      there is a 'Command' item in various forms or we create one..
       will be reported as Cmd=commandstring
       IN commands are SimConnect calls and reported as received
       OUT commands come in a variety with and without space etc.
       such commands are reported as received where a space is substituted with an _ (underscore)
       unmarked commands receive an artificial one close enough to recognize them later

      arguments are mostly reported as arg=value but not all that consistently
       if there is a pair it will be reported as such
       if there is only a value it will be reported by valueType ValueInteger, ValueReal, ValueText
     */

    // Process lines having neither input nor output marks
    // (just what the dev thought would be needed - no particular rule applies... thank you)
    // 0.00000 SimConnect version 12.1.0.0
    // 0.00169 Server: Scope=local, Protocol=IPv4, Address=127.0.0.1, Port=500, MaxClients=64
    // 0.35522 Exe Launched:  Path="C:\Program Files\FenixSim A320\deps\FenixBootstrapper.exe"  CommandLine=""  Version="2.4.0.2070"
    // 29.93329 [327] Disconnected! (5, C000014B)
    private void ProcLineNoMark( string line )
    {
      // make the special cases uniform here
      // handle all kind of weird stuff

      string pLine = line.Trim( );

      int colonPos = pLine.IndexOf( ":" );
      // SimConnect version line
      // 0.00000 SimConnect version 12.1.0.0
      if (pLine.Contains( "SimConnect version" )) {
        pLine = $"{TimestampArg}=" + pLine;
        pLine = pLine.Replace( " SimConnect", $",{CmdArg}=SimConnect" ); // patch CMD
        pLine = pLine.Replace( " version", $",{VersionArg}=" );
        pLine = Regex.Replace( pLine, @"\s+", "" ); // reduce space(s) to nothing
        _tokens.AddRange( pLine.Split( new char[] { ',' } ) ); // split by comma
      }

      // 29.93329 [327] Disconnected! (5, C000014B)
      else if (pLine.Contains( "Disconnected!" )) {
        pLine = Regex.Replace( pLine,
          @"(?<ts>\d+\.\d{5})\s*\[(?<n1>[0-9\s]+)((\,\s*)(?<n2>[0-9\s]*))?\]\s*(?<cmd>\w+)!",
          MatchEval, RegexOptions.Compiled );

        // (5, C000014B) -> ValueInteger=5, ValueText=C000014B
        string replacement = $"{ValueIntegerArg}=${{n1}}, {ValueTextArg}=${{h1}}";
        pLine = Regex.Replace( pLine,
          @"\(\s*(?<n1>[0-9]+)(\,\s*)(?<h1>[0-9\w\s]+)\)", replacement );

        _tokens.AddRange( pLine.Split( new char[] { ',' } ) ); // split by comma
      }

      else if (pLine.Contains( "Server:" )) {
        // Server lines
        /*
            0.00169 Server: Scope=local, Protocol=IPv4, Address=127.0.0.1, Port=500, MaxClients=64
            0.06913 Server: Scope=local, Protocol=IPv6, Address=::1, Port=501, MaxClients=64
            0.14381 Server: Scope=local, Protocol=Pipe, Name=\\.\pipe\Custom\SimConnect, MaxClients=64
            0.21367 Server: Scope=local, Protocol=IPv4, Address=127.0.0.1, Port=62073, MaxClients=64
            0.28231 Server: Scope=local, Protocol=IPv6, Address=::1, Port=62074, MaxClients=64
            0.34823 Server: Scope=local, Protocol=Pipe, Name=\\.\pipe\Microsoft Flight Simulator\SimConnect, MaxClients=64
        */
        pLine = $"{TimestampArg}=" + pLine;
        pLine = pLine.Replace( " Server:", $",{CmdArg}=Server," ); // patch.. CMD
        _tokens.AddRange( pLine.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries ) ); // having pairs split by comma
      }

      else if (pLine.Contains( "Exe Launched:" )) {
        // Exe lines
        /*
          0.35522 Exe Launched:  Path="C:\Program Files\FenixSim A320\deps\FenixBootstrapper.exe"  CommandLine=""  Version="2.4.0.2070"
        */
        pLine = $"{TimestampArg}=" + pLine;
        pLine = pLine.Replace( " Exe Launched:", $",{CmdArg}=Exe_Launched," ); // patch CMD
        pLine = pLine.Replace( " Path=", ",Path=" ); // patch.., add comma
        pLine = pLine.Replace( " CommandLine=", ",CommandLine=" ); // patch.., add comma
        pLine = pLine.Replace( " Version=", ",Version=" ); // patch.., add comma
        pLine = Regex.Replace( pLine, @"\s+", "" ); // reduce space(s) to nothing
        pLine = Regex.Replace( pLine, @"\,+", "," ); // reduce comma(s) to single

        _tokens.AddRange( pLine.Split( new char[] { ',' } ) ); // having pairs split by comma
      }

    }

    // Process lines having an output '<' mark, differnet flavors of those exist...
    // < 9.75206 [326] >>>>>  EXCEPTION=25, SendID=0, Index=-1  <<<<<
    // < 9.32789 [324] Event: 505
    // < 87.86310 [330] Facilities Request:  RequestID=34  count=275
    // < 183.98791 [325] Event:  Group=11  EventID=172  Data=1
    // < 224.74350 [325] EventFrame: 4  166.112946

    // < 57.08117 [328] Flight: 10105
    // < 64.04391 [328] AircraftLoaded: 10107
    // < 224.74276 [325] ObjectData: RequestID=110  DefineID=114
    // < 30.43686 [328] ObjectDataByType: RequestID=1  DefineID=1
    // < 87.83733 [320] ClientData: RequestID=0  DefineID=0  dwSize=296
    // < 226.11711 [325] ObjectAddRemove: EventID=88553  Type=5  ObjectID=70729728
    private void ProcLineOutput( string line )
    {
      // arrives with .., ClientNumber=N, ClientSuffix=S, ...
      // values arrive already as prop=value pairs

      // we replace spaces with comas and reduce to having one comma only
      // seems to work for the examples at hand
      string pLine = Regex.Replace( line, @"[\<\>]+", "" ).Trim( ); // kill exception deco and OUT mark
      pLine = pLine.Replace( ":", "," ); // replace colon with a comma
      pLine = Regex.Replace( pLine, @"\s+", "," ); // reduce space(s) to one comma
      pLine = Regex.Replace( pLine, @"\,+", "," ).Trim( ); // reduce commas(s) to one comma and trim

      // should have lines with fields separated by only one comma and no decoration 
      _tokens.AddRange( pLine.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries ) );
    }

    // gets from Regex [320, 1] Open
    // returns Cmd=.., ClientNumber=.., ClientSendID=.., // ClientSendID is optional
    private string MatchEval( Match match )
    {
      if (!match.Success) return "";

      string s = "";
      if (match.Groups["ts"].Success) {
        s += $"{TimestampArg}={match.Groups["ts"].Value}";
      }
      // add with comma in front
      if (match.Groups["cmd"].Success) {
        s += $",{CmdArg}={match.Groups["cmd"].Value}";
      }
      if (match.Groups["n1"].Success) {
        s += $",{ClientNumberArg}={match.Groups["n1"].Value}";
      }
      if (match.Groups["n2"].Success) {
        s += $",{ClientSendIDArg}={match.Groups["n2"].Value}";
      }
      return $"{s},";
    }

    // Process lines having an input '>' mark

    // > 8.87539 [320, 1]Open: Version=0x00000006  Name="BM98CH_WASM_24"          // patch missing commas
    // > 9.05804 [321, 2]SubscribeToSystemEvent:EventID=0, SystemEventName="6Hz"
    // > 57.21751 [328, 2203]UnsubscribeFromSystemEvent:EventID=10107
    // > 165.45103 [333, 2408] SetDataOnSimObject:DefineID=34, ObjectID=0, Flags=0, ArrayCount=1, cbUnitSize=4, pDataSet=973342084
    // > 30.18931 [328, 4] AddToDataDefinition:DefineID=1, DatumName="SIM ON GROUND", UnitsName="Bool", DatumType=1, fEpsilon=0.000000, DatumID=-1

    // > 8.96533 [320, 4]MapClientDataNameToID:szClientDataName="BM98CH_WASM_24.Command", ClientDataID=0
    // > 8.96534 [320, 5]CreateClientData:ClientDataID=0, dwSize=256, Flags=0
    // > 8.96534 [320, 6]AddToClientDataDefinition:DefineID=0, dwOffset=0, dwSizeOrType=256, fEpsilon=0.000000, DatumID=-1
    // > 57.40456 [325, 19711]ClearDataDefinition:DefineID=126
    // > 57.40771 [328, 2210]RequestSystemState:RequestID=10120, szState="Sim"
    // > 87.83732 [330, 1914]SetClientData:ClientDataID=0, DefineID=0, Flags=0, dwReserved=0, cbUnitSize=256, pDataSet=1040453540
    // > 8.96545 [320, 18]RequestClientData:ClientDataID=0, RequestID=0, DefineID=0, Period=3, Flags=0, origin=0, interval=0, limit=0
    // > 9.32781 [324, 4]RequestDataOnSimObject:RequestID=10001, DefineID=1, ObjectID=0, Period=4, Flags=1, origin=0, interval=0, limit=0
    // > 30.43684 [328, 1933]RequestDataOnSimObjectType:RequestID=1, DefineID=1, dwRadiusMeters=0, type=0
    // > 9.75315 [325, 107]MapClientEventToSimEvent:EventID=47, EventName="MAGNETO2_BOTH"
    // > 157.63296 [333, 2235]TransmitClientEvent:ObjectID=0, EventID=10134, GroupID=1, Flags=16, dwData=122800000
    // > 157.63296 [333, 2235]TransmitClientEvent_EX1:ObjectID=0, EventID=10134, GroupID=1, Flags=16, dwData0=122800000, dwData1=0, dwData2=0, dwData3=0, dwData4=0
    // > 9.75316 [325, 108]AddClientEventToNotificationGroup:GroupID=11, EventID=47, bMaskable=0
    // > 180.04499 [333, 2739]RemoveClientEvent:GroupID=30001, EventID=10122
    // > 87.82126 [330, 20]SetNotificationGroupPriority:GroupID=30001, uPriority=1002
    // > 180.04514 [333, 2751]ClearNotificationGroup:GroupID=30001
    // > 87.86301 [330, 1915]EnumerateInputEvents:RequestID=30
    // > 104.45231 [331, 40]SubscribeInputEvent:Hash=-274244859
    // > 104.36021 [331, 37]UnsubscribeInputEvent:Hash=0
    // > 183.98788 [330, 4041]SetInputEvent:Hash=-2047808529, cbUnitSize=8, Value=-2013003572
    private void ProcLineInput( string line )
    {
      // arrives alredy with .., ClientNumber=N, ClientSendID=S, ...
      // values arrive already as prop=value pairs

      // having an uniform format we...
      // remove the input mark
      // replace the colon with a comma
      // replace space with comma
      // cleanup double occurences
      string pLine = Regex.Replace( line, @"[\>]+", "" ).Trim( ); // kill  IN mark
      pLine = pLine.Replace( ":", "," ); // replace colon with a comma
      pLine = pLine.Replace( ", ", "," ); // reduce comma space to comma only
      pLine = Regex.Replace( pLine, @"\s+", "," ); ; // reduce space(s) to one comma and trim (Open has only a space, no comma)
      pLine = Regex.Replace( pLine, @"\,+", "," ).Trim( ); // reduce commas(s) to one comma and trim

      // should have lines with fields separated by only one comma and no decoration 
      _tokens.AddRange( pLine.Split( new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries ) );
    }


    /// <summary>
    /// cTor:
    /// </summary>
    /// <param name="line">LogLine to disect</param>
    public Tokenizer( string line )
    {
      _rawLine = line.Trim( );
      string pLine = _rawLine;
      _nextTokenIndex = 0;

      if (pLine.StartsWith( ">" )) {
        // IN lines don't need a lot of treatment, except that Open has no comma separator..

        // derive Cmd, ClientNumber and ClientSendID
        // [330, 4041]SetInputEvent:
        // [320] ClientData:
        pLine = Regex.Replace( pLine,
          @"(?<ts>\d+\.\d{5})\s*\[(?<n1>[0-9\s]+)((\,\s*)(?<n2>[0-9\s]*))?\]\s*(?<cmd>\w+):",
          MatchEval, RegexOptions.Compiled );

        ProcLineInput( pLine );
      }

      else if (pLine.StartsWith( "<" )) {
        // OUT: Server issued replies - very inconsistent, patch up here to have uniform processing later

        if (pLine.Contains( ">>>" )) {
          // < 9.75206 [326] >>>>>  EXCEPTION=25, SendID=0, Index=-1  <<<<<
          pLine = pLine.Replace( ">>>", "Exception: " ); // make it uniform with others and add a CMD: string
          // < 9.75206 [326] Exception: >>  EXCEPTION=25, SendID=0, Index=-1  <<<<<
        }
        pLine = pLine.Replace( "Facilities Request", "Facilities_Request" ); // replace space with _ in command part
        pLine = pLine.Replace( "ICAO Request", "ICAO_Request" ); // replace space with _ in command part

        // < 9.75090 [320] Event: 2  // has no prop=value pair
        // < 183.98791[325] Event: Group = 11  EventID = 172  Data = 1 // another Event that should be left alone below...
        if (pLine.Contains( " Event: " )) {
          string replacement = $"Event: {ValueIntegerArg}=${{n1}}"; // make a prop field from the number
          pLine = Regex.Replace( pLine, @"Event:\s+(?<n1>\d+)", replacement );
        }
        // < 224.74372 [325] EventFrame: 1  166.112946
        else if (pLine.Contains( " EventFrame: " )) {
          string replacement = $"EventFrame: {ValueIntegerArg}=${{n1}}, {ValueRealArg}=${{n2}}"; // make prop fields from the numbers
          pLine = Regex.Replace( pLine, @"EventFrame:\s+(?<n1>\d+)\s+(?<n2>\d+(\.\d+)?)", replacement );
        }
        // < 57.08117 [328] Flight: 10105
        else if (pLine.Contains( " Flight: " )) {
          string replacement = $"Flight: {ValueIntegerArg}=${{n1}}"; // make a prop field from the number
          pLine = Regex.Replace( pLine, @"Flight:\s+(?<n1>\d+)", replacement );
        }
        // < 64.04391 [328] AircraftLoaded: 10107
        else if (pLine.Contains( " AircraftLoaded: " )) {
          string replacement = $"AircraftLoaded: {ValueIntegerArg}=${{n1}}"; // make a prop field from the number
          pLine = Regex.Replace( pLine, @"AircraftLoaded:\s+(?<n1>\d+)", replacement );
        }

        // derive Cmd, ClientNumber and ClientSendID
        // 183.98791[330, 4041]SetInputEvent:
        // 9.75090 [320] ClientData:
        pLine = Regex.Replace( pLine,
          @"(?<ts>\d+\.\d{5})\s*\[(?<n1>[0-9\s]+)((\,\s*)(?<n2>[0-9\s]*))?\]\s*(?<cmd>\w+):",
          MatchEval, RegexOptions.Compiled );

        ProcLineOutput( pLine );
      }

      else {
        // those few are handled per linetype in the method
        ProcLineNoMark( pLine );
      }

    }


    /// <summary>
    /// Returns the next token or an empty string
    /// </summary>
    /// <returns></returns>
    public string NextToken( )
    {
      if (_nextTokenIndex < _tokens.Count) return _tokens[_nextTokenIndex++].Trim( );
      else return "";
    }

  }
}
