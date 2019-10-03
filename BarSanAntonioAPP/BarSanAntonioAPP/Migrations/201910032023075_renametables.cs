namespace BarSanAntonioAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renametables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetRoles", newName: "rol");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "usuario-rol");
            RenameTable(name: "dbo.AspNetUsers", newName: "usuario");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "usuario-claim");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "usuario-login");
            CreateTable(
                "dbo.agrup_plato_combinado",
                c => new
                    {
                        id_agrup_plato_combinado = c.Int(nullable: false, identity: true),
                        descripcion = c.String(maxLength: 40),
                        precio = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.id_agrup_plato_combinado);
            
            CreateTable(
                "dbo.plato_combinado",
                c => new
                    {
                        id_plato_combinado = c.Int(nullable: false, identity: true),
                        id_plato = c.Int(),
                        id_guarnicion = c.Int(),
                        id_agrup_plato_combinado = c.Int(),
                    })
                .PrimaryKey(t => t.id_plato_combinado)
                .ForeignKey("dbo.agrup_plato_combinado", t => t.id_agrup_plato_combinado)
                .ForeignKey("dbo.guarnicion", t => t.id_guarnicion)
                .ForeignKey("dbo.plato", t => t.id_plato)
                .Index(t => t.id_plato)
                .Index(t => t.id_guarnicion)
                .Index(t => t.id_agrup_plato_combinado);
            
            CreateTable(
                "dbo.detalle_factura",
                c => new
                    {
                        id_det_factura = c.Int(nullable: false, identity: true),
                        id_cab_factura = c.Int(nullable: false),
                        id_plato = c.Int(),
                        id_guarnicion = c.Int(),
                        id_postre = c.Int(),
                        id_bebida = c.Int(),
                        id_plato_combinado = c.Int(),
                        estado = c.String(maxLength: 24),
                        precio = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.id_det_factura)
                .ForeignKey("dbo.bebida", t => t.id_bebida)
                .ForeignKey("dbo.cabecera_factura", t => t.id_cab_factura, cascadeDelete: true)
                .ForeignKey("dbo.guarnicion", t => t.id_guarnicion)
                .ForeignKey("dbo.plato", t => t.id_plato)
                .ForeignKey("dbo.plato_combinado", t => t.id_plato_combinado)
                .ForeignKey("dbo.postre", t => t.id_postre)
                .Index(t => t.id_cab_factura)
                .Index(t => t.id_plato)
                .Index(t => t.id_guarnicion)
                .Index(t => t.id_postre)
                .Index(t => t.id_bebida)
                .Index(t => t.id_plato_combinado);
            
            CreateTable(
                "dbo.bebida",
                c => new
                    {
                        id_bebida = c.Int(nullable: false, identity: true),
                        descripcion = c.String(maxLength: 24),
                        precio = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.id_bebida);
            
            CreateTable(
                "dbo.cabecera_factura",
                c => new
                    {
                        id_cab_factura = c.Int(nullable: false, identity: true),
                        id_cliente = c.Int(),
                        id_mozo = c.Int(),
                        id_mesa = c.Int(),
                        fecha_alta = c.DateTime(),
                        cliente_Id = c.String(maxLength: 128),
                        mesero_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id_cab_factura)
                .ForeignKey("dbo.usuario", t => t.cliente_Id)
                .ForeignKey("dbo.mesa", t => t.id_mesa)
                .ForeignKey("dbo.usuario", t => t.mesero_Id)
                .Index(t => t.id_mesa)
                .Index(t => t.cliente_Id)
                .Index(t => t.mesero_Id);
            
            CreateTable(
                "dbo.mesa",
                c => new
                    {
                        id_mesa = c.Int(nullable: false, identity: true),
                        estado = c.String(maxLength: 24),
                    })
                .PrimaryKey(t => t.id_mesa);
            
            CreateTable(
                "dbo.guarnicion",
                c => new
                    {
                        id_guarnicion = c.Int(nullable: false, identity: true),
                        descripcion = c.String(maxLength: 24),
                        precio = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.id_guarnicion);
            
            CreateTable(
                "dbo.plato",
                c => new
                    {
                        id_plato = c.Int(nullable: false, identity: true),
                        descripcion = c.String(maxLength: 24),
                        precio = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.id_plato);
            
            CreateTable(
                "dbo.postre",
                c => new
                    {
                        id_postre = c.Int(nullable: false, identity: true),
                        descripcion = c.String(maxLength: 24),
                        precio = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.id_postre);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.detalle_factura", "id_postre", "dbo.postre");
            DropForeignKey("dbo.detalle_factura", "id_plato_combinado", "dbo.plato_combinado");
            DropForeignKey("dbo.plato_combinado", "id_plato", "dbo.plato");
            DropForeignKey("dbo.detalle_factura", "id_plato", "dbo.plato");
            DropForeignKey("dbo.plato_combinado", "id_guarnicion", "dbo.guarnicion");
            DropForeignKey("dbo.detalle_factura", "id_guarnicion", "dbo.guarnicion");
            DropForeignKey("dbo.cabecera_factura", "mesero_Id", "dbo.usuario");
            DropForeignKey("dbo.cabecera_factura", "id_mesa", "dbo.mesa");
            DropForeignKey("dbo.detalle_factura", "id_cab_factura", "dbo.cabecera_factura");
            DropForeignKey("dbo.cabecera_factura", "cliente_Id", "dbo.usuario");
            DropForeignKey("dbo.detalle_factura", "id_bebida", "dbo.bebida");
            DropForeignKey("dbo.plato_combinado", "id_agrup_plato_combinado", "dbo.agrup_plato_combinado");
            DropIndex("dbo.cabecera_factura", new[] { "mesero_Id" });
            DropIndex("dbo.cabecera_factura", new[] { "cliente_Id" });
            DropIndex("dbo.cabecera_factura", new[] { "id_mesa" });
            DropIndex("dbo.detalle_factura", new[] { "id_plato_combinado" });
            DropIndex("dbo.detalle_factura", new[] { "id_bebida" });
            DropIndex("dbo.detalle_factura", new[] { "id_postre" });
            DropIndex("dbo.detalle_factura", new[] { "id_guarnicion" });
            DropIndex("dbo.detalle_factura", new[] { "id_plato" });
            DropIndex("dbo.detalle_factura", new[] { "id_cab_factura" });
            DropIndex("dbo.plato_combinado", new[] { "id_agrup_plato_combinado" });
            DropIndex("dbo.plato_combinado", new[] { "id_guarnicion" });
            DropIndex("dbo.plato_combinado", new[] { "id_plato" });
            DropTable("dbo.postre");
            DropTable("dbo.plato");
            DropTable("dbo.guarnicion");
            DropTable("dbo.mesa");
            DropTable("dbo.cabecera_factura");
            DropTable("dbo.bebida");
            DropTable("dbo.detalle_factura");
            DropTable("dbo.plato_combinado");
            DropTable("dbo.agrup_plato_combinado");
            RenameTable(name: "dbo.usuario-login", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.usuario-claim", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.usuario", newName: "AspNetUsers");
            RenameTable(name: "dbo.usuario-rol", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.rol", newName: "AspNetRoles");
        }
    }
}
