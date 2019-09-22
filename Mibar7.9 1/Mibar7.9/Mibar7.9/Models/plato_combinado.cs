namespace Mibar7._9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class plato_combinado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public plato_combinado()
        {
            datalle_factura = new HashSet<datalle_factura>();
        }

        [Key]
        public int id_plato_combinado { get; set; }

        public int? id_plato { get; set; }

        public int? id_guarnicion { get; set; }

        public int? id_agrup_plato_combinado { get; set; }

        public virtual agrup_plato_combinado agrup_plato_combinado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<datalle_factura> datalle_factura { get; set; }

        public virtual guarnicion guarnicion { get; set; }

        public virtual plato plato { get; set; }
    }
}
