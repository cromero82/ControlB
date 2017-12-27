namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegPermisos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SegPermisos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(),
                        Sigla = c.String(),
                        Estado = c.Int(nullable: false),
                        Estregistro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SegPermisos");
        }
    }
}
