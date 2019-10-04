using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BarSanAntonioAPP.Models
{
    public class cabecera_factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cabecera_factura()
        {
            detalle_factura = new HashSet<detalle_factura>();
        }

        [Key]
        public int id_cab_factura { get; set; }

        public int? id_cliente { get; set; }

        public int? id_mozo { get; set; }

        public int? id_mesa { get; set; }

        public DateTime? fecha_alta { get; set; }

        public virtual ApplicationUser cliente { get; set; }

        public virtual mesa mesa { get; set; }

        public virtual ApplicationUser mesero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_factura> detalle_factura { get; set; }
    }
}