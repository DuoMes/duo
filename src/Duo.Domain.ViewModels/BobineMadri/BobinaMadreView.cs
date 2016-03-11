using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Domain.ViewModels.BobineMadri
{
    public class BobinaMadreView
    {
        public Guid Id { get;  set; }
        public int Version { get; set; }
        public string Codice { get;  set; }
        public int Lunghezza { get;  set; }
        public int Fascia { get;  set; }
    }
}
