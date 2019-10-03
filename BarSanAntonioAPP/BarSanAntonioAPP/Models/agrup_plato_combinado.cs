using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace BarSanAntonioAPP.Models
{
    public class agrup_plato_combinado
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public agrup_plato_combinado()
        {
            plato_combinado = new HashSet<plato_combinado>();
        }

        [Key]
        public int id_agrup_plato_combinado { get; set; }

        [StringLength(40)]
        public string descripcion { get; set; }

        [Column(TypeName = "money")]
        public decimal? precio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<plato_combinado> plato_combinado { get; set; }

    }
}