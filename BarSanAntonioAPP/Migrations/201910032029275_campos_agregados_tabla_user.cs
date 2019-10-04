namespace BarSanAntonioAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class campos_agregados_tabla_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.usuario", "nombre", c => c.String(nullable: false, maxLength: 24));
            AddColumn("dbo.usuario", "apellido", c => c.String(nullable: false, maxLength: 24));
            AddColumn("dbo.usuario", "fecha_nac", c => c.DateTime(nullable: false));
            AddColumn("dbo.usuario", "direccion", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.usuario", "direccion");
            DropColumn("dbo.usuario", "fecha_nac");
            DropColumn("dbo.usuario", "apellido");
            DropColumn("dbo.usuario", "nombre");
        }
    }
}
