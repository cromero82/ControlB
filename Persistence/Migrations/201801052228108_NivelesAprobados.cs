namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NivelesAprobados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenNivelesAprobados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstitucionId = c.Int(nullable: false),
                        NivelId = c.Int(nullable: false),
                        Estado = c.Int(nullable: false),
                        Estregistro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenInstituciones", t => t.InstitucionId, cascadeDelete: true)
                .ForeignKey("dbo.Tniveles", t => t.NivelId, cascadeDelete: true)
                .Index(t => t.InstitucionId, unique: true, name: "Ix_InstitucionId")
                .Index(t => t.NivelId, unique: true, name: "Ix_NivelId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenNivelesAprobados", "NivelId", "dbo.Tniveles");
            DropForeignKey("dbo.GenNivelesAprobados", "InstitucionId", "dbo.GenInstituciones");
            DropIndex("dbo.GenNivelesAprobados", "Ix_NivelId");
            DropIndex("dbo.GenNivelesAprobados", "Ix_InstitucionId");
            DropTable("dbo.GenNivelesAprobados");
        }
    }
}
