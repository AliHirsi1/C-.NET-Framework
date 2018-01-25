namespace CarDealarship.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        ContactUsId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 55),
                        LastName = c.String(nullable: false, maxLength: 55),
                        Email = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 15),
                        Message = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ContactUsId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        Phone = c.String(nullable: false, maxLength: 30),
                        Street1 = c.String(nullable: false, maxLength: 100),
                        street2 = c.String(),
                        ZipCode = c.Int(nullable: false),
                        CityId_CityId = c.Int(nullable: false),
                        Sale_SaleId = c.Int(),
                        StateId_StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Cities", t => t.CityId_CityId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.Sale_SaleId)
                .ForeignKey("dbo.States", t => t.StateId_StateId, cascadeDelete: true)
                .Index(t => t.CityId_CityId)
                .Index(t => t.Sale_SaleId)
                .Index(t => t.StateId_StateId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        ActualPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VehicleId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        PurchaseType = c.String(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
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
                        Interior = c.String(nullable: false),
                        VehicleType = c.String(nullable: false),
                        SalesPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Year = c.Int(nullable: false),
                        Color = c.String(nullable: false),
                        Mileage = c.Int(nullable: false),
                        VinNumber = c.String(nullable: false),
                        MSRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Transmission = c.String(nullable: false),
                        IsFeatured = c.Boolean(nullable: false),
                        ImageFileName = c.String(),
                        Image = c.Binary(),
                        IsNew = c.Boolean(nullable: false),
                        Description = c.String(),
                        MakeId_MakeId = c.Int(),
                        ModelId_ModelId = c.Int(),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Makes", t => t.MakeId_MakeId)
                .ForeignKey("dbo.Models", t => t.ModelId_ModelId)
                .Index(t => t.MakeId_MakeId)
                .Index(t => t.ModelId_ModelId);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        MakeId = c.Int(nullable: false, identity: true),
                        MakeName = c.String(),
                        UserId = c.String(maxLength: 128),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MakeId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        ModelId = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        MakeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ModelId)
                .ForeignKey("dbo.Makes", t => t.MakeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.MakeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        StateAbbreviation = c.String(),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        DepartmentId_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId_DepartmentId)
                .Index(t => t.DepartmentId_DepartmentId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PurchaseType = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        SpecialId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.SpecialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Employees", "DepartmentId_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Customers", "StateId_StateId", "dbo.States");
            DropForeignKey("dbo.Customers", "Sale_SaleId", "dbo.Sales");
            DropForeignKey("dbo.Sales", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "ModelId_ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Models", "MakeId", "dbo.Makes");
            DropForeignKey("dbo.Vehicles", "MakeId_MakeId", "dbo.Makes");
            DropForeignKey("dbo.Makes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sales", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Customers", "CityId_CityId", "dbo.Cities");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Employees", new[] { "DepartmentId_DepartmentId" });
            DropIndex("dbo.Models", new[] { "UserId" });
            DropIndex("dbo.Models", new[] { "MakeId" });
            DropIndex("dbo.Makes", new[] { "UserId" });
            DropIndex("dbo.Vehicles", new[] { "ModelId_ModelId" });
            DropIndex("dbo.Vehicles", new[] { "MakeId_MakeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sales", new[] { "UserId" });
            DropIndex("dbo.Sales", new[] { "VehicleId" });
            DropIndex("dbo.Customers", new[] { "StateId_StateId" });
            DropIndex("dbo.Customers", new[] { "Sale_SaleId" });
            DropIndex("dbo.Customers", new[] { "CityId_CityId" });
            DropTable("dbo.Specials");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Purchases");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.States");
            DropTable("dbo.Models");
            DropTable("dbo.Makes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Sales");
            DropTable("dbo.Customers");
            DropTable("dbo.ContactUs");
            DropTable("dbo.Cities");
        }
    }
}
