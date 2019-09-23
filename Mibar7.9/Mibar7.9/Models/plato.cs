namespace Mibar7._9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("plato")]
    public partial class plato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public plato()
        {
            datalle_factura = new HashSet<datalle_factura>();
            plato_combinado = new HashSet<plato_combinado>();
        }

        [Key]
        public int id_plato { get; set; }

        [StringLength(24)]
        public string descripcion { get; set; }

        [Column(TypeName = "money")]
        public decimal? precio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<datalle_factura> datalle_factura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<plato_combinado> plato_combinado { get; set; }
    }
}
