namespace BlazRTC;

public class IcecandidateEventArgs : EventArgs
{
    public IcecandidateEventArgs(object candidate)
    {
        Candidate = candidate;
    }

    public object Candidate { get; }
}
