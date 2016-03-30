
namespace Duo.Messages.Prodotti.Commands
{
    public class CreaNuovoProdotto
    {
        public string Codice { get; private set; }
        public string Descrizione { get; private set; }
        public decimal Spessore { get; private set; }

        private CreaNuovoProdotto()
        {

        }

        public CreaNuovoProdotto(string codice, string descrizione, decimal spessore)
        {
            this.Codice = codice;
            this.Descrizione = descrizione;
            this.Spessore = spessore;
        }
    }
}
