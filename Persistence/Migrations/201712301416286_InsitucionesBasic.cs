namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsitucionesBasic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instituciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CodigoDane = c.String(),
                        Nombre = c.String(nullable: false),
                        Rector = c.String(),
                        Direccion = c.String(nullable: false),
                        Correo = c.String(nullable: false),
                        Telefono = c.String(nullable: false),
                        FechaFundacion = c.DateTime(nullable: false),
                        Estregistro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Instituciones");
        }
    }
}
