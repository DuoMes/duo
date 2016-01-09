using System.Data.Entity.Infrastructure;
using Radical.CQRS.Data;

namespace Duo.Domain.Data.Services
{
	public class DbContextFactory : IDbContextFactory<DomainContext>
	{
		public DomainContext Create()
		{
			var ctx = new DuoDomainContext();
			
			return ctx;
		}
	}
}
