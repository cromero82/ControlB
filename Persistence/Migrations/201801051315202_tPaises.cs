namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tPaises : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tpaises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 4),
                        Nombre = c.String(nullable: false),
                        Estado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "UQ_pais_codigo");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tpaises", "UQ_pais_codigo");
            DropTable("dbo.Tpaises");
        }
    }
}
