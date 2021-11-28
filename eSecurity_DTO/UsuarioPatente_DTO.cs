using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity_DTO
{
    public class UsuarioPatente_DTO
    {
        public UsuarioPatente_DTO()
        {
            Usuario = new Usuarios_DTO();
            Patente = new Patente_DTO();
        }

        public long UsuarioPatenteId { get; set; }
        public Usuarios_DTO Usuario { get; set; }
        public Patente_DTO Patente { get; set; }
        public bool Denegado { get; set; }
        public string Familia { get; set; }
        public int DVH { get; set; }
        
    }
}
