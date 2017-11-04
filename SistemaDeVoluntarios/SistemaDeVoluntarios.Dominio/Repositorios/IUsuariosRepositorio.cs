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
        void Alterar(Usuarios usuarios, string id);
        void Excluir(string id);
        Usuarios Procurar(string id);
        Usuarios ProcurarLogin(string Email, string Senha);
    }
}
