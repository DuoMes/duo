
using Radical.CQRS;

namespace Duo.Domain.Trattamenti
{
   public interface IAnagraficaTrattamentoModificata: IDomainEvent
    {
        string VecchioCodice { get; set; }
        string VecchiaDescrizione { get; set; }
        string NuovoCodice { get; set; }
        string NuovaDescrizione { get; set; }
    }
}
