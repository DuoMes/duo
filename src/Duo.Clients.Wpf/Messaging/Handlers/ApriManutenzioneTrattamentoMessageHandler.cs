using Duo.Clients.Wpf.Presentation;
using System.Windows;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Messaging;
using Topics.Radical.Windows.Presentation.ComponentModel;

namespace Duo.Clients.Wpf.Messaging.Handlers
{
    class ApriManutenzioneTrattamentoMessageHandler : AbstractMessageHandler<ApriManutenzioneTrattamentoMessage>, INeedSafeSubscription
    {
        readonly IViewResolver viewResolver;
        readonly IConventionsHandler conventions;

        public ApriManutenzioneTrattamentoMessageHandler(IViewResolver viewResolver, IConventionsHandler conventions)
        {
            this.viewResolver = viewResolver;
            this.conventions = conventions;
        }
        public override void Handle(object sender, ApriManutenzioneTrattamentoMessage message)
        {
            var view = viewResolver.GetView<ManutenzioneTrattamentoView, ManutenzioneTrattamentoViewModel>(vm => { });
            view.Owner = this.conventions.GetViewOfViewModel(sender) as Window;
            view.ShowDialog();
        }
    }
}
