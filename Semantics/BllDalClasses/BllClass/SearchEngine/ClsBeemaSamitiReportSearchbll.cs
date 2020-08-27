
using Ensure.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsBeemaSamitiReportSearchbll
    {
        public int Fiscalid { get; set; }
        public int Deptid { get; set; }
        public DateTime Datefrom { get; set; }
        public DateTime DateTo { get; set; }
        public string reponame { get; set; }

        public string Quarter { get; set; }

        ClsBeemaSamitiReportSearchDal objdal = new ClsBeemaSamitiReportSearchDal();
        public DataTable getrepo_Bankers_Report()
        {
            return objdal.getrepo_Bankers_Report(this);
        }
        public DataTable getrepo_Contractors_Report()
        {
            return objdal.getrepo_Contractors_Report(this);
        }
        public DataTable getrepo_Engineering_Report()
        {
            return objdal.getrepo_Engineering_Report(this);
        }
        public DataTable getrepo_Fire_Report()
        {
            return objdal.getrepo_Fire_Report(this);
        }
        public DataTable getrepo_Household_Report()
        {
            return objdal.getrepo_Household_Report(this);
        }
        public DataTable getrepo_Marine_Report()
        {
            return objdal.getrepo_Marine_Report(this);
        }
        public DataTable getrepo_Medical_Report()
        {
            return objdal.getrepo_Medical_Report(this);
        }
        public DataTable getrepo_Miscellaneous_Report()
        {
            return objdal.getrepo_Miscellaneous_Report(this);
        }
        public DataTable getrepo_Motor_Report()
        {
            return objdal.getrepo_Motor_Report(this);
        }
        public DataTable getrepo_PAGPA_Report()
        {
            return objdal.getrepo_PAGPA_Report(this);
        }
        public DataTable getrepo_TMI_report()
        {
            return objdal.getrepo_TMI_report(this);
        }

        public DataTable getrepo_Cattle_Report()
        {
            return objdal.getrepo_Cattle_Report(this);
        }
        public DataTable getrepo_Cattle_Report_summary1()
        {
            return objdal.getrepo_Cattle_Report_summary1(this);
        }
        public DataTable getrepo_Cattle_Report_summary2()
        {
            return objdal.getrepo_Cattle_Report_summary2(this);
        }
        public DataTable getrepo_Cattle_Report_summary3()
        {
            return objdal.getrepo_Cattle_Report_summary3(this);
        }
        public DataTable getrepo_Cattle_Report_summary4()
        {
            return objdal.getrepo_Cattle_Report_summary4(this);
        }
        public DataTable getrepo_Cattle_Report_summary5()
        {
            return objdal.getrepo_Cattle_Report_summary5(this);
        }
        #region for claim
        public DataTable Get_MotorReport_Claim()
        {
            return objdal.Get_MotorReport_Claim(this);
        }

        public DataTable getTMIreport_claim()
        {
            return objdal.getTMIreport_claim(this);
        }
        public DataTable getFireReport_Claim()
        {
            return objdal.getFireReport_Claim(this);
        }
        public DataTable getMarineReport_Claim()
        {
            return objdal.getMarineReport_Claim(this);
        }
        public DataTable getMiscellaneousReport_Claim()
        {
            return objdal.getMiscellaneousReport_Claim(this);
        }
        public DataTable getEngineeringReport_Claim()
        {
            return objdal.getEngineeringReport_Claim(this);
        }
        public DataTable getContractorsReport_Claim()
        {
            return objdal.getContractorsReport_Claim(this);
        }
        public DataTable getPAGPAReport_Claim()
        {
            return objdal.getPAGPAReport_Claim(this);
        }
        public DataTable getBankersReport_Claim()
        {
            return objdal.getBankersReport_Claim(this);
        }
        public DataTable getHouseholdReport_Claim()
        {
            return objdal.getHouseholdReport_Claim(this);
        }
        public DataTable getMedicalReport_Claim()
        {
            return objdal.getMedicalReport_Claim(this);
        }
        #endregion for claim 
    }
}