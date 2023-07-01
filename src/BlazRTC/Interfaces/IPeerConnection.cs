using BlazRTC.Models;

namespace BlazRTC;

public interface IPeerConnection
{
    event EventHandler<ConnectionStateEventArgs> ConnectionStateChanged;

    ///Properties
    //canTrickleIceCandidates
    //connectionState
    //currentLocalDescription
    //currentRemoteDescription
    //iceConnectionState
    //iceGatheringState
    //localDescription
    //peerIdentity
    //pendingLocalDescription
    //pendingRemoteDescription
    //remoteDescription
    //sctp
    //signalingState


    ///Methods
    //addIceCandidate()
    //addTrack()
    //addTransceiver()
    //close()
    //createAnswer()
    //createDataChannel()
    //createOffer()
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
    //connectionstatechange
    //datachannel
    //icecandidate
    //icecandidateerror
    //iceconnectionstatechange
    //icegatheringstatechange
    //negotiationneeded
    //signalingstatechange
    //track
}
