namespace Duo.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlagTrattamentoCancellato : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trattamenti", "IsCancellato", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trattamenti", "IsCancellato");
        }
    }
}
