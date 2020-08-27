using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Ensure.BllDalClasses.DalClass.SearchEngine;

namespace Ensure.Ensure.SearchEngine.ReportSearch
{
    public class ClsGeneralRptControlBll
    {
       
	 public  int ControlId { get; set; } 
	 public  int ReportId { get; set; }
     public string chkname { get; set; }
     public DataTable dtcontorls { get; set; }


     internal DataTable getcontrols()
     {
         ClsGeneralRptDal objdal = new ClsGeneralRptDal();
         return objdal.getcontrols(this);

     }

     internal string insertUpdateControls()
     {
         ClsGeneralRptDal objdal = new ClsGeneralRptDal();
         return objdal.insertUpdateControls(this);

     }
    }
}