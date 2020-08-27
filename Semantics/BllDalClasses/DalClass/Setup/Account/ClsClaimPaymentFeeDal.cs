using Ensure.BllDalClasses.BllClass.Setup.Account;
using Ensure.DalClass.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.DalClass.Setup.Account
{
    public class ClsClaimPaymentFeeDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public DataTable GetClaimPayment(ClsClaimPaymentFeeBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
           
            sqlparam[0] = new SqlParameter("@CLAIMNO", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(obj.CLAIMNO);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("GET_CLAIM_BYNO", "sp", sqlparam);
            return dt;
        }
        public DataTable GetIssuedTo(ClsClaimPaymentFeeBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@CLAIMID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.CLAIMID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("GET_ISSUED_TO", "sp", sqlparam);
            return dt;
        }
        public string InsertUpdateClaimPaymennt(ClsClaimPaymentFeeBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[20];
            sqlparam[0] = new SqlParameter("@CLAIMID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.CLAIMID);
            sqlparam[1] = new SqlParameter("@SETTLEID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.SETTLEID);
            sqlparam[2] = new SqlParameter("@AMOUNT", SqlDbType.Decimal);
            sqlparam[2].Value = NullHandler.Decimal(obj.AMOUNT);
            sqlparam[3] = new SqlParameter("@BANKCODE", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.BANKCODE);
            sqlparam[4] = new SqlParameter("@LSUID", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(obj.LSUID);
            sqlparam[5] = new SqlParameter("@LMUID", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(obj.LMUID);
            sqlparam[6] = new SqlParameter("@DETAILID", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.DETAILID);
            sqlparam[7] = new SqlParameter("@ISSUETOID", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.ISSUETOID);
            sqlparam[8] = new SqlParameter("@DTCLAIMPAYMENTDETAIL", SqlDbType.Structured);
            sqlparam[8].Value = (obj.dtGetAllClaim);
            sqlparam[9] = new SqlParameter("@msg", SqlDbType.VarChar, 255);
            sqlparam[9].Direction = ParameterDirection.Output;
            sqlparam[10] = new SqlParameter("@CHEQUENO", SqlDbType.VarChar);
            sqlparam[10].Value = NullHandler.String(obj.CHEQUENO);
            sqlparam[11] = new SqlParameter("@SETTLEDATE", SqlDbType.DateTime);
            sqlparam[11].Value = NullHandler.DateTime(obj.SETTLEDATE);
            sqlparam[12] = new SqlParameter("@CHEQUEDATE", SqlDbType.DateTime);
            sqlparam[12].Value = NullHandler.DateTime(obj.CHEQUEDATE);
            sqlparam[13] = new SqlParameter("@LSDT", SqlDbType.DateTime);
            sqlparam[13].Value = NullHandler.DateTime(obj.LSDT);
            sqlparam[14] = new SqlParameter("@LMDT", SqlDbType.DateTime);
            sqlparam[14].Value = NullHandler.DateTime(obj.LMDT);
            sqlparam[15] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[15].Value = NullHandler.Int32(obj.branchid);
            sqlparam[16] = new SqlParameter("@uuid", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Int32(obj.uuid);
            sqlparam[17] = new SqlParameter("@paytoname", SqlDbType.VarChar);
            sqlparam[17].Value = NullHandler.String(obj.paytoname);
            sqlparam[18] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[18].Value = NullHandler.Int32(obj.SUBBRANCHID);
            sqlparam[19] = new SqlParameter("@PAYMENTTYPE", SqlDbType.Int);
            sqlparam[19].Value = NullHandler.Int32(obj.PAYMENTTYPE);
            objCmnDal.InsertUpdateTable("INSERT_CLAIM_PAYMENT", "sp", sqlparam);
            if (sqlparam[9].Value != DBNull.Value)
                return sqlparam[9].Value.ToString();
            else
                return null;
        }
        public DataTable GetIssueId(ClsClaimPaymentFeeBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@CLAIMID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.CLAIMID);
            sqlparam[1] = new SqlParameter("@IssuedToId", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.ISSUETOID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("GET_ISSUEDTO_Details", "sp", sqlparam);
            return dt;
        }
        internal DataSet getclaimpaymentdata(ClsClaimPaymentFeeBll clsVoucherEntryBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@settledid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsVoucherEntryBll.SETTLEID);
            sqlparam[1] = new SqlParameter("@key", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(clsVoucherEntryBll.KeyId);
            DataSet ds = new DataSet();
            return ds = objCmnDal.GetTableSet("claim_payment_chequeprint", "sp", sqlparam);
        }
    }
}