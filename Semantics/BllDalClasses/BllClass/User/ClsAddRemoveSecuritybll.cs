using Stock.BllDalClasses.DalClass.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.User
{
    public class ClsAddRemoveSecuritybll
    {
        #region tbl_AddRemove_DefaultSecurity
        public string BRANCHCODE { get; set; }
        public int SUBBRANCHCODE { get; set; }
        public int flag { get; set; }
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
        #endregion tbl_AddRemove_DefaultSecurity


        public string AddDefaultsecurity()
        {
            ClsAddRemoveSecurityDal objgrppermissiondal = new ClsAddRemoveSecurityDal();
            return objgrppermissiondal.AddDefaultsecurity(this);
        }

    }
}