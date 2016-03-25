using Duo.Domain.ViewModels.Trattamenti;
using System;

namespace Duo.Clients.Wpf.Messaging
{
    class ApriManutenzioneTrattamentoMessage
    {
        public Guid Id { get; set; }
        public int Version { get; internal set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }

        private ApriManutenzioneTrattamentoMessage()
        {
        }

        public ApriManutenzioneTrattamentoMessage(Guid id, int version, string codice, string descrizione)
        {
            this.Id = id;
            this.Version = version;
            this.Codice = codice;
            this.Descrizione = descrizione;
        }

    }
}