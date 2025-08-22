using System;
using System.Collections.Generic;
using System.Linq;

namespace SCLogLib
{
  /// <summary>
  /// Decoded Line Types
  ///  Server issued line types start with Sc...
  /// </summary>
  public enum LineType
  {
    /// <summary>
    /// An empty line
    /// </summary>
    None = 0,
    /// <summary>
    /// A not decoded token line
    ///  -- may be add this for the next version then
    /// </summary>
    Other,

    // NOTE: enums below MUST match the expected Cmd= property value
    //       where OUT cmds are prepended with Sc and IN cmds are as listed in the SDK
    //       OUT cmds containing a space in the Log are patched with space-> _ (underscore) in Tokenizer
    //       other OUT cmds need to be identified case by case and added when needed
    //       DEBUG build catches unknown ones with an Exception, Release will pass them as LineType=Other

    /// <summary>
    /// SimConnect Version info
    ///  e.g. 0.00000 SimConnect version 12.1.0.0
    /// </summary>
    ScSimConnect,
    /// <summary>
    /// Server Port reporting
    ///  e.g. 0.00169 Server: Scope=local, Protocol=IPv4, Address=127.0.0.1, Port=500, MaxClients=64
    /// </summary>
    ScServer,

    /// <summary>
    /// Startup Exe Laucher info
    ///  e.g. 0.35522 Exe Launched:  Path="C:\Program Files\FenixSim A320\deps\FenixBootstrapper.exe"  CommandLine=""  Version="2.4.0.2070"
    /// </summary>
    ScExe_Launched,

    /// <summary>
    /// OUT: 9.32789 [324] Event: 505
    /// OUT: 183.98791 [325] Event:  Group=11  EventID=172  Data=1
    /// </summary>
    ScEvent,
    /// <summary>
    /// OUT: 224.74350 [325] EventFrame: 4  166.112946
    /// </summary>
    ScEventFrame,
    /// <summary>
    /// OUT: 57.08117 [328] Flight: 10105
    /// </summary>
    ScFlight,
    /// <summary>
    /// OUT: 64.04391 [328] AircraftLoaded: 10107
    /// </summary>
    ScAircraftLoaded,

    /// <summary>
    /// OUT: 224.74276 [325] ObjectData: RequestID=110  DefineID=114
    /// </summary>
    ScObjectData,
    /// <summary>
    /// OUT: 30.43686 [328] ObjectDataByType: RequestID=1  DefineID=1
    /// </summary>
    ScObjectDataByType,
    /// <summary>
    /// OUT: 87.83733 [320] ClientData: RequestID=0  DefineID=0  dwSize=296
    /// </summary>
    ScClientData,
    /// <summary>
    /// OUT: 226.11711 [325] ObjectAddRemove: EventID=88553  Type=5  ObjectID=70729728
    /// </summary>
    ScObjectAddRemove,

    /// <summary>
    /// OUT: 87.86310 [330] Facilities Request:  RequestID=34  count=275
    /// </summary>
    ScFacilities_Request,

    /// <summary>
    /// OUT: 484.00751 [331] ICAO Request:  RequestID=30  count=2
    /// </summary>
    ScICAO_Request,

    /// <summary>
    /// OUT: 9.75202 [326] >>>>>  EXCEPTION=25, SendID=0, Index=-1  ˂˂˂˂˂˂
    /// </summary>
    ScException,

    /// <summary>
    /// 29.93329 [327] Disconnected! (5, C000014B)
    /// </summary>
    ScDisconnected,

    // *** TO BE TESTED...

    /// <summary>
    /// TODO Prospective reply to a Flow Event subscription
    /// OUT: 484.00751 [331] Flow_Event:  Flow_Event=
    /// </summary>
    ScFlow_Event,

    // included and ordered them along the SDK 2024 listing

    // Section General

    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]Close:
    /// </summary>
    Close,
    /// <summary>
    /// IN: 8.87539 [320, 1]Open: Version=0x00000006  Name="BM98CH_WASM_24"
    /// </summary>
    Open,
    /// <summary>
    /// IN: 57.40771 [328, 2210]RequestSystemState:RequestID=10120, szState="Sim"
    /// </summary>
    RequestSystemState,
    /// <summary>
    /// IN: 87.82126 [330, 20]SetNotificationGroupPriority:GroupID=30001, uPriority=1002
    /// </summary>
    SetNotificationGroupPriority,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]ExecuteAction:cbRequestID=, szActionID=, cbUnitSize=, pParamValues= 
    /// </summary>
    ExecuteAction,

    // Section AI Object

    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]AICreateEnrouteATCAircraft:szContainerTitle=, szTailNumber=, iFlightNumber=, szFlightPlanPath= , dFlightPlanPosition= , bTouchAndGo= , RequestID= 
    /// </summary>
    AICreateEnrouteATCAircraft,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]AICreateEnrouteATCAircraft_EX1:szContainerTitle=, szLivery=, szTailNumber=, iFlightNumber=, szFlightPlanPath= , dFlightPlanPosition= , bTouchAndGo= , RequestID= 
    /// </summary>
    AICreateEnrouteATCAircraft_EX1,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]AICreateNonATCAircraft:szContainerTitle=, szTailNumber=, InitPos=  , RequestID= 
    /// </summary>
    AICreateNonATCAircraft,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]AICreateNonATCAircraft_EX1:szContainerTitle=, szLivery=, szTailNumber=, InitPos=  , RequestID= 
    /// </summary>
    AICreateNonATCAircraft_EX1,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]AICreateParkedATCAircraft:szContainerTitle=, szTailNumber=, szAirportID=, RequestID= 
    /// </summary>
    AICreateParkedATCAircraft,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]AICreateParkedATCAircraft_EX1:szContainerTitle=, szLivery=, szTailNumber=, szAirportID=, RequestID= 
    /// </summary>
    AICreateParkedATCAircraft_EX1,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]AICreateSimulatedObject:szContainerTitle=, InitPos=  , RequestID= 
    /// </summary>
    AICreateSimulatedObject,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]AICreateSimulatedObject_EX1:szContainerTitle=, szLivery=, InitPos=  , RequestID= 
    /// </summary>
    AICreateSimulatedObject_EX1,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]AIReleaseControl:ObjectID=, RequestID= 
    /// </summary>
    AIReleaseControl,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]AIRemoveObject:ObjectID=, RequestID= 
    /// </summary>
    AIRemoveObject,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]AISetAircraftFlightPlan:ObjectID=, szFlightPlanPath= , RequestID= 
    /// </summary>
    AISetAircraftFlightPlan,
    /// <summary>
    /// IN: 1931.46236 [334, 3448]EnumerateSimObjectsAndLiveries:RequestID=16777221, Type=0
    /// </summary>
    EnumerateSimObjectsAndLiveries,

    // Section Events and Data

    /// <summary>
    /// IN: 9.75316 [325, 108]AddClientEventToNotificationGroup:GroupID=11, EventID=47, bMaskable=0
    /// </summary>
    AddClientEventToNotificationGroup,
    /// <summary>
    /// IN: 8.96534 [320, 6]AddToClientDataDefinition:DefineID=0, dwOffset=0, dwSizeOrType=256, fEpsilon=0.000000, DatumID=-1
    /// </summary>
    AddToClientDataDefinition,
    /// <summary>
    /// IN: 30.18931 [328, 4] AddToDataDefinition:DefineID=1, DatumName="SIM ON GROUND", UnitsName="Bool", DatumType=1, fEpsilon=0.000000, DatumID=-1
    /// </summary>
    AddToDataDefinition,
    /// <summary>
    /// IN: 57.40456 [325, 19711]ClearClientDataDefinition:DefineID=126
    /// </summary>
    ClearClientDataDefinition,
    /// <summary>
    /// IN: 57.40456 [325, 19711]ClearDataDefinition:DefineID=126
    /// </summary>
    ClearDataDefinition,
    /// <summary>
    /// IN: 57.40456 [325, 19711]ClearInputGroup:GroupID=126
    /// </summary>
    ClearInputGroup,
    /// <summary>
    /// IN: 180.04514 [333, 2751]ClearNotificationGroup:GroupID=30001
    /// </summary>
    ClearNotificationGroup,
    /// <summary>
    /// IN: 8.96534 [320, 5]CreateClientData:ClientDataID=0, dwSize=256, Flags=0
    /// </summary>
    CreateClientData,
    /// <summary>
    /// IN: 8.96533 [320, 4]MapClientDataNameToID:szClientDataName="BM98CH_WASM_24.Command", ClientDataID=0
    /// </summary>
    MapClientDataNameToID,
    /// <summary>
    /// IN: 9.75315 [325, 107]MapClientEventToSimEvent:EventID=47, EventName="MAGNETO2_BOTH"
    /// </summary>
    MapClientEventToSimEvent,
    /// <summary>
    /// IN: 180.04499 [333, 2739]RemoveClientEvent:GroupID=30001, EventID=10122
    /// </summary>
    RemoveClientEvent,
    /// <summary>
    /// Not seen in logs
    /// IN: 180.04499 [333, 2739]RemoveInputEvent:GroupID=, pszInputDefinition=
    /// </summary>
    RemoveInputEvent,
    /// <summary>
    /// IN: 8.96545 [320, 18]RequestClientData:ClientDataID=0, RequestID=0, DefineID=0, Period=3, Flags=0, origin=0, interval=0, limit=0
    /// </summary>
    RequestClientData,
    /// <summary>
    /// IN: 9.32781 [324, 4]RequestDataOnSimObject:RequestID=10001, DefineID=1, ObjectID=0, Period=4, Flags=1, origin=0, interval=0, limit=0
    /// </summary>
    RequestDataOnSimObject,
    /// <summary>
    /// IN: 30.43684 [328, 1933]RequestDataOnSimObjectType:RequestID=1, DefineID=1, dwRadiusMeters=0, type=0
    /// </summary>
    RequestDataOnSimObjectType,
    /// <summary>
    /// Not seen in logs
    /// IN: 9.32781 [324, 4]RequestNotificationGroup:GroupID=10001, dwReserved=, Flags=
    /// </summary>
    RequestNotificationGroup,
    /// <summary>
    /// Not seen in logs
    /// IN: 9.32781 [324, 4]RequestReservedKey:EventID=, szKeyChoice1=, szKeyChoice2=, szKeyChoice2=
    /// </summary>
    RequestReservedKey,
    /// <summary>
    /// IN: 87.83732 [330, 1914]SetClientData:ClientDataID=0, DefineID=0, Flags=0, dwReserved=0, cbUnitSize=256, pDataSet=1040453540
    /// </summary>
    SetClientData,
    /// <summary>
    /// IN: 165.45103 [333, 2408] SetDataOnSimObject:DefineID=34, ObjectID=0, Flags=0, ArrayCount=1, cbUnitSize=4, pDataSet=973342084
    /// </summary>
    SetDataOnSimObject,
    /// <summary>
    /// Not seen in logs
    /// IN: 165.45103 [333, 2408] SetInputGroupPriority:GroupID=, uPriority=
    /// </summary>
    SetInputGroupPriority,
    /// <summary>
    /// Not seen in logs
    /// IN: 165.45103 [333, 2408] SetInputGroupState:GroupID=, dwState=
    /// </summary>
    SetInputGroupState,
    /// <summary>
    /// Not seen in logs
    /// IN: 165.45103 [333, 2408] SetSystemEventState:EventID=, dwState=
    /// </summary>
    SetSystemEventState,
    /// <summary>
    /// Not seen in logs
    /// IN: 165.45103 [333, 2408] SubscribeToFlowEvent:
    /// </summary>
    SubscribeToFlowEvent,
    /// <summary>
    /// IN: 9.05804 [321, 2]SubscribeToSystemEvent:EventID=0, SystemEventName="6Hz"
    /// </summary>
    SubscribeToSystemEvent,
    /// <summary>
    /// IN: 157.63296 [333, 2235]TransmitClientEvent:ObjectID=0, EventID=10134, GroupID=1, Flags=16, dwData=122800000
    /// </summary>
    TransmitClientEvent,
    /// <summary>
    /// IN: 157.63296 [333, 2235]TransmitClientEvent_EX1:ObjectID=0, EventID=10134, GroupID=1, Flags=16, dwData0=122800000, dwData1=0, dwData2=0, dwData3=0, dwData4=0
    /// </summary>
    TransmitClientEvent_EX1,
    /// <summary>
    /// IN: 57.21751 [328, 2203]UnsubscribeFromSystemEvent:EventID=10107
    /// </summary>
    UnsubscribeFromSystemEvent,
    /// <summary>
    /// Not seen in logs
    /// IN: 165.45103 [333, 2408] UnsubscribeToFlowEvent:
    /// </summary>
    UnsubscribeToFlowEvent,

    // Section Flights

    /// <summary>
    /// Not seen in logs
    /// IN: 57.21751 [328, 2203]FlightLoad:szFileName=
    /// </summary>
    FlightLoad,
    /// <summary>
    /// Not seen in logs
    /// IN: 57.21751 [328, 2203]FlightPlanLoad:szFileName=
    /// </summary>
    FlightPlanLoad,
    /// <summary>
    /// Not seen in logs
    /// IN: 57.21751 [328, 2203]FlightSave:szFileName=, szTitle=, szDescription=
    /// </summary>
    FlightSave,

    // Section Facilities

    /// <summary>
    /// IN: 234.14932 [331, 3] AddToFacilityDefinition:DefineID=31001, FieldName="OPEN AIRPORT"
    /// </summary>
    AddToFacilityDefinition,
    /// <summary>
    /// Not seen in logs
    /// IN: 234.14932 [331, 3] AddFacilityDataDefinitionFilter:DefineID=, szFilterPath=, cbFilterDataSize=, pFilterData=
    /// </summary>
    AddFacilityDataDefinitionFilter,
    /// <summary>
    /// Not seen in logs
    /// IN: 234.14932 [331, 3] ClearAllFacilityDataDefinitionFilters:DefineID=
    /// </summary>
    ClearAllFacilityDataDefinitionFilters,
    /// <summary>
    /// IN: 233.94930 [331, 2]RequestAllFacilities:type=0, RequestID=31001
    /// </summary>
    RequestAllFacilities,
      /// <summary>
      /// IN: 233.94930 [331, 2]RequestFacilitiesList:type=0, RequestID=31001
      /// </summary>
    RequestFacilitiesList,
    /// <summary>
    /// IN: 233.94930 [331, 2]RequestFacilitesList_EX1:type=0, RequestID=31001
    /// </summary>
    RequestFacilitesList_EX1,
    /// <summary>
    /// Not seen in logs
    /// IN: 234.25271 [331, 491]RequestFacilityData:DefineID=31001, RequestID=31002, ICAO="PAKX", Region=""
    /// </summary>
    RequestFacilityData,
    /// <summary>
    /// IN: 483.75231 [331, 86808]RequestFacilityData_EX1:DefineID=31002, RequestID=117287, ICAO="ABA", Region="EH", Type=86
    /// </summary>
    RequestFacilityData_EX1,
    /// <summary>
    /// Not seen in logs
    /// IN: 234.25271 [331, 491]RequestJetwayData:szAirportIcao=, dwArrayCount=, pIndexes=
    /// </summary>
    RequestJetwayData,
    /// <summary>
    /// Not seen in logs
    /// IN: 104.45231 [331, 40]SubscribeToFacilities:type=, RequestID=
    /// </summary>
    SubscribeToFacilities,
    /// <summary>
    /// Not seen in logs
    /// IN: 104.45231 [331, 40]SubscribeToFacilities_EX1:type=, newElemInRangeRequestID=, oldElemOutRangeRequestID
    /// </summary>
    SubscribeToFacilities_EX1,
    /// <summary>
    /// Not seen in logs
    /// IN: 104.36021 [331, 37]UnsubscribeToFacilities:type=
    /// </summary>
    UnsubscribeToFacilities,
    /// <summary>
    /// Not seen in logs
    /// IN: 104.36021 [331, 37]UnsubscribeToFacilities_EX1:type=, bUnsubscribeNewInRange=, bUnsubscribeOldOutRange=
    /// </summary>
    UnsubscribeToFacilities_EX1,

    // Section InputEvents

    /// <summary>
    /// Not seen in logs
    /// IN: 87.86301 [330, 1915]EnumerateControllers:
    /// </summary>
    EnumerateControllers,
    /// <summary>
    /// IN: 87.86301 [330, 1915]EnumerateInputEvents:RequestID=30
    /// </summary>
    EnumerateInputEvents,
    /// <summary>
    /// Not seen in logs
    /// IN: 87.86301 [330, 1915]EnmerateInputEventParams:RequestID=
    /// </summary>
    EnmerateInputEventParams,
    /// <summary>
    /// Not seen in logs
    /// IN: 87.86301 [330, 1915]GetInputEvent:RequestID=, Hash=
    /// </summary>
    GetInputEvent,
    /// <summary>
    /// Not seen in logs
    /// IN: 87.86301 [330, 1915]GetInputEvent:GroupID=, pszInputDefinition=, DownEventID=, DownValue=, UpEventID=, SIMCONNECT_UNUSED=, UpValue=, bMaskable=
    /// </summary>
    MapInputEventToClientEvent_EX1,
    /// <summary>
    /// Not seen in logs
    /// IN: 87.86301 [330, 1915]GetInputEvent:GroupID=, pszInputDefinition=, DownEventID=, DownValue=, UpEventID=, SIMCONNECT_UNUSED=, UpValue=, bMaskable=
    /// </summary>
    MapInputEventToClientEvent,
    /// <summary>
    /// IN: 183.98788 [330, 4041]SetInputEvent:Hash=-2047808529, cbUnitSize=8, Value=-2013003572
    /// </summary>
    SetInputEvent,
    /// <summary>
    /// IN: 104.45231 [331, 40]SubscribeInputEvent:Hash=-274244859
    /// </summary>
    SubscribeInputEvent,
    /// <summary>
    /// IN: 104.36021 [331, 37]UnsubscribeInputEvent:Hash=0
    /// </summary>
    UnsubscribeInputEvent,

    // Section Debug

    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]GetLastSentPacketID: pdwSendID=
    /// </summary>
    GetLastSentPacketID,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]InsertString: pDest=, cbDest=, ppEnd=, pcbStringV=, pSource=
    /// </summary>
    InsertString,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]RequestResponseTimes: nCount=, fElapsedSeconds=
    /// </summary>
    RequestResponseTimes,
    /// <summary>
    /// Not seen in logs
    /// IN: S.SSSSS [N, S]RetrieveString:pData=, cbData=, pStringV=, ppszString=, pcbString=
    /// </summary>
    RetrieveString,

  }


  /// <summary>
  /// One Logged Line
  /// </summary>
  public class LogLine
  {
    // provide LineType Names here where the Enum is defined
    // - need to define them without the Type mark in order to work for the Tokenizer

    /// <summary>
    /// LogLine Cmd Name for SimConnect 
    /// </summary>
    public const string SimConnectCmd = "SimConnect"; // derived from enum ScSimConnect
    /// <summary>
    /// LogLine Cmd Name for Server 
    /// </summary>
    public const string ServerCmd = "Server";
    /// <summary>
    /// LogLine Cmd Name for Exe Launched 
    /// </summary>
    public const string Exe_LaunchedCmd = "Exe_Launched";
    /// <summary>
    /// LogLine Cmd Name for Event
    /// </summary>
    public const string EventCmd = "Event";
    /// <summary>
    /// LogLine Cmd Name for EventFrame
    /// </summary>
    public const string EventFrameCmd = "EventFrame";
    /// <summary>
    /// LogLine Cmd Name for Flight
    /// </summary>
    public const string FlightCmd = "Flight";
    /// <summary>
    /// LogLine Cmd Name for AircraftLoaded
    /// </summary>
    public const string AircraftLoadedCmd = "AircraftLoaded";
    /// <summary>
    /// TODO LogLine Cmd Name for Flow Event  *** PROSPECTIVE TO BE TESTED
    /// </summary>
    public const string Flow_EventCmd = "Flow_Event";
    /// <summary>
    /// LogLine Cmd Name for ObjectData
    /// </summary>
    public const string ObjectDataCmd = "ObjectData";
    /// <summary>
    /// LogLine Cmd Name for ObjectDataByType
    /// </summary>
    public const string ObjectDataByTypeCmd = "ObjectDataByType";
    /// <summary>
    /// LogLine Cmd Name for ClientData
    /// </summary>
    public const string ClientDataCmd = "ClientData";
    /// <summary>
    /// LogLine Cmd Name for ObjectAddRemove
    /// </summary>
    public const string ObjectAddRemoveCmd = "ObjectAddRemove";
    /// <summary>
    /// LogLine Cmd Name for Facilities Request
    /// </summary>
    public const string Facilities_RequestCmd = "Facilities_Request";
    /// <summary>
    /// LogLine Cmd Name for ICAORequest
    /// </summary>
    public const string ICAO_RequestCmd = "ICAO_Request";
    /// <summary>
    /// LogLine Cmd Name for Exception
    /// </summary>
    public const string ExceptionCmd = "Exception";
    /// <summary>
    /// LogLine Cmd Name for Disconnected
    /// </summary>
    public const string DisconnectedCmd = "Disconnected";




    // returns the Linetype for a Cmd string
    private static LineType LineTypeFromCmd( LogLineArgument cmdProp )
    {
      // sanity
      if (cmdProp == null) return LineType.None;
      if (cmdProp.Argument != ArgName.CmdS) throw new ArgumentException( "Must be of type Cmd" );

      // time consumed is the same for switch case and parse, using TryParse

      // try to handle as IN: cmd matches the Enum
      if (Enum.TryParse( cmdProp.ArgS, out LineType vLT )) {
        return vLT;
      }
      // try to handle as OUT: by prepending with an Sc mark 
      else if (Enum.TryParse( "Sc" + cmdProp.ArgS, out vLT )) {
        return vLT;
      }
      else {
        // catch missed/unknown ones
#if DEBUG
        // add to enum when landing here
        throw new ArgumentException( $"Undhandled line type: {cmdProp.ArgS}" );
#endif

#pragma warning disable CS0162 // Unreachable code detected
        return LineType.Other;
#pragma warning restore CS0162 // Unreachable code detected
      }
    }

    #region EXAMPLES

    /*  EXAMPLES

0.00000 SimConnect version 12.1.0.0

0.00169 Server: Scope=local, Protocol=IPv4, Address=127.0.0.1, Port=500, MaxClients=64
0.06913 Server: Scope=local, Protocol=IPv6, Address=::1, Port=501, MaxClients=64
0.14381 Server: Scope=local, Protocol=Pipe, Name=\\.\pipe\Custom\SimConnect, MaxClients=64
0.21367 Server: Scope=local, Protocol=IPv4, Address=127.0.0.1, Port=62073, MaxClients=64
0.28231 Server: Scope=local, Protocol=IPv6, Address=::1, Port=62074, MaxClients=64
0.34823 Server: Scope=local, Protocol=Pipe, Name=\\.\pipe\Microsoft Flight Simulator\SimConnect, MaxClients=64

0.35522 Exe Launched:  Path="C:\Program Files\FenixSim A320\deps\FenixBootstrapper.exe" Version="2.4.0.2070"

29.93329 [327] Disconnected! (5, C000014B)

> 8.87539 [320, 1]Open: Version=0x00000006  Name="BM98CH_WASM_24"
> 8.96530 [320, 2]SubscribeToSystemEvent:EventID=2, SystemEventName="6Hz"
> 8.96531 [320, 3]SubscribeToSystemEvent:EventID=0, SystemEventName="FlightLoaded"
> 8.96533 [320, 4]MapClientDataNameToID:szClientDataName="BM98CH_WASM_24.Command", ClientDataID=0
> 8.96534 [320, 5]CreateClientData:ClientDataID=0, dwSize=256, Flags=0
> 8.96534 [320, 6]AddToClientDataDefinition:DefineID=0, dwOffset=0, dwSizeOrType=256, fEpsilon=0.000000, DatumID=-1
> 8.96535 [320, 7]MapClientDataNameToID:szClientDataName="BM98CH_WASM_24.Acknowledge", ClientDataID=1
> 8.96537 [320, 8]CreateClientData:ClientDataID=1, dwSize=270, Flags=0
> 8.96537 [320, 9]AddToClientDataDefinition:DefineID=1, dwOffset=0, dwSizeOrType=270, fEpsilon=0.000000, DatumID=-1
> 8.96538 [320, 10]MapClientDataNameToID:szClientDataName="BM98CH_WASM_24.Result", ClientDataID=2
> 8.96539 [320, 11]CreateClientData:ClientDataID=2, dwSize=268, Flags=0
> 8.96540 [320, 12]AddToClientDataDefinition:DefineID=2, dwOffset=0, dwSizeOrType=268, fEpsilon=0.000000, DatumID=-1
> 8.96541 [320, 13]MapClientDataNameToID:szClientDataName="BM98CH_WASM_24.MResult", ClientDataID=3
> 8.96542 [320, 14]CreateClientData:ClientDataID=3, dwSize=268, Flags=0
> 8.96542 [320, 15]AddToClientDataDefinition:DefineID=3, dwOffset=0, dwSizeOrType=268, fEpsilon=0.000000, DatumID=-1
> 8.96543 [320, 16]MapClientDataNameToID:szClientDataName="BM98CH_WASM_24.LVars", ClientDataID=4
> 8.96544 [320, 17]CreateClientData:ClientDataID=4, dwSize=4000, Flags=0
> 8.96545 [320, 18]RequestClientData:ClientDataID=0, RequestID=0, DefineID=0, Period=3, Flags=0, origin=0, interval=0, limit=0
> 8.96546 [321, 1]Open: Version=0x00000006  Name="NAVIGRAPH_CHARTS_EFB_DATASTORE"
> 9.05804 [321, 2]SubscribeToSystemEvent:EventID=0, SystemEventName="6Hz"
> 9.23611 [324, 1]Open: Version=0x00000006  Name="SPAD-Bridge-Module"
> 9.32778 [324, 2]SubscribeToSystemEvent:EventID=0, SystemEventName="FlightLoaded"
> 9.32780 [324, 3]AddToDataDefinition:DefineID=1, DatumName="TITLE", UnitsName="", DatumType=10, fEpsilon=0.000000, DatumID=-1
> 9.32781 [324, 4]RequestDataOnSimObject:RequestID=10001, DefineID=1, ObjectID=0, Period=4, Flags=1, origin=0, interval=0, limit=0
> 9.32782 [324, 5]AddToDataDefinition:DefineID=2, DatumName="CAMERA STATE", UnitsName="ENUM", DatumType=1, fEpsilon=0.000000, DatumID=-1
> 9.32783 [324, 6]RequestDataOnSimObject:RequestID=10002, DefineID=2, ObjectID=0, Period=3, Flags=1, origin=0, interval=0, limit=0
> 9.32784 [324, 7]SubscribeToSystemEvent:EventID=504, SystemEventName="6Hz"
> 9.32785 [324, 8]SubscribeToSystemEvent:EventID=506, SystemEventName="SimStart"
> 9.32787 [324, 9]SubscribeToSystemEvent:EventID=507, SystemEventName="SimStop"
> 9.32788 [324, 10]SubscribeToSystemEvent:EventID=505, SystemEventName="View"
< 9.32789 [324] Event: 505
> 9.32790 [324, 11]MapClientDataNameToID:szClientDataName="SPAD_SC_DYN_VARDATA_ID", ClientDataID=1396987905
> 9.32791 [324, 12]MapClientDataNameToID:szClientDataName="SPAD_SC_DYN_VARDATA_DATA", ClientDataID=1396987906
> 9.32796 [324, 13]MapClientDataNameToID:szClientDataName="SPAD_SC_DYN_VARDUMP_ID", ClientDataID=1396987907
> 9.32797 [324, 14]MapClientDataNameToID:szClientDataName="SPAD_SC_DYN_VARDUMP_DATA", ClientDataID=1396987908

> 9.32814 [324, 32]RequestClientData:ClientDataID=1396987913, RequestID=10008, DefineID=1396987914, Period=3, Flags=0, origin=0, interval=0, limit=0
> 9.32815 [325, 1]Open: Version=0x00000006  Name="FCREmbedded"
> 9.42683 [326, 0]Open: Version=0x00000004  Name="FenixBootstrapper"
< 9.75090 [320] Event: 2
< 9.75092 [321] Event: 0

> 9.75196 [326, 1]MapClientDataNameToID:szClientDataName="Fenix:Ready", ClientDataID=1
> 9.75200 [326, 2]AddToClientDataDefinition:DefineID=1, dwOffset=-1, dwSizeOrType=-3, fEpsilon=0.000000, DatumID=-1
> 9.75201 [326, 3]RequestClientData:ClientDataID=1, RequestID=1000001, DefineID=1, Period=1, Flags=0, origin=0, interval=0, limit=0
< 9.75202 [326] >>>>>  EXCEPTION=25, SendID=0, Index=-1  <<<<<
> 9.75203 [326, 4]RequestClientData:ClientDataID=1, RequestID=1, DefineID=1, Period=3, Flags=0, origin=0, interval=0, limit=0
> 9.75204 [326, 5]MapClientDataNameToID:szClientDataName="Fenix:Shutdown", ClientDataID=2
> 9.75205 [326, 6]RequestClientData:ClientDataID=2, RequestID=1000002, DefineID=1, Period=1, Flags=0, origin=0, interval=0, limit=0
< 9.75206 [326] >>>>>  EXCEPTION=25, SendID=0, Index=-1  <<<<<
> 9.75207 [326, 7]RequestClientData:ClientDataID=2, RequestID=2, DefineID=1, Period=3, Flags=0, origin=0, interval=0, limit=0
> 9.75208 [326, 8]AddToDataDefinition:DefineID=1, DatumName="Title", UnitsName="", DatumType=9, fEpsilon=0.000000, DatumID=-1

< 224.73733 [325] EventFrame: 1  173.481598
> 224.74271 [325, 31563]RequestDataOnSimObject:RequestID=110, DefineID=114, ObjectID=0, Period=1, Flags=0, origin=0, interval=0, limit=0
< 224.74275 [325] ObjectData: RequestID=110  DefineID=114
> 224.74275 [325, 31564]RequestDataOnSimObject:RequestID=110, DefineID=114, ObjectID=0, Period=1, Flags=0, origin=0, interval=0, limit=0
< 224.74276 [325] ObjectData: RequestID=110  DefineID=114
< 224.74350 [325] EventFrame: 4  166.112946
< 224.74372 [325] EventFrame: 1  166.112946

> 9.75315 [325, 107]MapClientEventToSimEvent:EventID=47, EventName="MAGNETO2_BOTH"
> 9.75316 [325, 108]AddClientEventToNotificationGroup:GroupID=11, EventID=47, bMaskable=0
> 9.75223 [325, 6]SubscribeToSystemEvent:EventID=1, SystemEventName="Frame"

     */

    #endregion

    /// <summary>
    /// The raw input line
    /// </summary>
    protected readonly string _rawLine = "";

    /// <summary>
    /// detected arguments
    /// </summary>
    protected readonly List<LogLineArgument> _arguments = new List<LogLineArgument>( );

    /// <summary>
    /// The detected LogLine Type
    /// </summary>
    public LineType LogLineType { get; protected set; } = LineType.None;
    /// <summary>
    /// The Arguments of this line
    /// </summary>
    public IEnumerable<LogLineArgument> Arguments => _arguments;

    /// <summary>
    /// Timestamp of this LogLine
    /// </summary>
    public double Timestamp { get; protected set; } = -1;

    /// <summary>
    /// Returns the ClienNumber of this line
    ///  returns -1 if no ClientNumber was referenced
    /// </summary>
    public long ClientNumber { get; protected set; } = -1;

    /// <summary>
    /// Returns the ClientSendID or -1 if there is none
    /// </summary>
    public long ClientSendID { get; protected set; } = -1;

    /// <summary>
    /// The Input Line
    /// </summary>
    public string LoggedLine => _rawLine;


    // split prop pairs prop=value and removes double quotes
    private bool SplitPropValue( string token, out string prop, out string value )
    {
      string[] e = token.Split( new char[] { '=' } );

      if (e.Length == 2) {
        prop = e[0];
        value = e[1].Replace( "\"", "" ); // remove the double quotes

        return true;
      }
      prop = "";
      value = "";
      return false;
    }

    /// <summary>
    /// cTor: Create a logline from a string
    /// </summary>
    /// <param name="rawLine">The Logfile line</param>
    public LogLine( string rawLine )
    {
      _rawLine = rawLine;

      var tokens = new Tokenizer( rawLine );
      string token = tokens.NextToken( );
      LogLineArgument prop = null;

      // handle 1st token - always the timestamp as number
      if (SplitPropValue( token, out string propS, out string valueS )) {
        prop = LogLineArgument.GetArg( propS, valueS );
        _arguments.Add( prop );

        if (prop.Argument != ArgName.TimestampR) {
          ; // Debug stop - shall never land here
        }
      }

      // second should be Cmd=
      token = tokens.NextToken( );
      if (SplitPropValue( token, out propS, out valueS )) {
        prop = LogLineArgument.GetArg( propS, valueS );
        _arguments.Add( prop );

        if (prop.Argument != ArgName.CmdS) {
          ; // Debug stop - shall never land here
        }
      }

      LogLineType = LineTypeFromCmd( prop );

      if (LogLineType == LineType.Other) {
        ; // Debug stop  - undecoded line
      }

      if (LogLineType == LineType.None) {
#if DEBUG
        // Debug stop - shall never land here
        throw new ArgumentException( "Decoding of the input line was not successfull" );
#endif

#pragma warning disable CS0162 // Unreachable code detected
        return;
#pragma warning restore CS0162 // Unreachable code detected
      }
      // collect arguments
      else {
        token = tokens.NextToken( );
        while (!string.IsNullOrEmpty( token )) {
          if (SplitPropValue( token, out propS, out valueS )) {
            _arguments.Add( LogLineArgument.GetArg( propS, valueS ) );
          }
          // next 
          token = tokens.NextToken( );
        }
      }

      // precalc some often used in queries

      Timestamp = -1; // has no timestamp
      var arg = _arguments.FirstOrDefault( p => p.Argument == ArgName.TimestampR );
      if (arg != null) { Timestamp = arg.ArgR; }

      ClientNumber = -1; // has no client number
      arg = _arguments.FirstOrDefault( p => p.Argument == ArgName.ClientNumber );
      if (arg != null) { ClientNumber = arg.ArgI; }

      ClientSendID = -1; // has no client sendID
      arg = _arguments.FirstOrDefault( p => p.Argument == ArgName.ClientSendID );
      if (arg != null) { ClientSendID = arg.ArgI; }
    }

    /// <inheritdoc/>
    public override string ToString( ) => $"{LogLineType}:{_rawLine.Substring( 0, 10 )}.."; // should be longer than 10 chars for all lines...

    /// <summary>
    /// Json of this Line
    /// </summary>
    public string AsJson {
      get {
        /*
            { lineType: "", arguments:[ { arg: "", value: "" || digits }, .. { arg: "", value: "" || digits } ] }
         */
        string ps = "";
        foreach (var prop in _arguments) {
          ps += prop.AsJson + ", ";
        }
        ps = ps.TrimEnd( new char[] { ' ', ',' } ); // remove ending comma

        return $"{{ \"lineType\": \"{LogLineType}\", \"arguments\":[ {ps} ] }}";
      }
    }
  }
}
