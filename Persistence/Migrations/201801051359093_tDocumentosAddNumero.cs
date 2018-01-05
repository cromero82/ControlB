namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tDocumentosAddNumero : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tdocumentos", "Numero", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tdocumentos", "Numero");
        }
    }
}
