using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using Stock.DalClass.Common;

namespace Stock.BllDalClasses.DalClass.User
{
    public class ClsModulehitDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        internal string insertupdateHItcount(BllClass.Common.ClsModulehitcnt clsModulehitcnt)
        {
           SqlParameter[] sqlparam = new  SqlParameter[15];
            sqlparam[0]= new SqlParameter("@BRANCHId",SqlDbType.Int);
            sqlparam[0].Value=DBNullHandler.Int32(clsModulehitcnt.BRANCHId);
            sqlparam[1] = new SqlParameter("@LOGINID", SqlDbType.Int);
            sqlparam[1].Value = DBNullHandler.Int32(clsModulehitcnt.LOGINID);
            sqlparam[2] = new SqlParameter("@COMP_IP", SqlDbType.VarChar);
            sqlparam[2].Value = DBNullHandler.String(clsModulehitcnt.COMP_IP);
            //sqlparam[3] = new SqlParameter("@USERID", SqlDbType.VarChar);
            //sqlparam[3].Value = DBNullHandler.String(clsModulehitcnt.USERID);
            sqlparam[3] = new SqlParameter("@USERID", SqlDbType.Int);//sanjay changes
            sqlparam[3].Value = DBNullHandler.Int32(clsModulehitcnt.USERID);//sanjay changes
            sqlparam[4] = new SqlParameter("@COMP_NAME", SqlDbType.VarChar);
            sqlparam[4].Value = DBNullHandler.String(clsModulehitcnt.COMP_NAME);
            sqlparam[5] = new SqlParameter("@COMP_USER", SqlDbType.VarChar);
            sqlparam[5].Value = DBNullHandler.String(clsModulehitcnt.COMP_USER);
            sqlparam[6] = new SqlParameter("@HIT_DATE", SqlDbType.DateTime);
            sqlparam[6].Value = DBNullHandler.DateTime(clsModulehitcnt.HIT_DATE);
            sqlparam[7] = new SqlParameter("@HIT_TIME", SqlDbType.VarChar);
            sqlparam[7].Value = DBNullHandler.String(clsModulehitcnt.HIT_TIME);
            sqlparam[8] = new SqlParameter("@ADDCNT", SqlDbType.Int);
            sqlparam[8].Value = DBNullHandler.Int32(clsModulehitcnt.ADDCNT);
            sqlparam[9] = new SqlParameter("@EDITCNT", SqlDbType.Int);
            sqlparam[9].Value = DBNullHandler.Int32(clsModulehitcnt.EDITCNT);

            sqlparam[13] = new SqlParameter("@DELCNT", SqlDbType.Int);
            sqlparam[13].Value = DBNullHandler.Int32(clsModulehitcnt.DELCNT);
            sqlparam[10] = new SqlParameter("@VIEWCNT", SqlDbType.Int);
            sqlparam[10].Value = DBNullHandler.Int32(clsModulehitcnt.VIEWCNT);
            sqlparam[11] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[11].Direction = ParameterDirection.Output;
            sqlparam[12] = new SqlParameter("@MODULENAME", SqlDbType.VarChar);
            sqlparam[12].Value = DBNullHandler.String(clsModulehitcnt.MODULENAME);
            sqlparam[14] = new SqlParameter("@MODULEID", SqlDbType.Int);
            sqlparam[14].Value = DBNullHandler.Int32(clsModulehitcnt.MODULEID);
            objCmnDal.InsertUpdateTable("User_ModuleHitcounter_insertUpdate", "sp", sqlparam);
            if (sqlparam[11].Value != DBNull.Value)
                return sqlparam[11].Value.ToString();
            else
                return null;
            
            
            
        }

        //sanjay changes
        public DataTable GetModuleHitReport(BllClass.Common.ClsModulehitcnt clsModulehitcnt)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@datefrom", SqlDbType.DateTime);
            sqlparam[0].Value = DBNullHandler.DateTime(clsModulehitcnt.datefrom);
            sqlparam[1] = new SqlParameter("@dateto", SqlDbType.DateTime);
            sqlparam[1].Value = DBNullHandler.DateTime(clsModulehitcnt.dateto);
            sqlparam[2] = new SqlParameter("@userId", SqlDbType.VarChar);
            sqlparam[2].Value = DBNullHandler.String(clsModulehitcnt.USERID);
            sqlparam[3] = new SqlParameter("@mode", SqlDbType.VarChar);
            sqlparam[3].Value = DBNullHandler.String(clsModulehitcnt.mode);
            sqlparam[4] = new SqlParameter("@moduleid", SqlDbType.Int);
            sqlparam[4].Value = DBNullHandler.Int32(clsModulehitcnt.MODULEID);
            return objCmnDal.GetTable("historyReportViewer_get", "sp", sqlparam);
        }
        //--
    }
}