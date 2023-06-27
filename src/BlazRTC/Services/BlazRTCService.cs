using BlazRTC.Interops;

namespace BlazRTC.Services;

internal class BlazRTCService : IBlazRTCService
{
    private readonly IBlazRTCInterop _blazRTCInterop;
    public BlazRTCService(IBlazRTCInterop blazRTCInterop)
    {
        _blazRTCInterop = blazRTCInterop;
    }
    public List<MediaDevice> MediaDevices { get; } = new();


    public async Task<List<MediaDevice>> GetMediaDevicesAsync()
    {
        return await _blazRTCInterop.GetMediaDevicesAsync();
    }


}
