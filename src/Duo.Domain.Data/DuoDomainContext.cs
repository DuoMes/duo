using Radical.CQRS.Data;
using System.Data.Entity;

namespace Duo.Domain.Data
{
    public class DuoDomainContext : DomainContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var bobineMadriState = modelBuilder.Entity<BobineMadri.BobinaMadre.BobinaMadreStato>()
                .ToTable("BobineMadri");
            modelBuilder.MapPropertiesOf<BobineMadri.BobinaMadre.BobinaMadreStato>();

            var trattamentiState = modelBuilder.Entity<Trattamenti.Trattamento.StatoTrattamento>()
                .ToTable("Trattamenti");
            modelBuilder.MapPropertiesOf<Trattamenti.Trattamento.StatoTrattamento>();

            var prodottiState = modelBuilder.Entity<Prodotti.Prodotto.StatoProdotto>()
                .ToTable("Prodotti");
            modelBuilder.MapPropertiesOf<Prodotti.Prodotto.StatoProdotto>();

            //modelBuilder.Entity<Address>()
            //        .ToTable("dbo.PersonAddresses");
            //modelBuilder.MapPropertiesOf<Address>();

            //modelBuilder.ComplexType<BornInfo>();

            //var person = modelBuilder.Entity<Person>();
            //person.HasMany(p => p.Addresses)
            //    .WithOptional()
            //    .HasForeignKey(a => a.PersonId)
            //    .WillCascadeOnDelete();

            //modelBuilder.MapPropertiesOf<Person>(

            //    propertiesToSkip: new[]
            //    {
            //        nameof(Person.Info),
            //        ReflectionHelper.GetPropertyName<Person>( p => p.Addresses )
            //    });

            //var companyState = modelBuilder.Entity<Company.State>()
            //    .ToTable("Companies");
            //modelBuilder.MapPropertiesOf<Company.State>();
        }
    }
}
