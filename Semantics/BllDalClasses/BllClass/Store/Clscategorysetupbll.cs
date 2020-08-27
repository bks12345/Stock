using Stock.BllDalClasses.DalClass.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.Store
{
    public class Clscategorysetupbll
    {
        public int id { get; set; }
        public string Ncategory { get; set; }
        public string Ecategory { get; set; }
        public string Acountcode { get; set; }
        public int AUID { get; set; }
        public DateTime ADT { get; set; }
        public int UUID { get; set; }
        public DateTime UDT { get; set; }
        public int islock { get; set; }

        ClscategorysetupDal objdal = new ClscategorysetupDal();
        public string InsertUpdatecategory()
        {
            return objdal.InsertUpdatecategory(this);
        }
        public DataTable Getcategory()
        {
            DataTable dt = new DataTable();
            dt = objdal.Getcategory(this);
            return dt;
        }
    }
}