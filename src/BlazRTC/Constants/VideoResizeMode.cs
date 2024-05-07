namespace BlazRTC;

/// <summary>
/// Represents the resize mode of a video stream. Describe the means by which the resolution can be derived by the User Agent.
/// </summary>
public enum VideoResizeMode
{
    /// <summary>
    /// This resolution and frame rate is offered by the camera, its driver, or the OS.
    /// </summary>
    None = 0,

    /// <summary>
    /// This resolution is downscaled and/or cropped from a higher camera resolution by the User Agent, or its frame rate is decimated by the User Agent. 
    /// </summary>
    CropAndScale = 1,

}
