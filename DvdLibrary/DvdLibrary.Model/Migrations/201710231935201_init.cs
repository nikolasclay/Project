namespace DvdLibrary.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dvds",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseYear = c.Int(nullable: false),
                        DirectorName = c.String(),
                        RatingType = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.DvdId);
        }
        
        public override void Down()
        {
            DropTable("dbo.Dvds");
        }
    }
}
