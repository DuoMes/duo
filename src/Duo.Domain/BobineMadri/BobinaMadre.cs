﻿using Radical.CQRS;

namespace Duo.Domain.BobineMadri
{
    public class BobinaMadre: Aggregate<BobinaMadre.BobinaMadreStato>
    {
        public class BobinaMadreStato : AggregateState
        {
            public string Codice { get; set;}
            public int Lunghezza { get; set; }
            public int Fascia { get; set; }
        }

        public class Factory
        {
            public BobinaMadre CreaNuova(string codice, int lunghezza, int fascia)
            {
                var stato = new BobinaMadreStato() {
                    Codice = codice,
                    Fascia = fascia,
                    Lunghezza = lunghezza
                };
                var aggregato = new BobinaMadre(stato);
                aggregato.SetupCompleted();
                return aggregato;
            }
        }

        private BobinaMadre(BobinaMadre.BobinaMadreStato stato)
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
