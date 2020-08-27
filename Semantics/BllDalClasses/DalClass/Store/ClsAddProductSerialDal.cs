using Stock.BllDalClasses.BllClass.Common;
using Stock.BllDalClasses.BllClass.Store;
using Stock.DalClass.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.DalClass.Store
{
    public class ClsAddProductSerialDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public string InsertUpdateAddProductSerialsetup(ClsAddProductSerialbll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[11];
            sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.id);
            sqlparam[1] = new SqlParameter("@SerialNo", SqlDbType.NVarChar);
            sqlparam[1].Value = NullHandler.String(obj.SerialNo);
            sqlparam[2] = new SqlParameter("@AUID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.AUID);
            sqlparam[3] = new SqlParameter("@ADT", SqlDbType.Date);
            sqlparam[3].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[4] = new SqlParameter("@UUID", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(obj.UUID);
            sqlparam[5] = new SqlParameter("@UDT", SqlDbType.Date);
            sqlparam[5].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[6] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[6].Direction = ParameterDirection.Output;
            sqlparam[7] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[8] = new SqlParameter("@categoryid", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(obj.categoryid);
            sqlparam[9] = new SqlParameter("@subcategoryid", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(obj.subcategoryid);
            sqlparam[10] = new SqlParameter("@Particularid", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(obj.Particularid);
            objCmnDal.InsertUpdateTable("[store_Add_ProductSetup_insertUpdate]", "sp", sqlparam);
            if (sqlparam[7].Value != DBNull.Value)
                return sqlparam[7].Value.ToString();
            else
                return null;
        }
        public DataTable GetAddProductSerialsetup(ClsAddProductSerialbll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.id);
            sqlparam[1] = new SqlParameter("@categoryid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.categoryid);
            sqlparam[2] = new SqlParameter("@subcategoryid", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.subcategoryid);
            return objCmnDal.GetTable("store_Add_ProductSetup_GET", "sp", sqlparam);
        }    
    }    
}