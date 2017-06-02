using Radical.CQRS;

namespace Duo.Domain.Prodotti
{
    public class Prodotto : Aggregate<Prodotto.StatoProdotto>
    {

        public class StatoProdotto : AggregateState
        {
            public string Codice { get; set; }
            public string Descrizione { get; set; }
            public decimal Spessore { get; set; }
            public bool IsCancellato { get; set; } = false;
        }

        public class Factory
        {
            public Prodotto CreaNuovo(string codice, string descrizione, decimal spessore)
            {
                var stato = new StatoProdotto()
                {
                    Codice = codice,
                    Descrizione = descrizione,
                    Spessore = spessore
                };
                var aggregato = new Prodotto(stato);
                aggregato.SetupCompleted();
                return aggregato;
            }
        }

        private Prodotto(Prodotto.StatoProdotto stato)
            : base(stato)
        {
        }

        private void SetupCompleted()
        {
            this.RaiseEvent<IProdottoCreato>(e =>
            {
                e.Codice = this.Data.Codice;
                e.Descrizione = this.Data.Descrizione;
                e.Spessore = this.Data.Spessore;
            });
        }

        public void SegnalaComeCancellato()
        {
            if (!this.Data.IsCancellato)
            {
                this.Data.IsCancellato = true;
                this.RaiseEvent<IProdottoSegnalatoComeCancellato>(e =>
                {
                    e.Codice = this.Data.Codice;
                    e.Descrizione = this.Data.Descrizione;
                    e.Spessore = this.Data.Spessore;
                });
            }

        }

        public void CambiaAnagraficaProdotto(string codice, string descrizione, decimal spessore)
        {

            if (this.Data.Codice != codice || this.Data.Descrizione != descrizione || this.Data.Spessore != spessore)
            {
                var vecchioCodice = this.Data.Codice;
                var vecchiaDescrizione = this.Data.Descrizione;
                var vecchioSpessore = this.Data.Spessore;

                this.Data.Codice = codice;
                this.Data.Descrizione = descrizione;
                this.Data.Spessore = spessore;

                this.RaiseEvent<IAnagraficaProdottoModificata>(e =>
                {
                    e.VecchioCodice = vecchioCodice;
                    e.VecchiaDescrizione = vecchiaDescrizione;
                    e.VecchioSpessore = vecchioSpessore;
                    e.NuovoCodice = this.Data.Codice;
                    e.NuovaDescrizione = this.Data.Descrizione;
                    e.NuovoSpessore = this.Data.Spessore;
                });
            }

        }
    }
}
