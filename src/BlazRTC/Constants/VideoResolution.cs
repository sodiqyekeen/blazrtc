namespace BlazRTC;

/// <summary>
/// Represents the available video resolutions.
/// </summary>
public enum VideoResolution
{
    /// <summary>
    /// Low resolution: 320x240.
    /// </summary>
    Low = 0,

    /// <summary>
    /// Standard resolution: 640x480.
    /// </summary>
    Standard = 1,

    /// <summary>
    /// High definition resolution: 1280x720.
    /// </summary>
    HD = 2,

    /// <summary>
    /// Full HD resolution: 1920x1080.
    /// </summary>
    FullHD = 3,

    /// <summary>
    /// Ultra HD resolution: 3840x2160.
    /// </summary>
    UltraHD = 4,

    /// <summary>
    /// Custom resolution.
    /// </summary>
    Custom = 5
}
