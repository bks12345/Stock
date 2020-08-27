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
    public class ClsChequeFormatSetupDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public string InsertUpdateCheqFormat(ClsChequeFormatSetupBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[12];
            sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.id);
            sqlparam[1] = new SqlParameter("@FormatName", SqlDbType.NVarChar);
            sqlparam[1].Value = NullHandler.String(obj.FormatName);
            sqlparam[2] = new SqlParameter("@Name", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.Name);
            sqlparam[3] = new SqlParameter("@Date", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.Date);
            sqlparam[4] = new SqlParameter("@AmountInWord", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(obj.AmountInWord);
            sqlparam[5] = new SqlParameter("@Amount", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(obj.Amount);
            sqlparam[6] = new SqlParameter("@auid", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.auid);
            sqlparam[7] = new SqlParameter("@uuid", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.uuid);
            sqlparam[8] = new SqlParameter("@adt", SqlDbType.DateTime);
            sqlparam[8].Value = NullHandler.DateTime(obj.adt);
            sqlparam[9] = new SqlParameter("@udt", SqlDbType.DateTime);
            sqlparam[9].Value = NullHandler.DateTime(obj.udt);
            sqlparam[10] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[11] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[11].Direction = ParameterDirection.Output;
            objCmnDal.InsertUpdateTable("sp_insertupdate_chequeformat", "sp", sqlparam);
            if (sqlparam[11].Value != DBNull.Value)
                return sqlparam[11].Value.ToString();
            else
                return null;

        }
        public DataTable GetData(ClsChequeFormatSetupBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.id);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("[sp_get_chequeformatbyid]", "sp", sqlparam);
            return ds;
        }
    }
}