namespace OMSIFYP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Section", "CourseId", "dbo.Course");
            DropIndex("dbo.Section", new[] { "CourseId" });
            AddColumn("dbo.Section", "Course", c => c.String());
            DropColumn("dbo.Section", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Section", "CourseId", c => c.Int(nullable: false));
            DropColumn("dbo.Section", "Course");
            CreateIndex("dbo.Section", "CourseId");
            AddForeignKey("dbo.Section", "CourseId", "dbo.Course", "CourseID", cascadeDelete: true);
        }
    }
}
