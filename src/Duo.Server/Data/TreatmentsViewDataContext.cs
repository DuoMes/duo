using Duo.Domain.ViewModels.Treatments;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Duo.Server.Data
{
    class TreatmentsViewDataContext : DbContext
    {
        readonly DbSet<TreatmentView> _treatmentViewSet;

        public TreatmentsViewDataContext()
        {
            this._treatmentViewSet = this.Set<TreatmentView>();
        }

        public IQueryable<TreatmentView> TreatmentsView => this._treatmentViewSet.AsNoTracking();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var treatment = modelBuilder.Entity<TreatmentView>();
            treatment.ToTable("dbo.ProductsView");
        }
    }
}
