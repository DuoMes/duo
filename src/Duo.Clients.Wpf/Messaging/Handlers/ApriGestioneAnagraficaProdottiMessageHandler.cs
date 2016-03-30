
using Duo.Clients.Wpf.Presentation;
using System.Windows;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Messaging;
using Topics.Radical.Windows.Presentation.ComponentModel;

namespace Duo.Clients.Wpf.Messaging.Handlers
{
    class ApriGestioneAnagraficaProdottiMessageHandler : AbstractMessageHandler<ApriGestioneAnagraficaProdottiMessage>, INeedSafeSubscription
    {
        readonly IViewResolver viewResolver;
        readonly IConventionsHandler conventions;

        public ApriGestioneAnagraficaProdottiMessageHandler(IViewResolver viewResolver, IConventionsHandler conventions)
        {
            this.viewResolver = viewResolver;
            this.conventions = conventions;
        }
        public override void Handle(object sender, ApriGestioneAnagraficaProdottiMessage message)
        {
            var view = viewResolver.GetView<GestioneAnagraficaProdottiView, GestioneAnagraficaProdottiViewModel>(vm => { });
            view.Owner = this.conventions.GetViewOfViewModel(sender) as Window;
            view.ShowDialog();
        }
    }
}
