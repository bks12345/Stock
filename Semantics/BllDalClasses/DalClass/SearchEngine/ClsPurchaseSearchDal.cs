using Stock.BllDalClasses.BllClass.SearchEngine;
using Stock.DalClass.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.DalClass.SearchEngine
{
    public class ClsPurchaseSearchDal
    {
        clsCommonDal objCmnDal = new clsCommonDal();
        public DataTable GetPurchaseDeatils(ClsPurchaseSearchBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@Fiscalid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objbll.Fiscalid);
            sqlparam[1] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objbll.branchid);
            sqlparam[2] = new SqlParameter("@Billno", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objbll.Billno);
            sqlparam[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
            sqlparam[3].Value = NullHandler.DateTime(objbll.Datefrom);
            sqlparam[4] = new SqlParameter("@DateTo ", SqlDbType.DateTime);
            sqlparam[4].Value = NullHandler.DateTime(objbll.DateTo);
            DataTable dt = new DataTable();
            return objCmnDal.GetTable("SEARCH_PURCHASE_ENTRY", "sp", sqlparam);
        }
        public DataTable GetSalesDeatils(ClsPurchaseSearchBll objbll)
        {
            SqlParameter[] sqlparam = new SqlParameter[5];
            sqlparam[0] = new SqlParameter("@Fiscalid", SqlDbType.Int);
            sqlparam[0].Value = NullHandler.Int32(objbll.Fiscalid);
            sqlparam[1] = new SqlParameter("@branchid", SqlDbType.Int);
            sqlparam[1].Value = NullHandler.Int32(objbll.branchid);
            sqlparam[2] = new SqlParameter("@Billno", SqlDbType.Int);
            sqlparam[2].Value = NullHandler.Int32(objbll.Billno);
            sqlparam[3] = new SqlParameter("@Datefrom", SqlDbType.DateTime);
            sqlparam[3].Value = NullHandler.DateTime(objbll.Datefrom);
            sqlparam[4] = new SqlParameter("@DateTo ", SqlDbType.DateTime);
            sqlparam[4].Value = NullHandler.DateTime(objbll.DateTo);
            DataTable dt = new DataTable();
            return objCmnDal.GetTable("SEARCH_Sales_ENTRY", "sp", sqlparam);
        }
    }
}