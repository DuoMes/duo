using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duo.Clients.Wpf.Services
{
    class AppSettings
    {
        public AppSettings()
        {
            this.ApiBaseAddress = ConfigurationManager.AppSettings[ "api/baseAddress" ];
            this.JasonBaseAddress = ConfigurationManager.AppSettings[ "jason/baseAddress" ];
            this.SignalRBaseAddress = ConfigurationManager.AppSettings[ "signalR/baseAddress" ];
        }

        public String ApiBaseAddress { get; }

        public String JasonBaseAddress { get; }

        public String SignalRBaseAddress { get; }
    }
}
