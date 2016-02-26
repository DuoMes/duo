using Duo.Messages.BobineMadri.Commands;
using Radical.CQRS.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topics.Radical.Windows.Presentation;

namespace Duo.Clients.Wpf.Presentation
{
    class MainViewModel : AbstractViewModel
    {
        Services.AppSettings settings;
        Services.BobineMadriViewsService bobineMadriViewsService;

        public MainViewModel(Services.AppSettings settings, Services.BobineMadriViewsService bobineMadriViewsService)
        {
            this.settings = settings;
            this.bobineMadriViewsService = bobineMadriViewsService;
        }

        public async void Test()
        {
            var commandClient = new CommandClient(this.settings.JasonBaseAddress);
            var result = await commandClient.ExecuteAsync<Guid>(Guid.NewGuid().ToString(), new CreaNuovaBobinaMadre()
            {
                Codice = "12345",
                Fascia = 8200,
                Lunghezza = 22000
            });

            var view = await this.bobineMadriViewsService.GetById(result);

        }
    }
}
