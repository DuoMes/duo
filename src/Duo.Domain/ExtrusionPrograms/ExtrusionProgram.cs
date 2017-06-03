using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Radical.CQRS;

namespace Duo.Domain.ExtrusionPrograms
{
    class ExtrusionProgram : Aggregate<ExtrusionProgram.ExtrusionProgramState>
    {
        public class ExtrusionProgramState : AggregateState
        {
            public Guid ExtrusionLineId { get; set; }
            public Guid ProductId { get; set; }
            public int Length { get; set; }
            public int Widht { get; set; }
            public Guid TreatmentId { get; set; }
            public int QuantityToBeProduced { get; set; }
            public int JunboRollToBeProduced { get; set; }
            public DateTime ExpectedProductionDate { get; set; }
        }

        public class Factory
        {
            public ExtrusionProgram CreateNew(Guid extrusionLineId, Guid productId, int length, int widht, 
                Guid treatmentId, int quantityToBeProduced, int junboRollToBeProduced, DateTime expectedProductionDate)
            {
                var state = new ExtrusionProgramState()
                {
                    ExtrusionLineId = extrusionLineId,
                    ProductId = productId,
                    Length = length,
                    Widht = widht,
                    TreatmentId = treatmentId,
                    QuantityToBeProduced = quantityToBeProduced,
                    JunboRollToBeProduced = junboRollToBeProduced,
                    ExpectedProductionDate = expectedProductionDate
                };
                var aggregate = new ExtrusionProgram(state);
                aggregate.SetupCompleted();
                return aggregate;
            }
        }

        private ExtrusionProgram(ExtrusionProgram.ExtrusionProgramState state)
            : base(state)
        {
        }

        private void SetupCompleted()
        {
            this.RaiseEvent<IExtrusionProgramCreated>(e =>
            {
                e.ExtrusionLineId = this.Data.ExtrusionLineId;
                e.ProductId = this.Data.ProductId;
                e.Length = this.Data.Length;
                e.Widht = this.Data.Widht;
                e.TreatmentId = this.Data.TreatmentId;
                e.QuantityToBeProduced = this.Data.QuantityToBeProduced;
                e.JunboRollToBeProduced = this.Data.JunboRollToBeProduced;
                e.ExpectedProductionDate = this.Data.ExpectedProductionDate;
            });
        }
    }
}
