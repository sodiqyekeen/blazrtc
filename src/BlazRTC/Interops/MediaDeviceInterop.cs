using System.Text.Json;
using BlazRTC.Extensions;
using Microsoft.JSInterop;

namespace BlazRTC.Interops;

internal class MediaDeviceInterop : IMediaDevice
{
    private readonly DotNetObjectReference<MediaDeviceInterop> _dotNetObjectReference;
    private EventHandler<MediaDeviceChangeEventArgs>? _onDeviceChange;
    private readonly IJSRuntime _jSRuntime;
    private string? _localStreamElementId;

    public MediaDeviceInterop(IJSRuntime jSRuntime)
    {
        _dotNetObjectReference = DotNetObjectReference.Create(this);
        _jSRuntime = jSRuntime;
    }

    public event EventHandler<MediaStreamEventArgs>? MediaStreamAvailable;

    public event EventHandler<MediaDeviceChangeEventArgs> OnDeviceChange
    {
        add => SubscribeToDeviceChange(value);
        remove => UnsubscribeFromDeviceChange(value);
    }

    private async void SubscribeToDeviceChange(EventHandler<MediaDeviceChangeEventArgs> eventHandler)
    {
        if (_onDeviceChange is null)
        {
            await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazRTC.mediaDevices.listenForDeviceChanges", _dotNetObjectReference);
        }
        _onDeviceChange += eventHandler;
    }

    private async void UnsubscribeFromDeviceChange(EventHandler<MediaDeviceChangeEventArgs> eventHandler)
    {
        _onDeviceChange -= eventHandler;
        if (_onDeviceChange is null)
            await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazRTC.mediaDevices.cancelDeviceChangeListener");
    }

    public async Task<IEnumerable<MediaDeviceInfo>> GetMediaDevicesAsync()
    {
        var mediaDevices = await _jSRuntime.InvokeAsyncWithErrorHandling<MediaDeviceInfo[]>("blazRTC.mediaDevices.getConnectedDevices");
        return mediaDevices!;
    }

    public async Task<IMediaStream> StartMediaCaptureAsync(MediaCaptureOptions options)
    {
        var constraints = BuildMediaConstraints(options);
        var mediaStream = await _jSRuntime.InvokeAsyncWithErrorHandling<JsMediaStream>("blazRTC.mediaDevices.getUserMedia", constraints, options.PreviewStreamIn, _dotNetObjectReference);
        _localStreamElementId = options.PreviewStreamIn;
        var stream = new MediaStreamInterop(_jSRuntime, mediaStream!);
        OnMediaStreamAvailable(new MediaStreamEventArgs(stream));
        return stream;
    }

    public async Task ToggleVideoTrackAsync()
    {
        await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazRTC.mediaDevices.toggleVideoTrack");
    }

    public async Task ToggleAudioTrackAsync()
    {
        await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazRTC.mediaDevices.toggleAudioTrack");
    }


    public async Task StopMediaCaptureAsync()
    {
        if (_localStreamElementId is null) return;
        await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazRTC.mediaDevices.stopMediaStream", _localStreamElementId);
    }

    [JSInvokable]
    public void RaiseOnMediaStreamAvailable(object streamData)
    {
        Console.WriteLine($"Stream Data: {streamData.ToJson()}");
    }

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

    protected virtual void OnMediaStreamAvailable(MediaStreamEventArgs e)
    {
        MediaStreamAvailable?.Invoke(this, e);
    }

    public async ValueTask DisposeAsync()
    {
        _dotNetObjectReference?.Dispose();
        _localStreamElementId = null;
        if (_onDeviceChange is not null)
        {
            _onDeviceChange = null;
            await _jSRuntime.InvokeVoidAsyncWithErrorHandling("blazRTC.mediaDevices.cancelDeviceChangeListener");
        }
    }
}
