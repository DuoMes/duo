
using Duo.Clients.Wpf.Services;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Messaging;
using Topics.Radical.Windows.Presentation.ComponentModel;

namespace Duo.Clients.Wpf.Messaging.Handlers
{
    class SalvaTrattamentoMessageHandler : AbstractMessageHandler<SalvaTrattamentoMessage>, INeedSafeSubscription
    {
        readonly IViewResolver viewResolver;
        readonly IConventionsHandler conventions;
        readonly TrattamentiViewsService trattamentiViewsService;

        public SalvaTrattamentoMessageHandler(IViewResolver viewResolver, IConventionsHandler conventions, TrattamentiViewsService trattamentiViewsService)
        {
            this.viewResolver = viewResolver;
            this.conventions = conventions;
            this.trattamentiViewsService = trattamentiViewsService;
        }
        public override void Handle(object sender, SalvaTrattamentoMessage message)
        {
            trattamentiViewsService.Salva(message.Trattamento);
        }
    }
}
