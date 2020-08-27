using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.DalClass.Common;
using System.Data;
using System.Data.SqlClient;
using Stock.BllDalClasses.BllClass.User;

namespace Stock.BllDalClasses.DalClass.User
{
    public class clsLogReportsDal
    {
        clsCommonDal objCmn = new clsCommonDal();
        public DataTable GetTableName()
        {
            SqlParameter[] sqlparam = new SqlParameter[0];
            return objCmn.GetTable("GetAllTableNames", "sp", sqlparam);
        }

        public DataTable GetColumnName(clsLogReportBll objReport)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@tableName", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objReport.TableName);
            return objCmn.GetTable("GetColumnsNameByTableName", "sp", sqlparam);
        }

        public DataTable GetColumnAndDataType(clsLogReportBll objReport)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@tableName", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(objReport.TableName);
            return objCmn.GetTable("GetColumnAndDatatype", "sp", sqlparam);
        }

        public bool CreateLogTable(clsLogReportBll objReport)
        {

            clsCommonDal objcmndal = new clsCommonDal();
            var commandStr = "If not exists (select name from sysobjects where name = '" + objReport.logTableName + "') CREATE TABLE " + objReport.logTableName
               + "(" + objReport.TotalColumn_forLogTable + ")";

            return objcmndal.InsertUpdateTable(commandStr, "txt", null);

        }

        public bool CreateTrigger(clsLogReportBll objReport)
        {

            if (objReport.mode == "Insert")
            {
                TriggerForInsert(objReport);
                //TriggerForInsertUpdateDelete(objReport);
            }
            else if (objReport.mode == "Delete")
            {
                TriggerForDelete(objReport);
            }
            else if (objReport.mode == "InsertDelete")
            {
                TriggerForInsert(objReport);
                TriggerForDelete(objReport);
            }
            else if (objReport.mode == "InsertDeleteUpdate")
            {
                TriggerForInsert(objReport);
                TriggerForDelete(objReport);
            }
            return true;
        }

        protected bool TriggerForInsert(clsLogReportBll objReport)
        {
            clsCommonDal objcmndal = new clsCommonDal();
            var trigger = "create TRIGGER trigger_Insert_" + objReport.maintableName + " on "
                      + objReport.maintableName + " For insert as Begin Insert into " + objReport.logTableName
                      + " (" + objReport.TotalColumn + ") select "
                      + objReport.selectedColumn + ", getDate(), HOST_NAME(), [dbo].[GetCurrentIP](),'admin','1'"
                      + " From Inserted end";
            return objcmndal.InsertUpdateTable(trigger, "txt", null);

        }
        protected bool TriggerForDelete(clsLogReportBll objReport)
        {
            clsCommonDal objcmndal = new clsCommonDal();
            var trigger = "create TRIGGER trigger_Delete_" + objReport.maintableName + " on "
                    + objReport.maintableName + " For Delete as Begin Insert into " + objReport.logTableName
                    + " (" + objReport.TotalColumn + ") select "
                    + objReport.selectedColumn + ", getDate(), HOST_NAME(), [dbo].[GetCurrentIP](),'admin','0'"
                    + " From Deleted end";
            return objcmndal.InsertUpdateTable(trigger, "txt", null);

        }
        protected bool TriggerForInsertUpdateDelete(clsLogReportBll objReport)//not in used
        {
            clsCommonDal objcmndal = new clsCommonDal();
            var trigger = "create TRIGGER trigger_" + objReport.maintableName + " on "
                + objReport.maintableName + " For Delete as Begin Insert into " + objReport.logTableName
                + " (" + objReport.TotalColumn + ") select "
                + objReport.selectedColumn + ", getDate(), HOST_NAME(), [dbo].[GetCurrentIP](),'admin','0'"
                + " From Inserted end";
            return objcmndal.InsertUpdateTable(trigger, "txt", null);
        }



    }

    public class clsLogReportSearchDal
    {
        clsCommonDal objCmn = new clsCommonDal();
        public DataTable GetLogReport(clsLogReportSearchBLL objReport)
        {
            string sqlFilter = string.Empty;
            string query = string.Empty;
            string data = string.Empty;
            if (objReport.BranchID != 0)
            {
                sqlFilter += "BranchID = '" + objReport.BranchID + "' , ";
            }
            if (objReport.DocumentNO != "" && objReport.DocumentNO != null)
            {
                sqlFilter += "DocumentNo = '" + objReport.DocumentNO + "' , ";
            }
            if (objReport.ClaimNo != "" && objReport.ClaimNo != null)
            {
                sqlFilter += "CLAIMNO = " + objReport.ClaimNo + " , ";
            }
            if (objReport.DateFrom != null && objReport.DateTo != null)
            {
                sqlFilter += "LOGDATE between " + "'" + objReport.DateFrom + "'" + " , " + "'" + objReport.DateTo + "'" + " , ";
            }
            if (objReport.VoucherID != 0)
            {
                sqlFilter += "VoucherID = " + objReport.VoucherID + " , ";
            }
            if (objReport.VoucherNo != 0)
            {
                sqlFilter += "VoucherNo = " + objReport.VoucherNo + " , ";
            }
            if (objReport.ExtraField != "" && objReport.ExtraFieldValue != "" && objReport.ExtraField!=null && objReport.ExtraFieldValue!=null)
            {
                sqlFilter += objReport.ExtraField + "=" + "'" + objReport.ExtraFieldValue + "'" + " , ";
            }
            //int count = sqlFilter.Length;
            query = sqlFilter.Substring(0, sqlFilter.Length - 2);
            //query = sqlFilter.TrimEnd(',');
            data = query.Replace(",", "and");
            var str = "select " + objReport.ColumnList + " from " + objReport.LogTableName + " where " + data;
            SqlParameter[] sqlparam = new SqlParameter[0];
            return objCmn.GetTable(str, "text", sqlparam);

        }
    }
}