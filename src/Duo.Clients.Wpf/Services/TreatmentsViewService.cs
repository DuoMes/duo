using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.Treatments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Duo.Clients.Wpf.Services
{
    class TreatmentsViewsService : AbstractViewsService
    {
        Services.AppSettings settings;

        public TreatmentsViewsService(Services.AppSettings settings)
        {
            this.settings = settings;
        }

        public async Task<TreatmentView> GetById(Guid id)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}Treatments/{id}";

                return await this.GetAsync<TreatmentView>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<TreatmentView>> List(int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}Treatments/?i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<TreatmentView>>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<TreatmentView>> SearchByCode(String code, int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}Treatments/SearchByCode/?q={code}&i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<TreatmentView>>(apiClient, url);
            }
        }

    }
}
