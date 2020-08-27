using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Hosting;

namespace SQLCACHE
{
    public class dbCacheSetup
    {
        private static object GetCacheData(string cacheItemName)
        {
            return HostingEnvironment.Cache.Get(cacheItemName);

        }

        private static void SetCacheData(string CacheName, string cacheItemName, object dataSet, string connString, string tableName)
        {
            string cacheEntryname = CacheName;

            //Many articles online state that the following statement should be run only once at the start of the application. 
            //Few articles say the object get replaced if called again with same connection string.
            SqlDependency.Start(connString);

            //The following statements needs to be run only once against the connection string and the database table, hence may also be moved to an appropriate place in code.
            SqlCacheDependencyAdmin.EnableNotifications(connString);
            SqlCacheDependencyAdmin.EnableTableForNotifications(connString, tableName);

            SqlCacheDependency dependency = new SqlCacheDependency(cacheEntryname, tableName);
            HostingEnvironment.Cache.Insert(cacheItemName, dataSet, dependency);

        }

        public static DataTable FxGetSetupFromCacheData(string prmCacheName, string prmTableName, string prmIDCol, string prmColName, string prmCretiaCol, string prmWhereCond, string prmSortBy, out bool isDataFromCache)
        {
            string sqlQuery = "SELECT " + prmIDCol + "," + prmColName;
            if (prmCretiaCol.Trim() != "-1") sqlQuery = sqlQuery + "," + prmCretiaCol;
            sqlQuery = sqlQuery + " FROM [dbo].[" + prmTableName + "]";

            if (sqlQuery.Contains("SELECT TOP "))
                sqlQuery = sqlQuery + " WHERE " + prmWhereCond;
            string tableName = prmTableName;

            string connStringName = "dbensureConnectionString";
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings[connStringName].ToString();

            isDataFromCache = false;
            DataTable dtTemp = null;
            string cacheItemName = sqlQuery; //assuming the commandtext can be used to uniquely identify the cached item

            object obj = GetCacheData(cacheItemName);
            dtTemp = (DataTable)obj;

            if (dtTemp == null)
            {
                SqlConnection cnMain = new SqlConnection(connString);
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, cnMain);

                dtTemp = new DataTable();
                da.Fill(dtTemp);

                SetCacheData(prmCacheName, cacheItemName, dtTemp, connString, tableName);

            }
            else
            {
                isDataFromCache = true;
            }


            dtTemp.DefaultView.Sort = prmSortBy;

            if (prmWhereCond.Trim() != "")
            {
                DataRow[] rows = dtTemp.Select(prmWhereCond.Replace("*","[*]"));
                if (rows.Length > 0)
                {
                    dtTemp = rows.CopyToDataTable();
                }
                else
                    dtTemp = null;

                //DataTable newDt = new DataTable();
                //newDt.Columns.Add(prmIDCol, typeof(string));
                //newDt.Columns.Add(prmColName, typeof(string));

                //string[] vDelim = { "," };
                //string[] vArr = prmCretiaCol.Split(vDelim, StringSplitOptions.RemoveEmptyEntries);
                //for (int i = 0; i < vArr.Length; i++)
                //{
                //    newDt.Columns.Add(vArr[i], typeof(string));
                //}


                //foreach (DataRow row in rows)
                //{
                //    newDt.Rows.Add(row[prmIDCol].ToString(), row[prmColName].ToString());
                //}
                //if (newDt != null)
                //{
                //    if (newDt.Rows.Count > 0)
                //    {
                //        dtTemp = newDt;
                //    }
                //}
            }
            return dtTemp;

        }

        public static string FxGetSetupFromCacheDataJson(string prmCacheName, string prmTableName, string prmIDCol, string prmColName, string prmCretiaCol, string prmWhereCond, string prmSortBy, out bool isDataFromCache)
        {
            string sqlQuery = "SELECT " + prmIDCol + "," + prmColName;
            if (prmCretiaCol.Trim() != "-1") sqlQuery = sqlQuery + "," + prmCretiaCol;
            sqlQuery = sqlQuery + " FROM [dbo].[" + prmTableName + "]";
            string tableName = prmTableName;

            string connStringName = "dbensureConnectionString";
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings[connStringName].ToString();

            isDataFromCache = false;
            DataTable dtTemp = null;
            string cacheItemName = sqlQuery; //assuming the commandtext can be used to uniquely identify the cached item

            object obj = GetCacheData(cacheItemName);
            dtTemp = (DataTable)obj;

            if (dtTemp == null)
            {
                SqlConnection cnMain = new SqlConnection(connString);
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, cnMain);

                dtTemp = new DataTable();
                da.Fill(dtTemp);

                SetCacheData(prmCacheName, cacheItemName, dtTemp, connString, tableName);

            }
            else
            {
                isDataFromCache = true;
            }


            dtTemp.DefaultView.Sort = prmSortBy;

            if (prmWhereCond.Trim() != "")
            {
                DataRow[] rows = dtTemp.Select(prmWhereCond);
                if (rows.Length > 0)
                {
                    dtTemp = rows.CopyToDataTable();
                }
                else
                    dtTemp = null;
            }
            var obj1 = JsonConvert.SerializeObject(dtTemp);
            return obj1;

        }
    }
}