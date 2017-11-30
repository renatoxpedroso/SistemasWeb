using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaDeVoluntarios.Models
{
    public class TipoAcoes
    {
        public int Id { get; set; }
        public Guid codTipoAcao { get; set; }
        public string Nome { get; set; }
    }
}