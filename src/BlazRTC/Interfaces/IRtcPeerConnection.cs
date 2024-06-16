using BlazRTC.Models;

namespace BlazRTC;

public interface IRtcPeerConnection : IAsyncDisposable
{
    Task InitailiseAsync(object configuration);

    // bool CanTrickleIceCandidates { get; }
    // RtcConnectionState ConnectionState { get; }
    // RtcSessionDescription CurrentLocalDescription { get; }
    // RtcSessionDescription CurrentRemoteDescription { get; }
    // IceConnectionState IceConnectionState { get; }
    // IceGatheringState IceGatheringState { get; }
    // RtcSessionDescription LocalDescription { get; }
    // string? PeerIdentity { get; }
    // RtcSessionDescription PendingLocalDescription { get; }
    // RtcSessionDescription PendingRemoteDescription { get; }
    // RtcSessionDescription RemoteDescription { get; }
    // SignalingState SignalingState { get; }


    ///Methods
    Task AddIceCandidateAsync(object iceCandidate);
    //addTrack()
    //addTransceiver()
    //close()
    Task CreateAnswerAsync(object offer);
    //createDataChannel()
    Task CreateOfferAsync();
    //getConfiguration()
    //getIdentityAssertion()
    //getReceivers()
    //getSenders()
    //getStats()
    //getTransceivers()
    //removeTrack()
    //restartIce()
    //setConfiguration()
    //setIdentityProvider()
    //setLocalDescription()
    //setRemoteDescription()

    ///Events
    event EventHandler<IceCandidateEventArgs>? IceCandidateAvailable;
    event EventHandler<IceConnectionStateChangeEventArgs>? IceConnectionStateChanged;
    event EventHandler<RemoteStreamAvailableEventArgs>? OnRemoteStreamAvailable;
    event EventHandler<PeerConnectionStateChangeEventArgs>? PeerConnectionStateChange;
    event EventHandler<OfferEventArgs>? OfferAvailable;
    event EventHandler<AnswerEventArgs>? AnswerAvailable;
    //datachannel
    //icecandidateerror
    //icegatheringstatechange
    //negotiationneeded
    //signalingstatechange
    //track
}
