
using BlazRTC.Extensions;
using Microsoft.JSInterop;

namespace BlazRTC;

internal class RtcPeerConnectionInterop : IRtcPeerConnection
{
    private readonly IJSRuntime _jSRuntime;
    private readonly DotNetObjectReference<RtcPeerConnectionInterop> _dotNetObjectReference;

    public event EventHandler<IceCandidateEventArgs>? IceCandidateAvailable;
    public event EventHandler<IceConnectionStateChangeEventArgs>? IceConnectionStateChanged;
    public event EventHandler<RemoteStreamAvailableEventArgs>? OnRemoteStreamAvailable;
    public event EventHandler<PeerConnectionStateChangeEventArgs>? PeerConnectionStateChange;
    public event EventHandler<OfferEventArgs>? OfferAvailable;
    public event EventHandler<AnswerEventArgs>? AnswerAvailable;
    public RtcPeerConnectionInterop(IJSRuntime jSRuntime)
    {
        _jSRuntime = jSRuntime;
        _dotNetObjectReference = DotNetObjectReference.Create(this);
    }

    public async Task InitailiseAsync(object configuration)
    {
        var suceeded = await _jSRuntime.InvokeVoidWithErrorHandlingAsync("blazRTC.initialisePeerConnection", configuration, _dotNetObjectReference);
        if (!suceeded)
        {
            throw new InvalidOperationException("Failed to initialise peer connection");
        }
    }

    public async Task AddIceCandidateAsync(object iceCandidate)
    {
        await _jSRuntime.InvokeVoidWithErrorHandlingAsync("blazRTC.peerConnection.addIceCandidate", iceCandidate);
    }

    public async Task<RtcSessionDescription> CreateOfferAsync(string? localStreamId = null)
    {
        var offer = await _jSRuntime.InvokeWithErrorHandlingAsync<RtcSessionDescription>("blazRTC.peerConnection.createOffer", localStreamId);
        Console.WriteLine("Offer created " + offer.ToJson());
        return offer!;
    }

    public async Task<RtcSessionDescription> CreateAnswerAsync(RtcSessionDescription offer)
    {
        var answer = await _jSRuntime.InvokeWithErrorHandlingAsync<RtcSessionDescription>("blazRTC.peerConnection.createAnswer", offer);
        return answer!;
    }


    [JSInvokable]
    public void RaiseOnIceCandidate(object iceCandidate)
    {
        IceCandidateAvailable?.Invoke(this, new IceCandidateEventArgs(iceCandidate));
    }

    [JSInvokable]
    public void RaiseOnIceConnectionStateChange(object iceConnectionState)
    {
        IceConnectionStateChanged?.Invoke(this, new IceConnectionStateChangeEventArgs(iceConnectionState));
    }

    [JSInvokable]
    public void RaiseOnRemoteStreamAvailable(object stream)
    {
        OnRemoteStreamAvailable?.Invoke(this, new RemoteStreamAvailableEventArgs());
    }

    [JSInvokable]
    public void RaiseOnConnectionStateChange(string connectionState)
    {
        PeerConnectionStateChange?.Invoke(this, new PeerConnectionStateChangeEventArgs(connectionState));
    }

    protected virtual void OnIceCandidateAvailable(IceCandidateEventArgs e)
    {
        IceCandidateAvailable?.Invoke(this, e);
    }

    protected virtual void OnIceConnectionStateChangeAvailable(IceConnectionStateChangeEventArgs e)
    {
        IceConnectionStateChanged?.Invoke(this, e);
    }

    protected virtual void OnRemoteStreamAvailableAvailable(RemoteStreamAvailableEventArgs e)
    {
        OnRemoteStreamAvailable?.Invoke(this, e);
    }

    protected virtual void OnPeerConnectionStateChangeAvailable(PeerConnectionStateChangeEventArgs e)
    {
        PeerConnectionStateChange?.Invoke(this, e);
    }

    protected virtual void OnOfferAvailableAvailable(OfferEventArgs e)
    {
        OfferAvailable?.Invoke(this, e);
    }

    protected virtual void OnAnswerAvailableAvailable(AnswerEventArgs e)
    {
        AnswerAvailable?.Invoke(this, e);
    }




    public async ValueTask DisposeAsync()
    {
        await _jSRuntime.InvokeVoidWithErrorHandlingAsync("blazRTC.peerConnection.dispose", _dotNetObjectReference);
    }
}
