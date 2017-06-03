using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.Treatments;
using Duo.Server.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace Duo.Server.Controllers
{
    public class TrattamentiController : ApiController
    {
        private readonly TreatmentsViewDataContext dataContext = new TreatmentsViewDataContext();

        [HttpGet]
        public TreatmentView Get(Guid id)
        {
            var query = dataContext.TreatmentsView.SingleOrDefault(x => x.Id == id);
            return query;
        }

        [HttpGet]
        public PagedResultsViewModel<TreatmentView> Get(int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                var totalCount = dataContext.TreatmentsView.Count();

                var page = dataContext.TreatmentsView
                    .OrderBy(x => x.Code)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<TreatmentView>()
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
        public PagedResultsViewModel<TreatmentView> SearchByCode(string code, int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                Expression<Func<TreatmentView, bool>> query = bm => bm.Code.Contains(code);

                var totalCount = dataContext.TreatmentsView
                    .Where(query)
                    .Count();

                var page = dataContext.TreatmentsView
                    .Where(query)
                    .OrderBy(x => x.Code)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<TreatmentView>()
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
