using System;

namespace Duo.Domain.ViewModels.ExtrusionPrograms
{
    public class ExtrusionProgramView
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
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
}
