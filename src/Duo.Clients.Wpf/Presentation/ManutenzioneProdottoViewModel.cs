using Duo.Clients.Wpf.Services;
using Duo.Messages.Prodotti.Commands;
using Radical.CQRS.Client;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Windows.Presentation;
using Topics.Radical.Windows.Presentation.ComponentModel;
using Topics.Radical.Windows.Presentation.Messaging;
using Topics.Radical.Windows.Presentation.Services.Validation;

namespace Duo.Clients.Wpf.Presentation
{
    class ManutenzioneProdottoViewModel : AbstractViewModel
    {
        readonly IMessageBroker broker;
        readonly Services.AppSettings settings;
        readonly ProdottiViewsService prodottiViewsService;

        public Guid Id;
        public int Version;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Il campo codice non può essere vuoto")]
        public string Codice
        {
            get { return this.GetPropertyValue(() => this.Codice); }
            set { this.SetPropertyValue(() => this.Codice, value); }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Il campo descrizione non può essere vuoto")]
        public string Descrizione
        {
            get { return this.GetPropertyValue(() => this.Descrizione); }
            set { this.SetPropertyValue(() => this.Descrizione, value); }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Il campo spessore non può essere vuoto")]
        public decimal Spessore
        {
            get { return this.GetPropertyValue(() => this.Spessore); }
            set { this.SetPropertyValue(() => this.Spessore, value); }
        }

        public string WindowTitle
        {
            get { return this.GetPropertyValue(() => this.WindowTitle); }
            private set { this.SetPropertyValue(() => this.WindowTitle, value); }
        }

        public ManutenzioneProdottoViewModel(Services.AppSettings settings, IMessageBroker broker, Services.ProdottiViewsService prodottiViewsService)
        {
            this.settings = settings;
            this.broker = broker;
            this.prodottiViewsService = prodottiViewsService;

            
        }

        internal async void CaricaDatiProdotto(Guid idProdotto)
        {
            if (idProdotto == Guid.Empty)
            {
                this.WindowTitle = "Inserimento Prodotto";
            }
            else
            {
                this.WindowTitle = "Manutenzione Prodotto";
                var prodotto = await prodottiViewsService.GetById(idProdotto);
                this.Id = idProdotto;
                this.Version = prodotto.Version;
                this.Codice = prodotto.Codice;
                this.Descrizione = prodotto.Descrizione;
                this.Spessore = prodotto.Spessore;
            }
        }

        protected override IValidationService GetValidationService()
        {
            return new DataAnnotationValidationService<ManutenzioneProdottoViewModel>(this);
        }


#pragma warning disable 0618

        public async void Conferma()
        {
            this.Validate();

            if (!this.IsValid)
            {
                var errori = new StringBuilder("");
                foreach (var item in this.ValidationErrors)
                {
                    errori.AppendLine(string.Format(" - {0}", item.ToString()));
                }
                this.broker.Broadcast(this, new Messaging.VisualizzaMessageBoxMessage
                {
                    Message = "Alcuni dati non sono stati inseriti corettamente" + Environment.NewLine + errori,
                    Caption = this.WindowTitle,
                    Icon = System.Windows.MessageBoxImage.Warning
                });
                return;
            }

            var commandClient = new CommandClient(this.settings.JasonBaseAddress);
            if (this.Id == Guid.Empty)
            {
                var newItemId = await commandClient.ExecuteAsync<Guid>(Guid.NewGuid().ToString(), new CreaNuovoProdotto(this.Codice, this.Descrizione, this.Spessore));
            }
            else
            {
                await commandClient.ExecuteAsync<Guid>(Guid.NewGuid().ToString(), new CambiaAnagraficaProdotto(this.Id, this.Version, this.Codice, this.Descrizione, this.Spessore));
            }

            this.broker.Broadcast(new CloseViewRequest(this));
        }


        public void Annulla()
        {
            this.broker.Broadcast(new CloseViewRequest(this));
        }

#pragma warning restore 0618

    }
}
