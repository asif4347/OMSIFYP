namespace OMSIFYP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialAupdate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminContact",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Titile = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminContact");
        }
    }
}
