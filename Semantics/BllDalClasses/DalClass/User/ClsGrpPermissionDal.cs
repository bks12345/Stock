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
    public class ClsGrpPermissionDal
    {
        clsCommonDal objGrpPermissionBllCmnDal = new clsCommonDal();

        public string InsertUpdateGrpPermission(ClsGrpPermissionBll objGrpPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[13];
            sqlparam[0] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objGrpPermissionBll.BRANCHCODE);
            sqlparam[1] = new SqlParameter("@USERGROUPID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objGrpPermissionBll.USERGROUPID);
            sqlparam[2] = new SqlParameter("@HASPERMISSION", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objGrpPermissionBll.HASPERMISSION);
            sqlparam[3] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(objGrpPermissionBll.AUID);
            sqlparam[4] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[4].Value = NullHandler.DateTime(objGrpPermissionBll.ADT);
            sqlparam[5] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(objGrpPermissionBll.UUID);
            sqlparam[6] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[6].Value = NullHandler.DateTime(objGrpPermissionBll.UDT);
            sqlparam[7] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[7].Direction = ParameterDirection.Output;
            sqlparam[8] = new SqlParameter("@securityNames", SqlDbType.Structured);
            sqlparam[8].Value = (objGrpPermissionBll.dtsecurity);
            sqlparam[9] = new SqlParameter("@MODULEID", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(objGrpPermissionBll.MODULEID);
            sqlparam[10] = new SqlParameter("@BranchName", SqlDbType.VarChar);
            sqlparam[10].Value = NullHandler.String(objGrpPermissionBll.BranchName);
            sqlparam[11] = new SqlParameter("@userGroup", SqlDbType.VarChar);
            sqlparam[11].Value = NullHandler.String(objGrpPermissionBll.userGroup);
            sqlparam[12] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(objGrpPermissionBll.SUBBRANCHID);
            objGrpPermissionBllCmnDal.InsertUpdateTable("Security_Permission_Insertupdate", "sp", sqlparam);
            if (sqlparam[7].Value != DBNull.Value)
                return sqlparam[7].Value.ToString();
            else
                return null;
        }



        public string InsertGrpPermission(ClsGrpPermissionBll objGrpPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[12];
            sqlparam[0] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objGrpPermissionBll.BRANCHCODE);
            sqlparam[1] = new SqlParameter("@SUBBRNCHCODE", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objGrpPermissionBll.SUBBRANCHCODE);
            sqlparam[2] = new SqlParameter("@USERGROUPID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objGrpPermissionBll.USERGROUPID);
            sqlparam[3] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(objGrpPermissionBll.AUID);
            sqlparam[4] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[4].Value = NullHandler.DateTime(objGrpPermissionBll.ADT);
            sqlparam[5] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(objGrpPermissionBll.UUID);
            sqlparam[6] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[6].Value = NullHandler.DateTime(objGrpPermissionBll.UDT);
            sqlparam[7] = new SqlParameter("@securityNames", SqlDbType.Structured);
            sqlparam[7].Value = (objGrpPermissionBll.dtsecurity);
            sqlparam[8] = new SqlParameter("@branch", SqlDbType.Structured);
            sqlparam[8].Value = (objGrpPermissionBll.dtSubBranch);
            sqlparam[9] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[9].Direction = ParameterDirection.Output;
            sqlparam[10] = new SqlParameter("@applyToAllBranches", SqlDbType.Bit);
            sqlparam[10].Value = NullHandler.Boolean(objGrpPermissionBll.applyToAllBranches);
            sqlparam[11] = new SqlParameter("@removeunselSecurity", SqlDbType.Bit);
            sqlparam[11].Value = NullHandler.Boolean(objGrpPermissionBll.removeunselSecurity);
            objGrpPermissionBllCmnDal.InsertUpdateTable("insert_multiple_groupwise_security", "sp", sqlparam);
            if (sqlparam[9].Value != DBNull.Value)
                return sqlparam[9].Value.ToString();
            else
                return null;
        }

        public string InsertGrpPermission_New(ClsGrpPermissionBll objGrpPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@USERGROUPID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objGrpPermissionBll.USERGROUPID);
            sqlparam[1] = new SqlParameter("@AUID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(ClsConvertTo.Int32( ClsCommon.UserCode));
            sqlparam[2] = new SqlParameter("@securityNames", SqlDbType.Structured);
            sqlparam[2].Value = (objGrpPermissionBll.dtsecurity);
            sqlparam[3] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[3].Direction = ParameterDirection.Output;
            objGrpPermissionBllCmnDal.InsertUpdateTable("insert_groupwise_security", "sp", sqlparam);
            if (sqlparam[3].Value != DBNull.Value)
                return sqlparam[3].Value.ToString();
            else
                return null;
        }
        public DataTable getAllGrpPermission(ClsGrpPermissionBll objGrpPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@applyToAllBranches", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.Boolean(objGrpPermissionBll.applyToAllBranches);
            sqlparam[1] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objGrpPermissionBll.BRANCHCODE);
            sqlparam[2] = new SqlParameter("@SUBBRANCHCODE", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objGrpPermissionBll.SUBBRANCHCODE);
            sqlparam[3] = new SqlParameter("@USERGROUPID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objGrpPermissionBll.USERGROUPID);
            return objGrpPermissionBllCmnDal.GetTable("GetAllGroupPermission", "sp", sqlparam);
        }
        public DataTable getAllGrpPermission_New(ClsGrpPermissionBll objGrpPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@USERGROUPID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objGrpPermissionBll.USERGROUPID);
            return objGrpPermissionBllCmnDal.GetTable("Sec_Get_Groupwise_Permission", "sp", sqlparam);
        }

        public DataTable getAllSecurityBranches(ClsGrpPermissionBll objGrpPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@applyToAllBranches", SqlDbType.Bit);
            sqlparam[0].Value = NullHandler.Boolean(objGrpPermissionBll.applyToAllBranches);
            return objGrpPermissionBllCmnDal.GetTable("GetAllGroupPermission", "sp", sqlparam);
        }


        public string ResetGrpPermission(ClsGrpPermissionBll objGrpPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[8];
            sqlparam[0] = new SqlParameter("@UserGroupID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objGrpPermissionBll.USERGROUPID);
            sqlparam[1] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[1].Direction = ParameterDirection.Output;
            sqlparam[2] = new SqlParameter("@branchid",SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objGrpPermissionBll.branchid);
            sqlparam[3] = new SqlParameter("@subbranchid", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objGrpPermissionBll.SUBBRANCHID);
            sqlparam[4] = new SqlParameter("@auid",SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(objGrpPermissionBll.AUID);
            sqlparam[5] = new SqlParameter("@adt",SqlDbType.DateTime);
            sqlparam[5].Value = NullHandler.DateTime(objGrpPermissionBll.ADT);
            sqlparam[6] = new SqlParameter("@uuid",SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(objGrpPermissionBll.UUID);
            sqlparam[7] = new SqlParameter("@udt",SqlDbType.DateTime);
            sqlparam[7].Value = NullHandler.DateTime(objGrpPermissionBll.UDT);
            objGrpPermissionBllCmnDal.InsertUpdateTable("reset_multiple_groupwise_security", "sp", sqlparam);
            if (sqlparam[1].Value != DBNull.Value)
                return sqlparam[1].Value.ToString();
            else
                return null;
        }
    }
}