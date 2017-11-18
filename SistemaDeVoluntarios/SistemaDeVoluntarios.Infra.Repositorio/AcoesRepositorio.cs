using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaDeVoluntarios.Dominio.Entidades;
using SistemaDeVoluntarios.Dominio.Repositorios;
using Npgsql;
using System.Data;

namespace SistemaDeVoluntarios.Infra.Repositorio
{
    public class AcoesRepositorio : IAcoesRepositorio
    {
        public string strConexao;

        public AcoesRepositorio(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public void Inserir(Acoes acoes)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "INSERT INTO Acoes (CodAcao, Assunto, TipoAcao, DatInicio, DatFim, Status) " +
                        "Values(@CodAcao, @Assunto, @TipoAcao, @DatInicio, @DatFim, @Status);";

                    comando.Parameters.AddWithValue("CodAcao", Guid.NewGuid());
                    comando.Parameters.AddWithValue("Assunto", acoes.Assunto);
                    comando.Parameters.AddWithValue("TipoAcao", acoes.TipoAcao);
                    comando.Parameters.AddWithValue("DatInicio", acoes.DatInicio);
                    comando.Parameters.AddWithValue("DatFim", acoes.DatFim);
                    comando.Parameters.AddWithValue("Status", acoes.Status);
  

                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Alterar(Acoes acoes, Guid id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "UPDATE Acoes SET Assunto=@Assunto, TipoAcao=@TipoAcao, DatInicio=@DatInicio, DatFim=@DatFim, Status=@Status WHERE CodAcao=@CodAcao ";


                    comando.Parameters.AddWithValue("CodAcao", id.ToString());
                    comando.Parameters.AddWithValue("TipoAcao", acoes.TipoAcao);
                    comando.Parameters.AddWithValue("DatInicio", acoes.DatInicio);
                    comando.Parameters.AddWithValue("DatFim", acoes.DatFim);
                    comando.Parameters.AddWithValue("Status", acoes.Status);


                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Excluir(Guid id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "DELETE FROM Acoes WHERE CodAcao=@CodAcao ";

                    comando.Parameters.AddWithValue("CodAcao", id.ToString());

                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Acoes Procurar(Guid id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Acoes WHERE CodAcao=@CodAcao ";


                    comando.Parameters.AddWithValue("CodAcao", id.ToString());

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    Acoes acao = null;

                    while (leitor.NextResult())
                    {
                        acao = new Acoes();

                        acao.CodAcoes = Guid.Parse(leitor["CodAcao"].ToString());
                        acao.TipoAcao = leitor["TipoAcao"].ToString();
                        acao.DatInicio = Convert.ToDateTime(leitor["DatInicio"].ToString());
                        acao.DatFim = Convert.ToDateTime(leitor["DatFim"].ToString());
                        acao.Status = leitor["Status"].ToString();
                    }

                    return acao;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
