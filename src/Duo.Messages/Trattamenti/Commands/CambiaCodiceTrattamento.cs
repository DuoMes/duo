using Radical.CQRS.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Messages.Trattamenti.Commands
{
    public class CambiaCodiceTrattamento: IAggregateCommand
    {
        public Guid Id { get; private set; }
        public int Version {get; private set;}
        public string Codice { get; private set; }

        private CambiaCodiceTrattamento()
        {
        }

        public CambiaCodiceTrattamento(Guid id, int version, string codice)
        {
            this.Id = id;
            this.Version = version;
            this.Codice = codice;
        }
    }
}
