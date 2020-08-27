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
    public class clsAccChartDefDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();

        public string InsertUpdateTBACCCATEGORY(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[27];
            sqlparam[0] = new SqlParameter("@CATID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.CATID);
            sqlparam[1] = new SqlParameter("@SNO", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.SNO);
            sqlparam[2] = new SqlParameter("@ECATEGORY", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.ECATEGORY);
            sqlparam[3] = new SqlParameter("@NCATEGORY", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.NCATEGORY);
            sqlparam[4] = new SqlParameter("@GLCODE", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(obj.GLCODE);
            sqlparam[5] = new SqlParameter("@DEPARTMENT", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(obj.DEPARTMENT);
            sqlparam[6] = new SqlParameter("@FIXEDCAT", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.FIXEDCAT);
            sqlparam[7] = new SqlParameter("@HASCHILD", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.HASCHILD);
            sqlparam[8] = new SqlParameter("@LEVEL1", SqlDbType.Int);
            sqlparam[8].Value = NullHandler.Int32(obj.LEVEL1);
            sqlparam[9] = new SqlParameter("@LEVEL2", SqlDbType.Int);
            sqlparam[9].Value = NullHandler.Int32(obj.LEVEL2);
            sqlparam[10] = new SqlParameter("@LEVEL3", SqlDbType.Int);
            sqlparam[10].Value = NullHandler.Int32(obj.LEVEL3);
            sqlparam[11] = new SqlParameter("@LEVEL4", SqlDbType.Int);
            sqlparam[11].Value = NullHandler.Int32(obj.LEVEL4);
            sqlparam[12] = new SqlParameter("@LEVEL5", SqlDbType.Int);
            sqlparam[12].Value = NullHandler.Int32(obj.LEVEL5);
            sqlparam[13] = new SqlParameter("@LEVELNO", SqlDbType.Int);
            sqlparam[13].Value = NullHandler.Int32(obj.LEVELNO);
            sqlparam[14] = new SqlParameter("@OFTYPE", SqlDbType.Int);
            sqlparam[14].Value = NullHandler.Int32(obj.OFTYPE);
            sqlparam[15] = new SqlParameter("@REFID", SqlDbType.Int);
            sqlparam[15].Value = NullHandler.Int32(obj.REFID);
            sqlparam[16] = new SqlParameter("@AUID", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Int32(obj.AUID);
            sqlparam[17] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[17].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[18] = new SqlParameter("@UUID", SqlDbType.Int);
            sqlparam[18].Value = NullHandler.Int32(obj.UUID);
            sqlparam[19] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[19].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[20] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[20].Direction = ParameterDirection.Output;
            sqlparam[21] = new SqlParameter("@DEPTID", SqlDbType.Int);
            sqlparam[21].Value = NullHandler.Int32(obj.DEPTID);
            sqlparam[22] = new SqlParameter("@BranchId", SqlDbType.Int);
            sqlparam[22].Value = NullHandler.Int32(ClsCommon.BranchId);
            sqlparam[23] = new SqlParameter("@DRCRTYPE", SqlDbType.Int);
            sqlparam[23].Value = NullHandler.Int32(obj.DRCRTYPE);
            sqlparam[24] = new SqlParameter("@TRANTYPE", SqlDbType.Structured);
            sqlparam[24].Value = (obj.TRANTYPE);
            sqlparam[25] = new SqlParameter("@islock", SqlDbType.Int);
            sqlparam[25].Value = NullHandler.Int32(obj.islock);
            sqlparam[26] = new SqlParameter("@islockpartyadj", SqlDbType.Int);
            sqlparam[26].Value = NullHandler.Int32(obj.islockpartyadj);
            objCmnDal.InsertUpdateTable("acc_accCategory_insertUpdate", "sp", sqlparam);
            if (sqlparam[20].Value != DBNull.Value)
                return sqlparam[20].Value.ToString();
            else
                return null;

        }

        public string InsertUpdate_AccHeadAccCat(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[57];
            sqlparam[0] = new SqlParameter("@CATID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.CATID);
            sqlparam[1] = new SqlParameter("@SNO", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.SNO);
            sqlparam[2] = new SqlParameter("@ECATEGORY", SqlDbType.VarChar);
            sqlparam[2].Value = NullHandler.String(obj.ECATEGORY);
            sqlparam[3] = new SqlParameter("@NCATEGORY", SqlDbType.VarChar);
            sqlparam[3].Value = NullHandler.String(obj.NCATEGORY);
            sqlparam[4] = new SqlParameter("@GLCODE", SqlDbType.VarChar);
            sqlparam[4].Value = NullHandler.String(obj.GLCODE);
            sqlparam[5] = new SqlParameter("@DEPARTMENT", SqlDbType.VarChar);
            sqlparam[5].Value = NullHandler.String(obj.DEPARTMENT);
            sqlparam[6] = new SqlParameter("@FIXEDCAT", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(obj.FIXEDCAT);
            sqlparam[7] = new SqlParameter("@HASCHILD", SqlDbType.Int);
            sqlparam[7].Value = NullHandler.Int32(obj.HASCHILD);
            sqlparam[8] = new SqlParameter("@LEVEL1", SqlDbType.Decimal);
            sqlparam[8].Value = NullHandler.Decimal(obj.LEVEL1);
            sqlparam[9] = new SqlParameter("@LEVEL2", SqlDbType.Decimal);
            sqlparam[9].Value = NullHandler.Decimal(obj.LEVEL2);
            sqlparam[10] = new SqlParameter("@LEVEL3", SqlDbType.Decimal);
            sqlparam[10].Value = NullHandler.Decimal(obj.LEVEL3);
            sqlparam[11] = new SqlParameter("@LEVEL4", SqlDbType.Decimal);
            sqlparam[11].Value = NullHandler.Decimal(obj.LEVEL4);
            sqlparam[12] = new SqlParameter("@LEVEL5", SqlDbType.Decimal);
            sqlparam[12].Value = NullHandler.Decimal(obj.LEVEL5);
            sqlparam[13] = new SqlParameter("@LEVELNO", SqlDbType.Decimal);
            sqlparam[13].Value = NullHandler.Decimal(obj.LEVELNO);
            sqlparam[14] = new SqlParameter("@OFTYPE", SqlDbType.Decimal);
            sqlparam[14].Value = NullHandler.Decimal(obj.OFTYPE);
            sqlparam[15] = new SqlParameter("@REFID", SqlDbType.Decimal);
            sqlparam[15].Value = NullHandler.Decimal(obj.REFID);
            sqlparam[16] = new SqlParameter("@AUID", SqlDbType.Int);
            sqlparam[16].Value = NullHandler.Int32(obj.AUID);
            sqlparam[17] = new SqlParameter("@ADT", SqlDbType.DateTime);
            sqlparam[17].Value = NullHandler.DateTime(obj.ADT);
            sqlparam[18] = new SqlParameter("@UUID", SqlDbType.Int);
            sqlparam[18].Value = NullHandler.Int32(obj.UUID);
            sqlparam[19] = new SqlParameter("@UDT", SqlDbType.DateTime);
            sqlparam[19].Value = NullHandler.DateTime(obj.UDT);
            sqlparam[20] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[20].Direction = ParameterDirection.Output;

            sqlparam[21] = new SqlParameter("@ACATEGORY", SqlDbType.VarChar);
            sqlparam[21].Value = NullHandler.String(obj.ACATEGORY);
            sqlparam[22] = new SqlParameter("@ACCOUNTCODE", SqlDbType.Int);
            sqlparam[22].Value = NullHandler.Int32(obj.ACCOUNTCODE);
            sqlparam[23] = new SqlParameter("@THECODE", SqlDbType.VarChar);
            sqlparam[23].Value = NullHandler.String(obj.THECODE);
            sqlparam[24] = new SqlParameter("@AGENTCODE", SqlDbType.VarChar);
            sqlparam[24].Value = NullHandler.String(obj.AGENTCODE);
            sqlparam[25] = new SqlParameter("@ATYPE", SqlDbType.Decimal);
            sqlparam[25].Value = NullHandler.Decimal(obj.ATYPE);
            sqlparam[26] = new SqlParameter("@BANKACCNO", SqlDbType.VarChar);
            sqlparam[26].Value = NullHandler.String(obj.BANKACCNO);
            sqlparam[27] = new SqlParameter("@BANKCODE", SqlDbType.Decimal);
            sqlparam[27].Value = NullHandler.Decimal(obj.BANKCODE);
            sqlparam[28] = new SqlParameter("@BANKID", SqlDbType.Decimal);
            sqlparam[28].Value = NullHandler.Decimal(obj.BANKID);
            sqlparam[29] = new SqlParameter("@BRANCHCODE", SqlDbType.VarChar);
            sqlparam[29].Value = NullHandler.String(obj.BRANCHCODE);
            sqlparam[30] = new SqlParameter("@CLASSID", SqlDbType.VarChar);
            sqlparam[30].Value = NullHandler.String(obj.CLASSID);
            sqlparam[31] = new SqlParameter("@CLIENTCODE", SqlDbType.VarChar);
            sqlparam[31].Value = NullHandler.String(obj.CLIENTCODE);
            sqlparam[32] = new SqlParameter("@CURRENCYACCOUNT", SqlDbType.VarChar);
            sqlparam[32].Value = NullHandler.String(obj.CURRENCYACCOUNT);
            sqlparam[33] = new SqlParameter("@DEPTID", SqlDbType.Int);
            sqlparam[33].Value = NullHandler.Int32(obj.DEPTID);
            sqlparam[34] = new SqlParameter("@FIXEDHEAD", SqlDbType.Int);
            sqlparam[34].Value = NullHandler.Decimal(obj.FIXEDHEAD);
            sqlparam[35] = new SqlParameter("@ISBANK", SqlDbType.Decimal);
            sqlparam[35].Value = NullHandler.Decimal(obj.ISBANK);
            sqlparam[36] = new SqlParameter("@ISSBRANCHCODE", SqlDbType.VarChar);
            sqlparam[36].Value = NullHandler.String(obj.ISSBRANCHCODE);
            sqlparam[37] = new SqlParameter("@MCBANKCODE", SqlDbType.VarChar);
            sqlparam[37].Value = NullHandler.String(obj.MCBANKCODE);
            sqlparam[38] = new SqlParameter("@PLCATEGORY", SqlDbType.VarChar);
            sqlparam[38].Value = NullHandler.String(obj.PLCATEGORY);
            sqlparam[39] = new SqlParameter("@RELATEDTO", SqlDbType.Decimal);
            sqlparam[39].Value = NullHandler.Decimal(obj.RELATEDTO);
            sqlparam[40] = new SqlParameter("@RICOMPANYID", SqlDbType.Decimal);
            sqlparam[40].Value = NullHandler.Decimal(obj.RICOMPANYID);
            sqlparam[41] = new SqlParameter("@TYPE", SqlDbType.Decimal);
            sqlparam[41].Value = NullHandler.Decimal(obj.TYPE);
            sqlparam[42] = new SqlParameter("@ACCTYPE", SqlDbType.VarChar);
            sqlparam[42].Value = NullHandler.String(obj.ACCTYPE);
            sqlparam[43] = new SqlParameter("@BR_ACCOUNTCODE", SqlDbType.Decimal);
            sqlparam[43].Value = NullHandler.Decimal(obj.BR_ACCOUNTCODE);
            sqlparam[44] = new SqlParameter("@BUDGETCATID", SqlDbType.Decimal);
            sqlparam[44].Value = NullHandler.Decimal(obj.BUDGETCATID);
            sqlparam[45] = new SqlParameter("@CATCODE", SqlDbType.Decimal);
            sqlparam[45].Value = NullHandler.Decimal(obj.CATCODE);
            sqlparam[46] = new SqlParameter("@DEPTCODE", SqlDbType.VarChar);
            sqlparam[46].Value = NullHandler.String(obj.DEPTCODE);
            sqlparam[47] = new SqlParameter("@IS_CR_ADVICE", SqlDbType.Decimal);
            sqlparam[47].Value = NullHandler.Decimal(obj.IS_CR_ADVICE);
            sqlparam[48] = new SqlParameter("@IS_DEP_BANK", SqlDbType.Decimal);
            sqlparam[48].Value = NullHandler.Decimal(obj.IS_DEP_BANK);
            sqlparam[49] = new SqlParameter("@SLCODE", SqlDbType.VarChar);
            sqlparam[49].Value = NullHandler.String(obj.SLCODE);
            sqlparam[50] = new SqlParameter("@SUBAGENTCODE", SqlDbType.VarChar);
            sqlparam[50].Value = NullHandler.String(obj.SUBAGENTCODE);
            sqlparam[51] = new SqlParameter("@TBGROUP", SqlDbType.VarChar);
            sqlparam[51].Value = NullHandler.String(obj.TBGROUP);
            sqlparam[52] = new SqlParameter("@TBPART", SqlDbType.VarChar);
            sqlparam[52].Value = NullHandler.String(obj.TBPART);
            sqlparam[53] = new SqlParameter("@TBSUBGROUP", SqlDbType.VarChar);
            sqlparam[53].Value = NullHandler.String(obj.TBSUBGROUP);
            sqlparam[54] = new SqlParameter("@ACCOUNTTYPE", SqlDbType.VarChar);
            sqlparam[54].Value = NullHandler.String(obj.ACCOUNTTYPE);
            sqlparam[55] = new SqlParameter("@ACCHEADID", SqlDbType.Int);
            sqlparam[55].Value = NullHandler.Int32(obj.ACCHEADID);
            sqlparam[56] = new SqlParameter("@ACCCATID", SqlDbType.Int);
            sqlparam[56].Value = NullHandler.Int32(obj.ACCCATID);

            objCmnDal.InsertUpdateTable("acc_accCategory_accHead_insertUpdate", "sp", sqlparam);
            if (sqlparam[20].Value != DBNull.Value)
                return sqlparam[20].Value.ToString();
            else
                return null;

        }
        public DataTable LoadChartList()
        {
            return objCmnDal.GetTable("SELECT DISTINCT * from TBACCCATEGORY  ORDER BY CATID", "text", null);
        }
        public DataTable LoadAccTypeHead()
        {
            return objCmnDal.GetTable("SELECT DISTINCT * from TBACCCATEGORY where refid=0 ", "text", null);
        }
        public DataTable LoadChart()
        {
            return objCmnDal.GetTable("select SNO from TBACCCATEGORY ", "text", null);
        }
        public DataTable LoadList(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@CATID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.CATID);
            return objCmnDal.GetTable("acc_AccCategoryList_get", "sp", sqlparam);
        }
        public DataTable LoadChildList(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@REFID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.REFID);
            return objCmnDal.GetTable("acc_AccCategoryChild_get", "sp", sqlparam);
        }

        public DataTable LoadAccHeadSearch(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@GLCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(obj.GLCODE);
            return objCmnDal.GetTable("[acc_AccHeadSearchGlCode_get]", "sp", sqlparam);
        }

        public DataTable LoadCategory()
        {
            return objCmnDal.GetTable("SELECT * FROM tbAccCategory order by catid, level1, level2, level3, level4, level5", "text", null);
        }
        public DataTable LoadAccHeadCat()
        {
            return objCmnDal.GetTable("SELECT DISTINCT dbo.AC_AccountHead.*, dbo.TBACCCATEGORY.CATID as accCatid,dbo.TBACCCATEGORY.REFID FROM  dbo.TBACCCATEGORY LEFT OUTER JOIN  dbo.AC_AccountHead ON dbo.TBACCCATEGORY.CATID = dbo.AC_AccountHead.CATID where dbo.AC_AccountHead.CATID=dbo.TBACCCATEGORY.CATID", "text", null);
        }
        public DataTable LoadAccHead(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@REFID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.REFID);
            return objCmnDal.GetTable("acc_AccCategoryHeadList_get", "sp", sqlparam);
        }
        public DataTable LoadJoinHeadList(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@CATID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.CATID);
            sqlparam[1] = new SqlParameter("@AccountDesc", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.ACCOUNTDESC);
            return objCmnDal.GetTable("acc_accHead_accCategory_list", "sp", sqlparam);
        }
        public DataTable getAllAccountHeadCreation(clsAccChartDefBll objGrpPermissionBll)
        {
            SqlParameter[] sqlparam = new SqlParameter[0];         
            return objCmnDal.GetTable("getAllAccountHeadCreation", "sp", sqlparam);
        }
        public DataTable LoadListHead(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ACCHEADID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.ACCHEADID);
            return objCmnDal.GetTable("acc_AccHeadList_get", "sp", sqlparam);
        }
        public DataTable LoadAccTypeMapping(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@ACCOUNTTYPE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(obj.ACCOUNTTYPE);
            return objCmnDal.GetTable("acc_accTypeMapping", "sp", sqlparam);
        }

        internal DataTable Loadheadoncatagory(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@CATID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.CATID);
            return objCmnDal.GetTable("acc_acchead_catatagorywise_get", "sp", sqlparam);
        }

        internal DataTable LoadTrialblcList(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@CATID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.CATID);
            return objCmnDal.GetTable("acc_catagory_list_Trialblc", "sp", sqlparam);
        }
        internal DataTable LoadAccHeadList(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@CATID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Decimal(obj.CATID);
            return objCmnDal.GetTable("acc_category_accHeadList", "sp", sqlparam);
        }

        public DataTable LoadMaxSno(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@CATID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.CATID);
            sqlparam[1] = new SqlParameter("@REFID", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.REFID);
            return objCmnDal.GetTable("acc_chartOfAccount_getSNO", "sp", sqlparam);
        }

        public DataTable LoadMaxGLcode(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            //sqlparam[0] = new SqlParameter("@LEVELNO", SqlDbType.Int);
            //sqlparam[0].Value = NullHandler.Int32(obj.LEVELNO);
            sqlparam[0] = new SqlParameter("@REFID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.REFID);
            return objCmnDal.GetTable("acc_chartOfAcc_getGlcode", "sp", sqlparam);
        }

        public DataTable loadGlCode(clsAccChartDefBll obj)
        {
            return objCmnDal.GetTable("acc_get_GlCode", "sp", null);
        }

        public DataTable loadSlCode(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@GLCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(obj.GLCODE);
            return objCmnDal.GetTable("acc_get_SlCode", "sp", sqlparam);
        }
        public DataTable loadAccountDesc(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            sqlparam[0] = new SqlParameter("@SLCODE", SqlDbType.VarChar);
            sqlparam[0].Value = NullHandler.String(obj.SLCODE);
            sqlparam[1] = new SqlParameter("@GLCODE", SqlDbType.VarChar);
            sqlparam[1].Value = NullHandler.String(obj.GLCODE);
            return objCmnDal.GetTable("acc_get_accountDesc", "sp", sqlparam);
        }

        internal DataTable GetTransactionList(clsAccChartDefBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@CATID", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.CATID);
            DataTable ds = new DataTable();
            ds = objCmnDal.GetTable("[acc_transactionList_get]", "sp", sqlparam);
            return ds;
        }
    }
}