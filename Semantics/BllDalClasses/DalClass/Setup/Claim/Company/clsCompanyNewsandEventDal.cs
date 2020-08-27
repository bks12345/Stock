using Stock.BllDalClasses.BllClass.Common;
using Stock.BllDalClasses.BllClass.Setup.Company;
using Stock.DalClass.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.DalClass.Setup.Company
{
    public class clsCompanyNewsandEventDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdateNewsAndEventsLog(clsCompanyNewsandEventBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[18];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ID);
            sqlparam[1] = new SqlParameter("@NEID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.NEID);
            sqlparam[2] = new SqlParameter("@TILE", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.TILE);
            sqlparam[3] = new SqlParameter("@DESCRIPTION", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.DESCRIPTION);
            sqlparam[4] = new SqlParameter("@ACTIVATIONSTARTDATE", SqlDbType.DateTime);
            sqlparam[4].Value = NullHandler.DateTime(obj.ACTIVATIONSTARTDATE);
            sqlparam[5] = new SqlParameter("@ACTIVATIONEXPIRYDATE", SqlDbType.DateTime);
            sqlparam[5].Value = NullHandler.DateTime(obj.ACTIVATIONEXPIRYDATE);
            sqlparam[6] = new SqlParameter("@USERGROUPID", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.USERGROUPID);
            sqlparam[7] = new SqlParameter("@AUID", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.AUID);
            sqlparam[8] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[8].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[9] = new SqlParameter("@UUID", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(obj.UUID);
            sqlparam[10] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[10].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[11] = new SqlParameter("@ISDELETE", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(obj.ISDELETE);
            sqlparam[12] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[12].Direction = ParameterDirection.Output;
            sqlparam[13] = new SqlParameter("@Activation", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(obj.ACTIVATION);
            sqlparam[14] = new SqlParameter("@BRACNHID", SqlDbType.Int);
            sqlparam[14].Value = NullHandler.Int32(obj.BRANCHID);
            sqlparam[15] = new SqlParameter("@SUBBRANCHID", SqlDbType.Int);
            sqlparam[15].Value = NullHandler.Int32(obj.SUBBRANCHID);
            sqlparam[16] = new SqlParameter("@USERID", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Int32(obj.USERID);
            sqlparam[17] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[17].Value = NullHandler.Int32(ClsCommon.BranchId);
            objCmnDal.InsertUpdateTable("uw_NewsAndEventsLog_Insert_Update", "sp", sqlparam);
            if (sqlparam[12].Value != DBNull.Value)
                return sqlparam[12].Value.ToString();
            else
                return null;
        }
        public DataTable GetNewsEventById(clsCompanyNewsandEventBll objBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objBll.ID);
            return objCmnDal.GetTable("uw_NewsAndEventsLog_GetById ", "sp", sqlparam);
        }
        public DataTable SearchNewsEvents(clsCompanyNewsandEventBll objBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@frmDate", SqlDbType.DateTime);
            sqlparam[0].Value = NullHandler.DateTime(objBll.DATEFROM);
            sqlparam[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
            sqlparam[1].Value = NullHandler.DateTime(objBll.DATETO);
            sqlparam[2] = new SqlParameter("@UDID", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objBll.AUID);
            sqlparam[3] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(ClsCommon.BranchId);
            return objCmnDal.GetTable("uw_Search_NewsAndEvents", "sp", sqlparam);
        }
        public DataTable GetNewsEventDetails(clsCompanyNewsandEventBll objBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objBll.ID);
            sqlparam[1] = new SqlParameter("@USERID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objBll.USERID);
            return objCmnDal.GetTable("uw_NewsAndEvents_GetAllDetails", "sp", sqlparam);
        }
        public DataTable GetNewsEventBy_UserID(clsCompanyNewsandEventBll objBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@UID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objBll.AUID);
            sqlparam[1] = new SqlParameter("@ActiveOnly", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objBll.ACTIVATION);
            sqlparam[2] = new SqlParameter("@ReadStatus", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objBll.READ_STATUS_ONLY);
            return objCmnDal.GetTable("uw_NewsAndEvents_GetMyNews", "sp", sqlparam);
        }
        public DataTable LoadNewsandEvent()
        {
            return objCmnDal.GetTable("uw_NewsAndEventsLog_Get", "sp", null);
        }
        public DataTable DeleteNewsEvent(clsCompanyNewsandEventBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ID);
            return objCmnDal.GetTable("uw_NewsAndEventsLog_Delete", "sp", sqlparam);
        }
        public string UpdateNewsAndEventsReadLog(clsCompanyNewsandEventBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[4];
            sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ID);

            sqlparam[1] = new SqlParameter("@ReadDate", SqlDbType.DateTime);
            sqlparam[1].Value = NullHandler.DateTime(obj.ACTIVATIONSTARTDATE);

            sqlparam[2] = new SqlParameter("@uid", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.UUID);
          
            sqlparam[3] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[3].Direction = ParameterDirection.Output;

            objCmnDal.InsertUpdateTable("uw_NewsAndEventsReadLog_Update", "sp", sqlparam);
            if (sqlparam[3].Value != DBNull.Value)
                return sqlparam[3].Value.ToString();
            else
                return null;
        }

    }
}