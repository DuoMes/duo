using Duo.Domain.ViewModels.Trattamenti;
using System;

namespace Duo.Clients.Wpf.Messaging
{
    class ApriManutenzioneTrattamentoMessage
    {
        public Guid Id { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
    }
}