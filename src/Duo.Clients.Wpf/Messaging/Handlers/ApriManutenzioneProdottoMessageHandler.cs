
using Duo.Clients.Wpf.Presentation;
using System.Windows;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Messaging;
using Topics.Radical.Windows.Presentation.ComponentModel;

namespace Duo.Clients.Wpf.Messaging.Handlers
{
    class ApriManutenzioneProdottoMessageHandler : AbstractMessageHandler<ApriManutenzioneProdottoMessage>, INeedSafeSubscription
    {
        readonly IViewResolver viewResolver;
        readonly IConventionsHandler conventions;

        public ApriManutenzioneProdottoMessageHandler(IViewResolver viewResolver, IConventionsHandler conventions)
        {
            this.viewResolver = viewResolver;
            this.conventions = conventions;
        }
        public override void Handle(object sender, ApriManutenzioneProdottoMessage message)
        {
            var view = viewResolver.GetView<ManutenzioneProdottoView, ManutenzioneProdottoViewModel>(vm =>
                                                                                                        {
                                                                                                            vm.Id = message.Id;
                                                                                                            vm.Version = message.Version;
                                                                                                            vm.Codice = message.Codice;
                                                                                                            vm.Descrizione = message.Descrizione;
                                                                                                            vm.Spessore = message.Spessore;
                                                                                                        });
            view.Owner = this.conventions.GetViewOfViewModel(sender) as Window;
            view.ShowDialog();
        }
    }
}
