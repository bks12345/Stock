using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

namespace Stock.BllClass.Common
{
    public class clsDynamicGridView
    {
        public DataTable FirstGridViewRow(int colNo)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            for (int i = 1; i <= colNo; i++)
            {
                dt.Columns.Add(new DataColumn("Col"+i+"", typeof(string)));
            }
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            for (int i = 1; i <= colNo; i++)
            {
                dr["Col" + i + ""] = string.Empty; 
            }
            dt.Rows.Add(dr);
            return dt;
        }
        public DataTable AddNewRow(DataTable Vdt, string[] gridContent)
        {
            int rowIndex = 0;

            if (Vdt != null)
            {
                DataTable dtCurrentTable = Vdt;
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        i = dtCurrentTable.Rows.Count;
                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        for (int x = 0; x < gridContent.Length; x++)
                        {
                            dtCurrentTable.Rows[i - 1]["Col" + (x + 1) + ""] = gridContent[x];
                        }
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                }
                return dtCurrentTable;
            }
            return null;
        }
        //private void SetPreviousData()
        //{
        //    int rowIndex = 0;
        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dt = (DataTable)ViewState["CurrentTable"];
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                Label lblMemberNameEng = (Label)gdvOrg.Rows[rowIndex].Cells[1].FindControl("lblMemberNameEng");
        //                Label lblMemberNameNep = (Label)gdvOrg.Rows[rowIndex].Cells[2].FindControl("lblMemberNameNep");
        //                Label lblAddressEng = (Label)gdvOrg.Rows[rowIndex].Cells[3].FindControl("lblAddressEng");
        //                Label lblAddressNep = (Label)gdvOrg.Rows[rowIndex].Cells[4].FindControl("lblAddressNep");
        //                Label lblCitizenShipNo = (Label)gdvOrg.Rows[rowIndex].Cells[5].FindControl("lblCitizenshipNo");
        //                Label lblPassportNo = (Label)gdvOrg.Rows[rowIndex].Cells[6].FindControl("lblPassportNo");
        //                Label lblLicenseNo = (Label)gdvOrg.Rows[rowIndex].Cells[7].FindControl("lblLicenseNo");
        //                Label lblPhone = (Label)gdvOrg.Rows[rowIndex].Cells[8].FindControl("lblPhone");
        //                Label lblMobile = (Label)gdvOrg.Rows[rowIndex].Cells[9].FindControl("lblMobile");
        //                Label lblStatus = (Label)gdvOrg.Rows[rowIndex].Cells[10].FindControl("lblStatus");
        //                Label lblEmail = (Label)gdvOrg.Rows[rowIndex].Cells[11].FindControl("lblEmail");
        //                Label lblPath = (Label)gdvOrg.Rows[rowIndex].Cells[12].FindControl("lblPhotoPath");


        //                lblMemberNameEng.Text = dt.Rows[i]["Col1"].ToString();
        //                lblMemberNameNep.Text = dt.Rows[i]["Col2"].ToString();
        //                lblAddressEng.Text = dt.Rows[i]["Col3"].ToString();
        //                lblAddressNep.Text = dt.Rows[i]["Col4"].ToString();
        //                lblCitizenShipNo.Text = dt.Rows[i]["Col5"].ToString();
        //                lblPassportNo.Text = dt.Rows[i]["Col6"].ToString();
        //                lblLicenseNo.Text = dt.Rows[i]["Col7"].ToString();
        //                lblPhone.Text = dt.Rows[i]["Col8"].ToString();
        //                lblMobile.Text = dt.Rows[i]["Col9"].ToString();
        //                lblStatus.Text = dt.Rows[i]["Col10"].ToString();
        //                lblEmail.Text = dt.Rows[i]["Col11"].ToString();
        //                lblPath.Text = dt.Rows[i]["Col12"].ToString();
        //                rowIndex++;
        //            }
        //        }
        //    }
        //}
        //private void SetRowData()
        //{
        //    int rowIndex = 0;

        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //        DataRow drCurrentRow = null;
        //        if (dtCurrentTable.Rows.Count > 0)
        //        {
        //            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        //            {
        //                Label lblMemberNameEng = (Label)gdvOrg.Rows[rowIndex].Cells[1].FindControl("lblMemberNameEng");
        //                Label lblMemberNameNep = (Label)gdvOrg.Rows[rowIndex].Cells[2].FindControl("lblMemberNameNep");
        //                Label lblAddressEng = (Label)gdvOrg.Rows[rowIndex].Cells[3].FindControl("lblAddressEng");
        //                Label lblAddressNep = (Label)gdvOrg.Rows[rowIndex].Cells[4].FindControl("lblAddressNep");
        //                Label lblCitizenShipNo = (Label)gdvOrg.Rows[rowIndex].Cells[5].FindControl("lblCitizenshipNo");
        //                Label lblPassportNo = (Label)gdvOrg.Rows[rowIndex].Cells[6].FindControl("lblPassportNo");
        //                Label lblLicenseNo = (Label)gdvOrg.Rows[rowIndex].Cells[7].FindControl("lblLicenseNo");
        //                Label lblPhone = (Label)gdvOrg.Rows[rowIndex].Cells[8].FindControl("lblPhone");
        //                Label lblMobile = (Label)gdvOrg.Rows[rowIndex].Cells[9].FindControl("lblMobile");
        //                Label lblStatus = (Label)gdvOrg.Rows[rowIndex].Cells[10].FindControl("lblStatus");
        //                Label lblEmail = (Label)gdvOrg.Rows[rowIndex].Cells[11].FindControl("lblEmail");
        //                Label lblPath = (Label)gdvOrg.Rows[rowIndex].Cells[12].FindControl("lblPhotoPath");
        //                drCurrentRow = dtCurrentTable.NewRow();
        //                drCurrentRow["RowNumber"] = i + 1;
        //                dtCurrentTable.Rows[i - 1]["Col1"] = lblMemberNameEng.Text;
        //                dtCurrentTable.Rows[i - 1]["Col2"] = lblMemberNameNep.Text;
        //                dtCurrentTable.Rows[i - 1]["Col3"] = lblAddressEng.Text;
        //                dtCurrentTable.Rows[i - 1]["Col4"] = lblAddressNep.Text;
        //                dtCurrentTable.Rows[i - 1]["Col5"] = lblCitizenShipNo.Text;
        //                dtCurrentTable.Rows[i - 1]["Col6"] = lblPassportNo.Text;
        //                dtCurrentTable.Rows[i - 1]["Col7"] = lblLicenseNo.Text;
        //                dtCurrentTable.Rows[i - 1]["Col8"] = lblPhone.Text;
        //                dtCurrentTable.Rows[i - 1]["Col9"] = lblMobile.Text;
        //                dtCurrentTable.Rows[i - 1]["Col10"] = lblStatus.Text;
        //                dtCurrentTable.Rows[i - 1]["Col11"] = lblEmail.Text;
        //                dtCurrentTable.Rows[i - 1]["Col12"] = lblPath.Text;
        //                rowIndex++;
        //            }

        //            ViewState["CurrentTable"] = dtCurrentTable;
        //            //grvStudentDetails.DataSource = dtCurrentTable;
        //            //grvStudentDetails.DataBind();
        //        }
        //    }
        //    else
        //    {
        //        Response.Write("ViewState is null");
        //    }
        //    //SetPreviousData();
        //}
    }
}