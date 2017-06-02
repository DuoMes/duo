using System.Windows;

namespace Duo.Clients.Wpf.Messaging
{
    class VisualizzaMessageBoxMessage
    {
        public string Message { get; set; }
        public string Caption { get; set; }
        public MessageBoxImage Icon { get; set; }
    }
}
