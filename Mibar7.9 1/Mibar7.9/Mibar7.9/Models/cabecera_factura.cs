namespace Mibar7._9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class cabecera_factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cabecera_factura()
        {
            datalle_factura = new HashSet<datalle_factura>();
        }

        [Key]
        public int id_cab_factura { get; set; }

        public int? id_cliente { get; set; }

        public int? id_mozo { get; set; }

        public int? id_mesa { get; set; }

        public DateTime? fecha_alta { get; set; }

        public virtual persona persona { get; set; }

        public virtual mesa mesa { get; set; }

        public virtual persona persona1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<datalle_factura> datalle_factura { get; set; }
    }
}
