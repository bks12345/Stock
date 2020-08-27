using Ensure.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsActivityLogSearchBll
    {
        public int BRANCHID { get; set; }
        public int USERID { get; set; }
        public int groupname { get; set; }
        public DateTime DATEFROM { get; set; }
        public DateTime DATETO { get; set; }
        public int PG { get; set; }
        public int PGSIZE { get; set; }


        public DataTable dtSecBranch { get; set; }
        public DataTable dtSecSubBranch { get; set; }
        public int Sec_userid { get; set; }
        ClsActivityLogSearchDal objdal = new ClsActivityLogSearchDal();
        public DataSet GetallActivityLog()
        {
            return objdal.GetallActivityLog(this);
        }
        public DataSet GetActivityLog()
        {
            return objdal.GetActivityLog(this);
        }
    }
}