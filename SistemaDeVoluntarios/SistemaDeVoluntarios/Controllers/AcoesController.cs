﻿using System;
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
    public class AcoesController : Controller
    {
        // GET: Acoes
        public ActionResult IndexAcoesRecentes()
        {
            List<Models.Acoes> acoesModel;
            AcoesRepositorio acaoRepositorio = new AcoesRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            AcoesAplicacao acaoAplicacao = new AcoesAplicacao(acaoRepositorio);
            List<Dominio.Entidades.Acoes> acoes = acaoAplicacao.ProcurarAcoesRecente();

            acoesModel = Adapter.AcoesAdapter.ParaModel(acoes);

            ViewBag.acoes = acoesModel;
            ViewBag.usuarioLogin = Session["usuarioLogin"];

            return View();
        }

        public ActionResult IndexAcoesAndamento()
        {
            List<Models.Acoes> acoesModel;
            AcoesRepositorio acaoRepositorio = new AcoesRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            AcoesAplicacao acaoAplicacao = new AcoesAplicacao(acaoRepositorio);
            List<Dominio.Entidades.Acoes> acoes = acaoAplicacao.ProcurarAcoesAndamento();

            acoesModel = Adapter.AcoesAdapter.ParaModel(acoes);

            ViewBag.acoes = acoesModel;
            ViewBag.usuarioLogin = Session["usuarioLogin"];

            return View();
        }

        public ActionResult IndexAcoesConcluidas()
        {
            List<Models.Acoes> acoesModel;
            AcoesRepositorio acaoRepositorio = new AcoesRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            AcoesAplicacao acaoAplicacao = new AcoesAplicacao(acaoRepositorio);
            List<Dominio.Entidades.Acoes> acoes = acaoAplicacao.ProcurarAcoesConcluidas();

            acoesModel = Adapter.AcoesAdapter.ParaModel(acoes);

            ViewBag.acoes = acoesModel;
            ViewBag.usuarioLogin = Session["usuarioLogin"];

            return View();
        }
    }
}