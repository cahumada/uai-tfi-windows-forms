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
    public class Familia_DAL
    {
        public static int AltaFamilia(Familia_DTO pFamilia)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nFamilia", DbType.Int32, pFamilia.FamiliaId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("sDescripcion", DbType.String, pFamilia.Descripcion, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("sDesc_Corta", DbType.String, pFamilia.DescCorta, null, null));

                return Commons.ExecuteNonQuery("AgregarFamilia", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int EliminarFamilia(long pId)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nFamilia", DbType.Int32, pId, null, null));

                return Commons.ExecuteNonQuery("EliminarFamilia", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int ModificarFamilia(Familia_DTO pFamilia)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nFamilia", DbType.Int32, pFamilia.FamiliaId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("sDescripcion", DbType.String, pFamilia.Descripcion, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("sDesc_Corta", DbType.String, pFamilia.DescCorta, null, null));

                return Commons.ExecuteNonQuery("ActualizarFamilia", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Familia_DTO ObtenerFamilia(long pId)
        {
            var mParams = new List<DbParameter>();
            var mDt = new DataTable();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nFamilia", DbType.Int32, pId, null, null));

                mDt = Commons.ExecuteDataTable("ObtenerFamilia", CommandType.StoredProcedure, mParams);

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

        public static List<Familia_DTO> ObtenerFamilia()
        {
            var mCol = new List<Familia_DTO>();
            var mDt = new DataTable();

            try
            {
                mDt = Commons.ExecuteDataTable("ObtenerFamilias", CommandType.StoredProcedure, null);

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

        private static Familia_DTO GetDTODR(DataRow pDr)
        {
            var mDTO = new Familia_DTO();

            mDTO.FamiliaId = (Convert.IsDBNull(pDr["Id_Familia"])) ? 0 : (int)pDr["Id_Familia"];
            mDTO.Descripcion = (Convert.IsDBNull(pDr["Descripcion"])) ? "" : pDr["Descripcion"].ToString();
            mDTO.DescCorta = (Convert.IsDBNull(pDr["Desc_Corta"])) ? "" : pDr["Desc_Corta"].ToString();
            mDTO.Fecha = (Convert.IsDBNull(pDr["Fecha_Sys"])) ? DateTime.MinValue : (DateTime)pDr["Fecha_Sys"];

            return mDTO;
        }
    }
}
