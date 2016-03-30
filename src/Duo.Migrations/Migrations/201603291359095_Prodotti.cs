namespace Duo.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prodotti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Prodotti",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Codice = c.String(),
                        Descrizione = c.String(),
                        Spessore = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsCancellato = c.Boolean(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Prodotti");
        }
    }
}
