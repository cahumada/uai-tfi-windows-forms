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
    public class UsuarioFamilia
    {
        private UsuarioFamilia_DTO _UsuarioFamilia;

        #region Constructores
        public UsuarioFamilia()
        {

        }

        public UsuarioFamilia(int pUsuario)
        {
            ObtenerUsuarioFamilia(pUsuario);
        }

        public UsuarioFamilia(UsuarioFamilia_DTO pUsuarioFamilia)
        {
            _UsuarioFamilia = pUsuarioFamilia;
        }
        #endregion

        #region Propiedades
        public long UsuarioFamiliaId { get { return _UsuarioFamilia.UsuarioFamiliaId; } }
        public Usuarios_DTO Usuario { get { return _UsuarioFamilia.Usuario; } }
        public Familia_DTO Familia { get { return _UsuarioFamilia.Familia; } }
        public int DVH { get { return _UsuarioFamilia.DVH; } }
        #endregion

        #region Metodos
        public void Eliminar()
        {
            UsuarioFamilia_DAL.EliminarUsuarioFamilia(_UsuarioFamilia.UsuarioFamiliaId);
        }

        public void Guardar()
        {
            UsuarioFamilia_DAL.AltaUsuarioFamilia(_UsuarioFamilia.Usuario.UsuarioId, _UsuarioFamilia.Familia.FamiliaId);
        }

        public void AltaUsuarioFamilia(int pUsuarioId, int pFamiliaId)
        {
            _UsuarioFamilia.UsuarioFamiliaId = 0;
            _UsuarioFamilia.Usuario.UsuarioId = pUsuarioId;
            _UsuarioFamilia.Familia.FamiliaId = pFamiliaId;

            Guardar();
        }

        public void EliminarUsuarioFamilia(long pUsuarioFamiliaId)
        {
            _UsuarioFamilia.UsuarioFamiliaId = pUsuarioFamiliaId;

            Eliminar();
        }

        public List<UsuarioFamilia> ObtenerUsuarioFamilia(Usuarios pUsuario)
        {
            return ObtenerUsuarioFamilia(pUsuario.UsuarioId);
        }

        public List<UsuarioFamilia> ObtenerUsuarioFamilia(int pUsuarioId)
        {
            var mCol = new List<UsuarioFamilia>();

            foreach (var mUsuarioFamilia in UsuarioFamilia_DAL.ObtenerUsuarioFamilia(pUsuarioId))
            {
                mCol.Add(new UsuarioFamilia(mUsuarioFamilia));
            }

            return mCol;
        }
        #endregion
    }
}
