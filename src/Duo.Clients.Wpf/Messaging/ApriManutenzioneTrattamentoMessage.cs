using System;

namespace Duo.Clients.Wpf.Messaging
{
    class ApriManutenzioneTrattamentoMessage
    {
        public Guid Id { get; set; }

        private ApriManutenzioneTrattamentoMessage()
        {
        }

        public ApriManutenzioneTrattamentoMessage(Guid id)
        {
            this.Id = id;
        }

    }
}