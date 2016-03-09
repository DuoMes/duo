using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Messages.Trattamenti.Commands
{
    public class CambiaDescrizioneTrattamento
    {
        public Guid Id { get; set; }
        public string Descrizione { get; set; }
    }
}
