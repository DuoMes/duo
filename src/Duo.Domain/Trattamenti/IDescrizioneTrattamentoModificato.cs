using Radical.CQRS;

namespace Duo.Domain.Trattamenti
{
     interface IDescrizioneTrattamentoModificato: IDomainEvent
    {
        string Vecchia { get; set; }
        string Nuova { get; set; }
    }
}