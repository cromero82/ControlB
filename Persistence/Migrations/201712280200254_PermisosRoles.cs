namespace Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PermisosRoles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SegRolesPermisos", "PermisoId", "dbo.SegPermisos");
            DropPrimaryKey("dbo.SegPermisos");
            CreateTable(
                "dbo.SegRolesPermisos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PermisoId = c.Int(nullable: false),
                        RolId = c.String(maxLength: 128),
                        Estregistro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SegPermisos", t => t.PermisoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RolId)
                .Index(t => t.PermisoId)
                .Index(t => t.RolId);
            
            AlterColumn("dbo.SegPermisos", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.SegPermisos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SegRolesPermisos", "RolId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SegRolesPermisos", "PermisoId", "dbo.SegPermisos");
            DropIndex("dbo.SegRolesPermisos", new[] { "RolId" });
            DropIndex("dbo.SegRolesPermisos", new[] { "PermisoId" });
            DropPrimaryKey("dbo.SegPermisos");
            AlterColumn("dbo.SegPermisos", "Id", c => c.Long(nullable: false, identity: true));
            DropTable("dbo.SegRolesPermisos");
            AddPrimaryKey("dbo.SegPermisos", "Id");
            AddForeignKey("dbo.SegRolesPermisos", "PermisoId", "dbo.SegPermisos", "Id", cascadeDelete: true);
        }
    }
}
