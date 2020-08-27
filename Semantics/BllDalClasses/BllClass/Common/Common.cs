using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Xml;
using System.Data.SqlClient;
using Stock.DalClass.Common;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.Net;
using Stock.BllDalClasses.BllClass.User;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using CBMSBillPosting;

namespace Stock.BllDalClasses.BllClass.Common
{

    public class ClsCommon
    {

        #region public properties

        public static int VEntryType
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("VEntryType") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("VEntryType").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("VEntryType"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("VEntryType", value);
            }
        }
        
        public static string NepaliFont
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("NepaliFont") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("NepaliFont").ToString());
                }
                else
                {
                    return CreateConnection("NepaliFont");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("NepaliFont", value);
            }
        }
        public static string FiscalYear
        {
            get
            {
                List<string> conname = new List<string>();
                List<string> con = new List<string>();
                conname.Add("iscurrentfy");
                con.Add("1");
                FiscalYear = CodeDecode("fiscalyear", "fiscalyear", conname, con, "");
                if (HttpContext.Current.Profile.GetPropertyValue("FiscalYear") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("FiscalYear").ToString());
                }
                else
                {
                    return "";
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("FiscalYear", value);
            }
        }
        public static string BranchCode
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("BranchCode") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("BranchCode").ToString());
                }
                else
                {
                    return CreateConnection("BranchCode");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("BranchCode", value);
            }
        }
        public static int BranchId
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("BRANCHID") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("BRANCHID").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("BranchId"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("BRANCHID", value);
            }
        }
        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("UserName") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("UserName").ToString());
                }
                else
                {
                    return CreateConnection("UserName");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("UserName", value);
            }
        }
        public static DateTime LastReqDateTime
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("LastReqDateTime") != null)
                {
                    return ClsConvertTo.DateTime(HttpContext.Current.Profile.GetPropertyValue("LastReqDateTime").ToString());
                }
                else
                {
                    return ClsConvertTo.DateTime("");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("LastReqDateTime", value);
            }
        }
        public static int IdleTimeOut
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("IdleTimeOut") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("IdleTimeOut").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("IdleTimeOut", value);
            }
        }
        public static string UserCode
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("UserCode") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("UserCode").ToString());
                }
                else
                {
                    return CreateConnection("UserCode");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("UserCode", value);
            }
        }
        public static string GroupCode
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("GroupCode") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("GroupCode").ToString());
                }
                else
                {
                    return CreateConnection("GroupCode");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("GroupCode", value);
            }
        }
        public static Boolean IsAdmin
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("IsAdmin") != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Profile.GetPropertyValue("IsAdmin"));
                }
                else
                {
                    return false;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("IsAdmin", value);
            }
        }
       
        public static int En_SumInsured  //ashish
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("En_SumInsured") != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Profile.GetPropertyValue("En_SumInsured"));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("En_SumInsured"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("En_SumInsured", value);
            }
        }
        public static int SystemType
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("SystemType") != null)
                {
                    return ClsConvertTo.Int32(HttpContext.Current.Profile.GetPropertyValue("SystemType").ToString());
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("SystemType", value);
            }
        }


        public static int CompanyId
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("CompanyId") != null)
                {
                    return ClsConvertTo.Int32(HttpContext.Current.Profile.GetPropertyValue("CompanyId").ToString());
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("CompanyId", value);
            }
        }
        public static string CompanyName
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("CompanyName") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("CompanyName").ToString());
                }
                else
                {
                    return CreateConnection("CompanyName");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("CompanyName", value);
            }
        }
        public static string CompanyName_Nep
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("CompanyName_Nep") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("CompanyName_Nep").ToString());
                }
                else
                {
                    return CreateConnection("CompanyName_Nep");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("CompanyName_Nep", value);
            }
        }


 

        public static string SubBranchCode
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("SubBranchCode") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("SubBranchCode").ToString());
                }
                else
                {
                    return CreateConnection("SubBranchCode");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("SubBranchCode", value);
            }
        }


      

        public static int SubBranchId
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("SUBBRANCHID") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("SUBBRANCHID").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("SUBBRANCHID"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("SUBBRANCHID", value);
            }
        }
    

        public static string BranchName
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("BranchName") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("BranchName").ToString());
                }
                else
                {
                    return CreateConnection("BranchName");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("BranchName", value);
            }
        }
        public static string SubBranchName
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("SubBranchName") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("SubBranchName").ToString());
                }
                else
                {
                    return CreateConnection("SubBranchName");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("SubBranchName", value);
            }
        }

        public static string getipaddress
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("getipaddress") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("getipaddress").ToString());
                }
                else
                {
                    return CreateConnection("getipaddress");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("getipaddress", value);
            }
        }

        public static int ConnectedUsers
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("isconnected_user") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("isconnected_user").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("isconnected_user"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("isconnected_user", value);
            }
        }
        public static string Rep_Path_Alias
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("Rep_Path_Alias") != null)
                {
                    return ClsConvertTo.String((HttpContext.Current.Profile.GetPropertyValue("Rep_Path_Alias").ToString()));
                }
                else
                {
                    return ClsConvertTo.String (CreateConnection("Rep_Path_Alias"));
                }
            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("Rep_Path_Alias", value);
            }
        }
        public static int kyc_validation
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("kyc_validation") != null)
                {
                    return ClsConvertTo.Int32(HttpContext.Current.Profile.GetPropertyValue("kyc_validation").ToString());
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("kyc_validation", value);
            }
        }
        public static int EnableMakerCheckerConpcept
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("EnableMakerCheckerConpcept") != null)
                {
                    return ClsConvertTo.Int32(HttpContext.Current.Profile.GetPropertyValue("EnableMakerCheckerConpcept").ToString());
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("EnableMakerCheckerConpcept", value);
            }
        }
        public static int TmiNilValidation
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("TmiNilValidation") != null)
                {
                    return ClsConvertTo.Int32(HttpContext.Current.Profile.GetPropertyValue("TmiNilValidation").ToString());
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("TmiNilValidation", value);
            }
        }
        public static int templatemapping
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("templatemapping") != null)
                {
                    return ClsConvertTo.Int32(HttpContext.Current.Profile.GetPropertyValue("templatemapping").ToString());
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("templatemapping", value);
            }
        }
        public static int SYNC_IRD_IN_REALTIME
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("SYNC_IRD_IN_REALTIME") != null)
                {
                    return ClsConvertTo.Int32(HttpContext.Current.Profile.GetPropertyValue("SYNC_IRD_IN_REALTIME").ToString());
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("SYNC_IRD_IN_REALTIME", value);
            }
        }
        //public static string SessionId
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Profile.GetPropertyValue("SessionId") != null)
        //        {
        //            return (HttpContext.Current.Profile.GetPropertyValue("SessionId").ToString());
        //        }
        //        else
        //        {
        //            return CreateConnection("SessionId");
        //        }

        //    }

        //    set
        //    {
        //        HttpContext.Current.Profile.SetPropertyValue("SessionId", value);
        //    }
        //}

        //public static string WizTask
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Profile.GetPropertyValue("WizTask") != null)
        //        {
        //            return (HttpContext.Current.Profile.GetPropertyValue("WizTask").ToString());
        //        }
        //        else
        //        {
        //            return CreateConnection("WizTask");
        //        }

        //    }

        //    set
        //    {
        //        HttpContext.Current.Profile.SetPropertyValue("WizTask", value);
        //    }
        //}
        //public static int DOCID
        //{

        //    get
        //    {
        //        if (HttpContext.Current.Profile.GetPropertyValue("DOCID") != null)
        //        {
        //            return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("DOCID").ToString()));
        //        }
        //        else
        //        {
        //            return ClsConvertTo.Int32(CreateConnection("DOCID"));
        //        }

        //    }

        //    set
        //    {
        //        HttpContext.Current.Profile.SetPropertyValue("DOCID", value);
        //    }
        //}
        //public static int TEMPID
        //{

        //    get
        //    {
        //        if (HttpContext.Current.Profile.GetPropertyValue("TEMPID") != null)
        //        {
        //            return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("TEMPID").ToString()));
        //        }
        //        else
        //        {
        //            return ClsConvertTo.Int32(CreateConnection("TEMPID"));
        //        }

        //    }

        //    set
        //    {
        //        HttpContext.Current.Profile.SetPropertyValue("TEMPID", value);
        //    }
        //}
        public static int LoginTry
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("LoginTry") != null)
                {
                    return ClsConvertTo.Int32(HttpContext.Current.Profile.GetPropertyValue("LoginTry").ToString());
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("LoginTry", value);
            }
        }
        public static string RandomKey
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("RandomKey") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("RandomKey").ToString());
                }
                else
                {
                    return CreateConnection("RandomKey");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("RandomKey", value);
            }
        }

        public static int IsDynamicMenu
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("IsDynamicMenu") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("IsDynamicMenu").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("IsDynamicMenu"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("IsDynamicMenu", value);
            }
        }

        public static int validSurveyor
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("validSurveyor") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("validSurveyor").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("validSurveyor"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("validSurveyor", value);
            }
        }

        public static int DEFAULTCHEQUEBANK
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("DEFAULTCHEQUEBANK") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("DEFAULTCHEQUEBANK").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("DEFAULTCHEQUEBANK"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("DEFAULTCHEQUEBANK", value);
            }
        }
        public static int DEFAULTCHEQUENO
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("DEFAULTCHEQUENO") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("DEFAULTCHEQUENO").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("DEFAULTCHEQUENO"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("DEFAULTCHEQUENO", value);
            }
        }
        public static int SUMINSUREDINNIL
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("SUMINSUREDINNIL") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("SUMINSUREDINNIL").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("SUMINSUREDINNIL"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("SUMINSUREDINNIL", value);
            }
        }

        public static int EXPIRYDAY
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("EXPIRYDAY") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("EXPIRYDAY").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("EXPIRYDAY"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("EXPIRYDAY", value);
            }
        }

        public static int SalaryBasis
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("SalaryBasis") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("SalaryBasis").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("SalaryBasis"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("SalaryBasis", value);
            }
        }

        public static int isAddPhoto
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("isAddPhoto") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("isAddPhoto").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("isAddPhoto"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("isAddPhoto", value);
            }
        }
        public static int SendActivationCode 
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("SendActivationCode") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("SendActivationCode").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("SendActivationCode"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("SendActivationCode", value);
            }
        }
        public static int FilterAccountNameCOde
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("FilterAccountNameCOde") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("FilterAccountNameCOde").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("FilterAccountNameCOde"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("FilterAccountNameCOde", value);
            }
        }
        public static int IsMannualCreditNoteNo
        {

            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("IsMannualCreditNoteNo") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("IsMannualCreditNoteNo").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("IsMannualCreditNoteNo"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("IsMannualCreditNoteNo", value);
            }
        }
        public static int EnableCommAdj
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("EnableCommAdj") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("EnableCommAdj").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("EnableCommAdj"));
                }
            }
            set
            {
                HttpContext.Current.Profile.SetPropertyValue("EnableCommAdj", value);
            }
        }
        public static decimal ExcessLimitCollection
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("ExcessLimitCollection") != null)
                {
                    return ClsConvertTo.Decimal((HttpContext.Current.Profile.GetPropertyValue("ExcessLimitCollection").ToString()));
                }
                else
                {
                    return ClsConvertTo.Decimal(CreateConnection("ExcessLimitCollection"));
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("ExcessLimitCollection", value);
            }
        }
        public static int EnableDepositCollection
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("EnableDepositCollection") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("EnableDepositCollection").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("EnableDepositCollection"));
                }
            }
            set
            {
                HttpContext.Current.Profile.SetPropertyValue("EnableDepositCollection", value);
            }
        }
        public static int HasClientPortal
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("HasClientPortal") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("HasClientPortal").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("HasClientPortal"));
                }
            }
            set
            {
                HttpContext.Current.Profile.SetPropertyValue("HasClientPortal", value);
            }
        }
        public static int LoadAsPerGL
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("LoadAsPerGL") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("LoadAsPerGL").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("LoadAsPerGL"));
                }
            }
            set
            {
                HttpContext.Current.Profile.SetPropertyValue("LoadAsPerGL", value);
            }
        }
        public static int SeperateClaimCattle
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("SeperateClaimCattle") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("SeperateClaimCattle").ToString()));
                }
                else
                {
                    return ClsConvertTo.Int32(CreateConnection("SeperateClaimCattle"));
                }
            }
            set
            {
                HttpContext.Current.Profile.SetPropertyValue("SeperateClaimCattle", value);
            }
        }
        public static int comm_pay_mode
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("comm_pay_mode") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("comm_pay_mode").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("comm_pay_mode", value);
            }
        }
        public static int cr_node_paymode
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("cr_node_paymode") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("cr_node_paymode").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("cr_node_paymode", value);
            }
        }
        public static string IRD_USERNAME
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("IRD_USERNAME") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("IRD_USERNAME").ToString());
                }
                else
                {
                    return CreateConnection("IRD_USERNAME");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("IRD_USERNAME", value);
            }
        }
        public static string IRD_PASSWORD
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("IRD_PASSWORD") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("IRD_PASSWORD").ToString());
                }
                else
                {
                    return CreateConnection("IRD_PASSWORD");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("IRD_PASSWORD", value);
            }
        }
        public static string VatReg
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("VatReg") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("VatReg").ToString());
                }
                else
                {
                    return CreateConnection("VatReg");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("VatReg", value);
            }
        }
        public static int IsDemo
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("IsDemo") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("IsDemo").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("IsDemo", value);
            }
        }
        public static int applyNewSecurity
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("applyNewSecurity") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("applyNewSecurity").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("applyNewSecurity", value);
            }
        }

        public static int ReceiptVatPrintflag
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("ReceiptVatPrintflag") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("ReceiptVatPrintflag").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("ReceiptVatPrintflag", value);
            }
        }
        public static int IsCounterUser
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("IsCounterUser") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("IsCounterUser").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("IsCounterUser", value);
            }
        }
        public static int DefaultLogInPage
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("DefaultLogInPage") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("DefaultLogInPage").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("DefaultLogInPage", value);
            }
        }

        public static int BACK_DATE_WITHDRAW
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("BACK_DATE_WITHDRAW") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("BACK_DATE_WITHDRAW").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("BACK_DATE_WITHDRAW", value);
            }
        }

        public static int ALLOW_SUR_FUTURE_DEPUTE
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("ALLOW_SUR_FUTURE_DEPUTE") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("ALLOW_SUR_FUTURE_DEPUTE").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("ALLOW_SUR_FUTURE_DEPUTE", value);
            }
        }

        public static int ALLOW_SUR_BACKDATE_DEPUTE
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("ALLOW_SUR_BACKDATE_DEPUTE") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("ALLOW_SUR_BACKDATE_DEPUTE").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("ALLOW_SUR_BACKDATE_DEPUTE", value);
            }
        }
        //public static int EnableDepositWithdraw
        //{
        //    get
        //    {
        //        if (HttpContext.Current.Profile.GetPropertyValue("EnableDepositWithdraw") != null)
        //        {
        //            return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("EnableDepositWithdraw").ToString()));
        //        }
        //        else
        //        {
        //            return ClsConvertTo.Int32(CreateConnection("EnableDepositWithdraw"));
        //        }
        //    }
        //    set
        //    {
        //        HttpContext.Current.Profile.SetPropertyValue("EnableDepositWithdraw", value);
        //    }
        //}

        public static string DebitCaption
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("DebitCaption") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("DebitCaption").ToString());
                }
                else
                {
                    return CreateConnection("DebitCaption");
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("DebitCaption", value);
            }
        }

        public static int PrinterType
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("PrinterType") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("PrinterType").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("PrinterType", value);
            }
        }

        public static int UseClmRecom
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("UseClmRecom") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("UseClmRecom").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("UseClmRecom", value);
            }
        }
        public static int UseRefundRecom
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("UseRefundRecom") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("UseRefundRecom").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("UseRefundRecom", value);
            }
        }

        public static int EnableCollectionImport
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("EnableCollectionImport") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("EnableCollectionImport").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("EnableCollectionImport", value);
            }
        }

        public static int GenAllProforma
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("GenAllProforma") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("GenAllProforma").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("GenAllProforma", value);
            }
        }
        public static int HasTwoVatInvoice
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("HasTwoVatInvoice") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("HasTwoVatInvoice").ToString()));
                }
                else
                {
                    return 0;
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("HasTwoVatInvoice", value);
            }
        }
        public static int RVGenType
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("RVGenType") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("RVGenType").ToString()));
                }
                else
                {
                    return 0;
                }

            }
            
            set
            {
                HttpContext.Current.Profile.SetPropertyValue("RVGenType", value);
            }
        }
        public static int GPA_Breakdown_Type
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("GPA_Breakdown_Type") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("GPA_Breakdown_Type").ToString()));
                }
                else
                {
                    return 0;
                }

            }
            set
            {
                HttpContext.Current.Profile.SetPropertyValue("GPA_Breakdown_Type", value);
            }
        }
        public static int APPCLAIM_BEF_ENDORSE
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("APPCLAIM_BEF_ENDORSE") != null)
                {
                    return ClsConvertTo.Int32((HttpContext.Current.Profile.GetPropertyValue("APPCLAIM_BEF_ENDORSE").ToString()));
                }
                else
                {
                    return 0;
                }

            }
            set
            {
                HttpContext.Current.Profile.SetPropertyValue("APPCLAIM_BEF_ENDORSE", value);
            }
        }
        public static string AttachmentPath
        {
            get
            {
                if (HttpContext.Current.Profile.GetPropertyValue("AttachmentPath") != null)
                {
                    return (HttpContext.Current.Profile.GetPropertyValue("AttachmentPath").ToString());
                }
                else
                {
                    return "";
                }

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("AttachmentPath", value);
            }
        }
        #region serverDate
        public static string ServerDate
        {
            get
            {
                return SetDate();
                //if (HttpContext.Current.Profile.GetPropertyValue("ServerDate") != null)
                //{
                    //return (HttpContext.Current.Profile.GetPropertyValue("ServerDate").ToString());
                //}
                //else
                //{
                //    return "";
                //}

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("ServerDate", value);
            }
        }
        public static string SetDate()
        {
            clsCommonDal objCmn = new clsCommonDal();

            return objCmn.GetDate();

        }
        #endregion serverDate
        #region severDateTime
        public static string ServerDateTime
        {
            get
            {
                return SetDateTime();
                //if (HttpContext.Current.Profile.GetPropertyValue("ServerDateTime") != null)
                //{
                //    return (HttpContext.Current.Profile.GetPropertyValue("ServerDateTime").ToString());
                //}
                //else
                //{
                //    return "";
                //}

            }

            set
            {
                HttpContext.Current.Profile.SetPropertyValue("ServerDateTime", value);
            }
        }
        public static string SetDateTime()
        {
            clsCommonDal objCmn = new clsCommonDal();

            return objCmn.GetDateTime();

        }
        #endregion severDateTime
        #endregion public properties

        public static string CreateConnection(string returnType)
        {
           
            return "";
            //ScriptManager.RegisterStartupScript(HttpContext.Current, HttpContext.Current.GetType(), "", "alert('Could not connect to the server. Please try again!');window.location.replace('Login.aspx');", true);
        }

        #region for export
        public static void FxExport(DataTable dt, string path, string prmReportTitle = "", string param1A = "", string param1B = "", string param2A = "", string param2B = "")
        {
            //string path = Server.MapPath(ConfigurationManager.AppSettings["FolderPath"] + "/new.xls");
            FileInfo FI = new FileInfo(path);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);
            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = dt;
            DataGrd.DataBind();

            DataGrd.RenderControl(htmlWrite);
            string directory = path.Substring(0, path.LastIndexOf("\\"));// GetDirectory(Path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            System.IO.StreamWriter vw = new System.IO.StreamWriter(path, true);
            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());

            HttpResponse Response = System.Web.HttpContext.Current.Response;
            //Response.Write("Pretty Excel Export File\n\n");
            //Response.Write("Generated on " + DateTime.Now.ToShortDateString() + "\n\n");

            string headerTable = @"<table width='100%'>
                                    <tr><td><h4>Report </h4> </td>
                                        <td>Hello sundar</td>
                                        <td><h1>" + DateTime.Now.ToString("d") + "</h1></td></tr><tr><td>hi sundar</td></tr></table>";
            StringBuilder aaa = new StringBuilder();
                aaa.AppendFormat(@"<table border='0' cellpadding='0' cellspacing='0'>
                           <tr>
                               <!--<td rowspan='3' colspan='2'><img src='https://www.c-sharpcorner.com/App_themes/csharp/images/sitelogo.png'></td>-->
                               <td colspan='7'><h3>{0}</h3></td>
                           </tr>
                           <!--<tr>
                               <td colspan='7'>
       	                        <span><b>Address:</b>ktm</span> 
                               </td>
                           </tr>
                                <tr>
                               <td colspan='7'>  
       	                        <span><b>Phone No:</b>phn</span>
                               </td>
                           </tr>-->
                           <tr>
                               <td colspan='9'><h3>{1}</h3></td>
                           </tr>
                           <tr> <td colspan='3'>{2}</td>
                                <td colspan='5'>{3}</td> 
                           </tr>
                           <tr> <td colspan='3'>{4}</td>
                                <td colspan='5'>{5}</td> 
                           </tr>
                           </table>", ClsCommon.CompanyName, prmReportTitle, param1A, param1B,param2A, param2B);
                HttpContext.Current.Response.Write(aaa);

            vw.Flush();
            vw.Close();
            WriteAttachment(FI.Name, "application/octet-stream", stringWriter.ToString());
        }
        /*by pradip*/
        public static void FxExportForTrialBalance(DataTable dt, string path)
        {
            //string path = Server.MapPath(ConfigurationManager.AppSettings["FolderPath"] + "/new.xls");
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            FileInfo FI = new FileInfo(path);
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);

            DataGrid DataGrd = new DataGrid();
            DataGrd.DataSource = dt;
            DataGrd.DataBind();

            DataGrd.RenderControl(htmlWrite);
            string directory = path.Substring(0, path.LastIndexOf("\\"));// GetDirectory(Path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            System.IO.StreamWriter vw = new System.IO.StreamWriter(path, true);
            string headerTable = @"<Table><tr><td>Trial Balance</td></tr></Table>";
            Response.Write(headerTable);
            stringWriter.ToString().Normalize();
            vw.Write(stringWriter.ToString());
            vw.Flush();
            vw.Close();
            WriteAttachment(FI.Name, "application/octet-stream", stringWriter.ToString());
        }

        public static void WriteAttachment(string FileName, string FileType, string content)
        {
            HttpResponse Response = System.Web.HttpContext.Current.Response;
            Response.ClearHeaders();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
            Response.ContentType = FileType;
            Response.Write(content);
            Response.End();
        }
        #endregion for export

        public static string CodeDecode(string tblName, string fSelect, List<string> conName, List<string> con, string fbranchcode)
        {
            //clsCommonDal objCmn = new clsCommonDal();
            //string sp = "Select " + fSelect + " from " + tblName;
            //if (conName.Count > 0)
            //    if (conName[0] != "")
            //        sp = sp + " where ";
            //for (int i = 0; i < conName.Count; i++)
            //{
            //    if (conName[i] != "")
            //        sp = sp + conName[i] + " = '" + con[i] + "'";
            //    if (conName.Count > 1 && i != conName.Count - 1)
            //        sp = sp + " and ";
            //}
            //if (fbranchcode != "")
            //    sp = sp + " and BranchCode = '" + fbranchcode + "'";
            //DataTable dt = objCmn.GetTable(sp, "text", null);
            //if (dt.Rows.Count > 0)
            //    return dt.Rows[0][fSelect].ToString();
            //else
            //    return "";
            clsCommonDal objCmn = new clsCommonDal();
            string sp = "set nocount on;Select " + fSelect + " from " + tblName;
            if (conName.Count > 0)
                if (conName[0] != "")
                    sp = sp + " where ";
            for (int i = 0; i < conName.Count; i++)
            {
                if (conName[i] != "")
                    sp = sp + conName[i] + " = " + FxQuoteStr(con[i] );
                if (conName.Count > 1 && i != conName.Count - 1)
                    sp = sp + " and ";
            }
            if (fbranchcode != "")
                sp = sp + " and BranchCode = '" + fbranchcode + "'";
            DataTable dt = objCmn.GetTable(sp + ";set nocount off;", "text", null);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (fSelect.Contains(" as "))
                    {
                        string[] str = fSelect.Split(new string[] { " as " }, StringSplitOptions.None);
                        if(str.Length>1)
                        {
                            fSelect = str[1];
                        }
                    }
                    return dt.Rows[0][fSelect].ToString();
                }
                else
                    return "";
            }
            return "";
        }
        public static string CodeDecode(string tblName, string fSelect, List<string> conName, List<string> con, List<bool> isDecimal, string fbranchcode)
        {
            //clsCommonDal objCmn = new clsCommonDal();
            //string sp = "Select " + fSelect + " from " + tblName;
            //if (conName.Count > 0)
            //    if (conName[0] != "")
            //        sp = sp + " where ";
            //for (int i = 0; i < conName.Count; i++)
            //{
            //    if (isDecimal[i])
            //    {
            //        if (conName[i] != "")
            //            sp = sp + conName[i] + " = " + con[i];
            //    }
            //    else
            //    {
            //        if (conName[i] != "")
            //            sp = sp + conName[i] + " = '" + con[i] + "'";
            //    }
            //    if (conName.Count > 1 && i != conName.Count - 1)
            //        sp = sp + " and ";
            //}
            //if (fbranchcode != "")
            //    sp = sp + " and BranchCode = '" + fbranchcode + "'";
            //DataTable dt = objCmn.GetTable(sp, "text", null);
            //if (dt.Rows.Count > 0)
            //    return dt.Rows[0][fSelect].ToString();
            //else
            //    return "";
            clsCommonDal objCmn = new clsCommonDal();
            string sp = "set nocount on;Select " + fSelect + " from " + tblName;
            if (conName.Count > 0)
                if (conName[0] != "")
                    sp = sp + " where ";
            for (int i = 0; i < conName.Count; i++)
            {
                if (isDecimal[i])
                {
                    if (conName[i] != "")
                        sp = sp + conName[i] + " = " + con[i];
                }
                else
                {
                    if (conName[i] != "")
                        sp = sp + conName[i] + " = '" + con[i] + "'";
                }
                if (conName.Count > 1 && i != conName.Count - 1)
                    sp = sp + " and ";
            }
            if (fbranchcode != "")
                sp = sp + " and BranchCode = '" + fbranchcode + "'";
            DataTable dt = objCmn.GetTable(sp + ";set nocount off;", "text", null);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                    return dt.Rows[0][fSelect].ToString();
                else
                    return "";
            }
            return "";
        }

        public static string CodeDecode(string tblName, string fSelect, string fAs, List<string> conName, List<string> con, string fbranchcode)
        {
            //clsCommonDal objCmn = new clsCommonDal();
            //string sp = "Select " + fSelect + " as " + fAs + " from " + tblName;
            //if (conName.Count > 0)
            //    if (conName[0] != "")
            //        sp = sp + " where ";
            //for (int i = 0; i < conName.Count; i++)
            //{
            //    if (conName[i] != "")
            //        sp = sp + conName[i] + " = '" + con[i] + "'";
            //    if (conName.Count > 1 && i != conName.Count - 1)
            //        sp = sp + " and ";
            //}
            //if (fbranchcode != "")
            //    sp = sp + " and BranchCode = '" + fbranchcode + "'";
            //DataTable dt = objCmn.GetTable(sp, "text", null);
            //if (dt.Rows.Count > 0)
            //    return dt.Rows[0][fAs].ToString();
            //else
            //    return "";
            clsCommonDal objCmn = new clsCommonDal();
            string sp = "set nocount on;Select " + fSelect + " as " + fAs + " from " + tblName;
            if (conName.Count > 0)
                if (conName[0] != "")
                    sp = sp + " where ";
            for (int i = 0; i < conName.Count; i++)
            {
                if (conName[i] != "")
                    sp = sp + conName[i] + " = '" + con[i] + "'";
                if (conName.Count > 1 && i != conName.Count - 1)
                    sp = sp + " and ";
            }
            if (fbranchcode != "")
                sp = sp + " and BranchCode = '" + fbranchcode + "'";
            DataTable dt = objCmn.GetTable(sp + ";set nocount off;", "text", null);
            if (dt.Rows.Count > 0)
                return dt.Rows[0][fAs].ToString();
            else
                return "";
        }
        public static string CodeDecode(string tblName, string fSelect, List<string> conName, List<string> con, string orderby, string fbranchcode)
        {
            clsCommonDal objCmn = new clsCommonDal();
            string sp = "set nocount on;Select " + fSelect + " from " + tblName;
            if (conName.Count > 0)
                if (conName[0] != "")
                    sp = sp + " where ";
            for (int i = 0; i < conName.Count; i++)
            {
                if (conName[i] != "")
                    sp = sp + conName[i] + " = " + FxQuoteStr(con[i]);
                if (conName.Count > 1 && i != conName.Count - 1)
                    sp = sp + " and ";
            }
            if (fbranchcode != "")
                sp = sp + " and BranchCode = '" + fbranchcode + "'";
            if (!string.IsNullOrEmpty(orderby.Trim()))
                sp = sp + " order by " + orderby;
            DataTable dt = objCmn.GetTable(sp + ";set nocount off;", "text", null);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (fSelect.Contains(" as "))
                    {
                        string[] str = fSelect.Split(new string[] { " as " }, StringSplitOptions.None);
                        if (str.Length > 1)
                        {
                            fSelect = str[1];
                        }
                    }
                    return dt.Rows[0][fSelect].ToString();
                }
                else
                    return "";
            }
            return "";
        }

        public static string FormatClientName(string clientcode, string ClientName, string clientAddress, string acName, string AcAddress)
        {
            string clientName;
            if (clientcode == "0000000")
                clientName = /*"A/C. " + */acName + "\n" + AcAddress;
            else
                clientName = "M/S. " + ClientName + "," + clientAddress + "\n" + "A/C. " + acName + "\n" + AcAddress;
            return clientName;
        }

        public static string FormatClientName(string clientcode, string ClientName, string clientAddress, string acName, string AcAddress, bool isEng)
        {
            string clientName;
            if (clientcode == "0000000")
                if (isEng)
                    clientName =  /*"A/C. " + */ acName + "\n" + AcAddress;
                else
                    clientName = "श्री " + acName + "\n" + AcAddress;
            else
                if (isEng)
                    clientName = "M/S. " + ClientName + "," + clientAddress + "\n" + "A/C. " + acName + "\n" + AcAddress;
                else
                    clientName = "श्री " + ClientName + "," + clientAddress + "\n" + "धितो लिने : " + acName + "\n" + AcAddress;
            return clientName;
        }

        public static string FxQuoteStr(string prmDatas)
        {
            return "'" + prmDatas.Replace("'", "''") + "'";
        }



        public static decimal Rounding(int classid, decimal amount)
        {
            List<string> conname = new List<string>();
            List<string> conval = new List<string>();
            conname.Add("classid");
            conval.Add(classid.ToString());
            int roundingid = ClsConvertTo.Int32(CodeDecode("msclass", "roundingid", conname, conval, ""));
            if (roundingid == (int)Enum_rounding.Floor)
                amount = Math.Floor(amount);//Math.Round((amount - 0.45M), 0);
            else if (roundingid == (int)Enum_rounding.Ceil)
                amount = Math.Ceiling(amount);//Math.Round((amount + 0.45M), 0);
            else
                amount = Math.Round(amount, 2);
            return amount;
        }

  

    }

    public class ClsConvertTo
    {
        public static int Int16(string value)
        {
            if (value.Trim() == "") { return 0; }

            else { return Convert.ToInt16(Convert.ToDecimal(value)); }
        }

        public static int Int16(object value)
        {
            if (value != null && Convert.ToString(value).Trim() != "")
            {
                return Convert.ToInt16(Convert.ToDecimal(value));
            }
            else { return 0; }
        }
        public static int Int32(string value)
        {
            if (value.Trim() == "") { return 0; }

            else { return Convert.ToInt32(Convert.ToDecimal(value)); }
        }

        public static int Int32(object value)
        {
            if (value != null && Convert.ToString(value).Trim() != "")
            {
                return Convert.ToInt32(Convert.ToDecimal(value));
            }
            else { return 0; }
        }
        public static Int64 Int64(string value)
        {
            if (value.Trim() == "") { return 0; }
            else { return Convert.ToInt64(Convert.ToDecimal(value)); }
        }

        public static Int64 Int64(object value)
        {
            if (value != null && Convert.ToString(value).Trim() != "")
            {
                return Convert.ToInt64(Convert.ToDecimal(value));
            }
            else { return 0; }
        }
        public static string String(object value)
        {
            if (value != null)
            {
                return value.ToString();
            }
            else { return ""; }
        }

        public static decimal Decimal(string value)
        {
            if (value.Trim() == "") { return 0; }
            else { return Convert.ToDecimal(value); }
        }

        public static decimal Decimal(object value)
        {
            if (value != null && Convert.ToString(value).Trim() != "")
            {
                return Convert.ToDecimal(value);
            }
            else { return 0; }
        }

        public static DateTime DateTime(string value)
        {
            if (value.Trim() == "") { return Convert.ToDateTime("0001-01-01"); }
            else { return Convert.ToDateTime(value); }
        }

        public static Boolean Boolean(object value)
        {
            if (value != null && Convert.ToString(value).Trim() != "")
            {
                if (Convert.ToString(value).Trim() == "1" || Convert.ToString(value).Trim() == "True")
                    return true;
                else
                    return false;
            }
            else { return false; }
        }

        public static Boolean Boolean(string value)
        {
            if (value.Trim() == "1" || value.ToLower().Trim() == "true")
                return true;
            else
                return false;
        }
    }

    public class ClsFormatTo
    {
        /// <summary>
        /// Right formatting function
        /// </summary>
        /// <param name="codeToFormat"></param>
        /// <param name="codeLength"></param>
        /// <returns></returns>
        #region
        public static string Right(string codeToFormat, int codeLength)
        {
            string formatedCode;
            ClsFormatTo obj = new ClsFormatTo();
            formatedCode = obj.FormatRight("00000000000000" + codeToFormat, codeLength);
            return formatedCode;
        }
        public string FormatRight(string original, int numberCharacters)
        {
            return original.Substring(original.Length - numberCharacters);
        }
        #endregion

        /// <summary>
        /// Left Formatting function
        /// </summary>
        /// <param name="s"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        #region
        public static string Left(string s, int len)
        {
            ClsFormatTo obj = new ClsFormatTo();
            return obj.FormatLeft(s, 2);
        }
        public string FormatLeft(string s, int left)
        {
            return s.Substring(0, left);
        }
        #endregion
    }

    public class ClsAppend
    {
        /// <summary>
        /// appending columns of repeater if all datas of repeater need to be inserted into the databse at once
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static StringBuilder Columns(string col, int row, DataTable dt)
        {
            StringBuilder strB = new StringBuilder();
            foreach (DataRow rows in dt.Rows)
            {
                if (rows[col].ToString() != "")
                    strB.AppendFormat("{0}" + ",", rows[col]);
            }
            if (strB.Length > 0)
                strB.Length--;
            //strB.Remove(strB.Length-2,strB.Length);
            //string str = strB.ToString();
            //str.Replace(
            return strB;
        }
    }

    public class ClsBind
    {
        #region properties
        public string tblName { get; set; }
        public string fieldName1 { get; set; }
        public string fieldName2 { get; set; }
        public List<string> conditionName { get; set; }
        public List<string> condition { get; set; }
        public string conName { get; set; }
        public string con { get; set; }
        public bool frmXml { get; set; }
        public string disctinctBy { get; set; }
        #endregion properties
        #region loading combo
        /// <summary>
        /// for binding Dropdownlist. this is phase 1
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="tblname"></param>
        /// <param name="fieldname1"></param>
        /// <param name="fieldname2"></param>
        /// <param name="conName"></param>
        /// <param name="con"></param>
        public static void FxLoadCombo(ref DropDownList ddl, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con)
        {
            ClsBind obj = new ClsBind();
            obj.tblName = tblname;
            obj.fieldName1 = fieldname1;
            obj.fieldName2 = fieldname2;
            obj.conditionName = conName;
            obj.condition = con;
            DataTable dt = obj.FxForBinding("");
            ddl.DataSource = dt;
            ddl.DataBind();
            //ddl.Items.Insert(0, "None");
            //ddl.Items[0].Value = "-1";
            //ddl.Items[0].Selected = true;
        }
        public static void FxLoadCombo(ref DropDownList ddl, string tblname, string fieldname, List<string> conName, List<string> con)
        {
            ClsBind obj = new ClsBind();
            obj.tblName = tblname;
            obj.fieldName1 = fieldname;
            obj.disctinctBy = fieldname;
            obj.conditionName = conName;
            obj.condition = con;
            DataTable dt = obj.FxForBinding("");
            ddl.DataSource = dt;
            ddl.DataBind();
            //ddl.Items.Insert(0, "None");
            //ddl.Items[0].Value = "-1";
            //ddl.Items[0].Selected = true;
        }
        public static void FxLoadCombo(ref DropDownList ddl, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con, string SortBy)
        {
            ClsBind obj = new ClsBind();
            obj.tblName = tblname;
            obj.fieldName1 = fieldname1;
            obj.fieldName2 = fieldname2;
            obj.conditionName = conName;
            obj.condition = con;
            DataTable dt = obj.FxForBinding(SortBy);

               // dt.DefaultView.Sort = SortBy;
            ddl.DataSource = dt;
            ddl.DataBind();
            //ddl.Items.Insert(0, "None");
            //ddl.Items[0].Value = "-1";
            //ddl.Items[0].Selected = true;
        }
        public static void FxLoadComboMonth(ref DropDownList ddl, string fieldname1, string fieldname2, List<string> conName, List<string> con, string SortBy)
        {
            ClsBind obj = new ClsBind();
            //obj.tblName = tblname;
            obj.fieldName1 = fieldname1;
            obj.fieldName2 = fieldname2;
            obj.conditionName = conName;
            obj.condition = con;
            DataTable newDt = new DataTable();
            newDt.Columns.Add("MONTH");
            newDt.Columns.Add("ID");
            //DataRow dr = newDt.NewRow();
            newDt.Rows.Add("Shrawan","4");
            newDt.Rows.Add("Bhadra", "5");
            newDt.Rows.Add("Ashoj", "6");
            newDt.Rows.Add("Kartik", "7");
            newDt.Rows.Add("Mangshir", "8");

            newDt.Rows.Add("Poush", "9");
            newDt.Rows.Add("Magh", "10");
            newDt.Rows.Add("Falgun", "11");
            newDt.Rows.Add("Chaitra", "12");
            newDt.Rows.Add("Baisakh", "1");
            newDt.Rows.Add("Jestha", "2");
            newDt.Rows.Add("Ashad", "3");
            //newDt.Rows.Add(dr);
            ddl.DataSource = newDt;
            ddl.DataBind();
        }
        //public static void FxLoadCombo(ref DropDownList ddl, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con, bool fromXml)
        //{
        //    ClsBind obj = new ClsBind();
        //    obj.tblName = tblname;
        //    obj.fieldName1 = fieldname1;
        //    obj.fieldName2 = fieldname2;
        //    obj.conditionName = conName;
        //    obj.condition = con;
        //    obj.frmXml = fromXml;
        //    DataTable dt = obj.FxForBinding("");
        //    ddl.DataSource = dt;
        //    ddl.DataBind();
        //    //ddl.Items.Insert(0, "None");
        //    //ddl.Items[0].Value = "-1";
        //    //ddl.Items[0].Selected = true;
        //}
        //public static void FxLoadCombo(ref DropDownList ddl, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con, bool fromXml, string SortBy)
        //{
        //    ClsBind obj = new ClsBind();
        //    obj.tblName = tblname;
        //    obj.fieldName1 = fieldname1;
        //    obj.fieldName2 = fieldname2;
        //    obj.conditionName = conName;
        //    obj.condition = con;
        //    obj.frmXml = fromXml;
        //    DataTable dt = obj.FxForBinding(SortBy);
        //    if (fromXml) dt.DefaultView.Sort = SortBy;
        //    ddl.DataSource = dt;
        //    ddl.DataBind();
        //    //ddl.Items.Insert(0, "None");
        //    //ddl.Items[0].Value = "-1";
        //    //ddl.Items[0].Selected = true;
        //}
        /// <summary>
        /// for binding Listbox. this is phase 1
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="tblname"></param>
        /// <param name="fieldname1"></param>
        /// <param name="fieldname2"></param>
        /// <param name="conName"></param>
        /// <param name="con"></param>
        public static void FxLoadCombo(ref ListBox lb, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con)
        {
            ClsBind obj = new ClsBind();
            obj.tblName = tblname;
            obj.fieldName1 = fieldname1;
            obj.fieldName2 = fieldname2;
            obj.conditionName = conName;
            obj.condition = con;
            DataTable dt = obj.FxForBinding("");
            lb.DataSource = dt;
            lb.DataBind();
            //ddl.Items.Insert(0, "None");
            //ddl.Items[0].Value = "-1";
            //ddl.Items[0].Selected = true;
        }
        public static void FxLoadCombo(ref ListBox lb, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con, string SortBy)
        {
            ClsBind obj = new ClsBind();
            obj.tblName = tblname;
            obj.fieldName1 = fieldname1;
            obj.fieldName2 = fieldname2;
            obj.conditionName = conName;
            obj.condition = con;
            DataTable dt = obj.FxForBinding(SortBy);
           // dt.DefaultView.Sort = SortBy;
            lb.DataSource = dt;
            lb.DataBind();
            //ddl.Items.Insert(0, "None");
            //ddl.Items[0].Value = "-1";
            //ddl.Items[0].Selected = true;
        }
        //public static void FxLoadCombo(ref ListBox lb, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con, bool fromXml)
        //{
        //    ClsBind obj = new ClsBind();
        //    obj.tblName = tblname;
        //    obj.fieldName1 = fieldname1;
        //    obj.fieldName2 = fieldname2;
        //    obj.conditionName = conName;
        //    obj.condition = con;
        //    obj.frmXml = fromXml;
        //    DataTable dt = obj.FxForBinding("");
        //    lb.DataSource = dt;
        //    lb.DataBind();
        //    //ddl.Items.Insert(0, "None");
        //    //ddl.Items[0].Value = "-1";
        //    //ddl.Items[0].Selected = true;
        //}
        //public static void FxLoadCombo(ref ListBox lb, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con, bool fromXml, string SortBy)
        //{
        //    ClsBind obj = new ClsBind();
        //    obj.tblName = tblname;
        //    obj.fieldName1 = fieldname1;
        //    obj.fieldName2 = fieldname2;
        //    obj.conditionName = conName;
        //    obj.condition = con;
        //    obj.frmXml = fromXml;
        //    DataTable dt = obj.FxForBinding(SortBy);
        //    if (fromXml) dt.DefaultView.Sort = SortBy;
        //    lb.DataSource = dt;
        //    lb.DataBind();
        //    //ddl.Items.Insert(0, "None");
        //    //ddl.Items[0].Value = "-1";
        //    //ddl.Items[0].Selected = true;
        //}
        /// <summary>
        /// for binding checkboxlist. this is phase 1
        /// </summary>
        /// <param name="chk"></param>
        /// <param name="tblname"></param>
        /// <param name="fieldname1"></param>
        /// <param name="fieldname2"></param>
        /// <param name="conName"></param>
        /// <param name="con"></param>
        public static void FxLoadCombo(ref CheckBoxList chk, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con)
        {
            ClsBind obj = new ClsBind();
            obj.tblName = tblname;
            obj.fieldName1 = fieldname1;
            obj.fieldName2 = fieldname2;
            obj.conditionName = conName;
            obj.condition = con;
            DataTable dt = obj.FxForBinding("");
            chk.DataSource = dt;
            chk.DataBind();
            //ddl.Items.Insert(0, "None");
            //ddl.Items[0].Value = "-1";
            //ddl.Items[0].Selected = true;
        }
        public static void FxLoadCombo(ref CheckBoxList chk, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con, string SortBy)
        {
            ClsBind obj = new ClsBind();
            obj.tblName = tblname;
            obj.fieldName1 = fieldname1;
            obj.fieldName2 = fieldname2;
            obj.conditionName = conName;
            obj.condition = con;
            DataTable dt = obj.FxForBinding(SortBy);
            //dt.DefaultView.Sort = SortBy;
            chk.DataSource = dt;
            chk.DataBind();
            //ddl.Items.Insert(0, "None");
            //ddl.Items[0].Value = "-1";
            //ddl.Items[0].Selected = true;
        }
        //public static void FxLoadCombo(ref CheckBoxList chk, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con, bool fromXml)
        //{
        //    ClsBind obj = new ClsBind();
        //    obj.tblName = tblname;
        //    obj.fieldName1 = fieldname1;
        //    obj.fieldName2 = fieldname2;
        //    obj.conditionName = conName;
        //    obj.condition = con;
        //    obj.frmXml = fromXml;
        //    DataTable dt = obj.FxForBinding("");
        //    chk.DataSource = dt;
        //    chk.DataBind();
        //    //ddl.Items.Insert(0, "None");
        //    //ddl.Items[0].Value = "-1";
        //    //ddl.Items[0].Selected = true;
        //}
        //public static void FxLoadCombo(ref CheckBoxList chk, string tblname, string fieldname1, string fieldname2, List<string> conName, List<string> con, bool fromXml, string SortBy)
        //{
        //    ClsBind obj = new ClsBind();
        //    obj.tblName = tblname;
        //    obj.fieldName1 = fieldname1;
        //    obj.fieldName2 = fieldname2;
        //    obj.conditionName = conName;
        //    obj.condition = con;
        //    obj.frmXml = fromXml;
        //    DataTable dt = obj.FxForBinding(SortBy);
        //    if (fromXml)
        //        dt.DefaultView.Sort = SortBy;
        //    chk.DataSource = dt;
        //    chk.DataBind();
        //    //ddl.Items.Insert(0, "None");
        //    //ddl.Items[0].Value = "-1";
        //    //ddl.Items[0].Selected = true;
        //}
        /// <summary>
        /// for binding Dropdownlist. this is phase 2
        /// </summary>
        /// <returns></returns>
        public DataTable FxForBinding(string SortBy)
        {
            if (frmXml)
            {
                string XmlName = tblName + "XML.xml";
                string path = HttpContext.Current.Server.MapPath("~/App_Data/" + XmlName);
                if (!File.Exists(path))
                {
                    ClsXML.CreateXml(path, XmlName);
                    FxBindXML(path);
                }
                FxCheckEmptyXML(path);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                ds.ReadXml(path);
                DataSet dsnew = new DataSet();
                dsnew = ds.Copy();
                if (dsnew.Tables.Count > 0)
                {
                    string select = "";
                    for (int i = 0; i < conditionName.Count; i++)
                    {
                        if (conditionName[i] != "")
                            select = select + conditionName[i] + " <> '" + condition[i] + "'";
                        if (conditionName.Count > 1 && i != conditionName.Count - 1)
                            select = select + " or ";
                    }
                    if (select != "")
                    {
                        DataRow[] drr = dsnew.Tables[0].Select(select, fieldName1);

                        foreach (DataRow dr in drr)
                        {
                            dsnew.Tables[0].Rows.Remove(dr);
                        }
                    }
                    dt = dsnew.Tables[0].Copy();
                }
                //dt.Rows.Add(drr);
                return dt;
            }
            else
            {
                if (!string.IsNullOrEmpty(disctinctBy))
                //if (disctinctBy != "")
                {
                    clsCommonDal objCmn = new clsCommonDal();
                    string sp = "set nocount on;Select distinct " + fieldName1 + " from " + tblName;
                    if (conditionName.Count > 0)
                        if (conditionName[0] != "")
                            sp = sp + " where ";
                    for (int i = 0; i < conditionName.Count; i++)
                    {
                        if (conditionName[i] != "")
                            sp = sp + conditionName[i] + " = '" + condition[i] + "'";
                        if (conditionName.Count > 1 && i != conditionName.Count - 1)
                            sp = sp + " and ";
                    }
                    if (string.IsNullOrEmpty(SortBy))
                    {
                        sp = sp + " order by " + fieldName1 + ";set nocount off;";
                    }
                    else
                        sp = sp + " order by " + SortBy + ";set nocount off;";
                    return objCmn.GetTable(sp, "text", null);

                }
                else
                {
                    clsCommonDal objCmn = new clsCommonDal();
                    string sp = "set nocount on;Select " + fieldName1 + "," + fieldName2 + " from " + tblName;
                    if (conditionName.Count > 0)
                        if (conditionName[0] != "")
                            sp = sp + " where ";
                    for (int i = 0; i < conditionName.Count; i++)
                    {
                        if (conditionName[i] != "")
                            sp = sp + conditionName[i] + " = '" + condition[i] + "'";
                        if (conditionName.Count > 1 && i != conditionName.Count - 1)
                            sp = sp + " and ";
                    }

                    if (string.IsNullOrEmpty(SortBy))
                    {
                        sp = sp + " order by " + fieldName1 + ";set nocount off;";
                    }
                    else
                        sp = sp + " order by " + SortBy + ";set nocount off;";
                    return objCmn.GetTable(sp, "text", null);
                }
            }
        }
        public void FxCheckEmptyXML(string path)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(path);
            if (ds == null)
            {
                FxBindXML(path);
            }
            else if (ds.Tables.Count <= 0)
            {
                FxBindXML(path);
            }
            else if (ds.Tables[0] == null)
            {
                FxBindXML(path);
            }
            else if (ds.Tables[0].Rows.Count <= 0)
            {
                FxBindXML(path);
            }
            else
                return;
        }

        public void FxBindXML(string path)
        {
            clsCommonDal objCmn = new clsCommonDal();
            DataTable dt1 = new DataTable();
            string sp = "Select * from " + tblName;
            dt1 = objCmn.GetTable(sp, "text", null);
            ClsXML.SaveChildXml(dt1, "Row", path, "combo");
            FxCheckEmptyXML(path);
        }

        public static void FxLoadComboByLike(ref ListBox lb, string tblname, string fieldname1, string fieldname2, string likeConName, string likeCon, List<string> conName, List<string> con)
        {
            ClsBind obj = new ClsBind();
            obj.tblName = tblname;
            obj.fieldName1 = fieldname1;
            obj.fieldName2 = fieldname2;
            obj.conName = likeConName;
            obj.con = likeCon;
            obj.conditionName = conName;
            obj.condition = con;
            clsCommonDal objCmn = new clsCommonDal();
            string sp = "Select " + fieldname1 + "," + fieldname2 + " from " + tblname + " where " + likeConName + " like '%" + obj.con.Replace("'", "''") + "%'";
            for (int i = 0; i < obj.conditionName.Count; i++)
            {
                if (obj.conditionName[i] != "")
                    sp = sp + obj.conditionName[i] + " = '" + obj.condition[i] + "'";
                if (obj.conditionName.Count > 1 && i != obj.conditionName.Count - 1)
                    sp = sp + " and ";
            }
            DataTable dt = objCmn.GetTable(sp, "text", null);
            lb.DataSource = dt;
            lb.DataBind();
        }

        public static void FxLoadComboByLike(ref ListBox lb, string tblname, string fieldname1, string fieldname2, string conName, string con)
        {
            ClsBind obj = new ClsBind();
            obj.tblName = tblname;
            obj.fieldName1 = fieldname1;
            obj.fieldName2 = fieldname2;
            obj.conName = conName;
            obj.con = con;
            clsCommonDal objCmn = new clsCommonDal();
            string sp = "Select " + fieldname1 + "," + fieldname2 + " from " + tblname + " where " + conName + " like '%'+" + ClsCommon.FxQuoteStr(obj.con) + "+'%'";

            DataTable dt = objCmn.GetTable(sp, "text", null);
            lb.DataSource = dt;
            lb.DataBind();
        }



        public static void FxFilterAndLoadCombo(ref DropDownList ddl, string tblname, string fieldname1, string fieldname2, string conName, string con)
        {
            ClsBind obj = new ClsBind();
            obj.tblName = tblname;
            obj.fieldName1 = fieldname1;
            obj.fieldName2 = fieldname2;
            obj.conName = conName;
            obj.con = con;

            clsCommonDal objCmn = new clsCommonDal();
            string sp = "Select " + fieldname1 + "," + fieldname2 + " from " + tblname + " where " + conName + "(" + obj.con + ")";

            DataTable dt = objCmn.GetTable(sp, "text", null);
            ddl.DataSource = dt;
            ddl.DataBind();
            //ddl.Items.Insert(0, "None");
            //ddl.Items[0].Value = "-1";
            //ddl.Items[0].Selected = true;
        }

        public static void FxFilterAndLoadComboChkBox(ref CheckBoxList chk, string tblname, string fieldname1, string fieldname2, string conName, string con)
        {
            ClsBind obj = new ClsBind();
            obj.tblName = tblname;
            obj.fieldName1 = fieldname1;
            obj.fieldName2 = fieldname2;
            obj.conName = conName;
            obj.con = con;

            clsCommonDal objCmn = new clsCommonDal();
            string sp = "Select " + fieldname1 + "," + fieldname2 + " from " + tblname + " where " + conName + "(" + obj.con + ")";

            DataTable dt = objCmn.GetTable(sp, "text", null);
            chk.DataSource = dt;
            chk.DataBind();
            //ddl.Items.Insert(0, "None");
            //ddl.Items[0].Value = "-1";
            //ddl.Items[0].Selected = true;
        }
        #endregion loading combo
        #region for selectedIndex
        /// <summary>
        /// for setting selected index in Dropdownlist
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="val"></param>
        /// <param name="findBy"></param>
        public static void FxComboSelectecIndex(ref DropDownList ddl, string val, string findBy)
        {
            if (findBy == "val")
                ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(val));
            else if (findBy == "txt")
                ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByText(val));
        }

        public static void FxComboSelectecIndex(ref RadioButtonList rbl, string val, string findBy)
        {
            if (findBy == "val")
                rbl.SelectedIndex = rbl.Items.IndexOf(rbl.Items.FindByValue(val));
            else if (findBy == "txt")
                rbl.SelectedIndex = rbl.Items.IndexOf(rbl.Items.FindByText(val));
        }

        public static void FxComboSelectecIndex(ref CheckBoxList chk, string val, string findBy)
        {
            if (findBy == "val")
                chk.SelectedIndex = chk.Items.IndexOf(chk.Items.FindByValue(val));
            else if (findBy == "txt")
                chk.SelectedIndex = chk.Items.IndexOf(chk.Items.FindByText(val));
        }

        public static void FxComboSelectecIndex(ref ListBox lb, string val, string findBy)
        {
            if (findBy == "val")
                lb.SelectedIndex = lb.Items.IndexOf(lb.Items.FindByValue(val));
            else if (findBy == "txt")
                lb.SelectedIndex = lb.Items.IndexOf(lb.Items.FindByText(val));
        }

        public static void FxTreeViewSelectNode(ref TreeView trv, string ValueToSelect)
        {
            foreach (TreeNode n in trv.Nodes)
            {
                if (n.Value == ValueToSelect)
                {
                    n.Select();
                    break;
                }
                SelectNodeByValue(n, ValueToSelect);
            }
        }

        protected static void SelectNodeByValue(TreeNode Node, string ValueToSelect)
        {
            foreach (TreeNode n in Node.ChildNodes)
            {
                if (n.Value == ValueToSelect)
                {
                    n.Select();
                    break;
                }
                else
                {
                    SelectNodeByValue(n, ValueToSelect);
                }
            }
        }
        #endregion for selectedIndex
    }

    public class ClsConnection
    {
        /// <summary>
        /// for crystal report connection
        /// </summary>
        /// <param name="reportDocument"></param>
        public static void FxRptConnection(ReportDocument reportDocument, string _user, string _password, string _server, string _database)
        {
            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            crConnectionInfo.ServerName = _server;
            crConnectionInfo.DatabaseName = _database;
            crConnectionInfo.UserID = _user;
            crConnectionInfo.Password = _password;

            CrTables = reportDocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
        }
    }

    public class clsRpt
    {
        public static DataTable GenerateRepeatorWithDataType(DataTable vDt, string[] repeaterContent, string[] repeaterDataType, string[] repeateHeader)
        {
            DataTable dt = new DataTable();
            if (vDt == null)
            {
                dt.Columns.Add(new DataColumn("ID", typeof(int)));
                // dt.Columns.Add(new DataColumn("RowNumber", typeof(int)));
                for (int i = 0; i < repeaterContent.Length; i++)
                {
                    if (repeaterDataType[i] == "decimal")
                        dt.Columns.Add(new DataColumn(repeateHeader[i], typeof(decimal)));
                    else if (repeaterDataType[i] == "int")
                        dt.Columns.Add(new DataColumn(repeateHeader[i], typeof(int)));
                    else
                        dt.Columns.Add(new DataColumn(repeateHeader[i], typeof(string)));
                }
            }
            else
            {
                dt = vDt;
            }
            DataRow dtRow = dt.NewRow();
            try
            {
                dtRow["ID"] = 0;
            }
            catch
            {
                //dt.Columns.Add(new DataColumn("ID", typeof(int)));
                //dtRow["ID"] = 0;
            }
            dtRow["RowNumber"] = repeaterContent[0];
            for (int i = 1; i < repeaterContent.Length; i++)
            {
                dtRow[repeateHeader[i]] = repeaterContent[i];
            }
            dt.Rows.Add(dtRow);
            return dt;
        }
        public static DataTable GenerateRepeatorForImport(DataTable vDt, string[] repeaterContent, string[] repeateHeader)
        {
            DataTable dt = new DataTable();
            if (vDt == null)
            {
                dt.Columns.Add(new DataColumn("RowNumber", typeof(int)));
                for (int i = 1; i < repeaterContent.Length; i++)
                {
                    dt.Columns.Add(new DataColumn(repeateHeader[i], typeof(string)));
                }
            }
            else
            {
                dt = vDt;
            }
            DataRow dtRow = dt.NewRow();
            dtRow["RowNumber"] = repeaterContent[0];
            for (int i = 1; i < repeaterContent.Length; i++)
            {
                dtRow[repeateHeader[i]] = repeaterContent[i];
            }
            dt.Rows.Add(dtRow);
            return dt;
        }


        //public static DataTable GenerateRepeatorForUpload(DataTable vDt, string[] repeaterContent, string[] repeateHeader/*, Byte[] size*/)
        //{
        //    DataTable dt = new DataTable();
        //    if (vDt == null)
        //    {
        //        dt.Columns.Add(new DataColumn("RowNumber", typeof(int)));
        //        for (int i = 1; i < repeaterContent.Length; i++)
        //        {
        //            dt.Columns.Add(new DataColumn(repeateHeader[i], typeof(string)));
        //        }
        //        //dt.Columns.Add(new DataColumn(repeateHeader[repeaterContent.Length], typeof(Byte[])));
        //    }
        //    else
        //    {
        //        dt = vDt;
        //    }
        //    DataRow dtRow = dt.NewRow();
        //    dtRow["RowNumber"] = repeaterContent[0];
        //    for (int i = 1; i < repeaterContent.Length; i++)
        //    {
        //        dtRow[repeateHeader[i]] = repeaterContent[i];
        //    }
        //    //dtRow[repeateHeader[repeaterContent.Length]] = size;
        //    dt.Rows.Add(dtRow);
        //    return dt;
        //}

        public static DataTable GenerateRepeator(DataTable vDt, string[] repeaterContent, string[] repeateHeader)
        {
            DataTable dt = new DataTable();
            if (vDt == null)
            {
                dt.Columns.Add(new DataColumn("ID", typeof(int)));
                dt.Columns.Add(new DataColumn("RowNumber", typeof(int)));
                for (int i = 1; i < repeaterContent.Length; i++)
                {
                    dt.Columns.Add(new DataColumn(repeateHeader[i], typeof(string)));
                }
            }
            else
            {
                dt = vDt;
            }
            DataRow dtRow = dt.NewRow();
            try
            {
                dtRow["ID"] = 0;
            }
            catch
            {
                //dt.Columns.Add(new DataColumn("ID", typeof(int)));
                //dtRow["ID"] = 0;
            }
            dtRow["RowNumber"] = repeaterContent[0];
            for (int i = 1; i < repeaterContent.Length; i++)
            {
                dtRow[repeateHeader[i]] = repeaterContent[i];
            }
            dt.Rows.Add(dtRow);
            return dt;
        }
        public static DataTable GenRptFromTbl(DataTable vDt, string[] repeaterContent, string[] repeateHeader)
        {
            DataTable dt = new DataTable();
            if (vDt == null)
            {
                dt.Columns.Add(new DataColumn("ID", typeof(int)));
                dt.Columns.Add(new DataColumn("RowNumber", typeof(int)));

                for (int i = 2; i < repeaterContent.Length; i++)
                {
                    dt.Columns.Add(new DataColumn(repeateHeader[i], typeof(string)));
                }
            }
            else
            {
                dt = vDt;
            }
            DataRow dtRow = dt.NewRow();
            dtRow["ID"] = repeaterContent[1];
            dtRow["RowNumber"] = repeaterContent[0];
            for (int i = 2; i < repeaterContent.Length; i++)
            {
                dtRow[repeateHeader[i]] = repeaterContent[i];
            }
            dt.Rows.Add(dtRow);
            return dt;
        }


        //internal static DataTable GenerateRepeator(DataTable dataTable, string[] content)
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class ClsXML
    {
        public static void CreateXml(string filePath, string filename)
        {
            if (!File.Exists(filePath))
            {
                XmlTextWriter writer = new XmlTextWriter(filePath, System.Text.Encoding.UTF8);
                //Start XM DOcument
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 2;
                //ROOT Element
                writer.WriteStartElement(filename);
                writer.WriteEndElement();
                //End XML Document
                writer.WriteEndDocument();
                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('xml file created');", true);
                writer.Close();
            }
        }
        public static bool SaveXml(ListItemCollection lst, string path, string xmlpolicyid)
        {
            if (ClsConvertTo.Int32(ClsCommon.UserCode) == 0 || ClsCommon.BranchId == 0 )//|| ClsCommon.SessionId == "" )//|| (//ClsCommon.DOCID == 0 &&//TASK.ToUpper() == "EDIT"))
                return false;
            ClsUserBll objUser = new ClsUserBll();
            //DataTable dtCheck = objUser.CheckSession();
            //if (dtCheck == null)
            //    return false;
            //else if (dtCheck.Rows.Count <= 0)
            //    return false;
            //else if (ClsCommon.UserCode == dtCheck.Rows[0]["USERCODE"].ToString()
            //    && ClsCommon.BranchId == ClsConvertTo.Int32(dtCheck.Rows[0]["BRANCHID"].ToString())
            //    && ClsCommon.SessionId == dtCheck.Rows[0]["SessionId"].ToString()
            //    )//&& //ClsCommon.DOCID == ClsConvertTo.Int32(dtCheck.Rows[0]["DOCID"].ToString()))
            //    return false;
            string[] strsplit = xmlpolicyid.Split('_');
            if (strsplit.Length == 5)
            {
                if (strsplit[1] == ClsCommon.UserCode && strsplit[4] == ClsCommon.BranchId.ToString() )
                {
                    FileInfo fi = new FileInfo(path);
                    XmlDocument xml = new XmlDocument();
                    if (System.IO.File.Exists(path))
                    {
                        xml.Load(path);
                        string fName = fi.Name.Replace(".xml", "");
                        XmlElement el = (XmlElement)xml.SelectSingleNode("/" + fName + "/Row[ID='" + xmlpolicyid + "']");
                        if (el != null) { el.ParentNode.RemoveChild(el); }
                        xml.Save(path);
                    }
                    xml.Load(path);
                    //XmlElement rootEle = xml.CreateElement("Root");
                    XmlElement ParentElement = xml.CreateElement("Row");

                    for (int i = 0; i < lst.Count; i++)
                    {
                        XmlElement E = xml.CreateElement(lst[i].Text);
                        E.InnerText = lst[i].Value;
                        ParentElement.AppendChild(E);
                    }
                    //rootEle.AppendChild(ParentElement);
                    xml.DocumentElement.AppendChild(ParentElement);
                    xml.Save(path);
                    return true;
                }
            }
            return false;
        }
        public static DataSet GetXml(string path)
        {
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(path);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable GetXmlforexport(string path, string xmlid)
        {
            DataSet ds = ClsXML.GetXml(path);

            if (ds != null)
            {
                try
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        foreach (DataTable dt in ds.Tables)
                        {
                            DataTable dt2 = dt.Clone();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (dt.Rows[i]["ID"].ToString() == xmlid)
                                {
                                    //DataRow dr=dt.Rows[i];

                                    DataRow dr = dt2.NewRow();
                                    dr = dt.Rows[i];

                                    dt2.ImportRow(dr);
                                    return dt2;


                                }
                            }

                        }

                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }
        public static DataTable GetChildXml(string childpath, string xmlid,int docid)
        {
            DataTable dtnew = new DataTable();
            DataSet ds1 = new DataSet();
            ds1 = ClsXML.GetXml(childpath);
            if (ds1 != null)
            {
                if (ds1.Tables.Count != 0)
                {
                    string[] strsplit = xmlid.Split('_');
                    string newid = "";
                    foreach (var item in strsplit)
                    {
                        newid = newid + item;
                    }
                    foreach (DataTable dt in ds1.Tables)
                    {
                        if (dt.TableName == "id" + newid)
                        {


                            dtnew = dt;
                            return dtnew;



                        }

                    }

                }
            }
            return null;
        }
    
        public static bool CheckForId(string xmlpolicyid, string filename)
        {
            if (string.IsNullOrEmpty(filename) == false)
            {
                XmlDocument xmlDoc = new XmlDocument();
                string filepath = HttpContext.Current.Server.MapPath("~/App_Data/" + filename + ".xml");
                if (System.IO.File.Exists(filepath))
                {

                    if (string.IsNullOrEmpty(filepath) == false)
                    {
                        xmlDoc.Load(filepath);

                        XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/" + filename + "/Row[ID='" + xmlpolicyid + "']");
                        if (el != null)
                            return true;
                    }
                }
            }
            return false;
        }

        public static void UpdateXml(ListItemCollection lst, string path)
        {
            DataSet ds = GetXml(path);
            if (ds != null)
            {
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                        {
                            if (ds.Tables[0].Rows[j][lst[0].Text].ToString() == lst[0].Value)
                            {
                                for (int i = 0; i < lst.Count; i++)
                                {
                                    ds.Tables[0].Rows[j][lst[i].Text] = lst[i].Value;
                                }
                            }
                        }
                        ds.WriteXml(path);
                    }
                }
            }
        }

        public static bool SaveChildXml(DataTable dt, string id, string path)
        {
            if (ClsConvertTo.Int32(ClsCommon.UserCode) == 0 || ClsCommon.BranchId == 0 )//|| ClsCommon.SessionId == "" )//|| (//ClsCommon.DOCID == 0 &&//TASK.ToUpper() == "EDIT"))
                return false;
            ClsUserBll objUser = new ClsUserBll();
            //DataTable dtCheck = objUser.CheckSession();
            //if (dtCheck == null)
            //    return false;
            //else if (dtCheck.Rows.Count <= 0)
            //    return false;
            //else if (ClsCommon.UserCode == dtCheck.Rows[0]["USERCODE"].ToString()
            //    && ClsCommon.BranchId == ClsConvertTo.Int32(dtCheck.Rows[0]["BRANCHID"].ToString())
            //    && ClsCommon.SessionId == dtCheck.Rows[0]["SessionId"].ToString()
            //    )//&& //ClsCommon.DOCID == ClsConvertTo.Int32(dtCheck.Rows[0]["DOCID"].ToString()))
            //    return false;
            string[] strsplit = id.Split('_');
            if (strsplit.Length == 5)
            {
                if (strsplit[1] == ClsCommon.UserCode && strsplit[4] == ClsCommon.BranchId.ToString() )//&& id == ClsCommon.SessionId)
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(path);
                    XmlNode root = xml.DocumentElement;
                    string newid = "";
                    foreach (var item in strsplit)
                    {
                        newid = newid + item;
                    }
                    XmlNodeList nodelist = xml.GetElementsByTagName("id" + newid);
                    //XmlNodeList newnodelist = nodelist;
                    //if (nodelist != null)
                    //{
                    //    foreach (XmlNode xmlNode in newnodelist)
                    //    {
                    //        root.RemoveChild(xmlNode);
                    //    }
                    //}
                    Scan(nodelist);
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            XmlElement ParentElement = xml.CreateElement("id" + newid);

                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                XmlElement E = xml.CreateElement(dt.Columns[j].ToString());
                                E.InnerText = dt.Rows[i][j].ToString();
                                ParentElement.AppendChild(E);
                            }
                            //rootEle.AppendChild(ParentElement);
                            xml.DocumentElement.AppendChild(ParentElement);
                        }
                    }
                    xml.Save(path);
                    return true;
                }
            }
            return false;
        }
        public static void SaveChildXml(DataTable dt, string id, string path, string frm)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(path);
            XmlNode root = xml.DocumentElement;
            XmlNodeList nodelist = xml.GetElementsByTagName("id" + id);
            //XmlNodeList newnodelist = nodelist;
            //if (nodelist != null)
            //{
            //    foreach (XmlNode xmlNode in newnodelist)
            //    {
            //        root.RemoveChild(xmlNode);
            //    }
            //}
            Scan(nodelist);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    XmlElement ParentElement = xml.CreateElement("id" + id);

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        XmlElement E = xml.CreateElement(dt.Columns[j].ToString());
                        E.InnerText = dt.Rows[i][j].ToString();
                        ParentElement.AppendChild(E);
                    }
                    //rootEle.AppendChild(ParentElement);
                    xml.DocumentElement.AppendChild(ParentElement);
                }
            }
            xml.Save(path);
        }

        public static XmlNodeList Scan(XmlNodeList nodeList)
        {
            List<XmlNode> toRemove = new List<XmlNode>();

            foreach (XmlNode xmlElement in nodeList)
            {
                //string elementValue = xmlElement.InnerText;
                //if (elementValue.Length < 6 || elementValue.Substring(0, 3) != "999")
                //{
                toRemove.Add(xmlElement);
                //}
            }

            foreach (XmlNode xmlElement in toRemove)
            {
                XmlNode node = xmlElement.ParentNode;
                node.RemoveChild(xmlElement);
            }

            return nodeList;
        }

        public static void CreateXmlForTable(string tblName)
        {
            string XmlName = tblName + "XML.xml";
            string path = HttpContext.Current.Server.MapPath("~/App_Data/" + XmlName);
            //if (!File.Exists(path))
            //{
            clsCommonDal objCmn = new clsCommonDal();
            DataTable dt1 = new DataTable();
            string sp = "Select * from " + tblName;
            dt1 = objCmn.GetTable(sp, "text", null);
            File.Delete(path);
            ClsXML.CreateXml(path, XmlName);
            ClsXML.SaveChildXml(dt1, "Row", path);
            //}
        }

        //public static void xmldelte(string filename,string filenamechild, string filenamesecondchild, string xmlpolicyid)
        //{


        //    if ( string.IsNullOrEmpty(filename)==false)
        //    {
        //        XmlDocument xmlDoc = new XmlDocument();
        //        string filepath = HttpContext.Current.Server.MapPath("~/App_Data/" + filename + ".xml");
        //        if(System.IO.File.Exists(filepath))
        //        {

        //        if (string.IsNullOrEmpty(filepath) == false)
        //        {
        //            xmlDoc.Load(filepath);

        //            XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/" + filename + "/Row[ID='" + xmlpolicyid + "']");
        //            if (el != null) { el.ParentNode.RemoveChild(el); }



        //            xmlDoc.Save(filepath);
        //        }
        //        }
        //    }

        //    if (string.IsNullOrEmpty(filenamechild)==false)
        //    {
        //        XmlDocument xmlDoc = new XmlDocument();
        //        string filepath = HttpContext.Current.Server.MapPath("~/App_Data/" + filenamechild + ".xml");
        //        if(System.IO.File.Exists(filepath))
        //        {
        //        if (string.IsNullOrEmpty(filepath) == false)
        //        {
        //            xmlDoc.Load(filepath);

        //            string firstchild = "id" + xmlpolicyid;
        //            XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/" + filenamechild + "/ " + firstchild + "");
        //            if (el != null) { el.ParentNode.RemoveChild(el); }
        //            xmlDoc.Save(filepath);
        //        }
        //        }

        //    }

        //    if (string.IsNullOrEmpty(filenamesecondchild) == false)
        //    {
        //        XmlDocument xmlDoc = new XmlDocument();
        //        string filepath = HttpContext.Current.Server.MapPath("~/App_Data/" + filenamesecondchild + ".xml");
        //        if(System.IO.File.Exists(filepath))
        //        {
        //            if (string.IsNullOrEmpty(filepath) == false)
        //            {
        //                xmlDoc.Load(filepath);

        //                string firstchild = "id" + xmlpolicyid;
        //                XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/" + filenamesecondchild + "/ " + firstchild + "");
        //                if (el != null) { el.ParentNode.RemoveChild(el); }
        //                xmlDoc.Save(filepath);
        //            }
        //        }

        //    }


        //   string fileName_A = "WIZAXml";
        //   string childfilename_A="";
        //   string xmlid = xmlpolicyid;
        //   fxdeletewiz(fileName_A,childfilename_A, xmlid);

        //   string filename_B = "WIZBXml";
        //   string childfilename_B = "WIZB_TblMultipleBranchXML";
        //   fxdeletewiz(filename_B, childfilename_B, xmlid);

        //   string filename_D = "WIZDXml";
        //   string childfilename_D = "XMLTblRskBrkUp";
        //   fxdeletewiz(filename_D, childfilename_D, xmlid);


        //   string filename_E = "WIZE_Xml";
        //   string chilfilename_E = "";
        //   fxdeletewiz(filename_E, chilfilename_E, xmlid);

        //    string filename_F="";
        //   string childname_f = "XMLTblCoinsurance";
        //   fxdeletewiz(filename_F, childname_f, xmlid);

        //}

        //private static void fxdeletewiz(string filenamewiz,string childfilenamewiz, string xmlpolicyid)
        //{
        //    if (string.IsNullOrEmpty(filenamewiz)==false)
        //    {
        //        XmlDocument xmlDoc = new XmlDocument();
        //        string filepath = HttpContext.Current.Server.MapPath("~/App_Data/" + filenamewiz + ".xml");
        //        if(System.IO.File.Exists(filepath))
        //        {
        //        if (string.IsNullOrEmpty(filepath) == false)
        //        {
        //            xmlDoc.Load(filepath);
        //            XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/" + filenamewiz + "/Row[ID='" + xmlpolicyid + "']");
        //            if (el != null) { el.ParentNode.RemoveChild(el); }
        //            xmlDoc.Save(filepath);
        //        }
        //        }
        //    }
        //    if ( string.IsNullOrEmpty(childfilenamewiz)==false)
        //    {
        //        XmlDocument xmlDoc = new XmlDocument();
        //        string filepath = HttpContext.Current.Server.MapPath("~/App_Data/" + childfilenamewiz + ".xml");
        //        if(System.IO.File.Exists(filepath))
        //        {
        //        if (string.IsNullOrEmpty(filepath) == false)
        //        {
        //            xmlDoc.Load(filepath);
        //            string firstchild = "id" + xmlpolicyid;
        //            XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/" + childfilenamewiz + "/ " + firstchild + "");
        //            if (el != null) { el.ParentNode.RemoveChild(el); }
        //            xmlDoc.Save(filepath);
        //        }
        //        }
        //    }

        //}
        public static void DeleteWizards(ListItemCollection lst, string xmlpolicyid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string filename, filepath, filetype;
            for (int i = 0; i < lst.Count; i++)
            {
                filename = lst[i].Value;
                filetype = lst[i].Text;
                filepath = HttpContext.Current.Server.MapPath("~/App_Data/" + filename + ".xml");

                File.Delete(filepath);
                //if (filetype == "parent")
                //{
                //    if (System.IO.File.Exists(filepath))
                //    {
                //        if (string.IsNullOrEmpty(filepath) == false)
                //        {
                //            xmlDoc.Load(filepath);
                //            XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/" + filename + "/Row[ID='" + xmlpolicyid + "']");
                //            if (el != null) { el.ParentNode.RemoveChild(el); }
                //            xmlDoc.Save(filepath);
                //        }
                //    }
                //}
                //else if (filetype == "child")
                //{
                //    if (System.IO.File.Exists(filepath))
                //    {
                //        if (string.IsNullOrEmpty(filepath) == false)
                //        {
                //            xmlDoc.Load(filepath);
                //            string firstchild = "id" + xmlpolicyid;
                //            XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/" + filename + "/ " + firstchild + "");
                //            if (el != null) { el.ParentNode.RemoveChild(el); }
                //            xmlDoc.Save(filepath);
                //        }
                //    }
                //}
            }

        }
    }

    public class ClsSecurity
    {
        clsCommonEnumerator.ModuleName objEnumModuleName = new clsCommonEnumerator.ModuleName();
        public static string GetIP4Address()
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            if (IP4Address != String.Empty)
            {
                return IP4Address;
            }

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }
        public static string GetMacAddress(string ipAddress)
        {
            string macAddress = string.Empty;
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a " + ipAddress;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string strOutput = pProcess.StandardOutput.ReadToEnd();
            string[] substrings = strOutput.Split('-');
            if (substrings.Length >= 8)
            {
                macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                         + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6]
                         + "-" + substrings[7] + "-"
                         + substrings[8].Substring(0, 2);
                return macAddress;
            }

            else
            {
                return Mac_Address();
            }
        }
        private static string Mac_Address()
        {
            string MAC = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                {
                    if (nic.GetPhysicalAddress().ToString() != "")
                    {
                        MAC = nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }
            }
            return MAC;
        }
        public static string GetComputername()
        {



            return System.Net.Dns.GetHostName();
        }
        public static string GetModulename()
        {
            return HttpContext.Current.Request.RawUrl;

        }

       

        //by sunila
        public static DataTable FxGetSecurityUserWise(int pageId)
        {
            ClsUserPermissionBll objUserPermission = new ClsUserPermissionBll();
            objUserPermission.UserId = ClsConvertTo.Int32(ClsCommon.UserCode);
            objUserPermission.BRANCHID = ClsConvertTo.Int32(ClsCommon.BranchCode);
            objUserPermission.PageId = pageId;
            return objUserPermission.FxGetSecurityUserWise();
        }

        //by sunila
        public static DataTable FxGetSecurityGroupWise()
        {
            ClsSecurityNameBll objGroupPermission = new ClsSecurityNameBll();
            objGroupPermission.USERGROUPID = ClsConvertTo.Int32(ClsCommon.GroupCode);
            DataSet ds = objGroupPermission.Getsecurity();
            if (ds.Tables.Count > 0)
                return ds.Tables[1];
            return null;
        }

       


       

        public static bool FxGetSecurityPermission(string moduleGrpName, string moduleName, string secutrityName)
        {
            /* sunila: isadmin part must be removed after complete security setup for admin [24-aug-2016]*/
            if (ClsCommon.IsAdmin)
                return true;
            else
            {
                ClsUserPermissionBll objUserPermission = new ClsUserPermissionBll();
                objUserPermission.UserId = ClsConvertTo.Int32(ClsCommon.UserCode);
                objUserPermission.BRANCHID = ClsConvertTo.Int32(ClsCommon.BranchId);
                objUserPermission.SUBBRANCHID = ClsConvertTo.Int32(ClsCommon.SubBranchId);
                objUserPermission.MODULEGNAME = moduleGrpName;
                objUserPermission.MODEULENAME = moduleName;
                objUserPermission.SECURITYNAME = secutrityName;
                DataTable dt = objUserPermission.FxGetSecurityPermission();
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        if (ClsConvertTo.Boolean(dt.Rows[0]["HASPERMISSION"]) == true)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;

            }
        }

     

      

       
    } //ashish

    public class clsSecurityNew
    {
        public static DataTable FxGetSecurityList_New(string prmModGroup, string prmModuleName, string prmSecurityList, string prmPrimarySecName)
        {
            ClsUserPermissionBll objSec = new ClsUserPermissionBll();
            objSec.MODULEGNAME = prmModGroup;
            objSec.MODEULENAME = prmModuleName;
            objSec.SECURITYNAME = prmSecurityList;
            objSec.PRIMARY_SECURITYNAME = prmPrimarySecName;
            objSec.UserId = ClsConvertTo.Int32( ClsCommon.UserCode);
            return objSec.FxGetSecurityList_New();
        }
       public static DataTable FxGetSecurityAccessBranch_New(string prmModGroup, string prmModuleName, string prmSecurityList)
       {
           ClsUserPermissionBll objSec = new ClsUserPermissionBll();
           objSec.MODULEGNAME = prmModGroup;
           objSec.MODEULENAME = prmModuleName;
           objSec.SECURITYNAME = prmSecurityList;
           objSec.UserId = ClsConvertTo.Int32(ClsCommon.UserCode);
           return objSec.FxGetSecurityAccessBranch_New();
       }

       public static DataTable FxGetSecurityAccessBranch_Security_New(string prmModGroup, string prmModuleName, string prmSecurityList)
       {
           ClsUserPermissionBll objSec = new ClsUserPermissionBll();
           objSec.MODULEGNAME = prmModGroup;
           objSec.MODEULENAME = prmModuleName;
           objSec.SECURITYNAME = prmSecurityList;
           objSec.UserId = ClsConvertTo.Int32(ClsCommon.UserCode);
           return objSec.FxGetSecurityAccessBranch_Security_New();
       }

        public static Boolean FxCheckUserSecurity(DataTable dtSec, string prmSecurityName, int prmSubBranchID)
       {
           //DataTable dtSec = (DataTable)ViewState["SECURITY"];
           if (ClsCommon.IsAdmin)
           {
               return true;
           }
           if (dtSec == null)
           {
               return false;
           }
           if (dtSec.Rows.Count == 0)
           {
               return false;
           }
           else
           {
               DataRow[] dr = dtSec.Select("SecurityName = '" + prmSecurityName + "' and subbranchid = " + prmSubBranchID.ToString());
               if (dr.Length == 0)
               {
                   return false;
               }
               else
                   return true;
           }
       }

        public static Boolean FxHasUserSecurity(DataTable dtSec, string prmSecurityName)
        {
            if (ClsCommon.IsAdmin) return true;

            DataRow[] dr = dtSec.Select("SecurityName = '" + prmSecurityName + "'");
            if (dr.Length > 0)
                return true;
            else
                return false;
        }
    }
    public class ClsSendMail
    {
        ClientScriptManager abc;
        MailMessage msg = new MailMessage();
        // Gmail Address from where you send the mail
        public MailAddress fromAddress { get; set; }
        // any address where the email will be sending
        public MailAddressCollection toAddress { get; set; }
        public MailAddressCollection ccAddress { get; set; }
        public MailAddressCollection bccAddress { get; set; }
        public Boolean isBodyHtml { get; set; }
        //Password of your gmail address
        public string fromPassword { get; set; }
        // Passing the values and make a email formate to display
        public string subject { get; set; }
        public string body { get; set; }
        public List<HttpPostedFile> attachments { get; set; }
        public List<string> strFullFileName { get; set; }
        public Attachment check { get; set; }
        //public AttachmentCollection attach { get; set; }

        public void SendMail()
        {
            
            List<string> conName = new List<string>();
            List<string> conVal = new List<string>();
            conName = new List<string>();
            conVal = new List<string>();
            conName.Add("ISENABLED");
            conVal.Add("1");
            string _host = ClsCommon.CodeDecode("DEF_SMTP_SETUP", "hostname", conName, conVal, "");
            int _Port = ClsConvertTo.Int32(ClsCommon.CodeDecode("DEF_SMTP_SETUP", "port", conName, conVal, ""));
            int _enablessl = ClsConvertTo.Int32(ClsCommon.CodeDecode("DEF_SMTP_SETUP", "EnableSSl", conName, conVal, ""));
            msg = new MailMessage();
            SmtpClient mySmtpClient = new SmtpClient(_host,_Port);

            // set smtp-client with basicAuthentication
            mySmtpClient.UseDefaultCredentials = false;
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(fromAddress.Address, fromPassword);
            mySmtpClient.Credentials = basicAuthenticationInfo;

            //// smtp settings
            //var smtp = new SmtpClient();
            //{
            //    smtp.Host = "202.52.255.85";
            //    smtp.Port = 465;
            //    //smtp.Host = "smtp.gmail.com";
            //    //smtp.Port = 587;
            //    smtp.EnableSsl = true;
            //    //smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //    //smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
            //    smtp.Credentials = new NetworkCredential("rajesh_415259@picl.com.np", "rajesh123");
            //    //smtp.UseDefaultCredentials = true;
            //    smtp.Timeout = 20000;
            //}
            //// Passing values to smtp object
            ////smtp.Send(fromAddress, toAddress, subject, body);

            msg.From = fromAddress;
            if (toAddress != null)
                foreach (var item in toAddress)
                {
                    msg.To.Add(item);
                }
            if (ccAddress != null)
                foreach (var item in ccAddress)
                {
                    msg.CC.Add(item);
                }
            if (bccAddress != null)
                foreach (var item in bccAddress)
                {
                    msg.Bcc.Add(item);
                }

            msg.Subject = subject;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = body;
                msg.IsBodyHtml=isBodyHtml;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            if (check != null)
            {
                msg.Attachments.Add(check);
            }
            if (attachments != null)
            {
                for (int i = 0; i < attachments.Count; i++)
                {
                    HttpPostedFile hpf = attachments[i];
                    string strFileName = Path.GetFileName(hpf.FileName);
                    Attachment attachFile = new Attachment(hpf.InputStream, strFileName);
                  
                    msg.Attachments.Add(attachFile);
                }
            }
            if(strFullFileName!=null)
            {
                for (int i = 0; i < strFullFileName.Count; i++)
                {
                    Attachment attachFile = new Attachment(strFullFileName[i]);

                    msg.Attachments.Add(attachFile);
                }
            }
            try
            {
                if (_enablessl == 1)
                    mySmtpClient.EnableSsl = true;
                mySmtpClient.Send(msg);
            }

            catch (Exception ex)
            {
                string script = "<script>alert('" + ex.Message + "');self.close();</script>";
                this.abc.RegisterClientScriptBlock(this.GetType(), "sendMail", script);

                if (strFullFileName != null)
                    strFullFileName.Clear();
            }
            finally
            {
                msg.Dispose();
                if (strFullFileName != null)
                    strFullFileName.Clear();

            }
        }

        public string SendActivationEmail(string userEmail, string name, int empId, string usrname, string pass,ref string _randomKey)
        {
            try
            {
                ClsSendMail objMail = new ClsSendMail();
                string _email = "";
                string _Password = "";
                string ActivationUrl = string.Empty;

                #region Sender Details
                List<string> conName = new List<string>();
                List<string> conVal = new List<string>();
                conName = new List<string>();
                conVal = new List<string>();
                conName.Add("ISENABLED");
                conVal.Add("1");
                _email = ClsCommon.CodeDecode("DEF_SMTP_SETUP", "email", conName, conVal, "");
                _Password = ClsCommon.CodeDecode("DEF_SMTP_SETUP", "password", conName, conVal, "");
                string ip = ClsCommon.CodeDecode("DEF_SMTP_SETUP", "SoftwareIp", conName, conVal, "");
                string swPort = ClsCommon.CodeDecode("DEF_SMTP_SETUP", "SoftwarePort", conName, conVal, "");
                objMail.fromAddress = new MailAddress(_email, ClsCommon.CompanyName);
                objMail.fromPassword = _Password;
                objMail.subject = "Confirmation email for account activation";
                #endregion


                string _empId = ClsCrypto.GetEncryptedQueryString(empId.ToString());
                ActivationUrl = "http://" + ip + ":" + swPort + "/activateaccount.aspx?EmpID=" + _empId + "&ActivationCode=" + _randomKey;
                string body = "<html><head><title></title></head>"
                    + "<body style=\"margin:0; padding:0;\">"
                    + "<div style=\"width: 750px;\">"
                    + "<h1 style=\"padding:10px; text-align:center; background:#005099; margin:0; font-size:32px; text-transform:capitalize; color:#fff;\">" + ClsCommon.CompanyName + "</h1>"
                    + "<div style=\"padding:20px 40px;\">"
                    + "<p style=\"font-size:25px;\">Hi <strong> " + name + "</strong>, just one more step!</p>"
                    + "<p style=\"font-size:18px;\">We just need to verify email address to complete Signup Process.</p>"
                    + "<form style=\"text-align:center;font-weight:bold;\">"
                     + "<p>Username: " + usrname + "</p>"
                    + "<p>Email id: " + userEmail + "</p>"
                    + "<p style=\"margin-bottom:25px;\">Password:" + pass + "</p>"
                    + "<a style=\" background:#008a00; color:#fff; padding:10px; border:1px solid #008a00;text-decoration:none;font-weight:normal;\" href = '" + ActivationUrl + "'>Verify Your Email</a>"
                    + "</form>"
                    + "</div>"
                    + "<div style=\" border-top: 1px solid #ccc; bottom: 0; position: absolute; width: 750px; padding:10px 0;\">"

                    + "<div style=\"width:100%; float:left;  text-align:center;\">"

                    + "<p style=\" margin-top: 10px;\">&copy; 2016 copyright. All Rights Reserved</p>"

                    + "</div>"

                    + "</div>"

                    + "</div>"
                    + "</body>"
                    + "</html>";

                MailAddressCollection mail = new MailAddressCollection();
                mail.Add(userEmail);
                objMail.toAddress = mail;
                objMail.body = body;
                objMail.isBodyHtml = true;
                objMail.SendMail();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public void RandomActivationCode(ref string _randomKey)
        {
            string Password = "";
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~!@";
            var random = new Random();
            var result = new string(
            Enumerable.Repeat(chars, 16)
                  .Select(s => s[random.Next(s.Length)])
                  .ToArray());
            Password = result.ToString();

            _randomKey = Password;


        }
        //public void SendMail()
        //{

        //    // smtp settings
        //    var smtp = new SmtpClient();
        //    {
        //        //smtp.Host = "smtp.mos.com.np";
        //        //smtp.Port = 25;
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.Port = 587;
        //        smtp.EnableSsl = true;
        //        //smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        //        smtp.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
        //        //smtp.UseDefaultCredentials = true;
        //        smtp.Timeout = 20000;
        //    }
        //    // Passing values to smtp object
        //    //smtp.Send(fromAddress, toAddress, subject, body);

        //    msg.From = fromAddress;
        //    if (toAddress != null)
        //        foreach (var item in toAddress)
        //        {
        //            msg.To.Add(item);
        //        }
        //    if (ccAddress != null)
        //        foreach (var item in ccAddress)
        //        {
        //            msg.CC.Add(item);
        //        }
        //    if (bccAddress != null)
        //        foreach (var item in bccAddress)
        //        {
        //            msg.Bcc.Add(item);
        //        }

        //    msg.Subject = subject;
        //    msg.Body = body;
        //    if (check != null)
        //    {
        //        msg.Attachments.Add(check);
        //    }
        //    if (attachments != null)
        //    {
        //        for (int i = 0; i < attachments.Count; i++)
        //        {
        //            HttpPostedFile hpf = attachments[i];
        //            string strFileName = Path.GetFileName(hpf.FileName);
        //            Attachment attachFile = new Attachment(hpf.InputStream, strFileName);
        //            msg.Attachments.Add(attachFile);
        //        }
        //    }
        //    try
        //    {
        //        smtp.EnableSsl = true;
        //        smtp.Send(msg);

        //    }

        //    catch (Exception)
        //    {
        //        string script = "<script>alert('Failed in Sending Mail');self.close();</script>";
        //        this.abc.RegisterClientScriptBlock(this.GetType(), "sendMail", script);
        //    }
        //    finally
        //    {
        //        msg.Dispose();

        //    }
        //}
    }

    public class ClsCrypto
    {
       
        //string strPassword = Guid.NewGuid().ToString("N").Substring(0, 12);
        public static string Key = Guid.NewGuid().ToString("N").Substring(0, 16);
        private static byte[] GetByte(string data)
        {
            return Encoding.UTF8.GetBytes(data);
        }

        //public static byte[] EncryptString(string data, string Key)
        //{
        //    byte[] byteData = GetByte(data);
        //    SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
        //    algo.Key = GetByte(Key);
        //    algo.GenerateIV();

        //    MemoryStream mStream = new MemoryStream();
        //    mStream.Write(algo.IV, 0, algo.IV.Length);

        //    CryptoStream myCrypto = new CryptoStream(mStream, algo.CreateEncryptor(), CryptoStreamMode.Write);
        //    myCrypto.Write(byteData, 0, byteData.Length);
        //    myCrypto.FlushFinalBlock();

        //    return mStream.ToArray();
        //}

        //public static string DecryptString(byte[] data, string Key)
        //{
        //    SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
        //    algo.Key = GetByte(Key);
        //    MemoryStream mStream = new MemoryStream();

        //    byte[] byteData = new byte[algo.IV.Length];
        //    Array.Copy(data, byteData, byteData.Length);
        //    algo.IV = byteData;
        //    int readFrom = 0;
        //    readFrom += algo.IV.Length;

        //    CryptoStream myCrypto = new CryptoStream(mStream, algo.CreateDecryptor(), CryptoStreamMode.Write);
        //    myCrypto.Write(data, readFrom, data.Length - readFrom);
        //    myCrypto.FlushFinalBlock();

        //    return Encoding.UTF8.GetString(mStream.ToArray());
        //}

        //public static string GetEncryptedQueryString(string data,string key)
        //{
        //    return Convert.ToBase64String(EncryptString(data,key));
        //}

        //public static string GetDecryptedQueryString(string data,string key)
        //{
        //    byte[] byteData = Convert.FromBase64String(data.Replace(" ", "+"));
        //    return DecryptString(byteData,key);
        //}

        //private static byte[] GetByte1(string data)
        //{
        //    return Encoding.UTF8.GetBytes(data);
        //}

        public static byte[] EncryptString(string data)
        {
           
            byte[] byteData = GetByte(data);
            SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
            algo.Key = GetByte(Key);
            algo.GenerateIV();

            MemoryStream mStream = new MemoryStream();
            mStream.Write(algo.IV, 0, algo.IV.Length);

            CryptoStream myCrypto = new CryptoStream(mStream, algo.CreateEncryptor(), CryptoStreamMode.Write);
            myCrypto.Write(byteData, 0, byteData.Length);
            myCrypto.FlushFinalBlock();

            return mStream.ToArray();
        }

        public static string DecryptString(byte[] data)
        {
           
            SymmetricAlgorithm algo = SymmetricAlgorithm.Create();
            algo.Key = GetByte(Key);
            MemoryStream mStream = new MemoryStream();

            byte[] byteData = new byte[algo.IV.Length];
            Array.Copy(data, byteData, byteData.Length);
            algo.IV = byteData;
            int readFrom = 0;
            readFrom += algo.IV.Length;

            CryptoStream myCrypto = new CryptoStream(mStream, algo.CreateDecryptor(), CryptoStreamMode.Write);
            myCrypto.Write(data, readFrom, data.Length - readFrom);
            myCrypto.FlushFinalBlock();

            return Encoding.UTF8.GetString(mStream.ToArray());
        }

        public static string GetEncryptedQueryString(string data)
        {
            return Convert.ToBase64String(EncryptString(data));
        }

        public static string GetDecryptedQueryString(string data)
        {
            byte[] byteData = Convert.FromBase64String(data.Replace(" ", "+"));
            return DecryptString(byteData);
        }
        public static string getKey()
        {
            return Convert.ToBase64String(GetByte(Key));
        }
 
    }

    public class ClsAlert
    {
        public static void Alert(string Message)
        {
            string cleanMessage = Message.Replace("'", "\\'").Replace(Environment.NewLine, " ").Replace("\n", " ");
            string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";

            // Gets the executing web page 
            Page page = HttpContext.Current.CurrentHandler as Page;

            // Checks if the handler is a Page and that the script isn't allready on the Page 
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
            {
                page.ClientScript.RegisterClientScriptBlock(typeof(ClsAlert), "alert", script);
            }
        }
    }

}