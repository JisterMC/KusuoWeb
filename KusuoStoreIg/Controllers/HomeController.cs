using KusuoStoreIg.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KusuoStoreIg.Controllers
{
    public class HomeController : Controller
    {
        KusuoStoreEn db = new KusuoStoreEn();
        //USUARIO
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
        //CARCASAS
        public ActionResult Modelos()
        {
            List<carcasa> listdata = db.carcasa.ToList();

            ViewBag.Message = "¡Contáctanos!";

            return View(listdata);
        }

        [HttpPost]
        public ActionResult Agregarcarcasa(carcasa carcasa)
        {
            db.carcasa.Add(carcasa);
            db.SaveChanges();
          return View();

        }

    }
}