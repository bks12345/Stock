using Ensure.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsClaimPaymentBll
    {
        public DateTime datefrom { get; set; }
        public DateTime dateto { get; set; }
        public int Branchid { get; set; }
        public int Subbranchid { get; set; }
        public int TYPE { get; set; }
        public DataTable dtSecBranch { get; set; }
        public DataTable dtSecSubBranch { get; set; }
        public int Sec_userid { get; set; }

        ClsClaimPaymentDal objdal = new ClsClaimPaymentDal();

        internal DataTable getclaimreportdetails()
        {
            return objdal.getclaimreportdetails(this);
        }
    }
}