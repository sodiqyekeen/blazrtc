using System.Text.Json.Serialization;

namespace BlazRTC;

public record MediaStream(
    string Id,
    MediaStreamTrack[] Tracks
    );


public record MediaStreamTrack(
    string Id,
     string Label,
     string Kind
     );

public record JsMediaStream
{
    public string Id { get; init; } = null!;
    public JsMediaStreamTrack[] Tracks { get; init; } = [];
}

public record JsMediaStreamTrack
{
    public string Id { get; init; } = null!;
    public string Label { get; init; } = string.Empty;

    [JsonConverter(typeof(JsonStringEnumConverter<TrackKind>))]
    public TrackKind Kind { get; init; }
}