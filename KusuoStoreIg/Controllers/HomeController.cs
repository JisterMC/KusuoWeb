using KusuoStoreIg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KusuoStoreIg.Controllers
{
    public class HomeController : Controller
    {
        KusuoEntity db = new KusuoEntity();
        // GET: Usuario
        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(usuario usuario)
        {
            if (db.usuario.Any(x => x.nomusuario == usuario.nomusuario))
            {
                ViewBag.Notification = "Esta cuenta ya existe";
                return View();
            }
            else
            {
                db.usuario.Add(usuario);
                db.SaveChanges();

                Session["IdUsSS"] = usuario.IDus.ToString();
                Session["UsernameSS"] = usuario.nomusuario.ToString();
                return RedirectToAction("Index", "Home");
            }
        }
    
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
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(usuario usuario)
        {
            var checkLogin = db.usuario.Where(x => x.nomusuario.Equals(usuario.nomusuario) && x.contraseña.Equals(usuario.contraseña)).FirstOrDefault();
            if (checkLogin != null)
            {
                Session["IdUsSS"] = usuario.IDus.ToString();
                Session["UsernameSS"] = usuario.nomusuario.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Su usuario o contraseña es incorrecto";
            }
            return View();
        }
        public ActionResult Modelos()
        {
            ViewBag.Message = "¡Contáctanos!";

            return View();
        }

    }
}