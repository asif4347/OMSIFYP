namespace OMSIFYP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Section", "InstructorId", "dbo.Person");
            DropIndex("dbo.Section", new[] { "InstructorId" });
            DropColumn("dbo.Section", "InstructorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Section", "InstructorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Section", "InstructorId");
            AddForeignKey("dbo.Section", "InstructorId", "dbo.Person", "ID", cascadeDelete: true);
        }
    }
}
