using System;
using System.Windows;
using Duo.Clients.Wpf.Messaging.ExtrusionPrograms;
using Duo.Clients.Wpf.Presentation.ExtrusionPrograms;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Messaging;
using Topics.Radical.Windows.Presentation.ComponentModel;

namespace Duo.Clients.Wpf.Messaging.Handlers.ExtrusionPrograms
{
    class OpenExtrusionProgramsManagementMessageHandler : AbstractMessageHandler<OpenExtrusionProgramsManagementMessage>, INeedSafeSubscription
    {
        readonly IViewResolver viewResolver;
        readonly IConventionsHandler conventions;

        public OpenExtrusionProgramsManagementMessageHandler(IViewResolver viewResolver, IConventionsHandler conventions)
        {
            this.viewResolver = viewResolver;
            this.conventions = conventions;
        }

        public override void Handle(object sender, OpenExtrusionProgramsManagementMessage message)
        {
            var view = viewResolver.GetView<ExtrusionProgramsManagementView, ExtrusionProgramsManagementViewModel>(vm => { });
            view.Owner = this.conventions.GetViewOfViewModel(sender) as Window;
            view.ShowDialog();
        }
    }
}
