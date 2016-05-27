using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
