namespace OMSIFYP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollment", "test1", c => c.Int(nullable: false));
            AddColumn("dbo.Enrollment", "test2", c => c.Int(nullable: false));
            AddColumn("dbo.Enrollment", "final", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollment", "final");
            DropColumn("dbo.Enrollment", "test2");
            DropColumn("dbo.Enrollment", "test1");
        }
    }
}
