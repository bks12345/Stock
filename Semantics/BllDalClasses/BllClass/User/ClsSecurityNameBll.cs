using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllDalClasses.DalClass.User;
using System.Data;


namespace Stock.BllDalClasses.BllClass.User
{
    public class ClsSecurityNameBll
    {
        #region TBL_SECURITYNAME
        public int MODULEID { get; set; }
        public int SECURITYID { get; set; }
        public string BRANCHCODE { get; set; }
        public int USERGROUPID { get; set; } 
        public string SECURITYNAME { get; set; }
        public Int16 ISVISIBLE { get; set; }
        public string AUID { get; set; }
        public DateTime ADT { get; set; }
        public string UUID { get; set; }
        public DateTime UDT { get; set; }
        public int UserId { get; set; }
        public int SecuritySno { get; set; }
        public int islock { get; set; }
        #endregion TBL_SECURITYNAME


        ClsSecurityNameDal objsecurityName = new ClsSecurityNameDal();


        public string GetMaxSecuritySno()
        {
            return objsecurityName.GetMaxSecuritySno(this);
        }

        public DataSet Getsecurity()
        {
            ClsSecurityNameDal objsecuritydal = new ClsSecurityNameDal();
            DataSet ds = new DataSet();
            ds = objsecuritydal.Getsecurity(this);
            return ds;
        }

        public string InsertUpdateSecurityName()
        {
            return objsecurityName.InsertUpdateSecurityName(this);
        }

        public DataTable BindSecurityNameInListBox()
        {
            return objsecurityName.BindSecurityNameInListBox(this);
        }

        public DataTable GetSecurityName()
        {
            return objsecurityName.GetSecurityName(this);
        }

        public DataSet Getsecurityuserwise(ClsSecurityNameBll objsecuritybll)
        {
            ClsSecurityNameDal objsecuritydal = new ClsSecurityNameDal();
            DataSet ds = new DataSet();
            ds = objsecuritydal.Getsecurityusewise(this);
            return ds;

        }

    }
}