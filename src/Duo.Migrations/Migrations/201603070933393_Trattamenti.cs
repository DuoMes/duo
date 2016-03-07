namespace Duo.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Trattamenti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trattamenti",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Codice = c.String(),
                        Descrizione = c.String(),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trattamenti");
        }
    }
}
