using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVoluntarios.Dominio.Entidades
{
    public class Acoes
    {
        public Guid CodAcoes { get; set; }
        public string Assunto { get; set; }
        public string TipoAcao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Status { get; set; }
    }
}
