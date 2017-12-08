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
    
    public class CadastroUsuariosController : Controller
    {
        // GET: CadastroUsuarios
        public ActionResult Index()
        {
            return View();
        }

        [Filtro.FiltroAcess]
        public ActionResult IndexAlteracao()
        {
            ViewBag.usuario = Session["usuarioAlteracao"];
            ViewBag.usuarioLogin = Session["usuarioLogin"];

            return View();
        }

        [HttpPost]
        public ActionResult Gravar(Usuarios usuarios)
        {
            Dominio.Entidades.Usuarios user;
            UsuarioRepositorio usuarioRepositorio;
            UsuarioAplicacao usuarioAplicacao;

            string strConexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            usuarioRepositorio = new UsuarioRepositorio(strConexao);

            usuarioAplicacao = new UsuarioAplicacao(usuarioRepositorio);


            user = new Dominio.Entidades.Usuarios()
            {
                CodUsuario = usuarios.CodUsuario,
                TipoUsuario = usuarios.TipoUsuario,
                TipoPessoa = usuarios.TipoPessoa,
                Nome = usuarios.Nome,
                Email = usuarios.Email,
                Senha = usuarios.Senha,
                DataNacimento = usuarios.DataNacimento,
                cpfCnpj = usuarios.cpfCnpj,
                Telefone = usuarios.Telefone,
                Celular = usuarios.Celular,
                Rua = usuarios.Rua,
                Numero = usuarios.Numero,
                Bairro = usuarios.Bairro,
                Cidade = usuarios.Cidade,
                Cep = usuarios.Cep,
                Estado = usuarios.Estado

            };

            usuarioAplicacao.Inserir(user);

            return RedirectToAction("index");
        }

        public ActionResult Editar(int Id)
        {
            Models.Usuarios usuarioModel;
            UsuarioRepositorio usuariosRepositorio = new UsuarioRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuariosRepositorio);
            Dominio.Entidades.Usuarios usuario = usuarioAplicacao.ProcurarCodigo(Id);

            usuarioModel = Adapter.UsuarioAdapter.ParaModel(usuario);

            Session["usuarioAlteracao"] = usuarioModel;


            return RedirectToAction("IndexAlteracao");
        }
    }
}