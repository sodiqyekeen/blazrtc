namespace BlazRTC;

internal class MediaStreamInterop : IMediaStream
{
    private readonly IJSRuntime _jsRuntime;
    private readonly List<IMediaStreamTrack> _tracks = [];
    private readonly DotNetObjectReference<MediaStreamInterop> _dotNetObjectReference;

    public MediaStreamInterop(IJSRuntime jsRuntime, JsMediaStream source)
    {
        _jsRuntime = jsRuntime;
        Id = source.Id;
        _tracks = source.Tracks.Select(track => (IMediaStreamTrack)new MediaStreamTrackInterop(jsRuntime, track)).ToList();
        _dotNetObjectReference = DotNetObjectReference.Create(this);
    }

    public string Id { get; }

    public IReadOnlyList<IMediaStreamTrack> Tracks => _tracks;

    public event EventHandler<MediaStreamTrackEventArgs>? TrackAdded;
    public event EventHandler<MediaStreamTrackEventArgs>? TrackRemoved;

    public async Task AddTrackAsync(IMediaStreamTrack track)
    {
        _tracks.Add(track);
        OnTrackAdded(new MediaStreamTrackEventArgs(track));
    }

    public MediaStreamTrack GetTrackById(string trackId)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveTrackAsync(IMediaStreamTrack track)
    {
        _tracks.Remove(track);
        OnTrackRemoved(new MediaStreamTrackEventArgs(track));
    }

    protected virtual void OnTrackAdded(MediaStreamTrackEventArgs e)
    {
        TrackAdded?.Invoke(this, e);
    }

    protected virtual void OnTrackRemoved(MediaStreamTrackEventArgs e)
    {
        TrackRemoved?.Invoke(this, e);
    }
}
