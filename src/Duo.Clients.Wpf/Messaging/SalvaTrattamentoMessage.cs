using Duo.Domain.ViewModels.Trattamenti;

namespace Duo.Clients.Wpf.Messaging
{
    class SalvaTrattamentoMessage
    {
        public bool Cancel { get; internal set; }
        public TrattamentoView Trattamento { get; internal set; }
    }
}
