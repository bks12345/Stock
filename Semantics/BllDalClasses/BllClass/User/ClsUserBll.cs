using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Stock.BllDalClasses.DalClass.User;


namespace Stock.BllDalClasses.BllClass.User
{
    public class ClsUserBll
    {
        #region tblUser
        public int ID { get; set; }
        public string USERID { get; set; }
        public string FO_CODE { get; set; }
        public int GROUPID { get; set; }
        public int ISADMIN { get; set; }
        public int ISSUPERUSER { get; set; }
        public string username { get; set; }
        public int empid { get; set; }
        public string PASSWORD { get; set; }
        public DateTime VALIDFROM { get; set; }
        public DateTime VALIDTO { get; set; }
        public string BRANCHCODE { get; set; }
        public int LOCKED { get; set; }
        public int  ISDELETED { get; set; }
        public string GROUP_CODE { get; set; }
        public string USER_CODE { get; set; }
        public string LASTSAVEDBY { get; set; }
        public DateTime LASTSAVEDDATE { get; set; }
        public string IPADDRESS { get; set; }
        public decimal ALLOT { get; set; }
        public Boolean LOGGED { get; set; }
        public decimal LOGGED_COMPUTER_NAME { get; set; }
        public string USERCODE { get; set; }
        public DateTime VALIDUPTO { get; set; }
        public string AUID { get; set; }
        public DateTime ADT { get; set; }
        public string UUID { get; set; }
        public DateTime UDT { get; set; }
        public int restore { get; set; }
        public int DesignationId { get; set; }
        public int SUBBRANCHID { get; set; }
        public int BRANCHID { get; set; }
        public string EMAIL { get; set; }
        public int EMPID { get; set; }
        public int ISACTIVATE { get; set; }
        public string ACTIVATIONCODE { get; set; }
       // public DataTable dtUncheckBranch { get; set; }
        public DataTable dtBranch { get; set; }
        public int FLAG { get; set; }
        public int ppwnotification { get; set; }
        public int deadline_alert { get; set; }
        public int isconnected_user { get; set; }

 //added by sunil
        public int applyNewSecurity { get; set; }
        public int IsCounterUser { get; set; }
        public int defaultloginpage { get; set; }


        public DateTime ExpiryDate { get; set; }
        public string Remarks { get; set; }
        #endregion tblUser
        public string IP_ADDR { get; set; }
        //public string SESSIONID { get; set; }

        ClsUserDal objUser = new ClsUserDal();

        public string Createuser(ClsUserBll objuserbll)
        {
            ClsUserDal objuserdal = new ClsUserDal();
            return objuserdal.Createuser(this);
        }

        public DataTable GetLogin(ClsUserBll objuserbll)
        {
            ClsUserDal objuserdal = new ClsUserDal();
           //ClsUserBll objuserbll = new ClsUserBll();
            DataTable dt = new DataTable();
            dt=objuserdal.GetLogin(this);
            return dt;
        }

        public DataTable GetUserList()
        {
            ClsUserDal objuserdal = new ClsUserDal();
            DataTable dt = new DataTable();
            dt = objuserdal.GetUserList(this);
            return dt;
        }

        public DataTable GetUser(int id)
        {
            ClsUserDal objuserdal = new ClsUserDal();
            DataTable dt = new DataTable();
            dt = objuserdal.GetUser(id);
            return dt;
        }

        public string updateUserPassword()
        {
            return objUser.updateUserPassword(this);
        }

        public DataTable GetUserName()
        {
            return objUser.GetUserName(this);
        }

        public string CreateSession()
        {
            return objUser.CreateSession();
        }

        public DataTable GetSession()
        {
            return objUser.GetSession();
        }
            
        //public DataTable CheckSession()
        //{
        //    return objUser.CheckSession();
        //}

        public bool TraceTable(string step)
        {
            return objUser.TraceTable(step);
        }

        public bool LockUser()
        {
            return objUser.LockUser(this);
        }

        public DataTable GetUserDetails(int id)
        {
            ClsUserDal objuserdal = new ClsUserDal();
            DataTable dt = new DataTable();
            dt = objuserdal.GetUserDetails(id);
            return dt;
        }
        public DataTable GetUserByEmpId(int id,int userId)
        {
            ClsUserDal objuserdal = new ClsUserDal();
            DataTable dt = new DataTable();
            dt = objuserdal.GetUserByEmpId(id, userId);
            return dt;
        }

        public bool UpdateUserIsActivate()
        {
            return objUser.UpdateUserIsActivate(this);
        }
        public bool UpdateUserActivationCode()
        {
            return objUser.UpdateUserActivationCode(this);
        }

        public DataTable getPassHistory()
        {
            return objUser.getPassHistory(this);
        }
        internal DataTable GetSBranch()
        {
           
            DataTable dt = new DataTable();
            dt = objUser.GetSBranch(this);
            return dt;
        }
        public DataSet GetChkBranchAccess(ClsUserBll objuserbll)
        {
            
            DataSet ds = new DataSet();
            ds = objUser.GetChkBranchAccess(this);
            return ds;

        }
        public string checkip()
        {
          return  objUser.chkip(this);
        }
        public DataTable GetUser_ForPWextend()
        {
            return objUser.GetUser_ForPWextend(this);
        }
        public string ExtendUserPassword()
        {
            return objUser.ExtendUserPassword(this);
        }
        public string UnlockUser()
        {
            return objUser.UnlockUser(this);
        }
        
    }
}