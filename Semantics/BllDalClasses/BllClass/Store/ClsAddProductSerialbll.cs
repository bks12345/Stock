using Stock.BllDalClasses.DalClass.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.Store
{
    public class ClsAddProductSerialbll
    {
        public int id { get; set; }
        public string SerialNo { get; set; }
        public int AUID { get; set; }
        public DateTime ADT { get; set; }
        public int UUID { get; set; }
        public DateTime UDT { get; set; }
        public int categoryid { get; set; }
        public int subcategoryid { get; set; }
        public int Particularid { get; set; }

        ClsAddProductSerialDal obj = new ClsAddProductSerialDal();
        public string InsertUpdateAddProductSerialsetup()
        {
            return obj.InsertUpdateAddProductSerialsetup(this);
        }
        public DataTable GetAddProductSerialsetup()
        {
            DataTable dt = new DataTable();
            dt = obj.GetAddProductSerialsetup(this);
            return dt;
        }

    }
}