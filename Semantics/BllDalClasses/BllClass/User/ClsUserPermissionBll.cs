using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Stock.BllDalClasses.DalClass.User;

namespace Stock.BllDalClasses.BllClass.User
{
    public class ClsUserPermissionBll
    {
        #region tbl_permission_Userwise
        public int UserId { get; set; }
        public string BRANCHCODE { get; set; }
        public int BRANCHID{ get; set; }
        public string USER_CODE { get; set; }
        public int SECURITYID { get; set; }
        public decimal HASPERMISSION { get; set; }
        public string AUID { get; set; }
        public DateTime ADT { get; set; }
        public string UUID { get; set; }
        public DateTime UDT { get; set; }
        public DataTable dtsecurity { get; set; }
        public int MODULEID { get; set; }
        public DataTable dtBranch { get; set; }
        public DataTable dtSubBranch { get; set; }
        public DataTable dtUser { get; set; }
        public int SUBBRANCHID { get; set; }
        public string BranchName { get; set; }
        public string userGroup { get; set; }

        public string MODULEGNAME { get; set; }
        public string MODEULENAME { get; set; }
        public string SECURITYNAME { get; set; }
        public string PRIMARY_SECURITYNAME { get; set; }
        public DataTable dtUncheckBranch { get; set; }
        public DataTable dtUncheckSubBranch { get; set; }
        public DataTable dtUncheckUser { get; set; }
        public DataTable dtUnchecksecurity { get; set; }
        public int FLAG { get; set; }
        #endregion tbl_permission_Userwise

        public int PageId { get; set; }
        
        ClsuserPermissionDal objuserpermision = new ClsuserPermissionDal();

        public string InsertupdateUserwiseSecurity(ClsUserPermissionBll objperuserBll)
        {
            return objuserpermision.InsertupdateUserwiseSecurity(this);

        }

        public string InsertupdateMultiplePermission()
        {
            return objuserpermision.InsertupdateMultiplePermission(this);

        }
        //public string InsertupdateMultipleSecurity()
        //{
        //    return objuserpermision.InsertupdateMultipleSecurity(this);

        //}
        public string RemoveMultipleSecurity()
        {
            return objuserpermision.RemoveMultipleSecurity(this);

        }
        public string InsertupdateMultipleAccessBranch()
        {
            return objuserpermision.InsertupdateMultipleAccessBranch(this);

        }
        public string InsertupdateMultipleAccessBranch_new()
        {
            return objuserpermision.InsertupdateMultipleAccessBranch_new(this);

        }
        public DataSet LoadSecurityList()
        {
            return objuserpermision.LoadSecurityList(this);
        }
        public string RemoveMultipleAccessBranch()
        {
            return objuserpermision.RemoveMultipleAccessBranch(this);

        }


        // by sunila
        public DataTable FxGetSecurityUserWise()
        {
            return objuserpermision.FxGetSecurityUserWise(this);
        }

        public DataTable FxGetSecurityPermission()
        {
            return objuserpermision.FxGetSecurityPermission(this);
        }

        public DataSet FxGetSecurityBranchSubBranchUserWise()
        {
            return objuserpermision.FxGetSecurityBranchSubBranchUserWise(this);
        }
        public DataTable FxGetAppMenusSecurityPermission()
        {
            return objuserpermision.FxGetAppMenusSecurityPermission(this);
        }

        public DataTable FxGetSecurityList_New()
        {
            return objuserpermision.FxGetSecurityList_New(this);
        }
        public DataTable FxGetSecurityAccessBranch_New()
        {
            return objuserpermision.FxGetSecurityAccessBranch_New(this);
        }
        public DataTable FxGetSecurityAccessSubBranch_New()
        {
            return objuserpermision.FxGetSecurityAccessSubBranch_New(this);
        }
        public DataTable FxGetSecurityAccessBranch_Security_New()
        {
            return objuserpermision.FxGetSecurityAccessBranch_Security_New(this);
        }
        public DataTable GetAllMultipleBranchWisePermission()
        {
            return objuserpermision.GetAllMultipleBranchWisePermission(this);
        }
        //public DataTable AllMultipleBranchWisePermissionget()
        //{
        //    return objuserpermision.AllMultipleBranchWisePermissionget(this);
        //}
    }
}