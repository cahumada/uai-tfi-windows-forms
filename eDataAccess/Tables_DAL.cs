using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDataAccess
{
    public class Tables_DAL
    {
        public static DataTable FindAll(string pNombreTabla)
        {
            var mDt = new DataTable();
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("sTableName", DbType.String, pNombreTabla));

                mDt = Commons.ExecuteDataTable("ReaTabTablesAll", CommandType.StoredProcedure, mParams);

                return mDt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static DataTable Findl(string pNombreTabla, string pClave)
        {
            var mDt = new DataTable();
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("sTableName", DbType.String, pNombreTabla));
                mParams.Add((DbParameter)Commons.getNewParameter("nKey", DbType.Int32, pClave));

                mDt = Commons.ExecuteDataTable("ReaTabTables", CommandType.StoredProcedure, mParams);

                return mDt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
