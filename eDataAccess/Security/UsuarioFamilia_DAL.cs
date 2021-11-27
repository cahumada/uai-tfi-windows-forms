using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDataAccess.Security
{
    public class UsuarioFamilia_DAL
    {
        public static int AltaUsuarioFamilia(int pUsuarioId, int pFamilia)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUsuarioId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nFamilia", DbType.Int32, pFamilia, null, null));

                return Commons.ExecuteNonQuery("AltaUsuarioFamilia", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int EliminarUsuarioFamilia(int pUsuarioId, int pFamilia)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUsuarioId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nFamilia", DbType.Int32, pFamilia, null, null));

                return Commons.ExecuteNonQuery("EliminarUsuarioFamilia", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable ObtenerUsuarioFamilia(long pUsuarioId)
        {
            var mParams = new List<DbParameter>();
            var mDt = new DataTable();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("@nUsuario", DbType.Int32, pUsuarioId, null, null));

                mDt = Commons.ExecuteDataTable("ObtenerUsuarioFamilia", CommandType.StoredProcedure, mParams);

                if (mDt != null)
                {
                    return mDt;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<UsuarioFamilia_DTO> ObtenerUsuarioFamilia()
        {
            var mCol = new List<UsuarioFamilia_DTO>();
            var mDt = new DataTable();

            try
            {
                mDt = Commons.ExecuteDataTable("ObtenerUsuarioFamilias", CommandType.StoredProcedure, null);

                if (mDt != null)
                {
                    foreach (DataRow mDr in mDt.Rows)
                    {
                        mCol.Add(GetDTODR(mDr));
                    }

                    return mCol;
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static UsuarioFamilia_DTO GetDTODR(DataRow pDr)
        {
            var mDTO = new UsuarioFamilia_DTO();

            //USUARIO
            mDTO.Usuario.UsuarioId = (Convert.IsDBNull(pDr["Id_Usuario"])) ? 0 : (int)pDr["Id_Usuario"];
            mDTO.Usuario.Nik = (Convert.IsDBNull(pDr["Nik"])) ? "" : pDr["Nik"].ToString();
            mDTO.Usuario.Contrasena = (Convert.IsDBNull(pDr["Contrasena"])) ? "" : pDr["Contrasena"].ToString();
            mDTO.Usuario.IdiomaId = (Convert.IsDBNull(pDr["Id_Idioma"])) ? 0 : (int)pDr["Id_Idioma"];
            mDTO.Usuario.Intentos = (Convert.IsDBNull(pDr["Intentos"])) ? (short)0 : (short)pDr["Intentos"];
            mDTO.Usuario.Bloqueado = (Convert.IsDBNull(pDr["Bloqueado"])) ? false : (bool)pDr["Bloqueado"];

            //PATENTE
            mDTO.Familia.FamiliaId = (Convert.IsDBNull(pDr["Id_Familia"])) ? 0 : (int)pDr["Id_Familia"];
            mDTO.Familia.Descripcion = (Convert.IsDBNull(pDr["Descripcion"])) ? "" : pDr["Descripcion"].ToString();
            mDTO.Familia.DescCorta = (Convert.IsDBNull(pDr["Desc_Corta"])) ? "" : pDr["Desc_Corta"].ToString();
            mDTO.Familia.Fecha = (Convert.IsDBNull(pDr["Fecha_Sys"])) ? DateTime.MinValue : (DateTime)pDr["Fecha_Sys"];

            //USUARIOPATENTE
            mDTO.UsuarioFamiliaId = (Convert.IsDBNull(pDr["Id_UsuarioFamilia"])) ? 0 : (long)pDr["Id_UsuarioFamilia"];
            mDTO.DVH = (Convert.IsDBNull(pDr["DVH"])) ? 0 : (int)pDr["DVH"];

            return mDTO;
        }
    }
}
