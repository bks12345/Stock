using Ensure.BllDalClasses.BllClass.Common;
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
    public class ClsBankPaymentInfoDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public string InsertUpdateBankPaymentInfo(ClsBankPaymentInfobll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[30];
            sqlparam[0] = new SqlParameter("@BANKCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(obj.BANKCODE);
            sqlparam[1] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.AUID);
            sqlparam[2] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.UUID);
            sqlparam[3] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[3].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[4] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[4].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[5] = new SqlParameter("@bankid", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(obj.bankid);
            sqlparam[6] = new SqlParameter("@NatureOfPaymentID", SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(obj.NatureOfPaymentID);
            sqlparam[7] = new SqlParameter("@Remarks", SqlDbType.VarChar);
            sqlparam[7].Value = NullHandler.String(obj.Remarks);
            sqlparam[8] = new SqlParameter("@AcNo", SqlDbType.VarChar);
            sqlparam[8].Value = NullHandler.String(obj.AcNo);
            sqlparam[9] = new SqlParameter("@msg", SqlDbType.VarChar, 255);
            sqlparam[9].Direction = ParameterDirection.Output;
            sqlparam[10] = new SqlParameter("@branch", SqlDbType.VarChar);
            sqlparam[10].Value = NullHandler.String(obj.branch);
            sqlparam[11] = new SqlParameter("@ACHolderName", SqlDbType.VarChar);
            sqlparam[11].Value = NullHandler.String(obj.ACHolderName);
            sqlparam[12] = new SqlParameter("@isbankdetail", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(obj.isbankdetail);
            sqlparam[13] = new SqlParameter("@CLAIMID", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(obj.CLAIMID);
            sqlparam[14] = new SqlParameter("@Survyorfeeid", SqlDbType.Int);
            sqlparam[14].Value = NullHandler.Int32(obj.Survyorfeeid);
            sqlparam[15] = new SqlParameter("@Commissionid", SqlDbType.Int);
            sqlparam[15].Value = NullHandler.Int32(obj.Commissionid);
            sqlparam[16] = new SqlParameter("@AgentCommissionid", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Int32(obj.AgentCommissionid);
            sqlparam[17] = new SqlParameter("@CreditNoteid", SqlDbType.Int);
            sqlparam[17].Value = NullHandler.Int32(obj.CreditNoteid);
            sqlparam[18] = new SqlParameter("@CreditNoteidMultiple", SqlDbType.Int);
            sqlparam[18].Value = NullHandler.Int32(obj.CreditNoteidMultiple);
            sqlparam[19] = new SqlParameter("@claimsetlementid", SqlDbType.Int);
            sqlparam[19].Value = NullHandler.Int32(obj.claimsetlementid);
            sqlparam[20] = new SqlParameter("@surveyorfeesettlementid", SqlDbType.Int);
            sqlparam[20].Value = NullHandler.Int32(obj.surveyorfeesettlementid);

            sqlparam[21] = new SqlParameter("@pymentmodeid", SqlDbType.Int);
            sqlparam[21].Value = NullHandler.Int32(obj.paymentmodeid);
            sqlparam[22] = new SqlParameter("@purchaseid", SqlDbType.Int);
            sqlparam[22].Value = NullHandler.Int32(obj.purchaseid);
            sqlparam[23] = new SqlParameter("@disbursementid", SqlDbType.Int);
            sqlparam[23].Value = NullHandler.Int32(obj.disbursementid);



            sqlparam[24] = new SqlParameter("@Bankidnew", SqlDbType.Int);
            sqlparam[24].Value = NullHandler.Int32(obj.BankIDNew);
            sqlparam[25] = new SqlParameter("@CheqDate", SqlDbType.Date);
            sqlparam[25].Value = NullHandler.DateTime(obj.CheqDate);
            sqlparam[26] = new SqlParameter("@CheqAmt", SqlDbType.Decimal);
            sqlparam[26].Value = NullHandler.Decimal(obj.CheqAmt);

            sqlparam[27] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[27].Value = NullHandler.Int32(obj.branchid);
            sqlparam[28] = new SqlParameter("@subbranchid", SqlDbType.Int);
            sqlparam[28].Value = NullHandler.Int32(obj.subbranchid);
            sqlparam[29] = new SqlParameter("@moduleid", SqlDbType.Int);
            sqlparam[29].Value = NullHandler.Int32(obj.moduleid);

            objCmnDal.InsertUpdateTable("GetBankInfo_insertUpdate", "sp", sqlparam);
            if (sqlparam[9].Value != DBNull.Value)
                return sqlparam[9].Value.ToString();
            else
                return null;
        }
        public DataTable GetBankPaymentInfo(ClsBankPaymentInfobll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[0];
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("clm_GetBankInfo", "sp", sqlparam);
            return dt;
        }
        public string InsertUpdateMsAcnameBankdetails(ClsBankPaymentInfobll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[12];
            sqlparam[0] = new SqlParameter("@BANKCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(obj.BANKCODE);
            sqlparam[1] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.AUID);
            sqlparam[2] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.UUID);
            sqlparam[3] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[3].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[4] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[4].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[5] = new SqlParameter("@bankid", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(obj.bankid);
            sqlparam[6] = new SqlParameter("@AcNo", SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(obj.AcNo);
            sqlparam[7] = new SqlParameter("@msg", SqlDbType.VarChar, 255);
            sqlparam[7].Direction = ParameterDirection.Output;
            sqlparam[8] = new SqlParameter("@branch", SqlDbType.VarChar);
            sqlparam[8].Value = NullHandler.String(obj.branch);
            sqlparam[9] = new SqlParameter("@ACHolderName", SqlDbType.VarChar);
            sqlparam[9].Value = NullHandler.String(obj.ACHolderName);
            sqlparam[10] = new SqlParameter("@ACCOUNTID", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(obj.ACCOUNTID);
            sqlparam[11] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(ClsCommon.BranchId);

            objCmnDal.InsertUpdateTable("[insertupdate_MsAcnameBankdetails]", "sp", sqlparam);
            if (sqlparam[7].Value != DBNull.Value)
                return sqlparam[7].Value.ToString();
            else
                return null;
        }
        public DataTable GetMsAcnameBankDetails(ClsBankPaymentInfobll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            DataTable dt = new DataTable();
            sqlparam[0] = new SqlParameter("@ACCOUNTID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ACCOUNTID);
            dt = objCmnDal.GetTable("Get_msacname_bankdetails", "sp", sqlparam);
            return dt;
        }
        public DataTable FxBindPaymentType(ClsBankPaymentInfobll obj)
        {
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("get_paymenttype", "sp", null);
            return dt;
        }
    }
}