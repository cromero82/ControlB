namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumeroTniveles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tniveles", "Numero", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tniveles", "Numero");
        }
    }
}
