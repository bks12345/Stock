using Stock.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.SearchEngine
{
    public class ClsPurchaseSearchBll
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

        ClsPurchaseSearchDal objdal = new ClsPurchaseSearchDal();
        public DataTable GetPurchaseDeatils()
        {
            return objdal.GetPurchaseDeatils(this);
        }
        public DataTable GetSalesDeatils()
        {
            return objdal.GetSalesDeatils(this);
        }
    }
}