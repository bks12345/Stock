using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensure.DalClass.Common;
using System.Data.SqlClient;
using System.Data;
using Ensure.BllDalClasses.BllClass.Setup.Account;

namespace Ensure.BllDalClasses.DalClass.Setup.Account
{
    public class clsTransactionTypeDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdate_TransactionType(clsTransactionTypeBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[12];
            sqlparam[0] = new SqlParameter("@VOUCHERTYPEID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.VOUCHERTYPEID);
            sqlparam[1] = new SqlParameter("@TRANSACTIONNAME", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.TRANSACTIONNAME);
            sqlparam[2] = new SqlParameter("@CODE", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.CODE);
            sqlparam[3] = new SqlParameter("@ABBR", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.ABBR);
            sqlparam[4] = new SqlParameter("@msg", SqlDbType.VarChar, 40);
            sqlparam[4].Direction = ParameterDirection.Output;
            sqlparam[5] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(obj.ID);
            sqlparam[6] = new SqlParameter("@TRANSACTIONNAMEnep", SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(obj.TRANSACTIONNAMEnep);
            sqlparam[7] = new SqlParameter("@AUID", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.AUID);
            sqlparam[8] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[8].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[9] = new SqlParameter("@UUID", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(obj.UUID);
            sqlparam[10] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[10].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[11] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(obj.branchid);




            objCmnDal.InsertUpdateTable("acc_TransactionType_insertUpdate", "sp", sqlparam);
            if (sqlparam[4].Value != DBNull.Value)
                return sqlparam[4].Value.ToString();
            else
                return null;
        }
        public DataTable GetTransactionType(clsTransactionTypeBll obj)
        {

            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ID);
               DataTable ds = new DataTable();
               ds = objCmnDal.GetTable("acc_TransactionType_get", "sp", sqlparam);
            return ds;
           
        }
    }
}