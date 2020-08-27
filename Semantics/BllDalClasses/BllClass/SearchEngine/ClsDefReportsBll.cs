using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensure.BllDalClasses.DalClass.SearchEngine;
using System.Data;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsDefReportsBll
    {
        #region DEFREPORTS
        public string FNAME { get; set; }
        public int ID { get; set; }
        public int reportptId { get; set; }
        public int ApproveStatus { get; set; }
        public bool ISCHILD { get; set; }
        public string filename { get; set; }
        public string stname { get; set; }
        public string datasetname {get;set;}
       
        public int ISVISIBLE { get; set; }
        public string NAME { get; set; }
        public int PID { get; set; }
        public int REPORTTYPE { get; set; }
        public string AUID { get; set; }
        public DateTime ADT { get; set; }
        public string UUID { get; set; }
        public DateTime UDT { get; set; }
        public int fiscalId { get; set; }
        public int RiskTypeId { get; set; }
        public int uwfiscalId { get; set; }
        public int branchId { get; set; }
        public int subbranchId { get; set; }
        public int branchBusiId { get; set; }
        public int deptId { get; set; }
        public int classId { get; set; }
        public string doccode { get; set; }
        public string businesscode { get; set; }
        public DateTime datefrom { get; set; }
        public DateTime dateto { get; set; }
        public string fieldoffcode { get; set; }
        public string agentcode { get; set; }
        public decimal netpremiumFrom { get; set; }
        public decimal netpremiumTO { get; set; }
        public decimal suminsuredFrom { get; set; }
        public decimal suminsuredTO { get; set; }
        public string clientcode { get; set; }
        public string insuredcode { get; set; }
        public Int64 ACCNTNAMECODE { get; set; }
        public int riskId { get; set; }
        public string bankcode { get; set; }
        public int makevehicleId { get; set; }
        public int makemodelId { get; set; }
        public int vahiclenameId { get; set; }
        public int vechiletypeId { get; set; }
        // Claim Report attributes
        public decimal actualamtfrom { get; set; }
        public decimal actualamtto { get; set; }
        public decimal estamtfrom { get; set; }
        public decimal estamtto { get; set; }
        public string surveyor { get; set; }
        public string QuarterFiscalYr { get; set; }
        public DateTime occdatefrom { get; set; }
        public DateTime occdateto { get; set; }
        public DateTime settledatefrom { get; set; }
        public DateTime settledateto { get; set; }
        public int claimtypeid { get; set; }
        public int uwfiscalid { get; set; }
        public int claimFiscalId { get; set; }
        public int ritype { get; set; }
        public int coReinsurance { get; set; }
        public int quarterid { get; set; }
        public int riboker { get; set; }
        public decimal rangefrom { get; set; }
        public decimal rangeto { get; set; }
        public int IsNoticeSent { get; set; }
        public int IsRenewed { get; set; }
        public int IsCommPaid { get; set; }
        //by pradip
        public string endorsetype { get; set; }
        public int type { get; set; }
        //sanjay added
        public int surveyorType { get; set; }
        public int surveyorID { get; set; }
        public int claimtypeid2 { get; set; }
        public int claimevent { get; set; }
        public DateTime withdrawDateFrom { get; set; }
        public DateTime withdrawDateTo { get; set; }
        public string claimNo { get; set; }
        public string userName { get; set; }
        public string quarterName { get; set; }
        //public DateTime DTDEADLINE_FROM{get;set;}
        //public DateTime DTDEADLINE_TO{get;set;}
        //public DateTime REP_SUBMIT_DT_FROM{get;set;}
        //public DateTime REP_SUBMIT_DT_TO{get;set;}
        //public int CLAIM_ASSIGNTO{get;set;}
        //public DateTime PAID_DT_FROM{get;set;}
        //public DateTime PAID_DT_TO{get;set;}
        public int status { get; set; }
        public int FacBusiness { get; set; }
        public int TEMPID { get; set; }
        //sunila
        public string documentno { get; set; }
        public string doctype { get; set; }

        public int accountid { get; set; }
        public int CLIENTBANKID { get; set; }
        public int clientid { get; set; }
        public string insured { get; set; }
        public string bankname { get; set; }
        public string clientname { get; set; }

        public int CLASSCATEGORY { get; set; }
        public int CLAIMTYPE { get; set; }
        public int LOSSTYPE { get; set; }
        public int SUBLOSSTYPE { get; set; }
        public int SUPPLYMENTRY { get; set; }
        public int KNKType { get; set; }
        public int Facbusinessid { get; set; }




        #endregion DEFREPORTS

        public int UserId { get; set; }
        //for claim reports
        public string ClaimNo { get; set; }
        public DateTime PAID_DT_FROM { get; set; }
        public DateTime PAID_DT_TO { get; set; }
        public DateTime WITHDRAW_DT_FROM { get; set; }
        public DateTime WITHDRAW_DT_TO { get; set; }
        public DateTime REP_SUBMIT_DT_FROM { get; set; }
        public DateTime REP_SUBMIT_DT_TO { get; set; }
        public DateTime DTDEADLINE_FROM { get; set; }
        public DateTime DTDEADLINE_TO { get; set; }
        public int CLAIM_ASSIGNTO { get; set; }
        public int FLAG { get; set; }

        public int BANKID { get; set; }
        public string reportKey { get; set; }
        public string condition { get; set; }
        public int CRITERIA_OPTION { get; set; }
        public int NEP_MONTH_INDEX { get; set; }
        public int DATEOPTIONS { get; set; }
        public int REPTYPE { get; set; }

        public string panno { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime placedatefrom { get; set; }
        public DateTime placedateto { get; set; }
        public string RepKey { get; set; }
        public int Skip_Security { get; set; }

        public DateTime SurveyDeputedDateFrom { get; set; }
        public DateTime SurveyDeputedDateTo { get; set; }
        public DateTime ReportDateFrom { get; set; }
        public DateTime ReportDateTo { get; set; }
        public int check { get; set; }
        public int RiskExposureID { get; set; }
        public int BandNameID { get; set; }
        public DateTime Month { get; set; }
        public string classIdList { get; set; }
        public int PROVINCEID { get; set; }
        #region KYCREPORTLOG
        public DateTime sentDate { get; set; }
        public int LSUID { get; set; }
        public DateTime LSDT { get; set; }
        public int isdeleted { get; set; }
        public DataTable SENTDETAILS { get; set; }
        public int LOGID { get; set; }

        public int GROUP_OPTIONS { get; set; }
        public int FONT_OPTIONS { get; set; }
        public int INC_STAMP { get; set; }
        public int SHOW_AS_PER_CURR_PREM { get; set; }

        public DataTable dtSecBranch { get; set; }
        public DataTable dtSecSubBranch { get; set; }

        #endregion
        public int ClassCategoryId { get; set; }
        internal System.Data.DataTable loadreports()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.loadreports(this);
        }

        internal System.Data.DataTable Loadreportlist()
        {
            ClsDefReportDal objdallist = new ClsDefReportDal();
            return objdallist.Loadreportlist(this);
        }
        internal System.Data.DataTable LoadreportlistSetup()
        {
            ClsDefReportDal objdallist = new ClsDefReportDal();
            return objdallist.LoadreportlistSetup(this);
        }

      

        internal System.Data.DataTable getprocname()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.getprocname(this);
        }



        internal System.Data.DataTable getreport(string procname)
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.getprocname(this,procname);
        }
        public System.Data.DataSet getprocname_dataset(string procname)
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.getprocname_dataset(this, procname);
        }
        public System.Data.DataSet getprocname_dataset_ByTempID(string procname)
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.getprocname_dataset_ByTempID(this, procname);
        }
        internal System.Data.DataTable getreport_Claim(string procname)
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.getreport_Claim(this, procname);
        }

        public DataTable GetReport_Ri(string procname)
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.GetReport_Ri(this, procname);
        }

        public DataSet GetReport_Ri_DataSet(string procname)
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.GetReport_Ri_DataSet(this, procname);
        }

        internal string InsertupdateReports()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.InsertupdateReports(this);
        }



        internal System.Data.DataTable getischild()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.getischild(this);
        }

        internal string InsertupdateChildReports()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.InsertupdateChildReports(this);
        }

        internal System.Data.DataTable getdata()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.getdata(this);
        }

        // by sunila
        public DataTable FxGetSecurityRptWise()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.FxGetSecurityRptWise(this);
        }

        public string FxGetOtherReports()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.FxGetOtherReports(this);
        }

        internal string InsertUpdateGeneralReport()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.InsertUpdateGeneralReport(this);
        }
        internal System.Data.DataTable FxGetTempGeneralReport()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.FxGetTempGeneralReport(this);
        }

        internal string InsertUpdateClaimReport()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.InsertUpdateClaimReport(this);
        }

        internal System.Data.DataTable FxGetTempClaimReport()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.FxGetTempClaimReport(this);
        }

        internal string InsertUpdateRiReport()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.InsertUpdateRiReport(this);
        }

        internal System.Data.DataTable FxGetTempRiReport()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.FxGetTempRiReport(this);
        }

        internal System.Data.DataSet FxGetKYCreport()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.FxGetKYCreport(this);
        }

        internal string InsertupdateKYCAnnexRpt()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.InsertupdateKYCAnnexRpt(this);
        }
        public DataSet GetKycSearchDetails()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            DataSet dt = new DataSet();
            dt = objdal.GetKycSearchDetails(this);
            return dt;
        }
        //by pradip
        //public DataTable Get_RiCompanyShare()
        //{
        //    ClsDefReportDal objdal = new ClsDefReportDal();
        //    return objdal.Get_RiCompanyShare(this);
        //}

        //public DataTable Get_RiCompanyShare_Coinsurance()
        //{
        //    ClsDefReportDal objdal = new ClsDefReportDal();
        //    return objdal.Get_RiCompanyShare_Coinsurance(this);
        //} 
        internal System.Data.DataTable FxGetClassCategoryList()
        {
            ClsDefReportDal objdal = new ClsDefReportDal();
            return objdal.FxGetClassCategoryList(this);
        }
    }
}