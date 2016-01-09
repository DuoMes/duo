using System;
using System.Web.Http;

namespace Duo.Server.Controllers
{
    public class SamplesController: ApiController
    {
        [HttpPost]
        public String Echo(dynamic id)
        {
            return $"Echo: {id.Text}";
        }
    }
}
