namespace Mibar7._9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("persona")]
    public partial class persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public persona()
        {
            cabecera_factura = new HashSet<cabecera_factura>();
            cabecera_factura1 = new HashSet<cabecera_factura>();
        }

        [Key]

        public int id_persona { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        [StringLength(24)]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        [StringLength(24)]
        public string apellido { get; set; }
        [Required]
       // [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime? fecha_nac { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "Telefono")]
        public string telefono { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        [StringLength(48)]
        public string email { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        [StringLength(100)]
        public string direccion { get; set; }
        [Required]
        [StringLength(24)]
        public string rol { get; set; }
        [Required]
        [StringLength(24)]
        [Display(Name = "Nombre de usuario")]
        public string nick { get; set; }
        [Required]
        [StringLength(24)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string pass { get; set; }

        [Required]
        [StringLength(24)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("pass",ErrorMessage = "Las contraseñas no coinciden")]
        public string confirmar_pass { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cabecera_factura> cabecera_factura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cabecera_factura> cabecera_factura1 { get; set; }
    }
}
