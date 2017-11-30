using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaDeVoluntarios.Dominio.Entidades;
using SistemaDeVoluntarios.Dominio.Repositorios;

namespace SistemaDeVoluntarios.Aplicacao
{
    public class AcoesAplicacao
    {
        private IAcoesRepositorio acaoRepositorio;
        public AcoesAplicacao(IAcoesRepositorio acaoRepositorio)
        {
            this.acaoRepositorio = acaoRepositorio;
        }

        public void Inserir(Acoes acoes)
        {
            this.acaoRepositorio.Inserir(acoes);
        }

        public List<Acoes> ProcurarTodas()
        {
            List<Acoes> acoes;
            acoes = acaoRepositorio.ProcurarTodas();
            return acoes;
        }

        public Acoes Procurar(int Id)
        {
            Acoes acao;
            acao = acaoRepositorio.Procurar(Id);
            return acao;
        }
    }
}
