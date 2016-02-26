using Radical.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Domain.BobineMadri
{
    public interface IBobinaMadreCreata : IDomainEvent
    {
        string Codice { get; set; }
        int Lunghezza { get; set; }
        int Fascia { get; set; }
    }
}
