namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenInstituciones : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Instituciones", newName: "GenInstituciones");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.GenInstituciones", newName: "Instituciones");
        }
    }
}
