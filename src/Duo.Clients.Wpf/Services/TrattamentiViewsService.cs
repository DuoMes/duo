using Duo.Domain.ViewModels;
using Duo.Domain.ViewModels.Trattamenti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Clients.Wpf.Services
{
    class TrattamentiViewsService : AbstractViewsService
    {
        Services.AppSettings settings;

        public TrattamentiViewsService(Services.AppSettings settings)
        {
            this.settings = settings;
        }

        public async Task<TrattamentoView> GetById(Guid id)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}trattamenti/{id}";

                return await this.GetAsync<TrattamentoView>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<TrattamentoView>> List(int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}trattamenti/?i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<TrattamentoView>>(apiClient, url);
            }
        }

        public async Task<PagedResultsViewModel<TrattamentoView>> SearchByCode(String code, int i = 0, int s = 25)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}trattamenti/SearchByCode/?q={code}&i={i}&s={s}";

                return await this.GetAsync<PagedResultsViewModel<TrattamentoView>>(apiClient, url);
            }
        }

        internal async void Salva(TrattamentoView trattamento)
        {
            using (var apiClient = new HttpClient())
            {
                var url = $"{this.settings.ApiBaseAddress}trattamenti/Save";

                var postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("Id", trattamento.Id.ToString()));
                postData.Add(new KeyValuePair<string, string>("Codice", trattamento.Codice));
                postData.Add(new KeyValuePair<string, string>("Descrizione", trattamento.Descrizione));

                await this.PostAsync<TrattamentoView>(apiClient, url, new FormUrlEncodedContent(postData));
            }
        }

    }
}
