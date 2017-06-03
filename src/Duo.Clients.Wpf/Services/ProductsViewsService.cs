using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.Products;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Duo.Clients.Wpf.Services
{
    class ProductsViewsService : AbstractViewsService
    {
        Services.AppSettings settings;

        public ProductsViewsService(Services.AppSettings settings)
        {
            this.settings = settings;
        }

        public async Task<ProductView> GetById(Guid id)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}Products/{id}";

                return await this.GetAsync<ProductView>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<ProductView>> List(int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}Products/?i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<ProductView>>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<ProductView>> SearchByCode(String code, int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}Products/SearchByCode/?q={code}&i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<ProductView>>(apiClient, url);
            }
        }

    }
}
