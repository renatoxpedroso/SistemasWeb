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

        [HttpPost]
        public ActionResult Gravar(TipoAcoes tipo)
        {
            Dominio.Entidades.TipoAcoes tipoAcoes;
            TipoAcoesRepositorio tipoAcoesRepositorio;
            TipoAcoesAplicacao tipoAcoesAplicacao;

            string strConexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            tipoAcoesRepositorio = new TipoAcoesRepositorio(strConexao);

            tipoAcoesAplicacao = new TipoAcoesAplicacao(tipoAcoesRepositorio);


            tipoAcoes = new Dominio.Entidades.TipoAcoes()
            {
                //codTipoAcao = tipo.codTipoAcao,
                Nome = tipo.Nome,

            };

            tipoAcoesAplicacao.Inserir(tipoAcoes);

            return RedirectToAction("index");
        }
    }
}