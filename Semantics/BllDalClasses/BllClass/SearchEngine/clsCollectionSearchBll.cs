using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensure.BllDalClasses.DalClass.Setup.SearchEngine;
using System.Data;

namespace Ensure.BllDalClasses.BllClass.SearchEngine
{
    public class clsCollectionSearchBll
    {
        public int BRANCHID { get; set; }
        public int FISCALID { get; set; }
        public DateTime COLLECTIONDTFROM { get; set; }
        public DateTime COLLECTIONDTTO { get; set; }
        public string BILLNO { get; set; }
        public string RECEIPTNO { get; set; }
        public int VATINVNO { get; set; }
        public Int64 PARTYNAMECODE { get; set; }
        public decimal CASHAMT1 { get; set; }
        public decimal CASHAMT2 { get; set; }
        public decimal CHQAMT1 { get; set; }
        public decimal CHQAMT2 { get; set; }
        public string CHQNO { get; set; }
        public string TRANSNO { get; set; }
        public int PG { get; set; }
        public int PGSIZE { get; set; }
        public string F_VATINVNO { get; set; }

        public int FAC_OPTIONS { get; set; }
        public int PAYTYPE { get; set; }

        public string SUBBRANCHCODE { get; set; }
        public int top { get; set; }
        public int orderby { get; set; }
        public int DEPTID { get; set; }
        public int CLASSID { get; set; }
        public int SUBBRANCHID { get; set; }
        public int USECANCELDATE { get; set; }
        public int SENTSTATUS { get; set; }
        public int MID { get; set; }
        public int LSUID { get; set; }
        public int DOCID { get; set; }
        public DataTable DTSYNC { get; set; }
        public DataTable dtSecBranch { get; set; }
        public DataTable dtSecSubBranch { get; set; }
        public int Sec_userid { get; set; }

        clsCollectionSearchDal objCol = new clsCollectionSearchDal();
        public DataSet SearchCollection()
        {
            return objCol.SearchCollection(this);
        }
        public DataSet SearchVatAnnex()
        {
            return objCol.SearchVatAnnex(this);
        }
        public DataTable SearchReSyncData()
        {
            return objCol.SearchReSyncData(this);
        }
    }
}