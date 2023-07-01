using BlazRTC.Extensions;
using Microsoft.JSInterop;

namespace BlazRTC.Interops;

internal class MediaDeviceInterop : IMediaDeviceService, IDisposable
{
    private readonly IJSRuntime _jSRuntime;
    private DotNetObjectReference<MediaDeviceInterop>? _dotNetObjectReference;
    private EventHandler<MediaDeviceChangeEventArgs>? _onDeviceChange;
    private string? localStreamElementId;

    public event Action? OnVideoStreamAvailable;


    public MediaDeviceInterop(IJSRuntime jSRuntime)
    {
        _jSRuntime = jSRuntime;
    }

    public event EventHandler<MediaDeviceChangeEventArgs> OnDeviceChange
    {
        add => SubscribeToDeviceChange(value);
        remove => UnsubscribeFromDeviceChange(value);
    }

    private async void SubscribeToDeviceChange(EventHandler<MediaDeviceChangeEventArgs> eventHandler)
    {
        if (_onDeviceChange is null)
        {
            _dotNetObjectReference = DotNetObjectReference.Create(this);
            await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazMediaDevice.listenForDeviceChanges", _dotNetObjectReference);
        }
        _onDeviceChange += eventHandler;
    }

    private async void UnsubscribeFromDeviceChange(EventHandler<MediaDeviceChangeEventArgs> eventHandler)
    {
        _onDeviceChange -= eventHandler;
        if (_onDeviceChange is null)
            await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazMediaDevice.cancelDeviceChangeListener");
    }

    public async Task<IEnumerable<MediaDeviceInfo>> GetMediaDevicesAsync()
    {
        var mediaDevices = await _jSRuntime.InvokeAsyncWithErrorHandling<MediaDeviceInfo[]>("blazMediaDevice.getConnectedDevices");
        if (mediaDevices is null or { Length: 0 })
            return new List<MediaDeviceInfo>();
        //Todo: Handle situations where id and label are empty.
        return mediaDevices;
    }
    public async Task<bool> StartCameraAsync(MediaOptions options)
    {
        var succeeded = await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazMediaDevice.getMediaStream", options);
        if (succeeded)
        {
            localStreamElementId = options.PreviewStreamIn;
            NotifyVideoStreamAvailable();
        }

        return succeeded;
    }


    public void Dispose()
    {
        _dotNetObjectReference?.Dispose();
    }

    public async Task StopCameraAsync()
    {
        if (localStreamElementId is null) return;
        await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazMediaDevice.stopMediaStream", localStreamElementId);
    }

    private void NotifyVideoStreamAvailable() => OnVideoStreamAvailable?.Invoke();
}
