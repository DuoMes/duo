using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radical.CQRS;

namespace Duo.Domain.ExtrusionPrograms
{
    public interface IExtrusionProgramCreated : IDomainEvent
    {
        Guid ExtrusionLineId { get; set; }
        Guid ProductId { get; set; }
        int Length { get; set; }
        int Widht { get; set; }
        Guid TreatmentId { get; set; }
        int QuantityToBeProduced { get; set; }
        int JunboRollToBeProduced { get; set; }
        DateTime ExpectedProductionDate { get; set; }
    }
}
