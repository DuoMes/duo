using Duo.Domain.ViewModels.BobineMadri;
using Duo.Server.Data;
using Duo.Domain.ViewModels;
using System;
using System.Linq;
using System.Web.Http;
using System.Linq.Expressions;

namespace Duo.Server.Controllers
{
    public class BobineMadriController : ApiController
    {
        private BobineMadriViewDataContext dataContext = new BobineMadriViewDataContext();

        [HttpGet]
        public BobinaMadreView Get(Guid id)
        {
            var query = dataContext.BobineMadriView.Where(x => x.Id == id).SingleOrDefault();
            return query;
        }

        [HttpGet]
        public PagedResultsViewModel<BobinaMadreView> Get(int i = 0, int s = 25)
        {
            using(var tx = dataContext.Database.BeginTransaction())
            {
                var totalCount = dataContext.BobineMadriView.Count();

                var page = dataContext.BobineMadriView
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<BobinaMadreView>()
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
        public PagedResultsViewModel<BobinaMadreView> SearchByCode(String code, int i = 0, int s = 25)
        {
            using(var tx = dataContext.Database.BeginTransaction())
            {
                Expression<Func<BobinaMadreView, bool>> query = bm => bm.Codice.Contains(code);

                var totalCount = dataContext.BobineMadriView
                    .Where(query)
                    .Count();

                var page = dataContext.BobineMadriView
                    .Where(query)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<BobinaMadreView>()
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
