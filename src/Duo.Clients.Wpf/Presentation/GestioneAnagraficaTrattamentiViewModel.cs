using Duo.Clients.Wpf.Services;
using Duo.Domain.ViewModels.Trattamenti;
using System.Collections.ObjectModel;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Windows.Presentation;

namespace Duo.Clients.Wpf.Presentation
{
    class GestioneAnagraficaTrattamentiViewModel : AbstractViewModel
    {
        readonly IMessageBroker broker;
        TrattamentiViewsService trattamentiViewsService;

        public GestioneAnagraficaTrattamentiViewModel(IMessageBroker broker, Services.TrattamentiViewsService trattamentiViewsService)
        {
            this.broker = broker;
            this.trattamentiViewsService = trattamentiViewsService;

            CaricaTrattamenti();

            ManagePropertyMetadata();
        }

        public async void CaricaTrattamenti()
        {
            var view = await trattamentiViewsService.List();
            this.Trattamenti = new ObservableCollection<TrattamentoView>(view.Results);

        }

        private void ManagePropertyMetadata()
        {
            this.GetPropertyMetadata(() => this.TrattamentoSelezionato)
                .OnChanged(pvc =>
                {
                    this.ElementoSelezionato = (this.TrattamentoSelezionato != null);
                });
        }

        public ObservableCollection<TrattamentoView> Trattamenti
        {
            get { return this.GetPropertyValue(() => this.Trattamenti); }
            set { this.SetPropertyValue(() => this.Trattamenti, value); }
        }

        public TrattamentoView TrattamentoSelezionato
        {
            get { return this.GetPropertyValue(() => this.TrattamentoSelezionato); }
            set { this.SetPropertyValue(() => this.TrattamentoSelezionato, value); }
        }

        public bool ElementoSelezionato
        {
            get { return this.GetPropertyValue(() => this.ElementoSelezionato); }
            set { this.SetPropertyValue(() => this.ElementoSelezionato, value); }
        }

        public void AggiungiTrattamento()
        {
            this.broker.Broadcast(this, new Messaging.ApriManutenzioneTrattamentoMessage
            {
                Trattamento = new TrattamentoView()
            });
        }

        public void ModificaTrattamento()
        {

        }

        public void EliminaTrattamento()
        {
            if (TrattamentoSelezionato == null)
            {
                this.broker.Broadcast(this, new Messaging.VisualizzaMessageBoxMessage
                {
                    Message = "E' necessario selezionare un elemento prima di procedere.",
                    Caption = "Cancellazione trattamento",
                    Icon = System.Windows.MessageBoxImage.Warning
                });
                return;
            }

            //trattamentiViewsService.Delete(TrattamentoSelezionato);
            this.Trattamenti.Remove(TrattamentoSelezionato);
        }

    }
}
