namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenCore2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenCores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SedeId = c.Int(nullable: false),
                        JornadaId = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Estregistro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tjornadas", t => t.JornadaId, cascadeDelete: true)
                .ForeignKey("dbo.GenSedes", t => t.SedeId, cascadeDelete: true)
                .Index(t => t.SedeId)
                .Index(t => t.JornadaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenCores", "SedeId", "dbo.GenSedes");
            DropForeignKey("dbo.GenCores", "JornadaId", "dbo.Tjornadas");
            DropIndex("dbo.GenCores", new[] { "JornadaId" });
            DropIndex("dbo.GenCores", new[] { "SedeId" });
            DropTable("dbo.GenCores");
        }
    }
}
