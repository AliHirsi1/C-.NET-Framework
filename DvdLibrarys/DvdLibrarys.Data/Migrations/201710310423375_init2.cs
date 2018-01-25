namespace DvdLibrarys.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dvds", "ReleaseYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dvds", "ReleaseYear", c => c.Int());
        }
    }
}
