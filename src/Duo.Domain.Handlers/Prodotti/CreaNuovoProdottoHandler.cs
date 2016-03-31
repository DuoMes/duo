
using Duo.Messages.Prodotti.Commands;
using Jason.Handlers.Commands;
using Radical.CQRS;

namespace Duo.Domain.Handlers.Prodotti
{
    class CreaNuovoProdottoHandler : AbstractCommandHandler<CreaNuovoProdotto>
    {

        public IRepositoryFactory RepositoryFactory { get; set; }
        public Duo.Domain.Prodotti.Prodotto.Factory Factory { get; set; }

        protected override object OnExecute(CreaNuovoProdotto command)
        {

            using (var session = RepositoryFactory.OpenSession())
            {
                var prodotto = Factory.CreaNuovo(command.Codice, command.Descrizione, command.Spessore);
                session.Add(prodotto);
                session.CommitChanges();
                return prodotto.Id;
            }


        }
    
}
}
