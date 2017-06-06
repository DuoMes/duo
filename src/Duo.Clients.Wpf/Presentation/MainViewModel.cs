using System;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Windows.Presentation;

namespace Duo.Clients.Wpf.Presentation
{
    class MainViewModel : AbstractViewModel
    {
        readonly IMessageBroker broker;

        public MainViewModel(Services.AppSettings settings, IMessageBroker broker)
        {
            this.broker = broker;

        }

        public void OpenExtrusionProgramsManagement()
        {
            this.broker.Broadcast(this, new Messaging.ExtrusionPrograms.OpenExtrusionProgramsManagementMessage());
        }

        public void CreateExtrusionProgram()
        {
            this.broker.Broadcast(this, new Messaging.ExtrusionPrograms.CreateExtrusionProgramMessage());
        }

        public void UpdateExtrusionProgram()
        {
            this.broker.Broadcast(this, new Messaging.ExtrusionPrograms.UpdateExtrusionProgramMessage()
            {
                ExtrusionProgramId = Guid.NewGuid()
            });
        }

    }
}
