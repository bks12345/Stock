using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stock.DalClass.Common;
using System.Data.SqlClient;
using System.Data;
using Stock.BllDalClasses.BllClass.User;

namespace Stock.BllDalClasses.DalClass.User
{
    public class clsAccLockDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public int InsertAccountLock(clsAccLockBll objlockTable)
        {
            bool value;
            string createTrigger = string.Empty;
            string dropTrigger = string.Empty;
            try
            {
                var sqlString = "insert into " + objlockTable.TABLENAME + " (BRANCHID,DATEFROM,DATETO,FISCALYEAR,STATUS,AUID,ADT,UUID,UDT,islock) "
                    + "values(" + "'" + objlockTable.BRANCHID + "'," + "'" + objlockTable.DATEFROM + "'," + "'" + objlockTable.DATETO + "'," + "'" + objlockTable.FISCALYEAR + "',"
                    + "'" + objlockTable.STATUS + "'," + "'" + objlockTable.AUID + "'," + "'" + objlockTable.ADT + "'," + "'" + objlockTable.UUID + "'," + "'" + objlockTable.UDT + "'"+","+objlockTable.islock  + ")";
                value = objCmnDal.InsertUpdateTable(sqlString, "txt", null);

                if (objlockTable.MAINTABLENAME.ToLower() == "deposit")
                {
                    dropTrigger = "IF EXISTS (SELECT 1 FROM sys.objects WHERE name = 'trigger_"+ objlockTable.TABLENAME + "'"
                        + ") begin drop trigger trigger_" + objlockTable.TABLENAME + " end";
                    objCmnDal.InsertUpdateTable(dropTrigger, "txt", null);

                    createTrigger = "create trigger trigger_" + objlockTable.TABLENAME + " on " + objlockTable.MAINTABLENAME + " Instead of insert, update as "
                                        + "DECLARE @ACCSTATUS int ,@date date ,@branchId int begin set @date=(select CHQDATE from inserted ) "
                    + " set @branchId= (select branchid from inserted ) set @ACCSTATUS= dbo.fx_" + objlockTable.TABLENAME + "(@date,@branchId) "
                    + "If @ACCSTATUS = 1 begin RAISERROR('Data is locked!!!Please contact the administrator',10,1); end end";
                }
                else if (objlockTable.MAINTABLENAME.ToLower() == "docissue")
                {
                    createTrigger = "create trigger trigger_" + objlockTable.TABLENAME + " on " + objlockTable.MAINTABLENAME + " Instead of insert, update as "
                                       + "DECLARE @ACCSTATUS int ,@date date ,@branchId int begin set @date=(select DTPOLICYISS from inserted ) "
                   + " set @branchId= (select branchid from inserted ) set @ACCSTATUS= dbo.fx_" + objlockTable.TABLENAME + "(@date,@branchId) "
                   + "If @ACCSTATUS = 1 begin RAISERROR('Data is locked!!!Please contact the administrator',10,1); end end";
                }
                objCmnDal.InsertUpdateTable(createTrigger, "txt", null);
                if (value == true)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}