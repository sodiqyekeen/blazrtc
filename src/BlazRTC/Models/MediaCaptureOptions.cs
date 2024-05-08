namespace BlazRTC.Models;

public class MediaOptions
{
    private string _filter = "filter-none";
    public MediaOptions()
    {
        FrameRate = 24;
        AspectRatio = 1.33333;
        Muted = "muted";
    }
    public string? PreviewStreamIn { get; set; }
    public double FrameRate { get; set; }
    public double AspectRatio { get; set; }
    public string? FacingMode { get; set; }
    public string? ResizeMode { get; set; }
    public string Filter
    {
        get => _filter;
        set
        {
            _filter = value;
            NotifyOptionsChanged();
        }
    }
    public string Muted { get; set; }

    public event Action? OnOptionsChanged;
    private void NotifyOptionsChanged()
    {
        OnOptionsChanged?.Invoke();
    }

}

public class MediaCaptureOptions
{
    public bool AudioEnabled { get; private set; }
    public bool VideoEnabled { get; private set; }
    public double VideoWidth { get; private set; }
    public double VideoHeight { get; private set; }
    public double FrameRate { get; private set; }
    public double AspectRatio { get; private set; }
    public string? FacingMode { get; private set; }
    public string? ResizeMode { get; private set; }
    public string? AudioDeviceId { get; private set; }
    public string? VideoDeviceId { get; private set; }
    public string? PreviewStreamIn { get; private set; }

    private MediaCaptureOptions() { }


    /// <summary>
    /// Represents the options for capturing media.
    /// </summary>
    /// <returns>A new instance of <see cref="MediaCaptureOptions"/>. </returns>
    public static MediaCaptureOptions Create() =>
        new();

    /// <summary>
    /// Sets the audio capture enabled state and returns the updated <see cref="MediaCaptureOptions"/> instance.
    /// </summary>
    /// <param name="enabled">A value indicating whether audio capture should be enabled.</param>
    /// <returns>The updated <see cref="MediaCaptureOptions"/> instance.</returns>
    public MediaCaptureOptions WithAudioEnabled(bool enabled = true)
    {
        AudioEnabled = enabled;
        return this;
    }

    /// <summary>
    /// Sets the video capture enabled state and returns the updated <see cref="MediaCaptureOptions"/> instance.
    /// </summary>
    /// <param name="enabled">A value indicating whether video capture should be enabled.</param>
    /// <returns>The updated <see cref="MediaCaptureOptions"/> instance.</returns>
    public MediaCaptureOptions WithVideoEnabled(bool enabled = true)
    {
        VideoEnabled = enabled;
        return this;
    }

    /// <summary>
    /// Sets the video resolution for capturing media.
    /// </summary>
    /// <param name="resolution">The desired video resolution.</param>
    /// <param name="width">The width of the custom resolution (optional).</param>
    /// <param name="height">The height of the custom resolution (optional).</param>
    /// <returns>The updated <see cref="MediaCaptureOptions"/> instance.</returns>
    public MediaCaptureOptions WithVideoResolution(VideoResolution resolution, double width = 0, double height = 0)
    {
        if (resolution != VideoResolution.Custom)
        {
            (VideoWidth, VideoHeight) = GetResolution(resolution);
            return this;
        }

        if (width <= 0 || height <= 0)
            throw new ArgumentException("Custom resolution requires width and height to be specified.");

        VideoWidth = width;
        VideoHeight = height;

        return this;
    }

    /// <summary>
    /// Sets the video frame rate for capturing media.
    /// </summary>
    /// <param name="frameRate">The desired frame rate.</param>
    /// <returns>The updated <see cref="MediaCaptureOptions"/> instance.</returns>
    public MediaCaptureOptions WithFrameRate(double frameRate)
    {
        const double minFrameRate = 1;
        const double maxFrameRate = 60;
        FrameRate = Math.Clamp(frameRate, minFrameRate, maxFrameRate);
        return this;
    }


    /// <summary>
    /// Sets the video aspect ratio for capturing media.
    /// </summary>
    /// <param name="frameRate">The desired aspect ratio.</param>
    /// <returns>The updated <see cref="MediaCaptureOptions"/> instance.</returns>
    public MediaCaptureOptions WithAspectRatio(double aspectRatio)
    {
        AspectRatio = aspectRatio;
        return this;
    }

    /// <summary>
    /// Sets the video facing mode for capturing media.
    /// </summary>
    /// <param name="frameRate">The desired facing mode.</param>
    /// <returns>The updated <see cref="MediaCaptureOptions"/> instance.</returns>
    public MediaCaptureOptions WithFacingMode(VideoFacingMode facingMode)
    {
        FacingMode = facingMode.ToString().ToLower();
        return this;
    }

    /// <summary>
    /// Sets the video resize mode for capturing media.
    /// </summary>
    /// <param name="frameRate">The desired resize mode.</param>
    /// <returns>The updated <see cref="MediaCaptureOptions"/> instance.</returns>
    public MediaCaptureOptions WithResizeMode(VideoResizeMode resizeMode)
    {
        ResizeMode = resizeMode switch
        {
            VideoResizeMode.None => "none",
            VideoResizeMode.CropAndScale => "crop-and-scale",
            _ => throw new ArgumentOutOfRangeException(nameof(resizeMode), resizeMode, null)
        };
        return this;
    }

    /// <summary>
    /// Sets the preview stream for media capture.
    /// </summary>
    /// <param name="previewStreamIn"></param>
    /// <returns>The updated <see cref="MediaCaptureOptions"/> instance.</returns>
    public MediaCaptureOptions WithPreviewStream(string previewStreamIn)
    {
        PreviewStreamIn = previewStreamIn;
        return this;
    }

    private static (double width, double height) GetResolution(VideoResolution resolution) => resolution switch
    {
        VideoResolution.Low => (320, 240),
        VideoResolution.Standard => (640, 480),
        VideoResolution.HD => (1280, 720),
        VideoResolution.FullHD => (1920, 1080),
        VideoResolution.UltraHD => (3840, 2160),
        _ => throw new ArgumentOutOfRangeException(nameof(resolution), resolution, null)
    };
}