namespace BlazRTC;

/// <summary>
/// Represents the type of an SDP (Session Description Protocol) message.
/// </summary>
public enum RtcSdpType
{
    /// <summary>
    /// Represents the SDP message that describes the initial proposal in an offer/answer exchange.
    /// </summary>
    Offer,

    /// <summary>
    /// Represents the SDP message that describes the agreed-upon configuration, and is being sent to finalize negotiation.
    /// </summary>
    Answer,

    /// <summary>
    /// Represents the SDP message that describes a provisional answer, which is an intermediate state in the offer/answer exchange.
    /// </summary>
    PrAnswer,

    /// <summary>
    /// Represents the SDP message that indicates a rollback of the negotiation process.
    /// </summary>
    Rollback
}
