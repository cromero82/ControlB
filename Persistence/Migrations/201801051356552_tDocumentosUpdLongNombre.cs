namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tDocumentosUpdLongNombre : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tdocumentos", "UQ_tipodocumento");
            AlterColumn("dbo.Tdocumentos", "Nombre", c => c.String(nullable: false, maxLength: 80));
            CreateIndex("dbo.Tdocumentos", "Nombre", unique: true, name: "UQ_tipodocumento");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tdocumentos", "UQ_tipodocumento");
            AlterColumn("dbo.Tdocumentos", "Nombre", c => c.String(nullable: false, maxLength: 25));
            CreateIndex("dbo.Tdocumentos", "Nombre", unique: true, name: "UQ_tipodocumento");
        }
    }
}
