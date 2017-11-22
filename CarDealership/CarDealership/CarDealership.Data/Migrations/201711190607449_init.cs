namespace CarDealership.Data.Migrations
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
                        UserId = c.String(maxLength: 128),
                        CustomerId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseTypes", t => t.PurchaseTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.PurchaseTypeId)
                .Index(t => t.VehicleId)
                .Index(t => t.UserId)
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
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Role = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                        Image = c.String(),
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
                        UserId = c.String(maxLength: 128),
                        Added = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleModelId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.VehicleMakes", t => t.VehicleMakeId, cascadeDelete: true)
                .Index(t => t.VehicleMakeId)
                .Index(t => t.UserId);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Purchases", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VehicleModelId", "dbo.VehicleModels");
            DropForeignKey("dbo.VehicleModels", "VehicleMakeId", "dbo.VehicleMakes");
            DropForeignKey("dbo.VehicleModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Vehicles", "InteriorColorId", "dbo.InteriorColors");
            DropForeignKey("dbo.Vehicles", "ExteriorColorId", "dbo.ExteriorColors");
            DropForeignKey("dbo.Vehicles", "BodyStyleId", "dbo.BodyStyles");
            DropForeignKey("dbo.Purchases", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Purchases", "PurchaseTypeId", "dbo.PurchaseTypes");
            DropForeignKey("dbo.Purchases", "CustomerId", "dbo.Customers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.VehicleModels", new[] { "UserId" });
            DropIndex("dbo.VehicleModels", new[] { "VehicleMakeId" });
            DropIndex("dbo.Vehicles", new[] { "InteriorColorId" });
            DropIndex("dbo.Vehicles", new[] { "ExteriorColorId" });
            DropIndex("dbo.Vehicles", new[] { "BodyStyleId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleModelId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Purchases", new[] { "CustomerId" });
            DropIndex("dbo.Purchases", new[] { "UserId" });
            DropIndex("dbo.Purchases", new[] { "VehicleId" });
            DropIndex("dbo.Purchases", new[] { "PurchaseTypeId" });
            DropTable("dbo.Specials");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.VehicleMakes");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.Vehicles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
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
