using BlazRTC.Models;

namespace BlazRTC;


/// <summary>
/// EventArgs for tracking changes in the state of a peer connection.
/// </summary>
public class ConnectionStateEventArgs : EventArgs
{
    /// <summary>
    /// The current state of the peer connection.
    /// </summary>
    public PeerConncectionState ConnectionState { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ConnectionStateEventArgs"/> class with the specified state.
    /// </summary>
    /// <param name="newState">The new state of the peer connection.</param>

    public ConnectionStateEventArgs(string newState)
    {
        ConnectionState = GetState(newState);
    }

    private static PeerConncectionState GetState(string newState) => newState switch
    {
        "new" => PeerConncectionState.New,
        "checking" or "connecting" => PeerConncectionState.Connecting,
        "connected" => PeerConncectionState.Connected,
        "disconnected" => PeerConncectionState.Disconnected,
        "failed" => PeerConncectionState.Failed,
        "closed" => PeerConncectionState.Closed,
        _ => throw new ArgumentException("Invalid state", nameof(newState)),
    };
}
