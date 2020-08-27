using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Web.UI;
using Stock.BllDalClasses.BllClass.Common;
using System.Web.Services.Protocols;

namespace Stock.DalClass.Common
{
    public class clsCommonDal:SoapHeader
    {
        //for conection string to the database
        public string GetConnectionString()
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["dbensureConnectionString"];
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }
            return returnValue;
        }
        public string GetConnectionStringGet()
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["dbensureConnectionStringGet"];
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }
            return returnValue;
        }
        public string GetConnectionStringOracle()
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["ConnectionStringEnsureOLEDBOracle"];
            if (settings != null)
            {
                returnValue = settings.ConnectionString;
            }
            return returnValue;
        }
        public string GetDate()
        {
            using (SqlConnection con = new SqlConnection(GetConnectionStringGet()))
            {

                using (SqlCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "server_GetDate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            string date = "";
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                                date = DBNullHandler.FormatDateTime(dt.Rows[0]["todayDate"].ToString());
                            return date;
                        }
                    }
                    catch (Exception ex)
                    {
                        ClsAlert.Alert(ex.Message);
                        return "";
                    }
                }
            }
        }
        public string GetDateTime()
        {
            using (SqlConnection con = new SqlConnection(GetConnectionStringGet()))
            {

                using (SqlCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = "server_GetDate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            string date = "";
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                                date =dt.Rows[0]["todayDate"].ToString();
                            return date;
                        }
                    }
                    catch (Exception ex)
                    {
                        ClsAlert.Alert(ex.Message);
                        return "";
                    }
                }
            }
        }

        //for retriving values from table
        public DataTable GetTable(string sql,string sqlCmdType, SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionStringGet()))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = sql;
                        if (sqlCmdType == "text")
                            cmd.CommandType = CommandType.Text;
                        else if (sqlCmdType == "sp")
                            cmd.CommandType = CommandType.StoredProcedure;
                        else if (sqlCmdType == "td")
                            cmd.CommandType = CommandType.TableDirect;

                        if (param != null)
                        {
                            cmd.Parameters.AddRange(param);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                    catch (Exception ex)
                    {
                        ClsAlert.Alert(ex.Message);
                        return null;
                    }
                }
            }
        }
        public DataSet GetTableSet(string sql, string sqlCmdType, SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionStringGet()))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = sql;
                        cmd.CommandTimeout = 120;
                        if (sqlCmdType == "text")
                            cmd.CommandType = CommandType.Text;
                        else if (sqlCmdType == "sp")
                            cmd.CommandType = CommandType.StoredProcedure;
                        else if (sqlCmdType == "td")
                            cmd.CommandType = CommandType.TableDirect;

                        if (param != null)
                        {
                            cmd.Parameters.AddRange(param);
                        }
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            //da.ReturnProviderSpecificTypes = true;
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            return ds;
                        }
                    }
                    catch (Exception ex)
                    {
                        ClsAlert.Alert(ex.Message);
                        return null;
                    }
                }
            }
        }

        //for inserting into table
        public bool InsertUpdateTable(string sql, string sqlCmdType, SqlParameter[] param)
        {
            string _msg = "";
            return InsertUpdateTable(sql, sqlCmdType, param, ref _msg);
            

        }
        public bool InsertUpdateTable(ref string _msg,string sql, string sqlCmdType, SqlParameter[] param )
        {
            return InsertUpdateTable(sql, sqlCmdType, param, ref _msg);
        }
        public bool InsertUpdateTable(string sql, string sqlCmdType, SqlParameter[] param, ref string prmMsg )
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = sql;
                        if (sqlCmdType == "text")
                            cmd.CommandType = CommandType.Text;
                        else if (sqlCmdType == "sp")
                            cmd.CommandType = CommandType.StoredProcedure;
                        else if (sqlCmdType == "td")
                            cmd.CommandType = CommandType.TableDirect;

                        if (param != null)
                        {
                            cmd.Parameters.AddRange(param);
                        }
                        con.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            con.Close();
                            return true;
                        }
                        else
                        {
                            con.Close();
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        string _dupMsg = "Cannot insert duplicate key";
                        string _errMsg = ex.Message;
                        prmMsg = ex.Message;
                        //ClsAlert.Alert(ex.Message);
                        //if (_errMsg.Contains(_dupMsg))
                        //{
                        //    prmMsg = "DUPLICATE";
                        //}
                        //else
                        //{
                        //    MessageBox.Show(_errMsg);
                        //}
                        return false;
                    }
                }
            }

        }

        public bool DeleteTable(string sql, string sqlCmdType, SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = sql;
                        if (sqlCmdType == "text")
                            cmd.CommandType = CommandType.Text;
                        else if (sqlCmdType == "sp")
                            cmd.CommandType = CommandType.StoredProcedure;
                        else if (sqlCmdType == "td")
                            cmd.CommandType = CommandType.TableDirect;

                        if (param != null)
                        {
                            cmd.Parameters.AddRange(param);
                        }
                        con.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            con.Close();
                            return true;
                        }
                        else
                        {
                            con.Close();
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        ClsAlert.Alert(ex.Message);
                        con.Close();
                        return false;
                    }
                }
            }

        }
        //public string InsertUpdateTableWithReturnType(string sql, string sqlCmdType, SqlParameter[] param)
        //{
        //    using (SqlConnection con = new SqlConnection(GetConnectionString()))
        //    {
        //        using (SqlCommand cmd = con.CreateCommand())
        //        {
        //            try
        //            {
        //                cmd.CommandText = sql;
        //                if (sqlCmdType == "text")
        //                    cmd.CommandType = CommandType.Text;
        //                else if (sqlCmdType == "sp")
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                else if (sqlCmdType == "td")
        //                    cmd.CommandType = CommandType.TableDirect;

        //                if (param != null)
        //                {
        //                    cmd.Parameters.AddRange(param);
        //                }
        //                con.Open();
        //                cmd.EndExecuteNonQuery();
        //                con.Close();

        //            }
        //            catch (Exception)
        //            {
        //                MessageBox.Show("Error!!! Connection to database failed completely. Please check your network connection !!!");
        //            }
        //        }
        //    }
        //}
    }
}