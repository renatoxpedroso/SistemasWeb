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
    }
}
