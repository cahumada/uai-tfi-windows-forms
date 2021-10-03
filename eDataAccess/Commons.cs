using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDataAccess
{
    public class Commons
    {
        private static string CONEXION_POR_DEFAULT = ConfigurationManager.AppSettings["BO"];
        private static string SCHEME_CONEXION = ConfigurationManager.AppSettings["scheme"];

        internal static string getConexionString()
        {
            return ConfigurationManager.ConnectionStrings[CONEXION_POR_DEFAULT].ConnectionString.ToString();
        }

        internal static string getMyProvider()
        {
            return ConfigurationManager.ConnectionStrings[CONEXION_POR_DEFAULT].ProviderName.ToString();
        }

        internal static DbProviderFactory getProviderFactory()
        {
            return DbProviderFactories.GetFactory(Commons.getMyProvider());
        }

        internal static IDbDataParameter getNewParameter(string pParameterName, DbType pDbType, Object pValue, int? pSize = null, byte? pPrecision = null)
        {
            IDbDataParameter mParam;

            try
            {
                mParam = Commons.getProviderFactory().CreateParameter();
                mParam.ParameterName = pParameterName;
                mParam.DbType = pDbType;
                mParam.Value = pValue;

                if (pSize != null)
                    mParam.Size = (int)pSize;

                if (pPrecision != null)
                    mParam.Precision = (byte)pPrecision;
            }
            catch (Exception)
            {

                throw;
            }

            return mParam;
        }

        public static object ExecuteScalar(string pQuery, CommandType pCmdType, List<DbParameter> pParamList = null)
        {
            using (IDbConnection oCon = Commons.getProviderFactory().CreateConnection())
            {
                oCon.ConnectionString = Commons.getConexionString();

                using (IDbCommand oCmd = Commons.getProviderFactory().CreateCommand())
                {
                    oCmd.Connection = oCon;
                    oCmd.CommandType = pCmdType;
                    oCmd.CommandText = SCHEME_CONEXION + "." + pQuery;

                    if (pParamList != null && pParamList.Count > 0)
                    {
                        foreach (var oParam in pParamList)
                        {
                            oCmd.Parameters.Add(oParam);
                        }
                    }

                    try
                    {
                        oCon.Open();
                        return oCmd.ExecuteScalar();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        oCmd.Dispose();
                        oCon.Close();
                        oCon.Dispose();
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string pQuery, CommandType pCmdType, List<DbParameter> pParamList = null)
        {
            using (IDbConnection oCon = Commons.getProviderFactory().CreateConnection())
            {
                oCon.ConnectionString = Commons.getConexionString();

                using (IDbCommand oCmd = Commons.getProviderFactory().CreateCommand())
                {
                    oCmd.Connection = oCon;
                    oCmd.CommandType = pCmdType;
                    oCmd.CommandText = SCHEME_CONEXION + "." + pQuery;

                    if (pParamList != null && pParamList.Count > 0)
                    {
                        foreach (var oParam in pParamList)
                        {
                            oCmd.Parameters.Add(oParam);
                        }
                    }

                    try
                    {
                        oCon.Open();
                        return oCmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        oCmd.Dispose();
                        oCon.Close();
                        oCon.Dispose();
                    }
                }
            }
        }

        public static DataTable ExecuteDataTable(string pQuery, CommandType pCmdType, List<DbParameter> pParamList = null)
        {
            using (IDbConnection oCon = Commons.getProviderFactory().CreateConnection())
            {
                oCon.ConnectionString = Commons.getConexionString();
                DbDataAdapter oAdap = Commons.getProviderFactory().CreateDataAdapter();
                var oDt = new DataTable();

                using (IDbCommand oCmd = Commons.getProviderFactory().CreateCommand())
                {
                    oCmd.Connection = oCon;
                    oCmd.CommandType = pCmdType;
                    oCmd.CommandText = SCHEME_CONEXION + "." + pQuery;

                    if (pParamList != null && pParamList.Count > 0)
                    {
                        foreach (var oParam in pParamList)
                        {
                            oCmd.Parameters.Add(oParam);
                        }
                    }

                    try
                    {
                        oCon.Open();
                        oAdap.SelectCommand = (DbCommand)oCmd;

                        oAdap.Fill(oDt);

                        return oDt;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    finally
                    {
                        oCmd.Dispose();
                        oCon.Close();
                        oCon.Dispose();
                    }
                }
            }
        }
    }
}
