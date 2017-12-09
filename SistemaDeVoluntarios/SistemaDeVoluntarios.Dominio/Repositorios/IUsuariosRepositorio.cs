using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeVoluntarios.Dominio.Entidades;

namespace SistemaDeVoluntarios.Dominio.Repositorios
{
    public interface IUsuariosRepositorio
    {
        void Inserir(Usuarios usuarios);
        void Alterar(Usuarios usuarios);
        void AlterarStatus(int status, int id);
        void Excluir(Guid id);
        Usuarios ProcurarCodigo(int id);
        Usuarios ProcurarLogin(Usuarios usuarios);
        List<Usuarios> ProcurarTodos();
    }
}
