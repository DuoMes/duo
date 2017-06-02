using Duo.Notifications;
using Microsoft.AspNet.SignalR;
using Radical.CQRS.Server;
using System;

namespace Duo.Server.Push.Interceptors
{
    class PushToSignalRCommandInterceptor : Jason.Handlers.ICommandInterceptor
	{
		readonly IOperationContextManager operationContextManager;

		public PushToSignalRCommandInterceptor( IOperationContextManager operationContextManager )
		{
			this.operationContextManager = operationContextManager;
		}

		public void OnException( object rawCommand, Exception exception )
		{
			var context = this.operationContextManager.GetCurrent();

			var ctx = GlobalHost.ConnectionManager.GetHubContext<ClientNotificastionsHub>();
			ctx.Clients.All.OnCommandFailed( new FailureNotification()
			{
                Command = rawCommand.GetType(),
                Error = exception,
				CorrelationId = context.CorrelationId
			} );
		}

		public void OnExecute( object rawCommand )
		{

		}

		public void OnExecuted( object rawCommand, object rawResult )
		{
			var context = this.operationContextManager.GetCurrent();

			var ctx = GlobalHost.ConnectionManager.GetHubContext<ClientNotificastionsHub>();
			ctx.Clients.All.OnCommandExecuted( new SuccessNotification()
			{
                Command = rawCommand.GetType(),
				Result = rawResult,
				CorrelationId = context.CorrelationId
			} );
		}
	}
}
