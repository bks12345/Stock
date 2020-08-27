using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllDalClasses.DalClass.User;
using System.Data;

namespace Stock.BllDalClasses.BllClass.Common
{
    public class ClsModulehitcnt
    {
         #region TBLMODULEHITCOUNT
	 public  int BRANCHId { get; set; } 
	 public  int LOGINID { get; set; } 
     //public  string USERID { get; set; } 
     public int USERID { get; set; } //sanjay changes
	 public  string FORMNAME { get; set; } 
	 public  string MODULENAME { get; set; }
     public int MODULEID { get; set; }
     public  int LOADCNT { get; set; } 
	 public  int ADDCNT { get; set; } 
	 public  int EDITCNT { get; set; } 
	 public  int DELCNT { get; set; } 
	 public  int VIEWCNT { get; set; } 
	 public  string COMP_IP { get; set; } 
	 public  string COMP_NAME { get; set; } 
	 public  string COMP_USER { get; set; }
     public DateTime HIT_DATE { get; set; }
     public string HIT_TIME { get; set; }
     public string mode { get; set; }//sanjay added
     public DateTime datefrom { get; set; }//sanjay added
     public DateTime dateto { get; set; }//sanjay added
 #endregion TBLMODULEHITCOUNT
     ClsModulehitDal objmodulehit = new ClsModulehitDal();
     internal string insertupdateHItcount()
     {
         //ClsModulehitDal objmodulehit = new ClsModulehitDal();
         return objmodulehit.insertupdateHItcount(this);

     }

     public DataTable GetModuleHitReport()
     {
         return objmodulehit.GetModuleHitReport(this);
     }
    }
}