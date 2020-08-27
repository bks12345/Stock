using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.DalClass.Common;
using System.Data.SqlClient;
using System.Data;
using Stock.BllDalClasses.BllClass.Common;
using Stock.BllDalClasses.BllClass.User;

namespace Stock.BllDalClasses.DalClass.User
{
    public class ClsSecurityNameDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdateSecurityName(ClsSecurityNameBll objSecurityName)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[12];
                sqlparam[0] = new SqlParameter("@moduleID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objSecurityName.MODULEID);
                sqlparam[1] = new SqlParameter("@securityID", SqlDbType.Int);
                sqlparam[1].Value = NullHandler.Int32(objSecurityName.SECURITYID);
                sqlparam[2] = new SqlParameter("@security_Name", SqlDbType.VarChar);
                sqlparam[2].Value = NullHandler.String(objSecurityName.SECURITYNAME);
                sqlparam[3] = new SqlParameter("@isVisible", SqlDbType.TinyInt);
                sqlparam[3].Value = NullHandler.Int16(objSecurityName.ISVISIBLE);
                sqlparam[4] = new SqlParameter("@auid", SqlDbType.VarChar);
                sqlparam[4].Value = NullHandler.String(objSecurityName.AUID);
                sqlparam[5] = new SqlParameter("@adt", SqlDbType.DateTime);
                sqlparam[5].Value = NullHandler.DateTime(objSecurityName.ADT);
                sqlparam[6] = new SqlParameter("@uuid", SqlDbType.VarChar);
                sqlparam[6].Value = NullHandler.String(objSecurityName.UUID);
                sqlparam[7] = new SqlParameter("@udt", SqlDbType.DateTime);
                sqlparam[7].Value = NullHandler.DateTime(objSecurityName.UDT);
                sqlparam[8] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
                sqlparam[8].Direction = ParameterDirection.Output;
                sqlparam[9] = new SqlParameter("@SecuritySno", SqlDbType.Int);
                sqlparam[9].Value = NullHandler.Int32(objSecurityName.SecuritySno);
                sqlparam[10] = new SqlParameter("@BranchId", SqlDbType.Int);
                sqlparam[10].Value = NullHandler.Int32(ClsCommon.BranchId);
                sqlparam[11] = new SqlParameter("@islock",SqlDbType.Int);
                sqlparam[11].Value = NullHandler.Int32(objSecurityName.islock);
                objCmnDal.InsertUpdateTable("Security_securityName_insertUpdate", "sp", sqlparam);
                if (sqlparam[8].Value != DBNull.Value)
                    return sqlparam[8].Value.ToString();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetMaxSecuritySno(ClsSecurityNameBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ModuleId", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.MODULEID);

            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("security_get_SecuritySno", "sp", sqlparam);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["MaxSecuritySno"].ToString();
                }
                else return "0";
            }
            else return "0";
        }

        public DataSet Getsecurity(ClsSecurityNameBll objSecurityNameBll)
        {
             SqlParameter[] sqlparam = new SqlParameter[3];
             sqlparam[0] = new SqlParameter("@MODULEID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objSecurityNameBll.MODULEID);
            sqlparam[1] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objSecurityNameBll.BRANCHCODE);
            sqlparam[2] = new SqlParameter("@USERGROUPID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objSecurityNameBll.USERGROUPID);
            DataSet ds = new DataSet();
            ds = objCmnDal.GetTableSet("Security_grpWise_getSecurity", "sp", sqlparam);
            return ds;
        }
        
        public DataTable BindSecurityNameInListBox(ClsSecurityNameBll objSecurityName)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@moduleID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objSecurityName.MODULEID);
                return objCmnDal.GetTable("Security_get_SecurityName_bymoduleid", "sp", sqlparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetSecurityName(ClsSecurityNameBll objSecurityName)
        {
            try
            {
                SqlParameter[] sqlparam = new SqlParameter[1];
                sqlparam[0] = new SqlParameter("@securityID", SqlDbType.Int);
                sqlparam[0].Value = NullHandler.Int32(objSecurityName.SECURITYID);
                return objCmnDal.GetTable("Security_securityName_get", "sp", sqlparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet Getsecurityusewise(ClsSecurityNameBll objSecurityNameBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@MODULEID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objSecurityNameBll.MODULEID);
            sqlparam[1] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objSecurityNameBll.BRANCHCODE);
            sqlparam[2] = new SqlParameter("@UserId", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objSecurityNameBll.UserId);
            sqlparam[3] = new SqlParameter("@USERGROUPID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(objSecurityNameBll.USERGROUPID);
            DataSet ds = new DataSet();
            ds = objCmnDal.GetTableSet("Security_userWise_getSecurity", "sp", sqlparam);
              return ds;
            
        }

    }
}