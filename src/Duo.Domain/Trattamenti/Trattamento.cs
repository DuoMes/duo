using Radical.CQRS;

namespace Duo.Domain.Trattamenti
{
    public class Trattamento : Aggregate<Trattamento.Stato>
    {

        public class Stato : AggregateState
        {
            public string Codice { get; set; }
            public string Descrizione { get; set; }
        }

        public class Factory
        {
            public Trattamento CreaNuovo(string codice, string descrizione)
            {
                var stato = new Stato()
                {
                    Codice = codice,
                    Descrizione = descrizione
                };
                var aggregato = new Trattamento(stato);
                aggregato.SetupCompleted();
                return aggregato;
            }
        }

        private Trattamento(Trattamento.Stato stato)
            :base(stato)
        {
        }

        private void SetupCompleted()
        {
            this.RaiseEvent<ITrattamentoCreato>(e =>
            {
                e.Codice = this.Data.Codice;
                e.Descrizione = this.Data.Descrizione;
            });
        }

        public void CambiaCodice(string codice)
        {

            this.RaiseEvent<ITrattamentoCreato>(e =>
            {
                e.Codice = this.Data.Codice;
                e.Descrizione = this.Data.Descrizione;
            });

        }


    }
}
