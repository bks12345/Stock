using Ensure.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsReinsuranceSearchbll
    {
        public string BRANCHCODE { get; set; }

        public int BRANCHID { get; set; }

        public string ACCEPTANCENO { get; set; }

        public int LOCKED { get; set; }

        public string SUBBRANCHCODE { get; set; }

        public int SUBBRANCHID { get; set; }

        public string FISCALYEAR { get; set; }

        public string Month { get; set; } 

        public int FISCALID { get; set; }

        public int CheckDate { get; set; }

        public DateTime FROM { get; set; }

        public DateTime TO { get; set; }

        public string DEPTCODE { get; set; }

        public int DEPTID { get; set; }

        public int CLASSID { get; set; }

        public int ENTRY_USERID { get; set; }    

        public string DOCTYPE { get; set; }

        public string ENDORSETYPE { get; set; }

        public string DOCUMENTNO { get; set; }

        public string FACBUSINESS { get; set; }

        public string POLICYNO { get; set; }

       public int DOCNO { get; set; }

        public string BUSINESSTYPE { get; set; }

        public int USERID { get; set; }
        public int PG { get; set; }

        public int PGSIZE { get; set; }
        public int PAYTYPE { get; set; } 

        public int ISCHECKDATE { get; set; }

        public DataSet GetReinsurance()
        {
            ClsReinsuranceSearchDal objdal = new ClsReinsuranceSearchDal();
            return objdal.GetReinsurance(this);
        }

        //public DataTable GetReinsurance()
        //{
        //    ClsReinsuranceSearchDal objdal = new ClsReinsuranceSearchDal();
        //    DataTable dt = new DataTable();
        //    dt= objdal.GetReinsurance(this);
        //    return dt;
        //}
    }
}