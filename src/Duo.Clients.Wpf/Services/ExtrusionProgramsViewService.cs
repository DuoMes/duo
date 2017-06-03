using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.ExtrusionPrograms;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Duo.Clients.Wpf.Services
{
    class ExtrusionProgramsViewsService : AbstractViewsService
    {
        Services.AppSettings settings;

        public ExtrusionProgramsViewsService(Services.AppSettings settings)
        {
            this.settings = settings;
        }

        public async Task<ExtrusionProgramView> GetById(Guid id)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}ExtrusionPrograms/{id}";

                return await this.GetAsync<ExtrusionProgramView>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<ExtrusionProgramView>> List(int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}ExtrusionPrograms/?i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<ExtrusionProgramView>>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<ExtrusionProgramView>> SearchByCode(String code, int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}ExtrusionPrograms/SearchByCode/?q={code}&i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<ExtrusionProgramView>>(apiClient, url);
            }
        }

    }
}
