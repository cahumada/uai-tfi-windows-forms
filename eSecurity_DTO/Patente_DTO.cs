using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity_DTO
{
    public class Patente_DTO
    {
        public int PatenteId { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string DescCorta { get; set; }
    }
}
