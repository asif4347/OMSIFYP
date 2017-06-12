namespace OMSIFYP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialAupdate3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PTMCalls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        Titile = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PTMCalls");
        }
    }
}
