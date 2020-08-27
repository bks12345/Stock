using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.DalClass.Common;
using System.Data;
using Stock.BllDalClasses.BllClass.User;
using System.Data.SqlClient;

namespace Stock.BllDalClasses.DalClass.User
{
    public class ClsUserwisePolicyIssueLockDal
    {

        clsCommonDal objCmnDal = new clsCommonDal();

        public DataTable GetUser(ClsUserwisePolicyIssueLockBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.BRANCHID);
            sqlparam[1] = new SqlParameter("@GROUPID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.GROUPID);
            DataTable dt = objCmnDal.GetTable("User_UserwiseIssueLock_get_User", "sp", sqlparam);
            return dt;
        }

        public DataTable GetUserwiseIssueLock(ClsUserwisePolicyIssueLockBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.BRANCHID);
            sqlparam[1] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.ID);
            DataTable dt = objCmnDal.GetTable("User_UserwiseIssueLock_get", "sp", sqlparam);
            return dt;
        }

        public string InsertUpdateUserwiseIssueLock(ClsUserwisePolicyIssueLockBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[8];
            sqlparam[0] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.BRANCHID);
            sqlparam[1] = new SqlParameter("@IssueBlockLst", SqlDbType.Structured);
            sqlparam[1].Value = (obj.DTUserwiseLock);
            sqlparam[2] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.AUID);
            sqlparam[3] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.UUID);
            sqlparam[4] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[4].Direction = ParameterDirection.Output;
            sqlparam[5] = new SqlParameter("@USERID", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(obj.ID);
            sqlparam[6] = new SqlParameter("@BranchName", SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(obj.BranchName);
            sqlparam[7] = new SqlParameter("@UserName", SqlDbType.VarChar);
            sqlparam[7].Value = NullHandler.String(obj.UserName);
            objCmnDal.InsertUpdateTable("User_UserwiseIssueLock_insertUpdate", "sp", sqlparam);
            if (sqlparam[4].Value != DBNull.Value)
                return sqlparam[4].Value.ToString();
            else
                return null;
        }
    }
}