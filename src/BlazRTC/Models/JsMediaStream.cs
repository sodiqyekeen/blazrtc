namespace BlazRTC;

public record JsMediaStream
{
    public string Id { get; init; } = null!;
    public JsMediaStreamTrack[] Tracks { get; init; } = [];
}

