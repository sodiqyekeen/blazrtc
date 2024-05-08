using BlazRTC.Extensions;
using Microsoft.JSInterop;

namespace BlazRTC.Interops;

internal class MediaDeviceInterop : IMediaDeviceService, IDisposable
{
    private DotNetObjectReference<MediaDeviceInterop> _dotNetObjectReference;
    private EventHandler<MediaDeviceChangeEventArgs>? _onDeviceChange;
    private readonly string? _localStreamElementId;
    private readonly IJSRuntime _jSRuntime;

    public MediaDeviceInterop(IJSRuntime jSRuntime)
    {
        _dotNetObjectReference = DotNetObjectReference.Create(this);
        _jSRuntime = jSRuntime;
    }


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
            return [];
        return mediaDevices;
    }
    public async Task<bool> StartCameraAsync(MediaCaptureOptions options)
    {
        var succeeded = await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazMediaDevice.getMediaStream", options);
        if (succeeded)
        {
            // localStreamElementId = options.PreviewStreamIn;
            NotifyVideoStreamAvailable();
        }

        return succeeded;
    }


    public async Task StartCaptureAsync(MediaCaptureOptions options)
    {
        var constraints = BuildMediaConstraints(options);
        await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazMediaDevice.getMediaStream", constraints, options.PreviewStreamIn);
    }

    public void Dispose()
    {
        _dotNetObjectReference?.Dispose();
    }

    public async Task StopCameraAsync()
    {
        if (_localStreamElementId is null) return;
        await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazMediaDevice.stopMediaStream", _localStreamElementId);
    }

    private void NotifyVideoStreamAvailable() => OnVideoStreamAvailable?.Invoke();


    private static Dictionary<string, object> BuildMediaConstraints(MediaCaptureOptions options)
    {
        var constraints = new Dictionary<string, object>
        {
            ["audio"] = options.AudioEnabled,
            ["video"] = options.VideoEnabled ? BuildVideoConstraints(options) : false
        };

        if (options.AudioDeviceId is not null)
        {
            constraints["audio"] = new Dictionary<string, object>
            {
                ["deviceId"] = options.AudioDeviceId
            };
        }
        return constraints;
    }

    private static Dictionary<string, object> BuildVideoConstraints(MediaCaptureOptions options)
    {
        var constraints = new Dictionary<string, object>();

        if (options.VideoWidth > 0)
        {
            constraints["width"] = new Dictionary<string, object>
            {
                ["ideal"] = options.VideoWidth
            };
        }

        if (options.VideoHeight > 0)
        {
            constraints["height"] = new Dictionary<string, object>
            {
                ["ideal"] = options.VideoHeight
            };
        }

        if (options.FrameRate > 0)
        {
            constraints["frameRate"] = new Dictionary<string, object>
            {
                ["ideal"] = options.FrameRate
            };
        }

        if (options.AspectRatio > 0)
        {
            constraints["aspectRatio"] = new Dictionary<string, object>
            {
                ["ideal"] = options.AspectRatio
            };
        }

        if (options.FacingMode is not null)
        {
            constraints["facingMode"] = options.FacingMode;
        }

        if (options.ResizeMode is not null)
        {
            constraints["resizeMode"] = options.ResizeMode;
        }

        if (options.VideoDeviceId is not null)
        {
            constraints["deviceId"] = options.VideoDeviceId;
        }

        return constraints;
    }
}
