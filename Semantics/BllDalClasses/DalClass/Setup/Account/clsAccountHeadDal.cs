using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Ensure.DalClass.Common;
using Ensure.BllDalClasses.BllClass.Setup.Account;
using Ensure.BllDalClasses.BllClass.Common;

namespace Ensure.BllDalClasses.DalClass.Setup.Account
{
    public class clsAccountHeadDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdateAC_AccountHead(clsAccountHeadBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[30];
            sqlparam[0] = new SqlParameter("@ACCOUNTCODE", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ACCOUNTCODE);
            sqlparam[1] = new SqlParameter("@ACCOUNTDESC", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.ACCOUNTDESC);
            sqlparam[2] = new SqlParameter("@ACCOUNTDESCN", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.ACCOUNTDESCN);
            sqlparam[3] = new SqlParameter("@ACCOUNTTYPE", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.ACCOUNTTYPE);
            sqlparam[4] = new SqlParameter("@AGENTCODE", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(obj.AGENTCODE);
            sqlparam[5] = new SqlParameter("@ATYPE", SqlDbType.Decimal);
            sqlparam[5].Value = NullHandler.Decimal(obj.ATYPE);
            sqlparam[6] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[6].Value = NullHandler.String(obj.BRANCHCODE);
            sqlparam[7] = new SqlParameter("@CATID", SqlDbType.Decimal);
            sqlparam[7].Value = NullHandler.Decimal(obj.CATID);
            sqlparam[8] = new SqlParameter("@CLASSID", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(obj.CLASSID);
            sqlparam[9] = new SqlParameter("@CURRENCYACCOUNT", SqlDbType.VarChar);
            sqlparam[9].Value = NullHandler.String(obj.CURRENCYACCOUNT);
            sqlparam[10] = new SqlParameter("@DEPTID", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(obj.DEPTID);            
            sqlparam[11] = new SqlParameter("@PLCATEGORY", SqlDbType.VarChar);
            sqlparam[11].Value = NullHandler.String(obj.PLCATEGORY);
            sqlparam[12] = new SqlParameter("@TYPE", SqlDbType.Decimal);
            sqlparam[12].Value = NullHandler.Decimal(obj.TYPE);
            sqlparam[13] = new SqlParameter("@DEPTCODE", SqlDbType.VarChar);
            sqlparam[13].Value = NullHandler.String(obj.DEPTCODE);
            sqlparam[14] = new SqlParameter("@GLCODE", SqlDbType.VarChar);
            sqlparam[14].Value = NullHandler.String(obj.GLCODE);
            sqlparam[15] = new SqlParameter("@SLCODE", SqlDbType.VarChar);
            sqlparam[15].Value = NullHandler.String(obj.SLCODE);           
            sqlparam[16] = new SqlParameter("@TBGROUP", SqlDbType.VarChar);
            sqlparam[16].Value = NullHandler.String(obj.TBGROUP);
            sqlparam[17] = new SqlParameter("@TBPART", SqlDbType.VarChar);
            sqlparam[17].Value = NullHandler.String(obj.TBPART);
            sqlparam[18] = new SqlParameter("@TBSUBGROUP", SqlDbType.VarChar);
            sqlparam[18].Value = NullHandler.String(obj.TBSUBGROUP);           
            sqlparam[19] = new SqlParameter("@AUID", SqlDbType.VarChar);
            sqlparam[19].Value = NullHandler.String(obj.AUID);
            sqlparam[20] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[20].Value = NullHandler.String(obj.UUID);
            sqlparam[21] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[21].Direction = ParameterDirection.Output;
            sqlparam[22] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[22].Value = NullHandler.Int32(obj.BRANCHID);
            sqlparam[23] = new SqlParameter("@surveyorid", SqlDbType.Int);

                
            if (obj.SURVEYORID > 0)
            {
                sqlparam[23].Value = NullHandler.Int32(obj.SURVEYORID);
            }
            sqlparam[24] = new SqlParameter("@ISBANK", SqlDbType.Int);
            sqlparam[24].Value = NullHandler.Decimal(obj.ISBANK);

            sqlparam[25] = new SqlParameter("@balance_typeid", SqlDbType.Int);
            sqlparam[25].Value = NullHandler.Decimal(obj.minimunblncid);
            sqlparam[26] = new SqlParameter("@bankaccno", SqlDbType.VarChar);
            sqlparam[26].Value = NullHandler.String(obj.BankAccountNo);
            sqlparam[27] = new SqlParameter("@minimunbalance", SqlDbType.Decimal);
            sqlparam[27].Value = NullHandler.Decimal(obj.minimimblnc);
            sqlparam[28] = new SqlParameter("@IsVatOnSales", SqlDbType.Int);
            sqlparam[28].Value = NullHandler.Decimal(obj.ISVATONSALES);
            sqlparam[29] = new SqlParameter("@RICompanyID", SqlDbType.Int);
            sqlparam[29].Value = NullHandler.Decimal(obj.RICOMPANYID);

            objCmnDal.InsertUpdateTable("acc_accHead_insertUpdate", "sp", sqlparam);
            if (sqlparam[21].Value != DBNull.Value)
                return sqlparam[21].Value.ToString();
            else
                return null;
        }
        public DataTable Get_AccHead(clsAccountHeadBll cls)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@AccountCode", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(cls.ACCOUNTCODE);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("acc_acchead_category_list", "sp", sqlparam);
            return ds;
        }
        public DataTable LoadListHead(clsAccountHeadBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ACCHEADID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.ACCOUNTCODE);
            return objCmnDal.GetTable("acc_AccHeadList_get", "sp", sqlparam);
        }
        public DataTable LoadList()
        {
            return objCmnDal.GetTable("select DISTINCT * from AC_AccountHead ORDER BY CATID ", "text", null);
        }
        public string UpdateAccType(clsAccountHeadBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@ACCOUNTTYPE", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ACCOUNTTYPE);
            sqlparam[1] = new SqlParameter("@dtaccountDb", SqlDbType.Structured);
            sqlparam[1].Value = (obj.dtaccount);
            sqlparam[2] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[2].Direction = ParameterDirection.Output;
            sqlparam[3] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[4] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(ClsCommon.UserCode);
            objCmnDal.GetTable("acc_accType_accHead_Update", "sp", sqlparam);
            if (sqlparam[2].Value != DBNull.Value)
                return sqlparam[2].Value.ToString();
            else
                return null;
        }
        public string UpdateDepartment(clsAccountHeadBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@DEPTID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.DEPTID);
            sqlparam[1] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[1].Direction = ParameterDirection.Output;
            sqlparam[2] = new SqlParameter("@dtaccountDb", SqlDbType.Structured);
            sqlparam[2].Value = (obj.dtaccount);
            sqlparam[3] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[4] = new SqlParameter("@UUID", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(ClsCommon.UserCode);
            objCmnDal.GetTable("acc_accDept_accHead_Update", "sp", sqlparam);
            if (sqlparam[1].Value != DBNull.Value)
                return sqlparam[1].Value.ToString();
            else
                return null;
        }
        public DataTable LoadJoinHeadList()
        {
            return objCmnDal.GetTable("SELECT DISTINCT dbo.AC_AccountHead.CATID AS ACCHEADID, dbo.TBACCCATEGORY.*, dbo.AC_AccountHead.ACCOUNTCODE FROM dbo.TBACCCATEGORY LEFT OUTER JOIN  dbo.AC_AccountHead ON dbo.TBACCCATEGORY.CATID = dbo.AC_AccountHead.CATID where dbo.AC_AccountHead.CATID=dbo.TBACCCATEGORY.CATID", "text", null);
        }
        public DataTable LoadVoucherType(clsAccountHeadBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ACCHEADID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.ACCOUNTCODE);
            return objCmnDal.GetTable("acc_accHead_accheaddesc_list", "sp", sqlparam);
        }
        public DataTable GetAccHeadList(clsAccountHeadBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@ACCOUNTCODE", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.ACCOUNTCODE);
            sqlparam[1] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.BRANCHCODE);
            return objCmnDal.GetTable("acc_VoucherType_GetList", "sp", sqlparam);
        }

        public DataTable Get_AccHead_AccCode(clsAccountHeadBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@GLCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(obj.GLCODE);
            return objCmnDal.GetTable("acc_nrmlVchr_GetAccHead", "sp", sqlparam);
        }

        public DataTable Get_AccHead_List(clsAccountHeadBll cls)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@ACCOUNTDESC", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(cls.ACCOUNTDESC);
            sqlparam[1] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(cls.BRANCHCODE);
            sqlparam[2] = new SqlParameter("@ACCOUNTCODE", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Decimal(cls.ACCOUNTCODE);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("acc_AccHeadSearch_List", "sp", sqlparam);
            return ds;
        }

        public DataTable Get_SLCode_AccDesc(clsAccountHeadBll cls)
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@GLCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(cls.@GLCODE);
            sqlparam[1] = new SqlParameter("@SLCODE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(cls.SLCODE);
            sqlparam[2] = new SqlParameter("@ACCOUNTCODE", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(cls.ACCOUNTCODE);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("acc_nrmlVchr_GetSLCode_AccDesc", "sp", sqlparam);
            return ds;
        }

        internal DataTable Get_AccHead_byCatid(clsAccountHeadBll clsAccountHeadBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@CATID", SqlDbType.Int);
            sqlparam[0].Value = DBNullHandler.Int32(clsAccountHeadBll.CATID);
        
            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("get_acchead_bycatid", "sp", sqlparam);
            return dt;
        }

        public DataTable Get_AccHead_MaxSLCODE(clsAccountHeadBll clsAccountHeadBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@GLCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(clsAccountHeadBll.GLCODE);

            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("acc_AccHead_getSLcode", "sp", sqlparam);
            return dt;
        }


    }
}