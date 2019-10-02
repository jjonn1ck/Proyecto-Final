namespace Mibar7._9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boraradtablausuario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.cabecera_factura", "id_cliente", "dbo.persona");
            DropForeignKey("dbo.cabecera_factura", "id_mozo", "dbo.persona");
            DropIndex("dbo.cabecera_factura", new[] { "id_cliente" });
            DropIndex("dbo.cabecera_factura", new[] { "id_mozo" });
            AddColumn("dbo.cabecera_factura", "persona_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.cabecera_factura", "persona1_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.cabecera_factura", "persona_Id");
            CreateIndex("dbo.cabecera_factura", "persona1_Id");
            AddForeignKey("dbo.cabecera_factura", "persona_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.cabecera_factura", "persona1_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.persona");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.persona",
                c => new
                    {
                        id_persona = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 24, unicode: false),
                        apellido = c.String(nullable: false, maxLength: 24, unicode: false),
                        fecha_nac = c.DateTime(nullable: false),
                        telefono = c.String(nullable: false, maxLength: 15, unicode: false),
                        email = c.String(nullable: false, maxLength: 48, unicode: false),
                        direccion = c.String(nullable: false, maxLength: 100, unicode: false),
                        rol = c.String(maxLength: 24, unicode: false),
                        nick = c.String(nullable: false, maxLength: 24, unicode: false),
                        pass = c.String(nullable: false, maxLength: 24, unicode: false),
                    })
                .PrimaryKey(t => t.id_persona);
            
            DropForeignKey("dbo.cabecera_factura", "persona1_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.cabecera_factura", "persona_Id", "dbo.AspNetUsers");
            DropIndex("dbo.cabecera_factura", new[] { "persona1_Id" });
            DropIndex("dbo.cabecera_factura", new[] { "persona_Id" });
            DropColumn("dbo.cabecera_factura", "persona1_Id");
            DropColumn("dbo.cabecera_factura", "persona_Id");
            CreateIndex("dbo.cabecera_factura", "id_mozo");
            CreateIndex("dbo.cabecera_factura", "id_cliente");
            AddForeignKey("dbo.cabecera_factura", "id_mozo", "dbo.persona", "id_persona");
            AddForeignKey("dbo.cabecera_factura", "id_cliente", "dbo.persona", "id_persona");
        }
    }
}
