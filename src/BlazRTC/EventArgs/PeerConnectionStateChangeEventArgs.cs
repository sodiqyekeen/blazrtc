namespace BlazRTC;


/// <summary>
/// EventArgs for tracking changes in the state of a peer connection.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="PeerConnectionStateChangeEventArgs"/> class with the specified state.
/// </remarks>
/// <param name="newState">The new state of the peer connection.</param>
public class PeerConnectionStateChangeEventArgs(string newState) : EventArgs
{
    /// <summary>
    /// The current state of the peer connection.
    /// </summary>
    public RtcConnectionState ConnectionState { get; } = GetState(newState);

    private static RtcConnectionState GetState(string newState) => newState switch
    {
        "new" => RtcConnectionState.New,
        "checking" or "connecting" => RtcConnectionState.Connecting,
        "connected" => RtcConnectionState.Connected,
        "disconnected" => RtcConnectionState.Disconnected,
        "failed" => RtcConnectionState.Failed,
        "closed" => RtcConnectionState.Closed,
        _ => throw new ArgumentException("Invalid state", nameof(newState)),
    };
}
