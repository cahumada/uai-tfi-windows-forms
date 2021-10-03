using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity_DTO
{
    public class FamiliaPatente_DTO
    {
        public FamiliaPatente_DTO()
        {
            Patente = new Patente_DTO();
            Familia = new Familia_DTO();
        }

        public long FamiliaPatenteId { get; set; }
        public Familia_DTO Familia { get; set; }
        public Patente_DTO Patente { get; set; }
        public int DVH{ get; set; }
    }
}
