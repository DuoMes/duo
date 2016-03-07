using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        protected async Task<T> PostAsync<T>(HttpClient apiClient, String url,HttpContent content )
        {
            var response = await apiClient.PostAsync(url,content);
            var apiResult = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<T>(apiResult);

            return data;
        }
    }
}
