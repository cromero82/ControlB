namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tMetodologia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tmetodologias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 25),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nombre, unique: true, name: "UQ_nombre");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tmetodologias", "UQ_nombre");
            DropTable("dbo.Tmetodologias");
        }
    }
}
