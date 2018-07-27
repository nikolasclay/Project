namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apps",
                c => new
                    {
                        AppId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CurrentPrice = c.Double(nullable: false),
                        SuggestedPrice = c.Double(nullable: false),
                        CsvUpload = c.String(),
                    })
                .PrimaryKey(t => t.AppId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Apps");
        }
    }
}
