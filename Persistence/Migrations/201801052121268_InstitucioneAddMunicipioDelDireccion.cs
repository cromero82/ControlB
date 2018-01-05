namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstitucioneAddMunicipioDelDireccion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instituciones", "TmunicipioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Instituciones", "Nombre", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.Instituciones", "Nombre", unique: true, name: "UQ_institucion_codigo");
            DropColumn("dbo.Instituciones", "Direccion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Instituciones", "Direccion", c => c.String(nullable: false));
            DropIndex("dbo.Instituciones", "UQ_institucion_codigo");
            AlterColumn("dbo.Instituciones", "Nombre", c => c.String(nullable: false));
            DropColumn("dbo.Instituciones", "TmunicipioId");
        }
    }
}
