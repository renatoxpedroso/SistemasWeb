using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVoluntarios.Controllers
{
    [Filtro.FiltroAcess]
    public class AcoesController : Controller
    {
        // GET: Acoes
        public ActionResult IndexAcoesRecentes()
        {
            return View();
        }

        public ActionResult IndexAcoesAndamento()
        {
            return View();
        }

        public ActionResult IndexAcoesConcluidas()
        {
            return View();
        }
    }
}