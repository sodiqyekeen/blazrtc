namespace BlazRTC;

public interface IMediaStreamTrack
{
    string Id { get; }
    string Label { get; }
    TrackKind Kind { get; }

    // Task ApplyConstraintsAsync(MediaTrackConstraints constraints);
}
