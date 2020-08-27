using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Ensure.BllDalClasses.DalClass.Setup.SearchEngine;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
     
    public class ClsSuminsuredApproveBll
    {
        public int ID { get; set; }
        public int DOCID { get; set; }
        public string DocumentNo { get; set; }
        public DateTime APPDATE { get; set; }
        public string APPTIME { get; set; }
        public int APPBY { get; set; }
        public int APPROVED { get; set; }
        public int Branchid { get; set; }
        public int AUID { get; set; }
        public DateTime ADT { get; set; }
        public int UUID { get; set; }
        public DateTime UDT { get; set; }
        public string Remarks { get; set; }
        public int APPROVESTATUS { get; set; }
        public DateTime APPROVEDATE { get; set; }
        public int LSUID { get; set; }
        public DateTime LSUDT { get; set; }

        internal string InsertUpdateSuminsured()
        {
            ClsSuminsuredApproveDal obj = new ClsSuminsuredApproveDal();
            return obj.InsertUpdateSuminsured(this);
           
        }
        internal string InsertUpdateDebitAdviceSuminsured()
        {
            ClsSuminsuredApproveDal obj = new ClsSuminsuredApproveDal();
            return obj.InsertUpdateDebitAdviceSuminsured(this);

        }
    }
}