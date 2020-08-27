using Stock.BllClass.Common;
using Stock.BllDalClasses.BllClass.Common;
using Stock.BllDalClasses.BllClass.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock.Stock.Process
{
    public partial class SalesEntry : System.Web.UI.Page
    {
        List<string> conName = new List<string>();
        List<string> con = new List<string>();
        public static bool editmode;
        public Boolean SAVE
        {
            get
            {
                if (ViewState["SAVE"] != null)
                {
                    return ClsConvertTo.Boolean(ViewState["SAVE"]);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ViewState["SAVE"] = value;
            }
        }
        public Boolean EDIT
        {
            get
            {
                if (ViewState["EDIT"] != null)
                {
                    return ClsConvertTo.Boolean(ViewState["EDIT"]);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ViewState["EDIT"] = value;
            }
        }
        public Boolean NEW
        {
            get
            {
                if (ViewState["NEW"] != null)
                {
                    return ClsConvertTo.Boolean(ViewState["NEW"]);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ViewState["NEW"] = value;
            }
        }
        public Boolean PRINT
        {
            get
            {
                if (ViewState["PRINT"] != null)
                {
                    return ClsConvertTo.Boolean(ViewState["PRINT"]);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ViewState["PRINT"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FxSecurityAccess();
                FxLoadBranch();
                ClsBind.FxComboSelectecIndex(ref ddlBranch, ClsCommon.BranchId.ToString(), "val");
                FxBindFiscalYear();
                ClsBind.FxComboSelectecIndex(ref ddlFiscalYr, ClsCommon.FiscalYear, "txt");

                txtEDate.Text = ClsCommon.ServerDate;
                txtBillDate.Text = ClsCommon.ServerDate;
                string nepalidate;
                //nepalidate = SemNepaliDate.FxGetEngToNepDate(txtEDate.Text);
                //txtNDate.Text = nepalidate;
                //txtNBillDate.Text = nepalidate;
                pnlEntry.Enabled = false;
                panelEntry2.Enabled = false;
                txttransactionno.Enabled = true;
                txtNDate.Enabled = false;
                txtNBillDate.Enabled = false;
                FXBindBankDis();
                PaymentMode();
                if (ddlVatOption.SelectedValue == "0")
                {
                    txtvatper.Text = "13";
                }
            }
        }
        public void FxSecurityAccess()
        {
            if (ClsCommon.applyNewSecurity == 1)
            {
                string _SecurityName = "Save,New,Edit,Print";
                DataTable dtSec = clsSecurityNew.FxGetSecurityAccessBranch_Security_New("04 Account", "Purchase Entry", _SecurityName);
                ViewState["SECURITY"] = dtSec;
                if (dtSec == null)
                {
                    NEW = false;
                    SAVE = false;
                    EDIT = false;
                    PRINT = false;

                }
                else
                {
                    if (dtSec.Rows.Count == 0)
                    {
                        NEW = false;
                        SAVE = false;
                        EDIT = false;
                        PRINT = false;

                    }
                    else
                    {
                        NEW = clsSecurityNew.FxHasUserSecurity(dtSec, "New");
                        SAVE = clsSecurityNew.FxHasUserSecurity(dtSec, "Save");
                        EDIT = clsSecurityNew.FxHasUserSecurity(dtSec, "Edit");
                        PRINT = clsSecurityNew.FxHasUserSecurity(dtSec, "Print");



                    }
                }
                if (ClsCommon.IsAdmin)
                {
                    NEW = true;
                    SAVE = true;
                    EDIT = true;
                    PRINT = true;
                }
            }
        }
        public void FxBindFiscalYear()
        {
            ddlFiscalYr.DataTextField = "FISCALYEAR";
            ddlFiscalYr.DataValueField = "ID";
            conName = new List<string>();
            con = new List<string>();
            conName.Add("status");
            con.Add("1");
            ClsBind.FxLoadCombo(ref ddlFiscalYr, "FISCALYEAR", "FISCALYEAR", "ID", conName, con, "ENGSTARTDATE desc");
            ddlFiscalYr.Items.Insert(0, "");
            ddlFiscalYr.Items[0].Value = "-1";
            ddlFiscalYr.Items[0].Selected = true;
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
        public void FxBindPartyName()
        {

        }



        protected void btnNewVoucher_Click(object sender, EventArgs e)
        {
            if (ClsCommon.applyNewSecurity == 1)
            {
            }


            txttransactionno.Text = "";
            FxBindPartyName();
            editmode = false;
            pnlEntry.Enabled = true;
            panelEntry2.Enabled = true;
            pnlyeardetail.Enabled = false;

            lbitems.DataSource = "";
            lbitems.DataBind();
            //lbitems.Items.Insert(0, "None");
            //lbitems.Items[0].Value = "-1";
            //lbitems.Items[0].Selected = true;
            btnEdit.Enabled = false;


        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            editmode = true;
            rptpurchaseentry.DataSource = null;
            rptpurchaseentry.DataBind();
            ViewState["getdetail"] = null;
            if (txttransactionno.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Please Insert Transaction no!');", true);
                return;
            }

            ClsSalesBll objbll = new ClsSalesBll();
            objbll.Transactionno = ClsConvertTo.Int32(txttransactionno.Text);
            objbll.branchid = ClsConvertTo.Int32(ddlBranch.SelectedValue);
            objbll.Fiscalid = ClsConvertTo.Int32(ddlFiscalYr.SelectedValue);
            DataSet ds = objbll.GetAllPurchasedetails();

            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            // dt = objbll.GetPurchaseDetails();
            dt1 = ds.Tables[0];
            dt = ds.Tables[1];
            if (dt1 != null)
            {
                if (dt1.Rows.Count > 0)
                {
                    txtid.Text = dt1.Rows[0]["PurchaseID"].ToString();

                    ddlFiscalYr.SelectedValue = dt1.Rows[0]["Fiscalid"].ToString();
                    ddlBranch.SelectedValue = dt1.Rows[0]["branchid"].ToString();
                    // ddlSubBranch.SelectedValue = dt.Rows[0]["subbranchid"].ToString();
                    txtEDate.Text = DBNullHandler.FormatDateTime(dt1.Rows[0]["pdate"].ToString());
                    txtNDate.Text = dt1.Rows[0]["ndate"].ToString();
                    FxBindPartyName();
                    //ddlPartyName.SelectedValue = dt1.Rows[0]["vendorid"].ToString();
                    ddlVatOption.SelectedValue = dt1.Rows[0]["vatoptionid"].ToString();
                    ddlPurchaseType.SelectedValue = dt1.Rows[0]["pTypeid"].ToString();
                    txtBillNumber.Text = dt1.Rows[0]["billno"].ToString();
                    txtRemarks.Text = dt1.Rows[0]["Remarks"].ToString();

                    ddlBillType.SelectedValue = dt1.Rows[0]["BillType"].ToString();
                    txtBillDate.Text = DBNullHandler.FormatDateTime(dt1.Rows[0]["BillDate"].ToString());
                    txtNBillDate.Text = dt1.Rows[0]["BillDateNep"].ToString();

                    txttotal.Text = dt1.Rows[0]["pAmount"].ToString();
                    txtvatper.Text = dt1.Rows[0]["pVatRate"].ToString();
                    txtvatamt.Text = dt1.Rows[0]["pVatAmt"].ToString();
                    txtnetpayable.Text = dt1.Rows[0]["pNetamt"].ToString();

                    if (ClsConvertTo.Int32(dt1.Rows[0]["BankID"].ToString()) > 0)
                    {

                        //ddlChequeBank.SelectedValue = dt1.Rows[0]["BankID"].ToString();
                        ClsBind.FxComboSelectecIndex(ref ddlChequeBank, dt1.Rows[0]["BankID"].ToString(), "val");
                        if (ClsConvertTo.Int32(ddlChequeBank.SelectedValue) < 1)
                        {
                            ddlChequeBank.SelectedIndex = -1;
                            chkBankName.Checked = true;
                            chkBankName_CheckedChanged(sender, e);
                            ddlChequeBank.SelectedValue = dt1.Rows[0]["BankID"].ToString();
                        }

                    }
                    //ClsBind.FxComboSelectecIndex(ref ddlpaymenttype, dt1.Rows[0]["BankID"].ToString(), "val");
                    txtChequeDate.Text = DBNullHandler.FormatDateTime(dt1.Rows[0]["Cheqdt"].ToString());
                    txtCheqNo.Text = dt1.Rows[0]["CheqNo"].ToString();
                    txtCheqAmt.Text = dt1.Rows[0]["CheqAmt"].ToString();
                    txtpartyname.Text = dt1.Rows[0]["partyname"].ToString();

                    txtdisperc.Text = dt1.Rows[0]["pdiscRate"].ToString();
                    txtdiscountamt.Text = dt1.Rows[0]["pdiscAmt"].ToString();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('No record found!');", true);
                    return;
                }
                if (dt.Rows.Count > 0)
                {
                    rptpurchaseentry.DataSource = dt;
                    ViewState["getdetail"] = dt;
                    ViewState["SN"] = dt.Rows.Count;
                    rptpurchaseentry.DataBind();
                }

                pnlEntry.Enabled = true;
                panelEntry2.Enabled = true;
                pnlyeardetail.Enabled = false;

                lbitems.DataSource = "";
                lbitems.DataBind();
                //lbitems.Items.Insert(0, "None");
                //lbitems.Items[0].Value = "-1";
                //lbitems.Items[0].Selected = true;
                //txttransactionno.Enabled = true;
            }





        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //int pid = ClsConvertTo.Int32(hdnid.Value);
            try
            {


                //int k;
                //k = FieldValidation();
                //if (k == 1)
                //{
                //    return;
                //}
                if (ClsConvertTo.Decimal(txtCheqAmt.Text) > 0)
                {
                    if (ddlpaymenttype.SelectedValue == "1")
                    {
                        if (ddlChequeBank.SelectedValue == "0")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('Please Select Bank!');", true);
                            ddlChequeBank.Focus();
                            return;
                        }
                        if (txtCheqNo.Text == "" || txtCheqNo.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('Please Enter Cheque No!');", true);
                            txtCheqNo.Focus();
                            return;
                        }
                        if (txtChequeDate.Text == "" || txtChequeDate.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('Please Enter Cheque Date!');", true);
                            txtChequeDate.Focus();
                            return;
                        }
                    }

                }
                if (ddlVatOption.SelectedValue == "0")
                {
                    if (ClsConvertTo.Decimal(txtvatper.Text) != 13)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('VAT Rate must be 13 !');", true);
                        return;
                    }
                    if (ClsConvertTo.Decimal(txtvatamt.Text) <= 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('There must be a VAT amount when Vatable option is selected!');", true);
                        return;
                    }
                }
                if (ClsConvertTo.Decimal(txtnetpayable.Text) != (ClsConvertTo.Decimal(txtCheqAmt.Text)))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('Net Payable Amount And Sum of Cheque Amount Must be equal!');", true);
                    return;
                }

                string _msg = string.Empty, PurcID = string.Empty;

                DataTable dt = new DataTable();
                dt = (DataTable)ViewState["getdetail"];
                if (dt != null)
                {
                    string msg;
                    ClsSalesBll objbll = new ClsSalesBll();
                    objbll.Fiscalid = ClsConvertTo.Int32(ddlFiscalYr.SelectedValue);
                    objbll.branchid = ClsConvertTo.Int32(ddlBranch.SelectedValue);
                    objbll.pdate = ClsConvertTo.DateTime(txtEDate.Text.Trim());
                    objbll.ndate = txtNDate.Text.Trim();
                    //objbll.vendorid = ClsConvertTo.Int32(ddlPartyName.SelectedValue);
                    objbll.vatoptionid = ClsConvertTo.Int32(ddlVatOption.SelectedValue);
                    objbll.pTypeid = ClsConvertTo.Int32(ddlPurchaseType.SelectedValue);
                    objbll.billno = txtBillNumber.Text.Trim();

                    objbll.BillType = ClsConvertTo.Int32(ddlBillType.SelectedValue);
                    objbll.BillDate = ClsConvertTo.DateTime(txtBillDate.Text.Trim());
                    objbll.BillDateNep = txtNBillDate.Text;

                    objbll.Remarks = txtRemarks.Text.Trim();
                    objbll.pAmount = ClsConvertTo.Decimal(txttotal.Text.Trim());
                    objbll.pVatAmt = ClsConvertTo.Decimal(txtvatamt.Text.Trim());
                    objbll.pNetAmt = ClsConvertTo.Decimal(txtnetpayable.Text.Trim());
                    objbll.pVatRate = ClsConvertTo.Decimal(txtvatper.Text.Trim());

                    objbll.BankID = ClsConvertTo.Int32(ddlChequeBank.SelectedValue);
                    objbll.CheqNo = txtCheqNo.Text;
                    //if (ClsCommon.FxIsValidDate(txtChequeDate.Text))
                    //{
                    objbll.CheqDate = ClsConvertTo.DateTime(txtChequeDate.Text);
                    //}
                    objbll.CheqAmt = ClsConvertTo.Decimal(txtCheqAmt.Text);

                    objbll.dtpurchaseentrydetails = dt;
                    objbll.uuid = ClsConvertTo.Int32(ClsCommon.UserCode);
                    if (editmode == true)
                    {

                        objbll.PurchaseID = ClsConvertTo.Int32(txtid.Text.Trim());
                    }
                    objbll.partyname = txtpartyname.Text.Trim();
                    objbll.pdiscAmt = ClsConvertTo.Decimal(txtdiscountamt.Text.Trim());
                    objbll.pdiscRate = ClsConvertTo.Decimal(txtdisperc.Text.Trim());
                    msg = objbll.InsertUpdate_PurchaseEntry();

                    if (msg != null)
                    {
                        string[] strSplit = msg.Split('/');
                        _msg = strSplit[0].ToString();
                        PurcID = strSplit[1].ToString();

                        if (_msg == "insert")
                        {
                            txtid.Text = PurcID;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Data Saved Successfully!');", true);



                        }
                        if (_msg == "update")
                        {
                            txtid.Text = PurcID;
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Data Updated Successfully!');", true);

                        }
                        if (_msg.Contains("error"))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('There was some error while saving data!');", true);
                            return;
                        }
                    }

                }
                FxClearControl(Page.Controls);

                FxClearAll();
                ViewState["getdetail"] = null;
                txtEDate.Text = ClsCommon.ServerDate;
                string nepalidate;
                //nepalidate = SemNepaliDate.FxGetEngToNepDate(txtEDate.Text);
                //txtNDate.Text = nepalidate;
                txtBillDate.Text = ClsCommon.ServerDate;
                txtNBillDate.Text = ClsCommon.ServerDate;
                btnEdit.Enabled = true;
                txtvatper.Enabled = true;
                txtid.Text = PurcID;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;
            }


        }

        protected void chkBankName_CheckedChanged(object sender, EventArgs e)
        {
            //fxChequeBank();
            //try
            //{
            //    if (chkBankName.Checked == true)
            //    {
            //        ClsDefaultbankBll obj = new ClsDefaultbankBll();
            //        //ddlChequeBank.DataSource = null;
            //        //ddlChequeBank.DataBind();
            //        ddlChequeBank.Items.Clear();
            //        obj.BranchId = ClsConvertTo.Int32(ddlBranch.SelectedValue);
            //        obj.SUBBRANCHID = ClsConvertTo.Int32(ddlSubBranch.SelectedValue);
            //        //obj.ModuleId = 2;
            //        DataTable dt = new DataTable();
            //        dt = obj.getallbankcode();
            //        ddlChequeBank.DataSource = dt;
            //        ddlChequeBank.DataBind();
            //        ddlChequeBank.Enabled = true;
            //    }
            //    else
            //    {
            //        //FxBindBank();
            //        FXBindBankDis();
            //        ddlChequeBank.Enabled = true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
            //    return;

            //}
        }
        protected void FXBindBankDis()
        {
            try
            {
                //ClsDefaultbankBll obj = new ClsDefaultbankBll();
                //ddlChequeBank.DataSource = null;
                //ddlChequeBank.DataBind();
                //obj.BranchId = ClsConvertTo.Int32(ddlBranch.SelectedValue);
                //obj.SUBBRANCHID = ClsConvertTo.Int32(ddlSubBranch.SelectedValue);
                ////if (ddlDisbursementType.SelectedValue == "15")
                ////{
                ////    obj.ModuleId = 8;
                ////} if (ddlDisbursementType.SelectedValue == "17")
                ////{
                ////    obj.ModuleId = 9;
                ////}
                //// obj.ModuleId = 2;
                ////obj.ID =2;
                ////DataTable dtmoduleid = obj.GetModuleid();
                ////obj.ModuleId = ClsConvertTo.Int32(dtmoduleid.Rows[0]["moduleid"].ToString());

                ////made module id hardcore as said by sundar dai ...bikesh 2018/10/24
                //obj.ModuleId = (int)Enum_DefaultBankModule.Purchase_entry; //module id 11 for purchase entry in defmodule
                //obj.ISFLAG = 1;
                //DataTable dt = new DataTable();
                //dt = obj.getdefaultbank();
                //ddlChequeBank.DataSource = dt;
                //ddlChequeBank.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;

            }
        }
        protected void FxBindBank()
        {
            try
            {
                //ClsDefaultbankBll obj = new ClsDefaultbankBll();
                //ddlChequeBank.DataSource = null;
                //ddlChequeBank.DataBind();
                //obj.BranchId = ClsConvertTo.Int32(ddlBranch.SelectedValue);
                //obj.SUBBRANCHID = ClsConvertTo.Int32(ddlSubBranch.SelectedValue);
                ////if (ddlDisbursementType.SelectedValue == "15")
                ////{
                ////    obj.ModuleId = 8;
                ////} if (ddlDisbursementType.SelectedValue == "17")
                ////{
                ////    obj.ModuleId = 9;
                ////}
                //// obj.ModuleId = 2;

                //obj.ModuleId = 8;
                //obj.ISFLAG = 1;
                //DataTable dt = new DataTable();
                //dt = obj.getdefaultbank();
                //ddlChequeBank.DataSource = dt;
                //ddlChequeBank.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;

            }

            //ClsBind.FxLoadCombo(ref ddlBankName, "vw_defaultbank", "ACCOUNTCODE", "ACCOUNTDESC", conName, con);
        }
        protected void txtEDate_TextChanged(object sender, EventArgs e)
        {
            string nepalidate;
            //nepalidate = SemNepaliDate.FxGetEngToNepDate(txtEDate.Text);
            //txtNDate.Text = nepalidate;
        }

        protected void txtBillDate_TextChanged(object sender, EventArgs e)
        {
            string nepalidate;
            //nepalidate = SemNepaliDate.FxGetEngToNepDate(txtBillDate.Text);
            //txtNBillDate.Text = nepalidate;
        }
        protected void txtitem_TextChanged(object sender, EventArgs e)
        {
            GetItemList();


        }

        private void GetItemList()
        {
            ClsSalesBll objbll = new ClsSalesBll();
            objbll.EDESCRIPTION = txtitem.Text.Trim();
            DataTable dt = new DataTable();
            dt = objbll.GetPurchaseItem();
            if (dt.Rows.Count > 0)
            {
                lbitems.DataSource = null;
                lbitems.DataBind();
                lbitems.DataTextField = "";
                lbitems.DataValueField = "";
                lbitems.DataTextField = "EDESCRIPTION";
                lbitems.DataValueField = "PRODUCTID";
                lbitems.DataSource = dt;

                lbitems.DataBind();
            }
        }

        protected void txtitemsearch_Click(object sender, EventArgs e)
        {
            GetItemList();
        }


        #region add repeator
        protected void btnadd_Click(object sender, EventArgs e)
        {


            if (lbitems.Items.Count > 0 && txtrate.Text != "" && txtquantity.Text != "")
            {


                //if (lbitems.SelectedValue != "-1")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Please Select Items!');", true);
                //    return;
                //}
                //if (txtrate.Text != "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Please Insert Rate!');", true);
                //    return;
                //}
                //if (txtquantity.Text != "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Please Insert Quantity!');", true);
                //    return;
                //}
                DataTable dt = new DataTable();
                dt = GetPurchaseEntry();
                if (ViewState["getdetail"] != null)
                {
                    dt = (DataTable)ViewState["getdetail"];
                    rptpurchaseentry.DataSource = dt;
                    rptpurchaseentry.DataBind();

                }
                else
                {
                    rptpurchaseentry.DataSource = null;
                    rptpurchaseentry.DataBind();
                }

                //FxCalcTotalPayable();
                //clearcontrols();
                btnadd.Text = "Add";
                FxcalcTotalPayable();
                CalcVatnDis();
                CalcNetPayable();

                lbitems.DataSource = "";
                lbitems.DataBind();
                //lbitems.Items.Insert(0, "None");
                //lbitems.Items[0].Value = "-1";
                //lbitems.Items[0].Selected = true;

                txtrate.Text = "";
                txtquantity.Text = "";
                txtamount.Text = "";
                txtitem.Text = "";
                chkisvatable.Checked = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Please Insert Quantity, Rate And Item!');", true);
                return;
            }




        }
        public DataTable GetPurchaseEntry()
        {
            DataTable dt = (DataTable)ViewState["getdetail"];
            if (ViewState["getdetail"] != null)
            {
                int sn = ClsConvertTo.Int32((ViewState["SN"]));
                sn++;
                ViewState["SN"] = sn;
            }
            else
            {
                ViewState["SN"] = 1;
            }
            clsRptBll objRpt = new clsRptBll();
            string[] content = { ViewState["SN"].ToString(),
                                   lbitems.SelectedItem.Text,
                                   txtrate.Text.Trim(),
                                   txtquantity.Text.Trim(),
                                   txtamount.Text.Trim(),
                                   lbitems.SelectedValue,
                                   chkisvatable.Checked?"1":"0"

                               };
            string[] header = { "ROWNUMBER",
                                  "item",
                                  "rate",
                                  "quantity",
                                
                                  "amount",
                                  "itemid",
                                  "isvatable"
                                  
                              };
            if (ViewState["getdetail"] != null)
            {
                DataTable checkDt = (DataTable)ViewState["getdetail"];
                int check = checkDt.Rows.Count;
                int sn = ClsConvertTo.Int32(hdnrownum.Value);
                int status = 0;
                for (int i = 0; i < check; i++)
                {
                    if (checkDt.Rows[i]["ROWNUMBER"].ToString() == hdnrownum.Value)
                    {
                        if (btnadd.Text == "update")
                        {

                            checkDt.Rows[i]["item"] = lbitems.SelectedItem.Text;
                            checkDt.Rows[i]["rate"] = txtrate.Text.Trim();
                            checkDt.Rows[i]["quantity"] = txtquantity.Text.Trim();
                            checkDt.Rows[i]["amount"] = txtamount.Text.Trim();
                            checkDt.Rows[i]["itemid"] = lbitems.SelectedValue;
                            checkDt.Rows[i]["isvatable"] = chkisvatable.Checked ? "1" : "0";

                            status = 1;
                            hdnrownum.Value = "";



                        }
                        else
                        {
                            status = 2;//for duplicate
                            int SnoAdd = ClsConvertTo.Int32(ViewState["SN"]);
                            SnoAdd--;
                            ViewState["SN"] = SnoAdd;
                            break;
                        }


                    }
                }
                if (status == 1)//update
                {
                    dt = checkDt;
                }
                else if (status == 2)//duplicate
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "err_msg", "alert(' already exist!');", true);
                }
                else//add next row
                {
                    dt = clsRpt.GenerateRepeatorForImport((DataTable)ViewState["getdetail"], content, header);
                }
            }
            else
            {

                dt = clsRpt.GenerateRepeatorForImport((DataTable)ViewState["getdetail"], content, header);
            }


            ViewState["getdetail"] = null;
            ViewState["getdetail"] = dt;
            ViewState["SN"] = null;
            ViewState["SN"] = dt.Rows.Count;
            //ViewState["TblGAcc"] = dt;
            return dt;
        }
        protected void btnbind_Click(object sender, EventArgs e)
        {
            // clsVendorNameBll obj = new clsVendorNameBll();
            DataTable dt = new DataTable();
            int Sn = ClsConvertTo.Int32(hdnrownum.Value);
            dt = (DataTable)ViewState["getdetail"];
            foreach (DataRow row in dt.Rows)
            {
                if (ClsConvertTo.Int32(row["RowNumber"].ToString()) == Sn)
                {
                    hdnrownum.Value = row["ROWNUMBER"].ToString();
                    //lbitems.SelectedItem.Text = row["item"].ToString();
                    txtrate.Text = row["rate"].ToString();
                    txtquantity.Text = row["quantity"].ToString();
                    txtamount.Text = row["amount"].ToString();
                    chkisvatable.Checked = ClsConvertTo.Boolean(row["isvatable"].ToString());
                    //lbitems.SelectedValue = row["itemid"].ToString();
                    //ClsBind.FxComboSelectecIndex(ref lbitems, row["itemid"].ToString(), "val");
                    //lbitems.Items[0].Selected = true;

                    Dictionary<string, string> States = new Dictionary<string, string>();
                    States.Add(row["itemid"].ToString(), row["item"].ToString());

                    lbitems.DataSource = States;
                    lbitems.DataValueField = "Key";
                    lbitems.DataTextField = "Value";
                    lbitems.DataBind();
                    States.Clear();



                    ClsBind.FxComboSelectecIndex(ref lbitems, row["itemid"].ToString(), "val");

                }
            }

            btnadd.Text = "update";

        }
        #endregion
        #region calculation
        protected void FxcalcTotalPayable()
        {
            try
            {
                DataTable dt = (DataTable)rptpurchaseentry.DataSource;

                decimal sum = 0;

                foreach (RepeaterItem item in rptpurchaseentry.Items)
                {

                    Label sfeeamt = item.FindControl("lblamount") as Label;
                    decimal _sfeeamnt = ClsConvertTo.Decimal(sfeeamt.Text);


                    sum = sum + _sfeeamnt;



                }

                txttotal.Text = sum.ToString();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;
            }
        }
        protected void CalcVatnDis()
        {
            decimal _amnt = ClsConvertTo.Decimal(txttotal.Text);
            decimal _dispercent = ClsConvertTo.Decimal(txtdisperc.Text);
            decimal _vatpercent = ClsConvertTo.Decimal(txtvatper.Text);
            //decimal _tdspercent = ClsConvertTo.Decimal(txttdsper.Text);

            decimal _discount = (_amnt / 100) * _dispercent;
            txtdiscountamt.Text = _discount.ToString("0.00");

            decimal _vat = (_amnt / 100) * _vatpercent;
            txtvatamt.Text = _vat.ToString("0.00");
        }
        protected void CalcNetPayable()
        {

            decimal _amnt = ClsConvertTo.Decimal(txttotal.Text);

            decimal _disamnt = ClsConvertTo.Decimal(txtdiscountamt.Text);
            decimal _vatamnt = ClsConvertTo.Decimal(txtvatamt.Text);
            //decimal _tdsamnt = ClsConvertTo.Decimal(txttdsamt.Text);

            decimal _netpayable = _amnt - _disamnt + _vatamnt;

            txtnetpayable.Text = Math.Round(_netpayable, 2).ToString();
            txtCheqAmt.Text = _netpayable.ToString();

        }
        protected void txtquantity_TextChanged(object sender, EventArgs e)
        {
            decimal _rate = ClsConvertTo.Decimal(txtrate.Text);
            int _quantity = ClsConvertTo.Int32(txtquantity.Text);
            decimal _amount = _rate * _quantity;
            txtamount.Text = _amount.ToString();
        }

        protected void txtrate_TextChanged(object sender, EventArgs e)
        {
            decimal _rate = ClsConvertTo.Decimal(txtrate.Text);
            int _quantity = ClsConvertTo.Int32(txtquantity.Text);
            decimal _amount = _rate * _quantity;
            txtamount.Text = _amount.ToString();
        }

        protected void txtvatper_TextChanged(object sender, EventArgs e)
        {
            CalcVatnDis();
            CalcNetPayable();
        }

        protected void txtdisperc_TextChanged(object sender, EventArgs e)
        {
            CalcVatnDis();
            CalcNetPayable();
        }
        #endregion
        private void FxClearControl(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Text = string.Empty;
                    ((TextBox)ctrl).Style.Add("border", "");
                }
                else if (ctrl is DropDownList)
                {
                    ((DropDownList)ctrl).ClearSelection();
                    ((DropDownList)ctrl).Style.Add("border", "");
                }
                else if (ctrl is RadioButtonList)
                    ((RadioButtonList)ctrl).ClearSelection();
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Checked = false;

                FxClearControl(ctrl.Controls);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            FxClearControl(Page.Controls);
            FxClearAll();
            txtEDate.Text = ClsCommon.ServerDate;
            string nepalidate;
            //nepalidate = SemNepaliDate.FxGetEngToNepDate(txtEDate.Text);
            //txtNDate.Text = nepalidate;
            btnEdit.Enabled = true;
            ViewState["getdetail"] = null;
        }

        private void FxClearAll()
        {
            FxLoadBranch();
            ClsBind.FxComboSelectecIndex(ref ddlBranch, ClsCommon.BranchId.ToString(), "val");
            FxBindFiscalYear();
            ClsBind.FxComboSelectecIndex(ref ddlFiscalYr, ClsCommon.FiscalYear, "txt");

            lbitems.DataSource = "";
            lbitems.DataBind();
            //lbitems.Items.Insert(0, "None");
            //lbitems.Items[0].Value = "-1";
            //lbitems.Items[0].Selected = true;

            rptpurchaseentry.DataSource = null;
            rptpurchaseentry.DataBind();

            pnlyeardetail.Enabled = true;
            pnlEntry.Enabled = false;
            panelEntry2.Enabled = false;
        }
        #region For Validation
        public int FieldValidation()
        {
            int j = 0;
            List<string> list = new List<string>();
            try
            {
                list = checkIsEmpty();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == "" || list[i] == "-1")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('* field is required!!!');", true);
                        j = 1;
                        break;
                    }
                }
                return j;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<string> checkIsEmpty()
        {
            List<string> list = new List<string>();
            try
            {

                if (txtBillNumber.Text.Trim() == "")
                {
                    txtBillNumber.Style.Add("border", "1px solid red;");
                    list.Add(txtBillNumber.Text);
                }
                else
                {
                    txtBillNumber.Style.Add("border", "");
                    list.Add(txtBillNumber.Text);
                }
                if (ddlChequeBank.SelectedValue == "-1")
                {
                    ddlChequeBank.Style.Add("border", "1px solid red");
                    list.Add(ddlChequeBank.SelectedValue);
                }
                else
                {
                    ddlChequeBank.Style.Add("border", "");
                    list.Add(ddlChequeBank.SelectedValue);
                }
                if (ddlpaymenttype.SelectedValue == "1")
                {

                    //if (txtCheqNo.Text.Trim() == "")
                    //{
                    //    txtCheqNo.Style.Add("border", "1px solid red;");
                    //    list.Add(txtCheqNo.Text);
                    //}

                    //else
                    //{
                    //    txtCheqNo.Style.Add("border", "");
                    //    list.Add(txtCheqNo.Text);
                    //}
                    //if (txtChequeDate.Text.Trim() == "")
                    //{
                    //    txtChequeDate.Style.Add("border", "1px solid red;");
                    //    list.Add(txtChequeDate.Text);
                    //}

                    //else
                    //{
                    //    txtChequeDate.Style.Add("border", "");
                    //    list.Add(txtChequeDate.Text);
                    //}

                }
                else
                {
                    if (txtChequeDate.Text.Trim() == "")
                    {
                        txtChequeDate.Style.Add("border", "1px solid red;");
                        list.Add(txtChequeDate.Text);
                    }

                    else
                    {
                        txtChequeDate.Style.Add("border", "");
                        list.Add(txtChequeDate.Text);
                    }
                    if (ddlChequeBank.SelectedValue == "-1")
                    {
                        ddlChequeBank.Style.Add("border", "1px solid red");
                        list.Add(ddlChequeBank.SelectedValue);
                    }
                    else
                    {
                        ddlChequeBank.Style.Add("border", "");
                        list.Add(ddlChequeBank.SelectedValue);
                    }
                }
                //if (txtvatper.Text.Trim() == "")
                //{
                //    txtvatper.Style.Add("border", "1px solid red;");
                //    list.Add(txtvatper.Text);
                //}
                //else
                //{
                //    txtvatper.Style.Add("border", "");
                //    list.Add(txtvatper.Text);
                //}





                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        protected void ddlPartyName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void ddlVatOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVatOption.SelectedValue == "0")
            {
                txtvatper.Enabled = true;
                txtvatper.Text = "13";
                CalcVatnDis();
                CalcNetPayable();
            }
            else
            {

                txtvatper.Enabled = false;
                txtvatper.Text = "";
                txtvatamt.Text = "";
                CalcVatnDis();
                CalcNetPayable();
            }
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {

                //if (!PRINT_VOUCHER)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnEdit", "alert('Sorry, No Print permission');", true);
                //    return;
                //}
                string _repName;
                string _openfrom;
                string _TransId;

                _repName = "";
                _openfrom = "";
                if (txtid.Text.Trim() != null)
                {
                    _repName = "Process/Account/VoucherPrintloosesheet.rpt";
                    _openfrom = "VOUCHERENTRY";
                    _TransId = txtid.Text.Trim();
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "window.open('../../Reports/RptTemplates.aspx?PrmReportName=" + _repName + "&&PrmOpenFrom=" + _openfrom + "&&PrmPurchaseID=" + _TransId + "','Graph');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;

            }
        }

        void ucAccountHead_MyEvent(object sender, EventArgs e)
        {
        }

        protected void txtvatamt_TextChanged(object sender, EventArgs e)
        {
            //CalcVatnDis();
            CalcNetPayable();
        }

        protected void txttdsamt_TextChanged(object sender, EventArgs e)
        {
            //CalcVatnDis();
            CalcNetPayable();
        }

        protected void ddlpaymenttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlpaymenttype.SelectedValue == "1")
            {
                txtChequeDate.Enabled = true;
                txtCheqNo.Enabled = true;
            }
            if (ddlpaymenttype.SelectedValue == "2")
            {
                txtChequeDate.Enabled = true;
                txtCheqNo.Enabled = false;
            }
            if (ddlpaymenttype.SelectedValue == "3")
            {
                txtChequeDate.Enabled = true;
                txtCheqNo.Enabled = false;
            }
        }
        public void PaymentMode()
        {
            conName = new List<string>();
            con = new List<string>();
            ddlpaymenttype.DataValueField = "id";
            ddlpaymenttype.DataTextField = "PaymentType";
            ClsBind.FxLoadCombo(ref ddlpaymenttype, "def_paymenttype", "id", "PaymentType", conName, con, "id asc");
            //ClsBankPaymentInfobll objbll = new ClsBankPaymentInfobll();
            //DataTable dt = objbll.FxBindPaymentType();
            //if (dt != null)
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        ddlpaymenttype.DataSource = dt;
            //        ddlpaymenttype.DataBind();
            //    }
            //}
        }
    }
}