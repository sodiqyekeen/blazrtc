using System.Text.Json.Serialization;

namespace BlazRTC.Models;

public record JsMediaStreamTrack
{
    public string Id { get; init; } = null!;
    public string Label { get; init; } = string.Empty;

    [JsonConverter(typeof(JsonStringEnumConverter<TrackKind>))]
    public TrackKind Kind { get; init; }
}