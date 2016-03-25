using Radical.CQRS.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Messages.Trattamenti.Commands
{
    public class CambiaAnagraficaTrattamento: IAggregateCommand
    {
        public Guid Id { get; private set; }
        public int Version {get; private set;}
        public string Codice { get; private set; }
        public string Descrizione { get; private set; }

        private CambiaAnagraficaTrattamento()
        {
        }

        public CambiaAnagraficaTrattamento(Guid id, int version, string codice, string descrizione)
        {
            this.Id = id;
            this.Version = version;
            this.Codice = codice;
            this.Descrizione = descrizione;
        }
    }
}
