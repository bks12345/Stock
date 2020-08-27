using Ensure.BllDalClasses.DalClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class ClsAccountMappingBll
    {
        public int ACCOUNTCODE { get; set; }
        public int CATIID { get; set; }
        public int SourceAcc { get; set; }
        public int Desti_Acc { get; set; }
        public string UUID { set; get; }
        public int branchid { get; set; }
        public int userId { get; set; }
        public int branch { get; set; }
        public string UpdateAccountMapping()
        {
            ClsAccountMappingDal objdal = new ClsAccountMappingDal();
            return objdal.UpdateAccountMapping(this);
        }
        public string MergeAccountHead()
        {
            ClsAccountMappingDal objdal = new ClsAccountMappingDal();
            return objdal.MergeAccountHead(this);
        }
        public string MergeTransaction()
        {
            ClsAccountMappingDal objdal = new ClsAccountMappingDal();
            return objdal.MergeTransacton(this);
        }

        public DataSet gettransactionMerge()
        {
            ClsAccountMappingDal objdal = new ClsAccountMappingDal();          
            return objdal.gettransactionMerge(this);
 
        }
    }
}