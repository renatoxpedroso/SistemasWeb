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
    [Filtro.FiltroAcess]
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            List<Models.Acoes> acoesModel;
            AcoesRepositorio acaoRepositorio = new AcoesRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            AcoesAplicacao acaoAplicacao = new AcoesAplicacao(acaoRepositorio);
            List<Dominio.Entidades.Acoes> acoes = acaoAplicacao.ProcurarTodas();

            acoesModel = Adapter.AcoesAdapter.ParaModel(acoes);

            ViewBag.acoes = acoesModel;

            ViewBag.usuarioLogin = Session["usuarioLogin"];

            return View();
        }
    }
}