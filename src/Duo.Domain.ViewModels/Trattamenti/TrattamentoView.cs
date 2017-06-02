using System;

namespace Duo.Domain.ViewModels.Trattamenti
{
    public class TrattamentoView
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public bool IsCancellato { get; set; }
    }
}
