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
    public class UsuarioRepositorio : IUsuariosRepositorio
    {
        public string strConexao;

        public UsuarioRepositorio(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public void Inserir(Usuarios usuarios)
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
                            comando.CommandText = "INSERT INTO Usuarios (CodUsuario, TipoUsuario, TipoPessoa, Nome, Email, Senha, DataNacimento, cpfCnpj, Telefone, Celular, Rua, Numero, Bairro, Cidade, Cep, Estado, Status) " +
                                "Values(@CodUsuario, @TipoUsuario, @TipoPessoa, @Nome, @Email, @Senha, @DataNacimento, @cpfCnpj, @Telefone, @Celular, @Rua, @Numero, @Bairro, @Cidade, @Cep, @Estado, @Status);";

                            comando.Parameters.AddWithValue("CodUsuario", Guid.NewGuid());
                            comando.Parameters.AddWithValue("TipoUsuario", usuarios.TipoUsuario);
                            comando.Parameters.AddWithValue("TipoPessoa", usuarios.TipoPessoa);
                            comando.Parameters.AddWithValue("Nome", usuarios.Nome);
                            comando.Parameters.AddWithValue("Email", usuarios.Email);
                            comando.Parameters.AddWithValue("Senha", usuarios.Senha);
                            comando.Parameters.AddWithValue("DataNacimento", usuarios.DataNacimento);
                            comando.Parameters.AddWithValue("cpfCnpj", usuarios.cpfCnpj);
                            comando.Parameters.AddWithValue("Telefone", usuarios.Telefone);
                            comando.Parameters.AddWithValue("Celular", usuarios.Celular);
                            comando.Parameters.AddWithValue("Rua", usuarios.Rua);
                            comando.Parameters.AddWithValue("Numero", usuarios.Numero);
                            comando.Parameters.AddWithValue("Bairro", usuarios.Bairro);
                            comando.Parameters.AddWithValue("Cidade", usuarios.Cidade);
                            comando.Parameters.AddWithValue("Cep", usuarios.Cep);
                            comando.Parameters.AddWithValue("Estado", usuarios.Estado);
                            comando.Parameters.AddWithValue("Status", usuarios.Status);

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
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Alterar(Usuarios usuarios, Guid id)
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
                            comando.CommandText = "UPDATE Usuarios SET TipoUsuario=@TipoUsuario, TipoPessoa=@TipoPessoa, Nome=@Nome, Email=@Email, Senha=@Senha, DataNacimento=@DataNecimento, cpfCnpj=@cpfCnpj, Telefone=@Telefone, Celular=@celular, Rua=@Rua, Numero=@Numero, Bairro=@Bairro, Cidade=@Cidade, Cep=@Cep, Estado=@Estado, Status=@Status WHERE CodUsuario=@CodUsuario ";


                            comando.Parameters.AddWithValue("CodUsuario", id.ToString());
                            comando.Parameters.AddWithValue("TipoUsuario", usuarios.TipoUsuario);
                            comando.Parameters.AddWithValue("TipoPessoa", usuarios.TipoPessoa);
                            comando.Parameters.AddWithValue("Nome", usuarios.Nome);
                            comando.Parameters.AddWithValue("Email", usuarios.Email);
                            comando.Parameters.AddWithValue("Senha", usuarios.Senha);
                            comando.Parameters.AddWithValue("DataNacimento", usuarios.DataNacimento);
                            comando.Parameters.AddWithValue("cpfCnpj", usuarios.cpfCnpj);
                            comando.Parameters.AddWithValue("Telefone", usuarios.Telefone);
                            comando.Parameters.AddWithValue("Celular", usuarios.Celular);
                            comando.Parameters.AddWithValue("Rua", usuarios.Rua);
                            comando.Parameters.AddWithValue("Numero", usuarios.Numero);
                            comando.Parameters.AddWithValue("Bairro", usuarios.Bairro);
                            comando.Parameters.AddWithValue("Cidade", usuarios.Cidade);
                            comando.Parameters.AddWithValue("Cep", usuarios.Cep);
                            comando.Parameters.AddWithValue("Estado", usuarios.Estado);
                            comando.Parameters.AddWithValue("Status", usuarios.Status);

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
                            comando.CommandText = "DELETE FROM Usuarios WHERE CodUsuario=@CodUsuario ";

                            comando.Parameters.AddWithValue("CodUsuario", id.ToString());

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

        public Usuarios ProcurarCodigo(int id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Usuarios WHERE Id=@Id ";


                    comando.Parameters.AddWithValue("Id", id);

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    Usuarios user = null;

                    while (leitor.Read())
                    {
                        user = new Usuarios();

                        user.Id = Convert.ToInt32(leitor["Id"].ToString());
                        user.CodUsuario = Guid.Parse(leitor["CodUsuario"].ToString());
                        user.TipoUsuario = Convert.ToInt16(leitor["TipoUsuario"].ToString());
                        user.TipoPessoa = Convert.ToInt16(leitor["TipoPessoa"].ToString());
                        user.Nome = leitor["Nome"].ToString();
                        user.Email = leitor["Email"].ToString();
                        user.Senha = leitor["Senha"].ToString();
                        user.DataNacimento = Convert.ToDateTime(leitor["DataNacimento"].ToString());
                        user.cpfCnpj = leitor["cpfCnpj"].ToString();
                        user.Telefone = leitor["Telefone"].ToString();
                        user.Celular = leitor["Celular"].ToString();
                        user.Rua = leitor["Rua"].ToString();
                        user.Numero = leitor["Numero"].ToString();
                        user.Bairro = leitor["Bairro"].ToString();
                        user.Cidade = leitor["Cidade"].ToString();
                        user.Cep = Convert.ToInt32(leitor["Cep"].ToString());
                        user.Estado = leitor["Estado"].ToString();
                        user.Status = Convert.ToInt16(leitor["Status"].ToString());
                    }

                    return user;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Usuarios ProcurarLogin(Usuarios usuarios)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    //comando.CommandText = "SELECT * FROM usuarios WHERE email= '"+usuarios.Email+"' and senha= '"+usuarios.Senha+"'";
                    comando.CommandText = "SELECT * FROM usuarios WHERE email=@Email and senha=@Senha ";


                    comando.Parameters.AddWithValue("Email", usuarios.Email);
                    comando.Parameters.AddWithValue("Senha", usuarios.Senha);

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    Usuarios user = null;

                    while (leitor.Read())
                    {
                        user = new Usuarios();

                        user.Id = Convert.ToInt32(leitor["Id"].ToString());
                        user.CodUsuario = Guid.Parse(leitor["CodUsuario"].ToString());
                        user.TipoUsuario = Convert.ToInt16(leitor["TipoUsuario"].ToString());
                        user.TipoPessoa = Convert.ToInt16(leitor["TipoPessoa"].ToString());
                        user.Nome = leitor["Nome"].ToString();
                        user.Email = leitor["Email"].ToString();
                        user.Senha = leitor["Senha"].ToString();
                        user.DataNacimento = Convert.ToDateTime(leitor["DataNacimento"].ToString());
                        user.cpfCnpj = leitor["cpfCnpj"].ToString();
                        user.Telefone = leitor["Telefone"].ToString();
                        user.Celular = leitor["Celular"].ToString();
                        user.Rua = leitor["Rua"].ToString();
                        user.Numero = leitor["Numero"].ToString();
                        user.Bairro = leitor["Bairro"].ToString();
                        user.Cidade = leitor["Cidade"].ToString();
                        user.Cep = Convert.ToInt32(leitor["Cep"].ToString());
                        user.Estado = leitor["Estado"].ToString();
                    }

                    return user;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Usuarios> ProcurarTodos()
        {
            List<Usuarios> usuarios = new List<Usuarios>();

            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM usuarios";


                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    Usuarios user = null;

                    while (leitor.Read())
                    {
                        user = new Usuarios();

                        user.Id = Convert.ToInt32(leitor["Id"].ToString());
                        user.CodUsuario = Guid.Parse(leitor["CodUsuario"].ToString());
                        user.TipoUsuario = Convert.ToInt16(leitor["TipoUsuario"].ToString());
                        user.TipoPessoa = Convert.ToInt16(leitor["TipoPessoa"].ToString());
                        user.Nome = leitor["Nome"].ToString();
                        user.Email = leitor["Email"].ToString();
                        user.Senha = leitor["Senha"].ToString();
                        user.DataNacimento = Convert.ToDateTime(leitor["DataNacimento"].ToString());
                        user.cpfCnpj = leitor["cpfCnpj"].ToString();
                        user.Telefone = leitor["Telefone"].ToString();
                        user.Celular = leitor["Celular"].ToString();
                        user.Rua = leitor["Rua"].ToString();
                        user.Numero = leitor["Numero"].ToString();
                        user.Bairro = leitor["Bairro"].ToString();
                        user.Cidade = leitor["Cidade"].ToString();
                        user.Cep = Convert.ToInt32(leitor["Cep"].ToString());
                        user.Estado = leitor["Estado"].ToString();
                        user.Status = Convert.ToInt16(leitor["Status"].ToString());

                        usuarios.Add(user);
                    }

                    return usuarios;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void AlterarStatus(int status, int id)
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
                            comando.CommandText = "UPDATE Usuarios SET Status=@Status WHERE Id=@Id ";

                            comando.Parameters.AddWithValue("Status", status);
                            comando.Parameters.AddWithValue("Id", id);

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
    }
}
