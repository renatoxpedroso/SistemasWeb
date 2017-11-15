using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaDeVoluntarios.Dominio.Entidades;
using SistemaDeVoluntarios.Dominio.Repositorios;

namespace SistemaDeVoluntarios.Aplicacao
{
    public class UsuarioAdministradorAplicacao
    {
        private IUsuariosAdministradorRepositorio usuarioAdministradorRepositorio;
        public UsuarioAdministradorAplicacao(IUsuariosAdministradorRepositorio usuarioAdministradorRepositorio)
        {
            this.usuarioAdministradorRepositorio = usuarioAdministradorRepositorio;
        }

        public void Inserir(UsuarioAdministrador usuarios)
        {
            this.usuarioAdministradorRepositorio.Inserir(usuarios);
        }

    }
}
