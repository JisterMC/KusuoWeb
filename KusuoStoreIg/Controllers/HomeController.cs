using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KusuoStoreIg.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "¿Qué somos?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "¡Contáctanos!";

            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "¡Bienvenido nuevamente!";
                return View();
        }
    }
}