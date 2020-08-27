using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Ensure.Ensure.Process.UserControls;
using System.Xml;
using Ensure.BllClass.Setup.Company;
using Ensure.BllDalClasses.BllClass.Common;

namespace Ensure.Ensure.UserControls.Common
{
    public partial class FormatSetup : System.Web.UI.UserControl
    {
        
        #region property methods

        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //FxBindXml();
        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)gdvFormatSetup.Rows[0].FindControl("chkSelect")).Checked == true)
                for (int i = 1; i < gdvFormatSetup.Rows.Count; i++)
                {
                    ((CheckBox)gdvFormatSetup.Rows[i].FindControl("chkSelect")).Checked = false;
                    ((CheckBox)gdvFormatSetup.Rows[i].FindControl("chkSelect")).Enabled = false;
                    ((RadioButtonList)gdvFormatSetup.Rows[i].FindControl("rblDiplay")).Enabled = false;
                }
            else if (((CheckBox)gdvFormatSetup.Rows[0].FindControl("chkSelect")).Checked == false)
                for (int i = 1; i < gdvFormatSetup.Rows.Count; i++)
                {
                    ((CheckBox)gdvFormatSetup.Rows[i].FindControl("chkSelect")).Enabled = true;
                    ((RadioButtonList)gdvFormatSetup.Rows[i].FindControl("rblDiplay")).Enabled = true;
                }
            for (int i = 1; i < gdvFormatSetup.Rows.Count; i++)
            {
                if (((CheckBox)gdvFormatSetup.Rows[i].FindControl("chkSelect")).Checked == true)
                {
                    if (((RadioButtonList)gdvFormatSetup.Rows[i].FindControl("rblDiplay")).SelectedIndex == -1)
                        ((RadioButtonList)gdvFormatSetup.Rows[i].FindControl("rblDiplay")).SelectedIndex = 0;
                    ((RadioButtonList)gdvFormatSetup.Rows[i].FindControl("rblDiplay")).Enabled = true;
                    ((DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSeparator")).Enabled = true;
                    ((DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort")).Enabled = true;
                    FxUnBindSort();
                }
                else
                {
                    ((RadioButtonList)gdvFormatSetup.Rows[i].FindControl("rblDiplay")).ClearSelection();
                    ((DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSeparator")).SelectedIndex = 0;
                    ((RadioButtonList)gdvFormatSetup.Rows[i].FindControl("rblDiplay")).Enabled = false;
                    ((DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSeparator")).Enabled = false;
                    ((DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort")).Enabled = false;
                    FxBindSort();
                }
            }
        }

        protected void gdvFormatSetup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView drview = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex == 0)
                {
                    ((RadioButtonList)e.Row.FindControl("rblDiplay")).Visible = false;
                    ((DropDownList)e.Row.FindControl("ddlSeparator")).Visible = false;
                    ((DropDownList)e.Row.FindControl("ddlSort")).Visible = false;
                }
                if (ViewState["ForDisplay"] != null)
                {
                    if (ViewState["ForDisplay"].ToString() == "claim")
                        ((DropDownList)e.Row.FindControl("ddlSort")).Items.Add("7");
                }
                if (ViewState["tblForGdv"] != null)
                {
                    DataTable dt=(DataTable) ViewState["tblForGdv"];
                    if (dt.Rows.Count > e.Row.RowIndex)
                    {
                        ((CheckBox)e.Row.FindControl("chkSelect")).Checked = Convert.ToBoolean(dt.Rows[e.Row.RowIndex]["ISCHECKED"].ToString());
                        ((RadioButtonList)e.Row.FindControl("rblDiplay")).SelectedIndex = ClsConvertTo.Int32(dt.Rows[e.Row.RowIndex]["DISPLAY"].ToString());
                        DropDownList ddlSeperator = (DropDownList)e.Row.FindControl("ddlSeparator");
                        ddlSeperator.SelectedIndex = ddlSeperator.Items.IndexOf(ddlSeperator.Items.FindByText(dt.Rows[e.Row.RowIndex]["SEPARATOR"].ToString()));
                        ((DropDownList)e.Row.FindControl("ddlSort")).SelectedIndex = ClsConvertTo.Int32(dt.Rows[e.Row.RowIndex]["SORTNO"].ToString());
                    }
                }
                if (((CheckBox)e.Row.FindControl("chkSelect")).Checked == false)
                {
                    ((RadioButtonList)e.Row.FindControl("rblDiplay")).Enabled = false;
                    ((DropDownList)e.Row.FindControl("ddlSeparator")).Enabled = false;
                    ((DropDownList)e.Row.FindControl("ddlSort")).Enabled = false;
                }
                if (((CheckBox)e.Row.FindControl("chkSelect")).Checked == true)
                {
                    ((RadioButtonList)e.Row.FindControl("rblDiplay")).Enabled = true;
                    ((DropDownList)e.Row.FindControl("ddlSeparator")).Enabled = true;
                    ((DropDownList)e.Row.FindControl("ddlSort")).Enabled = true;
                }
                if (e.Row.RowIndex == 6)
                {
                    ((CheckBox)e.Row.FindControl("chkSelect")).Enabled = false;
                    ((RadioButtonList)e.Row.FindControl("rblDiplay")).Visible = false;
                }
            }
        }

        protected void rblDiplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEg_Click(object sender, EventArgs e)
        {
            int exit=0;
            List<int> gdvIndex = new List<int>();
            List<int> val = new List<int>();
            for (int i = 1; i < gdvFormatSetup.Rows.Count; i++)
            {
                if (((CheckBox)gdvFormatSetup.Rows[i].FindControl("chkSelect")).Checked == true)
                {
                    if (((DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort")).SelectedItem.Text == "None")
                    {
                        exit = 1;
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Choose Sort No. for " + ((Label)gdvFormatSetup.Rows[i].FindControl("lblTblName")).Text + "');", true);
                        break;
                    }
                    else
                    {
                        exit = 0;
                        val.Add(ClsConvertTo.Int32(((DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort")).SelectedItem.Text));
                    }
                }
            }
            if (exit == 0)
            {
                val.Sort();
                txtEg.Text = "";
                int max = FxGreater(val);
                foreach (var value in val)
                {
                    for (int i = 1; i < gdvFormatSetup.Rows.Count; i++)
                    {
                        RadioButtonList rbl = (RadioButtonList)gdvFormatSetup.Rows[i].FindControl("rblDiplay");
                        DropDownList ddlSeparator = (DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSeparator");
                        DropDownList ddlSort = (DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort");
                        if (((CheckBox)gdvFormatSetup.Rows[i].FindControl("chkSelect")).Checked == true)
                        {
                            if (ddlSeparator.SelectedIndex != -1 && ddlSort.SelectedItem.Text!="None")
                                if (ClsConvertTo.Int32(ddlSort.SelectedItem.Text) == value)
                                {
                                    if (i == 5 && !(ViewState["ForDisplay"] == null || ViewState["ForDisplay"].ToString() ==""))
                                    {
                                        if (ViewState["ForDisplay"].ToString() == "claim" && (ClsConvertTo.Int32(ddlSort.SelectedItem.Text) == 5 || ClsConvertTo.Int32(ddlSort.SelectedItem.Text)==max))
                                            txtEg.Text = txtEg.Text + "000101";
                                        else
                                            txtEg.Text = txtEg.Text + "000101" + ddlSeparator.SelectedValue;
                                    }
                                    else
                                        if (rbl.SelectedIndex != -1)
                                        {
                                            if (!(ViewState["ForDisplay"] == null || ViewState["ForDisplay"].ToString() ==""))
                                            {
                                                if (ViewState["ForDisplay"].ToString() == "claim" && ClsConvertTo.Int32(ddlSort.SelectedItem.Text) == max)
                                                    txtEg.Text = txtEg.Text + FxBindEg(rbl, ((Label)gdvFormatSetup.Rows[i].FindControl("lblTblName")).Text);
                                                else
                                                    txtEg.Text = txtEg.Text + FxBindEg(rbl, ((Label)gdvFormatSetup.Rows[i].FindControl("lblTblName")).Text) + ddlSeparator.SelectedValue;
                                            }
                                            else
                                                txtEg.Text = txtEg.Text + FxBindEg(rbl, ((Label)gdvFormatSetup.Rows[i].FindControl("lblTblName")).Text) + ddlSeparator.SelectedValue;
                                        }
                                    //if (((Label)gdvFormatSetup.Rows[i].FindControl("lblTblName")).Text == "Running No.")
                                    //    txtEg.Text = txtEg.Text.Trim(new Char[] { ' ', '*', '.' });
                                    if (txtEg.Text.Contains(ddlSeparator.SelectedValue + ddlSeparator.SelectedValue))
                                    {
                                        char[] end = ddlSeparator.SelectedValue.ToCharArray();
                                        txtEg.Text = txtEg.Text.TrimEnd(end) + ddlSeparator.SelectedValue;
                                    }
                                    break;
                                }
                        }
                        else
                            ((RadioButtonList)gdvFormatSetup.Rows[i].FindControl("rblDiplay")).ClearSelection();
                    } 
                }
                if (ViewState["ForDisplay"] != null)
                {
                    if (ViewState["ForDisplay"].ToString() != "claim")
                        txtEg.Text = txtEg.Text + "000101";
                }
                btnDone.Enabled = true;
            }
        }
        
        protected void ddlSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DropDownList ddl = (DropDownList)sender;
            //GridViewRow row = (GridViewRow)ddl.NamingContainer;
            FxForSorting();
            
        }

        #region event handling
        public event EventHandler MyEvent;
        protected void OnMyEvent(EventArgs e)
        {
            if (MyEvent != null)
                MyEvent(this, e);
        }
        #endregion event handling

        protected void btnDone_Click(object sender, EventArgs e)
        {
            MyEventArgs mea = new MyEventArgs();
            mea.Message = "ok";
            OnMyEvent(mea);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //mvFormatSetup.ActiveViewIndex = 1;
            btnEg.Enabled = true;
            btnDone.Enabled = false;
            btnDone.Visible = true;
            btnEdit.Visible = false;
                FxBindXml();
                FxForSorting();
            gdvFormatSetup.Enabled = true;
        }

        #endregion property methods

        #region methods

        protected void FxGetIndex(ref List<int> gdvIndex, ref List<int> val, bool condition)
        {
            for (int i = 1; i < gdvFormatSetup.Rows.Count; i++)
            {
                if (((CheckBox)gdvFormatSetup.Rows[i].FindControl("chkSelect")).Checked == condition)
                {
                    gdvIndex.Add(i);
                    if (((DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort")).SelectedItem.Text != "None")
                        val.Add(ClsConvertTo.Int32(((DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort")).SelectedItem.Text));
                }
            }
        }

        private void FxBindXml()
        {
            if (ViewState["ForDisplay"].ToString() == "claim")
            {
                string filePath = Server.MapPath("~/BllDalClasses/XML/TableNameClaim.xml");
                using (DataSet ds = new DataSet())
                {
                    ds.ReadXml(filePath);
                    gdvFormatSetup.DataSource = ds;
                    gdvFormatSetup.DataBind();
                }
                //for (int i = 0; i < gdvFormatSetup.Rows.Count; i++)
                //{
                //    ((DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort")).Items.Add("6");
                //}
            }
            else if (ViewState["ForDisplay"].ToString() == "kyc")
            {
                string filePath = Server.MapPath("~/BllDalClasses/XML/TableNameKyc.xml");
                using (DataSet ds = new DataSet())
                {
                    ds.ReadXml(filePath);
                    gdvFormatSetup.DataSource = ds;
                    gdvFormatSetup.DataBind();
                }
            }
            else if (ViewState["ForDisplay"].ToString() == "receiptBill")
            {
                string filePath = Server.MapPath("~/BllDalClasses/XML/TableNameReceiptNo.xml");
                using (DataSet ds = new DataSet())
                {
                    ds.ReadXml(filePath);
                    gdvFormatSetup.DataSource = ds;
                    gdvFormatSetup.DataBind();
                }
            }
            else if (ViewState["ForDisplay"].ToString() == "inward")
            {
                string filePath = Server.MapPath("~/BllDalClasses/XML/TableNameInwardBillNo.xml");
                using (DataSet ds = new DataSet())
                {
                    ds.ReadXml(filePath);
                    gdvFormatSetup.DataSource = ds;
                    gdvFormatSetup.DataBind();
                }
            }
            else
            {
                string filePath = Server.MapPath("~/BllDalClasses/XML/TableName.xml");
                using (DataSet ds = new DataSet())
                {
                    ds.ReadXml(filePath);
                    gdvFormatSetup.DataSource = ds;
                    gdvFormatSetup.DataBind();
                }
            }
        }

        protected void FxBindSort()
        {
            List<int> gdvIndex = new List<int>();
            List<int> val = new List<int>();

            // check for checked index in gridview and get their value selected in the dropdownlist
            FxGetIndex(ref gdvIndex, ref val, false);

            for (int i = 1; i < gdvFormatSetup.Rows.Count; i++)
            {
                DropDownList ddl = (DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort");
                if (((CheckBox)gdvFormatSetup.Rows[i].FindControl("chkSelect")).Checked == false)
                {
                    foreach (var item in gdvIndex)
                    {
                        if (i == item)
                        {
                            if (ddl.SelectedIndex != 0)
                            {
                                foreach (var item2 in val)
                                {
                                    //if (ddl.SelectedItem.Text == "None")
                                    //    continue;
                                    //else 
                                    if (ddl.SelectedItem.Text != "None")
                                    {
                                        if (ClsConvertTo.Int32(ddl.SelectedItem.Text) == item2)
                                        {
                                            ddl.SelectedIndex = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (var item2 in val)
                {
                    ListItem li = ddl.Items.FindByText(item2.ToString());
                    if (li == null)
                    {
                        string newItem = item2.ToString();
                        //string oldItem;
                        string oldSelectedItem;
                        DropDownList drp = new DropDownList();
                        drp.Items.AddRange(ddl.Items.OfType<ListItem>().ToArray());
                        oldSelectedItem = ddl.SelectedItem.Text;
                        //ddl.DataSource = "";
                        //ddl.DataBind();
                        ddl.Items.Clear();
                        ddl.Items.Add("None");
                        for (int j = 1; j <= item2; j++)
                        {
                            ddl.Items.Add(j.ToString());
                            //if (drp.Items[j].ToString() == "None" || ClsConvertTo.Int32(drp.Items[j].Text) <= ClsConvertTo.Int32(newItem))
                            //    ddl.Items.Add(drp.Items[j].ToString());
                            //else if (ClsConvertTo.Int32(drp.Items[j].Text) > ClsConvertTo.Int32(newItem))
                            //{
                            //    oldItem = drp.Items[j].Text;
                            //    ddl.Items.Add(newItem);
                            //    newItem = oldItem;
                            //}
                        }
                        //if (item2 != ClsConvertTo.Int32(newItem))
                        //    ddl.Items.Add(newItem);
                        if (oldSelectedItem != "")
                            ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByText(oldSelectedItem));
                    }
                }
            }
        }

        protected void FxUnBindSort()
        {
            List<int> gdvIndex = new List<int>();
            List<int> val = new List<int>();

            // check for checked index in gridview and get their value selected in the dropdownlist
            FxGetIndex(ref gdvIndex, ref val, true);

            for (int i = 1; i < gdvFormatSetup.Rows.Count; i++)
            {
                DropDownList ddl = (DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort");
                if (((CheckBox)gdvFormatSetup.Rows[i].FindControl("chkSelect")).Checked == true)
                {
                    foreach (var item in gdvIndex)
                    {
                        if (i == item)
                        {
                            if (ddl.SelectedIndex != 0)
                            {
                                foreach (var item2 in val)
                                {
                                    if (ClsConvertTo.Int32(ddl.SelectedItem.Text) != item2)
                                    {
                                        ListItem li = ddl.Items.FindByText(item2.ToString());
                                        if (li != null)
                                            ddl.Items.Remove(li);
                                    }
                                }
                            }
                            else
                            {
                                foreach (var item2 in val)
                                {
                                    ListItem li = ddl.Items.FindByText(item2.ToString());
                                    if (li != null)
                                        ddl.Items.Remove(li);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (var item2 in val)
                    {
                        ListItem li = ddl.Items.FindByText(item2.ToString());
                        if (li != null)
                            ddl.Items.Remove(li);
                    }
                }
            }
        }

        protected void FxForSorting()
        {
            int status = 0;
            int selectedVal = 0;

            List<int> gdvIndex = new List<int>();
            List<int> val = new List<int>();
            // check for checked index in gridview and get their value selected in the dropdownlist
            FxGetIndex(ref gdvIndex, ref val, true);

            for (int i = 1; i < gdvFormatSetup.Rows.Count; i++)
            {
                DropDownList ddlSort = (DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort");
                if (((CheckBox)gdvFormatSetup.Rows[i].FindControl("chkSelect")).Checked == true)
                {
                    if (ddlSort.SelectedItem.Text != "None")
                        selectedVal = (ClsConvertTo.Int32(ddlSort.SelectedItem.Text));
                    ddlSort.DataSource = "";
                    ddlSort.DataBind();
                    ddlSort.Items.Add("None");
                    for (int j = 1; j < gdvFormatSetup.Rows.Count; j++)
                    {
                        foreach (var value in val)
                        {
                            if (j == value && j != selectedVal)
                            {
                                status = 1;
                                break;
                            }
                        }

                        if (status != 1)
                            ddlSort.Items.Add(j.ToString());
                        status = 0;
                    }
                    ddlSort.SelectedIndex = ddlSort.Items.IndexOf(ddlSort.Items.FindByText(selectedVal.ToString()));
                    selectedVal = 0;
                }
                else
                {
                    ddlSort.DataSource = "";
                    ddlSort.DataBind();
                    ddlSort.Items.Add("None");
                    for (int j = 1; j < gdvFormatSetup.Rows.Count; j++)
                    {
                        foreach (var value in val)
                        {
                            if (j == value)
                            {
                                status = 1;
                                break;
                            }
                        }
                        if (status != 1)
                            ddlSort.Items.Add(j.ToString());
                        status = 0;
                    }

                    ddlSort.SelectedIndex = 0;
                }
            }
        }

        protected void FxDdlIndexCHange()
        {
            List<int> gdvIndex = new List<int>();
            List<int> val = new List<int>();
            string status="";
            // check for checked index in gridview and get their value selected in the dropdownlist
            FxGetIndex(ref gdvIndex, ref val, true);


            for (int i = 1; i < gdvFormatSetup.Rows.Count; i++)
            {
                DropDownList ddl = (DropDownList)gdvFormatSetup.Rows[i].FindControl("ddlSort");
                if (((CheckBox)gdvFormatSetup.Rows[i].FindControl("chkSelect")).Checked == true)
                {
                    foreach (var index in gdvIndex)
                    {
                        if (i == index)
                        {
                            if (ddl.SelectedIndex != 0)
                            {
                                foreach (var item2 in val)
                                {
                                    if (ClsConvertTo.Int32(ddl.SelectedItem.Text) == item2)
                                    {
                                        status = "match";
                                        break;
                                    }
                                }
                                if (status == "match")
                                    break;
                            }
                        }
                    }
                    if (status == "match")
                        continue;

                }
            }

        }

        protected string FxBindEg(RadioButtonList rbl, string tblName)
        {
            if (tblName == "Branch")
                return (rbl.SelectedIndex == 0 ? "01" : "KTM");
            if (tblName == "Department")
                return (rbl.SelectedIndex == 0 ? "01" : "FR");
            if (tblName == "Class")
                return (rbl.SelectedIndex == 0 ? "01" : "GFR");
            if (tblName == "DocType")
                return (rbl.SelectedIndex == 0 ? "01" : "01");
            if (tblName == "ClaimType")
                return (rbl.SelectedIndex == 0 ? "71" : "71");
            if (tblName == "Company")
                return (rbl.SelectedIndex == 0 ? "AHS" : "AHS");
            if (tblName == "InsuredType")
                return (rbl.SelectedIndex == 0 ? "INV" : "INV");
            if (tblName == "FiscalYear")
                return (rbl.SelectedIndex == 0 ? "71/72" : "71/72");
            return "";
        }

        /// <summary>
        /// This function is accessed from FormatSetup.aspx page
        /// </summary>
        /// <param name="dt"></param>
        public void FxBindGdv(DataTable dt,string str)
        {
            ViewState["ForDisplay"] = str;
            if (dt.Rows.Count > 0)
            {
                btnEg.Enabled = false;
                btnDone.Visible = false;
                btnEdit.Visible = true;
                gdvFormatSetup.Enabled = false;

                ViewState["tblForGdv"] = dt;
                txtEg.Text = dt.Rows[0]["EXAMPLE"].ToString();
                    FxBindXml();
            }
            else
            {
                    FxBindXml();
                btnEg.Enabled = true;
                btnDone.Visible = true;
                btnEdit.Visible = false;
            }
        }

        public int FxGreater(List<int> val)
        {
            int temp=0;
            foreach (var value in val)
            {
                temp = value;
                foreach (var value2 in val)
                {
                    if (temp < value2)
                        temp = value2;
                }
            }
            return temp;
        }

        #endregion methods

        //protected void gdvEdit_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //Find the RadioButtonList in the Row
        //        RadioButtonList rbl=(RadioButtonList)e.Row.FindControl("rblDisplay");
        //        rbl.Items.Add("Code");
        //        rbl.Items.Add("Alias");
        //        if (ViewState["tblForGdv"] != null)
        //        {
        //                Label lblDisplay = (Label)e.Row.FindControl("lblDisplay");
        //                rbl.SelectedIndex = rbl.Items.IndexOf(rbl.Items.FindByText(lblDisplay.Text));
        //        }
        //        rbl.Enabled = false;

        //        //Find the DropDownList in the Row
        //        DropDownList ddlSeparator = (e.Row.FindControl("ddlSeparator") as DropDownList);
        //        if (ViewState["tblForGdv"] != null)
        //        {
        //            Label lblSeparator = (Label)e.Row.FindControl("lblSeparator");
        //            ddlSeparator.Items.Add(lblSeparator.Text);
        //        }
        //        ddlSeparator.Enabled = false;

        //        //Find the DropDownList in the Row
        //        DropDownList ddlSort = (e.Row.FindControl("ddlSort") as DropDownList);
        //        if (ViewState["tblForGdv"] != null)
        //        {
        //            Label lblSort = (Label)e.Row.FindControl("lblSortNo");
        //            if(lblSort.Text=="0")
        //            ddlSort.Items.Add("None");
        //            else
        //                ddlSort.Items.Add(lblSort.Text);
        //        }
        //        ddlSort.Enabled = false;

        //        if (e.Row.RowIndex == 0)
        //        {
        //            ((RadioButtonList)e.Row.FindControl("rblDisplay")).Visible = false;
        //            ((DropDownList)e.Row.FindControl("ddlSeparator")).Visible = false;
        //            ((DropDownList)e.Row.FindControl("ddlSort")).Visible = false;
        //        }
        //    }
        //}

        //private void createNode(clsCompProfileBll objFormat, XmlTextWriter writer)
        //{
        //    //parent node start
        //    writer.WriteStartElement("Formats");
        //    //Id
        //    writer.WriteStartElement("id");
        //    writer.WriteString(objFormat.Id.ToString());
        //    writer.WriteEndElement();
        //    //Is checked
        //    writer.WriteStartElement("check");
        //    writer.WriteString(objFormat.check.ToString());
        //    writer.WriteEndElement();
        //    //Table name
        //    writer.WriteStartElement("tblname");            
        //    writer.WriteString(objFormat.tblname);
        //    writer.WriteEndElement();
        //    //display
        //    writer.WriteStartElement("display");
        //    writer.WriteString(objFormat.display.ToString());
        //    writer.WriteEndElement();
        //    //Separator
        //    writer.WriteStartElement("separator");
        //    writer.WriteString(objFormat.separator);
        //    writer.WriteEndElement();
        //    //sort no.
        //    writer.WriteStartElement("sortno");
        //    writer.WriteString(objFormat.sortno.ToString());
        //    writer.WriteEndElement();

        //    writer.WriteEndElement();
        //}
    }
}