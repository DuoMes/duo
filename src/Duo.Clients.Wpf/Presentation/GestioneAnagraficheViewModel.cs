using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Windows.Presentation;
using Topics.Radical.Windows.Presentation.Messaging;

namespace Duo.Clients.Wpf.Presentation
{
    class GestioneAnagraficheViewModel : AbstractViewModel
    {
        readonly IMessageBroker broker;
        public GestioneAnagraficheViewModel(IMessageBroker broker)
        {
            this.broker = broker;
        }

        public void ApriGestioneAnagraficaTrattamenti()
        {
            this.broker.Broadcast(this, new Messaging.ApriGestioneAnagraficaTrattamentiMessage());
        }

        public void ApriGestioneAnagraficaProdotti()
        {
            this.broker.Broadcast(this, new Messaging.ApriGestioneAnagraficaProdottiMessage());
        }

#pragma warning disable 0618
        public void Esci()
        {
            this.broker.Broadcast(new CloseViewRequest(this));
        }
    }
#pragma warning restore 0618

}
