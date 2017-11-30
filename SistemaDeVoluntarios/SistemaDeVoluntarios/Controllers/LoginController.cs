using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;

using SistemaDeVoluntarios.Dominio;
using SistemaDeVoluntarios.Infra.Repositorio;
using SistemaDeVoluntarios.Dominio.Entidades;
using SistemaDeVoluntarios.Aplicacao;

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
            Dominio.Entidades.Usuarios user;
            UsuarioRepositorio usuarioRepositorio;
            UsuarioAplicacao usuarioAplicacao;
            Models.Usuarios usuariosModel;

            string strConexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            usuarioRepositorio = new UsuarioRepositorio(strConexao);

            usuarioAplicacao = new UsuarioAplicacao(usuarioRepositorio);


            user = new Dominio.Entidades.Usuarios()
            {
                Email = usuario,
                Senha = senha
            };

            Usuarios users = usuarioAplicacao.ProcurarLogin(user);
            usuariosModel = Adapter.UsuarioAdapter.ParaModel(users);

            if (usuario == users.Email && senha == users.Senha)
            {
                if ((users.TipoUsuario.Equals(1)) || (users.TipoUsuario.Equals(2)))
                {
                    Session["usuarioLogin"] = usuariosModel;

                    return RedirectToAction("Index", "IndexUsuario");
                }
                else
                {
                    Session["usuarioLogin"] = usuariosModel;

                    return RedirectToAction("Index", "Index");
                }
               
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