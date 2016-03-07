using Jason.Handlers.Commands;
using Duo.Messages.Trattamenti.Commands;
using Radical.CQRS;

namespace Duo.Domain.Handlers.Trattamenti
{
    class CreaNuovoTrattamentoHandler : AbstractCommandHandler<Duo.Messages.Trattamenti.Commands.CreaNuovoTrattamento>
    {

        public IRepositoryFactory RepositoryFactory { get; set; }
        public Duo.Domain.Trattamenti.Trattamento.Factory Factory { get; set; }

        protected override object OnExecute(CreaNuovoTrattamento command)
        {

            using (var session = RepositoryFactory.OpenSession())
            {
                var trattamento = Factory.CreaNuovo(command.Codice, command.Descrizione);
                session.Add(trattamento);
                session.CommitChanges();
                return trattamento.Id;
            }


        }
    }
}
