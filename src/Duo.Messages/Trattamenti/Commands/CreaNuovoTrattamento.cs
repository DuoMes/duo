using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Messages.Trattamenti.Commands
{
    public class CreaNuovoTrattamento
    {
        public string Codice { get; private  set; }
        public string Descrizione { get; private set; }

        private CreaNuovoTrattamento()
        {

        }

        public CreaNuovoTrattamento(string codice, string descrizione)
        {
            this.Codice = codice;
            this.Descrizione = descrizione;
        }
    }
}
