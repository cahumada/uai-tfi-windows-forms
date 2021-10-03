using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDataAccess.Security
{
    public class DigitoVerificador_DAL
    {
        public static int VerificarIntegridad()
        {
            try
            {
                return (int)Commons.ExecuteScalar("VerificarIntegridad", System.Data.CommandType.StoredProcedure, null);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int CalcularDigVerif(string pNombreTabla)
        {
            var mParams = new List<DbParameter>();

            try
            {
                mParams.Add((DbParameter)Commons.getNewParameter("sTableName", DbType.String, pNombreTabla));

                return (int)Commons.ExecuteScalar("VerificarIntegridad", System.Data.CommandType.StoredProcedure, mParams);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
