using Duo.Domain.Trattamenti;
using Duo.Messages.Trattamenti.Commands;
using Jason.Handlers.Commands;
using Radical.CQRS;

namespace Duo.Domain.Handlers.Trattamenti
{
    class EliminaTrattamentoHandler : AbstractCommandHandler<Duo.Messages.Trattamenti.Commands.EliminaTrattamento>
    {

        public IRepositoryFactory RepositoryFactory { get; set; }
        public Duo.Domain.Trattamenti.Trattamento.Factory Factory { get; set; }

        protected override object OnExecute(EliminaTrattamento command)
        {

            using (var session = RepositoryFactory.OpenSession())
            {
                var trattamento = session.GetById<Trattamento>(command.Id);
                //session.Remove(trattamento);
                session.CommitChanges();
                return trattamento.Id;
            }


        }
    }
}
