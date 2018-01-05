namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstitucioneAddFkMunicipio : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Instituciones", "TmunicipioId");
            AddForeignKey("dbo.Instituciones", "TmunicipioId", "dbo.Tmunicipios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Instituciones", "TmunicipioId", "dbo.Tmunicipios");
            DropIndex("dbo.Instituciones", new[] { "TmunicipioId" });
        }
    }
}
