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
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
                {
                    con.Open();
                    using (NpgsqlTransaction transacao = con.BeginTransaction())
                    {
                        try
                        {
                            NpgsqlCommand comando = new NpgsqlCommand();
                            comando.Connection = con;
                            comando.CommandText = "INSERT INTO Acoes (CodAcao, Assunto, TipoAcao, DatInicio, DatFim, Status, Criador) " +
                                "Values(@CodAcao, @Assunto, @TipoAcao, @DatInicio, @DatFim, @Status, @Criador);";

                            comando.Parameters.AddWithValue("CodAcao", Guid.NewGuid());
                            comando.Parameters.AddWithValue("Assunto", acoes.Assunto);
                            comando.Parameters.AddWithValue("TipoAcao", acoes.TipoAcao);
                            comando.Parameters.AddWithValue("DatInicio", acoes.DatInicio);
                            comando.Parameters.AddWithValue("DatFim", acoes.DatFim);
                            comando.Parameters.AddWithValue("Status", acoes.Status);
                            comando.Parameters.AddWithValue("Criador", acoes.Criador);


                            comando.ExecuteNonQuery();
                            transacao.Commit();
                        }
                        catch (Exception x)
                        {
                            transacao.Rollback();
                            throw x;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Acoes acoes, Guid id)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
                {
                    con.Open();
                    using (NpgsqlTransaction transacao = con.BeginTransaction())
                    {
                        try
                        {
                            NpgsqlCommand comando = new NpgsqlCommand();
                            comando.Connection = con;
                            comando.CommandText = "UPDATE Acoes SET Assunto=@Assunto, TipoAcao=@TipoAcao, DatInicio=@DatInicio, DatFim=@DatFim, Status=@Status WHERE CodAcao=@CodAcao ";


                            comando.Parameters.AddWithValue("CodAcao", id.ToString());
                            comando.Parameters.AddWithValue("TipoAcao", acoes.TipoAcao);
                            comando.Parameters.AddWithValue("DatInicio", acoes.DatInicio);
                            comando.Parameters.AddWithValue("DatFim", acoes.DatFim);
                            comando.Parameters.AddWithValue("Status", acoes.Status);


                            comando.ExecuteNonQuery();
                            transacao.Commit();
                        }
                        catch (Exception x)
                        {
                            transacao.Rollback();
                            throw x;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Excluir(Guid id)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
                {
                    con.Open();
                    using (NpgsqlTransaction transacao = con.BeginTransaction())
                    {
                        try
                        {
                            NpgsqlCommand comando = new NpgsqlCommand();
                            comando.Connection = con;
                            comando.CommandText = "DELETE FROM Acoes WHERE CodAcao=@CodAcao ";

                            comando.Parameters.AddWithValue("CodAcao", id.ToString());

                            comando.ExecuteNonQuery();
                            transacao.Commit();
                        }
                        catch (Exception x)
                        {
                            transacao.Rollback();
                            throw x;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Acoes Procurar(int id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Acoes WHERE Id=@Id ";


                    comando.Parameters.AddWithValue("Id", id);

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    Acoes acao = null;

                    while (leitor.Read())
                    {
                        acao = new Acoes();

                        acao.Id =  Convert.ToInt32(leitor["Id"].ToString());
                        acao.CodAcoes = Guid.Parse(leitor["CodAcao"].ToString());
                        acao.Assunto = leitor["Assunto"].ToString();
                        acao.TipoAcao = leitor["TipoAcao"].ToString();
                        acao.DatInicio = Convert.ToDateTime(leitor["DatInicio"].ToString());
                        acao.DatFim = Convert.ToDateTime(leitor["DatFim"].ToString());
                        acao.Status = leitor["Status"].ToString();
                        acao.Criador = leitor["Criador"].ToString();
                    }

                    return acao;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Acoes> ProcurarTodas()
        {
            List<Acoes> acoes = new List<Acoes>();

            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Acoes";

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    Acoes acao = null;

                    while (leitor.Read())
                    {
                        acao = new Acoes();

                        acao.Id = Convert.ToInt32(leitor["Id"].ToString());
                        acao.CodAcoes = Guid.Parse(leitor["CodAcao"].ToString());
                        acao.Assunto = leitor["assunto"].ToString();
                        acao.TipoAcao = leitor["TipoAcao"].ToString();
                        acao.DatInicio = Convert.ToDateTime(leitor["DatInicio"].ToString());
                        acao.DatFim = Convert.ToDateTime(leitor["DatFim"].ToString());
                        acao.Status = leitor["Status"].ToString();
                        acao.Criador = leitor["Criador"].ToString();

                        acoes.Add(acao);
                    }

                    return acoes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Acoes> ProcurarAcoesRecente()
        {
            List<Acoes> acoes = new List<Acoes>();
            DateTime localDate = DateTime.Now;
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Acoes WHERE datInicio >= @Data";

                    comando.Parameters.AddWithValue("Data", localDate);

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    Acoes acao = null;

                    while (leitor.Read())
                    {
                        acao = new Acoes();

                        acao.Id = Convert.ToInt32(leitor["Id"].ToString());
                        acao.CodAcoes = Guid.Parse(leitor["CodAcao"].ToString());
                        acao.Assunto = leitor["assunto"].ToString();
                        acao.TipoAcao = leitor["TipoAcao"].ToString();
                        acao.DatInicio = Convert.ToDateTime(leitor["DatInicio"].ToString());
                        acao.DatFim = Convert.ToDateTime(leitor["DatFim"].ToString());
                        acao.Status = leitor["Status"].ToString();
                        acao.Criador = leitor["Criador"].ToString();

                        acoes.Add(acao);
                    }

                    return acoes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Acoes> ProcurarAcoesAndamento()
        {
            List<Acoes> acoes = new List<Acoes>();
            DateTime localDate = DateTime.Now;
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Acoes WHERE datInicio <= @Data and datFim <= @Data";

                    comando.Parameters.AddWithValue("Data", localDate);

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    Acoes acao = null;

                    while (leitor.Read())
                    {
                        acao = new Acoes();

                        acao.Id = Convert.ToInt32(leitor["Id"].ToString());
                        acao.CodAcoes = Guid.Parse(leitor["CodAcao"].ToString());
                        acao.Assunto = leitor["assunto"].ToString();
                        acao.TipoAcao = leitor["TipoAcao"].ToString();
                        acao.DatInicio = Convert.ToDateTime(leitor["DatInicio"].ToString());
                        acao.DatFim = Convert.ToDateTime(leitor["DatFim"].ToString());
                        acao.Status = leitor["Status"].ToString();
                        acao.Criador = leitor["Criador"].ToString();

                        acoes.Add(acao);
                    }

                    return acoes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Acoes> ProcurarAcoesConcluidas()
        {
            List<Acoes> acoes = new List<Acoes>();
            DateTime localDate = DateTime.Now;
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Acoes WHERE datFim <= @Data";

                    comando.Parameters.AddWithValue("Data", localDate);

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    Acoes acao = null;

                    while (leitor.Read())
                    {
                        acao = new Acoes();

                        acao.Id = Convert.ToInt32(leitor["Id"].ToString());
                        acao.CodAcoes = Guid.Parse(leitor["CodAcao"].ToString());
                        acao.Assunto = leitor["assunto"].ToString();
                        acao.TipoAcao = leitor["TipoAcao"].ToString();
                        acao.DatInicio = Convert.ToDateTime(leitor["DatInicio"].ToString());
                        acao.DatFim = Convert.ToDateTime(leitor["DatFim"].ToString());
                        acao.Status = leitor["Status"].ToString();
                        acao.Criador = leitor["Criador"].ToString();

                        acoes.Add(acao);
                    }

                    return acoes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
