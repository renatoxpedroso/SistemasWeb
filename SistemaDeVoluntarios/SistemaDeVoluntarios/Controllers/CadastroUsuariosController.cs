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
            string[] cidades = new string[] { "Agua Santa", "Agudo", "Ajuricaba", "Alecrim", "Alegrete", "Alegria", "Alpestre", "Alto Alegre", "Alto Feliz", "Alvorada", "Amaral Ferrador", "Ametista do Sul", "Andre da Rocha", "Anta Gorda", "Antonio Prado", "Arambare", "Ararica", "Aratiba", "Arroio Grande", "Arroio do Meio", "Arroio do Sal", "Arroio do Tigre"};
            string[] estados = new string[] { "Acre", "Alagoas", "Amapá", "Amazonas", "Bahia", "Ceará", "Distrito Federal", "Espírito Santo", "Goiás", "Maranhão", "Mato Grosso", "Mato Grosso do Sul", "Minas Gerais", "Pará", "Paraíba", "Paraná", "Pernambuco", "Piauí", "Rio de Janeiro", "Rio Grande do Norte", "Rio Grande do Sul", "Rondônia", "Roraima", "Santa Catarina", "São Paulo", "Sergipe", "Tocantins"};

            ViewBag.estados = estados;
            ViewBag.cidades = cidades;
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

        public ActionResult Alterar(Usuarios usuarios)
        {
            Dominio.Entidades.Usuarios user;
            UsuarioRepositorio usuarioRepositorio;
            UsuarioAplicacao usuarioAplicacao;
            ViewBag.usuario = Session["usuarioAlteracao"];
            Usuarios usu = ViewBag.usuario;

            string strConexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            usuarioRepositorio = new UsuarioRepositorio(strConexao);

            usuarioAplicacao = new UsuarioAplicacao(usuarioRepositorio);


            user = new Dominio.Entidades.Usuarios()
            {
                CodUsuario = usu.CodUsuario,
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

            usuarioAplicacao.Alterar(user);

            return View("IndexAlteracao");
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