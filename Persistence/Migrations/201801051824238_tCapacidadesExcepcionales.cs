namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tCapacidadesExcepcionales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TcapExcepcionales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Estado = c.Int(nullable: false),
                        Numero = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TcapExcepcionales");
        }
    }
}
