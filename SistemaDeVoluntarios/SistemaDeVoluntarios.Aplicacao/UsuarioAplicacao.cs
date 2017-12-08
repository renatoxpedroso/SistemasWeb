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
            this.usuarioRepositorio.Inserir(usuarios);
        }

        public Usuarios ProcurarLogin(Usuarios usuarios)
        {
            Usuarios users;
            users = usuarioRepositorio.ProcurarLogin(usuarios);
            return users;
        }

        public Usuarios ProcurarCodigo(int Id)
        {
            Usuarios users;
            users = usuarioRepositorio.ProcurarCodigo(Id);
            return users;
        }

        public List<Usuarios> ProcurarTodos()
        {
            List<Usuarios> users;
            users = usuarioRepositorio.ProcurarTodos();
            return users;
        }

        public void AlterarStatus(int status, int id)
        {
            this.usuarioRepositorio.AlterarStatus(status, id);
        }

    }
}
