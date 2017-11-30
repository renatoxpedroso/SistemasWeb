using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVoluntarios.Dominio.Entidades
{
    public class TipoAcoes
    {
        public int Id { get; set; }
        public Guid codTipoAcao { get; set; }
        public string Nome { get; set; }
     
    }
}
