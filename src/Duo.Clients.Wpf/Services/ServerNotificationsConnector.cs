using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Windows.Presentation.Boot;

namespace Duo.Clients.Wpf.Services
{
    class ServerNotificationsConnector : IExpectBootCallback, IDisposable
    {
        readonly AppSettings settings;
        readonly IMessageBroker broker;

        HubConnection hubConnection;

        public ServerNotificationsConnector(AppSettings settings, IMessageBroker broker)
        {
            this.settings = settings;
            this.broker = broker;
        }

        public async void OnBootCompleted()
        {
            this.hubConnection = new HubConnection(this.settings.SignalRBaseAddress);
            var clientNotificastionsHubProxy = hubConnection.CreateHubProxy( "ClientNotificastionsHub" );
            clientNotificastionsHubProxy.On<Duo.Notifications.SuccessNotification>("OnCommandExecuted", async msg =>
            {
                await this.broker.BroadcastAsync(this, new Messaging.CommandExecuted() { Notification = msg });
            } );

            clientNotificastionsHubProxy.On<Duo.Notifications.FailureNotification>("OnCommandFailed", async msg =>
            {
                await this.broker.BroadcastAsync(this, new Messaging.CommandFailed() { Notification = msg });
            });

            await this.hubConnection.Start();
        }

        public void Dispose()
        {
            if(this.hubConnection != null)
            {
                if(this.hubConnection.State == ConnectionState.Connected)
                {
                    this.hubConnection.Stop();
                }

                this.hubConnection.Dispose();
            }
        }
    }
}