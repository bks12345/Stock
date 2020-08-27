using Ensure.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsCreditNoteSearchBll
    {
        public int branchid { get; set; }
        public int subbranchid { get; set; }
        public int fiscalyrid { get; set; }
        public DateTime datefrom { get; set; }
        public DateTime dateto { get; set; }
        public int statusid { get; set; }
        public string policyno { get; set; }
        public string documentno { get; set; }
        public string creditnoteno { get; set; }
        public string bankname { get; set; }
        public string insuredname { get; set; }
        public int deptid { get; set; }
        public int classid { get; set; }
        public int bankid { get; set; }
        public int accountnameid { get; set; }
        public int PG { get; set; }
        public int PGSIZE { get; set; }
        
        public DataTable dtSecBranch { get; set; }
        public DataTable dtSecSubBranch { get; set; }
        public int Sec_userid { get; set; }
        
        ClsCreditNoteSearchDal objdal = new ClsCreditNoteSearchDal();
        public DataSet GetClaimNotePaymentSearch()
        {
            return objdal.GetClaimNotePaymentSearch(this);
        }
    }
}