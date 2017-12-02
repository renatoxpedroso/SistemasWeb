using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;

using SistemaDeVoluntarios.Dominio;
using SistemaDeVoluntarios.Infra.Repositorio;
using SistemaDeVoluntarios.Aplicacao;
using SistemaDeVoluntarios.Models;

namespace SistemaDeVoluntarios.Controllers
{
    //[Filtro.FiltroAcess]
    public class IndexUsuarioController : Controller
    {
        // GET: IndexUsuario
        public ActionResult Index()
        {
            List<Models.Usuarios> usuariosModel;
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioRepositorio);
            List<Dominio.Entidades.Usuarios> usuarios = usuarioAplicacao.ProcurarTodos();

            usuariosModel = Adapter.UsuarioAdapter.ParaModel(usuarios);

            ViewBag.usuarios = usuariosModel;

            return View();
        }
    }
}