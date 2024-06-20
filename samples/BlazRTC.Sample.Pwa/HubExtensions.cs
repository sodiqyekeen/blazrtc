using Microsoft.AspNetCore.SignalR.Client;

namespace BlazRTC.Sample.Pwa;
public static class HubExtensions
{
    public static HubConnection TryInitialize(this HubConnection? hubConnection)
    {
        if (hubConnection is null)
        {

            hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri("https://localhost:5212/blazrtc"))
                .WithAutomaticReconnect()
                .Build();
        }
        return hubConnection;
    }

    public static async Task<bool> ConnectWithRetryAsync(this HubConnection hubConnection, CancellationToken cancellationToken)
    {
        while (true)
        {
            try
            {
                await hubConnection.StartAsync(cancellationToken);
                return true;
            }
            catch when (cancellationToken.IsCancellationRequested)
            {
                return false;
            }
            catch (Exception)
            {
                await Task.Delay(5000, cancellationToken);
            }
        }
    }

    public static async ValueTask InvokeHubMethodAsync(this HubConnection hubConnection, string methodName)
    {
        if (hubConnection?.State is HubConnectionState.Connected)
        {
            await hubConnection.SendAsync(methodName);
        }

    }
}
