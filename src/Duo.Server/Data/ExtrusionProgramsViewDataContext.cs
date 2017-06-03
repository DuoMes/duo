using Duo.Domain.ViewModels.ExtrusionPrograms;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace Duo.Server.Data
{
    class ExtrusionProgramsViewDataContext : DbContext
    {
        readonly DbSet<ExtrusionProgramView> _extrusionProgramViewSet;

        public ExtrusionProgramsViewDataContext()
        {
            this._extrusionProgramViewSet = this.Set<ExtrusionProgramView>();
        }

        public IQueryable<ExtrusionProgramView> ExtrusionProgramsView => this._extrusionProgramViewSet.AsNoTracking();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var product = modelBuilder.Entity<ExtrusionProgramView>();
            product.ToTable("dbo.ExtrusionProgramsView");
        }
    }
}
