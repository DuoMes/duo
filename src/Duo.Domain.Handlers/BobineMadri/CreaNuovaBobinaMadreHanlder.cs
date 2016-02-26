using Jason.Handlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duo.Messages.BobineMadri.Commands;

namespace Duo.Domain.Handlers.BobineMadri
{
    class CreaNuovaBobinaMadreHanlder : AbstractCommandHandler<Duo.Messages.BobineMadri.Commands.CreaNuovaBobinaMadre>
    {
        protected override object OnExecute(CreaNuovaBobinaMadre command)
        {
            return Guid.NewGuid();
        }
    }
}
