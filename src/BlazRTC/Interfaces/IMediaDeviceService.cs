

namespace BlazRTC.Services;

public interface IMediaDeviceService
{
    /// <summary>
    /// Retrieves a collection of media devices asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains a collection of <see cref="MediaDeviceInfo"/> objects representing the connected media devices.</returns>
    Task<IEnumerable<MediaDeviceInfo>> GetMediaDevicesAsync();

    /// <summary>
    /// Starts capturing media using the specified options asynchronously.
    /// </summary>
    /// <param name="options">The options for media capture.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task StartMediaCaptureAsync(MediaCaptureOptions options);

    /// <summary>
    /// Toggles the video track on or off asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ToggleVideoTrackAsync();

    /// <summary>
    /// Toggles the audio track on or off asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task ToggleAudioTrackAsync();

    /// <summary>
    /// Stops the camera capture.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task StopMediaCaptureAsync();

    /// <summary>
    /// Occurs when a media device change is detected.
    /// </summary>
    event EventHandler<MediaDeviceChangeEventArgs> OnDeviceChange;

    /// <summary>
    /// Occurs when a video stream is available.
    /// </summary>
    event Action<string>? OnVideoStreamAvailable;
}
