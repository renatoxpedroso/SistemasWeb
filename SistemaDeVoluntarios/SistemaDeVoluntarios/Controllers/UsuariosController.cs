using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;

using SistemaDeVoluntarios.Dominio;
using SistemaDeVoluntarios.Infra.Repositorio;
using SistemaDeVoluntarios.Aplicacao;

namespace SistemaDeVoluntarios.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        
    }
}