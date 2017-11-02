using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVoluntarios.Controllers
{
    [Filtro.FiltroAcess]
    public class CadastroUsuariosController : Controller
    {
        // GET: CadastroUsuarios
        public ActionResult Index()
        {
            return View();
        }
    }
}