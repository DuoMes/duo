using System;

namespace Duo.Domain.ViewModels.Treatments
{
    public class TreatmentView
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }
}
