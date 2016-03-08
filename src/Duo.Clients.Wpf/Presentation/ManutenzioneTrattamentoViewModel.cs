using Duo.Domain.ViewModels.Trattamenti;
using System;
using System.Text;
using Topics.Radical.ComponentModel.Messaging;
using Topics.Radical.Windows.Presentation;
using Topics.Radical.Windows.Presentation.Messaging;

namespace Duo.Clients.Wpf.Presentation
{
    class ManutenzioneTrattamentoViewModel : AbstractViewModel
    {
        readonly IMessageBroker broker;

        public TrattamentoView Trattamento
        {
            get { return this.GetPropertyValue(() => this.Trattamento); }
            set { this.SetPropertyValue(() => this.Trattamento, value); }
        }

        public string WindowTitle
        {
            get { return this.GetPropertyValue(() => this.WindowTitle); }
            set { this.SetPropertyValue(() => this.WindowTitle, value); }
        }
        public ManutenzioneTrattamentoViewModel(IMessageBroker broker)
        {
            this.broker = broker;
            this.WindowTitle = (Trattamento.Id == Guid.Empty) ? "Inserimento Trattamento" : "Manutenzione Trattamento";
        }

        private string ControllaInserimento()
        {
            var errori = new StringBuilder("");

            if (string.IsNullOrEmpty(Trattamento.Codice))
            {
                errori.AppendLine(string.Format(" - {0}", "Il codice non può essere vuoto"));
            }

            if (string.IsNullOrEmpty(Trattamento.Descrizione))
            {
                errori.AppendLine(string.Format(" - {0}", "La desrizione non può essere vuota"));
            }

            return errori.ToString();
        }

#pragma warning disable 0618

        public void Conferma()
        {
            string errori = ControllaInserimento();

            if (!string.IsNullOrEmpty(errori))
            {
                this.broker.Broadcast(this, new Messaging.VisualizzaMessageBoxMessage
                {
                    Message = "Alcuni dati non sono stati inseriti corettamente" + Environment.NewLine + errori,
                    Caption = (Trattamento.Id == Guid.Empty) ? "Inserimento Trattamento" : "Manutenzione Trattamento",
                    Icon = System.Windows.MessageBoxImage.Warning
                });
                return;
            }

            this.broker.Broadcast(this, new Messaging.SalvaTrattamentoMessage
            {
                Trattamento = new TrattamentoView
                {
                    Id = Trattamento.Id,
                    Codice = Trattamento.Codice,
                    Descrizione = Trattamento.Descrizione
                }
            });


            this.broker.Broadcast(new CloseViewRequest(this));
        }


        public void Annulla()
        {
            this.broker.Broadcast(new CloseViewRequest(this));
        }

#pragma warning restore 0618

    }
}

