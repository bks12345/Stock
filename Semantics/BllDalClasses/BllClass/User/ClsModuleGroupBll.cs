using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.BllDalClasses.DalClass.User;
using System.Data;

namespace Stock.BllDalClasses.BllClass.User
{
    public class ClsModuleGroupBll
    {
        public int Module_Group_ID { get; set; }
        public string Module_Group_Name { get; set; }

        public string AUID { get; set; }
        public DateTime ADT { get; set; }
        public string UUID { get; set; }
        public DateTime UDT { get; set; }
        public int islock { get; set; }
        ClsModuleGroupDal objModuleGroup = new ClsModuleGroupDal();

        public string InsertUpdateModuleGroup()
        {
            return objModuleGroup.InsertUpdateModuleGroup(this);
        }

        public DataTable GetModuleGroup()
        {
            return objModuleGroup.GetModuleGroup(this);
        }
    }
}