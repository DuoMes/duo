using Microsoft.AspNet.SignalR.Client;
using Polly;
using System;
using System.Net.Http;
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
            var clientNotificastionsHubProxy = hubConnection.CreateHubProxy("ClientNotificastionsHub");
            clientNotificastionsHubProxy.On<Notifications.SuccessNotification>("OnCommandExecuted", async msg =>
            {
                await this.broker.BroadcastAsync(this, new Messaging.CommandExecuted() { Notification = msg });
            });

            clientNotificastionsHubProxy.On<Notifications.FailureNotification>("OnCommandFailed", async msg =>
            {
                await this.broker.BroadcastAsync(this, new Messaging.CommandFailed() { Notification = msg });
            });

            await Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(1))
                .ExecuteAsync(async () =>
                {
                    await this.hubConnection.Start();
                });
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