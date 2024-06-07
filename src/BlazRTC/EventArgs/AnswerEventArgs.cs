namespace BlazRTC;

public class AnswerEventArgs(object answer) : EventArgs
{
    public object Answer { get; } = answer;
}
