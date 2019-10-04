using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace BarSanAntonioAPP.Models
{
    public class detalle_factura
    {
        [Key]
        public int id_det_factura { get; set; }

        public int id_cab_factura { get; set; }

        public int? id_plato { get; set; }

        public int? id_guarnicion { get; set; }

        public int? id_postre { get; set; }

        public int? id_bebida { get; set; }

        public int? id_plato_combinado { get; set; }

        [StringLength(24)]
        public string estado { get; set; }

        [Column(TypeName = "money")]
        public decimal? precio { get; set; }

        public virtual bebida bebida { get; set; }

        public virtual cabecera_factura cabecera_factura { get; set; }

        public virtual guarnicion guarnicion { get; set; }

        public virtual plato plato { get; set; }

        public virtual plato_combinado plato_combinado { get; set; }

        public virtual postre postre { get; set; }
    }
}