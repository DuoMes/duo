using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Messages.Trattamenti.Commands
{
    public class CambiaCodiceTrattamento
    {
        public Guid Id { get; set; }
        public string Codice { get; set; }
    }
}
