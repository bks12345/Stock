using Ensure.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsAccountSearchBll
    {
        public int accountcode { get; set; }
        public string accountdesc { get; set; }
        public string SLcode { get; set; }
        public int isbank { get; set; }
        public int deptid { get; set; }
        public int classid { get; set; }
        public int surveyorid { get; set; }
        public string agentcode { get; set; }
        public string catid { get; set; }


        public DataTable GetAccountDetails()
        {
            ClsAccountSearchDal objdal = new ClsAccountSearchDal();
            return objdal.GetAccountDetails(this);
        }
    }
}