using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Windows.Presentation;

namespace Duo.Clients.Wpf.Presentation
{
    class MainViewModel : AbstractViewModel
    {
        Services.AppSettings settings;

        readonly IMessageBroker broker;

        public MainViewModel(Services.AppSettings settings, IMessageBroker broker)
        {
            this.settings = settings;
            this.broker = broker;
        }

    }
}
