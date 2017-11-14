namespace CarDealership.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyStyles",
                c => new
                    {
                        BodyStyleId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.BodyStyleId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.ExteriorColors",
                c => new
                    {
                        ExteriorColorId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ExteriorColorId);
            
            CreateTable(
                "dbo.InteriorColors",
                c => new
                    {
                        InteriorColorId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.InteriorColorId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchaseTypeId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        SalesPersonId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseTypes", t => t.PurchaseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.SalesPersons", t => t.SalesPersonId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.PurchaseTypeId)
                .Index(t => t.VehicleId)
                .Index(t => t.SalesPersonId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.PurchaseTypes",
                c => new
                    {
                        PurchaseTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseTypeId);
            
            CreateTable(
                "dbo.SalesPersons",
                c => new
                    {
                        SalesPersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.SalesPersonId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        VehicleMakeId = c.Int(nullable: false),
                        VehicleModelId = c.Int(nullable: false),
                        BodyStyleId = c.Int(nullable: false),
                        ExteriorColorId = c.Int(nullable: false),
                        InteriorColorId = c.Int(nullable: false),
                        VIN = c.String(),
                        New = c.Boolean(nullable: false),
                        Year = c.Int(nullable: false),
                        MSRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mileage = c.Int(nullable: false),
                        Feature = c.Boolean(nullable: false),
                        Description = c.String(),
                        Image = c.Binary(),
                        Transmission = c.String(),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.BodyStyles", t => t.BodyStyleId, cascadeDelete: true)
                .ForeignKey("dbo.ExteriorColors", t => t.ExteriorColorId, cascadeDelete: true)
                .ForeignKey("dbo.InteriorColors", t => t.InteriorColorId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleModels", t => t.VehicleModelId, cascadeDelete: true)
                .Index(t => t.VehicleModelId)
                .Index(t => t.BodyStyleId)
                .Index(t => t.ExteriorColorId)
                .Index(t => t.InteriorColorId);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        VehicleModelId = c.Int(nullable: false, identity: true),
                        VehicleMakeId = c.Int(nullable: false),
                        ModelType = c.String(),
                        UserId = c.Int(nullable: false),
                        Added = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleModelId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleMakes", t => t.VehicleMakeId, cascadeDelete: true)
                .Index(t => t.VehicleMakeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        ConfirmPassword = c.String(),
                        UserRole_UserRoleId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_UserRoleId)
                .Index(t => t.UserRole_UserRoleId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            CreateTable(
                "dbo.VehicleMakes",
                c => new
                    {
                        VehicleMakeId = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Added = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleMakeId);
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        SpecialId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.SpecialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes");
            DropForeignKey("dbo.VehicleModels", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserRole_UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.Vehicles", "InteriorColorId", "dbo.InteriorColors");
            DropForeignKey("dbo.Vehicles", "ExteriorColorId", "dbo.ExteriorColors");
            DropForeignKey("dbo.Vehicles", "BodyStyleId", "dbo.BodyStyles");
            DropForeignKey("dbo.Purchases", "SalesPersonId", "dbo.SalesPersons");
            DropForeignKey("dbo.Purchases", "PurchaseTypeId", "dbo.PurchaseTypes");
            DropForeignKey("dbo.Purchases", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Users", new[] { "UserRole_UserRoleId" });
            DropIndex("dbo.VehicleModels", new[] { "UserId" });
            DropIndex("dbo.VehicleModels", new[] { "VehicleMakeId" });
            DropIndex("dbo.Vehicles", new[] { "InteriorColorId" });
            DropIndex("dbo.Vehicles", new[] { "ExteriorColorId" });
            DropIndex("dbo.Vehicles", new[] { "BodyStyleId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleModelId" });
            DropIndex("dbo.Purchases", new[] { "CustomerId" });
            DropIndex("dbo.Purchases", new[] { "SalesPersonId" });
            DropIndex("dbo.Purchases", new[] { "VehicleId" });
            DropIndex("dbo.Purchases", new[] { "PurchaseTypeId" });
            DropTable("dbo.Specials");
            DropTable("dbo.VehicleMakes");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.Vehicles");
            DropTable("dbo.SalesPersons");
            DropTable("dbo.PurchaseTypes");
            DropTable("dbo.Purchases");
            DropTable("dbo.InteriorColors");
            DropTable("dbo.ExteriorColors");
            DropTable("dbo.Customers");
            DropTable("dbo.Contacts");
            DropTable("dbo.BodyStyles");
        }
    }
}
