namespace Duo.Messages.BobineMadri.Commands
{
    public class CreaNuovaBobinaMadre
    {
        public string Codice { get; private set; }
        public int Lunghezza { get; private set; }
        public int Fascia { get; private set; }

        private CreaNuovaBobinaMadre()
        {

        }

        public CreaNuovaBobinaMadre(string codice, int lunghezza, int fascia)
        {
            this.Codice = codice;
            this.Lunghezza = lunghezza;
            this.Fascia = fascia;
        }


    }
}
