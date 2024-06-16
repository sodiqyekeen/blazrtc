namespace BlazRTC;

public interface IMediaStream
{
    string Id { get; }
    IReadOnlyList<IMediaStreamTrack> Tracks { get; }

    event EventHandler<MediaStreamTrackEventArgs>? TrackAdded;
    event EventHandler<MediaStreamTrackEventArgs>? TrackRemoved;

    Task AddTrackAsync(IMediaStreamTrack track);
    Task RemoveTrackAsync(IMediaStreamTrack track);
    MediaStreamTrack GetTrackById(string trackId);

}
