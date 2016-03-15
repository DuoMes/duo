using System;
using Duo.Domain.Trattamenti;
using Duo.Messages.Trattamenti.Commands;
using Jason.Handlers.Commands;
using Radical.CQRS;
using Radical.CQRS.Handlers;

namespace Duo.Domain.Handlers.Trattamenti
{
    class EliminaTrattamentoHandler : AbstractAggregateCommandHandler<Duo.Domain.Trattamenti.Trattamento, Duo.Messages.Trattamenti.Commands.EliminaTrattamento>
    {

        public override void Manipulate(Trattamento aggregate, EliminaTrattamento command)
        {
                aggregate.SegnalaComeCancellato();
        }
    }
}
