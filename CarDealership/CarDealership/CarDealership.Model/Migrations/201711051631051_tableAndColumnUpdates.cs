namespace CarDealership.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableAndColumnUpdates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "SalesPersonId", "dbo.SalesPersons");
            DropForeignKey("dbo.Users", "UserRole_UserRoleId", "dbo.UserRoles");
            DropIndex("dbo.Purchases", new[] { "SalesPersonId" });
            DropIndex("dbo.Users", new[] { "UserRole_UserRoleId" });
            AddColumn("dbo.Purchases", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Role", c => c.String());
            AlterColumn("dbo.Vehicles", "Image", c => c.String());
            CreateIndex("dbo.Purchases", "UserId");
            AddForeignKey("dbo.Purchases", "UserId", "dbo.Users", "UserId", cascadeDelete: false);
            DropColumn("dbo.Purchases", "SalesPersonId");
            DropColumn("dbo.Users", "RoleId");
            DropColumn("dbo.Users", "ConfirmPassword");
            DropColumn("dbo.Users", "UserRole_UserRoleId");
            DropTable("dbo.SalesPersons");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            CreateTable(
                "dbo.SalesPersons",
                c => new
                    {
                        SalesPersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.SalesPersonId);
            
            AddColumn("dbo.Users", "UserRole_UserRoleId", c => c.Int());
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String());
            AddColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            AddColumn("dbo.Purchases", "SalesPersonId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Users");
            DropIndex("dbo.Purchases", new[] { "UserId" });
            AlterColumn("dbo.Vehicles", "Image", c => c.Binary());
            DropColumn("dbo.Users", "Role");
            DropColumn("dbo.Purchases", "UserId");
            CreateIndex("dbo.Users", "UserRole_UserRoleId");
            CreateIndex("dbo.Purchases", "SalesPersonId");
            AddForeignKey("dbo.Users", "UserRole_UserRoleId", "dbo.UserRoles", "UserRoleId");
            AddForeignKey("dbo.Purchases", "SalesPersonId", "dbo.SalesPersons", "SalesPersonId", cascadeDelete: false);
        }
    }
}
