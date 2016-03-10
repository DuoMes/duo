
using Radical.CQRS;

namespace Duo.Domain.Trattamenti
{
    interface ICodiceTrattamentoModificato: IDomainEvent
    {
        string Vecchio { get; set; }
        string Nuovo { get; set; }
    }
}
