using Duo.Domain.ViewModels.Products;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace Duo.Server.Data
{
    class ProductsViewDataContext : DbContext
    {
        readonly DbSet<ProductView> _productViewSet;

        public ProductsViewDataContext()
        {
            this._productViewSet = this.Set<ProductView>();
        }

        public IQueryable<ProductView> ProductsView => this._productViewSet.AsNoTracking();

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var product = modelBuilder.Entity<ProductView>();
            product.ToTable("dbo.ProductsView");
        }
    }
}
