namespace BlazRTC.Models;

public record MediaStreamTrack(
    string Id,
    DeviceKind Kind,
    string Label,
    string DeviceId,
    bool Enabled);
