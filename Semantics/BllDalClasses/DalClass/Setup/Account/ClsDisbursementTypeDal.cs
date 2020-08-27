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
    public class ClsDisbursementTypeDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public DataTable GetDisbursementList(ClsDisbursementTypeBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objbll.ID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("GET_DESBURSEMENT_LIST", "sp", sqlparam);
            return dt;
        }
        public string InsertUpdateDisbursement(ClsDisbursementTypeBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[12];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objbll.ID);
            sqlparam[1] = new SqlParameter("@ETITLE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objbll.ETITLE);
            sqlparam[2] = new SqlParameter("@NTITLE", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objbll.NTITLE);
            sqlparam[3] = new SqlParameter("@EABBRV", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(objbll.EABBRV);
            sqlparam[4] = new SqlParameter("@NABBRV", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(objbll.NABBRV);
            sqlparam[5] = new SqlParameter("@STATUS", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(objbll.LOCK);
            sqlparam[6] = new SqlParameter("@AUID", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(objbll.AUID);
            sqlparam[7] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[7].Value = NullHandler.DateTime(objbll.ADT);
            sqlparam[8] = new SqlParameter("@UUID", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(objbll.UUID);
            sqlparam[9] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[9].Value = NullHandler.DateTime(objbll.UDT);
            sqlparam[10] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[10].Direction = ParameterDirection.Output;
            sqlparam[11] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(objbll.branchid);
            objCmnDal.InsertUpdateTable("USP_INSERTUPDATE_DISBURDEMENT", "sp", sqlparam);
            if (sqlparam[10].Value != DBNull.Value)
                return sqlparam[10].Value.ToString();
            else
                return null;
        }


           


    }
}