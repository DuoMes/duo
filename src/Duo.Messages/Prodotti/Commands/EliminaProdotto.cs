using Radical.CQRS.Messages;
using System;

namespace Duo.Messages.Prodotti.Commands
{
    public class EliminaProdotto : IAggregateCommand
    {
        public Guid Id { get; private set; }
        public int Version { get; private set; }

        private EliminaProdotto()
        {

        }

        public EliminaProdotto(Guid id, int version)
        {
            this.Id = id;
            this.Version = version;
        }
    }
}
