using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeVoluntarios.Models
{
    public class UsuariosAdministrador
    {
        public Guid CodUsuario { get; set; }
        public int TipoUsuario { get; set; }
        public int TipoPessoa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNacimento { get; set; }
        public string cpfCnpj { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int Cep { get; set; }
        public string Estado { get; set; }
    }
}