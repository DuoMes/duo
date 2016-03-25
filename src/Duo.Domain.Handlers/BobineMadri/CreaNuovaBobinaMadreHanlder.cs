using Jason.Handlers.Commands;
using Duo.Messages.BobineMadri.Commands;
using Radical.CQRS;

namespace Duo.Domain.Handlers.BobineMadri
{
    class CreaNuovaBobinaMadreHanlder : AbstractCommandHandler<CreaNuovaBobinaMadre>
    {

        public IRepositoryFactory RepositoryFactory { get; set; }
        public Duo.Domain.BobineMadri.BobinaMadre.Factory Factory { get; set; }

        protected override object OnExecute(CreaNuovaBobinaMadre command)
        {

            using (var session = RepositoryFactory.OpenSession())
            {
                var bobinaMadre = Factory.CreaNuova(command.Codice, command.Lunghezza, command.Fascia);
                session.Add(bobinaMadre);
                session.CommitChanges();
                return bobinaMadre.Id;
            }


        }
    }
}
