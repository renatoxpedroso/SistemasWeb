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
            using(NpgsqlConnection con = new NpgsqlConnection(strConexao))
            {
                con.Open();
                NpgsqlCommand comando = new NpgsqlCommand();
                comando.Connection = con;
                comando.CommandText = "Insert into usuarios (CodUsuario, TipoUsuario, TipoPessoa, Nome, Email, Senha, DataNacimento, cpfCnpj, Telefone, Celular, Rua, Numero, Bairro, Cidade, Cep, Estado) " +
                    "Values(@CodUsuario, @TipoUsuario, @TipoPessoa, @Nome, @Email, @Senha, @DataNacimento, @cpfCnpj, @Telefone, @Celular, @Rua, @Numero, @Bairro, @Cidade, @Cep, @Estado);";

                comando.Parameters.AddWithValue("CodUsuario", usuarios.CodUsuario);

            }
        }

        public void Alterar(Usuarios usuarios, string id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(string id)
        {
            throw new NotImplementedException();
        }

        public Usuarios Procurar(Guid id)
        {
            throw new NotImplementedException();
        }

        public 
    }
}
