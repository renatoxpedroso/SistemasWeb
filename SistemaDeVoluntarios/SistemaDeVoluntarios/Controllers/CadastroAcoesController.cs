using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVoluntarios.Controllers
{
    [Filtro.FiltroAcess]
    public class CadastroAcoesController : Controller
    {
        // GET: CadastroAcoes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexUsuario()
        {
            return View();
        }
    }
}