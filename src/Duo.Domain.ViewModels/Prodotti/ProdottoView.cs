﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Domain.ViewModels.Prodotti
{
    public class ProdottoView
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public decimal Spessore { get; set; }
        public bool IsCancellato { get; set; }
    }
}
