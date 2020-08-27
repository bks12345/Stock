using Stock.BllDalClasses.DalClass.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.Purchase
{
    public class ClsPurchaseBll
    {
        public int VEN_ID { get; set; }
        public string EDESCRIPTION { get; set; }
        public int PurchaseID { get; set; }
        public int Fiscalid { get; set; }
        public int branchid { get; set; }
        public DateTime pdate { get; set; }
        public int vendorid { get; set; }
        //public int billno { get; set; }
        public string billno { get; set; }
        public decimal pAmount { get; set; }
        public decimal pdiscAmt { get; set; }
        public decimal pdiscRate { get; set; }
        public decimal pVatAmt { get; set; }
        public decimal pVatRate { get; set; }
        public decimal pNetAmt { get; set; }
        public decimal pTdsRate { get; set; }
        public decimal pTdsAmt { get; set; }
        public string ptdsGLcode { get; set; }
        public int vatoptionid { get; set; }
        public int pTypeid { get; set; }
        public int Transactionno { get; set; }
        public int subbranchid { get; set; }
        public string ndate { get; set; }
        public string Remarks { get; set; }
        public DataTable dtpurchaseentrydetails { get; set; }
        public int uuid { get; set; }
        public int detailid { get; set; }

        public int BankID { get; set; }
        public string CheqNo { get; set; }
        public DateTime CheqDate { get; set; }
        public decimal CheqAmt { get; set; }
        public decimal HisabMilanAmt { get; set; }
        public int HisabMilanCode { get; set; }
        public int BillType { get; set; }
        public string BillDateNep { get; set; }
        public DateTime BillDate { get; set; }

        public string partyname { get; set; }

        ClsPurchaseDal objdal = new ClsPurchaseDal();
        public DataTable GetPurchaseItem()
        {
            return objdal.GetPurchaseItem(this);
        }
        public DataTable GetPurchaseDetails()
        {
            return objdal.GetPurchaseDetails(this);
        }
        public string InsertUpdate_PurchaseEntry()
        {
            return objdal.InsertUpdate_PurchaseEntry(this);
        }
        public DataSet GetAllPurchasedetails()
        {
            return objdal.GetAllPurchasedetails(this);
        }
        public DataTable GetVendorDetails()
        {
            return objdal.GetVendordetails(this);
        }
    }
}