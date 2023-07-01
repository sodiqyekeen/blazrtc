

namespace BlazRTC.Services;

public interface IMediaDeviceService
{
    Task<IEnumerable<MediaDeviceInfo>> GetMediaDevicesAsync();
    Task<bool> StartCameraAsync(MediaOptions options);
    Task StopCameraAsync();
    //getDisplayMedia()
    //getSupportedConstraints()
    //getUserMedia()
    //selectAudioOutput()
    event EventHandler<MediaDeviceChangeEventArgs> OnDeviceChange;

    public event Action? OnVideoStreamAvailable;
}
