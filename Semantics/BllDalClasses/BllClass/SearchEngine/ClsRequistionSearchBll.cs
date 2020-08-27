using Ensure.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsRequistionSearchBll
    {
        public int Fiscalid { get; set; }
        public int branchid { get; set; }
        public int subbranchid { get; set; }
        public DateTime Datefrom { get; set; }
        public DateTime DateTo { get; set; }
        public int Billno { get; set; }
        public int vendorid { get; set; }
        public DataTable dtSecBranch { get; set; }
        public DataTable dtSecSubBranch { get; set; }
        public int Sec_userid { get; set; }
        public int ReqId { get; set; }

        ClsRequistionSearchDal objdal = new ClsRequistionSearchDal();
        public DataTable GetRequistionDeatils()
        {
            return objdal.GetRequistionDeatils(this);
        }
        public DataTable Get_RequistionEntry_DETAILS()
        {
            return objdal.Get_RequistionEntry_DETAILS(this);
        }
        public DataTable Get_RequistionEntry_DETAILSAll()
        {
            return objdal.Get_RequistionEntry_DETAILSAll(this);
        }

    }
}