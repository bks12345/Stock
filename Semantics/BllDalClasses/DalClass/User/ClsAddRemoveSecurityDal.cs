using Stock.BllDalClasses.BllClass.Common;
using Stock.BllDalClasses.BllClass.User;
using Stock.DalClass.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.DalClass.User
{
    public class ClsAddRemoveSecurityDal
    {
        clsCommonDal objGrpPermissionBllCmnDal = new clsCommonDal();
        public string AddDefaultsecurity(ClsAddRemoveSecuritybll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@USERGROUPID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.USERGROUPID);
            sqlparam[1] = new SqlParameter("@AUID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(ClsConvertTo.Int32(ClsCommon.UserCode));
            sqlparam[2] = new SqlParameter("@securityNames", SqlDbType.Structured);
            sqlparam[2].Value = (obj.dtsecurity);
            sqlparam[3] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[3].Direction = ParameterDirection.Output;
            sqlparam[4] = new SqlParameter("@flag", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(obj.flag);
            objGrpPermissionBllCmnDal.InsertUpdateTable("Add_Remove_DefaultSecurity", "sp", sqlparam);
            if (sqlparam[3].Value != DBNull.Value)
                return sqlparam[3].Value.ToString();
            else
                return null;
        }
    }
}