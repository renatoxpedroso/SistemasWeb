using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaDeVoluntarios.Models;
using SistemaDeVoluntarios.Dominio.Entidades;

namespace SistemaDeVoluntarios.Adapter
{
    public abstract class AcoesAdapter
    {
        public static Models.Acoes ParaModel(SistemaDeVoluntarios.Dominio.Entidades.Acoes acao)
        {
            return new Models.Acoes()
            {
                Id = acao.Id,
                CodAcoes = acao.CodAcoes,
                Assunto = acao.Assunto,
                DatFim = acao.DatFim,
                DatInicio = acao.DatInicio,
                TipoAcao = acao.TipoAcao,
                Status = acao.Status,
                Criador = acao.Criador
            };
        }

        public static List<Models.Acoes> ParaModel(List<SistemaDeVoluntarios.Dominio.Entidades.Acoes> acoes)
        {

            List<Models.Acoes> acoesModel = new List<Models.Acoes>();

            foreach (var acao in acoes)
            {
                acoesModel.Add(ParaModel(acao));

            }

            return acoesModel;
        }


        public static SistemaDeVoluntarios.Dominio.Entidades.Acoes ParaDominio(Models.Acoes acao)
        {
            return new SistemaDeVoluntarios.Dominio.Entidades.Acoes()
            {
                Id = acao.Id,
                CodAcoes = acao.CodAcoes,
                Assunto = acao.Assunto,
                DatFim = acao.DatFim,
                DatInicio = acao.DatInicio,
                TipoAcao = acao.TipoAcao,
                Status = acao.Status,
                Criador = acao.Criador
            };
        }
    }
}