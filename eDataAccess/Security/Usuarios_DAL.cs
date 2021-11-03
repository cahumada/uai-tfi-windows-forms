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
    public class Usuarios_DAL
    {
        public static int AltaUsuario(Usuarios_DTO pUsuario)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUsuario.UsuarioId, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("sNik", DbType.String, pUsuario.Nik, null, null));
                mParams.Add((DbParameter)Commons.getNewParameter("sContrasena", DbType.String, pUsuario.Contrasena));
                mParams.Add((DbParameter)Commons.getNewParameter("nIdioma", DbType.Int32, pUsuario.IdiomaId));
                mParams.Add((DbParameter)Commons.getNewParameter("nIntentos", DbType.Int16, pUsuario.Intentos));
                mParams.Add((DbParameter)Commons.getNewParameter("bAdmin", DbType.Boolean, pUsuario.Bloqueado));
                mParams.Add((DbParameter)Commons.getNewParameter("bBloqueado", DbType.Boolean, pUsuario.Bloqueado));

                return Commons.ExecuteNonQuery("AgregarUsuario", CommandType.StoredProcedure, mParams);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static int EliminarUsuario(int pId)
        {
            var mParams = new List<DbParameter>();

            try
            {

                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pId, null, null));

                return Commons.ExecuteNonQuery("EliminarUsuario", CommandType.StoredProcedure, mParams);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int ModificarUsuario(Usuarios_DTO pUsuario)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pUsuario.UsuarioId));
                mParams.Add((DbParameter)Commons.getNewParameter("sNik", DbType.String, pUsuario.Nik));
                mParams.Add((DbParameter)Commons.getNewParameter("bAdmin", DbType.Boolean, pUsuario.Bloqueado));
                mParams.Add((DbParameter)Commons.getNewParameter("bBloqueado", DbType.Boolean, pUsuario.Bloqueado));

                return Commons.ExecuteNonQuery("ActualizarUsuario", CommandType.StoredProcedure, mParams);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int BlanquearPassword(int pId, string NuevaContrasena)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pId));
                mParams.Add((DbParameter)Commons.getNewParameter("sContrasena", DbType.String, NuevaContrasena));

                return Commons.ExecuteNonQuery("ActualizarContrasena", CommandType.StoredProcedure, mParams);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Desbloquear(int pId)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pId));

                return Commons.ExecuteNonQuery("DesbloquearUsuario", CommandType.StoredProcedure, mParams);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int ActualizarIdioma(int pId, int pIdioma)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pId));
                mParams.Add((DbParameter)Commons.getNewParameter("Idioma", DbType.Int32, pIdioma));

                return Commons.ExecuteNonQuery("ActualizarUsuarioIdioma", CommandType.StoredProcedure, mParams);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool ValidarUsuarioExistente(int pId)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pId));

                int? mExists = Commons.ExecuteNonQuery("ValidarUsuarioExistente", CommandType.StoredProcedure, mParams);

                if (mExists != null)
                {
                    return (mExists == 1) ? true : false;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static Usuarios_DTO ObtenerUsuario(int pId)
        {
            var mParams = new List<DbParameter>();
            var mDt = new DataTable();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("nUsuario", DbType.Int32, pId));

                mDt = Commons.ExecuteDataTable("ObtenerUsuario", CommandType.StoredProcedure, mParams);

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

        public static Usuarios_DTO ObtenerUsuario(string pNik)
        {
            var mParams = new List<DbParameter>();
            var mDt = new DataTable();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("sNik", DbType.String, pNik));

                mDt = Commons.ExecuteDataTable("ObtenerUsuarioNik", CommandType.StoredProcedure, mParams);

                if (mDt != null)
                {
                    return GetDTODR(mDt.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static List<Usuarios_DTO> ObtenerUsuario()
        {
            var mCol = new List<Usuarios_DTO>();
            var mDt = new DataTable();

            try
            {
                mDt = Commons.ExecuteDataTable("ObtenerUsuarios", CommandType.StoredProcedure, null);

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


        private static Usuarios_DTO GetDTODR(DataRow pDr)
        {
            var mDTO = new Usuarios_DTO();

            mDTO.UsuarioId = (Convert.IsDBNull(pDr["Id_Usuario"])) ? 0 : (int)pDr["Id_Usuario"];
            mDTO.Nik = (Convert.IsDBNull(pDr["Nik"])) ? "" : pDr["Nik"].ToString();
            mDTO.Contrasena = (Convert.IsDBNull(pDr["Contrasena"])) ? "" : pDr["Contrasena"].ToString();
            mDTO.IdiomaId = (Convert.IsDBNull(pDr["Id_Idioma"])) ? 0 : (int)pDr["Id_Idioma"];
            mDTO.Intentos = (Convert.IsDBNull(pDr["Intentos"])) ? (short)0 : (short)pDr["Intentos"];
            mDTO.Bloqueado = (Convert.IsDBNull(pDr["Bloqueado"])) ? false : (bool)pDr["Bloqueado"];
            mDTO.DVH = (Convert.IsDBNull(pDr["DVH"])) ? 0 : (int)pDr["DVH"];
            mDTO.Admin = (Convert.IsDBNull(pDr["Admin"])) ? false : (bool)pDr["Admin"];

            return mDTO;
        }
    }
}
