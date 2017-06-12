namespace OMSIFYP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "userId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "userId");
        }
    }
}
