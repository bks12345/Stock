using Stock.BllDalClasses.DalClass.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.Store
{
    public class ClsUOMSetupbll
    {
        public int id { get; set; }
        public string Nunit { get; set; }
        public string Eunit{ get; set; }
        public string Abbreviation { get; set; }
        public int AUID { get; set; }
        public DateTime ADT { get; set; }
        public int UUID { get; set; }
        public DateTime UDT { get; set; }

        ClsUOMSetupDal objdal = new ClsUOMSetupDal();
        public string InsertUpdateUOMS()
        {
            return objdal.InsertUpdateUOMS(this);
        }
        public DataTable GetUOMS()
        {
            DataTable dt = new DataTable();
            dt = objdal.GetUOMS(this);
            return dt;
        }
    }
}