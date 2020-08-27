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
    public class ClsSurveyFeePaymentDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public DataTable GetSurveyFee(ClsSurveyFeePaymentBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ID);
            sqlparam[1] = new SqlParameter("@CLAIMNO", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.CLAIMNO);
            sqlparam[2] = new SqlParameter("@DateFrom", SqlDbType.DateTime);
            sqlparam[2].Value = NullHandler.DateTime(obj.DateFrom);
            sqlparam[3] = new SqlParameter("@DateTo", SqlDbType.DateTime);
            sqlparam[3].Value = NullHandler.DateTime(obj.DateTo);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("GET_BY_SURVEYORID", "sp", sqlparam);
            return dt;
        }
        public void InsertSurveyFeeMaster(ClsSurveyFeePaymentBll objBll, ref DataTable dt)
        {
            SqlParameter[] sqlparam = new SqlParameter[14];
            sqlparam[0] = new SqlParameter("@SETTLEDATE", SqlDbType.DateTime);
            sqlparam[0].Value = NullHandler.DateTime(objBll.SETTLEDATE);
            sqlparam[1] = new SqlParameter("@AMOUNT", SqlDbType.Decimal);
            sqlparam[1].Value = NullHandler.Decimal(objBll.TOTALPAYABLE);
            sqlparam[2] = new SqlParameter("@CHEQUENO", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objBll.CHEQUENO);
            sqlparam[3] = new SqlParameter("@CHEQUEDATE", SqlDbType.DateTime);
            sqlparam[3].Value = NullHandler.DateTime(objBll.CHECKDATE);
            sqlparam[4] = new SqlParameter("@BANKCODE", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(objBll.BANKCODE);

            sqlparam[5] = new SqlParameter("@LSUID", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(objBll.LSUID);
            sqlparam[6] = new SqlParameter("@LSDT", SqlDbType.DateTime);
            sqlparam[6].Value = NullHandler.DateTime(objBll.LSDT);
            sqlparam[7] = new SqlParameter("@LMUID", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(objBll.LMUID);
            sqlparam[8] = new SqlParameter("@LMDT", SqlDbType.DateTime);
            sqlparam[8].Value = NullHandler.DateTime(objBll.LMDT);
            sqlparam[9] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(objBll.BranchId);
            sqlparam[10] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(objBll.SUBBRANCHID);
            sqlparam[11] = new SqlParameter("@PAYMENTTYPE", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(objBll.PAYMENTTYPE);

            sqlparam[12] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[12].Direction = ParameterDirection.Output;
            sqlparam[13] = new SqlParameter("@SURVEYORID", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(objBll.surveyorid);

            DataRow workRow = dt.NewRow();
            workRow["ProcName"] = "INSERT_SURVEYFEE_PAYMENT";
            workRow["ProcType"] = "sp";
            workRow["sqlParam"] = sqlparam;
            dt.Rows.Add(workRow);
            //objCmnDal.InsertUpdateTable("INSERT_SURVEYFEE_PAYMENT", "sp", sqlparam);
            //if (sqlparam[12].Value != DBNull.Value)
            //    return sqlparam[12].Value.ToString();
            //else
            //    return null;
        }
        public void UpdateSurveyFee(ClsSurveyFeePaymentBll objBll, ref DataTable dt)
        {
            SqlParameter[] sqlparam = new SqlParameter[13];
            sqlparam[0] = new SqlParameter("@SETTLEID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objBll.SETTLEID);
            sqlparam[1] = new SqlParameter("@claimid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objBll.claimid);
            sqlparam[2] = new SqlParameter("@surveyorid", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objBll.surveyorid);
            sqlparam[3] = new SqlParameter("@ACCODE", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(objBll.ACCODE);
            sqlparam[4] = new SqlParameter("@BANKCODE", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(objBll.BANKCODE);
            //sqlparam[5] = new SqlParameter("@CLAIMNO", SqlDbType.VarChar);
            //sqlparam[5].Value = NullHandler.String(objBll.CLAIMNO);
            sqlparam[5] = new SqlParameter("@SETTLEDATE", SqlDbType.DateTime);
            sqlparam[5].Value = NullHandler.DateTime(objBll.SETTLEDATE);
            sqlparam[6] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[6].Direction = ParameterDirection.Output;
            sqlparam[7] = new SqlParameter("@TOTALPAYABLE", SqlDbType.Decimal);
            sqlparam[7].Value = NullHandler.Decimal(objBll.TOTALPAYABLE);
            sqlparam[8] = new SqlParameter("@CHECKDATE", SqlDbType.DateTime);
            sqlparam[8].Value = NullHandler.DateTime(objBll.CHECKDATE);
            sqlparam[9] = new SqlParameter("@CHEQUENO", SqlDbType.VarChar);
            sqlparam[9].Value = NullHandler.String(objBll.CHEQUENO);
            sqlparam[10] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(objBll.BranchId);
            sqlparam[11] = new SqlParameter("@uuid", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(objBll.uuid);
            sqlparam[12] = new SqlParameter("@SURVFEEID", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(objBll.SURVFEEID);
            DataRow workRow = dt.NewRow();
            workRow["ProcName"] = "UPDATE_SURVAYFEE";
            workRow["ProcType"] = "sp";
            workRow["sqlParam"] = sqlparam;
            dt.Rows.Add(workRow);
            //objCmnDal.InsertUpdateTable("UPDATE_SURVAYFEE", "sp", sqlparam);
            //if (sqlparam[6].Value != DBNull.Value)
            //    return sqlparam[6].Value.ToString();
            //else
            //    return null;
        }
        //internal DataTable getdefaultbank(BllClass.Setup.Account.ClsDefaultbankBll clsDefaultbankBll)
        //{
        //    SqlParameter[] sqlparam = new SqlParameter[4];
        //    sqlparam[0] = new SqlParameter("@ModuleId", SqlDbType.Int);
        //    sqlparam[0].Value = NullHandler.Int32(clsDefaultbankBll.ModuleId);
        //    sqlparam[1] = new SqlParameter("@BranchId", SqlDbType.Int);
        //    sqlparam[1].Value = NullHandler.Int32(clsDefaultbankBll.BranchId);
        //    sqlparam[2] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
        //    sqlparam[2].Value = NullHandler.Int32(clsDefaultbankBll.SUBBRANCHID);
        //    sqlparam[3] = new SqlParameter("@FLAG", SqlDbType.Int);
        //    sqlparam[3].Value = NullHandler.Int32(clsDefaultbankBll.ISFLAG);
        //    DataTable dt = new DataTable();
        //    dt = objCmnDal.GetTable("get_default_bank", "sp", sqlparam);
        //    return dt;

        //}
        //internal DataTable getallbankcode()
        //{
        //    DataTable dt = new DataTable();
        //    dt = objCmnDal.GetTable("get_allBankCode", "sp", null);
        //    return dt;
        //}
    }
}