using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity_DTO
{
    public class Usuarios_DTO
    {
        #region Propiedades
        public int UsuarioId { get; set; }
        public int IdiomaId { get; set; }
        public string Nik { get; set; }
        public string Contrasena { get; set; }
        public short Intentos { get; set; }
        public bool Bloqueado { get; set; }
        public int DVH { get; set; }
        public bool Admin { get; set; }
        #endregion
    }
}
