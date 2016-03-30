using Duo.Domain.Prodotti;
using Duo.Messages.Prodotti.Commands;
using Radical.CQRS.Handlers;


namespace Duo.Domain.Handlers.Prodotti
{
    class EliminaProdottoHandler : AbstractAggregateCommandHandler<Prodotto, EliminaProdotto>
    {

        public override void Manipulate(Prodotto aggregate, EliminaProdotto command)
        {
            aggregate.SegnalaComeCancellato();
        }
    }
}
