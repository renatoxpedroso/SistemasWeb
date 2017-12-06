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
   
    public class CadastroAdministradoresController : Controller
    {
        // GET: CadastroAdministradores
        public ActionResult Index()
        {
            ViewBag.usuarioLogin = Session["usuarioLogin"];
            return View();
        }

        [HttpPost]
        public ActionResult Gravar(UsuariosAdministrador usuarios)
        {
            Dominio.Entidades.UsuarioAdministrador user;
            UsuarioAdministradorRepositorio usuarioRepositorio;
            UsuarioAdministradorAplicacao usuarioAplicacao;

            string strConexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            usuarioRepositorio = new UsuarioAdministradorRepositorio(strConexao);

            usuarioAplicacao = new UsuarioAdministradorAplicacao(usuarioRepositorio);


            user = new Dominio.Entidades.UsuarioAdministrador()
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
    }
}