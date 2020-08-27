using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
using Ensure.DalClass.Common;
using Ensure.BllDalClasses.BllClass.Common;
using Ensure.BllClass.Setup.Underwriting.UW;
using Ensure.BllDalClasses.BllClass.Setup.ReInsurance.RI;

namespace Ensure.NepaliDt
{
    class SemNepaliDate
    {
        public static string FxGetEngToNepDate(string prmEngDate) 
        {
            DateTime vCurrDate ;
            DateTime vStartDate ;
            int Cnt =0;
            int vTotMonths =0;
            int vDateDiff = 0;

            DateTime dt = DateTime.Now;
            string sDate = dt.ToShortDateString();

            if (prmEngDate.Trim()=="")
            {
                prmEngDate = sDate;
            }
            if (ClsValidateControl.FxIsValidDate(prmEngDate) == false)
            {
                prmEngDate = sDate;
            }
            vCurrDate =Convert.ToDateTime( prmEngDate);
            string sql = "";
            //StringBuilder sql = new StringBuilder();
            DataTable Rs = new DataTable();
            //sql.Length = 0;
            string vAccDate=prmEngDate;

            sql = "SELECT tbYearInfo.NYear, tbMonthInfo.NMonth, tbMonthInfo.NDays, tbYearInfo.ESDate FROM tbYearInfo";
            sql = sql + " INNER JOIN tbMonthInfo ON tbYearInfo.NYear = tbMonthInfo.NYear";
            sql = sql + " Where '" + vAccDate + "' Between ESDATE And  EEDate";
            sql = sql + " ORDER BY tbMonthInfo.NMonth";
            Rs = FxGetDataFromQuery(sql.ToString());
            if (Rs == null)
            {
                return "";
            }
            int iRowCount = Rs.Rows.Count;
            string _NepDate = "";
            if (iRowCount > 0)
            {                
                Boolean _FirstTime = true;
                Boolean _Found = false;
                foreach (DataRow dr in Rs.Rows)
                {
                    if (_FirstTime==true)
                    {
                        vStartDate = Convert.ToDateTime(dr["ESDate"]);
                        vDateDiff = ClsConvertTo.Int32((vCurrDate - vStartDate).TotalDays);
                        _FirstTime = false;
                    }
                    if ((Cnt + ClsConvertTo.Int32( dr["NDays"])) > vDateDiff)
                    {
                        _Found = true;
                        _NepDate= Convert.ToString(dr["NYear"]) + "/" + Convert.ToString(vTotMonths + 1) + "/" + Convert.ToString((vDateDiff - Cnt + 1));                        
                    }
                    if (_Found == true)
                    {                        
                        break;
                    }
                    vTotMonths = vTotMonths + 1;
                    Cnt = Cnt + ClsConvertTo.Int32(dr["NDays"]);                    
                }                
            }
            return _NepDate;
        }
        public static int FxGetTotalDaysofMonth(int vYear, int vMonth)
        {
            int _vDays = 29;

            string sql = "";
            DataTable Rs = new DataTable();

            sql = "SELECT tbMonthInfo.NYear, tbMonthInfo.NMonth, tbMonthInfo.NDays";
            sql = sql + " FROM tbMonthInfo ";
            sql = sql + "  Where tbMonthInfo.NYear = " + vYear;
            sql = sql + " And tbMonthInfo.NMonth = " + vMonth;
            Rs = FxGetDataFromQuery(sql.ToString());
            int iRowCount = Rs.Rows.Count;
            
            if (iRowCount > 0)
            {
                foreach (DataRow dr in Rs.Rows)
                {
                    _vDays =ClsConvertTo.Int32( dr["NDays"]);
                }
            }            
            return _vDays;
        }        
        public static string FxGetNepToEngDate(string dNepDate)
        {
            try
            {
                string[] vDelim = { "/" };
                string[] vNepDt = dNepDate.Split(vDelim, StringSplitOptions.RemoveEmptyEntries);
                string Sql1 = "SELECT tbYearInfo.NYear, tbMonthInfo.NMonth, tbMonthInfo.NDays, tbYearInfo.ESDate, tbYearInfo.EEDate";
                Sql1 = Sql1 + " FROM tbMonthInfo INNER JOIN tbYearInfo ON tbyearInfo.NYear = tbMonthInfo.NYear";
                Sql1 = Sql1 + " Where tbYearInfo.NYear = " + vNepDt[0];
                Sql1 = Sql1 + " And tbMonthInfo.NMonth <= " + vNepDt[1];
                Sql1 = Sql1 + " ORDER BY NMonth";
                DataTable Rs = new DataTable();
                Rs = FxGetDataFromQuery(Sql1.ToString());
                if (Rs == null)
                {
                    ClsAlert.Alert("Invalid date format.");
                    //MessageBox.Show("Invalid date format.");
                    return System.DateTime.Now.ToShortDateString();
                }
                else
                {
                    int iRowCount = Rs.Rows.Count;
                    if (iRowCount==0)
                    {
                        return "1-JAN-1900";
                    }
                }
                
                DateTime vSdate = System.DateTime.Now;
                int Cnt = 1;
                int vSumDay = 0;
                //int MM;
                Boolean vFirstTime = true;
                foreach (DataRow Dr in Rs.Rows)
                {
                    vSdate = Convert.ToDateTime(Dr["EsDate"]);
                    if (vFirstTime)
                    {
                        vSumDay = ClsConvertTo.Int32(vNepDt[2]) - 1;
                    }
                    vFirstTime = false;
                    if (Cnt < ClsConvertTo.Int32(vNepDt[1]))
                    {
                        vSumDay = vSumDay + ClsConvertTo.Int32(Dr["NDays"]);
                        Cnt = Cnt + 1;
                    }
                }
                vSdate = vSdate.AddDays(vSumDay);
                return vSdate.ToShortDateString();
            }
            catch 
            {
                return System.DateTime.Now.ToShortDateString();
            }
        }
        public static string FxNepaliMonthName(string MthIndex)
        {
            int _indx = ClsConvertTo.Int32(MthIndex);
            if (_indx == 1) { return "Baisakh"; }
            if (_indx == 2) { return "Jestha"; }
            if (_indx == 3) { return "Ashad"; }
            if (_indx == 4) { return "Shrawan"; }
            if (_indx == 5) { return "Bhadra"; }
            if (_indx == 6) { return "Ashoj"; }
            if (_indx == 7) { return "Kartik"; }
            if (_indx == 8) { return "Mangshir"; }
            if (_indx == 9) { return "Poush"; }
            if (_indx == 10) { return "Magh"; }
            if (_indx == 11) { return "Falgun"; }
            if (_indx == 12) { return "Chaitra"; }
            return "Baisakh";
        }
        public static int FxGetNepaliYearIndex(string prmEngDate)
        {
            DateTime vCurrDate;
            DateTime vStartDate;
            int Cnt = 0;
            int vTotMonths = 0;
            int vDateDiff = 0;

            DateTime dt = DateTime.Now;
            string sDate = dt.ToShortDateString();

            if (prmEngDate.Trim() == "")
            {
                prmEngDate = sDate;
            }
            vCurrDate = Convert.ToDateTime(prmEngDate);
            string sql = "";
            //StringBuilder sql = new StringBuilder();
            DataTable Rs = new DataTable();
            //sql.Length = 0;
            string vAccDate = prmEngDate;

            sql = "SELECT tbYearInfo.NYear, tbMonthInfo.NMonth, tbMonthInfo.NDays, tbYearInfo.ESDate FROM tbYearInfo";
            sql = sql + " INNER JOIN tbMonthInfo ON tbYearInfo.NYear = tbMonthInfo.NYear";
            sql = sql + " Where '" + vAccDate + "' Between ESDATE And  EEDate";
            sql = sql + " ORDER BY tbMonthInfo.NMonth";

            Rs = FxGetDataFromQuery(sql.ToString());
            if (Rs == null)
            {
                return 0;
            }
            int iRowCount = Rs.Rows.Count;
            string _NepDate = "";
            if (iRowCount > 0)
            {
                Boolean _FirstTime = true;
                Boolean _Found = false;
                foreach (DataRow dr in Rs.Rows)
                {
                    if (_FirstTime == true)
                    {
                        vStartDate = Convert.ToDateTime(dr["ESDate"]);
                        vDateDiff = ClsConvertTo.Int32((vCurrDate - vStartDate).TotalDays);
                        _FirstTime = false;
                    }
                    if ((Cnt + ClsConvertTo.Int32(dr["NDays"])) > vDateDiff)
                    {
                        _Found = true;
                        _NepDate = Convert.ToString(dr["NYear"]);
                    }
                    if (_Found == true)
                    {
                        break;
                    }
                    vTotMonths = vTotMonths + 1;
                    Cnt = Cnt + ClsConvertTo.Int32(dr["NDays"]);
                }
            }
            return ClsConvertTo.Int32(_NepDate);
        }
        public static int FxGetNepaliMonthIndex(string prmEngDate)
        {
            DateTime vCurrDate;
            DateTime vStartDate;
            int Cnt = 0;
            int vTotMonths = 0;
            int vDateDiff = 0;

            DateTime dt = DateTime.Now;
            string sDate = dt.ToShortDateString();

            if (prmEngDate.Trim() == "")
            {
                prmEngDate = sDate;
            }
            vCurrDate = Convert.ToDateTime(prmEngDate);
            string sql = "";
            //StringBuilder sql = new StringBuilder();
            DataTable Rs = new DataTable();
            //sql.Length = 0;
            string vAccDate = prmEngDate;

            sql = "SELECT tbYearInfo.NYear, tbMonthInfo.NMonth, tbMonthInfo.NDays, tbYearInfo.ESDate FROM tbYearInfo";
            sql = sql + " INNER JOIN tbMonthInfo ON tbYearInfo.NYear = tbMonthInfo.NYear";
            sql = sql + " Where '" + vAccDate + "' Between ESDATE And  EEDate";
            sql = sql + " ORDER BY tbMonthInfo.NMonth";

            Rs = FxGetDataFromQuery(sql.ToString());
            if (Rs == null)
            {
                return 0;
            }
            int iRowCount = Rs.Rows.Count;
            string _NepDate = "";
            if (iRowCount > 0)
            {
                Boolean _FirstTime = true;
                Boolean _Found = false;
                foreach (DataRow dr in Rs.Rows)
                {
                    if (_FirstTime == true)
                    {
                        vStartDate = Convert.ToDateTime(dr["ESDate"]);
                        vDateDiff = ClsConvertTo.Int32((vCurrDate - vStartDate).TotalDays);
                        _FirstTime = false;
                    }
                    if ((Cnt + ClsConvertTo.Int32(dr["NDays"])) > vDateDiff)
                    {
                        _Found = true;
                        _NepDate =  Convert.ToString(vTotMonths + 1);
                    }
                    if (_Found == true)
                    {
                        break;
                    }
                    vTotMonths = vTotMonths + 1;
                    Cnt = Cnt + ClsConvertTo.Int32(dr["NDays"]);
                }
            }
            return ClsConvertTo.Int32( _NepDate);
        }
        public static int FxGetNepaliDayIndex(string prmEngDate)
        {
            DateTime vCurrDate;
            DateTime vStartDate;
            int Cnt = 0;
            int vTotMonths = 0;
            int vDateDiff = 0;

            DateTime dt = DateTime.Now;
            string sDate = dt.ToShortDateString();

            if (prmEngDate.Trim() == "")
            {
                prmEngDate = sDate;
            }
            vCurrDate = Convert.ToDateTime(prmEngDate);
            string sql = "";
            //StringBuilder sql = new StringBuilder();
            DataTable Rs = new DataTable();
            //sql.Length = 0;
            string vAccDate = prmEngDate;

            sql = "SELECT tbYearInfo.NYear, tbMonthInfo.NMonth, tbMonthInfo.NDays, tbYearInfo.ESDate FROM tbYearInfo";
            sql = sql + " INNER JOIN tbMonthInfo ON tbYearInfo.NYear = tbMonthInfo.NYear";
            sql = sql + " Where '" + vAccDate + "' Between ESDATE And  EEDate";
            sql = sql + " ORDER BY tbMonthInfo.NMonth";

            Rs = FxGetDataFromQuery(sql.ToString());
            if (Rs == null)
            {
                return 0;
            }
            int iRowCount = Rs.Rows.Count;
            string _NepDate = "";
            if (iRowCount > 0)
            {
                Boolean _FirstTime = true;
                Boolean _Found = false;
                foreach (DataRow dr in Rs.Rows)
                {
                    if (_FirstTime == true)
                    {
                        vStartDate = Convert.ToDateTime(dr["ESDate"]);
                        vDateDiff = ClsConvertTo.Int32((vCurrDate - vStartDate).TotalDays);
                        _FirstTime = false;
                    }
                    if ((Cnt + ClsConvertTo.Int32(dr["NDays"])) > vDateDiff)
                    {
                        _Found = true;
                        _NepDate = Convert.ToString(vDateDiff - Cnt + 1);
                    }
                    if (_Found == true)
                    {
                        break;
                    }
                    vTotMonths = vTotMonths + 1;
                    Cnt = Cnt + ClsConvertTo.Int32(dr["NDays"]);
                }
            }
            return ClsConvertTo.Int32(_NepDate);
        }

        protected static DataTable FxGetDataFromQuery(string _sql)
        {
            clsCommonDal cls = new clsCommonDal();
            using (SqlConnection connection = new SqlConnection(cls.GetConnectionString()))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = _sql;
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            return dt;
                        }
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

        public static void FxGetEngStart_End_Date(string prmFiscalID, int prmNepMonth, ref string prmStartDt, ref string prmEndDt)
        {
            int _year = 0;
            int _additionalYr = 0;
            int _lastdayofMonth = 0;
            int _month = prmNepMonth;
            if (_month < 4) _additionalYr = 1;

            prmStartDt = "";
            prmEndDt = "";
            DataTable dt = new DataTable();
            ClsFiscalYearBll clsdept = new ClsFiscalYearBll();
            clsdept.ID =ClsConvertTo.Int32(prmFiscalID);
            dt = clsdept.GetFiscalYr();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    string _StDt;
                    string _EnDt;
                    string _NepDt;
                    _StDt = Convert.ToDateTime( dt.Rows[0]["ENGSTARTDATE"]).ToString("dd-MMM-yyyy");
                    _NepDt = FxGetEngToNepDate(_StDt);
                    string[] vDelim = { "/" };
                    string[] vNepDt = _NepDt.Split(vDelim, StringSplitOptions.RemoveEmptyEntries);
                    _year = ClsConvertTo.Int32( vNepDt[0]);
                    _year = _year + _additionalYr;
                    _lastdayofMonth = FxGetTotalDaysofMonth(_year, _month);

                    _StDt = FxGetNepToEngDate(_year.ToString() + "/" + _month.ToString("00") + "/01");
                    _EnDt = FxGetNepToEngDate(_year.ToString() + "/" + _month.ToString("00") + "/" + _lastdayofMonth.ToString() );

                    prmStartDt = _StDt;
                    prmEndDt = _EnDt;
                }
            }

        }
        public static void FxGetEngStart_End_Date_RI(string prmFiscalID, int prmNepMonth, ref string prmStartDt, ref string prmEndDt)
        {
            int _year = 0;
            int _additionalYr = 0;
            int _lastdayofMonth = 0;
            int _month = prmNepMonth;
            if (_month < 4) _additionalYr = 1;

            prmStartDt = "";
            prmEndDt = "";
            DataTable dt = new DataTable();
            ClsRIFiscalYearBll objFiscalYrBll = new ClsRIFiscalYearBll();
            objFiscalYrBll.ID = ClsConvertTo.Int32(prmFiscalID);
            dt = objFiscalYrBll.GetFiscalYr();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    string _StDt;
                    string _EnDt;
                    string _NepDt;
                    _StDt = Convert.ToDateTime(dt.Rows[0]["ENGSTARTDATE"]).ToString("dd-MMM-yyyy");
                    _NepDt = FxGetEngToNepDate(_StDt);
                    string[] vDelim = { "/" };
                    string[] vNepDt = _NepDt.Split(vDelim, StringSplitOptions.RemoveEmptyEntries);
                    _year = ClsConvertTo.Int32(vNepDt[0]);
                    _year = _year + _additionalYr;
                    _lastdayofMonth = FxGetTotalDaysofMonth(_year, _month);

                    _StDt = FxGetNepToEngDate(_year.ToString() + "/" + _month.ToString("00") + "/01");
                    _EnDt = FxGetNepToEngDate(_year.ToString() + "/" + _month.ToString("00") + "/" + _lastdayofMonth.ToString());

                    prmStartDt = _StDt;
                    prmEndDt = _EnDt;
                }
            }

        }
    }
}
