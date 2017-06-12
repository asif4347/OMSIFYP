namespace OMSIFYP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Section", "sec", c => c.String(nullable: false));
            AddColumn("dbo.Section", "cour", c => c.String(nullable: false));
            AddColumn("dbo.Section", "ins", c => c.String(nullable: false));
            DropColumn("dbo.Section", "section");
            DropColumn("dbo.Section", "Course");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Section", "Course", c => c.String());
            AddColumn("dbo.Section", "section", c => c.String());
            DropColumn("dbo.Section", "ins");
            DropColumn("dbo.Section", "cour");
            DropColumn("dbo.Section", "sec");
        }
    }
}
