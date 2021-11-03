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
    public class Idioma_DAL
    {
        public static Idioma_DTO ObtenerIdiomaPorDefecto(int pUsuarioId = 0)
        {
            var mParams = new List<DbParameter>();
            var mDt = new DataTable();

            try
            {
                if (pUsuarioId > 0)
                {
                    mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUsuarioId, null, null));
                }

                mDt = Commons.ExecuteDataTable("ObtenerIdiomaUsuario", CommandType.StoredProcedure, (pUsuarioId > 0) ? mParams : null);

                if (mDt != null)
                {
                    return GetDTODR(mDt.Rows[0]);
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Idioma_DTO ObtenerIdioma(int pIdioma = 0)
        {
            var mParams = new List<DbParameter>();
            var mDt = new DataTable();

            try
            {
                if (pIdioma > 0)
                {
                    mParams.Add((DbParameter)Commons.getNewParameter("nIdioma", DbType.Int32, pIdioma, null, null));
                }

                mDt = Commons.ExecuteDataTable("ObtenerIdioma", CommandType.StoredProcedure, (pIdioma > 0) ? mParams : null);

                if (mDt != null)
                {
                    return GetDTODR(mDt.Rows[0]);
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Idioma_DTO> ObtenerIdiomas()
        {
            var mCol = new List<Idioma_DTO>();
            var mDt = new DataTable();

            try
            {
                mDt = Commons.ExecuteDataTable("ObtenerIdiomas", CommandType.StoredProcedure, null);

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

        private static Idioma_DTO GetDTODR(DataRow pDr)
        {
            var mDTO = new Idioma_DTO();

            mDTO.IdiomaId = (Convert.IsDBNull(pDr["Id_Idioma"])) ? 0 : (int)pDr["Id_Idioma"];
            mDTO.Descripcion = (Convert.IsDBNull(pDr["Descripcion"])) ? "" : pDr["Descripcion"].ToString();
            mDTO.DescCorta = (Convert.IsDBNull(pDr["Desc_Corta"])) ? "" : pDr["Desc_Corta"].ToString();
            mDTO.Fecha = (Convert.IsDBNull(pDr["Fecha_Sys"])) ? DateTime.MinValue : (DateTime)pDr["Fecha_Sys"];

            return mDTO;
        }
    }
}
