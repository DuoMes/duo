using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.ExtrusionLines;
using Duo.Server.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace Duo.Server.Controllers
{
    public class ExtrusionLinesController : ApiController
    {
        private readonly ExtrusionLinesViewDataContext dataContext = new ExtrusionLinesViewDataContext();

        [HttpGet]
        public ExtrusionLineView Get(Guid id)
        {
            var query = dataContext.ExtrusionLinesView.SingleOrDefault(x => x.Id == id);
            return query;
        }

        [HttpGet]
        public PagedResultsViewModel<ExtrusionLineView> Get(int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                var totalCount = dataContext.ExtrusionLinesView.Count();

                var page = dataContext.ExtrusionLinesView
                    .OrderBy(x => x.Code)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<ExtrusionLineView>()
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
        public PagedResultsViewModel<ExtrusionLineView> SearchByCode(string code, int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                Expression<Func<ExtrusionLineView, bool>> query = bm => bm.Code.Contains(code);

                var totalCount = dataContext.ExtrusionLinesView
                    .Where(query)
                    .Count();

                var page = dataContext.ExtrusionLinesView
                    .Where(query)
                    .OrderBy(x => x.Code)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<ExtrusionLineView>()
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
