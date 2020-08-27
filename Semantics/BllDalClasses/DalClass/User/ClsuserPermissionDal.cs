using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Stock.DalClass.Common;
using Stock.BllDalClasses.BllClass.User;

namespace Stock.BllDalClasses.DalClass.User
{
    public class ClsuserPermissionDal
    {

        clsCommonDal objUserPermissionBllCmnDal = new clsCommonDal();

        //Userwise Security settings
        public string InsertupdateUserwiseSecurity(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[14];
            sqlparam[0] = new SqlParameter("@UserId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.UserId);
            sqlparam[1] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objUserPermissionBll.BRANCHCODE);
            sqlparam[2] = new SqlParameter("@USER_CODE", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objUserPermissionBll.USER_CODE);
            sqlparam[3] = new SqlParameter("@securityNames", SqlDbType.Structured);
            sqlparam[3].Value = (objUserPermissionBll.dtsecurity);
            sqlparam[4] = new SqlParameter("@HASPERMISSION", SqlDbType.Decimal);
            sqlparam[4].Value = NullHandler.Decimal(objUserPermissionBll.HASPERMISSION);
            sqlparam[5] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(objUserPermissionBll.AUID);
            sqlparam[6] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[6].Value = NullHandler.DateTime(objUserPermissionBll.ADT);
            sqlparam[7] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[7].Value = NullHandler.String(objUserPermissionBll.UUID);
            sqlparam[8] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[8].Value = NullHandler.DateTime(objUserPermissionBll.UDT);
            sqlparam[9] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[9].Direction = ParameterDirection.Output;
            sqlparam[10] = new SqlParameter("@MODULEID", SqlDbType.Int);
            sqlparam[10].Value=NullHandler.Int32(objUserPermissionBll.MODULEID);
            sqlparam[11] = new SqlParameter("@BranchName", SqlDbType.VarChar);
            sqlparam[11].Value = NullHandler.String(objUserPermissionBll.BranchName);
            sqlparam[12] = new SqlParameter("@userGroup", SqlDbType.VarChar);
            sqlparam[12].Value = NullHandler.String(objUserPermissionBll.userGroup);
            sqlparam[13] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(objUserPermissionBll.SUBBRANCHID);
            objUserPermissionBllCmnDal.InsertUpdateTable("Security_Permission_Userwise_InsertUpdate ", "sp", sqlparam);
            if (sqlparam[9].Value != DBNull.Value)
                return sqlparam[9].Value.ToString();
            else
                return null;
        }

        //Multiple branchwise user
        public string InsertupdateMultiplePermission(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[18];
            sqlparam[0] = new SqlParameter("@useridtb", SqlDbType.Structured);
            sqlparam[0].Value = (objUserPermissionBll.dtUser);
            sqlparam[1] = new SqlParameter("@branch", SqlDbType.Structured);
            sqlparam[1].Value = (objUserPermissionBll.dtBranch);
            sqlparam[2] = new SqlParameter("@securityNames", SqlDbType.Structured);
            sqlparam[2].Value = (objUserPermissionBll.dtsecurity);
            sqlparam[3] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[3].Direction = ParameterDirection.Output;
            sqlparam[4] = new SqlParameter("@MODULEID", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(objUserPermissionBll.MODULEID);
            sqlparam[5] = new SqlParameter("@BranchName", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(objUserPermissionBll.BranchName);
            sqlparam[6] = new SqlParameter("@userGroup", SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(objUserPermissionBll.userGroup);
            sqlparam[7] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[7].Value = NullHandler.String(objUserPermissionBll.BRANCHCODE);
            sqlparam[8] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[8].Value = NullHandler.String(objUserPermissionBll.UUID);
            sqlparam[9] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[9].Value = NullHandler.String(objUserPermissionBll.AUID);
            sqlparam[10] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[10].Value = NullHandler.DateTime(objUserPermissionBll.ADT);
            sqlparam[11] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[11].Value = NullHandler.DateTime(objUserPermissionBll.UDT);
            //sqlparam[12] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            //sqlparam[12].Value = NullHandler.Int32(objUserPermissionBll.SUBBRANCHID);
            sqlparam[12] = new SqlParameter("@Subbranch", SqlDbType.Structured);
            sqlparam[12].Value = (objUserPermissionBll.dtSubBranch);

            sqlparam[13] = new SqlParameter("@unchecksecurityNames", SqlDbType.Structured);
            sqlparam[13].Value = (objUserPermissionBll.dtUnchecksecurity);
            sqlparam[14] = new SqlParameter("@uncheckuseridtb", SqlDbType.Structured);
            sqlparam[14].Value = (objUserPermissionBll.dtUncheckUser);
            sqlparam[15] = new SqlParameter("@uncheckbranch", SqlDbType.Structured);
            sqlparam[15].Value = (objUserPermissionBll.dtUncheckBranch);
            sqlparam[16] = new SqlParameter("@uncheckSubbranch", SqlDbType.Structured);
            sqlparam[16].Value = (objUserPermissionBll.dtUncheckSubBranch);
            sqlparam[17] = new SqlParameter("@FLAG", SqlDbType.Int);
            sqlparam[17].Value = NullHandler.Int32(objUserPermissionBll.FLAG);
            objUserPermissionBllCmnDal.InsertUpdateTable("Security_MultiplePermission_Userwise_InsertUpdate ", "sp", sqlparam);
            if (sqlparam[3].Value != DBNull.Value)
                return sqlparam[3].Value.ToString();
            else
                return null;
        }
        public string InsertupdateMultipleSecurity(ClsUserPermissionBll objUserPermissionBll)
        {
            //SqlParameter[] sqlparam = new SqlParameter[9];
            //sqlparam[0] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            //sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.BRANCHID);
            //sqlparam[1] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            //sqlparam[1].Value = NullHandler.Int32(objUserPermissionBll.SUBBRANCHID);
            //sqlparam[2] = new SqlParameter("@userGroup", SqlDbType.VarChar);
            //sqlparam[2].Value = NullHandler.String(objUserPermissionBll.userGroup);
            //sqlparam[3] = new SqlParameter("@MODULEID", SqlDbType.Int);
            //sqlparam[3].Value = NullHandler.Int32(objUserPermissionBll.MODULEID);
            //sqlparam[4] = new SqlParameter("@USERDT", SqlDbType.Structured);
            //sqlparam[4].Value = (objUserPermissionBll.dtUser);
            //sqlparam[5] = new SqlParameter("@SECURITYDT", SqlDbType.Structured);
            //sqlparam[5].Value = (objUserPermissionBll.dtsecurity);
            //sqlparam[6] = new SqlParameter("@AUID", SqlDbType.VarChar);
            //sqlparam[6].Value = NullHandler.String(objUserPermissionBll.AUID);
            //sqlparam[7] = new SqlParameter("@ADT", SqlDbType.DateTime);
            //sqlparam[7].Value = NullHandler.DateTime(objUserPermissionBll.ADT);
            //sqlparam[8] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            //sqlparam[8].Direction = ParameterDirection.Output;
            //objUserPermissionBllCmnDal.InsertUpdateTable("Security_MultipleSecurity_Userwise_InsertUpdate ", "sp", sqlparam);
            //if (sqlparam[8].Value != DBNull.Value)
            //    return sqlparam[8].Value.ToString();
            //else
                return null;
        }
        public string RemoveMultipleSecurity(ClsUserPermissionBll objUserPermissionBll)
        {
            //SqlParameter[] sqlparam = new SqlParameter[9];
            //sqlparam[0] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            //sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.BRANCHID);
            //sqlparam[1] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            //sqlparam[1].Value = NullHandler.Int32(objUserPermissionBll.SUBBRANCHID);
            //sqlparam[2] = new SqlParameter("@userGroup", SqlDbType.VarChar);
            //sqlparam[2].Value = NullHandler.String(objUserPermissionBll.userGroup);
            //sqlparam[3] = new SqlParameter("@MODULEID", SqlDbType.Int);
            //sqlparam[3].Value = NullHandler.Int32(objUserPermissionBll.MODULEID);
            //sqlparam[4] = new SqlParameter("@USERDT", SqlDbType.Structured);
            //sqlparam[4].Value = (objUserPermissionBll.dtUser);
            //sqlparam[5] = new SqlParameter("@RSECURITYDT", SqlDbType.Structured);
            //sqlparam[5].Value = (objUserPermissionBll.dtUnchecksecurity);
            //sqlparam[6] = new SqlParameter("@AUID", SqlDbType.VarChar);
            //sqlparam[6].Value = NullHandler.String(objUserPermissionBll.AUID);
            //sqlparam[7] = new SqlParameter("@ADT", SqlDbType.DateTime);
            //sqlparam[7].Value = NullHandler.DateTime(objUserPermissionBll.ADT);
            //sqlparam[8] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            //sqlparam[8].Direction = ParameterDirection.Output;
            //objUserPermissionBllCmnDal.InsertUpdateTable("Security_MultipleSecurity_Userwise_Remove ", "sp", sqlparam);
            //if (sqlparam[8].Value != DBNull.Value)
            //    return sqlparam[8].Value.ToString();
            //else
                return null;
        }
        public string InsertupdateMultipleAccessBranch(ClsUserPermissionBll objUserPermissionBll)
        {
            //SqlParameter[] sqlparam = new SqlParameter[11];
            //sqlparam[0] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            //sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.BRANCHID);
            //sqlparam[1] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            //sqlparam[1].Value = NullHandler.Int32(objUserPermissionBll.SUBBRANCHID);
            //sqlparam[2] = new SqlParameter("@userGroup", SqlDbType.VarChar);
            //sqlparam[2].Value = NullHandler.String(objUserPermissionBll.userGroup);
            //sqlparam[3] = new SqlParameter("@MODULEID", SqlDbType.Int);
            //sqlparam[3].Value = NullHandler.Int32(objUserPermissionBll.MODULEID);
            //sqlparam[4] = new SqlParameter("@USERDT", SqlDbType.Structured);
            //sqlparam[4].Value = (objUserPermissionBll.dtUser);
            //sqlparam[5] = new SqlParameter("@Subbranchdt", SqlDbType.Structured);
            //sqlparam[5].Value = (objUserPermissionBll.dtSubBranch);
            //sqlparam[6] = new SqlParameter("@AUID", SqlDbType.VarChar);
            //sqlparam[6].Value = NullHandler.String(objUserPermissionBll.AUID);
            //sqlparam[7] = new SqlParameter("@ADT", SqlDbType.DateTime);
            //sqlparam[7].Value = NullHandler.DateTime(objUserPermissionBll.ADT);
            //sqlparam[8] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            //sqlparam[8].Direction = ParameterDirection.Output;
            //sqlparam[9] = new SqlParameter("@branchdt", SqlDbType.Structured);
            //sqlparam[9].Value = (objUserPermissionBll.dtBranch);
            //sqlparam[10] = new SqlParameter("@SECURITYDT", SqlDbType.Structured);
            //sqlparam[10].Value = (objUserPermissionBll.dtsecurity);
            //objUserPermissionBllCmnDal.InsertUpdateTable("Security_MultipleAccessBranch_Userwise_InsertUpdate ", "sp", sqlparam);
            //if (sqlparam[8].Value != DBNull.Value)
            //    return sqlparam[8].Value.ToString();
            //else
                return null;
        }
        public string InsertupdateMultipleAccessBranch_new(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[11];
            sqlparam[0] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.BRANCHID);
            sqlparam[1] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objUserPermissionBll.SUBBRANCHID);
            sqlparam[2] = new SqlParameter("@userGroup", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objUserPermissionBll.userGroup);
            sqlparam[3] = new SqlParameter("@MODULEID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objUserPermissionBll.MODULEID);
            sqlparam[4] = new SqlParameter("@USERDT", SqlDbType.Structured);
            sqlparam[4].Value = (objUserPermissionBll.dtUser);
            sqlparam[5] = new SqlParameter("@Subbranchdt", SqlDbType.Structured);
            sqlparam[5].Value = (objUserPermissionBll.dtSubBranch);
            sqlparam[6] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(objUserPermissionBll.AUID);
            sqlparam[7] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[7].Value = NullHandler.DateTime(objUserPermissionBll.ADT);
            sqlparam[8] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[8].Direction = ParameterDirection.Output;
            sqlparam[9] = new SqlParameter("@branchdt", SqlDbType.Structured);
            sqlparam[9].Value = (objUserPermissionBll.dtBranch);
            sqlparam[10] = new SqlParameter("@SECURITYDT", SqlDbType.Structured);
            sqlparam[10].Value = (objUserPermissionBll.dtsecurity);
            objUserPermissionBllCmnDal.InsertUpdateTable("Security_MultipleAccessBranch_Userwise_InsertUpdate_New ", "sp", sqlparam);
            if (sqlparam[8].Value != DBNull.Value)
                return sqlparam[8].Value.ToString();
            else
                return null;
        }
        public DataSet LoadSecurityList(ClsUserPermissionBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@userid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.UserId);
            return objUserPermissionBllCmnDal.GetTableSet("Get_allsecuritylist_New", "sp", sqlparam);
        }
        public string RemoveMultipleAccessBranch(ClsUserPermissionBll objUserPermissionBll)
        {
            //SqlParameter[] sqlparam = new SqlParameter[11];
            //sqlparam[0] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            //sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.BRANCHID);
            //sqlparam[1] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            //sqlparam[1].Value = NullHandler.Int32(objUserPermissionBll.SUBBRANCHID);
            //sqlparam[2] = new SqlParameter("@userGroup", SqlDbType.VarChar);
            //sqlparam[2].Value = NullHandler.String(objUserPermissionBll.userGroup);
            //sqlparam[3] = new SqlParameter("@MODULEID", SqlDbType.Int);
            //sqlparam[3].Value = NullHandler.Int32(objUserPermissionBll.MODULEID);
            //sqlparam[4] = new SqlParameter("@USERDT", SqlDbType.Structured);
            //sqlparam[4].Value = (objUserPermissionBll.dtUser);
            ////sqlparam[5] = new SqlParameter("@RSECURITYDT", SqlDbType.Structured);
            ////sqlparam[5].Value = (objUserPermissionBll.dtUnchecksecurity);
            //sqlparam[5] = new SqlParameter("@RSubbranchdt", SqlDbType.Structured);
            //sqlparam[5].Value = (objUserPermissionBll.dtUncheckSubBranch);
            //sqlparam[6] = new SqlParameter("@AUID", SqlDbType.VarChar);
            //sqlparam[6].Value = NullHandler.String(objUserPermissionBll.AUID);
            //sqlparam[7] = new SqlParameter("@ADT", SqlDbType.DateTime);
            //sqlparam[7].Value = NullHandler.DateTime(objUserPermissionBll.ADT);
            //sqlparam[8] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            //sqlparam[8].Direction = ParameterDirection.Output;
            //sqlparam[9] = new SqlParameter("@Rbranchdt", SqlDbType.Structured);
            //sqlparam[9].Value = (objUserPermissionBll.dtUncheckBranch);
            //sqlparam[10] = new SqlParameter("@RSecurity", SqlDbType.Structured);
            //sqlparam[10].Value = (objUserPermissionBll.dtsecurity);
            //objUserPermissionBllCmnDal.InsertUpdateTable("Security_MultipleAccessBranch_Userwise_Remove ", "sp", sqlparam);
            //if (sqlparam[8].Value != DBNull.Value)
            //    return sqlparam[8].Value.ToString();
            //else
                return null;
        }

        // by sunila
        public DataTable FxGetSecurityUserWise(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@UserId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.UserId);
            sqlparam[1] = new SqlParameter("@BRANCHID", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.Int32(objUserPermissionBll.BRANCHID);
            sqlparam[2] = new SqlParameter("@PageId", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objUserPermissionBll.PageId);

            return objUserPermissionBllCmnDal.GetTable("Security_Permission_Userwise_GET", "sp", sqlparam);
        }

        // by sujeeb
        public DataTable FxGetSecurityPermission(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[6];
            sqlparam[0] = new SqlParameter("@UserId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.UserId);
            sqlparam[1] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objUserPermissionBll.BRANCHID);
            sqlparam[2] = new SqlParameter("@MODULEGNAME", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objUserPermissionBll.MODULEGNAME);
            sqlparam[3] = new SqlParameter("@MODEULENAME", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(objUserPermissionBll.MODEULENAME);
            sqlparam[4] = new SqlParameter("@SECURITYNAME", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(objUserPermissionBll.SECURITYNAME);
            sqlparam[5] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[5].Value = NullHandler.Int32(objUserPermissionBll.SUBBRANCHID);

            return objUserPermissionBllCmnDal.GetTable("Security_Permission_GET", "sp", sqlparam);
        }

        public DataSet FxGetSecurityBranchSubBranchUserWise(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@UserId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.UserId);


            return objUserPermissionBllCmnDal.GetTableSet("Security_MultiplePermission_Userwise_Branch_Subbranch_Get", "sp", sqlparam);
        }
        public DataTable FxGetAppMenusSecurityPermission(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@UserId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.UserId);
            sqlparam[1] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objUserPermissionBll.BRANCHID);

            sqlparam[2] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objUserPermissionBll.SUBBRANCHID);
            sqlparam[3] = new SqlParameter("@PAGEID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objUserPermissionBll.PageId);

            return objUserPermissionBllCmnDal.GetTable("AppMenus_Security_Permission_GET", "sp", sqlparam);
        }

        public DataTable FxGetSecurityList_New(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@UserId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.UserId);
            sqlparam[1] = new SqlParameter("@MODULEGNAME", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objUserPermissionBll.MODULEGNAME);
            sqlparam[2] = new SqlParameter("@MODEULENAME", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objUserPermissionBll.MODEULENAME);
            sqlparam[3] = new SqlParameter("@SECURITYNAME", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(objUserPermissionBll.SECURITYNAME);
            sqlparam[4] = new SqlParameter("@PRIMARY_SEC_NAME", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(objUserPermissionBll.PRIMARY_SECURITYNAME);
            return objUserPermissionBllCmnDal.GetTable("PROC_SEC_GETUSER_SECURITY", "sp", sqlparam);
        }

        public DataTable FxGetSecurityAccessBranch_New(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@UserId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.UserId);
            sqlparam[1] = new SqlParameter("@MODULEGNAME", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objUserPermissionBll.MODULEGNAME);
            sqlparam[2] = new SqlParameter("@MODEULENAME", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objUserPermissionBll.MODEULENAME);
            sqlparam[3] = new SqlParameter("@SECURITYNAME", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(objUserPermissionBll.SECURITYNAME);

            return objUserPermissionBllCmnDal.GetTable("PROC_SEC_LOAD_ACCESSBRANCH", "sp", sqlparam);
        }
        public DataTable FxGetSecurityAccessSubBranch_New(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@UserId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.UserId);
            sqlparam[1] = new SqlParameter("@MODULEGNAME", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objUserPermissionBll.MODULEGNAME);
            sqlparam[2] = new SqlParameter("@MODEULENAME", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objUserPermissionBll.MODEULENAME);
            sqlparam[3] = new SqlParameter("@SECURITYNAME", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(objUserPermissionBll.SECURITYNAME);
            sqlparam[4] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(objUserPermissionBll.BRANCHID);

            return objUserPermissionBllCmnDal.GetTable("PROC_SEC_LOAD_ACCESS_SUBBRANCH", "sp", sqlparam);
        }
        public DataTable FxGetSecurityAccessBranch_Security_New(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@UserId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.UserId);
            sqlparam[1] = new SqlParameter("@MODULEGNAME", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objUserPermissionBll.MODULEGNAME);
            sqlparam[2] = new SqlParameter("@MODEULENAME", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objUserPermissionBll.MODEULENAME);
            sqlparam[3] = new SqlParameter("@SECURITYNAME", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(objUserPermissionBll.SECURITYNAME);

            return objUserPermissionBllCmnDal.GetTable("PROC_SEC_ACCESSBRANCH_SECURITY", "sp", sqlparam);
        }
        public DataTable GetAllMultipleBranchWisePermission(ClsUserPermissionBll objUserPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@userid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.UserId);
            return objUserPermissionBllCmnDal.GetTable("GetAllMultipleBranchWisePermission", "sp", sqlparam);
        }
        //public DataTable AllMultipleBranchWisePermissionget(ClsUserPermissionBll objUserPermissionBll)
        //{
        //    SqlParameter[] sqlparam = new SqlParameter[1];
        //    sqlparam[0] = new SqlParameter("@userid", SqlDbType.Int);
        //    sqlparam[0].Value = NullHandler.Int32(objUserPermissionBll.UserId);
        //    return objUserPermissionBllCmnDal.GetTable("AllMultipleBranchWisePermissionget", "sp", sqlparam);
        //}
    }
}