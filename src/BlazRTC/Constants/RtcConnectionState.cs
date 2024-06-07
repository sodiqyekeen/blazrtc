namespace BlazRTC;

/// <summary>
/// Represents the state of an RTC connection.
/// </summary>
public enum RtcConnectionState
{
    /// <summary>
    /// The connection is new.
    /// </summary>
    New,

    /// <summary>
    /// The connection is connecting.
    /// </summary>
    Connecting,

    /// <summary>
    /// The connection is connected.
    /// </summary>
    Connected,

    /// <summary>
    /// The connection is disconnected.
    /// </summary>
    Disconnected,

    /// <summary>
    /// The connection has failed.
    /// </summary>
    Failed,

    /// <summary>
    /// The connection is closed.
    /// </summary>
    Closed
}
