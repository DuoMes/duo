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

        private BobinaMadre(BobinaMadre.Stato stato)
            :base(stato)
        {                        
        }
    }
}
