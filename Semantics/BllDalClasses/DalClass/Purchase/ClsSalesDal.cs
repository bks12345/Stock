using Stock.BllDalClasses.BllClass.Purchase;
using Stock.DalClass.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.DalClass.Purchase
{
    public class ClsSalesDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public DataTable GetPurchaseItem(ClsSalesBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@EDESCRIPTION", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objbll.EDESCRIPTION);
            return objCmnDal.GetTable("GET_PURCHASE_ITEM", "sp", sqlparam);
        }
        public DataTable GetPurchaseDetails(ClsSalesBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@Transactionno", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objbll.Transactionno);
            return objCmnDal.GetTable("GET_PURCHASEENTRY_DETAILS", "sp", sqlparam);
        }
        public DataSet GetAllPurchasedetails(ClsSalesBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@Transactionno", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objbll.Transactionno);
            sqlparam[1] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objbll.branchid);
            sqlparam[2] = new SqlParameter("@subbranchid", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objbll.subbranchid);
            sqlparam[3] = new SqlParameter("@Fiscalid", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objbll.Fiscalid);
            DataSet ds = new DataSet();
            ds = objCmnDal.GetTableSet("[GET_Sales_DETAILS]", "sp", sqlparam);
            return ds;
        }
        public string InsertUpdate_PurchaseEntry(ClsSalesBll obj)
        {
            SqlParameter[] sqlparam1 = new SqlParameter[29];
            sqlparam1[0] = new SqlParameter("@PurchaseID", SqlDbType.Int);
            sqlparam1[0].Value = NullHandler.Int32(obj.PurchaseID);
            sqlparam1[1] = new SqlParameter("@Fiscalid", SqlDbType.Int);
            sqlparam1[1].Value = NullHandler.Int32(obj.Fiscalid);
            sqlparam1[2] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam1[2].Value = NullHandler.Int32(obj.branchid);
            //sqlparam1[4] = new SqlParameter("@billno", SqlDbType.Int);
            //sqlparam1[4].Value = NullHandler.Int32(obj.billno);
            sqlparam1[3] = new SqlParameter("@partyname", SqlDbType.VarChar);
            sqlparam1[3].Value = NullHandler.String(obj.partyname);
            sqlparam1[4] = new SqlParameter("@billno", SqlDbType.VarChar);
            sqlparam1[4].Value = NullHandler.String(obj.billno);
            sqlparam1[5] = new SqlParameter("@pAmount", SqlDbType.Decimal);
            sqlparam1[5].Value = NullHandler.Decimal(obj.pAmount);
            sqlparam1[6] = new SqlParameter("@pdiscAmt", SqlDbType.Decimal);
            sqlparam1[6].Value = NullHandler.Decimal(obj.pdiscAmt);
            sqlparam1[7] = new SqlParameter("@pVatAmt", SqlDbType.Decimal);
            sqlparam1[7].Value = NullHandler.Decimal(obj.pVatAmt);
            sqlparam1[8] = new SqlParameter("@pNetAmt", SqlDbType.Decimal);
            sqlparam1[8].Value = NullHandler.Decimal(obj.pNetAmt);
            sqlparam1[9] = new SqlParameter("@dtpurchaseentrydetails", SqlDbType.Structured);
            sqlparam1[9].Value = (obj.dtpurchaseentrydetails);
            sqlparam1[10] = new SqlParameter("@vatoptionid ", SqlDbType.Int);
            sqlparam1[10].Value = NullHandler.Int32(obj.vatoptionid);
            sqlparam1[11] = new SqlParameter("@pTypeid ", SqlDbType.Int);
            sqlparam1[11].Value = NullHandler.Int32(obj.pTypeid);
            sqlparam1[12] = new SqlParameter("@Transactionno", SqlDbType.Int);
            sqlparam1[12].Value = NullHandler.Int32(obj.Transactionno);
            sqlparam1[13] = new SqlParameter("@subbranchid ", SqlDbType.Int);
            sqlparam1[13].Value = NullHandler.Int32(obj.subbranchid);
            sqlparam1[14] = new SqlParameter("@detailid", SqlDbType.Int);
            sqlparam1[14].Value = NullHandler.Int32(obj.detailid);

            sqlparam1[15] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam1[15].Direction = ParameterDirection.Output;

            sqlparam1[16] = new SqlParameter("@pdate", SqlDbType.DateTime);
            sqlparam1[16].Value = NullHandler.DateTime(obj.pdate);
            sqlparam1[17] = new SqlParameter("@ndate", SqlDbType.VarChar);
            sqlparam1[17].Value = NullHandler.String(obj.ndate);
            sqlparam1[18] = new SqlParameter("@Remarks", SqlDbType.VarChar);
            sqlparam1[18].Value = NullHandler.String(obj.Remarks);
            sqlparam1[19] = new SqlParameter("@uuid", SqlDbType.Int);
            sqlparam1[19].Value = NullHandler.Int32(obj.uuid);

            sqlparam1[20] = new SqlParameter("@Bankid", SqlDbType.Int);
            sqlparam1[20].Value = NullHandler.Int32(obj.BankID);
            sqlparam1[21] = new SqlParameter("@CheqNo", SqlDbType.VarChar);
            sqlparam1[21].Value = NullHandler.String(obj.CheqNo);
            sqlparam1[22] = new SqlParameter("@CheqDate", SqlDbType.Date);
            sqlparam1[22].Value = NullHandler.DateTime(obj.CheqDate);
            sqlparam1[23] = new SqlParameter("@CheqAmt", SqlDbType.Decimal);
            sqlparam1[23].Value = NullHandler.Decimal(obj.CheqAmt);

            sqlparam1[24] = new SqlParameter("@BillType", SqlDbType.Int);
            sqlparam1[24].Value = NullHandler.Int32(obj.BillType);
            sqlparam1[25] = new SqlParameter("@BillDate", SqlDbType.Date);
            sqlparam1[25].Value = NullHandler.DateTime(obj.BillDate);
            sqlparam1[26] = new SqlParameter("@BillDateNep", SqlDbType.NVarChar);
            sqlparam1[26].Value = NullHandler.String(obj.BillDateNep);

            sqlparam1[27] = new SqlParameter("@Vatrate", SqlDbType.Decimal);
            sqlparam1[27].Value = NullHandler.Decimal(obj.pVatRate);
            sqlparam1[28] = new SqlParameter("@pdiscRate", SqlDbType.Decimal);
            sqlparam1[28].Value = NullHandler.Decimal(obj.pdiscRate);

            objCmnDal.InsertUpdateTable("[INSERTUPDATE_Sales_DETAILS]", "sp", sqlparam1);
            if (sqlparam1[15].Value != DBNull.Value)
                return sqlparam1[15].Value.ToString();
            else
                return null;
        }
        public DataTable GetVendordetails(ClsSalesBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@VEN_ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objbll.VEN_ID);
            return objCmnDal.GetTable("Bind_Vendor_details", "sp", sqlparam);
        }
    }
}