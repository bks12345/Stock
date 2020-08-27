using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Stock.DalClass.Common;
using Stock.BllDalClasses.BllClass.User;
using Stock.BllDalClasses.BllClass.Common;

namespace Stock.BllDalClasses.DalClass.User
{
    public class ClsUserDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string Createuser(ClsUserBll objUserBll)
        {
             SqlParameter[] sqlparam = new SqlParameter[40];
	         sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int );
	         sqlparam[0].Value = NullHandler.Int32 (objUserBll.ID);
	         sqlparam[1] = new SqlParameter("@USERID", SqlDbType.VarChar );
	         sqlparam[1].Value = NullHandler.String (objUserBll.USERID);
	         sqlparam[2] = new SqlParameter("@Emp_Id", SqlDbType.Int );
	         sqlparam[2].Value = NullHandler.Int32 (objUserBll.empid);
	         sqlparam[3] = new SqlParameter("@PASSWORD", SqlDbType.VarChar );
	         sqlparam[3].Value = NullHandler.String (objUserBll.PASSWORD);
	         sqlparam[4] = new SqlParameter("@VALIDFROM", SqlDbType.DateTime );
	         sqlparam[4].Value = NullHandler.DateTime (objUserBll.VALIDFROM);
	         sqlparam[5] = new SqlParameter("@VALIDTO", SqlDbType.DateTime );
	         sqlparam[5].Value = NullHandler.DateTime (objUserBll.VALIDTO);
	         sqlparam[6] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar );
	         sqlparam[6].Value = NullHandler.String (objUserBll.BRANCHCODE);
	         sqlparam[7] = new SqlParameter("@LOCKED", SqlDbType.Int);
	         sqlparam[7].Value = NullHandler.Int32(objUserBll.LOCKED);
	         sqlparam[8] = new SqlParameter("@ISDELETED", SqlDbType.Int);
	         sqlparam[8].Value = NullHandler.Int32(objUserBll.ISDELETED);
	         sqlparam[9] = new SqlParameter("@GROUPID", SqlDbType.Int );
	         sqlparam[9].Value = NullHandler.Int32 (objUserBll.GROUPID);
	         sqlparam[10] = new SqlParameter("@USER_CODE", SqlDbType.VarChar );
	         sqlparam[10].Value = NullHandler.String (objUserBll.USER_CODE);
	         sqlparam[11] = new SqlParameter("@LASTSAVEDBY", SqlDbType.VarChar );
	         sqlparam[11].Value = NullHandler.String (objUserBll.LASTSAVEDBY);
	         sqlparam[12] = new SqlParameter("@LASTSAVEDDATE", SqlDbType.DateTime );
	         sqlparam[12].Value = NullHandler.DateTime (objUserBll.LASTSAVEDDATE);
	         sqlparam[13] = new SqlParameter("@IPADDRESS", SqlDbType.VarChar );
	         sqlparam[13].Value = NullHandler.String (objUserBll.IPADDRESS);
	         sqlparam[14] = new SqlParameter("@ALLOT", SqlDbType.Decimal );
	         sqlparam[14].Value = NullHandler.Decimal (objUserBll.ALLOT);
	         sqlparam[15] = new SqlParameter("@LOGGED", SqlDbType.Bit );
	         sqlparam[15].Value = NullHandler.Boolean(objUserBll.LOGGED);
	         sqlparam[16] = new SqlParameter("@LOGGED_COMPUTER_NAME", SqlDbType.Decimal );
	         sqlparam[16].Value = NullHandler.Decimal (objUserBll.LOGGED_COMPUTER_NAME);
	         sqlparam[17] = new SqlParameter("@USERCODE", SqlDbType.VarChar );
	         sqlparam[17].Value = NullHandler.String (objUserBll.USERCODE);
	         sqlparam[18] = new SqlParameter("@VALIDUPTO", SqlDbType.DateTime );
	         sqlparam[18].Value = NullHandler.DateTime (objUserBll.VALIDUPTO);
	         sqlparam[19] = new SqlParameter("@AUID", SqlDbType.VarChar );
	         sqlparam[19].Value = NullHandler.String (objUserBll.AUID);
	         sqlparam[20] = new SqlParameter("@ADT", SqlDbType.DateTime );
	         sqlparam[20].Value = NullHandler.DateTime (objUserBll.ADT);
	         sqlparam[21] = new SqlParameter("@UUID", SqlDbType.VarChar );
	         sqlparam[21].Value = NullHandler.String (objUserBll.UUID);
	         sqlparam[22] = new SqlParameter("@UDT", SqlDbType.DateTime );
	         sqlparam[22].Value = NullHandler.DateTime (objUserBll.UDT);
	         sqlparam[23] = new SqlParameter("@msg", SqlDbType.VarChar,20);
	         sqlparam[23].Direction = ParameterDirection.Output;
             sqlparam[24] = new SqlParameter("@Restore", SqlDbType.Int);
             sqlparam[24].Value=NullHandler.Int32(objUserBll.restore);
             sqlparam[25] = new SqlParameter("@DesignationId", SqlDbType.Int);
             sqlparam[25].Value = NullHandler.Int32(objUserBll.DesignationId);
             sqlparam[26] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
             sqlparam[26].Value = NullHandler.String(objUserBll.username);
             sqlparam[27] = new SqlParameter("@BranchId", SqlDbType.Int);
             sqlparam[27].Value = NullHandler.Int32(objUserBll.BRANCHID);
             sqlparam[28] = new SqlParameter("@ISADMIN", SqlDbType.Int);
             sqlparam[28].Value = NullHandler.Int32(objUserBll.ISADMIN);
             sqlparam[29] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
             sqlparam[29].Value = NullHandler.Int32(objUserBll.SUBBRANCHID);
             sqlparam[30] = new SqlParameter("@ISACTIVATE", SqlDbType.Int);
             sqlparam[30].Value = NullHandler.Int32(objUserBll.ISACTIVATE);
             sqlparam[31] = new SqlParameter("@ISSUPERUSER", SqlDbType.Int);
             sqlparam[31].Value = NullHandler.Int32(objUserBll.ISSUPERUSER);
             sqlparam[32] = new SqlParameter("@DTAccessBranch", SqlDbType.Structured);
             sqlparam[32].Value = (objUserBll.dtBranch);
             sqlparam[33] = new SqlParameter("@ppwnotification", SqlDbType.Int);
             sqlparam[33].Value = NullHandler.Int32(objUserBll.ppwnotification);
             sqlparam[34] = new SqlParameter("@deadline_alert", SqlDbType.Int);
             sqlparam[34].Value = NullHandler.Int32(objUserBll.deadline_alert);
             sqlparam[35] = new SqlParameter("@isconnected_user", SqlDbType.Int);
             sqlparam[35].Value = NullHandler.Int32(objUserBll.isconnected_user);
            // added by sunil
             sqlparam[36] = new SqlParameter("@applyNewSecurity", SqlDbType.Int);
             sqlparam[36].Value = NullHandler.Int32(objUserBll.applyNewSecurity);

             sqlparam[37] = new SqlParameter("@FOCODE", SqlDbType.VarChar);
             sqlparam[37].Value = NullHandler.String(objUserBll.FO_CODE);

             sqlparam[38] = new SqlParameter("@IsCounterUser", SqlDbType.Int);
             sqlparam[38].Value = NullHandler.Int32(objUserBll.IsCounterUser);
             sqlparam[39] = new SqlParameter("@defaultloginpage", SqlDbType.Int);
             sqlparam[39].Value = NullHandler.Int32(objUserBll.defaultloginpage);
            
            // objCmnDal.InsertUpdateTable("User_user_insertUpdate", "sp", sqlparam);
             objCmnDal.InsertUpdateTable("Insert_User", "sp", sqlparam);
	         if (sqlparam[23].Value != DBNull.Value)
	         return sqlparam[23].Value.ToString();
	         else 
	         return null;

        }

        public DataTable  GetLogin(ClsUserBll objUserBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@USERID", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objUserBll.USERID);
            sqlparam[1] = new SqlParameter("@PASSWORD", objUserBll.PASSWORD);
            sqlparam[1].Value = NullHandler.String(objUserBll.PASSWORD);
            sqlparam[2] = new SqlParameter("@EMAIL", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(objUserBll.EMAIL);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("tbl_user_login", "sp", sqlparam);

            return dt; ;
        }

        public DataTable GetUserList(ClsUserBll objUserBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objUserBll.BRANCHCODE);
            sqlparam[1] = new SqlParameter("@GROUPID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objUserBll.GROUPID);
            sqlparam[2] = new SqlParameter("@LOCKED", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objUserBll.LOCKED);
            sqlparam[3] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objUserBll.SUBBRANCHID);
            sqlparam[4] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(objUserBll.BRANCHID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("User_UserList_get", "sp", sqlparam);
            return dt;
        }

        public DataTable GetUser(int Id)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(Id);         
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("User_user_get_byid", "sp", sqlparam);
            return dt;
        }

        public string updateUserPassword(ClsUserBll objUserBll)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[6];
                sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objUserBll.ID);
                sqlparam[1] = new SqlParameter("@PASSWORD", SqlDbType.VarChar);
                sqlparam[1].Value = NullHandler.String(objUserBll.PASSWORD);               
                sqlparam[2] = new SqlParameter("@UUID", SqlDbType.VarChar);
                sqlparam[2].Value = NullHandler.String(objUserBll.UUID);
                sqlparam[3] = new SqlParameter("@UDT", SqlDbType.DateTime);
                sqlparam[3].Value = NullHandler.DateTime(objUserBll.UDT);
                sqlparam[4] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
                sqlparam[4].Direction = ParameterDirection.Output;
                sqlparam[5] = new SqlParameter("@BranchId", SqlDbType.Int);
                sqlparam[5].Value = NullHandler.Int32(ClsCommon.BranchId);
                objCmnDal.InsertUpdateTable("user_changePassword", "sp", sqlparam);
                if (sqlparam[4].Value != DBNull.Value)
                    return sqlparam[4].Value.ToString();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetUserName(ClsUserBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ID);
            return objCmnDal.GetTable("controlPanel_userList_get", "sp", sqlparam);
        }

        public string CreateSession()
        {
            SqlParameter[] sqlparam = new SqlParameter[14];
            sqlparam[0] = new SqlParameter("@SESSIONID", SqlDbType.NVarChar);
            sqlparam[0].Value = NullHandler.String(System.Web.HttpContext.Current.Session.SessionID);
            sqlparam[1] = new SqlParameter("@BranchCode", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(ClsCommon.BranchCode);
            sqlparam[2] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[3] = new SqlParameter("@UserCode", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(ClsCommon.UserCode);
            sqlparam[4] = new SqlParameter("@UserName", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(ClsCommon.UserName);
            sqlparam[5] = new SqlParameter("@GroupCode", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(ClsCommon.GroupCode);
            sqlparam[6] = new SqlParameter("@IsAdmin", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(ClsCommon.IsAdmin?1:0);
            sqlparam[7] = new SqlParameter("@SUBBRANCHCODE", SqlDbType.VarChar);
            sqlparam[7].Value = NullHandler.String(ClsCommon.SubBranchCode);
            sqlparam[8] = new SqlParameter("@BranchName", SqlDbType.VarChar);
            sqlparam[8].Value = NullHandler.String(ClsCommon.BranchName);
            sqlparam[9] = new SqlParameter("@SubBranchName", SqlDbType.VarChar);
            sqlparam[9].Value = NullHandler.String(ClsCommon.SubBranchName);
            sqlparam[10] = new SqlParameter("@UWSessionId", SqlDbType.VarChar);
            sqlparam[10].Value = NullHandler.String(""/*ClsCommon.SessionId*/);
            sqlparam[11] = new SqlParameter("@WizTask", SqlDbType.VarChar);
            sqlparam[11].Value = NullHandler.String("");//ClsCommon.WizTask);
            sqlparam[12] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[12].Direction = ParameterDirection.Output;
            sqlparam[13] = new SqlParameter("@DOCID", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(0);//ClsCommon.DOCID);
            objCmnDal.InsertUpdateTable("SECURITY_SESSION_INSERT", "sp", sqlparam);
            if (sqlparam[12].Value != DBNull.Value)
                return sqlparam[12].Value.ToString();
            else
                return "";
        }

        public DataTable GetSession()
        {

            ClsUserBll objUser = new ClsUserBll();
            objUser.TraceTable("get");
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@SESSIONID", SqlDbType.NVarChar);
            sqlparam[0].Value = NullHandler.String(System.Web.HttpContext.Current.Session.SessionID);
            return objCmnDal.GetTable("SECURITY_SESSION_GET", "sp", sqlparam);

        }

        //public DataTable CheckSession()
        //{
        //    ClsUserBll objUser = new ClsUserBll();
        //    objUser.TraceTable("check");
        //    SqlParameter[] sqlparam = new SqlParameter[2];
        //    sqlparam[0] = new SqlParameter("@SESSIONID", SqlDbType.NVarChar);
        //    sqlparam[0].Value = NullHandler.String(System.Web.HttpContext.Current.Session.SessionID);
        //    sqlparam[1] = new SqlParameter("@UWSessionId", SqlDbType.VarChar);
        //    sqlparam[1].Value = NullHandler.String(ClsCommon.SessionId);
        //    DataTable dt = objCmnDal.GetTable("SECURITY_SESSION_CHECK", "sp", sqlparam);

        //    objUser.TraceTable("chkafter");
        //    return dt;
        //    //if (dt != null)
        //    //{
        //    //    if (dt.Rows.Count > 0)
        //    //    {
        //    //        return true;
        //    //    }
        //    //}
        //    //return false;
        //}

        public bool TraceTable(string step)
        {
            //SqlParameter[] sqlparam = new SqlParameter[5];
            //sqlparam[0] = new SqlParameter("@SESSIONID", SqlDbType.NVarChar);
            //sqlparam[0].Value = NullHandler.String(ClsCommon.SessionId);
            //sqlparam[1] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            //sqlparam[1].Value = NullHandler.Int32(ClsCommon.BranchId);
            //sqlparam[2] = new SqlParameter("@UserCode", SqlDbType.VarChar);
            //sqlparam[2].Value = NullHandler.String(ClsCommon.UserCode);
            //sqlparam[3] = new SqlParameter("@DOCID", SqlDbType.Int);
            //sqlparam[3].Value = NullHandler.Int32(ClsCommon.DOCID);
            //sqlparam[4] = new SqlParameter("@step", SqlDbType.VarChar);
            //sqlparam[4].Value = NullHandler.String(step);
            //return objCmnDal.InsertUpdateTable("tracetable_insert", "sp", sqlparam);
            return true;
        }

        public bool LockUser(ClsUserBll objUserBll)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@USERID", SqlDbType.VarChar);
                sqlparam[0].Value = NullHandler.String(objUserBll.USERID);
                return objCmnDal.InsertUpdateTable("lock_user", "sp", sqlparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable GetUserDetails(int Id)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(Id);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("User_Get_Email_Password", "sp", sqlparam);
            return dt;
        }

        public DataTable GetUserByEmpId(int EmpId, int userId)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@EMPID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(EmpId);
            sqlparam[1] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(userId);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("User_user_get_byEmpId", "sp", sqlparam);
            return dt;
        }

        public bool UpdateUserIsActivate(ClsUserBll objUserBll)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@EMPID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objUserBll.EMPID);
                sqlparam[1] = new SqlParameter("@FLAG", SqlDbType.Int);
                sqlparam[1].Value = NullHandler.Int32(objUserBll.FLAG);
                return objCmnDal.InsertUpdateTable("User_UpdateIsActivate", "sp", sqlparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool UpdateUserActivationCode(ClsUserBll objUserBll)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[2];
                sqlparam[0] = new SqlParameter("@EMPID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objUserBll.EMPID);
                sqlparam[1] = new SqlParameter("@ACTIVATIONCODE", SqlDbType.VarChar);
                sqlparam[1].Value = NullHandler.String(objUserBll.ACTIVATIONCODE);
                return objCmnDal.InsertUpdateTable("User_ActivationCode_Update", "sp", sqlparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable getPassHistory(ClsUserBll objUserBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@USERID", SqlDbType.VarChar);
            sqlparam[0].Value=NullHandler.String(ClsCommon.UserCode);
            return objCmnDal.GetTable("getUserPassHistory","sp",sqlparam);
        }
        internal DataTable GetSBranch(ClsUserBll clsBranchBll)
        {


            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("GET_ALL_BRANCH", "sp", null);
            return dt;
        }
        public DataSet GetChkBranchAccess(ClsUserBll objSecurityNameBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@userid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objSecurityNameBll.ID);
          
            DataSet ds = new DataSet();
            ds = objCmnDal.GetTableSet("GET_CHKLIST", "sp", sqlparam);
            return ds;

        }
        public string chkip(ClsUserBll objSecurityNameBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@IP_ADDR", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objSecurityNameBll.IP_ADDR);
            sqlparam[1] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[1].Direction = ParameterDirection.Output;
            objCmnDal.InsertUpdateTable("compare_ipaddress", "sp", sqlparam);

            if (sqlparam[1].Value != DBNull.Value)
                return sqlparam[1].Value.ToString();
            else
                return "";
        }
        public DataTable GetUser_ForPWextend(ClsUserBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objbll.ID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("get_user_extendpw", "sp", sqlparam);
            return dt;
        }
        public string ExtendUserPassword(ClsUserBll objUserBll)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[6];
                sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objUserBll.ID);
                sqlparam[1] = new SqlParameter("@expirydate", SqlDbType.DateTime);
                sqlparam[1].Value = NullHandler.DateTime(objUserBll.ExpiryDate);
                sqlparam[2] = new SqlParameter("@remarks", SqlDbType.VarChar);
                sqlparam[2].Value = NullHandler.String(objUserBll.Remarks);
                //sqlparam[3] = new SqlParameter("@UDT", SqlDbType.DateTime);
                //sqlparam[3].Value = NullHandler.DateTime(objUserBll.UDT);
                sqlparam[3] = new SqlParameter("@auid", SqlDbType.VarChar);
                sqlparam[3].Value = NullHandler.String(objUserBll.AUID);
                sqlparam[4] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
                sqlparam[4].Direction = ParameterDirection.Output;
                sqlparam[5] = new SqlParameter("@BranchId", SqlDbType.Int);
                sqlparam[5].Value = NullHandler.Int32(ClsCommon.BranchId);
                objCmnDal.InsertUpdateTable("insert_passwordextend_date", "sp", sqlparam);
                if (sqlparam[4].Value != DBNull.Value)
                    return sqlparam[4].Value.ToString();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UnlockUser(ClsUserBll objUserBll)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[3];
                sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objUserBll.ID);
                sqlparam[1] = new SqlParameter("@uuid", SqlDbType.VarChar);
                sqlparam[1].Value = NullHandler.String(objUserBll.UUID);
                sqlparam[2] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
                sqlparam[2].Direction = ParameterDirection.Output;
                //sqlparam[5] = new SqlParameter("@BranchId", SqlDbType.Int);
                //sqlparam[5].Value = NullHandler.Int32(ClsCommon.BranchId);
                objCmnDal.InsertUpdateTable("sp_unlock_user", "sp", sqlparam);
                if (sqlparam[2].Value != DBNull.Value)
                    return sqlparam[2].Value.ToString();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}