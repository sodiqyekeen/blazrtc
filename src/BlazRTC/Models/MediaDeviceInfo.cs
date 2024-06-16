using System.Text.Json.Serialization;

namespace BlazRTC.Models;

// public record MediaDeviceInfo(
//     string DeviceId, 
// string Label, 

// MediaDeviceKind Kind, 
// string GroupId);


public record MediaDeviceInfo
{
    public string DeviceId { get; init; } = null!;
    public string Label { get; init; } = null!;
    [JsonConverter(typeof(JsonStringEnumConverter<MediaDeviceKind>))]
    public MediaDeviceKind Kind { get; init; }
    public string GroupId { get; init; } = null!;
}