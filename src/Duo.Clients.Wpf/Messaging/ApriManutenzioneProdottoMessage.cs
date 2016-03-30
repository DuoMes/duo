using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Clients.Wpf.Messaging
{
    class ApriManutenzioneProdottoMessage
    {
        public Guid Id { get; set; }
        public int Version { get; internal set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public decimal Spessore { get; set;}

        private ApriManutenzioneProdottoMessage()
        {
        }

        public ApriManutenzioneProdottoMessage(Guid id, int version, string codice, string descrizione, decimal spessore)
        {
            this.Id = id;
            this.Version = version;
            this.Codice = codice;
            this.Descrizione = descrizione;
            this.Spessore = spessore;
        }

    }
}
