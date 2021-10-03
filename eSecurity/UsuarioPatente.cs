using eDataAccess.Security;
using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSecurity
{
    public class UsuarioPatente
    {
        private UsuarioPatente_DTO _UsuarioPatente;

        #region Constructores
        public UsuarioPatente()
        {

        }

        public UsuarioPatente(int pUsuario)
        {
            ObtenerUsuarioPatente(pUsuario);
        }

        public UsuarioPatente(UsuarioPatente_DTO pUsuarioPatente)
        {
            _UsuarioPatente = pUsuarioPatente;
        }
        #endregion

        #region Propiedades
        public long UsuarioPatenteId { get { return _UsuarioPatente.UsuarioPatenteId; } }
        public Usuarios_DTO Usuario { get { return _UsuarioPatente.Usuario; } }
        public Patente_DTO Patente { get { return _UsuarioPatente.Patente; } }
        public int DVH { get { return _UsuarioPatente.DVH; } }
        #endregion

        #region Metodos
        public void Eliminar()
        {
            UsuarioPatente_DAL.EliminarUsuarioPatente(_UsuarioPatente.UsuarioPatenteId);
        }

        public void Guardar()
        {
            UsuarioPatente_DAL.AltaUsuarioPatente(_UsuarioPatente.Usuario.UsuarioId, _UsuarioPatente.Patente.PatenteId);
        }

        public void AltaUsuarioPatente(int pUsuarioId, int pPatenteId, bool pDenegar = false)
        {
            _UsuarioPatente.UsuarioPatenteId = 0;
            _UsuarioPatente.Usuario.UsuarioId = pUsuarioId;
            _UsuarioPatente.Patente.PatenteId = pPatenteId;

            Guardar();
        }

        public void EliminarUsuarioPatente(long pUsuarioPatenteId)
        {
            _UsuarioPatente.UsuarioPatenteId = pUsuarioPatenteId;

            Eliminar();
        }

        public List<UsuarioPatente> ObtenerUsuarioPatente(Usuarios pUsuario)
        {
            return ObtenerUsuarioPatente(pUsuario.UsuarioId);
        }

        public List<UsuarioPatente> ObtenerUsuarioPatente(int pUsuarioId)
        {
            var mCol = new List<UsuarioPatente>();

            foreach (var mUsuarioPatente in UsuarioPatente_DAL.ObtenerUsuarioPatente(pUsuarioId))
            {
                mCol.Add(new UsuarioPatente(mUsuarioPatente));
            }

            return mCol;
        }

        #endregion
    }
}
