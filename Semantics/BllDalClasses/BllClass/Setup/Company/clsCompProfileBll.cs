using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.DalClass.Setup.Company;
using System.Data;
using System.Text;
using Stock.BllDalClasses.BllClass.Common;

namespace Stock.BllClass.Setup.Company
{
    public class clsCompProfileBll
    {
        #region properties
        public int ID { get; set; }
        public string FontFamily { get; set; }
        public string CompanyNameEng { get; set; }
        public string CompanyNameNep { get; set; }
        public string AddressEng { get; set; }
        public string AddressNep { get; set; }
        public string VatReg { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Website { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public string ImgPath { get; set; }
        public int SystemType { get; set; }
        public int En_SumInsured { get; set; }//sanjay added

        //added by subarna
        public Int16 BankDeposit_Option { get; set; }
        public Int16 VatGen_Option { get; set; }
        public string CompanyPrefix { get; set; }
        public string CompanyRegNo { get; set; }

        //public StringBuilder tblName { get; set; }
        //public StringBuilder Display { get; set; }



        #endregion

        clsCompProfileDal objCompProfile = new clsCompProfileDal();
        public string InsertUpdateCompProfile()
        {
            return objCompProfile.InsertUpdateCompProfile(this);
        }

        public DataTable GetCompanyProfile()
        {
            return objCompProfile.GetCompanyProfile(this);
        }

        public int GetCompanySystemType()
        {
            DataTable dt = objCompProfile.GetCompanyProfile(this);
            if (dt.Rows.Count > 0)
            {
                return ClsConvertTo.Int32(dt.Rows[0]["SystemType"]);
            }
            return 0;
        }

   

    }
}