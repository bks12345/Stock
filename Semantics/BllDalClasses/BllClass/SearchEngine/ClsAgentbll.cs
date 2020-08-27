using Ensure.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsAgentbll
    {
        public int Fiscalid { get; set; }
        public int id { get; set; }
        public int branchid { get; set; }
        public int subbranchid { get; set; }
        public DateTime Datefrom { get; set; }
        public DateTime DateTo { get; set; }
        public string FieldOfficer { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public DataTable dtSecBranch { get; set; }
        public DataTable dtSecSubBranch { get; set; }
        public int Sec_userid { get; set; }

        ClsAgentDal objdal = new ClsAgentDal();
        public DataTable GetAgentDetail()
        {
            return objdal.GetAgent(this);
        }
    }
}
    
