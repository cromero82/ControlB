namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tniveles1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tniveles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        Nombre = c.String(nullable: false),
                        Estado = c.Int(nullable: false, defaultValue: 1),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tniveles");
        }
    }
}
