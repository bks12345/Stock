using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensure.DalClass.Common;
using Ensure.BllDalClasses.BllClass.Setup.Account;
using System.Data.SqlClient;
using System.Data;
using Ensure.BllDalClasses.BllClass.Common;

namespace Ensure.BllDalClasses.DalClass.Setup.Account
{
    public class clsPurchaseEntryDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdate_PurchaseEntry(clsPurchaseEntryBll obj, ref int prmPurID)
        {
            SqlParameter[] sqlparam = new SqlParameter[16];
            sqlparam[0] = new SqlParameter("@PurchaseID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.PurchaseID);
            sqlparam[1] = new SqlParameter("@Fiscalid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.Fiscalid);
            sqlparam[2] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.branchid);
            sqlparam[3] = new SqlParameter("@vendorid", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.vendorid);
            sqlparam[4] = new SqlParameter("@pdate", SqlDbType.Date);
            sqlparam[4].Value = NullHandler.DateTime(obj.pdate);
            sqlparam[5] = new SqlParameter("@billno", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(obj.billno);
            sqlparam[6] = new SqlParameter("@pAmount", SqlDbType.Decimal);
            sqlparam[6].Value = NullHandler.Decimal(obj.pAmount);
            sqlparam[7] = new SqlParameter("@pdiscAmt", SqlDbType.Decimal);
            sqlparam[7].Value = NullHandler.Decimal(obj.pdiscAmt);
            sqlparam[8] = new SqlParameter("@pVatAmt", SqlDbType.Decimal);
            sqlparam[8].Value = NullHandler.Decimal(obj.pVatAmt);
            sqlparam[9] = new SqlParameter("@pNetAmt", SqlDbType.Decimal);
            sqlparam[9].Value = NullHandler.Decimal(obj.pNetAmt);
            sqlparam[10] = new SqlParameter("@IsDeleted", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(obj.IsDeleted);
            sqlparam[11] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[11].Direction = ParameterDirection.Output;
            sqlparam[12] = new SqlParameter("@Master_id", SqlDbType.Int);
            sqlparam[12].Direction = ParameterDirection.Output;
            sqlparam[13] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[13].Value = NullHandler.String(ClsCommon.UserCode);
            sqlparam[14] = new SqlParameter("@vatoptionid", SqlDbType.Int);
            sqlparam[14].Value = NullHandler.Int32(obj.vatoptionid);
            sqlparam[15] = new SqlParameter("@pTypeid", SqlDbType.Int);
            sqlparam[15].Value = NullHandler.Int32(obj.ptypeid);
            //sqlparam[16] = new SqlParameter("@AccCode", SqlDbType.VarChar);
            //sqlparam[16].Value = NullHandler.String(obj.AccCode);
            //sqlparam[17] = new SqlParameter("@accDesc", SqlDbType.VarChar);
            //sqlparam[17].Value = NullHandler.String(obj.accDesc);
            //sqlparam[18] = new SqlParameter("@drAmt", SqlDbType.Decimal);
            //sqlparam[18].Value = NullHandler.Decimal(obj.drAmt);
            //sqlparam[19] = new SqlParameter("@crAmt", SqlDbType.Decimal);
            //sqlparam[19].Value = NullHandler.Decimal(obj.crAmt);
            //sqlparam[20] = new SqlParameter("@chqNo", SqlDbType.Decimal);
            //sqlparam[20].Value = NullHandler.Decimal(obj.chqNo);
          
            string _errMsg = "";
            prmPurID = 0;
            objCmnDal.InsertUpdateTable("acc_purchaseEntry_insertUpdate", "sp", sqlparam,ref _errMsg);
            if (sqlparam[11].Value != DBNull.Value)
           
                if (_errMsg.Length > 2)
                {
                    return _errMsg;
                }
                else
                {
                if (sqlparam[11].Value.ToString() == "insert")
                    {
                        prmPurID = ClsConvertTo.Int32(sqlparam[12].Value);
                    }
                    return sqlparam[11].Value.ToString();
                }
            else
                return null;
        }

        public DataTable LoadPurchaseEntry(clsPurchaseEntryBll clsApp)
        {

            return objCmnDal.GetTable("acc_purchaseEntryLoad_get", "sp", null);
        }
        public DataTable ShowPurchaseEntry(clsPurchaseEntryBll clsApp)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@billno", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(clsApp.billno);
            sqlparam[1] = new SqlParameter("@Fiscalid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(clsApp.Fiscalid);
            sqlparam[2] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(clsApp.branchid);
            sqlparam[3] = new SqlParameter("@vendorid", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(clsApp.vendorid);

            return objCmnDal.GetTable("acc_purchaseEntry_show", "sp", sqlparam);
        }

        public DataTable GetData(clsPurchaseEntryBll clsApp)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@PurchaseID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsApp.PurchaseID);

            return objCmnDal.GetTable("acc_purchaseEntry_get", "sp", sqlparam);
        }
    }
}