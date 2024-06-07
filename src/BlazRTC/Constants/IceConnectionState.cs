namespace BlazRTC;

/// <summary>
/// Represents the state of an ICE (Interactive Connectivity Establishment) connection.
/// </summary>
public enum IceConnectionState
{
    /// <summary>
    /// The connection is new.
    /// </summary>
    New,

    /// <summary>
    /// The connection is checking.
    /// </summary>
    Checking,

    /// <summary>
    /// The connection is connected.
    /// </summary>
    Connected,

    /// <summary>
    /// The connection is completed.
    /// </summary>
    Completed,

    /// <summary>
    /// The connection has failed.
    /// </summary>
    Failed,

    /// <summary>
    /// The connection is disconnected.
    /// </summary>
    Disconnected,

    /// <summary>
    /// The connection is closed.
    /// </summary>
    Closed
}
