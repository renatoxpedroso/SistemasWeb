using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SistemaDeVoluntarios.Dominio.Entidades;
using SistemaDeVoluntarios.Dominio.Repositorios;
using SistemaDeVoluntarios.Infra.Repositorio;

namespace SistemaDeVoluntarios.Infra.Repositorio.Teste
{
    [TestClass]
    public class UsuarioRepositorioTeste
    {
        [TestMethod]
        public void InsertTeste()
        {
            string strConexao = "Server=localhost; Port=5432; Database=SistemaDeVoluntarios; User Id = postgres; Password = postgres; ";

            Usuarios user = new Usuarios();
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio(strConexao);

            user.CodUsuario = Guid.NewGuid();
            user.TipoUsuario = 3;
            user.TipoPessoa = 2;
            user.Nome = "";
            user.Email = "";
            user.Senha = "";
            user.DataNacimento = DateTime.Parse("");
            user.cpfCnpj = "";
            user.Telefone = "";
            user.Celular = "";
            user.Rua = "";
            user.Numero = "";
            user.Bairro = "";
            user.Cidade = "";
            user.Cep = 8;
            user.Estado = "";

            try
            {
                usuarioRepositorio.Inserir(user);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        public void SelectTeste()
        {
            string strConexao = "Server=localhost; Port=5432; Database=SistemaDeVoluntarios; User Id = postgres; Password = postgres; ";

            Usuarios user = new Usuarios();
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio(strConexao);

            string CodUsuario = "099cdb61-aca7-4e43-a939-73c24e83179d";


            try
            {
                usuarioRepositorio.Procurar(CodUsuario);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        public void SelectLoginTeste()
        {
            string strConexao = "Server=localhost; Port=5432; Database=SistemaDeVoluntarios; User Id = postgres; Password = postgres; ";

            Usuarios user = new Usuarios();
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio(strConexao);

            string Email = "";
            string Senha = "";


            try
            {
                usuarioRepositorio.ProcurarLogin(Email, Senha);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
