namespace Mibar7._9.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<agrup_plato_combinado> agrup_plato_combinado { get; set; }
        public virtual DbSet<bebida> bebida { get; set; }
        public virtual DbSet<cabecera_factura> cabecera_factura { get; set; }
        public virtual DbSet<datalle_factura> datalle_factura { get; set; }
        public virtual DbSet<guarnicion> guarnicion { get; set; }
        public virtual DbSet<mesa> mesa { get; set; }
        public virtual DbSet<persona> persona { get; set; }
        public virtual DbSet<plato> plato { get; set; }
        public virtual DbSet<plato_combinado> plato_combinado { get; set; }
        public virtual DbSet<postre> postre { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<agrup_plato_combinado>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<agrup_plato_combinado>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<bebida>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<bebida>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<cabecera_factura>()
                .HasMany(e => e.datalle_factura)
                .WithRequired(e => e.cabecera_factura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<datalle_factura>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<datalle_factura>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<guarnicion>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<guarnicion>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<mesa>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.rol)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.nick)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<persona>()
                .HasMany(e => e.cabecera_factura)
                .WithOptional(e => e.persona)
                .HasForeignKey(e => e.id_cliente);

            modelBuilder.Entity<persona>()
                .HasMany(e => e.cabecera_factura1)
                .WithOptional(e => e.persona1)
                .HasForeignKey(e => e.id_mozo);

            modelBuilder.Entity<plato>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<plato>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);

            modelBuilder.Entity<postre>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<postre>()
                .Property(e => e.precio)
                .HasPrecision(19, 4);
        }
    }
}
