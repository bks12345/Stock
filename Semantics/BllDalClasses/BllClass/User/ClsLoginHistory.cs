using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllDalClasses.DalClass.User;
using System.Data;

namespace Stock.BllDalClasses.BllClass.User
{
    public class ClsLoginHistory
    {
        #region TBLLOGINHISTORY
        public int ISSUCCESS { get; set; } 
	 public  int BRANCHID { get; set; } 
	 public  int LOGINID { get; set; } 
	 public  int USERID { get; set; } 
	 public  string COMP_IP { get; set; } 
	 public  string COMP_NAME { get; set; } 
	 public  string COMP_USER { get; set; } 
	 public  string UserName { get; set; }
     public DateTime? LOGIN_DATE { get; set; }
     public string LOGIN_TIME { get; set; }
     public DateTime? LOGOUT_DATE { get; set; }
     public string LOGOUT_TIME { get; set; }
     public DateTime? datefrom  { get; set; }
     public DateTime? dateto { get; set; }
     public int PG { get; set; }
     public int PGSIZE { get; set; }
     public string mode { get; set; }//sanjay added
   
 #endregion TBLLOGINHISTORY

     ClsLoginHistoryDal objdal = new ClsLoginHistoryDal();

     public string insertupdateUserHistory()
     {
         //ClsLoginHistoryDal objdal = new ClsLoginHistoryDal();
         return objdal.insertupdateUserHistory(this);
     }

     internal System.Data.DataTable getdata()
     {
         //ClsLoginHistoryDal objdal = new ClsLoginHistoryDal();
         return objdal.getdata(this);
     }
        //sanjay changes
     public DataTable GetHistoryReport()
     {
         return objdal.GetHistoryReport(this);
     }
     public DataSet GetAllData()
     {
         return objdal.GetAllData(this);
     }

    }
}