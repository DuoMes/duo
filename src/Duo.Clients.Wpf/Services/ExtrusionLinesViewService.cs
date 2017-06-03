using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.ExtrusionLines;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Duo.Clients.Wpf.Services
{
    class ExtrusionLinesViewsService : AbstractViewsService
    {
        Services.AppSettings settings;

        public ExtrusionLinesViewsService(Services.AppSettings settings)
        {
            this.settings = settings;
        }

        public async Task<ExtrusionLineView> GetById(Guid id)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}ExtrusionLines/{id}";

                return await this.GetAsync<ExtrusionLineView>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<ExtrusionLineView>> List(int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}ExtrusionLines/?i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<ExtrusionLineView>>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<ExtrusionLineView>> SearchByCode(String code, int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}ExtrusionLines/SearchByCode/?q={code}&i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<ExtrusionLineView>>(apiClient, url);
            }
        }

    }
}
