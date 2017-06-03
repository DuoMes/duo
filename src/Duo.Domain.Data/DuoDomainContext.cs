using Radical.CQRS.Data;
using System.Data.Entity;

namespace Duo.Domain.Data
{
    public class DuoDomainContext : DomainContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var bobineMadriState = modelBuilder.Entity<ExtrusionPrograms.ExtrusionProgram.ExtrusionProgramState>()
                .ToTable("ExtrusionPrograms");
            modelBuilder.MapPropertiesOf<ExtrusionPrograms.ExtrusionProgram.ExtrusionProgramState>();
        }
    }
}
