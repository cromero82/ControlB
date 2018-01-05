namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tDocumentos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tdocumentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 25),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nombre, unique: true, name: "UQ_tipodocumento");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tdocumentos", "UQ_tipodocumento");
            DropTable("dbo.Tdocumentos");
        }
    }
}
