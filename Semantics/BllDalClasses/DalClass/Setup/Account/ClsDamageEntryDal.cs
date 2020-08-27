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
    public class ClsDamageEntryDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public DataTable GetDamageItem(ClsDamageItemBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@EDESCRIPTION", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objbll.EDESCRIPTION);
            return objCmnDal.GetTable("GET_PURCHASE_ITEM", "sp", sqlparam);
        }    
        public DataSet GetAllDamageDetails(ClsDamageItemBll objbll)
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
            ds = objCmnDal.GetTableSet("GET_Damage_DETAILS", "sp", sqlparam);
            return ds;
        }
        public string InsertUpdate_DamageEntry(ClsDamageItemBll obj)
        {
            SqlParameter[] sqlparam1 = new SqlParameter[18];
            sqlparam1[0] = new SqlParameter("@DamageID", SqlDbType.Int);
            sqlparam1[0].Value = NullHandler.Int32(obj.DamageID);
            sqlparam1[1] = new SqlParameter("@Fiscalid", SqlDbType.Int);
            sqlparam1[1].Value = NullHandler.Int32(obj.Fiscalid);
            sqlparam1[2] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam1[2].Value = NullHandler.Int32(obj.branchid);
            sqlparam1[3] = new SqlParameter("@PONo", SqlDbType.Int);
            sqlparam1[3].Value = NullHandler.Int32(obj.PONo);
            sqlparam1[4] = new SqlParameter("@dtDamageentrydetails", SqlDbType.Structured);
            sqlparam1[4].Value = (obj.dtDamageentrydetails);
            sqlparam1[5] = new SqlParameter("@subbranchid ", SqlDbType.Int);
            sqlparam1[5].Value = NullHandler.Int32(obj.subbranchid);
            sqlparam1[6] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam1[6].Direction = ParameterDirection.Output;
            sqlparam1[7] = new SqlParameter("@Remarks", SqlDbType.VarChar);
            sqlparam1[7].Value = NullHandler.String(obj.Remarks);
            sqlparam1[8] = new SqlParameter("@uuid", SqlDbType.Int);
            sqlparam1[8].Value = NullHandler.Int32(obj.uuid);
            sqlparam1[9] = new SqlParameter("@DamageiNo", SqlDbType.Int);
            sqlparam1[9].Value = NullHandler.Int32(obj.Damageno);

            sqlparam1[10] = new SqlParameter("@Vatrate", SqlDbType.Decimal);
            sqlparam1[10].Value = NullHandler.Decimal(obj.pVatRate);
            sqlparam1[11] = new SqlParameter("@DiscRate", SqlDbType.Decimal);
            sqlparam1[11].Value = NullHandler.Decimal(obj.pdiscRate);

            sqlparam1[12] = new SqlParameter("@pTdsAmt", SqlDbType.Decimal);
            sqlparam1[12].Value = NullHandler.Decimal(obj.pTdsAmt);
            sqlparam1[13] = new SqlParameter("@pTdsRate", SqlDbType.Decimal);
            sqlparam1[13].Value = NullHandler.Decimal(obj.pTdsRate);

            sqlparam1[14] = new SqlParameter("@total", SqlDbType.Decimal);
            sqlparam1[14].Value = NullHandler.Decimal(obj.pAmount);
            sqlparam1[15] = new SqlParameter("@pdiscAmt", SqlDbType.Decimal);
            sqlparam1[15].Value = NullHandler.Decimal(obj.pdiscAmt);
            sqlparam1[16] = new SqlParameter("@pVatAmt", SqlDbType.Decimal);
            sqlparam1[16].Value = NullHandler.Decimal(obj.pVatAmt);
            sqlparam1[17] = new SqlParameter("@pNetAmt", SqlDbType.Decimal);
            sqlparam1[17].Value = NullHandler.Decimal(obj.pNetAmt);

            objCmnDal.InsertUpdateTable("INSERTUPDATE_Damage_Entry_DETAILS", "sp", sqlparam1);
            if (sqlparam1[6].Value != DBNull.Value)
                return sqlparam1[6].Value.ToString();
            else
                return null;
        }
        public DataTable Damage_Entry_DETAILS(ClsDamageItemBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[0];
            return objCmnDal.GetTable("Damage_Entry_DETAILS", "sp", null);
        }
    }
}