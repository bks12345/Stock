using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Stock.DalClass.Common;
using Stock.BllDalClasses.BllClass.Common;
using Stock.BllDalClasses.BllClass.User;
namespace Stock.BllDalClasses.DalClass.User
{
    public class ClsGroupDal
    {

        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdateUserGrp(UserGroupBll objGroupBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[11];
            sqlparam[0] = new SqlParameter("@GROUP_CODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objGroupBll.GROUP_CODE);
            sqlparam[1] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objGroupBll.AUID);
            sqlparam[2] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[2].Value = NullHandler.DateTime(objGroupBll.ADT);
            sqlparam[3] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(objGroupBll.UUID);
            sqlparam[4] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[4].Value = NullHandler.DateTime(objGroupBll.UDT);
            sqlparam[5] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[5].Direction = ParameterDirection.Output;
            sqlparam[6] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar, 20);
            sqlparam[6].Value = NullHandler.String(objGroupBll.BRANCHCODE);
            sqlparam[7] = new SqlParameter("@GROUPNAME", SqlDbType.VarChar);
            sqlparam[7].Value = NullHandler.String(objGroupBll.GROUPNAME);
            sqlparam[8] = new SqlParameter("@GROUPID", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(objGroupBll.GROUPID);
            sqlparam[9] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[10] = new SqlParameter("@islock",SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(objGroupBll.islock);
            string _errMsg = "";
            objCmnDal.InsertUpdateTable("User_usergroup_insertupdate", "sp", sqlparam, ref _errMsg);
            if (sqlparam[5].Value != DBNull.Value)
                if (_errMsg.Length > 2)
                {
                    return _errMsg;
                }
                else
                {
                    return sqlparam[5].Value.ToString();
                }
            else
                return null;
        }

        public DataTable GetUserGroup()
        {
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("User_usergroup_get", "sp", null);
            return dt;
        }

        public DataTable GetUserGrpById(UserGroupBll objuserGroupBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@GROUPID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objuserGroupBll.GROUPID);
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("User_UserGroup_get_byid", "sp", sqlparam);
            return dt;
        }
        public DataTable GetUserList(UserGroupBll objuserGroupBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@GROUPID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objuserGroupBll.GROUPID);
            sqlparam[1] = new SqlParameter("@SUBBRANCHID", SqlDbType.VarChar, 20);
            sqlparam[1].Value = NullHandler.String(objuserGroupBll.SUBBRANCHCODE);
            sqlparam[2] = new SqlParameter("@BRANCHID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objuserGroupBll.BRANCHID);

            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("get_user_list", "sp", sqlparam);
            return dt;
        }

        //public int FxDeleteUserGrp(UserGroupBll objGroupBll)
        //{
        //    SqlParameter[] sqlparam = new SqlParameter[1];
        //    sqlparam[0] = new SqlParameter("@GROUPID", SqlDbType.Int);
        //    sqlparam[0].Value = NullHandler.Int32(objGroupBll.GROUPID);
        //    int result = ClsConvertTo.Int32(objCmnDal.DeleteTable("User_userGroup_Delete_byid", "sp", sqlparam));
        //    return result;
            
        //}
    }
}