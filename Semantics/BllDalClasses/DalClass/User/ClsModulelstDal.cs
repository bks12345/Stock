using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.DalClass.Common;
using System.Data.SqlClient;
using System.Data;
using Stock.BllDalClasses.BllClass.Common;
using Stock.BllDalClasses.BllClass.User;

namespace Stock.BllDalClasses.DalClass.User
{
    public class ClsModulelstDal
    {

        clsCommonDal objCmnDal = new clsCommonDal();

        #region
        //public string InsertUpdateTBL_MODULELIST(ClassName obj)
        //{
        //    SqlParameter[] sqlparam = new SqlParameter[4];
        //    sqlparam[0] = new SqlParameter("@MODULEID", SqlDbType.Int);
        //    sqlparam[0].Value = NullHandler.Int32(obj.MODULEID);
        //    sqlparam[1] = new SqlParameter("@MODULENAME", SqlDbType.VarChar);
        //    sqlparam[1].Value = NullHandler.String(obj.MODULENAME);
        //    sqlparam[2] = new SqlParameter("@MODULE_GROUP_ID", SqlDbType.Int);
        //    sqlparam[2].Value = NullHandler.Int32(obj.MODULE_GROUP_ID);
        //    sqlparam[3] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
        //    sqlparam[3].Direction = ParameterDirection.Output;
        //    objCmnDal.InsertUpdateTable("insertupdateTBL_MODULELIST", "sp", sqlparam);
        //    if (sqlparam[3].Value != DBNull.Value)
        //        return sqlparam[3].Value.ToString();
        //    else
        //        return null;
        //}                
        #endregion


        public string GetMaxModuleNameSno(ClsModulelstBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@MODULE_GROUP_ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.MODULE_GROUP_ID);

            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("security_get_ModuleNameSno", "sp", sqlparam);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["MaxModuleNameSno"].ToString();
                }
                else return "0";
            }
            else return "0";
        }

        public DataTable GetModulelst(ClsModulelstBll objModulelistBll)
        {
            
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@MODULE_GROUP_ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objModulelistBll.MODULE_GROUP_ID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("Security_grpWise_getModuleName", "sp", sqlparam);
            return dt;
        }

        public string InsertUpdateModuleList(ClsModulelstBll objModuleList)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[11];
                sqlparam[0] = new SqlParameter("@moduleID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objModuleList.MODULEID);
                sqlparam[1] = new SqlParameter("@moduleName", SqlDbType.VarChar);
                sqlparam[1].Value = NullHandler.String(objModuleList.MODULENAME);
                sqlparam[2] = new SqlParameter("@module_group_ID", SqlDbType.Int);
                sqlparam[2].Value = NullHandler.Int32(objModuleList.MODULE_GROUP_ID);
                sqlparam[3] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
                sqlparam[3].Direction = ParameterDirection.Output;
                sqlparam[4] = new SqlParameter("@ModuleNameSno", SqlDbType.Int);
                sqlparam[4].Value = NullHandler.Int32(objModuleList.ModuleNameSno);
                sqlparam[5] = new SqlParameter("@BranchId", SqlDbType.Int);
                sqlparam[5].Value = NullHandler.Int32(ClsCommon.BranchId);
                sqlparam[6] = new SqlParameter("@AUID", SqlDbType.VarChar);
                sqlparam[6].Value = NullHandler.String(objModuleList.AUID);
                sqlparam[7] = new SqlParameter("@ADT", SqlDbType.DateTime);
                sqlparam[7].Value = NullHandler.DateTime(objModuleList.ADT);
                sqlparam[8] = new SqlParameter("@UUID", SqlDbType.VarChar);
                sqlparam[8].Value = NullHandler.String(objModuleList.UUID);
                sqlparam[9] = new SqlParameter("@UDT", SqlDbType.DateTime);
                sqlparam[9].Value = NullHandler.DateTime(objModuleList.UDT);
                sqlparam[10] = new SqlParameter("@islock",SqlDbType.Int);
                sqlparam[10].Value = NullHandler.Int32(objModuleList.islock);
                objCmnDal.InsertUpdateTable("Security_moduleList_insertUpdate", "sp", sqlparam);
                if (sqlparam[3].Value != DBNull.Value)
                    return sqlparam[3].Value.ToString();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetModuleList(ClsModulelstBll objModuleList)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@moduleID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objModuleList.MODULEID);
                return objCmnDal.GetTable("Security_moduleList_get", "sp", sqlparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetModuleListByModuleGroupID(ClsModulelstBll objModuleList)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@moduleGroupId", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objModuleList.MODULE_GROUP_ID);
                return objCmnDal.GetTable("Security_GetModuleListByModuleGroupId", "sp", sqlparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region
        //public DataTable GetModuleList(ClsModulelistBll objModuleList)
        //{
        //    try
        //    {
        //        SqlParameter[] sqlparam = new SqlParameter[1];
        //        sqlparam[0] = new SqlParameter("@module_group_ID", SqlDbType.Int);
        //        sqlparam[0].Value = NullHandler.Int32(objModuleGroup.Module_Group_ID);
        //        return objCmnDal.GetTable("user_moduleGroup_get", "sp", sqlparam);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion
    }
}