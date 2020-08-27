using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllDalClasses.DalClass.User;
using System.Data;

namespace Stock.BllDalClasses.BllClass.User
{
    public class ClsUserwisePolicyIssueLockBll
    {

        public int BRANCHID { get; set; }
        public int GROUPID { get; set; }
        public int ID { get; set; }      
        public string AUID { get; set; }
        public string UUID { get; set; }
        public DataTable DTUserwiseLock { get; set; }
        public string BranchName { get; set; }
        public string UserName { get; set; }

        ClsUserwisePolicyIssueLockDal objUserwiseLock = new ClsUserwisePolicyIssueLockDal();
        public DataTable GetUser()
        {
            return objUserwiseLock.GetUser(this);
        }

        public DataTable GetUserwiseIssueLock()
        {
            return objUserwiseLock.GetUserwiseIssueLock(this);
        }

        public string InsertUpdateUserwiseIssueLock()
        {
            return objUserwiseLock.InsertUpdateUserwiseIssueLock(this);
        }
    }
}