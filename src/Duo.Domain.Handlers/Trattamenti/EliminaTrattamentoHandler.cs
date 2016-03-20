using Duo.Domain.Trattamenti;
using Duo.Messages.Trattamenti.Commands;
using Radical.CQRS.Handlers;

namespace Duo.Domain.Handlers.Trattamenti
{
    class EliminaTrattamentoHandler : AbstractAggregateCommandHandler<Trattamento, EliminaTrattamento>
    {

        public override void Manipulate(Trattamento aggregate, EliminaTrattamento command)
        {
                aggregate.SegnalaComeCancellato();
        }
    }
}
