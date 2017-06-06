using System;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Windows.Presentation;

namespace Duo.Clients.Wpf.Presentation.ExtrusionPrograms
{
    class ExtrusionProgramViewModel : AbstractViewModel
    {
        Services.AppSettings settings;

        readonly IMessageBroker broker;

        public ExtrusionProgramViewModel(Services.AppSettings settings, IMessageBroker broker)
        {
            this.Title = "Insert Extrusion Program";
            ManagePropertyMetadata();
            this.settings = settings;
            this.broker = broker;
        }

        private void ManagePropertyMetadata()
        {

            this.GetPropertyMetadata(() => this.ExtrusionProgramId)
                .OnChanged(pvc =>
                {
                    this.Title = this.ExtrusionProgramId.HasValue ? "Edit Extrusion Program" : "Insert Extrusion Program";
                });
        }

        public string Title
        {
            get { return this.GetPropertyValue(() => this.Title); }
            set { this.SetPropertyValue(() => this.Title, value); }
        }

        public Guid? ExtrusionProgramId
        {
            get { return this.GetPropertyValue(() => this.ExtrusionProgramId); }
            set { this.SetPropertyValue(() => this.ExtrusionProgramId, value); }
        }


    }
}
