using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazRTC;

public class MediaDeviceInfoConverter : JsonConverter<MediaDeviceInfo>
{
    public override MediaDeviceInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException();

        string deviceId = string.Empty;
        string label = string.Empty;
        MediaDeviceKind kind = MediaDeviceKind.AudioInput;
        string groupId = string.Empty;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
                return new MediaDeviceInfo(deviceId, label, kind, groupId);

            if (reader.TokenType != JsonTokenType.PropertyName)
                throw new JsonException();

            string propertyName = reader.GetString()!;
            reader.Read();

            switch (propertyName)
            {
                case "deviceId":
                    deviceId = reader.GetString() ?? string.Empty;
                    break;
                case "label":
                    label = reader.GetString() ?? string.Empty;
                    break;
                case "kind":
                    kind = reader.GetString() switch
                    {
                        "audioinput" => MediaDeviceKind.AudioInput,
                        "audiooutput" => MediaDeviceKind.AudioOutput,
                        "videoinput" => MediaDeviceKind.VideoInput,
                        _ => MediaDeviceKind.Unknown
                    };
                    break;
                case "groupId":
                    groupId = reader.GetString() ?? string.Empty;
                    break;
            }
        }

        return new MediaDeviceInfo(deviceId, label, kind, groupId);
    }

    public override void Write(Utf8JsonWriter writer, MediaDeviceInfo value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("deviceId", value.DeviceId);
        writer.WriteString("label", value.Label);
        writer.WriteString("kind", value.Kind.ToString());
        writer.WriteString("groupId", value.GroupId);
        writer.WriteEndObject();
    }
}
