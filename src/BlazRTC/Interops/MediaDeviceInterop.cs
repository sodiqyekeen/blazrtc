using BlazRTC.Extensions;
using Microsoft.JSInterop;

namespace BlazRTC.Interops;

internal class MediaDeviceInterop(IJSRuntime jSRuntime) : IMediaDeviceService, IDisposable
{
    private DotNetObjectReference<MediaDeviceInterop>? _dotNetObjectReference;
    private EventHandler<MediaDeviceChangeEventArgs>? _onDeviceChange;
    private string? localStreamElementId;

    public event Action? OnVideoStreamAvailable;

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
            await jSRuntime.InvokeVoidAsyncWithErrorHandling("blazMediaDevice.listenForDeviceChanges", _dotNetObjectReference);
        }
        _onDeviceChange += eventHandler;
    }

    private async void UnsubscribeFromDeviceChange(EventHandler<MediaDeviceChangeEventArgs> eventHandler)
    {
        _onDeviceChange -= eventHandler;
        if (_onDeviceChange is null)
            await jSRuntime.InvokeVoidAsyncWithErrorHandling("blazMediaDevice.cancelDeviceChangeListener");
    }

    public async Task<IEnumerable<MediaDeviceInfo>> GetMediaDevicesAsync()
    {
        var mediaDevices = await jSRuntime.InvokeAsyncWithErrorHandling<MediaDeviceInfo[]>("blazMediaDevice.getConnectedDevices");
        if (mediaDevices is null or { Length: 0 })
            return [];
        //Todo: Handle situations where id and label are empty.
        return mediaDevices;
    }
    public async Task<bool> StartCameraAsync(MediaOptions options)
    {
        var succeeded = await jSRuntime.InvokeVoidAsyncWithErrorHandling("blazMediaDevice.getMediaStream", options);
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
        await jSRuntime.InvokeVoidAsyncWithErrorHandling("blazMediaDevice.stopMediaStream", localStreamElementId);
    }

    private void NotifyVideoStreamAvailable() => OnVideoStreamAvailable?.Invoke();
}
