using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensure.DalClass.Common;
using System.Data.SqlClient;
using System.Data;
using Ensure.BllDalClasses.BllClass.Setup.Account;
using Ensure.BllDalClasses.BllClass.Common;

namespace Ensure.BllDalClasses.DalClass.Setup.Account
{
    public class clsVoucherTypeDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdateic_vouchertype(clsVoucherTypeBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[18];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ID);
            sqlparam[1] = new SqlParameter("@SNO", SqlDbType.Decimal);
            sqlparam[1].Value = NullHandler.Decimal(obj.SNO);
            sqlparam[2] = new SqlParameter("@ETITLE", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.ETITLE);
            sqlparam[3] = new SqlParameter("@NTITLE", SqlDbType.NVarChar);
            sqlparam[3].Value = NullHandler.String(obj.NTITLE);
            sqlparam[4] = new SqlParameter("@EABBRV", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(obj.EABBRV);
            sqlparam[5] = new SqlParameter("@NABBRV", SqlDbType.NVarChar);
            sqlparam[5].Value = NullHandler.String(obj.NABBRV);
            sqlparam[6] = new SqlParameter("@VOUCHERTYPE", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.VOUCHERTYPE);
            sqlparam[7] = new SqlParameter("@SHOW", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.SHOW);
            sqlparam[8] = new SqlParameter("@TOSHOW", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(obj.TOSHOW);
            sqlparam[9] = new SqlParameter("@STATUS", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(obj.STATUS);
            sqlparam[10] = new SqlParameter("@AUID", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(obj.AUID);
            sqlparam[11] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[11].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[12] = new SqlParameter("@UUID", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(obj.UUID);
            sqlparam[13] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[13].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[14] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[14].Direction = ParameterDirection.Output;
            sqlparam[15] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[15].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[16] = new SqlParameter("@moduleid", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Int32(obj.moduleid);
            sqlparam[17] = new SqlParameter("@islock", SqlDbType.Int);
            sqlparam[17].Value = NullHandler.Int32(obj.islock);
            objCmnDal.InsertUpdateTable("acc_voucherType_insertUpdate", "sp", sqlparam);
            if (sqlparam[14].Value != DBNull.Value)
                return sqlparam[14].Value.ToString();
            else
                return null;
        }
        public DataTable LoadVoucherList(clsVoucherTypeBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.ID);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("[acc_icVoucherType_getList]", "sp", sqlparam);
            return ds;
            
        }
        public DataTable LoadVoucherGetList()
        {
            return objCmnDal.GetTable("select * from ic_vouchertype", "text", null);
        }
    }
}