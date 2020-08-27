using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Stock.BllDalClasses.DalClass.User;

namespace Stock.BllDalClasses.BllClass.User
{
    public class clsLogReportBll
    {
        clsLogReportsDal objLogReport = new clsLogReportsDal();
        public string TableName { get; set; }

        public string logTableName { get; set; }//to create log table
        public string TotalColumn_forLogTable { get; set; }//to create log table

        //for triggering
        public string mode { get; set; }
        public string TotalColumn { get; set; }
        public string maintableName { get; set; }
        public string selectedColumn { get; set; }

     
        
        public DataTable GetTableName()
        {
            return objLogReport.GetTableName();
        }
        public DataTable GetColumnName()
        {
            return objLogReport.GetColumnName(this);
        }

        public DataTable GetColumnAndDataType()
        {
            return objLogReport.GetColumnAndDataType(this);
        }
        public bool CreateLogTable()
        {
            return objLogReport.CreateLogTable(this);
        }
        public bool CreateTrigger()
        {
            return objLogReport.CreateTrigger(this);
        }
    }

    public class clsLogReportSearchBLL
    {
        clsLogReportSearchDal objReportSearch = new clsLogReportSearchDal();
        //log report search button
        public string LogTableName { get; set; }
        public string ColumnList { get; set; }
        public int BranchID { get; set; }
        public string DocumentNO { get; set; }
        public string ClaimNo { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int VoucherID { get; set; }
        public int VoucherNo { get; set; }        
        public string ExtraField { get; set; }
        public string ExtraFieldValue { get; set; }

        public DataTable GetLogReport()
        {
            return objReportSearch.GetLogReport(this);
        }
    }
}