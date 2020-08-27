using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllDalClasses.DalClass.User;
using System.Data;

namespace Stock.BllDalClasses.BllClass.User
{
    public class ClsPolicyIssueLockBll
    {
        #region tbpolicyissueblock
        public int BRANCHID { get; set; }
        public int DEPTID { get; set; }
        public int CLASSID { get; set; }
        public int LOCKED { get; set; }
        public string AUID { get; set; }
        public DateTime ADT { get; set; }
        public string UUID { get; set; }
        public DateTime UDT { get; set; }

        public DataTable DTLockLst { get; set; }
        public string BranchName { get; set; }

        public int SUBBRANCHID { get; set; }
        public string SUBBRANCHCODE { get; set; }
        public string SUBBRANCHNAME { get; set; }
        public int islock { get; set; }

        #endregion tbpolicyissueblock

        ClsPolicyIssueLockDal objLockDal = new ClsPolicyIssueLockDal();

        public DataTable GetPolicyIssueLock()
        {
            return objLockDal.GetPolicyIssueLock(this);
        }
        public string InsertUpdatePolicyIssueLock()
        {
            return objLockDal.InsertUpdatePolicyIssueLock(this);
        }
        public DataTable LoadSubBranchList()
        {
            ClsPolicyIssueLockDal objBranchDal = new ClsPolicyIssueLockDal();
            DataTable dt = new DataTable();
            dt = objBranchDal.LoadSubBranchList(this);
            return dt;
            //return objBranchDal.LoadSubBranchList(this);

        }
    }
}