namespace Mibar7._9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetIdentity_RenameTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "usuario");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "claims-usuario");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "logins-usuario");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "usuario-roles");
            RenameTable(name: "dbo.AspNetRoles", newName: "rol");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.rol", newName: "AspNetRoles");
            RenameTable(name: "dbo.usuario-roles", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.logins-usuario", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.claims-usuario", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.usuario", newName: "AspNetUsers");
        }
    }
}
