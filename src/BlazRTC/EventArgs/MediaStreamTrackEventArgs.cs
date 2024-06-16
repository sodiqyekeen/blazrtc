namespace BlazRTC;

public class MediaStreamTrackEventArgs(IMediaStreamTrack track) : EventArgs
{
    public IMediaStreamTrack Track { get; } = track;
}
