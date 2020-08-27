using Stock.BllDalClasses.DalClass.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.Store
{
    public class ClsDepartmentSetupbll
    {
           public int id { get; set; }
        public string Ndeptnamey { get; set; }
        public string Edeptname { get; set; }
        public int AUID { get; set; }
        public DateTime ADT { get; set; }
        public int UUID { get; set; }
        public DateTime UDT { get; set; }

        ClsDepartmentSetupDal objdal = new ClsDepartmentSetupDal();
        public string InsertUpdatecategory()
        {
            return objdal.InsertUpdateDepartmentSetup(this);
        }
        public DataTable GetDepartmentSetup()
        {
            DataTable dt = new DataTable();
            dt = objdal.GetDepartmentSetup(this);
            return dt;
        }    
    }
}