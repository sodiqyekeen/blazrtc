namespace BlazRTC;

public class TrackEventArgs : EventArgs
{
    public string ConnectionId { get;}
    public TrackEventArgs(string connectionId)
    {
        ConnectionId = connectionId;
    }
}
