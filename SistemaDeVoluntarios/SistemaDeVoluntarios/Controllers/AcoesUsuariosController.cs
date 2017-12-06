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
    public class AcoesUsuariosController : Controller
    {
        // GET: AcoesUsuarios
        public ActionResult IndexAcoesUsuariosAndamento()
        {
            List<Models.Acoes> acoesModel;
            AcoesRepositorio acaoRepositorio = new AcoesRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            AcoesAplicacao acaoAplicacao = new AcoesAplicacao(acaoRepositorio);
            List<Dominio.Entidades.Acoes> acoes = acaoAplicacao.ProcurarAcoes("2");

            acoesModel = Adapter.AcoesAdapter.ParaModel(acoes);

            ViewBag.acoes = acoesModel;
            ViewBag.usuarioLogin = Session["usuarioLogin"];

            return View();
        }

        public ActionResult IndexAcoesUsuariosConcluidas()
        {
            List<Models.Acoes> acoesModel;
            AcoesRepositorio acaoRepositorio = new AcoesRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            AcoesAplicacao acaoAplicacao = new AcoesAplicacao(acaoRepositorio);
            List<Dominio.Entidades.Acoes> acoes = acaoAplicacao.ProcurarAcoes("3");

            acoesModel = Adapter.AcoesAdapter.ParaModel(acoes);

            ViewBag.acoes = acoesModel;
            ViewBag.usuarioLogin = Session["usuarioLogin"];

            return View();
        }

        public ActionResult IndexAcoesUsuariosRecentes()
        {
            List<Models.Acoes> acoesModel;
            AcoesRepositorio acaoRepositorio = new AcoesRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            AcoesAplicacao acaoAplicacao = new AcoesAplicacao(acaoRepositorio);
            List<Dominio.Entidades.Acoes> acoes = acaoAplicacao.ProcurarAcoes("1");

            acoesModel = Adapter.AcoesAdapter.ParaModel(acoes);

            ViewBag.acoes = acoesModel;
            ViewBag.usuarioLogin = Session["usuarioLogin"];

            return View();
        }
    }
}