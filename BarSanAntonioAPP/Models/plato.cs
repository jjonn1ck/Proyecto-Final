using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BarSanAntonioAPP.Models
{
    [Table("plato")]
    public class plato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public plato()
        {
            detalle_factura = new HashSet<detalle_factura>();
            plato_combinado = new HashSet<plato_combinado>();
        }

        [Key]
        public int id_plato { get; set; }

        [StringLength(24)]
        public string descripcion { get; set; }

        [Column(TypeName = "money")]
        public decimal? precio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_factura> detalle_factura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<plato_combinado> plato_combinado { get; set; }
    }
}