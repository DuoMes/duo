using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using Topics.Radical.Windows.Presentation.Boot;

namespace Duo.Clients.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ServicePointManager.DefaultConnectionLimit = 10;
            var boostrapper = new WindsorApplicationBootstrapper<Presentation.MainView>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Task.Run(async () =>
            {
                var cmd = new Duo.Messages.BobineMadri.Commands.CreaNuovaBobinaMadre()
                {
                    Codice = "12345",
                    Fascia = 8200,
                    Lunghezza = 22000
                };

                var jasonBaseAddress = ConfigurationManager.AppSettings["jason/baseAddress"];
                var client = new Radical.CQRS.Client.CommandClient(jasonBaseAddress);
                var cid = Guid.NewGuid().ToString();
                var result = await client.ExecuteAsync<Guid>(cid, cmd);


                var apiBaseAddress = ConfigurationManager.AppSettings["api/baseAddress"];

                HttpClient apiClient = new HttpClient();
                //var content = new StringContent(JsonConvert.SerializeObject(f));
                //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var url = apiBaseAddress + "bobinemadri";

                var response = await apiClient.GetAsync(url);
                var apiResult = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<IEnumerable<Duo.Domain.ViewModels.BobineMadri.BobinaMadreView>>(apiResult);

            });


        }
    }
}
