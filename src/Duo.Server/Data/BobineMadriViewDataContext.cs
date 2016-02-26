using Duo.Domain.ViewModels.BobineMadri;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Server.Data
{
    class BobineMadriViewDataContext: DbContext
    {
        readonly DbSet<BobinaMadreView> _bobinaMadreViewSet;

        public BobineMadriViewDataContext()
        {
            this._bobinaMadreViewSet = this.Set<BobinaMadreView>();
        }

        public IQueryable<BobinaMadreView> BobineMadriView
        {
            get { return this._bobinaMadreViewSet.AsNoTracking(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var bobinaMadre = modelBuilder.Entity<BobinaMadreView>();
            bobinaMadre.ToTable("dbo.BobineMadri");
        }
    }
}
