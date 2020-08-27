using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensure.BllDalClasses.DalClass.SearchEngine;
using System.Data;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsRenewalNoticeBll
    {
        #region RENEWALTABLE
        public int ID { get; set; }
        public string AGENTCODE { get; set; }
        public string BRANCHCODE { get; set; }
        public Int32 BRANCHID { get; set; }
        public Int32 SUBBRANCHID { get; set; }
        public Int32 FISCALID { get; set; }
        public string CLASSCODE { get; set; }
        public string CLIENTCODE { get; set; }
        public string DEPTCODE { get; set; }
        public string DOCUMENTNO { get; set; }

        public decimal SUMINSURED_DRIVER { get; set; }
        public decimal SUMINSURED_HELPER { get; set; }
        public decimal SUMINSURED_PASSENGER { get; set; }
        public decimal DRIVERPREMIUM { get; set; }
        public decimal HELPERPREMIUM { get; set; }
        public decimal PASSANGERPREMIUM { get; set; }
        public decimal TPPREMIUM { get; set; }
        public decimal NETPREMIUM { get; set; }
        public decimal BASICPREMIUM { get; set; }
        public decimal POOLPREMIUM { get; set; }
        public decimal STAMPDUTY { get; set; }
        public decimal THIRDPARTYPREMIUM { get; set; }
        public decimal SUMINSURED { get; set; }
        public decimal TRAILOR_SI { get; set; }
        public DateTime DTNOTICESENT { get; set; }
        public DateTime DTRENEW { get; set; }
        public string EDESC { get; set; }
        public DateTime EXPITYDT { get; set; }
        public string FISCALYEAR { get; set; }
        public string FLDOFFCODE { get; set; }
        public int FONTTYPE { get; set; }
        public decimal GOVDISCAMT { get; set; }
        public decimal GOVDISCPER { get; set; }
        public decimal NOCLAIMAMT { get; set; }
        public decimal NOCLAIMPER { get; set; }
        public int NOCLAIMYR { get; set; }
        public decimal NOCLAIMPREMIUM { get; set; }
        public string NVEHICLENO { get; set; }
        public string POLICYNO { get; set; }
        public int PRINTED { get; set; }
        public int RENEWSTATUS { get; set; }
        public decimal VATAMT { get; set; }
        public decimal VATRATE { get; set; }
        public string VEHICLENO { get; set; }
        public int AUID { get; set; }
        public DateTime ADT { get; set; }
        public int UUID { get; set; }
        public DateTime UDT { get; set; }
        public int docid { get; set; }
        public int accountid { get; set; }
        public int clientid { get; set; }
        public int bankid { get; set; }
        public int agentid { get; set; }
        public int fldofficerid { get; set; }
        public int RenewedDocID { get; set; }
        public int DeptID { get; set; }
        public int ClassID { get; set; }
        public DataTable dtRsk { get; set; }
        public string PROPERTYDESC { get; set; }
        public int noofhelper { get; set; }
        public int noofcustomer { get; set; }
        public int noofdriver { get; set; }
        public decimal EOD { get; set; }
        public decimal CC_HP { get; set; }
        public decimal TONS { get; set; }
        public int SEATS { get; set; }
        public int CATEGORYID { get; set; }
        public string NEWINSUREDNEP { get; set; }
        public string NEWINSUREDENG { get; set; }
        public string NEWINSUREDAddNEP { get; set; }
        public string NEWINSUREDAddENG { get; set; }
        public string NEWEMAIL { get; set; }
        public string newMobileNo { get; set; }
        public string NEWBANKNAME { get; set; }
        public string NEWBANKADDRESS { get; set; }
        public string NEWBANKNAMENEP { get; set; }
        public string NEWBANKADDRESSNEP { get; set; }
        public string NEWFLDOFFICERCODE { get; set; }
        public string NEWAGENTCODE { get; set; }
        public int NEWFLDOFFICERID { get; set; }
        public int NEWAGENTID { get; set; }
        public int HASNEWBANK { get; set; }
        public int HASNEWINSURED { get; set; }
        public int HASNEWDO { get; set; }
        public int YEARMANUFACTURE { get; set; }

        #endregion RENEWALTABLE
        public int RISKID { get; set; }
        ClsRenewalNoticeDal clsRenewalNotice = new ClsRenewalNoticeDal();
        public string InsertUpdateRENEWALTABLE()
        {
            return clsRenewalNotice.InsertUpdateRENEWALTABLE(this);
        }

        public DataTable FxGetRenewalInformation()
        {
            return clsRenewalNotice.FxGetRenewalInformation(this);
        }

        public DataTable GetRiskCoverMapping()
        {
            DataTable dt = new DataTable();
            dt = clsRenewalNotice.GetRiskCoverMapping(this);
            return dt;
        }
        public int FxGetRenewalNcdYr()
        {
            return clsRenewalNotice.FxGetRenewalNcdYr(this);
        }
    }
}