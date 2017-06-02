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
    }
}
