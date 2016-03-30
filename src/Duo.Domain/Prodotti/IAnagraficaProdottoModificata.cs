using Radical.CQRS;

namespace Duo.Domain.Prodotti
{
    public interface IAnagraficaProdottoModificata: IDomainEvent
    {
        string NuovaDescrizione { get; set; }
        string NuovoCodice { get; set; }
        decimal NuovoSpessore { get; set; }
        string VecchiaDescrizione { get; set; }
        string VecchioCodice { get; set; }
        decimal VecchioSpessore { get; set; }
    }
}