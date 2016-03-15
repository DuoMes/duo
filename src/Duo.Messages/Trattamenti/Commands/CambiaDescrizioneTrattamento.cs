using Radical.CQRS.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Messages.Trattamenti.Commands
{
    public class CambiaDescrizioneTrattamento : IAggregateCommand
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }
        public string Descrizione { get; private set; }

        private CambiaDescrizioneTrattamento()
        {
        }

        public CambiaDescrizioneTrattamento(Guid id, int version, string descrizione)
        {
            this.Id = id;
            this.Version = version;
            this.Descrizione = descrizione;
        }
    }
}
