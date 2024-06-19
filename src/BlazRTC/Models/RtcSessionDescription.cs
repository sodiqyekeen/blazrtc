using System.Text.Json.Serialization;

namespace BlazRTC;

/// <summary>
/// Represents a description of one end of a connection or potential connection and how it's configured.
/// </summary>
public record RtcSessionDescription
{
    /// <summary>
    /// Gets or sets the type of the session description.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter<RtcSdpType>))]
    public RtcSdpType Type { get; init; }

    /// <summary>
    /// Gets or sets the SDP (Session Description Protocol) content of the session description.
    /// </summary>
    public string Sdp { get; init; } = null!;
}