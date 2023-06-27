namespace BlazRTC;

public interface IPeerConnection
{
    event EventHandler<ConnectionStateEventArgs> ConnectionStateChanged;

}
