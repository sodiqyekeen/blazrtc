using BlazRTC.Interops;

namespace BlazRTC.Services;

internal class BlazRTCService : IBlazRTCService
{
    private readonly IBlazRTCInterop _blazRTCInterop;
    public BlazRTCService(IBlazRTCInterop blazRTCInterop)
    {
        _blazRTCInterop = blazRTCInterop;
    }
    public List<MediaDeviceInfo> MediaDevices { get; } = new();



}
