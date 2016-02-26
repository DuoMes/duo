using Jason.Handlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duo.Messages.BobineMadri.Commands;
using Radical.CQRS;

namespace Duo.Domain.Handlers.BobineMadri
{
    class CreaNuovaBobinaMadreHanlder : AbstractCommandHandler<Duo.Messages.BobineMadri.Commands.CreaNuovaBobinaMadre>
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
