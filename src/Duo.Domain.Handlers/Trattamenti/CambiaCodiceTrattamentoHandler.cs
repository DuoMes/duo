using Duo.Domain.Trattamenti;
using Duo.Messages.Trattamenti.Commands;
using Jason.Handlers.Commands;
using Radical.CQRS;

namespace Duo.Domain.Handlers.Trattamenti
{
    class CambiaCodiceTrattamentoHandler : AbstractCommandHandler<Duo.Messages.Trattamenti.Commands.CambiaCodiceTrattamento>
    {

        public IRepositoryFactory RepositoryFactory { get; set; }
        public Duo.Domain.Trattamenti.Trattamento.Factory Factory { get; set; }

        protected override object OnExecute(CambiaCodiceTrattamento command)
        {

            using (var session = RepositoryFactory.OpenSession())
            {
                var trattamento = session.GetById<Trattamento>(command.Id);
                trattamento.CambiaCodice(command.Codice);
                session.CommitChanges();
                return trattamento.Id;
            }


        }
    }
}
