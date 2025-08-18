using System;

namespace SCLogLib
{
  /// <summary>
  /// Provides SimConnect Exception strings from Exception ID
  /// </summary>
  public class ScExceptions
  {
    // copy from SC 2024
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public enum SIMCONNECT_EXCEPTION
    {
      NONE,
      ERROR,
      SIZE_MISMATCH,
      UNRECOGNIZED_ID,
      UNOPENED,
      VERSION_MISMATCH,
      TOO_MANY_GROUPS,
      NAME_UNRECOGNIZED,
      TOO_MANY_EVENT_NAMES,
      EVENT_ID_DUPLICATE,
      TOO_MANY_MAPS,
      TOO_MANY_OBJECTS,
      TOO_MANY_REQUESTS,
      WEATHER_INVALID_PORT,
      WEATHER_INVALID_METAR,
      WEATHER_UNABLE_TO_GET_OBSERVATION,
      WEATHER_UNABLE_TO_CREATE_STATION,
      WEATHER_UNABLE_TO_REMOVE_STATION,
      INVALID_DATA_TYPE,
      INVALID_DATA_SIZE,
      DATA_ERROR,
      INVALID_ARRAY,
      CREATE_OBJECT_FAILED,
      LOAD_FLIGHTPLAN_FAILED,
      OPERATION_INVALID_FOR_OBJECT_TYPE,
      ILLEGAL_OPERATION,
      ALREADY_SUBSCRIBED,
      INVALID_ENUM,
      DEFINITION_ERROR,
      DUPLICATE_ID,
      DATUM_ID,
      OUT_OF_BOUNDS,
      ALREADY_CREATED,
      OBJECT_OUTSIDE_REALITY_BUBBLE,
      OBJECT_CONTAINER,
      OBJECT_AI,
      OBJECT_ATC,
      OBJECT_SCHEDULE,
      JETWAY_DATA,
      ACTION_NOT_FOUND,
      NOT_AN_ACTION,
      INCORRECT_ACTION_PARAMS,
      GET_INPUT_EVENT_FAILED,
      SET_INPUT_EVENT_FAILED,
      SIMCONNECT_EXCEPTION_INTERNAL, // added in 2024
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

    /// <summary>
    /// Return the Exception string if one matched or Unknown Exception 
    /// </summary>
    public static string GetExceptionS( long exID )
    {
      string exS = $"Unknown Exception with ID={exID}";
      if (exID == 0) return exS; // 0 is considered as missing ...

      if (Enum.IsDefined( typeof( ScExceptions.SIMCONNECT_EXCEPTION ), (int)exID )) {
        exS = ((ScExceptions.SIMCONNECT_EXCEPTION)exID).ToString( );
      }
      return exS;
    }


  }
}
