using Ensure.BllDalClasses.BllClass.Common;
using Ensure.BllDalClasses.BllClass.Setup.Account;
using Ensure.DalClass.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Ensure.BllDalClasses.DalClass.Setup.Account
{
    public class ClsReqForCrNotePaymentDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public DataTable GetCrNoteDetail(ClsReqForCrNotePaymentBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[7];
            sqlparam[0] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.branchid);
            sqlparam[1] = new SqlParameter("@subbranchid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.subbranchid);
            sqlparam[2] = new SqlParameter("@fiscalid", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.fiscalid);
            sqlparam[3] = new SqlParameter("@approved", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.approved);
            sqlparam[4] = new SqlParameter("@feildofficerid", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(obj.feildofficerid);
            sqlparam[5] = new SqlParameter("@datefrom", SqlDbType.DateTime);
            sqlparam[5].Value = NullHandler.DateTime(obj.datefrom);
            sqlparam[6] = new SqlParameter("@dateto", SqlDbType.DateTime);
            sqlparam[6].Value = NullHandler.DateTime(obj.dateto);

            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("get_creditnotepayment_req", "sp", sqlparam);
            return dt;
        }
        public DataTable GetCrNoteDetailPaid(ClsReqForCrNotePaymentBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[7];
            sqlparam[0] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.branchid);
            sqlparam[1] = new SqlParameter("@subbranchid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.subbranchid);
            sqlparam[2] = new SqlParameter("@fiscalid", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(obj.fiscalid);
            sqlparam[3] = new SqlParameter("@approved", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.approved);
            sqlparam[4] = new SqlParameter("@feildofficerid", SqlDbType.Int);
            sqlparam[4].Value = NullHandler.Int32(obj.feildofficerid);
            sqlparam[5] = new SqlParameter("@datefrom", SqlDbType.DateTime);
            sqlparam[5].Value = NullHandler.DateTime(obj.datefrom);
            sqlparam[6] = new SqlParameter("@dateto", SqlDbType.DateTime);
            sqlparam[6].Value = NullHandler.DateTime(obj.dateto);

            DataTable dt = new DataTable();
            dt = objCmnDal.GetTable("get_creditnotepayment_paid", "sp", sqlparam);
            return dt;
        }
        public string UpdateCrNotePayment(ClsReqForCrNotePaymentBll obj)
        {
            SqlParameter[] sqlparam = new SqlParameter[7];
            sqlparam[0] = new SqlParameter("@docid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(obj.docid);
            sqlparam[1] = new SqlParameter("@approvedby", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(obj.approvedby);
            sqlparam[2] = new SqlParameter("@approveddate", SqlDbType.Date);
            sqlparam[2].Value = NullHandler.DateTime(obj.approveddate);
            sqlparam[3] = new SqlParameter("@isapproved", SqlDbType.Int);
            sqlparam[3].Value = NullHandler.Int32(obj.isapproved);
            sqlparam[4] = new SqlParameter("@approvedtime", SqlDbType.DateTime);
            sqlparam[4].Value = NullHandler.DateTime(obj.approvedtime);
          
            sqlparam[5] = new SqlParameter("@msg", SqlDbType.VarChar, 20);
            sqlparam[5].Direction = ParameterDirection.Output;

            sqlparam[6] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[6].Value = NullHandler.Int32(ClsCommon.BranchId);

            objCmnDal.InsertUpdateTable("update_crnotepayment", "sp", sqlparam);
            if (sqlparam[5].Value != DBNull.Value)
                return sqlparam[5].Value.ToString();
            else
                return null;
        }
    }
}