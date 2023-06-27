using BlazRTC.Interops;
using Microsoft.Extensions.DependencyInjection;

namespace BlazRTC;

public static class DependencyInjection
{
    public static IServiceCollection AddBlazRTCServices(this IServiceCollection services)
    {
        services.AddSingleton<IBlazRTCInterop, BlazRTCInterop>();
        services.AddSingleton<IBlazRTCService, BlazRTCService>();
        return services;
    }
}
