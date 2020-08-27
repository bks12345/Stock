using Ensure.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsDamageSearchBll
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
        public int DamId { get; set; }

        ClsDamageSearchDal objdal = new ClsDamageSearchDal();
        public DataTable GetDamageDeatils()
        {
            return objdal.GetDamageDeatils(this);
        }
        public DataTable Get_DamageEntry_DETAILS()
        {
            return objdal.Get_DamageEntry_DETAILS(this);
        }
        public DataTable Get_DamageEntry_DETAILSAll()
        {
            return objdal.Get_DamageEntry_DETAILSAll(this);
        }

    }
}