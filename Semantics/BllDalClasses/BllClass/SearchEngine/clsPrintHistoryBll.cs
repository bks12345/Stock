using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Ensure.BllDalClasses.DalClass.Process;

namespace Ensure.BllDalClasses.BllClass.Process
{
    public class clsPrintHistoryBll
    {
        public int BRANCHID { get; set; }
        public int DOCID { get; set; }
        public int MID { get; set; }
        public int PID { get; set; }
        public DateTime PRINTDATE { get; set; }
        public int USERID { get; set; } 
        public string RECEIPTNO { get; set; }
        public string VATNO { get; set; }
        public int PRINTTYPE { get; set; }
        public int AUID { get; set; }
        public DateTime ADT { get; set; }


        public DateTime datefrom { get; set; }
        public DateTime dateto { get; set; }
        public string mode { get; set; }
        public string POLICYNO { get; set; }
        public int APP_ID { get; set; }
        public string DocNo { get; set; }
        public int claimId { get; set; }
        clsPrintHistoryDal objprintHistory = new clsPrintHistoryDal();
        public string InsertPrintHistory()
        {
            return objprintHistory.InsertPrintHistory(this);
        }
        public string InsertPrintHistoryClaimActivityLog()
        {
            return objprintHistory.InsertPrintHistoryClaimActivityLog(this);
        }

        public DataSet GetMaxCountForPrintingPolicy()
        {
            return objprintHistory.GetMaxCountForPrintingPolicy(this);
        }

        public DataTable GetPrintCount()
        {
            return objprintHistory.GetPrintCount(this);
        }

        public DataTable GetPrintApprover()
        {
            return objprintHistory.GetPrintApprover(this);
        }

        public DataTable GetPrintHistoryByAPP_ID()
        {
            return objprintHistory.GetPrintHistoryByAPP_ID(this);
        }

        public DataTable GetPrintHistory()
        {
            return objprintHistory.GetPrintHistory(this);
        }

        public DataTable GetDocListAndPrintCount()
        {
            return objprintHistory.GetDocListAndPrintCount(this);
        }
    }
}