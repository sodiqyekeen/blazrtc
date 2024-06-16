using System.Text.Json;
using System.Text.Json.Serialization;

namespace BlazRTC;

public class JsonStringEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException($"Unexpected token type: {reader.TokenType}");
        string enumString = reader.GetString()!;
        return Enum.TryParse(enumString, true, out T result) ? result : throw new JsonException($"Invalid value: {enumString}");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
