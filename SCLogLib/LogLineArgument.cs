using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SCLogLib
{
  /// <summary>
  /// Argument Names of a LogLine commands
  /// </summary>
  public enum ArgName
  {
    // NOTE: arg names are case sensitive and definend how they appear in logfiles (and SDK docs)
    //       Name as found are of type Integer and stored as long
    //       Real types are extended with R and stored as double (the factory will detect and handle the extension and conversion)
    //       Text types are extended with S and stored as string (the factory will detect and handle the extension and conversion)


    /// <summary>
    /// Unknown (not decoded argument, stored as string value)
    /// </summary>
    UnknownS = 0,

    // self created ones from the App
    /// <summary>
    /// A Timestamp, double
    /// </summary>
    TimestampR,
    /// <summary>
    /// A Cmd, string
    /// </summary>
    CmdS,
    /// <summary>
    /// A ClientNumber, long
    /// </summary>
    ClientNumber,
    /// <summary>
    /// A ClientSendID, long
    /// </summary>
    ClientSendID,

    /// <summary>
    /// A Text Value where no prop is given, string
    /// </summary>
    ValueTextS,
    /// <summary>
    /// An Integer Value where no prop is given (Events), long
    /// </summary>
    ValueInteger,
    /// <summary>
    /// A real Value where no prop is given (Events), double
    /// </summary>
    ValueRealR,

    // Logfile Arguments 

    /// <summary>
    /// A Name, string
    /// </summary>
    NameS,
    /// <summary>
    /// A Version, string
    /// </summary>
    VersionS,

    /// <summary>
    /// An EXCEPTION, long
    /// </summary>
    EXCEPTION,

    /// <summary>
    /// A Scope, string
    /// </summary>
    ScopeS,
    /// <summary>
    /// A Protocol, string
    /// </summary>
    ProtocolS,
    /// <summary>
    /// An IP Address, string
    /// </summary>
    AddressS,
    /// <summary>
    /// A Port, long
    /// </summary>
    Port,
    /// <summary>
    /// A MaxClients Number, long
    /// </summary>
    MaxClients,

    /// <summary>
    /// A Path, string
    /// </summary>
    PathS,
    /// <summary>
    /// A CommandLine, string
    /// </summary>
    CommandLineS,

    /// <summary>
    /// An Exception, long
    /// </summary>
    Exception,

    /// <summary>
    /// A SystemEventName, string
    /// </summary>
    SystemEventNameS,
    /// <summary>
    /// An szClientDataName, string
    /// </summary>
    szClientDataNameS,

    /// <summary>
    /// An EventID, long
    /// </summary>
    EventID,
    /// <summary>
    /// An DownEventID, long
    /// </summary>
    DownEventID,
    /// <summary>
    /// An UpEventID, long
    /// </summary>
    UpEventID,
    /// <summary>
    /// A RequestID, long
    /// </summary>
    RequestID,
    /// <summary>
    /// A cbRequestID, long
    /// </summary>
    cbRequestID,
    /// <summary>
    /// An ObjectID, long
    /// </summary>
    ObjectID,
    /// <summary>
    /// A GroupID, long
    /// </summary>
    GroupID,
    /// <summary>
    /// A DefineID, long
    /// </summary>
    DefineID,
    /// <summary>
    /// A DatumID, long
    /// </summary>
    DatumID,
    /// <summary>
    /// A ClientDataID, long
    /// </summary>
    ClientDataID,
    /// <summary>
    /// A SendID, long
    /// </summary>
    SendID,
    /// <summary>
    /// A newElemInRangeRequestID, long
    /// </summary>
    newElemInRangeRequestID,
    /// <summary>
    /// A oldElemOutRangeRequestID, long
    /// </summary>
    oldElemOutRangeRequestID,

    /// <summary>
    /// A dwWord, long
    /// </summary>
    dwWord,
    /// <summary>
    /// A dwState, long
    /// </summary>
    dwState,
    /// <summary>
    /// A dwData, long
    /// </summary>
    dwData,
    /// <summary>
    /// A dwData0, long
    /// </summary>
    dwData0,
    /// <summary>
    /// A dwData1, long
    /// </summary>
    dwData1,
    /// <summary>
    /// A dwData2, long
    /// </summary>
    dwData2,
    /// <summary>
    /// A dwData3, long
    /// </summary>
    dwData3,
    /// <summary>
    /// A dwData4, long
    /// </summary>
    dwData4,
    /// <summary>
    /// A dwSize, long
    /// </summary>
    dwSize,
    /// <summary>
    /// A dwSizeOrType, long
    /// </summary>
    dwSizeOrType,
    /// <summary>
    /// A dwOffset, long
    /// </summary>
    dwOffset,
    /// <summary>
    /// A dwArrayCount, long
    /// </summary>
    dwArrayCount,
    /// <summary>
    /// A dwReserved, long
    /// </summary>
    dwReserved,
    /// <summary>
    /// A dwRadiusMeters, long
    /// </summary>
    dwRadiusMeters,
    /// <summary>
    /// An fEpsilon, double
    /// </summary>
    fEpsilon,
    /// <summary>
    /// An uPriority, long
    /// </summary>
    uPriority,
    /// <summary>
    /// A bMaskable, long
    /// </summary>
    bMaskable,
    /// <summary>
    /// A bUnsubscribeNewInRange, long (bool)
    /// </summary>
    bUnsubscribeNewInRange,
    /// <summary>
    /// A bUnsubscribeOldOutRange, long (bool)
    /// </summary>
    bUnsubscribeOldOutRange,
    /// <summary>
    /// A cbUnitSize, long
    /// </summary>
    cbUnitSize,
    /// <summary>
    /// A cbFilterDataSize, long
    /// </summary>
    cbFilterDataSize,
    /// <summary>
    /// A pDataSet, long
    /// </summary>
    pDataSet,
    /// <summary>
    /// A pParamValues, long
    /// </summary>
    pParamValues,
    /// <summary>
    /// A pFilterData, long
    /// </summary>
    pFilterData,
    /// <summary>
    /// A pIndexes, long
    /// </summary>
    pIndexes,
    /// <summary>
    /// An szState, string
    /// </summary>
    szStateS,
    /// <summary>
    /// An szActionID, string
    /// </summary>
    szActionIDS,
    /// <summary>
    /// An szFileName, string
    /// </summary>
    szFileNameS,
    /// <summary>
    /// An szFilterPath, string
    /// </summary>
    szFilterPathS,
    /// <summary>
    /// An szTitle, string
    /// </summary>
    szTitleS,
    /// <summary>
    /// An szDescription, string
    /// </summary>
    szDescriptionS,
    /// <summary>
    /// An szContainerTitle, string
    /// </summary>
    szContainerTitleS,
    /// <summary>
    /// An szLivery, string
    /// </summary>
    szLiveryS,
    /// <summary>
    /// An szTailNumber, string
    /// </summary>
    szTailNumberS,
    /// <summary>
    /// An szAirportID, string
    /// </summary>
    szAirportIDS,
    /// <summary>
    /// An szAirportIcao, string
    /// </summary>
    szAirportIcaoS,
    /// <summary>
    /// An iFlightNumber, long
    /// </summary>
    iFlightNumber,
    /// <summary>
    /// An szFlightPlanPath, string
    /// </summary>
    szFlightPlanPathS,
    /// <summary>
    /// An dFlightPlanPosition, real
    /// </summary>
    dFlightPlanPositionR,
    /// <summary>
    /// A bTouchAndGo, long (bool)
    /// </summary>
    bTouchAndGo,
    /// <summary>
    /// A pszInputDefinition, long
    /// </summary>
    pszInputDefinition,
    /// <summary>
    /// An szKeyChoice1, string
    /// </summary>
    szKeyChoice1S,
    /// <summary>
    /// An szKeyChoice2, string
    /// </summary>
    szKeyChoice2S,
    /// <summary>
    /// An szKeyChoice3, string
    /// </summary>
    szKeyChoice3S,

    /// <summary>
    /// A Type, long
    /// </summary>
    Type,
    /// <summary>
    /// A type, long
    /// </summary>
    type,
    /// <summary>
    /// An Index, long
    /// </summary>
    Index,
    /// <summary>
    /// A Period, long
    /// </summary>
    Period,
    /// <summary>
    /// A Flags, long
    /// </summary>
    Flags,
    /// <summary>
    /// A Group, long
    /// </summary>
    Group,
    /// <summary>
    /// A Data, long
    /// </summary>
    Data,
    /// <summary>
    /// An origin, long
    /// </summary>
    origin,
    /// <summary>
    /// An interval, long
    /// </summary>
    interval,
    /// <summary>
    /// A limit, long
    /// </summary>
    limit,
    /// <summary>
    /// A DatumName, string
    /// </summary>
    DatumNameS,
    /// <summary>
    /// A DatumType, long
    /// </summary>
    DatumType,
    /// <summary>
    /// A UnitsName, string
    /// </summary>
    UnitsNameS,
    /// <summary>
    /// A EventName, string
    /// </summary>
    EventNameS,
    /// <summary>
    /// A FieldName, string
    /// </summary>
    FieldNameS,
    /// <summary>
    /// A count, long
    /// </summary>
    count,
    /// <summary>
    /// A Hash, long
    /// </summary>
    Hash,
    /// <summary>
    /// An ArrayCount, long
    /// </summary>
    ArrayCount,
    /// <summary>
    /// A Value, long
    /// </summary>
    Value,
    /// <summary>
    /// A Value, string
    /// </summary>
    ICAOS,
    /// <summary>
    /// A Value, string
    /// </summary>
    RegionS,
    /// <summary>
    /// A InitPos, long (SIMCONNECT_DATA_INITPOSITION)
    /// </summary>
    InitPos,
    /// <summary>
    /// A DownValue, long
    /// </summary>
    DownValue,
    /// <summary>
    /// An UpValue, long
    /// </summary>
    UpValue,

    // from Debug section

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    pdwSendID, // a pointer
    pDest, // a pointer
    cbDest, // a DWORD
    ppEnd, // a pointer
    pcbStringV, // a pointer
    pSourceS,  // a string
    nCount, // a DWORD
    fElapsedSeconds, // a pointer to floats
    pData, // a pointer
    cbData, // a DWORD
    pStringV, // a pointer
    ppszString, // a pointer
    pcbString, // a pointer
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

  }





  /// <summary>
  /// One Argument item of a LogLine
  ///  type is one of Integer (long), Real (double), Text (string)
  /// </summary>
  public class LogLineArgument
  {
    // provide Argument Names here where the Enum is defined
    // - need to define them without the Type mark in order to work for the Tokenizer

    /// <summary>
    /// LogLine Arg Name for Timestamp 
    /// </summary>
    public const string TimestampArg = "Timestamp";
    /// <summary>
    /// LogLine Arg Name for ClientNumber 
    /// </summary>
    public const string ClientNumberArg = "ClientNumber";
    /// <summary>
    /// LogLine Arg Name for ClientSendID 
    /// </summary>
    public const string ClientSendIDArg = "ClientSendID";
    /// <summary>
    /// LogLine Arg Name for Cmd 
    /// </summary>
    public const string CmdArg = "Cmd";

    /// <summary>
    /// LogLine Arg Name for Version 
    /// </summary>
    public const string VersionArg = "Version";
    /// <summary>
    /// LogLine Arg Name for ValueText 
    /// </summary>
    public const string ValueTextArg = "ValueText";
    /// <summary>
    /// LogLine Arg Name for ValueInteger 
    /// </summary>
    public const string ValueIntegerArg = "ValueInteger";
    /// <summary>
    /// LogLine Arg Name for ValueReal 
    /// </summary>
    public const string ValueRealArg = "ValueReal";


    /// <summary>
    /// Returns a Typed Arg Item for the given arguments
    /// </summary>
    /// <param name="name">Argument Name</param>
    /// <param name="value">Argument Value</param>
    /// <returns>A LogLineArgument</returns>
    public static LogLineArgument GetArg( string name, string value )
    {
      // unmarked ones are of type Integer
      if (Enum.TryParse( name, out ArgName vPI )) {
        return new LogLineArgument( vPI, FromStringI( value ) ); ;
      }
      // marked with ending S (e.g. NameS) are strings
      else if (Enum.TryParse( name + "S", out vPI )) {
        return new LogLineArgument( vPI, value ); ;
      }
      // marked with ending R (e.g. fEpsilonR) are Real types
      else if (Enum.TryParse( name + "R", out vPI )) {
        return new LogLineArgument( vPI, FromStringR( value ) ); ;
      }

      else {
        // catch missed ones
#if DEBUG
        // add to enum when landing here
        throw new ArgumentException( $"Undhandled argument type: {name}" );
#endif

#pragma warning disable CS0162 // Unreachable code detected
        return new LogLineArgument( ArgName.UnknownS, name + "=" + value );
#pragma warning restore CS0162 // Unreachable code detected
      }
    }


    // convert without data loss
    private static string AsText( object p )
    {
      if (p == null) return "";
      if (p is string valS) return valS;
      if (p is double valD) return valD.ToString( );
      if (p is float valF) return valF.ToString( );
      if (p is int valI) return valI.ToString( );
      if (p is long valL) return valL.ToString( );
      if (p is bool valB) return valB.ToString( );
      return "";
    }
    // convert without data loss
    private static bool AsBool( object p )
    {
      if (p == null) return false;
      if (p is bool valB) return valB;
      if (p is string valS) return !string.IsNullOrEmpty( valS );// returns the String as Bool (true -> not empty or WS)
      if (p is double valD) return valD > 0; // returns the Double as Bool (true -> >0)
      if (p is float valF) return valF > 0; // returns the Float as Bool (true -> >0)
      if (p is int valI) return valI > 0; // returns the Int as Bool (true -> >0)
      if (p is long valL) return valL > 0; // returns the Long as Bool (true -> >0)
      return false;
    }
    // convert without data loss or NaN
    private static double AsReal( object p )
    {
      if (p == null) return float.NaN;
      if (p is double valD) return valD;
      if (p is float valF) return valF;
      if (p is long valL) return valL; // returns the Long as Float
      if (p is int valI) return valI; // returns the Int as Float
      if (p is bool valB) return valB ? 1f : 0f;
      return float.NaN;
    }
    // convert without data loss or MinValue
    private static long AsInteger( object p )
    {
      if (p == null) return long.MinValue;
      if (p is long valL) return valL;
      if (p is int valI) return valI;
      if (p is bool valB) return valB ? 1 : 0;
      return long.MinValue;
    }

    // Returns a Real (double) from a string or NaN
    private static double FromStringR( string v )
    {
      if (double.TryParse( v, out double val )) return val;
      return double.NaN;
    }
    // Returns an Integer (long) from a string or long.MinValue
    private static long FromStringI( string i )
    {
      if (long.TryParse( i, out long val )) return val;
      return long.MinValue;
    }

    /// <summary>
    /// cTor:
    /// </summary>
    /// <param name="argName">Argument Name (type)</param>
    /// <param name="argValue">Argument Value</param>
    public LogLineArgument( ArgName argName, object argValue )
    {
      Argument = argName;
      ArgValueObj = argValue;
    }

    /// <summary>
    /// The Argument contained
    /// </summary>
    public ArgName Argument { get; protected set; } = ArgName.UnknownS;
    /// <summary>
    /// The Argument value as object
    /// </summary>
    public object ArgValueObj { get; protected set; } = ""; // default is UnknownS which must be a string

    /// <summary>
    /// True for an Integer (long) Argument
    /// </summary>
    public bool IsInteger => (ArgValueObj != null) && (ArgValueObj is long);
    /// <summary>
    /// Argument value converted to Integer (long or long.MinValue)
    /// </summary>
    public long ArgI => AsInteger( ArgValueObj );

    /// <summary>
    /// True for a Real (double) Argument
    /// </summary>
    public bool IsReal => (ArgValueObj != null) && (ArgValueObj is double);
    /// <summary>
    /// Argument value converted to Real (double or double.NaN)
    /// </summary>
    public double ArgR => AsReal( ArgValueObj );

    /// <summary>
    /// True for a string Argument
    /// </summary>
    public bool IsText => (ArgValueObj != null) && (ArgValueObj is string);
    /// <summary>
    /// Argument value converted to String (or an empty string)
    ///   may contain unprintable Ctrl chars (use ArgSescaped if needed)
    /// </summary>
    public string ArgS => AsText( ArgValueObj );
    /// <summary>
    /// Argument value converted to String escaped for JSON i.e. \-> \\
    ///  and replace Ctrl Chars with an UNICODE Control Set char U+2400 .. U+2426
    /// </summary>
    protected string ArgSescaped => MakePrintableCtrlChars( AsText( ArgValueObj ) ).Replace( "\\", "\\\\" );

    /* BOOL is not used as source type right now
    /// <summary>
    /// True for a bool Argument
    /// </summary>
    public bool IsBool => (ArgValueObj != null) && (ArgValueObj is bool);
    */
    /// <summary>
    /// Argument value converted to bool
    /// </summary>
    public bool ArgB => AsBool( ArgValueObj );


    /// <summary>
    /// Json of this property
    /// </summary>
    public string AsJson {
      get {
        /*
            { arg: "", value: "" || digits }
        */
        if (IsInteger) return $"{{ \"arg\": \"{Argument}\", \"value\": {ArgI.ToString( CultureInfo.InvariantCulture )} }}";
        else if (IsReal) return $"{{ \"arg\": \"{Argument}\", \"value\": {ArgR.ToString( "F6", CultureInfo.InvariantCulture )} }}";
        else return $"{{ \"arg\": \"{Argument}\", \"value\": \"{ArgSescaped}\" }}";
      }
    }


    /// <inheritdoc/>
    public override string ToString( ) => $"{Argument}:{ArgSescaped}";


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
  }
}
