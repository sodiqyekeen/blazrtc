namespace BlazRTC;

/// <summary>
/// Represents the type of an RTC ice candidate.
/// </summary>
public enum RtcIceCandidateType
{
    /// <summary>
    /// The candidate is a host candidate, whose IP address as specified in the RTCIceCandidate.address property is in fact the true address of the remote peer.
    /// </summary>
    Host,

    /// <summary>
    /// The candidate is a server reflexive candidate; the ip and port are a binding allocated by a NAT for an agent when it sent a packet through the NAT to a server. They can be learned by the STUN server and TURN server to represent the candidate's peer anonymously.
    /// </summary>
    Srflx,

    /// <summary>
    /// The candidate is a peer reflexive candidate; the ip and port are a binding allocated by a NAT when it sent a STUN request to represent the candidate's peer anonymously.
    /// </summary>
    Prflx,

    /// <summary>
    /// The candidate is a relay candidate, obtained from a TURN server. The relay candidate's IP address is an address the TURN server uses to forward the media between the two peers.
    /// </summary>
    Relay
}

