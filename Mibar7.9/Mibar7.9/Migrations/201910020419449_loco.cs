namespace Mibar7._9.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class loco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.agrup_plato_combinado",
                c => new
                    {
                        id_agrup_plato_combinado = c.Int(nullable: false, identity: true),
                        descripcion = c.String(maxLength: 40, unicode: false),
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
                "dbo.datalle_factura",
                c => new
                    {
                        id_det_factura = c.Int(nullable: false, identity: true),
                        id_cab_factura = c.Int(nullable: false),
                        id_plato = c.Int(),
                        id_guarnicion = c.Int(),
                        id_postre = c.Int(),
                        id_bebida = c.Int(),
                        id_plato_combinado = c.Int(),
                        estado = c.String(maxLength: 24, unicode: false),
                        precio = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.id_det_factura)
                .ForeignKey("dbo.bebida", t => t.id_bebida)
                .ForeignKey("dbo.cabecera_factura", t => t.id_cab_factura)
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
                        descripcion = c.String(maxLength: 24, unicode: false),
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
                    })
                .PrimaryKey(t => t.id_cab_factura)
                .ForeignKey("dbo.mesa", t => t.id_mesa)
                .ForeignKey("dbo.persona", t => t.id_cliente)
                .ForeignKey("dbo.persona", t => t.id_mozo)
                .Index(t => t.id_cliente)
                .Index(t => t.id_mozo)
                .Index(t => t.id_mesa);
            
            CreateTable(
                "dbo.mesa",
                c => new
                    {
                        id_mesa = c.Int(nullable: false, identity: true),
                        estado = c.String(maxLength: 24, unicode: false),
                    })
                .PrimaryKey(t => t.id_mesa);
            
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
            
            CreateTable(
                "dbo.guarnicion",
                c => new
                    {
                        id_guarnicion = c.Int(nullable: false, identity: true),
                        descripcion = c.String(maxLength: 24, unicode: false),
                        precio = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.id_guarnicion);
            
            CreateTable(
                "dbo.plato",
                c => new
                    {
                        id_plato = c.Int(nullable: false, identity: true),
                        descripcion = c.String(maxLength: 24, unicode: false),
                        precio = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.id_plato);
            
            CreateTable(
                "dbo.postre",
                c => new
                    {
                        id_postre = c.Int(nullable: false, identity: true),
                        descripcion = c.String(maxLength: 24, unicode: false),
                        precio = c.Decimal(storeType: "money"),
                    })
                .PrimaryKey(t => t.id_postre);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MyExtraProperty = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.datalle_factura", "id_postre", "dbo.postre");
            DropForeignKey("dbo.datalle_factura", "id_plato_combinado", "dbo.plato_combinado");
            DropForeignKey("dbo.plato_combinado", "id_plato", "dbo.plato");
            DropForeignKey("dbo.datalle_factura", "id_plato", "dbo.plato");
            DropForeignKey("dbo.plato_combinado", "id_guarnicion", "dbo.guarnicion");
            DropForeignKey("dbo.datalle_factura", "id_guarnicion", "dbo.guarnicion");
            DropForeignKey("dbo.cabecera_factura", "id_mozo", "dbo.persona");
            DropForeignKey("dbo.cabecera_factura", "id_cliente", "dbo.persona");
            DropForeignKey("dbo.cabecera_factura", "id_mesa", "dbo.mesa");
            DropForeignKey("dbo.datalle_factura", "id_cab_factura", "dbo.cabecera_factura");
            DropForeignKey("dbo.datalle_factura", "id_bebida", "dbo.bebida");
            DropForeignKey("dbo.plato_combinado", "id_agrup_plato_combinado", "dbo.agrup_plato_combinado");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.cabecera_factura", new[] { "id_mesa" });
            DropIndex("dbo.cabecera_factura", new[] { "id_mozo" });
            DropIndex("dbo.cabecera_factura", new[] { "id_cliente" });
            DropIndex("dbo.datalle_factura", new[] { "id_plato_combinado" });
            DropIndex("dbo.datalle_factura", new[] { "id_bebida" });
            DropIndex("dbo.datalle_factura", new[] { "id_postre" });
            DropIndex("dbo.datalle_factura", new[] { "id_guarnicion" });
            DropIndex("dbo.datalle_factura", new[] { "id_plato" });
            DropIndex("dbo.datalle_factura", new[] { "id_cab_factura" });
            DropIndex("dbo.plato_combinado", new[] { "id_agrup_plato_combinado" });
            DropIndex("dbo.plato_combinado", new[] { "id_guarnicion" });
            DropIndex("dbo.plato_combinado", new[] { "id_plato" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.postre");
            DropTable("dbo.plato");
            DropTable("dbo.guarnicion");
            DropTable("dbo.persona");
            DropTable("dbo.mesa");
            DropTable("dbo.cabecera_factura");
            DropTable("dbo.bebida");
            DropTable("dbo.datalle_factura");
            DropTable("dbo.plato_combinado");
            DropTable("dbo.agrup_plato_combinado");
        }
    }
}
