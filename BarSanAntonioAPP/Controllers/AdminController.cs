using BarSanAntonioAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarSanAntonioAPP.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult AsignarRoles()
        {
            var listadoRoles = db.Roles.Select(x => x.Name).ToList();

            ViewBag.listadosroles= listadoRoles;
            return View();
        }
    }
}