using Stock.BllDalClasses.BllClass.Common;
using Stock.BllDalClasses.BllClass.SearchEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock.Stock.SearchEngine
{
    public partial class SalesSearch : System.Web.UI.Page
    {
        public Boolean Search
        {
            get
            {
                if (ViewState["Search"] != null)
                {
                    return ClsConvertTo.Boolean(ViewState["Search"]);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ViewState["Search"] = value;
            }
        }

        List<string> conName = new List<string>();
        List<string> con = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FxLoadBranch();
                ClsBind.FxComboSelectecIndex(ref ddlBranch, ClsCommon.BranchId.ToString(), "val");
                //ClsBind.FxComboSelectecIndex(ref ddlSubBranch, ClsCommon.SubBranchId.ToString(), "val");
                FxBindFiscalYear();
                ClsBind.FxComboSelectecIndex(ref ddlFiscalYr, ClsCommon.FiscalYear, "txt");

                txtFrom.Text = ClsCommon.ServerDate;
                txtTo.Text = ClsCommon.ServerDate;
            }

        }

        public void FxBindFiscalYear()
        {
            ddlFiscalYr.DataValueField = "ID";
            ddlFiscalYr.DataTextField = "FISCALYEAR";
            conName = new List<string>();
            con = new List<string>();
            conName.Add("status");
            con.Add("1");
            ClsBind.FxLoadCombo(ref ddlFiscalYr, "FISCALYEAR", "FISCALYEAR", "ID", conName, con, "ENGSTARTDATE desc");
            ddlFiscalYr.Items.Insert(0, "");
            ddlFiscalYr.Items[0].Value = "-1";
            ddlFiscalYr.Items[0].Selected = true;
        }
        protected void ddlFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStartEndDate();
        }
        public void BindStartEndDate()
        {
            conName = new List<string>();
            con = new List<string>();
            conName.Add("ID");
            con.Add(ddlFiscalYr.SelectedValue);
            DateTime startdate = ClsConvertTo.DateTime((ClsCommon.CodeDecode("FISCALYEAR", "ENGSTARTDATE", conName, con, "")));
            txtFrom.Text = DBNullHandler.FormatDateTime(startdate);
            DateTime enddate = ClsConvertTo.DateTime((ClsCommon.CodeDecode("FISCALYEAR", "ENGENDDATE", conName, con, "")));
            txtTo.Text = DBNullHandler.FormatDateTime(enddate);
        }

        public void FxLoadBranch()
        {
            try
            {
                conName = new List<string>();
                con = new List<string>();
                ddlBranch.DataValueField = "BRANCHID";
                ddlBranch.DataTextField = "ENAME";

                ClsBind.FxLoadCombo(ref ddlBranch, "MSBRANCH", "BRANCHID", "ENAME", conName, con, "BRANCHID asc");
                ddlBranch.Items.Insert(0, "");
                ddlBranch.Items[0].Value = "-1";
                ddlBranch.Items[0].Selected = true;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;

            }


        }

        protected void ddlFiscalYr_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindStartEndDate();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FxLoadBranch();
            ClsBind.FxComboSelectecIndex(ref ddlBranch, ClsCommon.BranchId.ToString(), "val");
            FxBindFiscalYear();
            ClsBind.FxComboSelectecIndex(ref ddlFiscalYr, ClsCommon.FiscalYear, "txt");

            txtFrom.Text = ClsCommon.ServerDate;
            txtTo.Text = ClsCommon.ServerDate;

            txtBillNo.Text = "";
            txtpartyname.Text = "";

            rptpurchasedetail.DataSource = null;
            rptpurchasedetail.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ClsCommon.applyNewSecurity == 1)
            {
                if (clsSecurityNew.FxCheckUserSecurity((DataTable)ViewState["SECURITY"], "Search", ClsCommon.SubBranchId) == false)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSearch", "alert('You have no permission to Search!');", true);
                    return;
                }
            }

            ClsPurchaseSearchBll objbll = new ClsPurchaseSearchBll();



            objbll.Fiscalid = ClsConvertTo.Int32(ddlFiscalYr.SelectedValue);
            objbll.branchid = ClsConvertTo.Int32(ddlBranch.SelectedValue);
            objbll.Datefrom = ClsConvertTo.DateTime(txtFrom.Text.Trim());
            objbll.DateTo = ClsConvertTo.DateTime(txtTo.Text.Trim());
            objbll.Billno = ClsConvertTo.Int32(txtBillNo.Text.Trim());
            objbll.vendorid = ClsConvertTo.Int32(txtpartyname.Text.Trim());
            DataTable dt = new DataTable();
            dt = objbll.GetSalesDeatils();
            if (dt == null)
            {
                rptpurchasedetail.DataSource = null;
                rptpurchasedetail.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSearch", "alert('Record not found !');", true);
                return;
            }
            if (dt.Rows.Count > 0)
            {
                rptpurchasedetail.DataSource = dt;
                rptpurchasedetail.DataBind();
            }
            else
            {
                rptpurchasedetail.DataSource = null;
                rptpurchasedetail.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSearch", "alert('Record not found !');", true);
                return;
            }
        }

        protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnprint_Click(object sender, EventArgs e)
        {
            try
            {

                //string _repName;
                //string _openfrom;
                //string _PayId;
                //_repName = "";
                //_openfrom = "";
                //if (hdnPurchaseID.Value.Trim() != null)
                //{
                //    if (ClsCommon.PolicyFont == 0) //PICL
                //    {
                //        _repName = "Process/Account/PICL/PICLDisbursmentRpt.rpt";
                //    }
                //    else if (ClsCommon.PolicyFont == 1) // National
                //    {
                //        _repName = "Process/Account/Nat/NatDisbursmentRpt.rpt";
                //    }

                //    _openfrom = "PRINT_PURCHASE_VOUCHER";
                //    _PayId = hdnPurchaseID.Value;
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "window.open('../Reports/RptTemplates.aspx?PrmReportName=" + _repName + "&&PrmOpenFrom=" + _openfrom + "&&PrmPurchaseID=" + _PayId + "','Graph');", true);
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;

            }
        }
        protected void btnChequePrint_Click(object sender, EventArgs e)
        {
            try
            {


                //string _repName;
                //string _openfrom;
                //int _settledid;
                //int _keyid;
                //_repName = "";
                //_openfrom = "";
                //if (hdnPurchaseID.Value.Trim() != null)
                //{
                //    _repName = "Process/Account/" + ClsCommon.Rep_Path_Alias + "/Rptchequeprinting.rpt";
                //    _openfrom = "CHQPRINT";
                //    _settledid = ClsConvertTo.Int32(hdnPurchaseID.Value);
                //    _keyid = 7;
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "window.open('../Reports/RptTemplates.aspx?PrmReportName=" + _repName + "&&PrmOpenFrom=" + _openfrom + "&&SettledID=" + _settledid + "&&KeyId=" + _keyid + "','Graph');", true);
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;

            }
        }
    }
}