namespace BlazRTC;

/// <summary>
/// Represents a description of one end of a connection or potential connection and how it's configured.
/// </summary>
public class RtcSessionDescription
{
    /// <summary>
    /// Gets or sets the type of the session description.
    /// </summary>
    public RtcSdpType Type { get; set; }

    /// <summary>
    /// Gets or sets the SDP (Session Description Protocol) content of the session description.
    /// </summary>
    public string Sdp { get; set; }
}