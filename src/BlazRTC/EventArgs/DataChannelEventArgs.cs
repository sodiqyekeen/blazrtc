using BlazRTC;

namespace BlazRTC;

/// <summary>
/// EventArgs for tracking changes in the state of a data channel.
/// </summary>
public class DataChannelEventArgs : EventArgs
{
    /// <summary>
    /// Gets or sets the label of the data channel.
    /// </summary>
    public string Label { get; set; }

    /// <summary>
    /// Gets or sets the data channel.
    /// </summary>
    public DataChannel DataChannel { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataChannelEventArgs"/> class with the specified label and data channel.
    /// </summary>
    /// <param name="label">The label of the data channel.</param>
    /// <param name="dataChannel">The data channel.</param>
    public DataChannelEventArgs(string label, DataChannel dataChannel)
    {
        Label = label;
        DataChannel = dataChannel;
    }
}
