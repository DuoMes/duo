using Duo.Clients.Wpf.Presentation;
using System;
using System.Windows;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Messaging;
using Topics.Radical.Windows.Presentation.ComponentModel;

namespace Duo.Clients.Wpf.Messaging.Handlers
{
    class ApriCreazioneTrattamentoMessageHandler : AbstractMessageHandler<ApriCreazioneTrattamentoMessage>, INeedSafeSubscription
    {
        readonly IViewResolver viewResolver;
        readonly IConventionsHandler conventions;

        public ApriCreazioneTrattamentoMessageHandler(IViewResolver viewResolver, IConventionsHandler conventions)
        {
            this.viewResolver = viewResolver;
            this.conventions = conventions;
        }
        public override void Handle(object sender, ApriCreazioneTrattamentoMessage message)
        {
            var view = viewResolver.GetView<ManutenzioneTrattamentoView, ManutenzioneTrattamentoViewModel>(vm =>
            {
                vm.Id = Guid.Empty;
            });
            view.Owner = this.conventions.GetViewOfViewModel(sender) as Window;
            view.ShowDialog();
        }
    }
}
