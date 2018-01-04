namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tespecialidades_Tcaracter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tcaracters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Estado = c.Int(nullable: false),
                        Numero = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tespecialidades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Estado = c.Int(nullable: false),
                        Numero = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tespecialidades");
            DropTable("dbo.Tcaracters");
        }
    }
}
