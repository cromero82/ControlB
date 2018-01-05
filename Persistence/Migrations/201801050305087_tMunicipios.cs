namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tMunicipios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tmunicipios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartamentoId = c.Int(nullable: false),
                        Cod = c.String(maxLength: 5),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        Estado = c.Int(nullable: false),
                        Latitud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tdepartamentos", t => t.DepartamentoId, cascadeDelete: true)
                .Index(t => t.DepartamentoId)
                .Index(t => t.Cod, unique: true, name: "UQ_mun_cod");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tmunicipios", "DepartamentoId", "dbo.Tdepartamentos");
            DropIndex("dbo.Tmunicipios", "UQ_mun_cod");
            DropIndex("dbo.Tmunicipios", new[] { "DepartamentoId" });
            DropTable("dbo.Tmunicipios");
        }
    }
}
