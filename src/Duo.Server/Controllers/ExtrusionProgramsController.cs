using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.ExtrusionPrograms;
using Duo.Server.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;

namespace Duo.Server.Controllers
{
    public class ExtrusionProgramsController : ApiController
    {
        private readonly ExtrusionProgramsViewDataContext dataContext = new ExtrusionProgramsViewDataContext();

        [HttpGet]
        public ExtrusionProgramView Get(Guid id)
        {
            var query = dataContext.ExtrusionProgramsView.SingleOrDefault(x => x.Id == id);
            return query;
        }

        [HttpGet]
        public PagedResultsViewModel<ExtrusionProgramView> Get(int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                var totalCount = dataContext.ExtrusionProgramsView.Count();

                var page = dataContext.ExtrusionProgramsView
                    .OrderBy(x => x.Code)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<ExtrusionProgramView>()
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
        public PagedResultsViewModel<ExtrusionProgramView> SearchByCode(string code, int i = 0, int s = 25)
        {
            using (var tx = dataContext.Database.BeginTransaction())
            {
                Expression<Func<ExtrusionProgramView, bool>> query = bm => bm.Code.Contains(code);

                var totalCount = dataContext.ExtrusionProgramsView
                    .Where(query)
                    .Count();

                var page = dataContext.ExtrusionProgramsView
                    .Where(query)
                    .OrderBy(x => x.ExpectedProductionDate)
                    .Skip(i * s)
                    .Take(s)
                    .ToList();

                tx.Commit();

                return new PagedResultsViewModel<ExtrusionProgramView>()
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
