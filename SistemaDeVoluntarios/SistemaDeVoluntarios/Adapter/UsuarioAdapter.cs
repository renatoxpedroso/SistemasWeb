using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaDeVoluntarios.Models;
using SistemaDeVoluntarios.Dominio.Entidades;


namespace SistemaDeVoluntarios.Adapter
{
    public abstract class UsuarioAdapter
    {
        public static Models.Usuarios ParaModel(SistemaDeVoluntarios.Dominio.Entidades.Usuarios usuario)
        {
            return new Models.Usuarios()
            {
                Bairro = usuario.Bairro,
                Celular = usuario.Celular,
                Cep = usuario.Cep,
                Cidade = usuario.Cidade,
                CodUsuario = usuario.CodUsuario,
                cpfCnpj = usuario.cpfCnpj,
                DataNacimento = usuario.DataNacimento,
                Email = usuario.Email,
                Estado = usuario.Estado,
                Nome = usuario.Nome,
                Numero = usuario.Numero,
                Rua = usuario.Rua,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone,
                TipoPessoa = usuario.TipoPessoa,
                TipoUsuario = usuario.TipoUsuario
            };
        }


        public static List<Models.Usuarios> ParaModel(List< SistemaDeVoluntarios.Dominio.Entidades.Usuarios> usuarios)
        {

            List<Models.Usuarios> usuariosModel = new List<Models.Usuarios>();

            foreach(var usu in usuarios)
            {
                usuariosModel.Add(ParaModel(usu));

            }

            return usuariosModel;
        }


        public static SistemaDeVoluntarios.Dominio.Entidades.Usuarios ParaDominio(Models.Usuarios usuario)
        {
            return new SistemaDeVoluntarios.Dominio.Entidades.Usuarios()
            {
                Bairro = usuario.Bairro,
                Celular = usuario.Celular,
                Cep = usuario.Cep,
                Cidade = usuario.Cidade,
                CodUsuario = usuario.CodUsuario,
                cpfCnpj = usuario.cpfCnpj,
                DataNacimento = usuario.DataNacimento,
                Email = usuario.Email,
                Estado = usuario.Estado,
                Nome = usuario.Nome,
                Numero = usuario.Numero,
                Rua = usuario.Rua,
                Senha = usuario.Senha,
                Telefone = usuario.Telefone,
                TipoPessoa = usuario.TipoPessoa,
                TipoUsuario = usuario.TipoUsuario
            };
        }
    }
}