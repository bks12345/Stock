using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensure.BllDalClasses.DalClass.SearchEngine;
using System.Data;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class clsSearchBll
    {
        //GENERAL
        public string BRANCHCODE { get; set; }
        public int BRANCHID { get; set; }
        public string ACCEPTANCENO { get; set; }
        public int STATUS { get; set; }
        public string SUBBRANCHCODE { get; set; }
        public int SUBBRANCHID { get; set; }
        public string FISCALYEAR { get; set; }
        public int FISCALID { get; set; }
        public int CheckDate { get; set; }
        public DateTime FROM { get; set; }
        public DateTime TO { get; set; }
        //public DateTime COLLECTIONDTFROM { get; set; }
        //public DateTime COLLECTIONDTTO { get; set; }
        public string DEPTCODE { get; set; }
        public int DEPTID { get; set; }
        public int CLASSID { get; set; }
        public int ENTRY_USERID { get; set; }
        public string FLDOFFCODE { get; set; }
        public string AGENTCODE { get; set; }
        public string SUBAGENTCODE { get; set; }
        public string DOCTYPE { get; set; }
        public string ENDORSETYPE { get; set; }
        public string DOCUMENTNO { get; set; }
        public string FACBUSINESS { get; set; }
        public string POLICYNO { get; set; }
        public string VATINVNO { get; set; }
        public string CREDITNOTE { get; set; }
        public int DOCNO { get; set; }
        public string BUSINESSTYPE { get; set; }
        public int SORTBY { get; set; }
        public int REINSTATE { get; set; }
        //OTHER    
        public string BANKCODE { get; set; }
        public Int64 ACCOUNTNAMECODE { get; set; }
        public string ISSBRANCHCODE { get; set; }
        public decimal SUMINSUREDFROM { get; set; }
        public decimal SUMINSUREDTO { get; set; }
        public int RICOMPANYID { get; set; }
        public int COINSURANCEID { get; set; }
        public int CATEGORYID { get; set; } //vehicletype
        public int MAKEVEHICLEID { get; set; }
        public int MAKEMODELID { get; set; }
        public int VEHICLENAMEID { get; set; }
        public int YEARMANUFACTURE { get; set; }
        public string EVEHICLENO { get; set; }
        public string ENGINENO { get; set; }
        public string CHASISNO { get; set; }
        //public string SURVEYORNAME { get; set; }
        public int USERID { get; set; }
        public string TYPECOVER { get; set; }
        public int PG { get; set; }
        public int PGSIZE { get; set; }
        public int ISCHECKDATE { get; set; }
        public int DOCID { get; set; }
        public int FILEID { get; set; }

        public int CHILDID { get; set; }
        public int PARENTDOCID { get; set; }
        public int CHILDDOCID { get; set; }
        public int LSUID { get; set; }
        public int ISDELETE { get; set; }
        public int id { get; set; }
        public string REMARKS { get; set; }

        public int forwardedUID { get; set; }
        public DateTime forwardedDt { get; set; }
        public string FORWARDED_REMARKS { get; set; }

        public string InsuredName { get; set; }
        public int CLAIMID { get; set; }
        public int BankID { get; set; }
        public string Bankname { get; set; }
        public DateTime LSUDT { get; set; }
        public string ERUNNINHVEHNO { get; set; }

        public DataTable dtSecBranch { get; set; }
        public DataTable dtSecSubBranch { get; set; }
        public int ISCOUNTER { get; set; }
        public int Sec_userid { get; set; }
        public int PROVINCE { get; set; }
        public int DISTRICT { get; set; }


        public int ApprovedUID { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime Reqdate { get; set; }
        public int ReqUID { get; set; }
        public string ApprovedRemarks { get; set; }
        public int IsProformaApprove { get; set; }
        public int IsBackDateReq { get; set; }

        clsSearchDal objSearch = new clsSearchDal();

        public DataSet SearchPolicy()
        {
            return objSearch.SearchPolicy(this);
        }
        public DataSet NewSearchPolicy()
        {
            return objSearch.NewSearchPolicy(this);
        }
        public DataSet CustomSearchPolicy()
        {
            return objSearch.CustomSearchPolicy(this);
        }


        internal DataSet SearchDebitPolicy()
        {
            return objSearch.SearchDebitPolicy(this);
        }
        internal DataTable search_policy_attachment()
        {
            return objSearch.search_policy_attachment(this);
        }
        internal DataTable get_Childpolicy_Docid()
        {
            return objSearch.get_Childpolicy_Docid(this);
        }

        public string InsertUpdateDependentPolicy()
        {
            return objSearch.InsertUpdateDependentPolicy(this);
        }
        public string DeleteDependentPolicy()
        {
            return objSearch.DeleteDependentPolicy(this);
        }

        internal DataTable DepenetPolicyGet()
        {
            return objSearch.DepenetPolicyGet(this);
        }

        internal DataTable checkDuplicateParentId()
        {
            return objSearch.checkDuplicateParentId(this);
        }

        internal DataTable SearchDebitDetail()
        {
            return objSearch.SearchDebitDetail(this);
        }
        public string InsertInterBranch()
        {
            return objSearch.InsertInterBranch(this);
        }
        public DataTable GetAllInterBaranch()
        {
            return objSearch.GetAllInterBaranch(this);
        }
        public DataTable GetPolicyForwardAccount()
        {
            return objSearch.GetPolicyForwardAccount(this);
        }
        public string InsertForwardToAcc()
        {
            return objSearch.InsertForwardToAcc(this);
        }
        public string InsertClmCheqDispatch()
        {
            return objSearch.InsertClmCheqDispatch(this);
        }
        public DataTable GetclmChqDispatchDetails()
        {
            return objSearch.GetclmChqDispatchDetails(this);
        }
        public DataTable GetRiskCoverDetails()
        {
            return objSearch.GetRiskCoverDetails(this);
        }
        public DataTable GetOsLogHistory()
        {
            return objSearch.GetOsLogHistory(this);
        }
        public string InsertBranchidSearch()
        {
            return objSearch.InsertBranchidSearch(this);
        }
        public DataTable GetAssignmentRemarks()
        {
            return objSearch.GetAssignmentRemarks(this);
        }

        public DataTable GetBackDateApproval()
        {
            return objSearch.GetBackDateApproval(this);
        }

        public string InsertRequestForBackDateApproval()
        {
            return objSearch.InsertRequestForBackDateApproval(this);
        }
    }
}