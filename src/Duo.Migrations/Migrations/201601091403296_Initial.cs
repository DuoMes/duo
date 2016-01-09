namespace Duo.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DomainEventCommits",
                c => new
                    {
                        EventId = c.Guid(nullable: false),
                        EventType = c.String(),
                        EventBlob = c.String(),
                        AggregateId = c.Guid(nullable: false),
                        Version = c.Int(nullable: false),
                        PublishedOn = c.DateTimeOffset(nullable: false, precision: 7),
                        TransactionId = c.Guid(nullable: false),
                        StreamGroup = c.String(),
                        IsDispatched = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DomainEventCommits");
        }
    }
}
