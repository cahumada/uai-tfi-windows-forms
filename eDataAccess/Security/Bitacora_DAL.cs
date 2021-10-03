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
                mParams.Add((DbParameter)Commons.getNewParameter("FechaMovimiento", DbType.DateTime, pBitacora.FechaMovimient, null, null));

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

        public static int ModificarBitacora(Bitacora_DTO pBitacora)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nLog", DbType.Int64, pBitacora.LogId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nUser", DbType.Int32, pBitacora.UsuarioId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nCriticality", DbType.Int32, pBitacora.CriticidadId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nTyp_Movement", DbType.Int32, pBitacora.MovimientoId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("dEffectDate", DbType.DateTime, pBitacora.FechaMovimient, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nDVH", DbType.Int32, pBitacora.DVH, null, null));

                return Commons.ExecuteNonQuery("UpdBitacora", CommandType.StoredProcedure, mParams);

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

        private static Bitacora_DTO GetDTODR(DataRow pDr)
        {
            var mDTO = new Bitacora_DTO();

            mDTO.LogId = (Convert.IsDBNull(pDr["Id_Log"])) ? 0 : (long)pDr["Id_Log"];
            mDTO.UsuarioId = (Convert.IsDBNull(pDr["Id_Usuario"])) ? 0 : (int)pDr["Id_Usuario"];
            mDTO.MovimientoId = (Convert.IsDBNull(pDr["Id_Movimiento"])) ? 0 : (int)pDr["Id_Movimiento"];
            mDTO.CriticidadId = (Convert.IsDBNull(pDr["Id_Criticidad"])) ? 0 : (int)pDr["Id_Criticidad"];
            mDTO.FechaMovimient = (Convert.IsDBNull(pDr["Fecha_Movimiento"])) ? DateTime.MinValue : (DateTime)pDr["Fecha_Movimiento"];
            mDTO.DVH = (Convert.IsDBNull(pDr["DVH"])) ? 0 : (int)pDr["DVH"];

            return mDTO;
        }
    }
}
