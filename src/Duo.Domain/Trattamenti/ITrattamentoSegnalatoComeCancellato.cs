using Radical.CQRS;

namespace Duo.Domain.Trattamenti
{
    public interface ITrattamentoSegnalatoComeCancellato : IDomainEvent
    {
        string Codice { get; set; }
        string Descrizione { get; set; }
    }
}