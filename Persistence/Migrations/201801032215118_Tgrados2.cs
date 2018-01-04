namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tgrados2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tgrados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NivelId = c.Int(nullable: false),
                        Codigo = c.String(),
                        Nombre = c.String(),
                        Estado = c.Int(nullable: false, defaultValue: 1),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tniveles", t => t.NivelId, cascadeDelete: true)
                .Index(t => t.NivelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tgrados", "NivelId", "dbo.Tniveles");
            DropIndex("dbo.Tgrados", new[] { "NivelId" });
            DropTable("dbo.Tgrados");
        }
    }
}
