using Ensure.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsDisbursementSearchBll
    {
        public int BRANCHID { get; set; }
        public int SUBBRANCHID { get; set; }
        public int FISCALID { get; set; }
        public int DISBURSEMENTNO { get; set; }
        public int DISBURSEMENT_TYPE { get; set; }
        public string BILLNO { get; set; }
        public DateTime DATEFROM { get; set; }
        public DateTime DATETO { get; set; }
        public int Tempid { get; set; }
        public int Id { get; set; }
        public DataTable dtSecBranch { get; set; }
        public DataTable dtSecSubBranch { get; set; }
        public int Sec_userid { get; set; }
        ClsDisbursementSearchDal objdal = new ClsDisbursementSearchDal();
        public DataTable GetAllDisbursementList()
        {
            return objdal.GetAllDisbursementList(this);
        }
        public DataTable GetAllDisbursementSummary()
        {
            return objdal.GetAllDisbursementSummary(this);
        }
        public string insertdisbursmentsummary()
        {
            return objdal.insertdisbursmentsummary(this);
        }
    }
}