namespace OMSIFYP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Section",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        section = c.String(),
                        CourseId = c.Int(nullable: false),
                        InstructorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.InstructorId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.InstructorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Section", "InstructorId", "dbo.Person");
            DropForeignKey("dbo.Section", "CourseId", "dbo.Course");
            DropIndex("dbo.Section", new[] { "InstructorId" });
            DropIndex("dbo.Section", new[] { "CourseId" });
            DropTable("dbo.Section");
        }
    }
}
