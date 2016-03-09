using Duo.Domain.Trattamenti;
using Duo.Messages.Trattamenti.Commands;
using Jason.Handlers.Commands;
using Radical.CQRS;

namespace Duo.Domain.Handlers.Trattamenti
{
    class CambiaDescrizioneTrattamentoHandler : AbstractCommandHandler<Duo.Messages.Trattamenti.Commands.CambiaDescrizioneTrattamento>
    {

        public IRepositoryFactory RepositoryFactory { get; set; }
        public Duo.Domain.Trattamenti.Trattamento.Factory Factory { get; set; }

        protected override object OnExecute(CambiaDescrizioneTrattamento command)
        {

            using (var session = RepositoryFactory.OpenSession())
            {
                var trattamento = session.GetById<Trattamento>(command.Id);
                trattamento.CambiaDescrizione(command.Descrizione);
                session.CommitChanges();
                return null;
            }


        }
    }
}
