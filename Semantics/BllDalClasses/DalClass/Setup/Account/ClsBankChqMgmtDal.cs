using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensure.DalClass.Common;
using Ensure.BllDalClasses.BllClass.Setup.Account;
using System.Data.SqlClient;
using System.Data;
using Ensure.BllDalClasses.BllClass.User;

namespace Ensure.BllDalClasses.DalClass.Setup.Account
{
    public class ClsBankChqMgmtDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdateBankChqMgmt(ClsBankChqMgmtBll obj, ref DataTable dt)
        {
            SqlParameter[] sqlparam = new SqlParameter[11];
            sqlparam[0] = new SqlParameter("@CHEQUEID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.CHEQUEID);
            sqlparam[1] = new SqlParameter("@BANKACCOUNTID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.BANKACCOUNTID);
            sqlparam[2] = new SqlParameter("@CHEQUENUMBER", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.CHEQUENUMBER);
            sqlparam[3] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[3].Direction = ParameterDirection.Output;
            sqlparam[4] = new SqlParameter("@CHEQUESTATUS", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(obj.CHEQUESTATUS);
            sqlparam[5] = new SqlParameter("@APPROVEDBYID", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(obj.APPROVEDBYID);
            sqlparam[6] = new SqlParameter("@APPDATETIME", SqlDbType.DateTime);
            sqlparam[6].Value = NullHandler.DateTime(obj.APPDATETIME);
            sqlparam[7] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.BRANCHID);
            sqlparam[8] = new SqlParameter("@APPROVEDID", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(obj.APPROVEDID);
            sqlparam[9] = new SqlParameter("@CHEQUEFROM", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(obj.CHEQUEFROM);
            sqlparam[10] = new SqlParameter("@CHEQUETO", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(obj.CHEQUETO);
            
            DataRow workRow = dt.NewRow();
            workRow["ProcName"] = "acc_setup_BankChqMgmt";
            workRow["ProcType"] = "sp";
            workRow["sqlParam"] = sqlparam;
            dt.Rows.Add(workRow);
            return "";
        }

        public DataTable getBankChqMgmt(ClsBankChqMgmtBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@BANKACCOUNTID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.BANKACCOUNTID);
            sqlparam[1] = new SqlParameter("@CHEQUESTATUS", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.CHEQUESTATUS);
            sqlparam[2] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.BRANCHID);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("acc_BankChqMgmt_get", "sp", sqlparam);
            return ds;
        }
        public DataTable getBankChqMgmtByID(ClsBankChqMgmtBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@CHEQUEID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.CHEQUEID);
       
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("acc_BankChqMgmt_getById", "sp", sqlparam);
            return ds;
        }
        public DataTable getBankChqMgmtMinimumNo(ClsBankChqMgmtBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@BANKACCOUNTID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.BANKACCOUNTID);
            sqlparam[1] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.BRANCHID);

            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("acc_BankChqMgmt_get_minimumChq", "sp", sqlparam);
            return ds;
        }

        public DataTable GetBookNo_ChequeNo(ClsBankChqMgmtBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@BankAccId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.BANKACCOUNTID);
            sqlparam[1] = new SqlParameter("@BookNoId", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.BookNoId);
            sqlparam[2] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.BRANCHID);
            sqlparam[3] = new SqlParameter("@flag", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.flag);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("GetBookNo_ChequeNo", "sp", sqlparam);
            return ds;
        }
      

    }
}