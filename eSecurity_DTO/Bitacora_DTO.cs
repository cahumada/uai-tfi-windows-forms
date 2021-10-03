using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity_DTO
{
    public class Bitacora_DTO
    {
        public long LogId { get; set; }
        public int UsuarioId { get; set; }
        public int MovimientoId { get; set; }
        public int CriticidadId { get; set; }
        public DateTime FechaMovimient { get; set; }
        public int DVH { get; set; }
    }
}
