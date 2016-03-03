namespace Duo.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BobineMadri : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BobineMadri",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Codice = c.String(),
                        Lunghezza = c.Int(nullable: false),
                        Fascia = c.Int(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BobineMadri");
        }
    }
}
