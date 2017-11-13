using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaDeVoluntarios.Dominio.Entidades;
using SistemaDeVoluntarios.Dominio.Repositorios;


namespace SistemaDeVoluntarios.Aplicacao
{
    public class UsuarioAplicacao
    {
        private IUsuariosRepositorio usuarioRepositorio;
        public UsuarioAplicacao(IUsuariosRepositorio usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }

        public void Inserir(Usuarios usuarios)
        {
            if (string.IsNullOrEmpty(usuarios.Nome))
            {
                throw new Exception("O produto está sem nome!");
            }

            this.usuarioRepositorio.Inserir(usuarios);
        }
    }
}
