using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.DalClass.Common;
using System.Data;
using System.Data.SqlClient;
using Stock.BllDalClasses.BllClass.User;

namespace Stock.BllDalClasses.DalClass.User
{
    public class ClsLoginHistoryDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public string insertupdateUserHistory(ClsLoginHistory clsLoginHistory)
        {
            SqlParameter[] sqlparam = new SqlParameter[12];
            sqlparam[0] = new SqlParameter("@USERID", SqlDbType.VarChar);
            sqlparam[0].Value = DBNullHandler.String(clsLoginHistory.USERID);
            sqlparam[1] = new SqlParameter("@COMP_IP", SqlDbType.VarChar);
            sqlparam[1].Value = DBNullHandler.String(clsLoginHistory.COMP_IP);
            sqlparam[2] = new SqlParameter("@COMP_USER", SqlDbType.VarChar);
            sqlparam[2].Value = DBNullHandler.String(clsLoginHistory.COMP_USER);
            sqlparam[3] = new SqlParameter("@COMP_NAME", SqlDbType.VarChar);
            sqlparam[3].Value = DBNullHandler.String(clsLoginHistory.COMP_NAME);
            sqlparam[4] = new SqlParameter("@LOGIN_DATE", SqlDbType.DateTime);
            sqlparam[4].Value = DBNullHandler.DateTime(clsLoginHistory.LOGIN_DATE);
            sqlparam[5] = new SqlParameter("@LOGIN_TIME", SqlDbType.VarChar);
            sqlparam[5].Value = DBNullHandler.String(clsLoginHistory.LOGIN_TIME);
            sqlparam[6] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[6].Direction = ParameterDirection.Output;
            sqlparam[7] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[7].Value = DBNullHandler.Int32(clsLoginHistory.BRANCHID);
            sqlparam[8] = new SqlParameter("@UserName", SqlDbType.VarChar);
            sqlparam[8].Value = DBNullHandler.String(clsLoginHistory.UserName);
            sqlparam[9] = new SqlParameter("@ISSUCCESS", SqlDbType.Int);
            sqlparam[9].Value = DBNullHandler.Int32(clsLoginHistory.ISSUCCESS);
            sqlparam[10] = new SqlParameter("@LOGOUT_DATE", SqlDbType.DateTime);
            sqlparam[10].Value = DBNullHandler.DateTime(clsLoginHistory.LOGOUT_DATE);
            sqlparam[11] = new SqlParameter("@LOGOUT_TIME", SqlDbType.VarChar);
            sqlparam[11].Value = DBNullHandler.String(clsLoginHistory.LOGOUT_TIME);
            objCmnDal.InsertUpdateTable("tbl_user_loginhistory_inserupdate", "sp", sqlparam);
            if (sqlparam[6].Value != DBNull.Value)
                return sqlparam[6].Value.ToString();
            else
                return null;

        }

        public DataTable getdata(ClsLoginHistory clsLoginHistory)
        {
            SqlParameter[] sqlparam = new SqlParameter[6];
            sqlparam[0] = new SqlParameter("@datefrom", SqlDbType.Date);
            sqlparam[0].Value = DBNullHandler.DateTime(clsLoginHistory.datefrom);
            sqlparam[1] = new SqlParameter("@dateto", SqlDbType.Date);
            sqlparam[1].Value = DBNullHandler.DateTime(clsLoginHistory.dateto);
            sqlparam[2] = new SqlParameter("@COMP_NAME", SqlDbType.VarChar);
            sqlparam[2].Value = DBNullHandler.String(clsLoginHistory.COMP_NAME);
            sqlparam[3] = new SqlParameter("@COMP_USER", SqlDbType.VarChar);
            sqlparam[3].Value = DBNullHandler.String(clsLoginHistory.COMP_USER);
            sqlparam[4] = new SqlParameter("@USERID", SqlDbType.Int);
            sqlparam[4].Value = DBNullHandler.Int32 (clsLoginHistory.USERID);
            sqlparam[5] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[5].Value = DBNullHandler.Int32(clsLoginHistory.BRANCHID);
            return objCmnDal.GetTable("tbl_user_loginhistory_get", "sp", sqlparam);
        }
        public DataSet GetAllData(ClsLoginHistory clsLoginHistory)
        {
            SqlParameter[] sqlparam = new SqlParameter[8];
            sqlparam[0] = new SqlParameter("@datefrom", SqlDbType.Date);
            sqlparam[0].Value = DBNullHandler.DateTime(clsLoginHistory.datefrom);
            sqlparam[1] = new SqlParameter("@dateto", SqlDbType.Date);
            sqlparam[1].Value = DBNullHandler.DateTime(clsLoginHistory.dateto);
            sqlparam[2] = new SqlParameter("@COMP_NAME", SqlDbType.VarChar);
            sqlparam[2].Value = DBNullHandler.String(clsLoginHistory.COMP_NAME);
            sqlparam[3] = new SqlParameter("@COMP_USER", SqlDbType.VarChar);
            sqlparam[3].Value = DBNullHandler.String(clsLoginHistory.COMP_USER);
            sqlparam[4] = new SqlParameter("@USERID", SqlDbType.Int);
            sqlparam[4].Value = DBNullHandler.Int32(clsLoginHistory.USERID);
            sqlparam[5] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[5].Value = DBNullHandler.Int32(clsLoginHistory.BRANCHID);
            sqlparam[6] = new SqlParameter("@PG", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(clsLoginHistory.PG);
            sqlparam[7] = new SqlParameter("@PGSIZE", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(clsLoginHistory.PGSIZE);
            return objCmnDal.GetTableSet("tbl_user_loginhistory_get", "sp", sqlparam);
        }

        //sanjay changes
        public DataTable GetHistoryReport(ClsLoginHistory clsLoginHistory)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@datefrom", SqlDbType.DateTime);
            sqlparam[0].Value = DBNullHandler.DateTime(clsLoginHistory.datefrom);
            sqlparam[1] = new SqlParameter("@dateto", SqlDbType.DateTime);
            sqlparam[1].Value = DBNullHandler.DateTime(clsLoginHistory.dateto);
            sqlparam[2] = new SqlParameter("@userId", SqlDbType.VarChar);
            sqlparam[2].Value = DBNullHandler.String(clsLoginHistory.USERID);
            sqlparam[3] = new SqlParameter("@mode", SqlDbType.VarChar);
            sqlparam[3].Value = DBNullHandler.String(clsLoginHistory.mode);
            return objCmnDal.GetTable("historyReportViewer_get", "sp", sqlparam);
        }
        //--
    }
}