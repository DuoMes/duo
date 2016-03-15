﻿using System;
using Duo.Domain.Trattamenti;
using Duo.Messages.Trattamenti.Commands;
using Jason.Handlers.Commands;
using Radical.CQRS;
using Radical.CQRS.Handlers;

namespace Duo.Domain.Handlers.Trattamenti
{
    class CambiaCodiceTrattamentoHandler : AbstractAggregateCommandHandler<Duo.Domain.Trattamenti.Trattamento, Duo.Messages.Trattamenti.Commands.CambiaCodiceTrattamento>
    {
        public override void Manipulate(Trattamento aggregate, CambiaCodiceTrattamento command)
        {
            aggregate.CambiaCodice(command.Codice);
        }

    }
}
