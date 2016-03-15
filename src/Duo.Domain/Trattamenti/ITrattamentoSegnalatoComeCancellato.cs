using Radical.CQRS;

namespace Duo.Domain.Trattamenti
{
    internal interface ITrattamentoSegnalatoComeCancellato : IDomainEvent
    {
        string Codice { get; set; }
        string Descrizione { get; set; }
    }
}