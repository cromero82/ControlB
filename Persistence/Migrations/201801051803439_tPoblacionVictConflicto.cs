namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tPoblacionVictConflicto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TpVictimaConflictoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Estado = c.Int(nullable: false),
                        Numero = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Numero, unique: true, name: "UQ_victimaconfl_num");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.TpVictimaConflictoes", "UQ_victimaconfl_num");
            DropTable("dbo.TpVictimaConflictoes");
        }
    }
}
