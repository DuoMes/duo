using Duo.Domain.ViewModels.ExtrusionLines;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace Duo.Server.Data
{
    class ExtrusionLinesViewDataContext : DbContext
    {
        readonly DbSet<ExtrusionLineView> _extrusionLineViewSet;

        public ExtrusionLinesViewDataContext()
        {
            this._extrusionLineViewSet = this.Set<ExtrusionLineView>();
        }

        public IQueryable<ExtrusionLineView> ExtrusionLinesView => this._extrusionLineViewSet.AsNoTracking();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var product = modelBuilder.Entity<ExtrusionLineView>();
            product.ToTable("dbo.ExtrusionLinesView");
        }
    }
}
