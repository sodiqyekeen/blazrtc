namespace BlazRTC;


/// <summary>
/// Represents an ICE (Interactive Connectivity Establishment) candidate for establishing a WebRTC connection.
/// </summary>
/// <param name="Address">A string containing the IP address of the candidate.</param>
/// <param name="Candidate">A string representing the transport address for the candidate that can be used for connectivity checks.</param>
/// <param name="Component">An enum representing the component of the candidate.</param>
/// <param name="Foundation">A string containing the foundation for the candidate.</param>
/// <param name="Port">An integer representing the port number of the candidate.</param>
/// <param name="Priority">An integer representing the priority of the candidate.</param>
/// <param name="Protocol">A string containing the protocol of the candidate.</param>
/// <param name="Type">An enum representing the type of the candidate.</param>
/// <param name="UsernameFragment">A string containing the username fragment of the candidate.</param>
/// <param name="RelatedAddress">A string containing the related address of the candidate.</param>
/// <param name="RelatedPort">An integer representing the related port of the candidate.</param>
/// <param name="SdpMid">A string containing the media stream identification tag of the candidate.</param>
/// <param name="SdpMLineIndex">An integer representing the index (starting at zero) of the m-line in the SDP this candidate is associated with.</param>
/// <param name="TcpType">A string containing the TCP type of the candidate.</param>
public record RtcIceCandidate(
    string Address,
    string Candidate,
    RtcIceCandidateComponent Component,
    string Foundation,
    int Port,
    int Priority,
    string Protocol,
    RtcIceCandidateType Type,
    string UsernameFragment,
    string? RelatedAddress,
    int? RelatedPort,
    string? SdpMid,
    int? SdpMLineIndex,
    string TcpType
    );