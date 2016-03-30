using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.Prodotti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Clients.Wpf.Services
{
    class ProdottiViewsService : AbstractViewsService
    {
        Services.AppSettings settings;

        public ProdottiViewsService(Services.AppSettings settings)
        {
            this.settings = settings;
        }

        public async Task<ProdottoView> GetById(Guid id)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}trattamenti/{id}";

                return await this.GetAsync<ProdottoView>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<ProdottoView>> List(int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}prodotti/?i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<ProdottoView>>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<ProdottoView>> SearchByCode(String code, int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}prodotti/SearchByCode/?q={code}&i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<ProdottoView>>(apiClient, url);
            }
        }

    }
}
