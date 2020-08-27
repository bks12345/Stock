using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Ensure.DalClass.Common;
using Ensure.BllDalClasses.BllClass.Common;

namespace Ensure.BllDalClasses.DalClass.Setup.Account
{
    public class ClsVoucherDesignationlimitDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        internal string InsertUpdateVoucherDesignationwiselimt(BllClass.Setup.Account.ClsVoucherDesignationlimitBll clsVoucherDesignationlimitBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[7];
            sqlparam[0] = new SqlParameter("@LIMITID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsVoucherDesignationlimitBll.LIMITID);
            sqlparam[1] = new SqlParameter("@designationid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(clsVoucherDesignationlimitBll.designationid);

            sqlparam[2] = new SqlParameter("@limitamt", SqlDbType.Decimal);
            sqlparam[2].Value = NullHandler.Decimal(clsVoucherDesignationlimitBll.limitamt);
            sqlparam[3] = new SqlParameter("@UserID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(clsVoucherDesignationlimitBll.UserID);

            sqlparam[4] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[4].Direction = ParameterDirection.Output;
            sqlparam[5] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[6] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(ClsCommon.UserCode);
            string _errMsg = "";

            objCmnDal.InsertUpdateTable("user_insertupdate_Voucher_designationWiseLimit", "sp", sqlparam, ref _errMsg);
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

        internal DataTable get_Voucher_designationwiselimt(BllClass.Setup.Account.ClsVoucherDesignationlimitBll clsVoucherDesignationlimitBll)
        {
            return objCmnDal.GetTable("user_get_voucher_designationWiseLimit", "sp", null);
        }

        internal string deleterecord(BllClass.Setup.Account.ClsVoucherDesignationlimitBll clsVoucherDesignationlimitBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@LIMITID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsVoucherDesignationlimitBll.LIMITID);
            return ClsConvertTo.String(objCmnDal.DeleteTable("user_delete_VOUCHER_designationWiseLimit", "sp", sqlparam));
        }
        public DataTable checkduplicateforuser(BllClass.Setup.Account.ClsVoucherDesignationlimitBll clsVoucherDesignationlimitBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@userid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsVoucherDesignationlimitBll.UserID);
            sqlparam[1] = new SqlParameter("@limitid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(clsVoucherDesignationlimitBll.LIMITID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("Check_duplicate_for_Voucherlimit", "sp", sqlparam);
           return dt;
        }
    }
}