namespace Mibar7._9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiodenombresacampo : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.cabecera_factura", name: "persona_Id", newName: "cliente_Id");
            RenameColumn(table: "dbo.cabecera_factura", name: "persona1_Id", newName: "mesero_Id");
            RenameIndex(table: "dbo.cabecera_factura", name: "IX_persona_Id", newName: "IX_cliente_Id");
            RenameIndex(table: "dbo.cabecera_factura", name: "IX_persona1_Id", newName: "IX_mesero_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.cabecera_factura", name: "IX_mesero_Id", newName: "IX_persona1_Id");
            RenameIndex(table: "dbo.cabecera_factura", name: "IX_cliente_Id", newName: "IX_persona_Id");
            RenameColumn(table: "dbo.cabecera_factura", name: "mesero_Id", newName: "persona1_Id");
            RenameColumn(table: "dbo.cabecera_factura", name: "cliente_Id", newName: "persona_Id");
        }
    }
}
