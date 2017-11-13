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
    public class UsuarioAdministradorRepositorio : IUsuariosAdministradorRepositorio
    {
        public string strConexao;
        UsuarioAdministrador user = new UsuarioAdministrador();

        public UsuarioAdministradorRepositorio(string strConexao)
        {
            this.strConexao = strConexao;
        }

        public void Inserir(UsuarioAdministrador usuariosAdministrador)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "INSERT INTO Usuarios (CodUsuario, TipoUsuario, TipoPessoa, Nome, Email, Senha, DataNacimento, cpfCnpj, Telefone, Celular, Rua, Numero, Bairro, Cidade, Cep, Estado) " +
                        "Values(@CodUsuario, @TipoUsuario, @TipoPessoa, @Nome, @Email, @Senha, @DataNacimento, @cpfCnpj, @Telefone, @Celular, @Rua, @Numero, @Bairro, @Cidade, @Cep, @Estado);";

                    comando.Parameters.AddWithValue("CodUsuario", usuariosAdministrador.CodUsuario);
                    comando.Parameters.AddWithValue("TipoUsuario", 3);
                    comando.Parameters.AddWithValue("TipoPessoa", usuariosAdministrador.TipoPessoa);
                    comando.Parameters.AddWithValue("Nome", usuariosAdministrador.Nome);
                    comando.Parameters.AddWithValue("Email", usuariosAdministrador.Email);
                    comando.Parameters.AddWithValue("Senha", usuariosAdministrador.Senha);
                    comando.Parameters.AddWithValue("DataNacimento", usuariosAdministrador.DataNacimento);
                    comando.Parameters.AddWithValue("cpfCnpj", usuariosAdministrador.cpfCnpj);
                    comando.Parameters.AddWithValue("Telefone", usuariosAdministrador.Telefone);
                    comando.Parameters.AddWithValue("Celular", usuariosAdministrador.Celular);
                    comando.Parameters.AddWithValue("Rua", usuariosAdministrador.Rua);
                    comando.Parameters.AddWithValue("Numero", usuariosAdministrador.Numero);
                    comando.Parameters.AddWithValue("Bairro", usuariosAdministrador.Bairro);
                    comando.Parameters.AddWithValue("Cidade", usuariosAdministrador.Cidade);
                    comando.Parameters.AddWithValue("Cep", usuariosAdministrador.Cep);
                    comando.Parameters.AddWithValue("Estado", usuariosAdministrador.Estado);

                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Alterar(UsuarioAdministrador usuariosAdministrador, Guid id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "UPDATE Usuarios SET TipoPessoa=@TipoPessoa, Nome=@Nome, Email=@Email, Senha=@Senha, DataNacimento=@DataNecimento, cpfCnpj=@cpfCnpj, Telefone=@Telefone, Celular=@celular, Rua=@Rua, Numero=@Numero, Bairro=@Bairro, Cidade=@Cidade, Cep=@Cep, Estado=@Estado WHERE CodUsuario=@CodUsuario ";


                    comando.Parameters.AddWithValue("CodUsuario", id.ToString());
                    comando.Parameters.AddWithValue("TipoPessoa", usuariosAdministrador.TipoPessoa);
                    comando.Parameters.AddWithValue("Nome", usuariosAdministrador.Nome);
                    comando.Parameters.AddWithValue("Email", usuariosAdministrador.Email);
                    comando.Parameters.AddWithValue("Senha", usuariosAdministrador.Senha);
                    comando.Parameters.AddWithValue("DataNacimento", usuariosAdministrador.DataNacimento);
                    comando.Parameters.AddWithValue("cpfCnpj", usuariosAdministrador.cpfCnpj);
                    comando.Parameters.AddWithValue("Telefone", usuariosAdministrador.Telefone);
                    comando.Parameters.AddWithValue("Celular", usuariosAdministrador.Celular);
                    comando.Parameters.AddWithValue("Rua", usuariosAdministrador.Rua);
                    comando.Parameters.AddWithValue("Numero", usuariosAdministrador.Numero);
                    comando.Parameters.AddWithValue("Bairro", usuariosAdministrador.Bairro);
                    comando.Parameters.AddWithValue("Cidade", usuariosAdministrador.Cidade);
                    comando.Parameters.AddWithValue("Cep", usuariosAdministrador.Cep);
                    comando.Parameters.AddWithValue("Estado", usuariosAdministrador.Estado);

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
                    comando.CommandText = "DELETE FROM Usuarios WHERE CodUsuario=@CodUsuario ";

                    comando.Parameters.AddWithValue("CodUsuario", id.ToString());

                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public UsuarioAdministrador Procurar(Guid id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Usuarios WHERE CodUsuario=@CodUsuario ";


                    comando.Parameters.AddWithValue("CodUsuario", id.ToString());

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.NextResult())
                    {
                        user = new UsuarioAdministrador();

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
                        user.Cep = Convert.ToInt16(leitor["Cep"].ToString());
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

        public UsuarioAdministrador ProcurarLogin(string Email, string Senha)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                try
                {
                    con.Open();
                    NpgsqlCommand comando = new NpgsqlCommand();
                    comando.Connection = con;
                    comando.CommandText = "SELECT * FROM Usuarios WHERE Email=@Email and Senha=@Senha ";


                    comando.Parameters.AddWithValue("Email", Email);
                    comando.Parameters.AddWithValue("Senha", Senha);

                    NpgsqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.NextResult())
                    {
                        user = new UsuarioAdministrador();

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
                        user.Cep = Convert.ToInt16(leitor["Cep"].ToString());
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
    }   
}
