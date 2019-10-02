using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.ComponentModel.DataAnnotations;

namespace Mibar7._9.Models
{
    public class AppUser : IdentityUser
    {
        //add your custom properties which have not included in IdentityUser before
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
    }
}