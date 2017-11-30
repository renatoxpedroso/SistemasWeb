using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeVoluntarios.Models
{
    public class Acoes
    {
        public int Id { get; set; }
        public Guid CodAcoes { get; set; }
        public string Assunto { get; set; }
        public string TipoAcao { get; set; }
        public string DatInicio { get; set; }
        public string DatFim { get; set; }
        public string Status { get; set; }
    }
}