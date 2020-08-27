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
    public class ClsDepartmentSetupDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public string InsertUpdateDepartmentSetup(ClsDepartmentSetupbll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[9];
            sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.id);
            sqlparam[1] = new SqlParameter("@Ndeptname", SqlDbType.NVarChar);
            sqlparam[1].Value = NullHandler.String(obj.Ndeptnamey);
            sqlparam[2] = new SqlParameter("@Edeptname", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.Edeptname);
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
            objCmnDal.InsertUpdateTable("[store_deptnamesetup_insertUpdate]", "sp", sqlparam);
            if (sqlparam[7].Value != DBNull.Value)
                return sqlparam[7].Value.ToString();
            else
                return null;

        }
        public DataTable GetDepartmentSetup(ClsDepartmentSetupbll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.id);
            sqlparam[1] = new SqlParameter("@Edeptname", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.Edeptname);
            return objCmnDal.GetTable("[store_DepartmentSetup_GET]", "sp", sqlparam);
        }

    }
}