using System;
using System.Windows;
using System.Windows.Threading;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Messaging;

namespace Duo.Clients.Wpf.Messaging.Handlers
{
    class VisualizzaMessageBoxMessageHandler : AbstractMessageHandler<VisualizzaMessageBoxMessage>, INeedSafeSubscription
    {
        public override void Handle(object sender, VisualizzaMessageBoxMessage message)
        {
            MessageBox.Show(Application.Current.MainWindow, message.Message, message.Caption, MessageBoxButton.OK, message.Icon);
        }
    }
}
