using Duo.Domain.ViewModels.Trattamenti;
using Duo.Server.Data;
using Duo.Domain.ViewModels;
using System;
using System.Linq;
using System.Web.Http;
using System.Linq.Expressions;

namespace Duo.Server.Controllers
{
    public class TrattamentiController : ApiController
    {
        private TrattamentiViewDataContext dataContext = new TrattamentiViewDataContext();

        [HttpGet]
        public TrattamentoView Get(Guid id)
        {
            var query = dataContext.TrattamentiView.Where(x => x.Id == id).SingleOrDefault();
            return query;
        }

        [HttpGet]
        public PagedResultsViewModel<TrattamentoView> Get(int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                var totalCount = dataContext.TrattamentiView.Count();

                var page = dataContext.TrattamentiView
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<TrattamentoView>()
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
        public PagedResultsViewModel<TrattamentoView> SearchByCode(String code, int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                Expression<Func<TrattamentoView, bool>> query = bm => bm.Codice.Contains(code);

                var totalCount = dataContext.TrattamentiView
                    .Where(query)
                    .Count();

                var page = dataContext.TrattamentiView
                    .Where(query)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<TrattamentoView>()
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
