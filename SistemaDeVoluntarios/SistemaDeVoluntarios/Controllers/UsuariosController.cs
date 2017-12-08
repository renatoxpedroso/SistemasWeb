using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SistemaDeVoluntarios.Aplicacao;
using SistemaDeVoluntarios.Infra.Repositorio;
using System.Configuration;

namespace SistemaDeVoluntarios.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            
            List<Models.Usuarios> usuariosModel;
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioRepositorio);
            List<Dominio.Entidades.Usuarios> usuarios = usuarioAplicacao.ProcurarTodos();

            usuariosModel = Adapter.UsuarioAdapter.ParaModel(usuarios);

            ViewBag.usuarios = usuariosModel;
            ViewBag.usuarioLogin = Session["usuarioLogin"];

            return View();
        }

        public ActionResult AlterarStatus(int id)
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioRepositorio);
            usuarioAplicacao.AlterarStatus(2, id);

            return RedirectToAction("index");
        }

        
    }
}