using Radical.CQRS;
using System;

namespace Duo.Domain.ExtrusionPrograms
{
    public interface IExtrusionProgramCreated : IDomainEvent
    {
        string Code { get; set; }
        Guid ExtrusionLineId { get; set; }
        Guid ProductId { get; set; }
        int Thickness { get; set; }
        int Length { get; set; }
        int Widht { get; set; }
        Guid TreatmentId { get; set; }
        int QuantityToBeProduced { get; set; }
        int JumboRollToBeProduced { get; set; }
        DateTime ExpectedProductionDate { get; set; }
    }
}
