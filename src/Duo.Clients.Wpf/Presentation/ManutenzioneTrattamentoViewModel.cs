﻿using Duo.Domain.ViewModels.Trattamenti;
using Duo.Messages.Trattamenti.Commands;
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
    class ManutenzioneTrattamentoViewModel : AbstractViewModel, IRequireValidation
    {
        readonly IMessageBroker broker;
        readonly Services.AppSettings settings;        

        public Guid Id
        {
            get { return this.GetPropertyValue(() => this.Id); }
            set { this.SetPropertyValue(() => this.Id, value); }
        }

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

        public string WindowTitle
        {
            get { return this.GetPropertyValue(() => this.WindowTitle); }
            set { this.SetPropertyValue(() => this.WindowTitle, value); }
        }

        public ManutenzioneTrattamentoViewModel(Services.AppSettings settings, IMessageBroker broker)
        {
            this.settings = settings;
            this.broker = broker;
            this.WindowTitle = (this.Id == Guid.Empty) ? "Inserimento Trattamento" : "Manutenzione Trattamento";
        }

        protected override IValidationService GetValidationService()
        {
            return new DataAnnotationValidationService<ManutenzioneTrattamentoViewModel>(this);
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
                var newItemId = await commandClient.ExecuteAsync<Guid>(Guid.NewGuid().ToString(), new CreaNuovoTrattamento()
                {
                    Codice = this.Codice,
                    Descrizione = this.Descrizione
                });
            }
            else
            {
                
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

