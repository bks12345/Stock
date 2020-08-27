using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web;
using Stock.BllDalClasses.DalClass.User;

namespace Stock.BllDalClasses.BllClass.User
{
    public class UserGroupBll
    {
        #region TBL_USERGROUP
        public string BRANCHCODE { get; set; }
        public int GROUPID { get; set; }
        public string GROUPNAME { get; set; }
        public string GROUP_CODE { get; set; }
        public string AUID { get; set; }
        public DateTime ADT { get; set; }
        public string UUID { get; set; }
        public DateTime UDT { get; set; }
        public DataTable dtUsergrp { get; set; }
        public int BRANCHID { get; set; }
        public string SUBBRANCHCODE { get; set; }
        public int islock { get; set; }
        
        #endregion TBL_USERGROUP


        public string InsertUpdateUserGrp()
        {
             ClsGroupDal objgrpdal = new ClsGroupDal();
             return objgrpdal.InsertUpdateUserGrp(this);
        }

        public DataTable GetUserGroup()
        {
            ClsGroupDal objgrpdal = new ClsGroupDal();
            DataTable dt = new DataTable();
            dt = objgrpdal.GetUserGroup();
            return dt;
        }

        public DataTable GetUserGrpById()
        {
            ClsGroupDal grpdal = new ClsGroupDal();
            DataTable dt = new DataTable();
            dt = grpdal.GetUserGrpById(this);
            return dt;
        }
        public DataTable GetUserList()
        {
            ClsGroupDal grpdal = new ClsGroupDal();
            return grpdal.GetUserList(this);
        }

        //public int FxDeleteUserGrp()
        //{
        //    ClsGroupDal grpdal = new ClsGroupDal();
        //    return grpdal.FxDeleteUserGrp(this);

        //}
    }
}