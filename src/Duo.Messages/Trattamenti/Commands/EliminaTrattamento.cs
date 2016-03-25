using Radical.CQRS.Messages;
using System;

namespace Duo.Messages.Trattamenti.Commands
{
    public class EliminaTrattamento : IAggregateCommand
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }

        private EliminaTrattamento()
        {

        }

        public EliminaTrattamento(Guid id, int version)
        {
            this.Id = id;
            this.Version = version;
        }
    }
}
