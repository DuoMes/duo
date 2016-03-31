using Duo.Domain.Prodotti;
using Duo.Messages.Prodotti.Commands;
using Radical.CQRS.Handlers;


namespace Duo.Domain.Handlers.Prodotti
{
    class CambiaAnagraficaProdottoHandler : AbstractAggregateCommandHandler<Prodotto, CambiaAnagraficaProdotto>
    {
        public override void Manipulate(Prodotto aggregate, CambiaAnagraficaProdotto command)
        {
            aggregate.CambiaAnagraficaProdotto(command.Codice, command.Descrizione, command.Spessore);
        }

    }
}
