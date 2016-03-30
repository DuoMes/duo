using Duo.Domain.ViewModels.Prodotti;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Duo.Server.Data
{
    class ProdottiViewDataContext : DbContext
    {
        readonly DbSet<ProdottoView> _prodottoViewSet;

        public ProdottiViewDataContext()
        {
            this._prodottoViewSet = this.Set<ProdottoView>();
        }

        public IQueryable<ProdottoView> ProdottiView
        {
            get { return this._prodottoViewSet.Where(x => x.IsCancellato == false).AsNoTracking(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var trattamento = modelBuilder.Entity<ProdottoView>();
            trattamento.ToTable("dbo.Prodotti");
        }
    }
}
