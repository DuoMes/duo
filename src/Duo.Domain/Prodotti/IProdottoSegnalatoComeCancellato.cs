using Radical.CQRS;

namespace Duo.Domain.Prodotti
{
    public interface IProdottoSegnalatoComeCancellato: IDomainEvent
    {
        string Codice { get; set; }
        string Descrizione { get; set; }
        decimal Spessore { get; set; }
    }
}