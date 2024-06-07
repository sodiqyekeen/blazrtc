namespace BlazRTC;

/// <summary>
/// Represents the state of ICE gathering.
/// </summary>
public enum IceGatheringState
{
    /// <summary>
    /// The ICE gathering state is new.
    /// </summary>
    New,

    /// <summary>
    /// The ICE gathering state is gathering.
    /// </summary>
    Gathering,

    /// <summary>
    /// The ICE gathering state is complete.
    /// </summary>
    Complete
}
