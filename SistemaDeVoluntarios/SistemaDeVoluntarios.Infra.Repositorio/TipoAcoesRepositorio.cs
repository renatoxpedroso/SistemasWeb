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
    public class TipoAcoesRepositorio : ITipoAcoesRepositorio
    {
        public string strConexao;

        public TipoAcoesRepositorio(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public void Inserir(TipoAcoes tipoAcoes)
        {
            try { 
                using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
                {
                    con.Open();
                    using (NpgsqlTransaction transacao = con.BeginTransaction())
                    {
                        try
                        {
                            NpgsqlCommand comando = new NpgsqlCommand();
                            comando.Connection = con;
                            comando.CommandText = "INSERT INTO tipo_acao (CodTipoAcao, Nome) " +
                                "Values(@CodTipoAcao, @Nome);";

                            comando.Parameters.AddWithValue("CodTipoAcao", Guid.NewGuid());
                            comando.Parameters.AddWithValue("Nome", tipoAcoes.Nome);


                            comando.ExecuteNonQuery();
                            transacao.Commit();
                        }
                        catch(Exception x)
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

        public void Alterar(TipoAcoes tipoAcoes, Guid id)
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
                            comando.CommandText = "UPDATE Tipo_Acao SET Nome=@Nome WHERE CodTipoAcoes=@CodTipoAcao ";


                            comando.Parameters.AddWithValue("CodTipoAcao", id.ToString());
                            comando.Parameters.AddWithValue("Nome", tipoAcoes.Nome);


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
                            comando.CommandText = "DELETE FROM Tipo_Acao WHERE CodTipoAcao=@CodTipoAcao ";

                            comando.Parameters.AddWithValue("CodTipoAcao", id.ToString());

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


        public TipoAcoes Procurar(Guid id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Tipo_Acao WHERE CodTipoAcao=@CodTipoAcao ";


                    comando.Parameters.AddWithValue("CodTipoAcao", id.ToString());

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    TipoAcoes tipoAcao = null;

                    while (leitor.NextResult())
                    {
                        tipoAcao = new TipoAcoes();

                        tipoAcao.Id = Convert.ToInt32(leitor["Id"].ToString());
                        tipoAcao.codTipoAcao = Guid.Parse(leitor["CodTipoAcao"].ToString());
                        tipoAcao.Nome = leitor["Nome"].ToString();
                    }

                    return tipoAcao;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<TipoAcoes> ProcurarTodas()
        {
            List<TipoAcoes> tipoAcoes = new List<TipoAcoes>();

            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Tipo_Acao";

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    TipoAcoes tipoAcao = null;

                    while (leitor.Read())
                    {
                        tipoAcao = new TipoAcoes();

                        tipoAcao.Id = Convert.ToInt32(leitor["Id"].ToString());
                        tipoAcao.codTipoAcao = Guid.Parse(leitor["CodTipoAcao"].ToString());
                        tipoAcao.Nome = leitor["Nome"].ToString();

                        tipoAcoes.Add(tipoAcao);
                    }

                    return tipoAcoes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    } 
}
