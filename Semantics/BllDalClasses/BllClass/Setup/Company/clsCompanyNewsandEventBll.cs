using Stock.BllDalClasses.DalClass.Setup.Company;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Stock.BllDalClasses.BllClass.Setup.Company
{
    public class clsCompanyNewsandEventBll
    {
        #region tbl_NewsAndEventsLog
        public int ID { get; set; }
        public int USERID { get; set; }
        public int NEID { get; set; }
        public string TILE { get; set; }
        public string DESCRIPTION { get; set; }
        public DateTime ACTIVATIONSTARTDATE { get; set; }
        public DateTime DATEFROM { get; set; }
        public DateTime DATETO { get; set; }
        public DateTime ACTIVATIONEXPIRYDATE { get; set; }
        public int USERGROUPID { get; set; }
        public int AUID { get; set; }
        public DateTime ADT { get; set; }
        public int UUID { get; set; }
        public DateTime UDT { get; set; }
        public int ISDELETE { get; set; }
        public int ACTIVATION { get; set; }
        public int BRANCHID { get; set; }
        public int SUBBRANCHID { get; set; }
        

        public int READ_STATUS_ONLY { get; set; }
        #endregion tbl_NewsAndEventsLog
        public string InsertUpdateNewsAndEventsLog()
        {
            clsCompanyNewsandEventDal objDal = new clsCompanyNewsandEventDal();
            return objDal.InsertUpdateNewsAndEventsLog(this);
        }
        public DataTable GetNewsEventById()
        {
            clsCompanyNewsandEventDal objDal = new clsCompanyNewsandEventDal();
            DataTable dt2 = new DataTable();
            dt2 = objDal.GetNewsEventById(this);
            return dt2;
        }
        public DataTable GetNewsEventDetails()
        {
            clsCompanyNewsandEventDal objDal = new clsCompanyNewsandEventDal();
            DataTable dt2 = new DataTable();
            dt2 = objDal.GetNewsEventDetails(this);
            return dt2;
        }
        public DataTable SearchNewsEvents()
        {
            clsCompanyNewsandEventDal objDal = new clsCompanyNewsandEventDal();
            DataTable dt2 = new DataTable();
            dt2 = objDal.SearchNewsEvents(this);
            return dt2;
        }
        public DataTable GetNewsEventBy_UserID()
        {
            clsCompanyNewsandEventDal objDal = new clsCompanyNewsandEventDal();
            DataTable dt2 = new DataTable();
            dt2 = objDal.GetNewsEventBy_UserID(this);
            return dt2;
        }
        public DataTable LoadNewsandEvent()
        {
            clsCompanyNewsandEventDal objDal = new clsCompanyNewsandEventDal();
            DataTable dt2 = new DataTable();
            dt2 = objDal.LoadNewsandEvent();
            return dt2;
        }
        public DataTable DeleteNewsEvent()
        {
            clsCompanyNewsandEventDal objDal = new clsCompanyNewsandEventDal();
            DataTable dt2 = new DataTable();
            dt2 = objDal.DeleteNewsEvent(this);
            return dt2;
        }
        public string UpdateNewsAndEventsReadLog()
        {
            clsCompanyNewsandEventDal objDal = new clsCompanyNewsandEventDal();
            return objDal.UpdateNewsAndEventsReadLog(this);
        }
    }
}