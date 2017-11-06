using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVoluntarios.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String usuario, String senha)
        {
            if (usuario == "renato@renato.com" && senha == "123")
            {
                Session["usuario"] = usuario;

                return RedirectToAction("Index", "Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}