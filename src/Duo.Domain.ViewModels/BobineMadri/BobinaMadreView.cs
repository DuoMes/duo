using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Domain.ViewModels.BobineMadri
{
    public class BobinaMadreView
    {
        public Guid Id { get; private set; }
        public string Codice { get; private set; }
        public int Lunghezza { get; private set; }
        public int Fascia { get; private set; }
    }
}
