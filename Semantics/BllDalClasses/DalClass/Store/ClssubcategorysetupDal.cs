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
    public class ClssubcategorysetupDal
    {
         clsCommonDal objCmnDal = new clsCommonDal();
        public string InsertUpdatesubcategory(Clssubcategorysetupbll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[10];
            sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.id);
            sqlparam[1] = new SqlParameter("@NSubcategory", SqlDbType.NVarChar);
            sqlparam[1].Value = NullHandler.String(obj.NSubcategory);
            sqlparam[2] = new SqlParameter("@ESubcategory", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.ESubcategory);
            sqlparam[3] = new SqlParameter("@AUID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.AUID);
            sqlparam[4] = new SqlParameter("@ADT", SqlDbType.Date);
            sqlparam[4].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[5] = new SqlParameter("@UUID", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(obj.UUID);
            sqlparam[6] = new SqlParameter("@UDT", SqlDbType.Date);
            sqlparam[6].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[7] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[7].Direction = ParameterDirection.Output;
            sqlparam[8] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[9] = new SqlParameter("@category", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(obj.category);
            objCmnDal.InsertUpdateTable("store_Subcategorysetup_insertUpdate", "sp", sqlparam);
            if (sqlparam[7].Value != DBNull.Value)
                return sqlparam[7].Value.ToString();
            else
                return null;

        }
        public DataTable Getsubcategory(Clssubcategorysetupbll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.id);
           // sqlparam[1] = new SqlParameter("@categoryid", SqlDbType.Int);
            //sqlparam[1].Value = NullHandler.Int32(obj.category);
            return objCmnDal.GetTable("store_Subcategorysetup_GET", "sp", sqlparam);
        }
    }
}