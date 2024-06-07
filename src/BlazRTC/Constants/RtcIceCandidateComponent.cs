namespace BlazRTC;

/// <summary>
/// Represents the component of an ICE candidate.
/// </summary>
public enum RtcIceCandidateComponent
{
    /// <summary>
    /// The RTP component of an ICE candidate.
    /// </summary>
    Rtp,

    /// <summary>
    /// The RTCP component of an ICE candidate.
    /// </summary>
    Rtcp
}