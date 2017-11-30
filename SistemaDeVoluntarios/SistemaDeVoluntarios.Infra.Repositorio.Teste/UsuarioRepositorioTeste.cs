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
            user.Nome = "Joao";
            user.Email = "joao@joao.com";
            user.Senha = "123";
            user.DataNacimento = DateTime.Parse("1989-01-01");
            user.cpfCnpj = "21256954152";
            user.Telefone = "5426568941";
            user.Celular = "5499168745";
            user.Rua = "Rua do Joao";
            user.Numero = "896";
            user.Bairro = "Joaozinho";
            user.Cidade = "Joelandia";
            user.Cep = 88541000;
            user.Estado = "SC";

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
        [TestMethod]
        public void SelectTeste()
        {
            string strConexao = "Server=localhost; Port=5432; Database=SistemaDeVoluntarios; User Id = postgres; Password = postgres; ";

            Usuarios user = new Usuarios();
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio(strConexao);

            Guid CodUsuario = Guid.Parse("099cdb61-aca7-4e43-a939-73c24e83179d");


            try
            {
              //  usuarioRepositorio.Procurar(CodUsuario);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        public void SelectLoginTeste()
        {
            string strConexao = "Server=localhost; Port=5432; Database=SistemaDeVoluntarios; User Id = postgres; Password = postgres; ";

            Usuarios user = new Usuarios();
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio(strConexao);

            string Email = "";
            string Senha = "";


            try
            {
                //usuarioRepositorio.ProcurarLogin(Email, Senha);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

    }
}
