namespace BlazRTC;

public class MediaTrackConstraints
{
    public string DeviceId { get; set; } = string.Empty;
    public string GroupId { get; set; } = string.Empty;
}

public class AudioTrackConstraints : MediaTrackConstraints
{
    /// <value>
    /// Property <c>AutoGainControl</c> specifies whether automatic gain control is preferred and/or required.
    /// </value>
    /// <remarks>
    /// Only the following values are valid for this property:
    /// <list type="bullet">
    /// <item>
    /// <description>exact</description>
    /// </item>
    /// <item>
    /// <description>ideal</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints/autoGainControl"/>
    public string AutoGainControl { get; set; } = string.Empty;

    /// <value>
    /// Property <c>ChannelCount</c> specifies the exact or ideal number of channels for the audio track.
    /// </value>
    /// <remarks>
    /// Only the following values are valid for this property:
    /// <list type="bullet">
    /// <item>
    /// <description>exact</description>
    /// </item>
    /// <item>
    /// <description>ideal</description>
    /// </item>
    ///  <item>
    /// <description>max</description>
    /// </item>
    /// <item>
    /// <description>min</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints/channelCount"/>
    public string ChannelCount { get; set; } = string.Empty;

    /// <value>
    /// Property <c>EchoCancellation</c> specifies whether echo cancellation is preferred and/or required.
    /// </value>
    /// <remarks>
    /// Only the following values are valid for this property:
    /// <list type="bullet">
    /// <item>
    /// <description>exact</description>
    /// </item>
    /// <item>
    /// <description>ideal</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints/echoCancellation"/>
    public string EchoCancellation { get; set; } = string.Empty;

    /// <value>
    /// Property <c>Latency</c> specifies the exact or ideal latency for the audio track.
    /// </value>
    /// <remarks>
    /// Only the following values are valid for this property:
    /// <list type="bullet">
    /// <item>
    /// <description>exact</description>
    /// </item>
    /// <item>
    /// <description>ideal</description>
    /// </item>
    /// <item>
    /// <description>max</description>
    /// </item>
    /// <item>
    /// <description>min</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints/latency"/>
    public string Latency { get; set; } = string.Empty;

    /// <value>
    /// Property <c>NoiseSuppression</c> specifies whether noise suppression is preferred and/or required.
    /// </value>
    /// <remarks>
    /// Only the following values are valid for this property:
    /// <list type="bullet">
    /// <item>
    /// <description>exact</description>
    /// </item>
    /// <item>
    /// <description>ideal</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints/noiseSuppression"/>
    public string NoiseSuppression { get; set; } = string.Empty;

    /// <value>
    /// Property <c>SampleRate</c> specifies the exact or ideal sample rate for the audio track.
    /// </value>
    /// <remarks>
    /// Only the following values are valid for this property:
    /// <list type="bullet">
    /// <item>
    /// <description>exact</description>
    /// </item>
    /// <item>
    /// <description>ideal</description>
    /// </item>
    /// <item>
    /// <description>max</description>
    /// </item>
    /// <item>
    /// <description>min</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints/sampleRate"/>
    public string SampleRate { get; set; } = string.Empty;

    /// <value>
    /// Property <c>SampleSize</c> specifies the exact or ideal sample size for the audio track.
    /// </value>
    /// <remarks>
    /// Only the following values are valid for this property:
    /// <list type="bullet">
    /// <item>
    /// <description>exact</description>
    /// </item>
    /// <item>
    /// <description>ideal</description>
    /// </item>
    /// <item>
    /// <description>max</description>
    /// </item>
    /// <item>
    /// <description>min</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints/sampleSize"/>
    public string SampleSize { get; set; } = string.Empty;
}

public class VideoTrackConstraints : MediaTrackConstraints
{
    /// <value>
    /// Property <c>AspectRatio</c> specifies the exact or ideal aspect ratio for the video track.
    /// </value>
    /// <remarks>
    /// Only the following values are valid for this property:
    /// <list type="bullet">
    /// <item>
    /// <description>exact</description>
    /// </item>
    /// <item>
    /// <description>ideal</description>
    /// </item>
    /// <item>
    /// <description>max</description>
    /// </item>
    /// <item>
    /// <description>min</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints/aspectRatio"/>
    public string AspectRatio { get; set; } = string.Empty;

    /// <value>
    /// Property <c>FrameRate</c> specifies the exact or ideal frame rate for the video track.
    /// </value>
    /// <remarks>
    /// Only the following values are valid for this property:
    /// <list type="bullet">
    /// <item>
    /// <description>exact</description>
    /// </item>
    /// <item>
    /// <description>ideal</description>
    /// </item>
    /// <item>
    /// <description>max</description>
    /// </item>
    /// <item>
    /// <description>min</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints/frameRate"/>
    public string FrameRate { get; set; } = string.Empty;

    /// <value>
    /// Property <c>Height</c> specifies the exact or ideal height for the video track.
    /// </value>
    /// <remarks>
    /// Only the following values are valid for this property:
    /// <list type="bullet">
    /// <item>
    /// <description>exact</description>
    /// </item>
    /// <item>
    /// <description>ideal</description>
    /// </item>
    /// <item>
    /// <description>max</description>
    /// </item>
    /// <item>
    /// <description>min</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints/height"/>
    public string Height { get; set; } = string.Empty;

    /// <value>
    /// Property <c>Width</c> specifies the exact or ideal width for the video track.
    /// </value>
    /// <remarks>
    /// Only the following values are valid for this property:
    /// <list type="bullet">
    /// <item>
    /// <description>exact</description>
    /// </item>
    /// <item>
    /// <description>ideal</description>
    /// </item>
    /// <item>
    /// <description>max</description>
    /// </item>
    /// <item>
    /// <description>min</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso href="https://developer.mozilla.org/en-US/docs/Web/API/MediaTrackConstraints/width"/>
    public string Width { get; set; } = string.Empty;


}