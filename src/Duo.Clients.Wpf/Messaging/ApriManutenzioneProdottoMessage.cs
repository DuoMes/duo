using System;

namespace Duo.Clients.Wpf.Messaging
{
    class ApriManutenzioneProdottoMessage
    {
        public Guid Id { get; set; }

        private ApriManutenzioneProdottoMessage()
        {
        }

        public ApriManutenzioneProdottoMessage(Guid id)
        {
            this.Id = id;
        }

    }
}
