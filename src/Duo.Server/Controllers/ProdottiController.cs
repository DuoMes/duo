using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.Prodotti;
using Duo.Server.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace Duo.Server.Controllers
{
    public class ProdottiController : ApiController
    {
        private ProdottiViewDataContext dataContext = new ProdottiViewDataContext();

        [HttpGet]
        public ProdottoView Get(Guid id)
        {
            var query = dataContext.ProdottiView.Where(x => x.Id == id).SingleOrDefault();
            return query;
        }

        [HttpGet]
        public PagedResultsViewModel<ProdottoView> Get(int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                var totalCount = dataContext.ProdottiView.Count();

                var page = dataContext.ProdottiView
                    .OrderBy(x => x.Codice)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<ProdottoView>()
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
        public PagedResultsViewModel<ProdottoView> SearchByCode(String code, int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                Expression<Func<ProdottoView, bool>> query = bm => bm.Codice.Contains(code);

                var totalCount = dataContext.ProdottiView
                    .Where(query)
                    .Count();

                var page = dataContext.ProdottiView
                    .Where(query)
                    .OrderBy(x => x.Codice)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<ProdottoView>()
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
