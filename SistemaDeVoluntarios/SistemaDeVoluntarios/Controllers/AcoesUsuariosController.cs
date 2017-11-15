using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVoluntarios.Controllers
{
    public class AcoesUsuariosController : Controller
    {
        // GET: AcoesUsuarios
        public ActionResult IndexAcoesUsuariosAndamento()
        {
            return View();
        }

        public ActionResult IndexAcoesUsuariosConcluidas()
        {
            return View();
        }

        public ActionResult IndexAcoesUsuariosRecentes()
        {
            return View();
        }
    }
}