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

    //dictionary MediaTrackConstraintSet
    //{
    //    ConstrainULong width;
    //    ConstrainULong height;
    //    ConstrainDouble aspectRatio;
    //    ConstrainDouble frameRate;
    //    ConstrainDOMString facingMode;
    //    ConstrainDOMString resizeMode;
    //    ConstrainULong sampleRate;
    //    ConstrainULong sampleSize;
    //    ConstrainBoolean echoCancellation;
    //    ConstrainBoolean autoGainControl;
    //    ConstrainBoolean noiseSuppression;
    //    ConstrainDouble latency;
    //    ConstrainULong channelCount;
    //    ConstrainDOMString deviceId;
    //    ConstrainDOMString groupId;
    //};

    public event Action? OnOptionsChanged;
    private void NotifyOptionsChanged()
    {
        OnOptionsChanged?.Invoke();
    }

}

public class AudioOptions
{
    public bool EchoCancellation { get; set; }
    public bool AutoGainControl { get; set; }
    public bool NoiseSuppression { get; set; }
    public double Latency { get; set; }
    public ulong ChannelCount { get; set; }
}
