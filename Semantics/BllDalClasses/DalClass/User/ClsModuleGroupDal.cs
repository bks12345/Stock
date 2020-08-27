using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllDalClasses.BllClass.User;
using System.Data.SqlClient;
using System.Data;
using Stock.DalClass.Common;
using Stock.BllDalClasses.BllClass.Common;

namespace Stock.BllDalClasses.DalClass.User
{
    public class ClsModuleGroupDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdateModuleGroup(ClsModuleGroupBll objModuleGroup)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[9];
                sqlparam[0] = new SqlParameter("@module_group_ID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objModuleGroup.Module_Group_ID);
                sqlparam[1] = new SqlParameter("@module_group_Name", SqlDbType.VarChar);
                sqlparam[1].Value = NullHandler.String(objModuleGroup.Module_Group_Name);
                sqlparam[2] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
                sqlparam[2].Direction = ParameterDirection.Output;
                sqlparam[3] = new SqlParameter("@BranchId", SqlDbType.Int);
                sqlparam[3].Value = NullHandler.Int32(ClsCommon.BranchId);
                sqlparam[4] = new SqlParameter("@AUID", SqlDbType.VarChar);
                sqlparam[4].Value = NullHandler.String(objModuleGroup.AUID);
                sqlparam[5] = new SqlParameter("@ADT", SqlDbType.DateTime);
                sqlparam[5].Value = NullHandler.DateTime(objModuleGroup.ADT);
                sqlparam[6] = new SqlParameter("@UUID", SqlDbType.VarChar);
                sqlparam[6].Value = NullHandler.String(objModuleGroup.UUID);
                sqlparam[7] = new SqlParameter("@UDT", SqlDbType.DateTime);
                sqlparam[7].Value = NullHandler.DateTime(objModuleGroup.UDT);
                sqlparam[8] = new SqlParameter("@islock", SqlDbType.Int);
                sqlparam[8].Value = NullHandler.Int32(objModuleGroup.islock);
                objCmnDal.InsertUpdateTable("Security_moduleGroup_insertUpdate", "sp", sqlparam);
                if (sqlparam[2].Value != DBNull.Value)
                    return sqlparam[2].Value.ToString();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable GetModuleGroup(ClsModuleGroupBll objModuleGroup)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@module_group_ID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objModuleGroup.Module_Group_ID);
                return objCmnDal.GetTable("Security_moduleGroup_get", "sp", sqlparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}