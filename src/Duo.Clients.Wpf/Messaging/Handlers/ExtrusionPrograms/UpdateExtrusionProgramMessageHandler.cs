using System;
using System.Windows;
using Duo.Clients.Wpf.Messaging.ExtrusionPrograms;
using Duo.Clients.Wpf.Presentation.ExtrusionPrograms;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Messaging;
using Topics.Radical.Windows.Presentation.ComponentModel;

namespace Duo.Clients.Wpf.Messaging.Handlers.ExtrusionPrograms
{
    class UpdateExtrusionProgramMessageHandler : AbstractMessageHandler<UpdateExtrusionProgramMessage>, INeedSafeSubscription
    {
        readonly IViewResolver viewResolver;
        readonly IConventionsHandler conventions;

        public UpdateExtrusionProgramMessageHandler(IViewResolver viewResolver, IConventionsHandler conventions)
        {
            this.viewResolver = viewResolver;
            this.conventions = conventions;
        }

        public override void Handle(object sender, UpdateExtrusionProgramMessage message)
        {
            var view = viewResolver.GetView<ExtrusionProgramView, ExtrusionProgramViewModel>(vm =>
            {
                vm.ExtrusionProgramId = message.ExtrusionProgramId;
            });
            view.Owner = this.conventions.GetViewOfViewModel(sender) as Window;
            view.ShowDialog();
        }
    }
}
