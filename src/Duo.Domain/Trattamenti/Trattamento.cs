using System;
using Radical.CQRS;

namespace Duo.Domain.Trattamenti
{
    public class Trattamento : Aggregate<Trattamento.StatoTrattamento>
    {

        public class StatoTrattamento : AggregateState
        {
            public string Codice { get; set; }
            public string Descrizione { get; set; }
            public bool IsCancellato { get; set; } = false;
        }

        public class Factory
        {
            public Trattamento CreaNuovo(string codice, string descrizione)
            {
                var stato = new StatoTrattamento()
                {
                    Codice = codice,
                    Descrizione = descrizione
                };
                var aggregato = new Trattamento(stato);
                aggregato.SetupCompleted();
                return aggregato;
            }
        }

        private Trattamento(Trattamento.StatoTrattamento stato)
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

        public void SegnalaComeCancellato()
        {
            if (!this.Data.IsCancellato)
            {
                this.Data.IsCancellato = true;
                this.RaiseEvent<ITrattamentoSegnalatoComeCancellato>(e =>
                {
                    e.Codice = this.Data.Codice;
                    e.Descrizione = this.Data.Descrizione;
                });
            }

        }

        public void CambiaCodice(string codice)
        {

            if (this.Data.Codice != codice)
            {
                var vecchio = this.Data.Codice;
                this.Data.Codice = codice;
                this.RaiseEvent<ICodiceTrattamentoModificato>(e =>
                {
                    e.Vecchio = vecchio;
                    e.Nuovo = this.Data.Codice;
                });
            }

        }

        public void CambiaDescrizione(string descrizione)
        {

            if (this.Data.Descrizione != descrizione)
            {
                var vecchia = this.Data.Descrizione;
                this.Data.Descrizione = descrizione;
                this.RaiseEvent<IDescrizioneTrattamentoModificato>(e =>
                {
                    e.Vecchia = vecchia;
                    e.Nuova = this.Data.Descrizione;
                });
            }

        }
    }
}
