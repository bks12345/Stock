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
    public class ClsDesignationDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public string InsertUpdateDesignation(ClsDesignationBll objDesignationBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[8];
            sqlparam[0]= new SqlParameter("@ID",SqlDbType.Int);
            sqlparam[0].Value=NullHandler.Int32(objDesignationBll.ID);
            sqlparam[1] = new SqlParameter("@Designation", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(objDesignationBll.Designation);
            sqlparam[2] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[2].Direction = ParameterDirection.Output;
            sqlparam[3] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[4] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(objDesignationBll.AUID);
            sqlparam[5] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(objDesignationBll.UUID);
            sqlparam[6] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[6].Value = NullHandler.DateTime(objDesignationBll.UDT);
            sqlparam[7] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[7].Value = NullHandler.DateTime(objDesignationBll.ADT);
            objCmnDal.InsertUpdateTable("User_Designation_insertupdate", "sp", sqlparam);
            if (sqlparam[2].Value != DBNull.Value)
                return sqlparam[2].Value.ToString();
            else
                return null;            
        }

        public DataTable getdesignation(ClsDesignationBll clsDesignationBll)
        {
            DataTable dt = new DataTable();
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsDesignationBll.ID);
            dt = objCmnDal.GetTable("User_Designation_get", "sp", sqlparam);
            return dt;
        }

        public int delete_designation(ClsDesignationBll clsDesignationBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(clsDesignationBll.ID);
            return ClsConvertTo.Int32(objCmnDal.InsertUpdateTable("User_Designation_delete", "sp", sqlparam));
        }
    }
}