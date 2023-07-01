namespace BlazRTC.Services;

internal interface IBlazRTCInterop
{
    Task<List<MediaDeviceInfo>> GetConnectedDevicesAsync();
}
