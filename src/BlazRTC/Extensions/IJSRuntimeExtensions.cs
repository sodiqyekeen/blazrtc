using System.Text.Json;
using Microsoft.JSInterop;

namespace BlazRTC.Extensions;

internal static class IJSRuntimeExtensions
{
    public static async ValueTask<bool> InvokeVoidAsyncWithErrorHandling(this IJSRuntime jsRuntime, string identifier, params object?[] args)
    {
        try
        {
            await jsRuntime.InvokeVoidAsync(identifier, args);
            return true;
        }
        catch (Exception ex)
        {
#if DEBUG
            Console.WriteLine(ex.ToString());
#endif
            return false;
        }
    }

    public static async ValueTask<T?> InvokeAsyncWithErrorHandling<T>(this IJSRuntime jsRuntime, string identifier, params object?[] args)
    {
        try
        {
            return await jsRuntime.InvokeAsync<T>(identifier, args);
        }
        catch (Exception ex)
        {
#if DEBUG
            Console.WriteLine(ex.ToString());
#endif
            return default;
        }
    }


    public static async ValueTask<T?> InvokeAsyncWithErrorHandling<T>(this IJSRuntime jsRuntime, string identifier, JsonSerializerOptions serializerOptions, params object?[] args)
    {
        try
        {
            var result = await jsRuntime.InvokeAsync<object>(identifier, args);
            return result.ToJson().FromJson<T>(serializerOptions);
        }
        catch (Exception ex)
        {
#if DEBUG
            Console.WriteLine(ex.ToString());
#endif
            return default;
        }
    }
}
