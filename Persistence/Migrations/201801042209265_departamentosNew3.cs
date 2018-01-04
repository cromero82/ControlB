namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departamentosNew3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tdepartamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cod = c.String(maxLength: 5),
                        Nombre = c.String(nullable: false, maxLength: 80),
                        Estado = c.Int(nullable: false),
                        Latitud = c.Double(nullable: false),
                        Longitud = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Cod, unique: true, name: "UQ_dep_cod");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tdepartamentos", "UQ_dep_cod");
            DropTable("dbo.Tdepartamentos");
        }
    }
}
