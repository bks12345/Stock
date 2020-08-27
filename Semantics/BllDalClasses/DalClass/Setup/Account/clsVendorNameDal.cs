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
    public class clsVendorNameDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdate_VendorName(clsVendorNameBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[17];
            sqlparam[0] = new SqlParameter("@ADDRESS", SqlDbType.NVarChar);
            sqlparam[0].Value = NullHandler.String(obj.ADDRESS);
            sqlparam[1] = new SqlParameter("@EMAILADDRESS", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.EMAILADDRESS);
            sqlparam[2] = new SqlParameter("@MOBILENO", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.MOBILENO);
            sqlparam[3] = new SqlParameter("@PANNO", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.PANNO);
            sqlparam[4] = new SqlParameter("@TELEPHONENO", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(obj.TELEPHONENO);
            sqlparam[5] = new SqlParameter("@VATNO", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(obj.VATNO);
            sqlparam[6] = new SqlParameter("@VENDORCODE", SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(obj.VENDORCODE);
            sqlparam[7] = new SqlParameter("@VENDORDESC", SqlDbType.VarChar);
            sqlparam[7].Value = NullHandler.String(obj.VENDORDESC);
            sqlparam[8] = new SqlParameter("@NVENDORDESC", SqlDbType.NVarChar);
            sqlparam[8].Value = NullHandler.String(obj.NVENDORDESC);
            sqlparam[9] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[9].Value = NullHandler.String(obj.AUID);
            sqlparam[10] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[10].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[11] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[11].Value = NullHandler.String(obj.UUID);
            sqlparam[12] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[12].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[13] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[13].Direction = ParameterDirection.Output;
            sqlparam[14] = new SqlParameter("@VEN_ID", SqlDbType.Int);
            sqlparam[14].Value= NullHandler.Int32(obj.VEN_ID);
            sqlparam[15] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[15].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[16] = new SqlParameter("@ACCOUNTID", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Int32(obj.ACCOUNTID);
            objCmnDal.InsertUpdateTable("acc_vendorName_insertUpdate", "sp", sqlparam);
            if (sqlparam[13].Value != DBNull.Value)
                return sqlparam[13].Value.ToString();
            else
                return null;
        }

        public DataTable LoadVendorName(clsVendorNameBll clsApp)
        {
           
            return  objCmnDal.GetTable("[acc_LoadvendorName_get]", "sp", null);
            //return ds;
            //return objCmnDal.GetTable("select * from TBLVENDORINFO", "text", null);
        }

        public DataTable GetData(clsVendorNameBll clsApp)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@VEN_ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsApp.VEN_ID);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("[acc_vendorName_get]", "sp", sqlparam);
            return ds;
        }
        public DataTable GetByKycNo(clsVendorNameBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@KYCNO", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(obj.KYCNO);
            return objCmnDal.GetTable("[SP_GET_KYCNO]", "sp", sqlparam);
        }

        internal DataTable getcode(clsVendorNameBll clsApp)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];

            sqlparam[0] = new SqlParameter("@VENDORCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(clsApp.VENDORCODE);
            return objCmnDal.GetTable("[acc_get_vendorCode]", "sp", sqlparam);
        }

       
      
    }
}