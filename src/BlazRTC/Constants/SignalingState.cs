namespace BlazRTC;

/// <summary>
/// Represents the state of the signaling process on the local end of the connection while connecting or reconnecting to another peer.
/// </summary>
public enum SignalingState
{
    /// <summary>
    /// The connection is new.
    /// </summary>
    Stable,

    /// <summary>
    /// The connection has a local offer.
    /// </summary>
    HaveLocalOffer,

    /// <summary>
    /// The connection has a remote offer.
    /// </summary>
    HaveRemoteOffer,

    /// <summary>
    /// The connection has a local pranswer.
    /// </summary>
    HaveLocalPranswer,

    /// <summary>
    /// The connection has a remote pranswer.
    /// </summary>
    HaveRemotePranswer,

    /// <summary>
    /// The connection is closed.
    /// </summary>
    Closed
}
