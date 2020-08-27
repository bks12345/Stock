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
    public class ClsPurchaseItemDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public string InsertUpdatePurchaseItem(ClsPurchaseItemBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[9];
            sqlparam[0] = new SqlParameter("@PURCHASEID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.PURCHASEID);
          
            sqlparam[1] = new SqlParameter("@EDESCRIPTION", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.EDESCRIPTION);
            sqlparam[2] = new SqlParameter("@NDESCRIPTION", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.NDESCRIPTION);
            sqlparam[3] = new SqlParameter("@ACCOUNTCODE", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.ACCOUNTCODE);
            sqlparam[4] = new SqlParameter("@FIXEDACCESS", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(obj.FIXEDACCESS);
            sqlparam[5] = new SqlParameter("@MSG", SqlDbType.VarChar, 20);
            sqlparam[5].Direction = ParameterDirection.Output;
            sqlparam[6] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.branchid);
            sqlparam[7] = new SqlParameter("@uuid", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.uuid);
            sqlparam[8] = new SqlParameter("@IsInventoryItem", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(obj.IsInventoryItem);
            objCmnDal.InsertUpdateTable("SP_INSERTUPDATE_PURCHASE", "sp", sqlparam);
            if (sqlparam[5].Value != DBNull.Value)
                return sqlparam[5].Value.ToString();
            else
                return null;
        }
        public DataTable GetPurchaseList(ClsPurchaseItemBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@PURCHASEID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.PURCHASEID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("GET_ALL_PARTICULAR", "sp", sqlparam);
            return dt;
        }
    }
}