using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.DalClass.Common;
using System.Data;
using System.Data.SqlClient;
using Stock.BllDalClasses.BllClass.Common;
using Stock.BllDalClasses.BllClass.Setup;

namespace Stock.BllDalClasses.DalClass.Setup
{
    public class ClsProductDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdateSurveyorType(ClsProductBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[10];
            sqlparam[0] = new SqlParameter("@SURVTYPECODE", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.SURVTYPECODE);
            sqlparam[1] = new SqlParameter("@EDESCRIPTION", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.EDESCRIPTION);
            sqlparam[2] = new SqlParameter("@NDESCRIPTION", SqlDbType.NVarChar);
            sqlparam[2].Value = NullHandler.String(obj.NDESCRIPTION);
            sqlparam[3] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.AUID);
            sqlparam[4] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[4].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[5] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(obj.UUID);
            sqlparam[6] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[6].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[7] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[7].Direction = ParameterDirection.Output;
            sqlparam[8] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[9] = new SqlParameter("@islock", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(obj.islock);
            objCmnDal.InsertUpdateTable("def_product_insertUpdate", "sp", sqlparam);
            if (sqlparam[7].Value != DBNull.Value)
                return sqlparam[7].Value.ToString();
            else
                return null;
        }

        public DataTable GetSurveyorType(ClsProductBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@SURVTYPECODE", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.SURVTYPECODE);
            return objCmnDal.GetTable("[def_product_get]", "sp", sqlparam);
        }
        public string InsertUpdateSurveyrType(ClsProductBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[10];

            sqlparam[0] = new SqlParameter("@EDESCRIPTION", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(obj.EDESCRIPTION);
            sqlparam[1] = new SqlParameter("@NDESCRIPTION", SqlDbType.NVarChar);
            sqlparam[1].Value = NullHandler.String(obj.NDESCRIPTION);
            sqlparam[2] = new SqlParameter("@msg", SqlDbType.VarChar, 40);
            sqlparam[2].Direction = ParameterDirection.Output;
            sqlparam[3] = new SqlParameter("@SURVEYORID", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.SURVEYORID);
            sqlparam[4] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(obj.AUID);
            sqlparam[5] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[5].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[6] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(obj.UUID);
            sqlparam[7] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[7].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[8] = new SqlParameter("@islock", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(obj.islock);
            sqlparam[9] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(ClsCommon.BranchId);
            objCmnDal.InsertUpdateTable("clm_surveyrType_insertUpdate", "sp", sqlparam);
            if (sqlparam[2].Value != DBNull.Value)
                return sqlparam[2].Value.ToString();
            else
                return null;
        }
        public DataTable GetSurveyrType(ClsProductBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@SURVEYORID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.SURVEYORID);
            return objCmnDal.GetTable("clm_SurveyrType_get", "sp", sqlparam);
        }
    }
}