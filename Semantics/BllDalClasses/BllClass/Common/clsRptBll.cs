using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Stock.BllClass.Common
{
    public class clsRptBll
    {
        public DataTable GenerateRepeator(DataTable vDt, string[] repeaterContent)
        {
            DataTable dt = new DataTable();
            if (vDt == null)
            {
                dt.Columns.Add(new DataColumn("ID", typeof(int)));
                dt.Columns.Add(new DataColumn("RowNumber", typeof(int)));
                for (int i = 1; i < repeaterContent.Length; i++)
                {
                    dt.Columns.Add(new DataColumn("Col" + i + "", typeof(string)));
                }
            }
            else
            {
                dt = vDt;
            }
            DataRow dtRow = dt.NewRow();
            dtRow["ID"] = 0;
            dtRow["RowNumber"] = repeaterContent[0];
            for (int i = 1; i < repeaterContent.Length; i++)
            {
                dtRow["Col" + i + ""] = repeaterContent[i];
            }
            dt.Rows.Add(dtRow);
            return dt;
        }
        public DataTable GenRptFromTbl(DataTable vDt, string[] repeaterContent)
        {
            DataTable dt = new DataTable();
            if (vDt == null)
            {
                dt.Columns.Add(new DataColumn("ID", typeof(int)));
                dt.Columns.Add(new DataColumn("RowNumber", typeof(int)));

                for (int i = 2; i < repeaterContent.Length; i++)
                {
                    dt.Columns.Add(new DataColumn("Col" + (i - 1) + "", typeof(string)));
                }
            }
            else
            {
                dt = vDt;
            }
            DataRow dtRow = dt.NewRow();
            dtRow["ID"] = repeaterContent[1];
            dtRow["RowNumber"] = repeaterContent[0];
            for (int i = 2; i < repeaterContent.Length; i++)
            {
                dtRow["Col" + (i - 1) + ""] = repeaterContent[i];
            }
            dt.Rows.Add(dtRow);
            return dt;
        }
    }
}