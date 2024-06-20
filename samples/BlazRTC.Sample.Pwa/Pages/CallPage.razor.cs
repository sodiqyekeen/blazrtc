using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using BlazRTC.Models;
using BlazRTC.Services;

namespace BlazRTC.Sample.Pwa;

public partial class CallPage : IAsyncDisposable
{
    [Inject] private IMediaDevice MediaDeviceService { get; set; } = default!;
    [Inject] private IRtcPeerConnection PeerConnection { get; set; } = default!;
    private HubConnection? _hubConnection;


    List<MediaDeviceInfo> devices = [];
    string? localStreamId = null;
    private CancellationTokenSource _cts = new CancellationTokenSource();

    protected override async Task OnInitializedAsync()
    {
        _hubConnection = _hubConnection.TryInitialize();
        _hubConnection!.ConnectWithRetryAsync(_cts.Token);

        devices = (await MediaDeviceService.GetMediaDevicesAsync()).ToList();
        MediaDeviceService.MediaStreamAvailable += OnStreamAvailable;
    }


    private void OnStreamAvailable(object? sender, MediaStreamEventArgs streamEvent)
    {
        this.localStreamId = streamEvent.Stream.Id;
        StateHasChanged();
    }

    private async Task StartMediaCapture()
    {
        var options = MediaCaptureOptions.Create()
        .WithAudioEnabled()
        .WithVideoEnabled()
        .WithPreviewStream("preview");

        var mediaStream = await MediaDeviceService.StartMediaCaptureAsync(options);
        Console.WriteLine("Stream Started " + mediaStream.Id);
        await PeerConnection.InitailiseAsync(new { });
        var offer = await PeerConnection.CreateOfferAsync(mediaStream.Id);
    }

    private async Task ToggleVideo()
    {
        if (localStreamId != null)
            await MediaDeviceService.ToggleVideoTrackAsync();
    }

    private async Task StopMediaCaptureAsync()
    {
        await MediaDeviceService.StopMediaCaptureAsync();
        localStreamId = null;
        StateHasChanged();
    }

    public async ValueTask DisposeAsync()
    {
        await StopMediaCaptureAsync();
        MediaDeviceService.MediaStreamAvailable -= OnStreamAvailable;
    }
}
