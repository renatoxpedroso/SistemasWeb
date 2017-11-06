using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaDeVoluntarios.Dominio.Entidades;

namespace SistemaDeVoluntarios.Dominio.Repositorios
{
    public interface IAcoesRepositorio
    {
        void Inserir(Acoes acoes);
        void Alterar(Acoes acoes, string id);
        void Excluir(string id);
        Acoes Procurar(string id);

    }
}
