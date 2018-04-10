namespace Safe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cadences", "ProgramIncrement", c => c.String());
            DropColumn("dbo.Cadences", "Program");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cadences", "Program", c => c.Int(nullable: false));
            DropColumn("dbo.Cadences", "ProgramIncrement");
        }
    }
}
