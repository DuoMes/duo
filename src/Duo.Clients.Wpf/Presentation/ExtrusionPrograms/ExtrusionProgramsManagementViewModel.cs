using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Windows.Presentation;

namespace Duo.Clients.Wpf.Presentation.ExtrusionPrograms
{
    class ExtrusionProgramsManagementViewModel : AbstractViewModel
    {
        Services.AppSettings settings;

        readonly IMessageBroker broker;

        public ExtrusionProgramsManagementViewModel(Services.AppSettings settings, IMessageBroker broker)
        {
            this.settings = settings;
            this.broker = broker;
        }
    }
}
