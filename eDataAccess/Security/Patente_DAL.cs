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
    public class Patente_DAL
    {
        public static int AltaPatente(Patente_DTO pPatente)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nPatente", DbType.Int32, pPatente.PatenteId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("sDescripcion", DbType.String, pPatente.Descripcion, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("sDesc_Corta", DbType.String, pPatente.DescCorta, null, null));

                return Commons.ExecuteNonQuery("AgregarPatente", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int EliminarPatente(long pId)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nPatente", DbType.Int32, pId, null, null));

                return Commons.ExecuteNonQuery("EliminarPatente", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int ModificarPatente(Patente_DTO pPatente)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nPatente", DbType.Int32, pPatente.PatenteId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("sDescripcion", DbType.String, pPatente.Descripcion, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("sDesc_Corta", DbType.String, pPatente.DescCorta, null, null));

                return Commons.ExecuteNonQuery("ActualizarPatente", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Patente_DTO> ObtenerPatente(Usuarios_DTO pUser)
        {
            var mParams = new List<DbParameter>();
            var mDt = new DataTable();
            var mCol = new List<Patente_DTO>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUser.UsuarioId, null, null));

                mDt = Commons.ExecuteDataTable("ObtenerPatenteUsuario", CommandType.StoredProcedure, mParams);

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

        public static Patente_DTO ObtenerPatente(long pId)
        {
            var mParams = new List<DbParameter>();
            var mDt = new DataTable();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nPatente", DbType.Int32, pId, null, null));

                mDt = Commons.ExecuteDataTable("ObtenerPatente", CommandType.StoredProcedure, mParams);

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

        public static List<Patente_DTO> ObtenerPatente()
        {
            var mCol = new List<Patente_DTO>();
            var mDt = new DataTable();

            try
            {
                mDt = Commons.ExecuteDataTable("ObtenerPatentes", CommandType.StoredProcedure, null);

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

        private static Patente_DTO GetDTODR(DataRow pDr)
        {
            var mDTO = new Patente_DTO();

            mDTO.PatenteId = (Convert.IsDBNull(pDr["Id_Patente"])) ? 0 : (int)pDr["Id_Patente"];
            mDTO.Descripcion = (Convert.IsDBNull(pDr["Descripcion"])) ? "" : pDr["Descripcion"].ToString();
            mDTO.DescCorta = (Convert.IsDBNull(pDr["Desc_Corta"])) ? "" : pDr["Desc_Corta"].ToString();
            mDTO.Fecha = (Convert.IsDBNull(pDr["Fecha_Sys"])) ? DateTime.MinValue : (DateTime)pDr["Fecha_Sys"];

            return mDTO;
        }

    }
}
