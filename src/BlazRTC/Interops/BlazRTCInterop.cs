using Microsoft.JSInterop;

namespace BlazRTC.Interops;

internal class BlazRTCInterop : IBlazRTCInterop, IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> rtcModuleTask;
    public BlazRTCInterop(IJSRuntime jSRuntime)
    {
        rtcModuleTask = new(() => jSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/BlazRTC/BlazRTC.js").AsTask());
    }

    public async Task<List<MediaDevice>> GetMediaDevicesAsync()
    {
        var module = await rtcModuleTask.Value;
        var response = await module.InvokeAsync<InteropResponse<List<MediaDevice>>>("getMediaDevices");
        return response.Succeeded ? response.Data! : throw new InteropException(response.Error!);
    }

    public async ValueTask DisposeAsync()
    {
        if (!rtcModuleTask.IsValueCreated)
            return;

        var module = await rtcModuleTask.Value;
        await module.DisposeAsync();
    }
}

