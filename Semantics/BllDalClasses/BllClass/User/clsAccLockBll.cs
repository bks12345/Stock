using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllDalClasses.DalClass.User;

namespace Stock.BllDalClasses.BllClass.User
{
    public class clsAccLockBll
    {
        public string MAINTABLENAME { get; set; }
        public string TABLENAME { get; set; }
        public int BRANCHID { get; set; }
        public string FISCALYEAR { get; set; }
        public DateTime DATEFROM { get; set; }
        public DateTime DATETO { get; set; }
        public int STATUS { get; set; }
        public string AUID { get; set; }
        public DateTime ADT { get; set; }
        public string UUID { get; set; }
        public DateTime UDT { get; set; }
        public int islock { get; set; }

        clsAccLockDal objAccountLockDal = new clsAccLockDal();

        public int InsertAccountLock()
        {
            return objAccountLockDal.InsertAccountLock(this);
        }
    }
}