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
            List<Models.TipoAcoes> tipoAcaoModel;
            TipoAcoesRepositorio  tipoAcaoRepositorio = new TipoAcoesRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            TipoAcoesAplicacao tipoAcaoAplicacao = new TipoAcoesAplicacao(tipoAcaoRepositorio);
            List<Dominio.Entidades.TipoAcoes> tipoAcoes = tipoAcaoAplicacao.ProcurarTodas();

            tipoAcaoModel = Adapter.TipoAcoesAdapter.ParaModel(tipoAcoes);

            if (Session["acao"] != null)
            {
                ViewBag.acao = Session["acao"];
            }
            else
            {
                ViewBag.acao = null;
            }

            ViewBag.tipoAcoes = tipoAcaoModel;

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
                DatInicio = Convert.ToDateTime(acoes.DatInicio),
                DatFim = Convert.ToDateTime(acoes.DatFim),
                TipoAcao = acoes.TipoAcao,
                Criador = acoes.Criador

            };

            acaoAplicacao.Inserir(acao);

            return RedirectToAction("index");
        }

        public ActionResult Editar(int Id)
        {
            Models.Acoes acoesModel;
            AcoesRepositorio acaoRepositorio = new AcoesRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            AcoesAplicacao acaoAplicacao = new AcoesAplicacao(acaoRepositorio);
            Dominio.Entidades.Acoes acoes = acaoAplicacao.Procurar(Id);

            acoesModel = Adapter.AcoesAdapter.ParaModel(acoes);

            Session["acao"] = acoesModel;


            return RedirectToAction("index");
        }
    }
}