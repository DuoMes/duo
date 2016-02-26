using Duo.Domain.ViewModels.BobineMadri;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Clients.Wpf.Services
{
    class BobineMadriViewsService
    {
        Services.AppSettings settings;

        public BobineMadriViewsService(Services.AppSettings settings)
        {
            this.settings = settings;
        }

        public async Task<BobinaMadreView> GetById(Guid id)
        {
            using(var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}bobinemadri/{id}";

                var response = await apiClient.GetAsync(url);
                var apiResult = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<BobinaMadreView>(apiResult);

                return data;
            }
        }

        public async Task<IEnumerable<BobinaMadreView>> List()
        {
            using(var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}bobinemadri";

                var response = await apiClient.GetAsync(url);
                var apiResult = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<IEnumerable<BobinaMadreView>>(apiResult);

                return data;
            }
        }
    }
}
