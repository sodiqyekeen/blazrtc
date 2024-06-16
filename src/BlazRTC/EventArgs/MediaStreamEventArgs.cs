namespace BlazRTC;

public class MediaStreamEventArgs(IMediaStream stream) : EventArgs
{
    public IMediaStream Stream { get; } = stream;
}
