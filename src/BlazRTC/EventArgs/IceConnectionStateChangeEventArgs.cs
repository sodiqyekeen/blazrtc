namespace BlazRTC;

public class IceConnectionStateChangeEventArgs(object iceConnectionState) : EventArgs
{
    public IceConnectionState ConnectionState { get; } = GetState(iceConnectionState);

    private static IceConnectionState GetState(object iceConnectionState) => (iceConnectionState as string) switch
    {
        "new" => IceConnectionState.New,
        "checking" => IceConnectionState.Checking,
        "connected" => IceConnectionState.Connected,
        "completed" => IceConnectionState.Completed,
        "disconnected" => IceConnectionState.Disconnected,
        "failed" => IceConnectionState.Failed,
        "closed" => IceConnectionState.Closed,
        _ => throw new ArgumentException("Invalid state", nameof(iceConnectionState)),
    };



}
