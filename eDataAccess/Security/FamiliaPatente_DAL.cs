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
    public class FamiliaPatente_DAL
    {
        public static int AltaFamiliaPatente(int pFamiliaId, int pPatenteId)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nFamilia", DbType.Int32, pFamiliaId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nPatente", DbType.Int32, pPatenteId, null, null));

                return Commons.ExecuteNonQuery("AgregarFamiliaPatente", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int EliminarFamiliaPatente(long pFamiliaPatenteId)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nFamilyPatentId", DbType.Int64, pFamiliaPatenteId, null, null));

                return Commons.ExecuteNonQuery("EliminarFamiliaPatente", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static DataTable ObtenerFamiliaPatente(int pFamiliId)
        {
            var mParams = new List<DbParameter>();
            var mDt = new DataTable();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nFamily", DbType.Int32, pFamiliId, null, null));

                mDt = Commons.ExecuteDataTable("ObtenerFamiliaPatente", CommandType.StoredProcedure, mParams);

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

        public static List<FamiliaPatente_DTO> ObtenerFamiliaPatente()
        {
            var mCol = new List<FamiliaPatente_DTO>();
            var mDt = new DataTable();

            try
            {
                mDt = Commons.ExecuteDataTable("ObtenerFamiliaPatentes", CommandType.StoredProcedure, null);

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

        private static FamiliaPatente_DTO GetDTODR(DataRow pDr)
        {
            var mDTO = new FamiliaPatente_DTO();

            //FAMILIA
            mDTO.Familia.FamiliaId = (Convert.IsDBNull(pDr["Id_Familia"])) ? 0 : (int)pDr["Id_Familia"];
            mDTO.Familia.Descripcion = (Convert.IsDBNull(pDr["Descripcion_F"])) ? "" : pDr["Descripcion_F"].ToString();
            mDTO.Familia.DescCorta = (Convert.IsDBNull(pDr["Desc_Corta_F"])) ? "" : pDr["Desc_Corta_F"].ToString();
            mDTO.Familia.Fecha = (Convert.IsDBNull(pDr["Fecha_Sys_F"])) ? DateTime.MinValue : (DateTime)pDr["Fecha_Sys_F"];

            //PATENTE
            mDTO.Patente.PatenteId = (Convert.IsDBNull(pDr["Id_Patente"])) ? 0 : (int)pDr["Id_Patente"];
            mDTO.Patente.Descripcion = (Convert.IsDBNull(pDr["Descripcion_P"])) ? "" : pDr["Descripcion_P"].ToString();
            mDTO.Patente.DescCorta = (Convert.IsDBNull(pDr["Desc_Corta_P"])) ? "" : pDr["Desc_Corta_P"].ToString();
            mDTO.Patente.Fecha = (Convert.IsDBNull(pDr["Fecha_Sys_P"])) ? DateTime.MinValue : (DateTime)pDr["Fecha_Sys_P"];

            //USUARIOPATENTE
            mDTO.FamiliaPatenteId = (Convert.IsDBNull(pDr["Id_FamiliaPatente"])) ? 0 : (long)pDr["Id_FamiliaPatente"];
            mDTO.DVH = (Convert.IsDBNull(pDr["DVH"])) ? 0 : (int)pDr["DVH"];

            return mDTO;
        }
    }
}
