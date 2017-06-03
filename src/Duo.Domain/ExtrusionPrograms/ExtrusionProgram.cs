using Radical.CQRS;
using System;

namespace Duo.Domain.ExtrusionPrograms
{
    public class ExtrusionProgram : Aggregate<ExtrusionProgram.ExtrusionProgramState>
    {
        public class ExtrusionProgramState : AggregateState
        {
            public string Code { get; set; }
            public Guid ExtrusionLineId { get; set; }
            public Guid ProductId { get; set; }
            public int Thickness { get; set; }
            public int Length { get; set; }
            public int Widht { get; set; }
            public Guid TreatmentId { get; set; }
            public int QuantityToBeProduced { get; set; }
            public int JumboRollToBeProduced { get; set; }
            public DateTime ExpectedProductionDate { get; set; }
        }

        public class Factory
        {
            public ExtrusionProgram CreateNew(string code, Guid extrusionLineId, Guid productId, int thickness, int length, int widht,
                Guid treatmentId, int quantityToBeProduced, int jumboRollToBeProduced, DateTime expectedProductionDate)
            {
                var state = new ExtrusionProgramState()
                {
                    Code = code,
                    ExtrusionLineId = extrusionLineId,
                    ProductId = productId,
                    Thickness = thickness,
                    Length = length,
                    Widht = widht,
                    TreatmentId = treatmentId,
                    QuantityToBeProduced = quantityToBeProduced,
                    JumboRollToBeProduced = jumboRollToBeProduced,
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
                e.Code = this.Data.Code; 
                e.ExtrusionLineId = this.Data.ExtrusionLineId;
                e.ProductId = this.Data.ProductId;
                e.Thickness = this.Data.Thickness;
                e.Length = this.Data.Length;
                e.Widht = this.Data.Widht;
                e.TreatmentId = this.Data.TreatmentId;
                e.QuantityToBeProduced = this.Data.QuantityToBeProduced;
                e.JumboRollToBeProduced = this.Data.JumboRollToBeProduced;
                e.ExpectedProductionDate = this.Data.ExpectedProductionDate;
            });
        }
    }
}
