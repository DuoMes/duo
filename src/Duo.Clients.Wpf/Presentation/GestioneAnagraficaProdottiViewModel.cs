using Duo.Clients.Wpf.Services;
using Duo.Domain.ViewModels.Prodotti;
using Duo.Messages.Prodotti.Commands;
using Radical.CQRS.Client;
using System;
using System.Collections.ObjectModel;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Windows.Presentation;

namespace Duo.Clients.Wpf.Presentation
{
    class GestioneAnagraficaProdottiViewModel : AbstractViewModel
    {
        readonly IMessageBroker broker;
        readonly ProdottiViewsService prodottiViewsService;
        readonly Services.AppSettings settings;


        public GestioneAnagraficaProdottiViewModel(Services.AppSettings settings, IMessageBroker broker, Services.ProdottiViewsService prodottiViewsService)
        {
            this.settings = settings;
            this.broker = broker;
            this.prodottiViewsService = prodottiViewsService;

            CaricaProdotti();

            ManagePropertyMetadata();
        }

        private async void CaricaProdotti()
        {
            var view = await prodottiViewsService.List();
            this.Prodotti = new ObservableCollection<ProdottoView>(view.Results);

        }

        private void ManagePropertyMetadata()
        {
            this.GetPropertyMetadata(() => this.ProdottoSelezionato)
                .OnChanged(pvc =>
                {
                    this.ElementoSelezionato = (this.ProdottoSelezionato != null);
                });
        }

        public ObservableCollection<ProdottoView> Prodotti
        {
            get { return this.GetPropertyValue(() => this.Prodotti); }
            set { this.SetPropertyValue(() => this.Prodotti, value); }
        }

        public ProdottoView ProdottoSelezionato
        {
            get { return this.GetPropertyValue(() => this.ProdottoSelezionato); }
            set { this.SetPropertyValue(() => this.ProdottoSelezionato, value); }
        }

        public bool ElementoSelezionato
        {
            get { return this.GetPropertyValue(() => this.ElementoSelezionato); }
            set { this.SetPropertyValue(() => this.ElementoSelezionato, value); }
        }

        public void AggiungiProdotto()
        {
            this.broker.Broadcast(this, new Messaging.ApriCreazioneProdottoMessage());
        }

        public void ModificaProdotto()
        {
            this.broker.Broadcast(this, new Messaging.ApriManutenzioneProdottoMessage(
                                                            ProdottoSelezionato.Id,
                                                            ProdottoSelezionato.Version,
                                                            ProdottoSelezionato.Codice,
                                                            ProdottoSelezionato.Descrizione,
                                                            ProdottoSelezionato.Spessore
                                                            ));
        }

        public async void EliminaProdotto()
        {
            var commandClient = new CommandClient(this.settings.JasonBaseAddress);
            var newItemId = await commandClient.ExecuteAsync<Guid>(Guid.NewGuid().ToString(),
                                                                        new EliminaProdotto(
                                                                            ProdottoSelezionato.Id,
                                                                            ProdottoSelezionato.Version
                                                                            ));
        }
    }
}
