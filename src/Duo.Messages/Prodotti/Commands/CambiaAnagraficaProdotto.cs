using Radical.CQRS.Messages;
using System;

namespace Duo.Messages.Prodotti.Commands
{
    public class CambiaAnagraficaProdotto : IAggregateCommand
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public string Codice { get; private set; }
        public string Descrizione { get; private set; }
        public decimal Spessore { get; private set; }

        private CambiaAnagraficaProdotto()
        {
        }

        public CambiaAnagraficaProdotto(Guid id, int version, string codice, string descrizione, decimal spessore)
        {
            this.Id = id;
            this.Version = version;
            this.Codice = codice;
            this.Descrizione = descrizione;
            this.Spessore = spessore;
        }
    }
}

