using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDataAccess
{
    public class MyMenu_DAL
    {
        public static DataTable GenerarMenu()
        {
            var mDt = new DataTable();

            try
            {
                mDt = Commons.ExecuteDataTable("ObtenerMenu", CommandType.StoredProcedure, null);

                return mDt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
