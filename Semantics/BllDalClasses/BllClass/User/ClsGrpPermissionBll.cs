using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Stock.BllDalClasses.DalClass.User;

namespace Stock.BllDalClasses.BllClass.User
{
    public class ClsGrpPermissionBll
    {
        #region tbl_permission_groupwise
        public string BRANCHCODE { get; set; }
        public int SUBBRANCHCODE { get; set; }
        public int USERGROUPID { get; set; }
        public int SECURITYID { get; set; }
        public string AUID { get; set; }
        public int HASPERMISSION { get; set; }
        public DateTime ADT { get; set; }
        public string UUID { get; set; }
        public DateTime UDT { get; set; }
        public DataTable dtsecurity { get; set; }
        public int SUBBRANCHID { get; set; }
        public int MODULEID { get; set; }
        public string BranchName { get; set; }
        public string userGroup { get; set; }
        public int branchid { get; set; }

        public bool applyToAllBranches { get; set; }
        public bool removeunselSecurity { get; set; }

        public DataTable dtSubBranch { get; set; }
        #endregion tbl_permission_groupwise


        public string InsertUpdateGrpPermission()
        {
            ClsGrpPermissionDal objgrppermissiondal = new ClsGrpPermissionDal();
            return objgrppermissiondal.InsertUpdateGrpPermission(this);

        }



        public string InsertGrpPermission()
        {
            ClsGrpPermissionDal objgrppermissiondal = new ClsGrpPermissionDal();
            return objgrppermissiondal.InsertGrpPermission(this);
        }
        public string InsertGrpPermission_New()
        {
            ClsGrpPermissionDal objgrppermissiondal = new ClsGrpPermissionDal();
            return objgrppermissiondal.InsertGrpPermission_New(this);
        }

        public DataTable getAllGrpPermission()
        {
            ClsGrpPermissionDal objgrppermissiondal = new ClsGrpPermissionDal();
            return objgrppermissiondal.getAllGrpPermission(this);
        }

        public DataTable getAllGrpPermission_New()
        {
            ClsGrpPermissionDal objgrppermissiondal = new ClsGrpPermissionDal();
            return objgrppermissiondal.getAllGrpPermission_New(this);
        }
        //when click show after checking apply to all branches 
        public DataTable getAllSecurityBranches()
        {
            ClsGrpPermissionDal objgrppermissiondal = new ClsGrpPermissionDal();
            return objgrppermissiondal.getAllSecurityBranches(this);
        }


        public string ResetGrpPermission()
        {
            ClsGrpPermissionDal objgrppermissiondal = new ClsGrpPermissionDal();
            return objgrppermissiondal.ResetGrpPermission(this);
        }
    }
}