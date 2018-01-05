namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenSedes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GenSedes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoDaneSede = c.String(),
                        NombreSede = c.String(nullable: false, maxLength: 200),
                        InstitucionId = c.Int(nullable: false),
                        RectorResponsable = c.String(),
                        Direccion = c.String(nullable: false),
                        Correo = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                        Estregistro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GenInstituciones", t => t.InstitucionId, cascadeDelete: true)
                .Index(t => t.NombreSede, unique: true, name: "UQ_sede")
                .Index(t => t.InstitucionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GenSedes", "InstitucionId", "dbo.GenInstituciones");
            DropIndex("dbo.GenSedes", new[] { "InstitucionId" });
            DropIndex("dbo.GenSedes", "UQ_sede");
            DropTable("dbo.GenSedes");
        }
    }
}
