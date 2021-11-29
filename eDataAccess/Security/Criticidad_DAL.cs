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
    public class Criticidad_DAL
    {
        #region Metodos
        public static Criticidad_DTO ObtenerCriticidad(Int32 pCriticidad)
        {
            DataTable mDt = new DataTable();
            List<DbParameter> mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nCriticidad", DbType.Int32, pCriticidad));

                mDt = Commons.ExecuteDataTable("ObtenerCriticidad", CommandType.StoredProcedure, mParams);

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

        public static List<Criticidad_DTO> ObtenerCriticidad()
        {
            DataTable mDt = new DataTable();
            List<Criticidad_DTO> mCol = new List<Criticidad_DTO>();

            try
            {
                mDt = Commons.ExecuteDataTable("ObtenerCriticidades", CommandType.StoredProcedure);

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

        private static Criticidad_DTO GetDTODR(DataRow pDr)
        {
            Criticidad_DTO mDTO = new Criticidad_DTO()
            {
                CriticidadId = (Convert.IsDBNull(pDr["Id_Criticidad"])) ? 0 : (int)pDr["Id_Criticidad"],
                Descripcion = (Convert.IsDBNull(pDr["Descripcion"])) ? "" : pDr["Descripcion"].ToString(),
                DescCorta = (Convert.IsDBNull(pDr["Desc_Corta"])) ? "" : pDr["Desc_Corta"].ToString()
            };

            return mDTO;
        }


        #endregion
    }
}
