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
        void Alterar(Acoes acoes, Guid id);
        void Excluir(Guid id);
        Acoes Procurar(int id);
        List<Acoes> ProcurarTodas();
        List<Acoes> ProcurarAcoesRecente();
        List<Acoes> ProcurarAcoesAndamento();
        List<Acoes> ProcurarAcoesConcluidas();
    }
}
