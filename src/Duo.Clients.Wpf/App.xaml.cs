using System.Net;
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

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    //Task.Run(async () => 
        //    //{
        //    //    var f = new Foo { Text = "Hi, there!" };

        //    //    var baseAddress = ConfigurationManager.AppSettings[ "api/baseAddress" ];

        //    //    HttpClient client = new HttpClient();
        //    //    var content = new StringContent(JsonConvert.SerializeObject(f));
        //    //    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //    //    var url = baseAddress + "api/samples/echo";

        //    //    var response = await client.PostAsync(url, content);
        //    //    var result = await response.Content.ReadAsStringAsync();

        //    //    var x = result;
        //    //});
        //}
    }
}
