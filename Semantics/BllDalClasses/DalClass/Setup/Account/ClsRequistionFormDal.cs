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
    public class ClsRequistionFormDal
    {
         clsCommonDal objCmnDal = new clsCommonDal();
         public DataTable GetRequistionItem(ClsRequistionFormBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@EDESCRIPTION", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objbll.EDESCRIPTION);
            return objCmnDal.GetTable("GET_PURCHASE_ITEM", "sp", sqlparam);
        }
         public DataTable GetPurchaseDetails(ClsRequistionFormBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@Transactionno", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objbll.Transactionno);
            return objCmnDal.GetTable("GET_PURCHASEENTRY_DETAILS", "sp", sqlparam);
        }
         public DataSet GetAllRequistion(ClsRequistionFormBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@PONo", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objbll.PONo);
            sqlparam[1] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objbll.branchid);
            sqlparam[2] = new SqlParameter("@subbranchid", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objbll.subbranchid);
            sqlparam[3] = new SqlParameter("@Fiscalid", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objbll.Fiscalid);
            DataSet ds = new DataSet();
            ds = objCmnDal.GetTableSet("GET_Requistion_DETAILS", "sp", sqlparam);
            return ds;
        }
         public string InsertUpdate_RequistionEntry(ClsRequistionFormBll obj)
        {
            SqlParameter[] sqlparam1 = new SqlParameter[17];
            sqlparam1[0] = new SqlParameter("@RequistionID", SqlDbType.Int);
            sqlparam1[0].Value = NullHandler.Int32(obj.RequistionID);
            sqlparam1[1] = new SqlParameter("@Fiscalid", SqlDbType.Int);
            sqlparam1[1].Value = NullHandler.Int32(obj.Fiscalid);
            sqlparam1[2] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam1[2].Value = NullHandler.Int32(obj.branchid);
            sqlparam1[3] = new SqlParameter("@vendorid", SqlDbType.Int);
            sqlparam1[3].Value = NullHandler.Int32(obj.vendorid);
            sqlparam1[4] = new SqlParameter("@PONo", SqlDbType.Int);
            sqlparam1[4].Value = NullHandler.Int32(obj.PONo);
            sqlparam1[5] = new SqlParameter("@total", SqlDbType.Decimal);
            sqlparam1[5].Value = NullHandler.Decimal(obj.total);
            sqlparam1[6] = new SqlParameter("@dtpurchasedetailsReq", SqlDbType.Structured);
            sqlparam1[6].Value = (obj.dtpurchaseentrydetails);
            sqlparam1[7] = new SqlParameter("@subbranchid ", SqlDbType.Int);
            sqlparam1[7].Value = NullHandler.Int32(obj.subbranchid);
            sqlparam1[8] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam1[8].Direction = ParameterDirection.Output;
            sqlparam1[9] = new SqlParameter("@pdate", SqlDbType.DateTime);
            sqlparam1[9].Value = NullHandler.DateTime(obj.pdate);
            sqlparam1[10] = new SqlParameter("@ndate", SqlDbType.VarChar);
            sqlparam1[10].Value = NullHandler.String(obj.ndate);
            sqlparam1[11] = new SqlParameter("@Remarks", SqlDbType.VarChar);
            sqlparam1[11].Value = NullHandler.String(obj.Remarks);
            sqlparam1[12] = new SqlParameter("@uuid", SqlDbType.Int);
            sqlparam1[12].Value = NullHandler.Int32(obj.uuid);

            sqlparam1[13] = new SqlParameter("@RequisitionDate", SqlDbType.Date);
            sqlparam1[13].Value = NullHandler.DateTime(obj.RequisitionDate);
            sqlparam1[14] = new SqlParameter("@RequisitionDateNep", SqlDbType.NVarChar);
            sqlparam1[14].Value = NullHandler.String(obj.RequisitionDateNep);
            sqlparam1[15] = new SqlParameter("@Requistion", SqlDbType.Int);
            sqlparam1[15].Value = NullHandler.Int32(obj.Requistion);
            sqlparam1[16] = new SqlParameter("@RequisitioniNo", SqlDbType.Int);
            sqlparam1[16].Value = NullHandler.Int32(obj.RequisitioniNo);

            objCmnDal.InsertUpdateTable("INSERTUPDATE_Requistion_Entry_DETAILS", "sp", sqlparam1);
            if (sqlparam1[8].Value != DBNull.Value)
                return sqlparam1[8].Value.ToString();
            else
                return null;
        }
         public DataTable Requistion_Entry_DETAILS(ClsRequistionFormBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[0];
            return objCmnDal.GetTable("Requistion_Entry_DETAILS", "sp", null);
        }
    }
}