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
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            List<Models.Usuarios> usuariosModel;
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio(ConfigurationManager.ConnectionStrings["conexao"].ToString());
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioRepositorio);
            List<Dominio.Entidades.Usuarios> usuarios = usuarioAplicacao.ProcurarTodos();

            usuariosModel = Adapter.UsuarioAdapter.ParaModel(usuarios);

            ViewBag.usuarios = usuariosModel;


            return View();
        }


        
    }
}