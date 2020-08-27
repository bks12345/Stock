using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllDalClasses.DalClass.User;
using System.Data;
using System.Data.SqlClient;


namespace Stock.BllDalClasses.BllClass.User
{
    public class ClsModulelstBll
    {
        #region TBL_MODULELIST
        public int MODULEID { get; set; }
        public string MODULENAME { get; set; }
        public int MODULE_GROUP_ID { get; set; }
        public int ModuleNameSno { get; set; }

        public string AUID { get; set; }
        public DateTime ADT { get; set; }
        public string UUID { get; set; }
        public DateTime UDT { get; set; }
        public int islock { get; set; }
        #endregion TBL_MODULELIST

        ClsModulelstDal objModulelst = new ClsModulelstDal();

        public string GetMaxModuleNameSno()
        {
            return objModulelst.GetMaxModuleNameSno(this);
        }

        public DataTable GetModulelst()
        {
            ClsModulelstDal objModulelst = new ClsModulelstDal();
            DataTable dt = new DataTable();
            dt = objModulelst.GetModulelst(this);
            return dt;
        }

        public string InsertUpdateModuleList()
        {
            return objModulelst.InsertUpdateModuleList(this);
        }

        public DataTable GetModuleList()
        {
            return objModulelst.GetModuleList(this);
        }

        public DataTable GetModuleListByModuleGroupID()
        {
            return objModulelst.GetModuleListByModuleGroupID(this);
        }
        
    }
}