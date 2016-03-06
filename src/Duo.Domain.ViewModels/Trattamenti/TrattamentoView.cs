using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Domain.ViewModels.Trattamenti
{
    public class TrattamentoView
    {
        public Guid Id { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
    }
}
