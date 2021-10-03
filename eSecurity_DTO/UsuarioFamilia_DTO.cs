using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity_DTO
{
    public class UsuarioFamilia_DTO
    {
        public UsuarioFamilia_DTO()
        {
            Usuario = new Usuarios_DTO();
            Familia = new Familia_DTO();
        }

        public long UsuarioFamiliaId { get; set; }
        public Usuarios_DTO Usuario { get; set; }
        public Familia_DTO Familia { get; set; }
        public int DVH { get; set; }
    }
}
