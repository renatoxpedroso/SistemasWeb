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
        public DateTime DatInicio { get; set; }
        public DateTime DatFim { get; set; }
        public string Status { get; set; }
        public string Criador { get; set; }
    }
}