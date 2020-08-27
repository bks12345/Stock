using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensure.DalClass.Common;
using System.Data.SqlClient;
using System.Data;
using Ensure.BllDalClasses.BllClass.Setup.Account;
using Ensure.BllDalClasses.BllClass.Common;

namespace Ensure.BllDalClasses.DalClass.Setup.Account
{
    public class clsAccTypeDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdateTBACCOUNTTYPE(clsAccTypeBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[11];
            sqlparam[0] = new SqlParameter("@ACCTYPEID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ACCTYPEID);
            sqlparam[1] = new SqlParameter("@ACCOUNTTYPE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.ACCOUNTTYPE);
            sqlparam[2] = new SqlParameter("@DESCRIPTION", SqlDbType.NVarChar);
            sqlparam[2].Value = NullHandler.String(obj.DESCRIPTION);
            sqlparam[3] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[3].Direction = ParameterDirection.Output;
            sqlparam[4] = new SqlParameter("@ACCOUNT", SqlDbType.Structured);
            sqlparam[4].Value = (obj.ACCOUNT);
            sqlparam[5] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[6]=new SqlParameter("@islock",SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.islock);
            sqlparam[7] = new SqlParameter("@AUID", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.AUID);
            sqlparam[8] = new SqlParameter("@UUID", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(obj.UUID);
            sqlparam[9] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[9].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[10] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[10].Value = NullHandler.DateTime(obj.UDT);


            //sqlparam[6] = new SqlParameter("@UUID", SqlDbType.VarChar);
            //sqlparam[6].Value = NullHandler.String(ClsCommon.UserCode);
            objCmnDal.InsertUpdateTable("acc_accType_insertUpdate", "sp", sqlparam);
            if (sqlparam[3].Value != DBNull.Value)
                return sqlparam[3].Value.ToString();
            else
                return null;
        }
        public DataTable GetData()
        {
            return objCmnDal.GetTable("acc_accType_get", "sp", null);
            //return objCmnDal.GetTable("select * from TBACCOUNTTYPE", "text", null);
        }
        public DataTable GetAccType(clsAccTypeBll clsApp)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ACCOUNTTYPE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(clsApp.ACCOUNTTYPE);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("acc_AccType_List", "sp", sqlparam);
            return ds;
        }    
        //public DataTable GetAccType()
        //{
        //    return objCmnDal.GetTable("select ACCOUNTTYPE from TBACCOUNTTYPE", "text", null);
        //}  
    }
}