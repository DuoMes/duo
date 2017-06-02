using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.BobineMadri;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Duo.Clients.Wpf.Services
{
    class BobineMadriViewsService: AbstractViewsService
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

                return await this.GetAsync<BobinaMadreView>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<BobinaMadreView>> List(int i = 0, int s = 25)
        {
            using(var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}bobinemadri/?i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<BobinaMadreView>>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<BobinaMadreView>> SearchByCode( String code, int i = 0, int s = 25)
        {
            using(var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}bobinemadri/SearchByCode/?q={code}&i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<BobinaMadreView>>(apiClient, url);
            }
        }
    }
}
