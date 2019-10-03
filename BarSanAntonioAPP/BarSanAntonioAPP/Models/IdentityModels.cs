using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BarSanAntonioAPP.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(24)]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        [StringLength(24)]
        public string apellido { get; set; }
        [Required]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? fecha_nac { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        [StringLength(100)]
        public string direccion { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("BarSanAntonioAPP", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<agrup_plato_combinado> agrup_plato_combinado { get; set; }
        public virtual DbSet<bebida> bebida { get; set; }
        public virtual DbSet<cabecera_factura> cabecera_factura { get; set; }
        public virtual DbSet<detalle_factura> detalle_factura { get; set; }
        public virtual DbSet<guarnicion> guarnicion { get; set; }
        public virtual DbSet<mesa> mesa { get; set; }
        public virtual DbSet<plato> plato { get; set; }
        public virtual DbSet<plato_combinado> plato_combinado { get; set; }
        public virtual DbSet<postre> postre { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("usuario");

            modelBuilder.Entity<IdentityRole>().ToTable("rol");
            modelBuilder.Entity<IdentityUserRole>().ToTable("usuario-rol");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("usuario-claim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("usuario-login");
        }
    }
}