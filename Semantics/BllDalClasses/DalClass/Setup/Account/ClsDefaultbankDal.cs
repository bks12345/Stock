using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Ensure.DalClass.Common;
using Ensure.BllDalClasses.BllClass.Common;
using Ensure.BllDalClasses.BllClass.Setup.Account;

namespace Ensure.BllDalClasses.DalClass.Setup.Account
{
    public class ClsDefaultbankDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        internal string insertupdatedefaultbank(BllClass.Setup.Account.ClsDefaultbankBll clsDefaultbankBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[11];
            sqlparam[0] = new SqlParameter("@BankId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsDefaultbankBll.BankId);
            sqlparam[1] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(clsDefaultbankBll.BranchId);
            sqlparam[2] = new SqlParameter("@ModuleId", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(clsDefaultbankBll.ModuleId);
            sqlparam[3] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(clsDefaultbankBll.ID);
            sqlparam[4] = new SqlParameter("@msg", SqlDbType.VarChar,20);                
            sqlparam[4].Direction=ParameterDirection.Output;
            sqlparam[5] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(ClsCommon.UserCode);
            sqlparam[6] = new SqlParameter("@isLocked", SqlDbType.SmallInt);
            sqlparam[6].Value = NullHandler.Int32(clsDefaultbankBll.isLocked);
            sqlparam[7] = new SqlParameter("@isDefault", SqlDbType.SmallInt);
            sqlparam[7].Value = NullHandler.Int32(clsDefaultbankBll.isDefault);
            sqlparam[8] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(clsDefaultbankBll.SUBBRANCHID);
            sqlparam[9] = new SqlParameter("@paymentsourceid", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(clsDefaultbankBll.paymentsourceid);
            //sqlparam[6] = new SqlParameter("@UUID", SqlDbType.VarChar);
            //sqlparam[6].Value = NullHandler.String(ClsCommon.UserCode);
            sqlparam[10] = new SqlParameter("@AccountNo", SqlDbType.VarChar);
            sqlparam[10].Value = NullHandler.String(clsDefaultbankBll.AccountNo);
            string _errMsg = "";

            objCmnDal.InsertUpdateTable("Defaultbank_insertupdate", "sp", sqlparam, ref _errMsg);

            if (sqlparam[4].Value != DBNull.Value)
                if (_errMsg.Length > 2)
                {
                    return _errMsg;
                }
                else
                {
                    return sqlparam[4].Value.ToString();
                }
            else
                return null;
          
        }

        internal DataTable getdata(BllClass.Setup.Account.ClsDefaultbankBll clsDefaultbankBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@ModuleId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsDefaultbankBll.ModuleId);
            sqlparam[1] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(clsDefaultbankBll.BranchId);
            sqlparam[2] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(clsDefaultbankBll.SUBBRANCHID);
            sqlparam[3] = new SqlParameter("@paymentsourceid", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(clsDefaultbankBll.paymentsourceid);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("def_defaultbank", "sp", sqlparam);
          return dt;

        }

        internal DataTable getdefaultbank(BllClass.Setup.Account.ClsDefaultbankBll clsDefaultbankBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@ModuleId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsDefaultbankBll.ModuleId);
            sqlparam[1] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(clsDefaultbankBll.BranchId);
            sqlparam[2] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(clsDefaultbankBll.SUBBRANCHID);
            sqlparam[3] = new SqlParameter("@FLAG", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(clsDefaultbankBll.ISFLAG);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("get_default_bank", "sp", sqlparam);
            return dt;
         
        }

        internal DataTable getAccHeadBank(BllClass.Setup.Account.ClsDefaultbankBll clsDefaultbankBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[0];
            DataTable dt = objCmnDal.GetTable("getBankName_acAccounthead","sp",sqlparam);
            return dt;
        }

        internal DataTable getallbankcode(ClsDefaultbankBll obj)
        {
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("get_allBankCode", "sp", null);
            return dt;
        }
        internal DataTable getallbankcodeForCrAdvice(ClsDefaultbankBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.BranchId);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("[get_allBankCodeForCreditAdvice]", "sp", sqlparam);
            return dt;
        }
        internal string DeleteDefaultBank(ClsDefaultbankBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ID);
            sqlparam[1] = new SqlParameter("@isdelete", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.isdelete);
            sqlparam[2] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[2].Direction = ParameterDirection.Output;
            objCmnDal.InsertUpdateTable("DELETE_DEFAULT_BANK", "sp", sqlparam);
            if (sqlparam[2].Value != DBNull.Value)
                return sqlparam[2].Value.ToString();
            else
                return null;
        }
        internal DataTable getdefaultbankDisbursment(BllClass.Setup.Account.ClsDefaultbankBll clsDefaultbankBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@ModuleId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsDefaultbankBll.ModuleId);
            sqlparam[1] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(clsDefaultbankBll.BranchId);
            sqlparam[2] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(clsDefaultbankBll.SUBBRANCHID);
            sqlparam[3] = new SqlParameter("@FLAG", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(clsDefaultbankBll.ISFLAG);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("get_default_bank_disbursement", "sp", sqlparam);
            return dt;

        }

        internal DataTable getAccAllGLCODE(BllClass.Setup.Account.ClsDefaultbankBll clsDefaultbankBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[0];
            DataTable dt = objCmnDal.GetTable("acc_get_GLCode", "sp", sqlparam);
            return dt;
        }
        public DataTable getModuleid(ClsDefaultbankBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objbll.ID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("getmoduleid", "sp", sqlparam);
            return dt;
        }
    }
}