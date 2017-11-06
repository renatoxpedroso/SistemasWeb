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

        public void Alterar(Acoes acoes, string id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "UPDATE Acoes SET Assunto=@Assunto, TipoAcao=@TipoAcao, DataInicio=@DataInicio, DataFim=@DataFim, Status=@Status WHERE CodAcao=@CodAcao ";


                    comando.Parameters.AddWithValue("CodAcao", id);
                    comando.Parameters.AddWithValue("TipoAcao", acoes.TipoAcao);
                    comando.Parameters.AddWithValue("DataInicio", acoes.DataInicio);
                    comando.Parameters.AddWithValue("DataFim", acoes.DataFim);
                    comando.Parameters.AddWithValue("Status", acoes.Status);
 

                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Excluir(string id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "DELETE FROM Acoes WHERE CodAcao=@CodAcao ";

                    comando.Parameters.AddWithValue("CodAcao", id);

                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
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
                    comando.CommandText = "INSERT INTO Acoes (CodAcao, Assunto, TipoAcao, DataInicio, DataFim, Status) " +
                        "Values(@CodAcao, @Assunto, @TipoAcao, @DataInicio, @DataFim, @Status);";

                    comando.Parameters.AddWithValue("CodAcao", acoes.CodAcoes);
                    comando.Parameters.AddWithValue("Assunto", acoes.Assunto);
                    comando.Parameters.AddWithValue("TipoAcao", acoes.TipoAcao);
                    comando.Parameters.AddWithValue("DataInicio", acoes.DataInicio);
                    comando.Parameters.AddWithValue("DataFim", acoes.DataFim);
                    comando.Parameters.AddWithValue("Status", acoes.Status);
  

                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Acoes Procurar(string id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Acoes WHERE CodAcao=@CodAcao ";


                    comando.Parameters.AddWithValue("CodAcao", id);

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    Acoes acao = null;

                    while (leitor.NextResult())
                    {
                        acao = new Acoes();

                        acao.CodAcoes = Guid.Parse(leitor["CodAcao"].ToString());
                        acao.TipoAcao = leitor["TipoAcao"].ToString();
                        acao.DataInicio = Convert.ToDateTime(leitor["DataInicio"].ToString());
                        acao.DataFim = Convert.ToDateTime(leitor["DataFim"].ToString());
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
