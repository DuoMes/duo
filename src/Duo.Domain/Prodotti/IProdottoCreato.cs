using Radical.CQRS;

namespace Duo.Domain.Prodotti
{
    public interface IProdottoCreato: IDomainEvent
    {
        string Codice { get; set; }
        string Descrizione { get; set; }
        decimal Spessore { get; set; }
    }
}