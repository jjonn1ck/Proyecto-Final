using Mibar7._9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mibar7._9.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LaCarta()
        {
            return View();
        }
        public ActionResult MmiPedido()
        {
            return View();
        }
        public ActionResult Caratula()
        {
            return View();
        }
        public ActionResult Guarnicion()
        {
            return View();
        }
        public ActionResult CargarUsuario()
        {
            return View();
        }


        public ActionResult IniciarSesion()
        {

            return View();
        }


        [HttpPost]
        public ActionResult IniciarSesion(persona persona)
        {

            string usuario = persona.nick;
            string pass = persona.pass;



            foreach (persona usu in db.persona.Where(u => u.nick == usuario && u.pass == pass))
            {
                /* if (usu.idRol == 1)
                 {

                     return RedirectToAction("Index", "OrdenDeTrabajo", usu);


                 }

                 else
                 {

                     return RedirectToAction("IndexEmpleado", "OrdenDeTrabajo", usu);
                 }*/

                return RedirectToAction("Index");


            }

            return View("Incorrecto");

        }
    }

}