using Radical.CQRS;

namespace Duo.Domain.Trattamenti
{
    public interface ITrattamentoCreato: IDomainEvent
    {
        string Codice { get; set; }
        string Descrizione { get; set; }
    }
}
