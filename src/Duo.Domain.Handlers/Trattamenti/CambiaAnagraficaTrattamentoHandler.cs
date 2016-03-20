using Duo.Domain.Trattamenti;
using Duo.Messages.Trattamenti.Commands;
using Radical.CQRS.Handlers;

namespace Duo.Domain.Handlers.Trattamenti
{
    class CambiaAnagraficaTrattamentoHandler : AbstractAggregateCommandHandler<Trattamento, CambiaAnagraficaTrattamento>
    {
        public override void Manipulate(Trattamento aggregate, CambiaAnagraficaTrattamento command)
        {
            aggregate.CambiaAnagraficaTrattamento(command.Codice, command.Descrizione);
        }

    }
}
