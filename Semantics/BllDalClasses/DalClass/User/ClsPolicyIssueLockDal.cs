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
    public class ClsPolicyIssueLockDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public DataTable GetPolicyIssueLock(ClsPolicyIssueLockBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.BRANCHID);
            sqlparam[1] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.SUBBRANCHID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("User_PolicyIssueBlock_get", "sp", sqlparam);
            return dt;

        }

        public string InsertUpdatePolicyIssueLock(ClsPolicyIssueLockBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[9];
            sqlparam[0] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.BRANCHID);
            sqlparam[1] = new SqlParameter("@IssueBlockLst", SqlDbType.Structured);
            sqlparam[1].Value = (obj.DTLockLst);
            sqlparam[2] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.AUID);
            sqlparam[3] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.UUID);
            sqlparam[4] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[4].Direction = ParameterDirection.Output;
            sqlparam[5] = new SqlParameter("@BranchName", SqlDbType.VarChar);
            sqlparam[5].Value= NullHandler.String(obj.BranchName);
            sqlparam[6] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.SUBBRANCHID);
            sqlparam[7] = new SqlParameter("@SubBranchName", SqlDbType.VarChar);
            sqlparam[7].Value = NullHandler.String(obj.SUBBRANCHNAME);
            sqlparam[8] = new SqlParameter("@islock", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(obj.islock);
            objCmnDal.InsertUpdateTable("User_PolicyIssueBlock_insertUpdate", "sp", sqlparam);
            if (sqlparam[4].Value != DBNull.Value)
                return sqlparam[4].Value.ToString();
            else
                return null;

        }
        public DataTable LoadSubBranchList(ClsPolicyIssueLockBll objBranchBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@SUBBRANCHCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objBranchBll.SUBBRANCHCODE);
            sqlparam[1] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objBranchBll.BRANCHID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("company_SubBranch_getList", "sp", sqlparam);
            return dt;
        }

    }
}