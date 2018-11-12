namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NickName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Victory = c.Int(nullable: false),
                        Draw = c.Int(nullable: false),
                        Losing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Players");
        }
    }
}
