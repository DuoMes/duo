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
    }
}
