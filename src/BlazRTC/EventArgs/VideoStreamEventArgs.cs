namespace BlazRTC;

public class VideoStreamEventArgs(string streamId) : EventArgs
{
    public string StreamId { get; } = streamId;
}
