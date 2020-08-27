using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Ensure.BllDalClasses.DalClass.SearchEngine;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsClaimSearch
    {
         public  int CLAIMID { get; set; } 
	 public  string CLAIMNO { get; set; } 
	 public  string POLICYNO { get; set; } 
	 public  int DOCID { get; set; }
     public int PG { get; set; }
     public int PGSIZE { get; set; }
	 public  string DOCUMENTNO { get; set; } 
	 public  string INWARDNO { get; set; } 
	 public  string BRANCHCODE { get; set; } 
	 public  string DEPTCODE { get; set; } 
	 public  string FISCALYEAR { get; set; } 
	 public  int CLAIMSNO { get; set; } 
	 public  string UNDFISCALYEAR { get; set; } 
	 public  string NMONTH { get; set; } 
	 public  string NYEAR { get; set; } 
	 public  DateTime DTCLAIMREG { get; set; } 
	 public  string CLASSCODE { get; set; } 
	 public  DateTime CLAIMINTDATE { get; set; } 
	 public  string CLAIMCAUSECD { get; set; } 
	 public  DateTime DATEOFOCCUR { get; set; } 
	 public  string OCCURRTIME { get; set; } 
	 public  string PLCOFOCCUR { get; set; } 
	 public  string NATUROFLOSS { get; set; } 
	 public  string GEOREGCODE { get; set; } 
	 public  string CESSIONNO { get; set; } 
	 public  string CLAIMANT { get; set; } 
	 public  string COMMENTS { get; set; } 
	 public  double ESTAMOUNT { get; set; } 
	 public  double ESTSURVFEE { get; set; } 
	 public  double SUMINSURED { get; set; } 
	 public  double SUMINSUREDGROSS { get; set; } 
	 public  int CLAIMTYPE { get; set; } 
	 public  double ACTOTHFEE { get; set; } 
	 public   DateTime APPROVEDDATE { get; set; } 
	 public  int APPROVEDBY { get; set; } 
	 public 	   string VOUCHERNO { get; set; } 
	 public  DateTime DISVOUISSDT { get; set; } 
	 public  string ISSUEDBY { get; set; } 
	 public  string ISSUEDTO { get; set; } 
	 public  DateTime CLSETDT { get; set; } 
	 public  string CLCHQNO { get; set; } 
	 public  DateTime CLCHQDT { get; set; } 
	 public  int PROCESSSTEP { get; set; } 
	 public  string AFFPROPERTY { get; set; } 
	 public  int CLAIMPAID { get; set; } 
	 	 public  string PAIDREMARK { get; set; } 
	 public  double IDCLAIMANT { get; set; } 
	 public  string CLAIMGROUP { get; set; } 
	 public  int SETTLEDDAYS { get; set; } 
	 public  double AMTTP { get; set; } 
	 public  double AMTOD { get; set; } 
	 public  int BENEFITID { get; set; } 
	 public  string RISKS { get; set; } 
	  public 	   string FORCEREGREMARKS { get; set; } 
	 	 public  string USERNAME { get; set; } 
	 public  string TRANSITMODE { get; set; } 
	 public  string GOODSTYPE { get; set; } 
	 public  int DECLARATIONID { get; set; } 
	 public  string DECLARATIONNO { get; set; } 
	 public  string DATEOFLOSSFISCALYEAR { get; set; } 
	 public  string CLAIMSETTLEDFISCALYEAR { get; set; } 
	 public  int BUSINESSTYPE { get; set; } 
	 public 	  string AUID { get; set; } 
	 public  DateTime ADT { get; set; } 
	 public  string UUID { get; set; } 
	 public  DateTime UDT { get; set; } 
	 public  string COINSURENAME { get; set; } 
	 public  double COINSUREAMT { get; set; } 
	 public  double COINSURE { get; set; } 
	 public  double ACTAMTTP { get; set; } 
	 public  double ACTCOINSUREAMT { get; set; } 
	 public  double ACTCOINSURESURFEE { get; set; } 
	 public  double ACTLOSS { get; set; } 
	 public  double ACTSURFEE { get; set; } 
	 public  double AMTAVERAGE { get; set; } 
	 public  double AMTMARKET { get; set; } 
	 public  double AMTVAT { get; set; } 
	 public  double APPROVEDAMT { get; set; } 
	 public  double AVGCLAUSE { get; set; } 
	 public  string CLAIMNOTECOPY { get; set; } 
	 public  DateTime CLAIMNOTEDATE { get; set; } 
	 public  double COMEXCESS { get; set; } 
	 public  DateTime DTRIAPPROVED { get; set; } 
	 public  string DVREMARKS { get; set; } 
	 public  string LOSSDTL { get; set; } 
	 public  double LSDISCOUNT { get; set; } 
	 public  double POLEXCESS { get; set; } 
	 public  string TMPCLAIMNO { get; set; } 
	 public  string TMPCLAIMNO_NEW { get; set; } 
	 public  double ACTXOL1 { get; set; } 
	 public  double ACTXOL2 { get; set; } 
	 public  DateTime APPDATE { get; set; } 
	 public  string APPUSRID { get; set; } 
	 public   int CERTIFICATENO { get; set; } 
	 public  double CLAIMSNOBKUP2AUG13 { get; set; } 
	 public  double CLAIMSNO_MEDICAL { get; set; } 
	 public  double CLAIMTYPE_BKUP { get; set; } 
	 public  string CLM_GRP { get; set; } 
	 public  string ENDORSEDTL { get; set; } 
	 public  string ENDORSEMENTNO { get; set; } 
	 public  double ESTXOL1 { get; set; } 
	 public  double ESTXOL2 { get; set; } 
	 public  DateTime FINDTAPPTMNT { get; set; } 
	 public  double FINESTLOSS { get; set; } 
	 public  double FINOTHFEE { get; set; } 
	 public  string FINPLAPPTMNT { get; set; } 
	 public  DateTime FINRPTDATE { get; set; } 
	 public  string FINSURCODE { get; set; } 
	 public  double FINSURFEE { get; set; } 
	 public  string FRESH_REN_NO { get; set; } 
	 public  string GEOREGIONCD { get; set; } 
	 public  double ISOLDMANUALCLAIMNO { get; set; } 
	 public  DateTime LETCOMPISSDT { get; set; } 
	 public  double MIDCLAIMNO { get; set; } 
	 public  double MKTPOOL { get; set; } 
	 public  double MKTPOOL_PC { get; set; } 
	 	 public  double PAIDREGSRNO { get; set; } 
	 public  string REFFISCALYEAR { get; set; } 
	 public  string RIFISCALYEAR { get; set; } 
	  	 public  int SETTLE_DAYS { get; set; } 
	 public  int SHORTCLAIMNO { get; set; } 
	 public  DateTime SPOTDTAPPTMNT { get; set; } 
	 public  double SPOTESTLOSS { get; set; } 
	 public  double SPOTOTHFEE { get; set; } 
	 public  string SPOTPLAPPTMNT { get; set; } 
	 public  DateTime SPOTRPTDT { get; set; } 
	 public  string SPOTSURCODE { get; set; } 
	 public  double SPOTSURFEE { get; set; } 
	 public  string VEHICLENOOWN { get; set; } 
	 public  string VEHICLENOTP { get; set; } 
	 public  double ACTSUROTHFEE { get; set; } 
	 public  double CONSULTANTFEE { get; set; } 
	 public  double CONSULTANTFEEMECH { get; set; } 
	 public  string DECEASEDPERSON { get; set; } 
	 public  string DRIVERS_EXPERIENCE { get; set; } 
	 public  string LEGALHEIR { get; set; } 
	 public  int MEDICAL_MEMBERID { get; set; } 
	 public  int NOOFCLAIM { get; set; } 
	 public  double REINSTATEPREMIUM { get; set; } 
	 public  double SUVFEEPAIDBYCLIENTOTHER { get; set; } 
	 public  double SUVFEEPAIDBYCLIENTPROF { get; set; } 
	 public  string INTFILENO { get; set; } 
	 public  int claimclauseid { get; set; }
     public DateTime datefromStart { get; set; }
     public DateTime datetoStart { get; set; }
     public DateTime datefrom2 { get; set; }
     public DateTime dateto2 { get; set; }
     public DateTime datefromsettle { get; set; }
     public DateTime datetosettle { get; set; }
     public string fldofficerid { get; set; }
     public decimal estamtFrom { get; set; }
     public decimal estamtTo { get; set; }
     public decimal actamtfrom { get; set; }
     public decimal actamtTo { get; set; }
     public int SurveyorId { get; set; }
     public int KNKType { get; set; }
     public int Facbusinessid { get; set; }
     public string vehicleno { get; set; }
     public int vehicle_type_id { get; set; }
     public string engineno { get; set; }
     public int makemodelid { get; set; }
     public int MakeVehicleId { get; set; }
     public int vehiclenameid { get; set; }
     public DateTime Manufacture { get; set; }
     public int paidornot { get; set; }
     public int deptid { get; set; }
     public int classid { get; set; }
     public int branchid { get; set; }
     public string claimpaidstatus { get; set; }
     public int yearmanufacture { get; set; }
     public int carrierRecovery { get; set; }
     public int agentid { get; set; }
     public int PROVINCECODE { get; set; }
        //sanjay changes
     public DateTime submissionDateFrom { get; set; }
     public DateTime submissionDateTo { get; set; }

     public DateTime FinalDocsubmissionDateFrom { get; set; }
     public DateTime FinalDocsubmissionDateTo { get; set; }

     public string SUBBRANCHCODE { get; set; } 
        //--
     public int SUBBRANCHID { get; set; }
     public int AssignTo { get; set; }
     public int ClaimEvent { get; set; }
     public int SortBy { get; set; }
     public int AccountID { get; set; }
     public string InsuredName { get; set; }
     public int RIAPPROVED { get; set; }

     public string agentcode { get; set; }
     public string fieldoffcode { get; set; }
     public DateTime statusdatefrom { get; set; }
     public DateTime statusdateto { get; set; }

     #region tmclaim_HOTransfer
	 public  int FORWARDED_ID { get; set; } 
	 public  int forwardedUID { get; set; } 
	 public  DateTime forwardedDt { get; set; } 
	 public int FStatus { get; set; }
     public string FORWARDED_REMARKS { get; set; } 

    #endregion tmclaim_HOTransfer
     public DataTable dtSecBranch { get; set; }
     public DataTable dtSecSubBranch { get; set; }
     public int Sec_userid { get; set; }
     public int LOSSTYPE { get; set; }
     public int SUBLOSSTYPE { get; set; }
     //public int CLAIMTYPE { get; set; }
     public int SUPPLYMENTRY { get; set; }
     public string MEDICALMEMBER { get; set; }
        internal DataSet Getclaimdata()
        {
            ClsClaimSearchDll objdal = new ClsClaimSearchDll();
            DataSet ds = new DataSet();
            ds = objdal.Getclaimdata(this);
            return ds;
        }
        public string InsertUpdatetmclaim_HOTransfer()
        {
            ClsClaimSearchDll objdal = new ClsClaimSearchDll();
            return objdal.InsertUpdatetmclaim_HOTransfer(this);
        }

    }
}