using Radical.CQRS.Data;
using System.Data.Entity.Infrastructure;

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
