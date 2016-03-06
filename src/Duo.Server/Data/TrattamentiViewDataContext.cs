using Duo.Domain.ViewModels.Trattamenti;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Duo.Server.Data
{
    class TrattamentiViewDataContext : DbContext
    {
        readonly DbSet<TrattamentoView> _trattamentoViewSet;

        public TrattamentiViewDataContext()
        {
            this._trattamentoViewSet = this.Set<TrattamentoView>();
        }

        public IQueryable<TrattamentoView> TrattamentiView
        {
            get { return this._trattamentoViewSet.AsNoTracking(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var trattamento = modelBuilder.Entity<TrattamentoView>();
            trattamento.ToTable("dbo.Trattamenti");
        }
    }
}
