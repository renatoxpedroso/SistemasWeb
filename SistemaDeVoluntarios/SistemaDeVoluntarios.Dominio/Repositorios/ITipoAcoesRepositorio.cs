using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeVoluntarios.Dominio.Entidades;

namespace SistemaDeVoluntarios.Dominio.Repositorios
{
    public interface ITipoAcoesRepositorio
    {
        void Inserir(TipoAcoes tipoAcoes);
        void Alterar(TipoAcoes tipoAcoes, Guid id);
        void Excluir(Guid id);
        TipoAcoes Procurar(Guid id);
    }
}
