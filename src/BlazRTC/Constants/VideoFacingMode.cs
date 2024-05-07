namespace BlazRTC;

/// <summary>
/// Represents the video facing mode of a camera. Describe the directions that the camera can face, as seen from the user's perspective.
/// </summary>
public enum VideoFacingMode
{
    /// <summary>
    /// The source is facing toward the user (a self-view camera).
    /// </summary>
    User,

    /// <summary>
    /// The source is facing away from the user (viewing the environment).
    /// </summary>
    Environment,

    /// <summary>
    /// The source is facing to the left of the user.
    /// </summary>
    Left,

    /// <summary>
    /// The source is facing to the right of the user.
    /// </summary>
    /// Right
}
