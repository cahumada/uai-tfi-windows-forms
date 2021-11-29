using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eSecurity_DTO;

namespace eDataAccess.Security
{
    public class TipoMovimiento_DAL
    {
        #region Metodos
        public static TipoMovimiento_DTO ObtenerTipoMovimiento(Int32 pTipoMovimiento)
        {
            DataTable mDt = new DataTable();
            List<DbParameter> mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nTipoMovimiento", DbType.Int32, pTipoMovimiento));

                mDt = Commons.ExecuteDataTable("ObtenerTipoMovimiento", CommandType.StoredProcedure, mParams);

                if (mDt != null)
                    return GetDTODR(mDt.Rows[0]);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<TipoMovimiento_DTO> ObtenerTipoMovimiento()
        {
            DataTable mDt = new DataTable();
            List<TipoMovimiento_DTO> mCol = new List<TipoMovimiento_DTO>();

            try
            {
                mDt = Commons.ExecuteDataTable("ObtenerTipoMovimientos", CommandType.StoredProcedure);

                if (mDt != null)
                {
                    foreach (DataRow mDr in mDt.Rows)
                        mCol.Add(GetDTODR(mDr));
                }

                return mCol;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static TipoMovimiento_DTO GetDTODR(DataRow pDr)
        {
            TipoMovimiento_DTO mDTO = new TipoMovimiento_DTO()
            {
                TipoMovimientoId = (Convert.IsDBNull(pDr["Id_Movimiento"])) ? 0 : (int)pDr["Id_Movimiento"],
                Descripcion = (Convert.IsDBNull(pDr["Descripcion"])) ? "" : pDr["Descripcion"].ToString(),
                DescCorta = (Convert.IsDBNull(pDr["Desc_Corta"])) ? "" : pDr["Desc_Corta"].ToString()
            };

            return mDTO;
        }


        #endregion
    }
}
