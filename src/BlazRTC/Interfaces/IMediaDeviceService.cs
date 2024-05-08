

namespace BlazRTC.Services;

public interface IMediaDeviceService
{
    Task<IEnumerable<MediaDeviceInfo>> GetMediaDevicesAsync();
    Task StartCaptureAsync(MediaCaptureOptions options);
    Task<bool> StartCameraAsync(MediaCaptureOptions options);
    Task StopCameraAsync();
    //getDisplayMedia()
    //getSupportedConstraints()
    //getUserMedia()
    //selectAudioOutput()
    event EventHandler<MediaDeviceChangeEventArgs> OnDeviceChange;

    public event Action? OnVideoStreamAvailable;
}
