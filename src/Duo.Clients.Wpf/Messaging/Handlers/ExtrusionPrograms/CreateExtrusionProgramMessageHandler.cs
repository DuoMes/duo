using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Duo.Clients.Wpf.Messaging.ExtrusionPrograms;
using Duo.Clients.Wpf.Presentation.ExtrusionPrograms;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Messaging;
using Topics.Radical.Windows.Presentation.ComponentModel;

namespace Duo.Clients.Wpf.Messaging.Handlers.ExtrusionPrograms
{
    class CreateExtrusionProgramMessageHandler : AbstractMessageHandler<CreateExtrusionProgramMessage>, INeedSafeSubscription
    {
        readonly IViewResolver viewResolver;
        readonly IConventionsHandler conventions;

        public CreateExtrusionProgramMessageHandler(IViewResolver viewResolver, IConventionsHandler conventions)
        {
            this.viewResolver = viewResolver;
            this.conventions = conventions;
        }

        public override void Handle(object sender, CreateExtrusionProgramMessage message)
        {
            var view = viewResolver.GetView<ExtrusionProgramView, ExtrusionProgramViewModel>(vm =>
            {
                vm.ExtrusionProgramId = new Guid?();
            });
            view.Owner = this.conventions.GetViewOfViewModel(sender) as Window;
            view.ShowDialog();
        }
    }
}
