namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstadoInstituciones : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instituciones", "Estado", c => c.Int(nullable: false, defaultValue:1));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instituciones", "Estado");
        }
    }
}
