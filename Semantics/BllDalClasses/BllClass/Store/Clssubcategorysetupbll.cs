using Stock.BllDalClasses.DalClass.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.Store
{
    public class Clssubcategorysetupbll
    {
        public int id { get; set; }
        public string NSubcategory { get; set; }
        public string ESubcategory { get; set; }
        public int AUID { get; set; }
        public DateTime ADT { get; set; }
        public int UUID { get; set; }
        public DateTime UDT { get; set; }
        public int category { get; set; }

        ClssubcategorysetupDal obj = new ClssubcategorysetupDal();
        public string InsertUpdatesubcategory()
        {
            return obj.InsertUpdatesubcategory(this);
        }
        public DataTable Getsubcategory()
        {
            DataTable dt = new DataTable();
            dt = obj.Getsubcategory(this);
            return dt;
        }

    }
}