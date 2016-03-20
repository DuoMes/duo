using Duo.Clients.Wpf.Services;
using Duo.Domain.ViewModels.Trattamenti;
using Duo.Messages.Trattamenti.Commands;
using Radical.CQRS.Client;
using System;
using System.Collections.ObjectModel;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Windows.Presentation;

namespace Duo.Clients.Wpf.Presentation
{
    class GestioneAnagraficaTrattamentiViewModel : AbstractViewModel
    {
        readonly IMessageBroker broker;
        readonly TrattamentiViewsService trattamentiViewsService;
        readonly Services.AppSettings settings;


        public GestioneAnagraficaTrattamentiViewModel(Services.AppSettings settings, IMessageBroker broker, Services.TrattamentiViewsService trattamentiViewsService)
        {
            this.settings = settings;
            this.broker = broker;
            this.trattamentiViewsService = trattamentiViewsService;

            CaricaTrattamenti();

            ManagePropertyMetadata();
        }

        private async void CaricaTrattamenti()
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
            this.broker.Broadcast(this, new Messaging.ApriManutenzioneTrattamentoMessage(Guid.Empty, 0, string.Empty, string.Empty));
        }

        public void ModificaTrattamento()
        {
            this.broker.Broadcast(this, new Messaging.ApriManutenzioneTrattamentoMessage(
                                                            TrattamentoSelezionato.Id,
                                                            TrattamentoSelezionato.Version,
                                                            TrattamentoSelezionato.Codice,
                                                            TrattamentoSelezionato.Descrizione
                                                            ));
        }

        public async void EliminaTrattamento()
        {
            var commandClient = new CommandClient(this.settings.JasonBaseAddress);
            var newItemId = await commandClient.ExecuteAsync<Guid>(Guid.NewGuid().ToString(),
                                                                        new EliminaTrattamento(
                                                                            TrattamentoSelezionato.Id,
                                                                            TrattamentoSelezionato.Version
                                                                            ));
        }

    }
}
