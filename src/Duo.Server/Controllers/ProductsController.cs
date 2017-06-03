using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.Products;
using Duo.Server.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace Duo.Server.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly ProductsViewDataContext dataContext = new ProductsViewDataContext();

        [HttpGet]
        public ProductView Get(Guid id)
        {
            var query = dataContext.ProductsView.SingleOrDefault(x => x.Id == id);
            return query;
        }

        [HttpGet]
        public PagedResultsViewModel<ProductView> Get(int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                var totalCount = dataContext.ProductsView.Count();

                var page = dataContext.ProductsView
                    .OrderBy(x => x.Code)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<ProductView>()
                {
                    PageIndex = i,
                    PageSize = s,
                    Results = page,
                    TotalPages = totalCount.ToPagesCount(s),
                    TotalResults = totalCount
                };
            }
        }


        [HttpGet]
        public PagedResultsViewModel<ProductView> SearchByCode(string code, int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                Expression<Func<ProductView, bool>> query = bm => bm.Code.Contains(code);

                var totalCount = dataContext.ProductsView
                    .Where(query)
                    .Count();

                var page = dataContext.ProductsView
                    .Where(query)
                    .OrderBy(x => x.Code)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<ProductView>()
                {
                    PageIndex = i,
                    PageSize = s,
                    Results = page,
                    TotalPages = totalCount.ToPagesCount(s),
                    TotalResults = totalCount
                };
            }
        }

    }
}
