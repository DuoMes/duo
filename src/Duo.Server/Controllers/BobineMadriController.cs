using Duo.Domain.ViewModels.BobineMadri;
using Duo.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Duo.Server.Controllers
{
    public class BobineMadriController: ApiController
    {
        private BobineMadriViewDataContext dataContext = new BobineMadriViewDataContext();

        [HttpGet]
        public IEnumerable<BobinaMadreView> Get()
        {
            var query = dataContext.BobineMadriView.ToList();
            return query;
        }

        [HttpGet]
        public BobinaMadreView Get(Guid id)
        {
            var query = dataContext.BobineMadriView.Where(x => x.Id == id).SingleOrDefault();
            return query;
        }

    }
}
