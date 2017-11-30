using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaDeVoluntarios.Dominio.Entidades;
using SistemaDeVoluntarios.Dominio.Repositorios;

namespace SistemaDeVoluntarios.Aplicacao
{
    public class TipoAcoesAplicacao
    {

        private ITipoAcoesRepositorio tipoAcaoRepositorio;
        public TipoAcoesAplicacao(ITipoAcoesRepositorio tipoAcaoRepositorio)
        {
            this.tipoAcaoRepositorio = tipoAcaoRepositorio;
        }

        public void Inserir(TipoAcoes tipoAcoes)
        {
            this.tipoAcaoRepositorio.Inserir(tipoAcoes);
        }

        public List<TipoAcoes> ProcurarTodas()
        {
            List<TipoAcoes> tipoAcoes;
            tipoAcoes = tipoAcaoRepositorio.ProcurarTodas();
            return tipoAcoes;
        }
    }
}
