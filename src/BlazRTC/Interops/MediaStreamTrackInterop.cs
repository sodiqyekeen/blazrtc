namespace BlazRTC;

public class MediaStreamTrackInterop(IJSRuntime jSRuntime, JsMediaStreamTrack source) : IMediaStreamTrack
{
    public string Id { get; } = source.Id;
    public string Label { get; } = source.Label;
    public TrackKind Kind { get; } = source.Kind;
}
