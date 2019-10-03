namespace Mibar7._9.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Owin;

    public partial class ApplicationDbContext : IdentityDbContext<AppUser>
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

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>().ToTable("usuario");
            modelBuilder.Entity<IdentityUserRole>().ToTable("usuario-roles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("logins-usuario");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("claims-usuario");
            modelBuilder.Entity<IdentityRole>().ToTable("rol");
        }

        public System.Data.Entity.DbSet<Mibar7._9.Models.AppUser> AppUsers { get; set; }
    }
}
