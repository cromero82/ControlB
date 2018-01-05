namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tEtnias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tetnias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Estado = c.Int(nullable: false),
                        Numero = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Numero, unique: true, name: "UQ_etnia");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tetnias", "UQ_etnia");
            DropTable("dbo.Tetnias");
        }
    }
}
