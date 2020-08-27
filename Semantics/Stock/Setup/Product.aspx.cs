using Stock.BllDalClasses.BllClass.Common;
using Stock.BllDalClasses.BllClass.Setup;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock.Stock.Setup
{
    public partial class Product : System.Web.UI.Page
    {
        public Int32 PAGEID
        {
            get
            {
                if (ViewState["PAGEID"] != null)
                {
                    return Convert.ToInt32(ViewState["PAGEID"]);
                }
                else
                {
                    return 0;
                }

            }
            set
            {
                ViewState["PAGEID"] = value;
            }
        }
        public Boolean ADD
        {
            get
            {
                if (ViewState["ADD"] != null)
                {
                    return ClsConvertTo.Boolean(ViewState["ADD"]);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ViewState["ADD"] = value;
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
        public Boolean DELETE
        {
            get
            {
                if (ViewState["DELETE"] != null)
                {
                    return ClsConvertTo.Boolean(ViewState["DELETE"]);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                ViewState["DELETE"] = value;
            }
        }

        //static bool editMode;
        public Boolean editMode
        {
            get
            {
                if (ViewState["editMode"] != null)
                {
                    return ClsConvertTo.Boolean(ViewState["editMode"]);
                }
                else
                {
                    return false;
                }

            }
            set
            {
                ViewState["editMode"] = value;
            }
        }
        #region property Methods

        protected void Page_Load(object sender, EventArgs e)
        {
                if (!IsPostBack)
                {
                    try
                    {
                        ADD = true;
                        EDIT = true;
                        FxBindInitial();
                        FxBindListBox();
                        txtNName.Font.Name = ClsCommon.NepaliFont;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                        return;

                    }
                }
            
        }

        protected void lbSurveyorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClsProductBll obj = new ClsProductBll();
                obj.SURVTYPECODE = ClsConvertTo.Int32(lbSurveyorType.SelectedValue);
                DataTable dt = obj.GetSurveyorType();
                if (dt.Rows.Count > 0)
                {
                    txtEName.Text = dt.Rows[0]["EDESCRIPTION"].ToString();
                    txtNName.Text = dt.Rows[0]["NDESCRIPTION"].ToString();
                    chkislock.Checked = ClsConvertTo.Boolean(dt.Rows[0]["ISLOCK"].ToString());
                    txtenteredby.Text = dt.Rows[0]["enteredby"].ToString() + " " + "on" + " " + dt.Rows[0]["ADT"].ToString();
                    txtupdatedby.Text = dt.Rows[0]["updatedby"].ToString() + " " + "on" + " " + dt.Rows[0]["UDT"].ToString();
                }
                btnEdit.Enabled = true;
                btnCancel.Enabled = true;
                btnNew.Enabled = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;

            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            if (ClsCommon.applyNewSecurity == 0)
            {
                if (!ClsSecurity.FxGetSecurityPermission("Setup", "Claim Setup", "Survey Type Add"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('You have no permission to Add!');", true);
                    return;

                }
            }
            else
            {
                if (clsSecurityNew.FxCheckUserSecurity((DataTable)ViewState["SECURITY"], "Add", ClsCommon.SubBranchId) == false)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('You have no permission to Add!');", true);
                    return;
                }
            }

            FxClearControl(Page.Controls);
            lbSurveyorType.Enabled = false;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            pnlEntry.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            lbSurveyorType.Enabled = false;
            editMode = false;
            txtupdatedby.Enabled = false;
            txtenteredby.Enabled = false;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ClsCommon.applyNewSecurity == 0)
            {
                if (!ClsSecurity.FxGetSecurityPermission("Setup", "Claim Setup", "Survey Type Edit"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('You have no permission to Edit!');", true);
                    return;

                }
            }
            else
            {
                if (clsSecurityNew.FxCheckUserSecurity((DataTable)ViewState["SECURITY"], "Edit", ClsCommon.SubBranchId) == false)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('You have no permission to Edit!');", true);
                    return;
                }
            }

            if (lbSurveyorType.SelectedIndex != -1)
            {
                lbSurveyorType.Enabled = false;
                btnNew.Enabled = false;
                btnEdit.Enabled = false;
                pnlEntry.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                editMode = true;
                txtupdatedby.Enabled = false;
                txtenteredby.Enabled = false;
            }
            else
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Select from list box to edit!');", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClsCommon.applyNewSecurity == 0)
                {
                    if (editMode == true)
                    {
                        if (!ClsSecurity.FxGetSecurityPermission("Setup", "Claim Setup", "Survey Type Edit"))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('You have no permission to Edit!');", true);
                            return;

                        }
                    }
                    else
                    {
                        if (!ClsSecurity.FxGetSecurityPermission("Setup", "Claim Setup", "Survey Type Add"))
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('You have no permission to Add!');", true);
                            return;

                        }

                    }
                }
                else
                {
                    if (editMode == true)
                    {
                        if (clsSecurityNew.FxCheckUserSecurity((DataTable)ViewState["SECURITY"], "Edit", ClsCommon.SubBranchId) == false)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('You have no permission to Edit!');", true);
                            return;
                        }
                    }
                    else
                    {
                        if (clsSecurityNew.FxCheckUserSecurity((DataTable)ViewState["SECURITY"], "Add", ClsCommon.SubBranchId) == false)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('You have no permission to Add!');", true);
                            return;
                        }
                    }
                }

                #region  check required fields
                int k;
                k = FieldValidation();
                if (k == 1)
                {
                    return;
                }
                #endregion
                ClsProductBll obj = new ClsProductBll();
                obj.EDESCRIPTION = txtEName.Text.Trim();
                obj.NDESCRIPTION = txtNName.Text.Trim();
                obj.AUID = ClsCommon.UserCode;
                obj.ADT = DateTime.Now;
                obj.UUID = ClsCommon.UserCode;
                obj.UDT = DateTime.Now;
                if (editMode && lbSurveyorType.SelectedIndex != -1)
                {
                    obj.SURVTYPECODE = ClsConvertTo.Int32(lbSurveyorType.SelectedValue);
                }
                obj.islock = chkislock.Checked ? 1 : 0;
                string msg = obj.InsertUpdateSurveyorType();
                if (msg != null)
                {
                    if (msg.Contains("error"))
                    {
                        string[] strSplit = msg.Split('/');
                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Error occured while saving SurveyorType!!!\\nError No. : " + strSplit[1].ToString() + "');", true);
                        btnNew.Enabled = false;
                        btnEdit.Enabled = false;
                    }
                    else
                    {
                        if (msg == "insert")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Record saved successfully!');", true);
                        }
                        else if (msg == "update")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Record updated successfully!');", true);
                        }
                        FxClearControl(Page.Controls);
                        FxBindInitial();
                        FxBindListBox();
                        lbSurveyorType.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            FxClearControl(Page.Controls);
            FxBindInitial();
            lbSurveyorType.SelectedIndex = -1;
            btnNew.Enabled = ADD;
            btnEdit.Enabled = EDIT;
        }

        protected void txtEName_TextChanged(object sender, EventArgs e)
        {
            if (txtEName.Text.Trim() != "")
            {
                txtEName.Style.Add("border", "");
            }
            else
            {
                txtEName.Style.Add("border", "1px solid red;");
            }
        }

        protected void txtNName_TextChanged(object sender, EventArgs e)
        {
            if (txtNName.Text.Trim() != "")
            {
                txtNName.Style.Add("border", "");
            }
            else
            {
                txtNName.Style.Add("border", "1px solid red;");
            }
        }

        #endregion

        #region methods
        protected void FxBindListBox()
        {
            List<string> conName = new List<string>();
            List<string> conVal = new List<string>();
            ClsBind.FxLoadCombo(ref lbSurveyorType, "Product", "PRODUCTID", "EDESCRIPTION", conName, conVal, "EDESCRIPTION asc");
            //clsSurveyorTypeBll obj = new clsSurveyorTypeBll();
            //DataTable dt = obj.GetSurveyorType();
            //lbSurveyorType.DataSource = dt;
            //lbSurveyorType.DataBind();

        }

        protected void FxBindInitial()
        {
            lbSurveyorType.Enabled = true;
            btnNew.Enabled = true;
            btnEdit.Enabled = false;
            pnlEntry.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = true;
            editMode = false;
        }

        private void FxClearControl(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();
                else if (ctrl is RadioButtonList)
                    ((RadioButtonList)ctrl).ClearSelection();
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Checked = false;

                FxClearControl(ctrl.Controls);
            }
        }
        #endregion methods

       

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
                if (txtEName.Text.Trim() == "")
                {
                    txtEName.Style.Add("border", "1px solid red;");
                    list.Add(txtEName.Text);
                }
                else
                {
                    txtEName.Style.Add("border", "");
                    list.Add(txtEName.Text);
                }

                if (txtNName.Text.Trim() == "")
                {
                    txtNName.Style.Add("border", "1px solid red;");
                    list.Add(txtNName.Text);
                }
                else
                {
                    txtNName.Style.Add("border", "");
                    list.Add(txtNName.Text);
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}