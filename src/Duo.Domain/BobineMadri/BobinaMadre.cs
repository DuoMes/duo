using Radical.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Domain.BobineMadri
{
    public class BobinaMadre: Aggregate<BobinaMadre.Stato>
    {
        public class Stato : AggregateState
        {
            public string Codice { get; set;}
            public int Lunghezza { get; set; }
            public int Fascia { get; set; }
        }

        public class Factory
        {
            public BobinaMadre CreaNuova(string codice, int lunghezza, int fascia)
            {
                var stato = new Stato() {
                    Codice = codice,
                    Fascia = fascia,
                    Lunghezza = lunghezza
                };
                var aggregato = new BobinaMadre(stato);
                aggregato.SetupCompleted();
                return aggregato;
            }
        }

        private BobinaMadre(BobinaMadre.Stato stato)
            :base(stato)
        {                        
        }

        private void SetupCompleted()
        {
            this.RaiseEvent<IBobinaMadreCreata>(e =>
            {
                e.Codice = this.Data.Codice;
                e.Lunghezza = this.Data.Lunghezza;
                e.Fascia = this.Data.Fascia;
            });
        }

    }
}
