namespace BlazRTC.Services;

internal interface IBlazRTCInterop
{
    Task<List<MediaDevice>> GetMediaDevicesAsync();
}
