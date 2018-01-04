namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tjornadas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tjornadas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50),
                        Estado = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tjornadas");
        }
    }
}
