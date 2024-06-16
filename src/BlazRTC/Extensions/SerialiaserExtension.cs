using System.Text.Json;

namespace BlazRTC.Extensions;

public static class SerialiaserExtension
{
    public readonly static JsonSerializerOptions DefaultJsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static string ToJson<T>(this T obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public static T FromJson<T>(this string json, JsonSerializerOptions? options = null)
    {
        options ??= DefaultJsonSerializerOptions;
        return JsonSerializer.Deserialize<T>(json, options)!;
    }

}
