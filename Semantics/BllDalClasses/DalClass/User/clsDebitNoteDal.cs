using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.DalClass.Common;
using System.Data.SqlClient;
using System.Data;
using Stock.BllDalClasses.BllClass.User;
using Stock.BllDalClasses.BllClass.Common;

namespace Stock.BllDalClasses.DalClass.User
{
    public class clsDebitNoteDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdatetbldefusersettings(clsDebitNoteBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[12];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ID);
            sqlparam[1] = new SqlParameter("@USERID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.USERID);
            sqlparam[2] = new SqlParameter("@usersignature", SqlDbType.Image);
            sqlparam[2].Value = (obj.usersignature);
            sqlparam[3] = new SqlParameter("@companyseal", SqlDbType.Image);
            sqlparam[3].Value = (obj.companyseal);
            sqlparam[4] = new SqlParameter("@ccEmail", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(obj.ccEmail);
            sqlparam[5] = new SqlParameter("@isSenderEmail", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(obj.isSenderEmail);
            sqlparam[6] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[6].Direction = ParameterDirection.Output;
            sqlparam[7] = new SqlParameter("@SIGNATUREURL", SqlDbType.VarChar);
            sqlparam[7].Value = NullHandler.String(obj.SIGNATUREURL);
            sqlparam[8] = new SqlParameter("@COMPANYSEALURL", SqlDbType.VarChar);
            sqlparam[8].Value = NullHandler.String(obj.COMPANYSEALURL);
            sqlparam[9] = new SqlParameter("@ISDELETED", SqlDbType.TinyInt);
            sqlparam[9].Value = NullHandler.Int32(obj.ISDELETED);
            sqlparam[10] = new SqlParameter("@uuid", SqlDbType.VarChar);
            sqlparam[10].Value = NullHandler.String(ClsCommon.UserCode);
            sqlparam[11] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(ClsCommon.BranchId);
            objCmnDal.InsertUpdateTable("insertupdatetbldefusersettings", "sp", sqlparam);
            if (sqlparam[6].Value != DBNull.Value)
                return sqlparam[6].Value.ToString();
            else
                return null;
        }
        public DataTable getUserSettings(clsDebitNoteBll objDebitNote)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@USERID",SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objDebitNote.USERID);
            return objCmnDal.GetTable("tbldefusersettings_get", "sp", sqlparam);

        }
    }
}