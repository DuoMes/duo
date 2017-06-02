using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Duo.Clients.Wpf.Services
{
    abstract class AbstractViewsService
    {
        protected async Task<T> GetAsync<T>( HttpClient apiClient, String url )
        {
            var response = await apiClient.GetAsync(url);
            var apiResult = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<T>(apiResult);

            return data;
        }

    }
}
