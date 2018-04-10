namespace Safe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cadences",
                c => new
                    {
                        CadenceID = c.Int(nullable: false, identity: true),
                        Sequence = c.Int(nullable: false),
                        Program = c.Int(nullable: false),
                        Iteration = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CadenceID);
            
            CreateTable(
                "dbo.Capacities",
                c => new
                    {
                        CapacityID = c.Int(nullable: false, identity: true),
                        TeamID = c.String(),
                        TeamName = c.String(),
                        ProgramIncrement = c.String(),
                        Iteration1 = c.Int(nullable: false),
                        Iteration2 = c.Int(nullable: false),
                        Iteration3 = c.Int(nullable: false),
                        Iteration4 = c.Int(nullable: false),
                        Iteration5 = c.Int(nullable: false),
                        Iteration6 = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        CadenceID_CadenceID = c.Int(),
                    })
                .PrimaryKey(t => t.CapacityID)
                .ForeignKey("dbo.Cadences", t => t.CadenceID_CadenceID)
                .Index(t => t.CadenceID_CadenceID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        EmployeeNumber = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        ManagerID = c.Int(nullable: false),
                        Email = c.String(),
                        CostCenter = c.Int(nullable: false),
                        Status = c.String(),
                        PrimaryTeam = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        MembershipID = c.Int(nullable: false, identity: true),
                        Role = c.String(),
                        EmployeeID_EmployeeID = c.Int(),
                        TeamID_TeamID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MembershipID)
                .ForeignKey("dbo.Employees", t => t.EmployeeID_EmployeeID)
                .ForeignKey("dbo.Team_and_Trains", t => t.TeamID_TeamID)
                .Index(t => t.EmployeeID_EmployeeID)
                .Index(t => t.TeamID_TeamID);
            
            CreateTable(
                "dbo.Team_and_Trains",
                c => new
                    {
                        TeamID = c.String(nullable: false, maxLength: 128),
                        Type = c.String(),
                        Name = c.String(),
                        Parent = c.String(),
                    })
                .PrimaryKey(t => t.TeamID);
            
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
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Memberships", "TeamID_TeamID", "dbo.Team_and_Trains");
            DropForeignKey("dbo.Memberships", "EmployeeID_EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Capacities", "CadenceID_CadenceID", "dbo.Cadences");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Memberships", new[] { "TeamID_TeamID" });
            DropIndex("dbo.Memberships", new[] { "EmployeeID_EmployeeID" });
            DropIndex("dbo.Capacities", new[] { "CadenceID_CadenceID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Team_and_Trains");
            DropTable("dbo.Memberships");
            DropTable("dbo.Employees");
            DropTable("dbo.Capacities");
            DropTable("dbo.Cadences");
        }
    }
}
