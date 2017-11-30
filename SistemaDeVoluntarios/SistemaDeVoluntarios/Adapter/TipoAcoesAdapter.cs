using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaDeVoluntarios.Models;
using SistemaDeVoluntarios.Dominio.Entidades;

namespace SistemaDeVoluntarios.Adapter
{
    public abstract class TipoAcoesAdapter
    {
        public static Models.TipoAcoes ParaModel(SistemaDeVoluntarios.Dominio.Entidades.TipoAcoes tipoAcoes)
        {
            return new Models.TipoAcoes()
            {
                Id = tipoAcoes.Id,
                codTipoAcao = tipoAcoes.codTipoAcao,
                Nome = tipoAcoes.Nome
            };
        }

        public static List<Models.TipoAcoes> ParaModel(List<SistemaDeVoluntarios.Dominio.Entidades.TipoAcoes> tipoAcoes)
        {

            List<Models.TipoAcoes> atipoAcoesModel = new List<Models.TipoAcoes>();

            foreach (var tipoAcao in tipoAcoes)
            {
                atipoAcoesModel.Add(ParaModel(tipoAcao));

            }

            return atipoAcoesModel;
        }


        public static SistemaDeVoluntarios.Dominio.Entidades.TipoAcoes ParaDominio(Models.TipoAcoes tipoAcao)
        {
            return new SistemaDeVoluntarios.Dominio.Entidades.TipoAcoes()
            {
                Id = tipoAcao.Id,
                codTipoAcao = tipoAcao.codTipoAcao,
                Nome = tipoAcao.Nome
            };
        }
    }
}