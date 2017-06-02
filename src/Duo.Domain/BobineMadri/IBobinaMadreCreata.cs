using Radical.CQRS;

namespace Duo.Domain.BobineMadri
{
    public interface IBobinaMadreCreata : IDomainEvent
    {
        string Codice { get; set; }
        int Lunghezza { get; set; }
        int Fascia { get; set; }
    }
}
