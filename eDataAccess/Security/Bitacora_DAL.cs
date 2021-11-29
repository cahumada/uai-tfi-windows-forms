using eSecurity_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eFramework;

namespace eDataAccess.Security
{
    public class Bitacora_DAL
    {
        public static int AltaBitacora(Bitacora_DTO pBitacora)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nLog", DbType.Int64, pBitacora.LogId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pBitacora.UsuarioId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nCriticidad", DbType.Int32, pBitacora.CriticidadId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nTipoMovimiento", DbType.Int32, pBitacora.MovimientoId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("dFechaMov", DbType.DateTime, pBitacora.FechaMovimiento, null, null));

                return Commons.ExecuteNonQuery("AgregarBitacora", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int EliminarBitacora(long pId)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nLog", DbType.Int64, pId, null, null));

                return Commons.ExecuteNonQuery("EliminarBitacora", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int EliminarBitacora()
        {
            try
            {
                return Commons.ExecuteNonQuery("EliminarBitacoraCompleta", CommandType.StoredProcedure);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int EliminarBitacora(DateTime pFechaDesde, DateTime pFechaHasta, Int32 pUsuario = default(int), Int32 pCriticidad = default(int))
        {
            List<DbParameter> mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("dFechaDesde", DbType.Date, pFechaDesde));
                mParams.Add((DbParameter)Commons.getNewParameter("dFechaHasta", DbType.Date, pFechaHasta));
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUsuario));
                mParams.Add((DbParameter)Commons.getNewParameter("nCriticidad", DbType.Int32, pCriticidad));

                return Commons.ExecuteNonQuery("LimpiarBitacora", CommandType.StoredProcedure, mParams);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static int ModificarBitacora(Bitacora_DTO pBitacora)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nLog", DbType.Int64, pBitacora.LogId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pBitacora.UsuarioId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nCriticidad", DbType.Int32, pBitacora.CriticidadId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nTipoMovimiento", DbType.Int32, pBitacora.MovimientoId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("dFechaMov", DbType.DateTime, pBitacora.FechaMovimiento, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nDVH", DbType.Int32, pBitacora.DVH, null, null));

                return Commons.ExecuteNonQuery("ActualizarBitacora", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Bitacora_DTO ObtenerBitacora(long pId)
        {
            var mParams = new List<DbParameter>();
            var mDt = new DataTable();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nLog", DbType.Int64, pId));

                mDt = Commons.ExecuteDataTable("ObtenerBitacora", CommandType.StoredProcedure, mParams);

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

        public static DataTable ObtenerBitacoraReporte()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = Commons.ExecuteDataTable("ObtenerReporteBitacoras", CommandType.StoredProcedure);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["sTipoMovimiento"] = Convert.IsDBNull(dr["sTipoMovimiento"]) ? null : Encriptado.DataDecryption(dr["sTipoMovimiento"].ToString());
                        dr["Nik"] = Convert.IsDBNull(dr["Nik"]) ? null : Encriptado.DataDecryption(dr["Nik"].ToString());
                    }

                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static List<Bitacora_DTO> ObtenerBitacora()
        {
            var mCol = new List<Bitacora_DTO>();
            var mDt = new DataTable();

            try
            {
                mDt = Commons.ExecuteDataTable("ObtenerBitacoras", CommandType.StoredProcedure, null);

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

        public static List<Bitacora_DTO> ObtenerBitacora(DateTime pFechaDesde, DateTime pFechaHasta, Int32 pUsuario = default(int), Int32 pCriticidad = default(int))
        {
            DataTable dt = new DataTable();
            List<Bitacora_DTO> mCol = new List<Bitacora_DTO>();
            List<DbParameter> mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("dFechaDesde", DbType.Date, pFechaDesde));
                mParams.Add((DbParameter)Commons.getNewParameter("dFechaHasta", DbType.Date, pFechaHasta));
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUsuario));
                mParams.Add((DbParameter)Commons.getNewParameter("nCriticidad", DbType.Int32, pCriticidad));

                dt = Commons.ExecuteDataTable("ObtenerBitacoraFiltrada", CommandType.StoredProcedure, mParams);

                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                        mCol.Add(GetDTODR(dr));
                }

                return mCol;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable ObtenerBitacoraReporte(DateTime pFechaDesde, DateTime pFechaHasta, Int32 pUsuario = default(int), Int32 pCriticidad = default(int))
        {
            DataTable dt = new DataTable();
            List<DbParameter> mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("dFechaDesde", DbType.Date, pFechaDesde));
                mParams.Add((DbParameter)Commons.getNewParameter("dFechaHasta", DbType.Date, pFechaHasta));
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUsuario));
                mParams.Add((DbParameter)Commons.getNewParameter("nCriticidad", DbType.Int32, pCriticidad));

                dt = Commons.ExecuteDataTable("ObtenerReporteBitacoraFiltrada", CommandType.StoredProcedure, mParams);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["sTipoMovimiento"] = Convert.IsDBNull(dr["sTipoMovimiento"]) ? null : Encriptado.DataDecryption(dr["sTipoMovimiento"].ToString());
                        dr["Nik"] = Convert.IsDBNull(dr["Nik"]) ? null : Encriptado.DataDecryption(dr["Nik"].ToString());
                    }

                    return dt;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static Bitacora_DTO GetDTODR(DataRow pDr)
        {
            var mDTO = new Bitacora_DTO();

            mDTO.LogId = (Convert.IsDBNull(pDr["Id_Log"])) ? 0 : (long)pDr["Id_Log"];
            mDTO.UsuarioId = (Convert.IsDBNull(pDr["Id_Usuario"])) ? 0 : (int)pDr["Id_Usuario"];
            mDTO.MovimientoId = (Convert.IsDBNull(pDr["Id_Movimiento"])) ? 0 : (int)pDr["Id_Movimiento"];
            mDTO.CriticidadId = (Convert.IsDBNull(pDr["Id_Criticidad"])) ? 0 : (int)pDr["Id_Criticidad"];
            mDTO.FechaMovimiento = (Convert.IsDBNull(pDr["Fecha_Movimiento"])) ? DateTime.MinValue : (DateTime)pDr["Fecha_Movimiento"];
            mDTO.DVH = (Convert.IsDBNull(pDr["DVH"])) ? 0 : (int)pDr["DVH"];

            return mDTO;
        }
    }
}
