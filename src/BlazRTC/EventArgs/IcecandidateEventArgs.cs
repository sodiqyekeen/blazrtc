namespace BlazRTC;

public class IceCandidateEventArgs : EventArgs
{
    public IceCandidateEventArgs(object candidate)
    {
        Candidate = candidate;
    }

    public object Candidate { get; }
}
