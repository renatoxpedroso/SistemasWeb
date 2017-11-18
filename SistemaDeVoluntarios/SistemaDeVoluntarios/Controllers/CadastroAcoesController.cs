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
        public ActionResult Gravar(Acoes acoes)
        {
            Dominio.Entidades.Acoes acao;
            AcoesRepositorio acaoRepositorio;
            AcoesAplicacao acaoAplicacao;

            string strConexao = ConfigurationManager.ConnectionStrings["conexao"].ToString();

            acaoRepositorio = new AcoesRepositorio(strConexao);

            acaoAplicacao = new AcoesAplicacao(acaoRepositorio);


            acao = new Dominio.Entidades.Acoes()
            {
                Status = acoes.Status,
                Assunto = acoes.Assunto,
                DatInicio = acoes.DatInicio,
                DatFim = acoes.DatFim,
                TipoAcao = acoes.TipoAcao

            };

            acaoAplicacao.Inserir(acao);

            return RedirectToAction("index");
        }
    }
}