using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Duo.Server.Push
{
    public class ClientNotificastionsHub: Hub
    {
        public override Task OnConnected()
        {
            System.Console.WriteLine($"ClientNotificastionsHub / SignalR client connected: {this.Context.ConnectionId}.");

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            System.Console.WriteLine($"ClientNotificastionsHub / SignalR client {(stopCalled ? "manually disconnected" : "connection lost")} : {this.Context.ConnectionId}.");

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            System.Console.WriteLine($"ClientNotificastionsHub / SignalR client reconnected: {this.Context.ConnectionId}.");

            return base.OnReconnected();
        }
    }
}
