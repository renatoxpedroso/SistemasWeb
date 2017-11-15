using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeVoluntarios.Dominio.Entidades;

namespace SistemaDeVoluntarios.Dominio.Repositorios
{
    public interface IUsuariosAdministradorRepositorio
    {
        void Inserir(UsuarioAdministrador usuariosAdministrador);
        void Alterar(UsuarioAdministrador usuariosAdministrador, Guid id);
        void Excluir(Guid id);
        UsuarioAdministrador Procurar(Guid id);
        //UsuarioAdministrador ProcurarLogin(UsuarioAdministrador usuariosAdministrador);
    }
}
