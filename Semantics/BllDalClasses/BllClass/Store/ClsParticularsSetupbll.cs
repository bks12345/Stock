using Stock.BllDalClasses.DalClass.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.Store
{
    public class ClsParticularsSetupbll
    {
        public int id { get; set; }
        public string Nparticulars { get; set; }
        public string Eparticulars { get; set; }
        public int AUID { get; set; }
        public DateTime ADT { get; set; }
        public int UUID { get; set; }
        public DateTime UDT { get; set; }
        public int categoryid { get; set; }
        public int subcategoryid { get; set; }


        ClsParticularsSetupDal obj = new ClsParticularsSetupDal();
        public string InsertUpdateParticularssetup()
        {
            return obj.InsertUpdateParticularssetup(this);
        }
        public DataTable GetParticularssetup()
        {
            DataTable dt = new DataTable();
            dt = obj.GetParticularssetup(this);
            return dt;
        }

    }
}