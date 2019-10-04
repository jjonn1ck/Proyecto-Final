using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BarSanAntonioAPP.Models
{

    [Table("bebida")]
    public class bebida
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bebida()
        {
            detalle_factura = new HashSet<detalle_factura>();
        }

        [Key]
        public int id_bebida { get; set; }

        [StringLength(24)]
        public string descripcion { get; set; }

        [Column(TypeName = "money")]
        public decimal? precio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_factura> detalle_factura { get; set; }

    }
}