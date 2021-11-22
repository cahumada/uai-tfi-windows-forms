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
    public class UsuarioPatente_DAL
    {
        public static int AltaUsuarioPatente(int pUsuarioId, int pPatente, bool pDenegar = false)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUsuarioId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("nPatente", DbType.String, pPatente, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("bDenegar", DbType.String, pDenegar, null, null));

                return Commons.ExecuteNonQuery("AgregarUsuarioPatente", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int EliminarUsuarioPatente(long pId)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuarioPatenteId", DbType.Int64, pId, null, null));

                return Commons.ExecuteNonQuery("EliminarUsuarioPatente", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<UsuarioPatente_DTO> ObtenerUsuarioPatente(long pUsuarioId)
        {
            var mParams = new List<DbParameter>();
            var mCol = new List<UsuarioPatente_DTO>();
            var mDt = new DataTable();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUsuarioId, null, null));

                mDt = Commons.ExecuteDataTable("ObtenerUsuarioPatente", CommandType.StoredProcedure, mParams);

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

        public static List<UsuarioPatente_DTO> ObtenerUsuarioPatente()
        {
            var mCol = new List<UsuarioPatente_DTO>();
            var mDt = new DataTable();

            try
            {
                mDt = Commons.ExecuteDataTable("ObtenerUsuarioPatentes", CommandType.StoredProcedure, null);

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

        public static bool UsuarioPatenteHabilitada(int pUsuario, int pPatente)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUsuario));
                mParams.Add((DbParameter)Commons.getNewParameter("nPatente", DbType.Int32, pPatente));

                return (bool)Commons.ExecuteScalar("UsuarioPatenteHabilitada", CommandType.StoredProcedure, mParams);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static UsuarioPatente_DTO GetDTODR(DataRow pDr)
        {
            var mDTO = new UsuarioPatente_DTO();

            //USUARIO
            mDTO.Usuario.UsuarioId = (Convert.IsDBNull(pDr["Id_Usuario"])) ? 0 : (int)pDr["Id_Usuario"];
            mDTO.Usuario.Nik = (Convert.IsDBNull(pDr["Nik"])) ? "" : pDr["Nik"].ToString();
            mDTO.Usuario.Contrasena = (Convert.IsDBNull(pDr["Contrasena"])) ? "" : pDr["Contrasena"].ToString();
            mDTO.Usuario.IdiomaId = (Convert.IsDBNull(pDr["Id_Idioma"])) ? 0 : (int)pDr["Id_Idioma"];
            mDTO.Usuario.Intentos = (Convert.IsDBNull(pDr["Intentos"])) ? (short)0 : (short)pDr["Intentos"];
            mDTO.Usuario.Bloqueado = (Convert.IsDBNull(pDr["Bloqueado"])) ? false : (bool)pDr["Bloqueado"];

            //PATENTE
            mDTO.Patente.PatenteId = (Convert.IsDBNull(pDr["Id_Patente"])) ? 0 : (int)pDr["Id_Patente"];
            mDTO.Patente.Descripcion = (Convert.IsDBNull(pDr["Descripcion"])) ? "" : pDr["Descripcion"].ToString();
            mDTO.Patente.DescCorta = (Convert.IsDBNull(pDr["Desc_Corta"])) ? "" : pDr["Desc_Corta"].ToString();
            mDTO.Patente.Fecha = (Convert.IsDBNull(pDr["Fecha_Sys"])) ? DateTime.MinValue : (DateTime)pDr["Fecha_Sys"];

            //USUARIOPATENTE
            mDTO.UsuarioPatenteId = (Convert.IsDBNull(pDr["Id_UsuarioPatente"])) ? 0 : (long)pDr["Id_UsuarioPatente"];
            mDTO.DVH = (Convert.IsDBNull(pDr["DVH"])) ? 0 : (int)pDr["DVH"];
            //mDTO.Denegado = (Convert.IsDBNull(pDr["bIsDeny"])) ? false : (bool)pDr["bIsDeny"];

            return mDTO;
        }
    }
}
