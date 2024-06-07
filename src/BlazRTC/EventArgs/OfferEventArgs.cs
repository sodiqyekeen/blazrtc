namespace BlazRTC;

public class OfferEventArgs(object offer) : EventArgs
{
    public object Offer { get; } = offer;
}
