namespace OMSIFYP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialAupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuperAdminContact",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Titile = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Person", "CNIC", c => c.Int(nullable: false));
            AddColumn("dbo.Person", "Adddress", c => c.String());
            AddColumn("dbo.Person", "imgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "imgUrl");
            DropColumn("dbo.Person", "Adddress");
            DropColumn("dbo.Person", "CNIC");
            DropTable("dbo.SuperAdminContact");
        }
    }
}
