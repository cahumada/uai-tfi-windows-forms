using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDataAccess.Security
{
    public class BackupRestore_DAL
    {
        public static bool RealizarBackup(string pRuta, Int32 pCantidadArchivos)
        {
            List<DbParameter> mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("sRuta", DbType.String, pRuta));
                mParams.Add((DbParameter)Commons.getNewParameter("nCantidadArchivos", DbType.Int32, pCantidadArchivos));

                Commons.ExecuteNonQuery("GenerarBackup", CommandType.StoredProcedure, mParams);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool RealizarRestore(string pRuta, Int32 pCantidadArchivos)
        {
            List<DbParameter> mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("sRuta", DbType.String, pRuta));
                mParams.Add((DbParameter)Commons.getNewParameter("nCantidadArchivos", DbType.Int32, pCantidadArchivos));

                Commons.ExecuteNonQuery("GenerarRestore", CommandType.StoredProcedure, mParams, true);

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
