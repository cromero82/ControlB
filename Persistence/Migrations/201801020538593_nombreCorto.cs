namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nombreCorto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ShortName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ShortName");
        }
    }
}
