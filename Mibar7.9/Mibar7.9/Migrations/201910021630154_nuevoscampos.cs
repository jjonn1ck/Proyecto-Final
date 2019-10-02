namespace Mibar7._9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevoscampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "nombre", c => c.String(nullable: false, maxLength: 24));
            AddColumn("dbo.AspNetUsers", "apellido", c => c.String(nullable: false, maxLength: 24));
            AddColumn("dbo.AspNetUsers", "fecha_nac", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "direccion", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.AspNetUsers", "MyExtraProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MyExtraProperty", c => c.String());
            DropColumn("dbo.AspNetUsers", "direccion");
            DropColumn("dbo.AspNetUsers", "fecha_nac");
            DropColumn("dbo.AspNetUsers", "apellido");
            DropColumn("dbo.AspNetUsers", "nombre");
        }
    }
}
