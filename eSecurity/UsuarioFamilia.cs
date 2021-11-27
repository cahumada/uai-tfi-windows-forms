using eDataAccess.Security;
using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eFramework;

namespace eSecurity
{
    public class UsuarioFamilia : ObjetoSimple
    {
        private UsuarioFamilia_DTO _UsuarioFamilia = new UsuarioFamilia_DTO();

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
        public override void Eliminar()
        {
            UsuarioFamilia_DAL.EliminarUsuarioFamilia(_UsuarioFamilia.Usuario.UsuarioId, _UsuarioFamilia.Familia.FamiliaId);
        }

        public override DataSet ObtenerDataSet()
        {
            return new DataSet();
        }

        public override void Guardar()
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

        public void EliminarUsuarioFamilia(int pUsuarioId, int pFamiliaId)
        {
            _UsuarioFamilia.UsuarioFamiliaId = 0;
            _UsuarioFamilia.Usuario.UsuarioId = pUsuarioId;
            _UsuarioFamilia.Familia.FamiliaId = pFamiliaId;

            Eliminar();
        }

        public DataTable ObtenerUsuarioFamilia(Usuarios pUsuario)
        {
            return ObtenerUsuarioFamilia(pUsuario.UsuarioId);
        }

        public DataTable ObtenerUsuarioFamilia(int pUsuarioId)
        {
            var dataTable = UsuarioFamilia_DAL.ObtenerUsuarioFamilia(pUsuarioId);


            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
                {
                    if (!Convert.IsDBNull(dataTable.Rows[i][1]) && // [1] = Descripcion
                        !string.IsNullOrEmpty(dataTable.Rows[i][1].ToString()))
                        dataTable.Rows[i][1] = dataTable.Rows[i][1].ToString();
                    // dataTable.Rows[i][1] = Encriptado.DataDecryption(dataTable.Rows[i][1].ToString()); //TODO
                }
            }

            return dataTable;
        }
        #endregion
    }
}
