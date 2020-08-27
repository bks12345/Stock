using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ensure.BllClass.Setup.Underwriting.Area;
using System.Data;
using Ensure.BllClass.Setup.Underwriting.KYC;
using Ensure.BllDalClasses.BllClass.Setup.Underwriting.Area;
using Ensure.BllDalClasses.BllClass.Common;

namespace Ensure.Ensure.UserControls.Common
{
    public partial class Area : System.Web.UI.UserControl
    {
        #region properties
        public string Id
        {
            get
            {
                if (ViewState["Id"] != null)
                {
                    return (ViewState["Id"]).ToString();
                }
                else
                {
                    return "";
                }

            }

            set
            {
                ViewState["Id"] = value;
            }
        }
        public string Task
        {
            get
            {
                if (ViewState["Task"] != null)
                {
                    return (ViewState["Task"]).ToString();
                }
                else
                {
                    return "";
                }

            }

            set
            {
                ViewState["Task"] = value;
            }
        }

        public static List<int> delIdsOrg = new List<int>();
        public static List<int> delIdsDoc = new List<int>();
        #endregion properties

        List<string> conName = new List<string>();
        List<string> con = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["from"] != null)
                {
                    if (!(Session["from"].ToString() == "policysearch" || Session["from"].ToString() == "forceedit" || Session["from"].ToString() == "wizb" || Session["from"].ToString() == "bank" || Session["from"].ToString() == "kyc"))
                    {
                        BindInnitial();
                        if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                        {
                            Id = (Request.QueryString["Id"]);
                            if (!string.IsNullOrEmpty(Request.QueryString["Task"]))
                                Task = (Request.QueryString["Task"]);
                            BindForm();
                        }
                    }
                    else if (Session["from"].ToString() == "bank")
                    {
                        BindInnitial();

                        if (!string.IsNullOrEmpty(Request.QueryString["Task"]))
                        {
                            Task = (Request.QueryString["Task"]);
                            if (Task != "Add")
                                BindForm();
                        }
                        //rblMnuVdc.Items.FindByValue("0").Selected = true;
                    }
                    else if (Session["from"].ToString() == "kyc")
                    {
                        BindInnitial();

                        if (!string.IsNullOrEmpty(Request.QueryString["Task"]))
                        {
                            Task = (Request.QueryString["Task"]);
                            //if (Task != "Add")
                            BindForm();
                        }
                        //rblMnuVdc.Items.FindByValue("0").Selected = true;
                    }
                    //else
                    //{
                    //    BindInnitial();
                    //}
                }
                else if (Session["Address"] != null)
                {
                    BindInnitial();
                    BindForm();
                }
                else
                {
                    BindInnitial();
                    if (!string.IsNullOrEmpty(Request.QueryString["Id"]))
                    {
                        Id = (Request.QueryString["Id"]);
                        if (!string.IsNullOrEmpty(Request.QueryString["Task"]))
                            Task = (Request.QueryString["Task"]);
                        BindForm();
                    }
                    rblMnuVdc.Items.FindByValue("0").Selected = true;
                }

            }
            //else
            //{
            //    BindInnitial();
            //}

        }

        public void BindForm()
        {
            if (Session["Address"] != null)
            {
                ClsAreaBll obj = (ClsAreaBll)Session["Address"];

                BindInnitial();
                ddlZone.SelectedIndex = ddlZone.Items.IndexOf(ddlZone.Items.FindByValue(obj.ZONEID.ToString()));

                BindDistrict();
                ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(ddlDistrict.Items.FindByValue(obj.DISTRICTID.ToString()));

                rblMnuVdc.SelectedIndex = rblMnuVdc.Items.IndexOf(rblMnuVdc.Items.FindByValue(obj.MNUVDC.ToString()));
                BindMnuVdc();
                if (rblMnuVdc.SelectedValue == "0")
                    ddlMnuVdc.SelectedIndex = ddlMnuVdc.Items.IndexOf(ddlMnuVdc.Items.FindByValue(obj.MNUCODE.ToString()));
                else if (rblMnuVdc.SelectedValue == "1")
                    ddlMnuVdc.SelectedIndex = ddlMnuVdc.Items.IndexOf(ddlMnuVdc.Items.FindByValue(obj.VDCCODE.ToString()));

                txtWardNo.Text = obj.WARDNO;
                txtEAddress.Text = obj.EADDRESS;
                txtNAddress.Text = obj.NADDRESS;

                BindArea();
                ddlArea.SelectedIndex = ddlArea.Items.IndexOf(ddlArea.Items.FindByValue(obj.AREAID.ToString()));
                ClsAreaBll objArea = new ClsAreaBll();
                objArea.AREACODE = ClsConvertTo.Int32(ddlArea.SelectedValue);
                DataTable dt1 = objArea.GetArea();
                if (dt1 != null)
                {
                    if (dt1.Rows.Count > 0)
                    {
                        txtNArea.Text = dt1.Rows[0]["NDESC"].ToString();
                    }
                }

                BindTole();
                ddlTole.SelectedIndex = ddlTole.Items.IndexOf(ddlTole.Items.FindByValue(obj.TOLEID.ToString()));
                ClsToleBll objTole = new ClsToleBll();
                objTole.TOLEID = ClsConvertTo.Int32(ddlTole.SelectedValue);
                DataTable dt2 = objTole.GetTole();
                if (dt2 != null)
                {
                    if (dt2.Rows.Count > 0)
                    {
                        txtNTole.Text = dt2.Rows[0]["NDESC"].ToString();
                    }
                }
                txtHouseNo.Text = obj.HOUSENO;
                txtPlotNo.Text = obj.PLOTNO;
            }
        }

        #region for SelectedIndexChanged methods
        public void ddlZone_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlZone.SelectedValue != "-1")
            //{
            //    //BindDistrict();
                BindDistrict();
            //    //FxBindZoneDistrict();
            //    ddlZone.Style.Add("border", "");
            //}
            //else
            //{
            //    //ddlDistrict.ClearSelection();
            //    //ddlMnuVdc.ClearSelection();
            //    //ddlArea.ClearSelection();
            //    //ddlTole.ClearSelection();

            //    ddlDistrict.DataSource = "";
            //    ddlDistrict.DataBind();
            //    ddlDistrict.Items.Insert(0, "None");
            //    ddlDistrict.Items[0].Value = "-1";
            //    ddlDistrict.Items[0].Selected = true;

            //    ddlMnuVdc.DataSource = "";
            //    ddlMnuVdc.DataBind();
            //    ddlMnuVdc.Items.Insert(0, "None");
            //    ddlMnuVdc.Items[0].Value = "-1";
            //    ddlMnuVdc.Items[0].Selected = true;

            //    ddlArea.DataSource = "";
            //    ddlArea.DataBind();
            //    ddlArea.Items.Insert(0, "None");
            //    ddlArea.Items[0].Value = "-1";
            //    ddlArea.Items[0].Selected = true;

            //    ddlTole.DataSource = "";
            //    ddlTole.DataBind();
            //    ddlTole.Items.Insert(0, "None");
            //    ddlTole.Items[0].Value = "-1";
            //    ddlTole.Items[0].Selected = true;
            //    ddlZone.Style.Add("border", "1px solid red;");

            //}
            ////FxGetAddress();
            ClsBind.FxComboSelectecIndex(ref ddlArea, "None", "txt");
        }

        public void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
                BindMnuVdc();
                BindArea();
            ClsBind.FxComboSelectecIndex(ref ddlArea, "None", "txt");
        }

        public void rblMnuVdc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindMnuVdc();
            BindMnuVdc(); ClsBind.FxComboSelectecIndex(ref ddlArea, "None", "txt");
        }

        public void ddlMnuVdc_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindArea();
            //ddlTole.DataSource = "";
            //ddlTole.DataBind();
            ddlTole.Items.Clear();
            ddlTole.Items.Insert(0, "None");
            ddlTole.Items[0].Value = "-1";
            ddlTole.Items[0].Selected = true;
            //if (ddlMnuVdc.SelectedValue != "-1")
            //{
            //    BindMnuVdc();
            //    //BindMnuVdcAddress();
            //    ddlMnuVdc.Style.Add("border", "");
            //}
            //else
            //{
            //    //ddlMnuVdc.Style.Add("border", "1px solid red;");
            //}
            //FxGetAddress();
            ClsBind.FxComboSelectecIndex(ref ddlArea, "None", "txt");
        }

        public void txtWardNo_TextChanged(object sender, EventArgs e)
        {
            //if (txtWardNo.Text.Trim() != "")
            //{
            //    //string address = txtEAddress.Text;
            //    //string[] str = address.Split('-');
            //    //address = str[0] + "-" + txtWardNo.Text;
            //    //txtEAddress.Text = address;

            //    //string address2 = txtNAddress.Text;
            //    //string[] str2 = address2.Split('-');
            //    //address2 = str2[0] + "-" + txtWardNo.Text + "_";
            //    //txtNAddress.Text = address2;

            //    BindArea();
            //    //FxBindArea();

            //    txtWardNo.Style.Add("border", "");
            //}
            //else
            //{
            //    BindArea();
            //    //txtWardNo.Style.Add("border", "1px solid red;");
            //}
            BindArea();
            //FxGetAddress();
            ClsBind.FxComboSelectecIndex(ref ddlArea, "None", "txt");
        }

        public void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlArea.SelectedValue != "-1")
            {
                ClsAreaBll objArea = new ClsAreaBll();
                objArea.AREACODE = ClsConvertTo.Int32(ddlArea.SelectedValue);
                DataTable dt = objArea.GetArea();
                txtNArea.Text = dt.Rows[0]["NDESC"].ToString();

                BindTole();
                ddlArea.Style.Add("border", "");
            }
            else
            {
                ddlArea.Style.Add("border", "1px solid red;");
            }
        }

        public void ddlTole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTole.SelectedValue != "-1")
            {
                ClsToleBll objTole = new ClsToleBll();
                objTole.TOLEID = ClsConvertTo.Int32(ddlTole.SelectedValue);
                DataTable dt = objTole.GetTole();
                txtNTole.Text = dt.Rows[0]["NDESC"].ToString();

                ddlTole.Style.Add("border", "");
            }
        }
        #endregion

        #region Binding

        public void BindInnitial()
        {
            FxBindZone();
            BindDistrict();

            //ddlZone.Items.Insert(0, "None");
            //ddlZone.Items[0].Value = "-1";
            //ddlZone.Items[0].Selected = true;
            //if (!ddlDistrict.Items.Contains(ddlDistrict.Items.FindByText("None")))
            //{
            //    ddlDistrict.Items.Insert(0, "None");
            //    conName = new List<string>();
            //    con = new List<string>();
            //    conName.Add("edescription");
            //    con.Add("None");
            //    ddlDistrict.Items[0].Value = ClsCommon.CodeDecode("District", "ID", conName, con, "");
            //    ddlDistrict.Items[0].Selected = true;
            //}
            //else
            //{
            //    ClsBind.FxComboSelectecIndex(ref ddlDistrict, "None", "txt");
            //}
            //ddlDistrict.DataSource = "";
            //ddlDistrict.DataBind();
            //ddlDistrict.Items.Insert(0, "None");
            //ddlDistrict.Items[0].Value = "-1";
            //ddlDistrict.Items[0].Selected = true;
            ////if (rblMnuVdc.SelectedValue == "0")
            ////{
            ////    if (!ddlMnuVdc.Items.Contains(ddlMnuVdc.Items.FindByText("None")))
            ////    {
            ////        ddlMnuVdc.Items.Insert(0, "None");
            ////        conName = new List<string>();
            ////        con = new List<string>();
            ////        conName.Add("mnu");
            ////        con.Add("None");
            ////        ddlMnuVdc.Items[0].Value = ClsCommon.CodeDecode("mnu", "mnucode", conName, con, "");
            ////        ddlMnuVdc.Items[0].Selected = true;
            ////    }
            ////    else
            ////    {
            ////        ClsBind.FxComboSelectecIndex(ref ddlMnuVdc, "None", "txt");
            ////    }
            ////}
            ////else
            ////{
            ////    if (!ddlMnuVdc.Items.Contains(ddlMnuVdc.Items.FindByText("None")))
            ////    {
            ////        ddlMnuVdc.Items.Insert(0, "None");
            ////        conName = new List<string>();
            ////        con = new List<string>();
            ////        conName.Add("vdc");
            ////        con.Add("None");
            ////        ddlMnuVdc.Items[0].Value = ClsCommon.CodeDecode("vdc", "vdccode", conName, con, "");
            ////        ddlMnuVdc.Items[0].Selected = true;
            ////    }
            ////    else
            ////    {
            ////        ClsBind.FxComboSelectecIndex(ref ddlMnuVdc, "None", "txt");
            ////    }
            ////}

            //ddlMnuVdc.DataSource = "";
            //ddlMnuVdc.DataBind();
            //ddlMnuVdc.Items.Insert(0, "None");
            //ddlMnuVdc.Items[0].Value = "-1";
            //ddlMnuVdc.Items[0].Selected = true;

            //ddlArea.DataSource = "";
            //ddlArea.DataBind();

            //if (!ddlArea.Items.Contains(ddlArea.Items.FindByText("None")))
            //{
            //    ddlArea.Items.Insert(0, "None");
            //    conName = new List<string>();
            //    con = new List<string>();
            //    conName.Add("edesc");
            //    con.Add("None");
            //    ddlArea.Items[0].Value = ClsCommon.CodeDecode("area", "areacode", conName, con, "");
            //    ddlArea.Items[0].Selected = true;
            //}
            //else
            //{
            //    ClsBind.FxComboSelectecIndex(ref ddlArea, "None", "txt");
            //}


            ////if (!ddlTole.Items.Contains(ddlTole.Items.FindByText("None")))
            ////{
            ////    ddlTole.Items.Insert(0, "None");
            ////    conName = new List<string>();
            ////    con = new List<string>();
            ////    conName.Add("edesc");
            ////    con.Add("None");
            ////    ddlTole.Items[0].Value = ClsCommon.CodeDecode("tole", "toleid", conName, con, "");
            ////    ddlTole.Items[0].Selected = true;
            ////}
            ////else
            ////{
            ////    ClsBind.FxComboSelectecIndex(ref ddlTole, "None", "txt");
            ////}
            //ddlTole.DataSource = "";
            //ddlTole.DataBind();
            //ddlTole.Items.Insert(0, "None");
            //ddlTole.Items[0].Value = "-1";
            //ddlTole.Items[0].Selected = true;
            rblMnuVdc.Items.FindByValue("0").Selected = true;
            txtNAddress.Font.Name = ClsCommon.NepaliFont;
            txtNArea.Font.Name = ClsCommon.NepaliFont;
            txtNTole.Font.Name = ClsCommon.NepaliFont;            
        }

        public void BindDistrict()
        {
            //clsDistrictBll objDistrict = new clsDistrictBll();
            //objDistrict.ZONEID = ClsConvertTo.Int32(ddlZone.SelectedValue);
            //DataTable dt = objDistrict.GetDistrict();


            bool isDataFromCache = false;
            DataTable dt = new DataTable();
            dt = SQLCACHE.dbCacheSetup.FxGetSetupFromCacheData("Cache_District", "District", "ID", "EDESCRIPTION", "Zoneid", "Zoneid = " + ClsConvertTo.Int32(ddlZone.SelectedValue), "EDESCRIPTION", out isDataFromCache);
            //ddlZone.DataSource = dt;
            //ddlZone.DataBind();

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ddlDistrict.DataSource = dt;
                    ddlDistrict.DataBind();                    
                }
            } 
            if (!ddlDistrict.Items.Contains(ddlDistrict.Items.FindByText("None")))
            {
                ddlDistrict.Items.Insert(0, "None");
                conName = new List<string>();
                con = new List<string>();
                conName.Add("edescription");
                con.Add("None");
                ddlDistrict.Items[0].Value = ClsCommon.CodeDecode("District", "ID", conName, con, "");
                ddlDistrict.Items[0].Selected = true;
            }
            else
            {
                ClsBind.FxComboSelectecIndex(ref ddlDistrict, "None", "txt");
            }
            //ddlDistrict.Items.Insert(0, "None");
            //ddlDistrict.Items[0].Value = "-1";
            //ddlDistrict.Items[0].Selected = true;
            BindMnuVdc();
            BindArea();
            BindTole();
        }

        public void BindMnuVdc()
        {
            clsMnuVdcBll objMnuVdc = new clsMnuVdcBll();
            if (ddlDistrict.SelectedValue == "-1")
            {
                ddlMnuVdc.DataSource = "";
                ddlMnuVdc.DataBind();
            }
            else
            {
                objMnuVdc.DISCODE = ClsConvertTo.Int32(ddlDistrict.SelectedValue);
                objMnuVdc.flag = Convert.ToBoolean(ClsConvertTo.Int32(rblMnuVdc.SelectedValue));
                DataTable dt = objMnuVdc.GetMnuVdc();

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ddlMnuVdc.DataTextField = "NAME";
                        ddlMnuVdc.DataValueField = "ID";
                        ddlMnuVdc.DataSource = dt;
                        ddlMnuVdc.DataBind();
                    }
                }
            }
            if (rblMnuVdc.SelectedValue == "0")
            {
                if (!ddlMnuVdc.Items.Contains(ddlMnuVdc.Items.FindByText("None")))
                {
                    ddlMnuVdc.Items.Insert(0, "None");
                    conName = new List<string>();
                    con = new List<string>();
                    conName.Add("mnu");
                    con.Add("None");
                    ddlMnuVdc.Items[0].Value = ClsCommon.CodeDecode("mnu", "mnucode", conName, con, "");
                    ddlMnuVdc.Items[0].Selected = true;
                }
                else
                {
                    ClsBind.FxComboSelectecIndex(ref ddlMnuVdc, "None", "txt");
                }
            }
            else
            {
                if (!ddlMnuVdc.Items.Contains(ddlMnuVdc.Items.FindByText("None")))
                {
                    ddlMnuVdc.Items.Insert(0, "None");
                    conName = new List<string>();
                    con = new List<string>();
                    conName.Add("vdc");
                    con.Add("None");
                    ddlMnuVdc.Items[0].Value = ClsCommon.CodeDecode("vdc", "vdccode", conName, con, "");
                    ddlMnuVdc.Items[0].Selected = true;
                }
                else
                {
                    ClsBind.FxComboSelectecIndex(ref ddlMnuVdc, "None", "txt");
                }
            }
        }

        //public void BindMnuVdcAddress()
        //{
        //    //for binding permanent address automatically
        //    clsMnuVdcBll objmnuvdc = new clsMnuVdcBll();
        //    objmnuvdc.ID = ClsConvertTo.Int32(ddlMnuVdc.SelectedValue);
        //    objmnuvdc.flag = Convert.ToBoolean(ClsConvertTo.Int32(rblMnuVdc.SelectedValue));
        //    DataTable dt = objmnuvdc.GetMnuVdc_Rpt();
        //    if (dt.Rows.Count > 0)
        //    {
        //        string address = txtEAddress.Text;
        //        string[] str = address.Split(' ');
        //        address = str[0] + " " + dt.Rows[0]["NAME"].ToString();
        //        txtEAddress.Text = address;

        //        string address2 = txtNAddress.Text;
        //        string[] str2 = address2.Split(' ');
        //        address2 = str2[0] + " " + dt.Rows[0]["NNAME"].ToString();
        //        txtNAddress.Text = address2;
        //    }
        //}

        public void BindArea()
        {
            ClsAreaBll objArea = new ClsAreaBll();
            objArea.ZONEID = ClsConvertTo.Int32(ddlZone.SelectedValue);
            objArea.DISTRICTID = ClsConvertTo.Int32(ddlDistrict.SelectedValue);
            objArea.MNUVDC = ClsConvertTo.Int32(rblMnuVdc.SelectedValue);
            if (rblMnuVdc.SelectedValue == "0")
                objArea.MNUCODE = ClsConvertTo.Int32(ddlMnuVdc.SelectedValue);
            else
                objArea.VDCCODE = ClsConvertTo.Int32(ddlMnuVdc.SelectedValue);
            objArea.WARDNO = txtWardNo.Text;
            DataTable dt = objArea.GetArea_None();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ddlArea.Items.Clear();
                    ddlArea.DataSource = dt;
                    ddlArea.DataBind();


                }
            }
            if (!ddlArea.Items.Contains(ddlArea.Items.FindByText("None")))
            {
                ddlArea.DataSource = "";
                ddlArea.DataBind();
                ddlArea.Items.Insert(0, "None");
                conName = new List<string>();
                con = new List<string>();
                conName.Add("EDESC");
                con.Add("None");
                ddlArea.Items[0].Value = ClsCommon.CodeDecode("AREA", "AREACODE", conName, con, "");
                ddlArea.Items[0].Selected = true;
            }
            else
            {
                ClsBind.FxComboSelectecIndex(ref ddlArea, "None", "txt");
            }

        }

        public void BindArea1(int area)
        {
            ClsAreaBll objArea = new ClsAreaBll();
            objArea.AREACODE = area;
            DataTable dt = objArea.GetArea_None();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ddlArea.Items.Clear();
                    ddlArea.DataSource = dt;
                    ddlArea.DataBind();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["EDESC"].ToString() != "None")
                        {
                            txtWardNo.Text = dt.Rows[i]["WARDNO"].ToString();
                        }

                    }
                }
            }

        }

        public void BindTole()
        {
            ClsToleBll objTole = new ClsToleBll();
            objTole.ZONEID = ClsConvertTo.Int32(ddlZone.SelectedValue);
            objTole.DISTRICTID = ClsConvertTo.Int32(ddlDistrict.SelectedValue);
            objTole.MNUVDC = ClsConvertTo.Int32(rblMnuVdc.SelectedValue);
            if (rblMnuVdc.SelectedValue == "0")
                objTole.MNUCODE = ClsConvertTo.Int32(ddlMnuVdc.SelectedValue);
            else
                objTole.VDCCODE = ClsConvertTo.Int32(ddlMnuVdc.SelectedValue);
            objTole.WARDNO = txtWardNo.Text;
            objTole.AREACODE = ClsConvertTo.Int32(ddlArea.SelectedValue);

            DataTable dt = objTole.GetTole();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ddlTole.DataSource = dt;
                    ddlTole.DataBind();

                }
            }
            if (!ddlTole.Items.Contains(ddlTole.Items.FindByText("None")))
            {
                ddlTole.Items.Insert(0, "None");
                conName = new List<string>();
                con = new List<string>();
                conName.Add("edesc");
                con.Add("None");
                ddlTole.Items[0].Value = ClsCommon.CodeDecode("tole", "toleid", conName, con, "");
                ddlTole.Items[0].Selected = true;
            }
            else
            {
                ClsBind.FxComboSelectecIndex(ref ddlTole, "None", "txt");
            }
        }
        //public void FxGetAddress()
        //{
        //    string address = "", naddress = "";
        //    if (!(ddlTole.SelectedIndex == -1 || ddlTole.SelectedItem.Text == "None"))
        //    {
        //        address = ddlTole.SelectedItem.Text;

        //        conName = new List<string>();
        //        con = new List<string>();
        //        conName.Add("toleid");
        //        con.Add(ddlTole.SelectedValue);
        //        naddress = ClsCommon.CodeDecode("tole", "ndesc", conName, con, "");
        //    }
        //    if (!(ddlArea.SelectedIndex == -1 || ddlArea.SelectedItem.Text == "None"))
        //    {
        //        if (address != "")
        //            address = address + ", ";
        //        address = address + ddlArea.SelectedItem.Text;

        //        if (naddress != "")
        //            naddress = naddress + ", ";
        //        conName = new List<string>();
        //        con = new List<string>();
        //        conName.Add("areacode");
        //        con.Add(ddlArea.SelectedValue);
        //        naddress = naddress + ClsCommon.CodeDecode("area", "ndesc", conName, con, "");
        //    }
        //    if (txtWardNo.Text.Trim()!="")
        //    {
        //        if (address != "")
        //            address = address + " ";
        //        address = address + txtWardNo.Text;
        //        if (naddress != "")
        //            naddress = naddress + ", "; 
        //        naddress = naddress + txtWardNo.Text;
        //    }
        //    if (!(ddlMnuVdc.SelectedIndex == -1 || ddlMnuVdc.SelectedItem.Text == "None"))
        //    {
        //        if (address != "")
        //            address = address + ", ";
        //        address = address + ddlMnuVdc.SelectedItem.Text;

        //        if (naddress != "")
        //            naddress = naddress + ", ";
        //        conName = new List<string>();
        //        con = new List<string>();
        //        if (rblMnuVdc.SelectedValue == "0")
        //        {
        //            conName.Add("mnucode");
        //            con.Add(ddlMnuVdc.SelectedValue);
        //            naddress = naddress + ClsCommon.CodeDecode("mnu", "nmnu", conName, con, "");
        //        }
        //        else
        //        {
        //            conName.Add("vdccode");
        //            con.Add(ddlMnuVdc.SelectedValue);
        //            naddress = naddress + ClsCommon.CodeDecode("vdc", "nvdc", conName, con, "");
        //        }

        //    }
        //    if (!(ddlDistrict.SelectedIndex == -1 || ddlDistrict.SelectedItem.Text == "None"))
        //    {
        //        if (address != "")
        //            address = address + ", ";
        //        address = address + ddlDistrict.SelectedItem.Text;

        //        if (naddress != "")
        //            naddress = naddress + ", ";
        //        conName = new List<string>();
        //        con = new List<string>();
        //        conName.Add("id");
        //        con.Add(ddlDistrict.SelectedValue);
        //        naddress = naddress + ClsCommon.CodeDecode("district", "ndescription", conName, con, "");
        //    }
        //    if (!(ddlZone.SelectedIndex == -1 || ddlZone.SelectedItem.Text == "None"))
        //    {
        //        if (address != "")
        //            address = address + ", ";
        //        address = address + ddlZone.SelectedItem.Text;

        //        if (naddress != "")
        //            naddress = naddress + ", ";
        //        conName = new List<string>();
        //        con = new List<string>();
        //        conName.Add("id");
        //        con.Add(ddlZone.SelectedValue);
        //        naddress = naddress + ClsCommon.CodeDecode("zone", "ndescription", conName, con, "");
        //    }
        //    txtEAddress.Text = address;
        //    txtNAddress.Text = naddress;
        //}

        #endregion

        #region Refresh Click Events

        public void btnRefreshZone_Click(object sender, EventArgs e)
        {
            ClearControl(this.Controls);
            BindInnitial();
        }

        public void btnRefreshDistrict_Click(object sender, EventArgs e)
        {
            ddlDistrict.ClearSelection();
            BindDistrict();
            //FxBindDistrict();
        }

        public void btnRefreshMnuVdc_Click(object sender, EventArgs e)
        {
            if (Session["popup_id"] != null)
            {
                if (rblMnuVdc.SelectedValue == "0")
                {
                    string mnucode = ClsConvertTo.String(Session["popup_id"]);
                    BindMnuVdc();
                    //FxBindMNUVDC();
                    ClsBind.FxComboSelectecIndex(ref ddlMnuVdc, mnucode, "val");
                    BindArea();
                    //FxBindArea();
                    BindTole();
                    //FxBindTole();
                }
                else
                {
                    string vdccode = ClsConvertTo.String(Session["popup_id"]);
                    BindMnuVdc();
                    //FxBindMNUVDC();
                    ClsBind.FxComboSelectecIndex(ref ddlMnuVdc, vdccode, "val");
                    BindArea();
                    //FxBindArea();
                    BindTole();
                    //FxBindTole();
                }
            }
        }

        public void btnRefreshArea_Click(object sender, EventArgs e)
        {
            if (Session["popup_id"] != null)
            {
                string areacode = ClsConvertTo.String(Session["popup_id"]);
                //BindArea1(ClsConvertTo.Int32(areacode));
                BindArea();
                //FxBindArea();
                ClsBind.FxComboSelectecIndex(ref ddlArea, areacode, "val");
                BindTole();
                //FxBindTole();
            }
        }

        public void btnRefreshTole_Click(object sender, EventArgs e)
        {
            if (Session["popup_id"] != null)
            {
                string toleid = ClsConvertTo.String(Session["popup_id"]);
                BindTole();
                //FxBindTole();
                ClsBind.FxComboSelectecIndex(ref ddlTole, toleid, "val");
            }
        }
        #endregion

        /// <summary>
        /// for clearing the input feilds
        /// </summary>
        /// <param name="ctrls"></param>
        private void ClearControl(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).ClearSelection();
                else if (ctrl is RadioButtonList)
                    ((RadioButtonList)ctrl).SelectedIndex=0;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Checked = false;

                ClearControl(ctrl.Controls);
            }
            ddlZone.Style.Add("border", "");
            ddlTole.Style.Add("border", "");
            ddlArea.Style.Add("border", "");
            txtWardNo.Style.Add("border", "");
            ddlMnuVdc.Style.Add("border", "");
            ddlDistrict.Style.Add("border", "");
        }

        #region Bind DropdownList

        public void FxBindZone()
        {
            //conName = new List<string>();
            //con = new List<string>();
            //ClsBind.FxLoadCombo(ref   ddlZone, "zone", "EDESCRIPTION", "ID", conName, con);

            bool isDataFromCache = false;
            DataTable dt = new DataTable();
            dt = SQLCACHE.dbCacheSetup.FxGetSetupFromCacheData("Cache_Zone", "zone", "ID", "EDESCRIPTION", "-1", "1=1", "EDESCRIPTION", out isDataFromCache);
            ddlZone.DataSource = dt;
            ddlZone.DataBind();

            if (!ddlZone.Items.Contains(ddlZone.Items.FindByText("None")))
            {
                ddlZone.Items.Insert(0, "None");
                ddlZone.Items[0].Value = "-1";
                ddlZone.Items[0].Selected = true;
                //ddlZone.Items.Insert(0, "None");
                //conName = new List<string>();
                //con = new List<string>();
                //conName.Add("edescription");
                //con.Add("None");
                //ddlZone.Items[0].Value = ClsCommon.CodeDecode("zone", "ID", conName, con, "");
                //ddlZone.Items[0].Selected = true;
            }
            else
            {
                ClsBind.FxComboSelectecIndex(ref ddlZone, "None", "txt");
            }
        }

        //public void FxBindDistrict()
        //{
        //    conName = new List<string>();
        //    con = new List<string>();
        //    conName.Add("ZONEID");
        //    con.Add(ddlZone.SelectedValue);
        //    ClsBind.FxLoadCombo(ref   ddlDistrict, "District", "EDESCRIPTION", "ID", conName, con, true, "EDESCRIPTION asc");
        //    if (!ddlDistrict.Items.Contains(ddlDistrict.Items.FindByText("None")))
        //    {
        //        ddlDistrict.Items.Insert(0, "None");
        //        conName = new List<string>();
        //        con = new List<string>();
        //        conName.Add("edescription");
        //        con.Add("None");
        //        ddlDistrict.Items[0].Value = ClsCommon.CodeDecode("district", "ID", conName, con, "");
        //        ddlDistrict.Items[0].Selected = true;
        //    }
        //    else
        //    {
        //        ClsBind.FxComboSelectecIndex(ref ddlZone, "None", "txt");
        //    }


        //    ddlMnuVdc.DataSource = "";
        //    ddlMnuVdc.DataBind();
        //    ddlMnuVdc.Items.Insert(0, "None");
        //    conName = new List<string>();
        //    con = new List<string>();
        //    conName.Add("mnu");
        //    con.Add("None");
        //    ddlMnuVdc.Items[0].Value = ClsCommon.CodeDecode("mnu", "MNUCODE", conName, con, "");
        //    ddlMnuVdc.Items[0].Selected = true;

        //    ddlArea.DataSource = "";
        //    ddlArea.DataBind();
        //    ddlArea.Items.Insert(0, "None");
        //    conName = new List<string>();
        //    con = new List<string>();
        //    conName.Add("EDESC");
        //    con.Add("None");
        //    ddlArea.Items[0].Value = ClsCommon.CodeDecode("AREA", "AREACODE", conName, con, "");
        //    ddlArea.Items[0].Selected = true;

        //    ddlTole.DataSource = "";
        //    ddlTole.DataBind();
        //    ddlTole.Items.Insert(0, "None");
        //    conName = new List<string>();
        //    con = new List<string>();
        //    conName.Add("EDESC");
        //    con.Add("None");
        //    ddlTole.Items[0].Value = ClsCommon.CodeDecode("TOLE", "TOLEID", conName, con, "");
        //    ddlTole.Items[0].Selected = true;
        //}

        //public void FxBindMNUVDC()
        //{

        //    conName = new List<string>();
        //    con = new List<string>();
        //    if (ddlDistrict.SelectedValue == "-1")
        //    {
        //        ddlMnuVdc.DataSource = "";
        //        ddlMnuVdc.DataBind();
        //    }
        //    else
        //    {
        //        if (rblMnuVdc.SelectedValue == "0")
        //        {

        //            ddlMnuVdc.DataTextField = "MNU";
        //            ddlMnuVdc.DataValueField = "MNUCODE";

        //            conName.Add("DISCODE");
        //            con.Add(ddlDistrict.SelectedValue);
        //            ClsBind.FxLoadCombo(ref   ddlMnuVdc, "mnu", "MNU", "MNUCODE", conName, con);
        //            //BindArea();
        //        }
        //        else
        //        {
        //            ddlMnuVdc.DataTextField = "vdc";
        //            ddlMnuVdc.DataValueField = "VDCCODE";

        //            conName.Add("DISCODE");
        //            con.Add(ddlDistrict.SelectedValue);
        //            ClsBind.FxLoadCombo(ref   ddlMnuVdc, "Vdc", "vdc", "VDCCODE", conName, con);
        //            //BindArea();
        //        }
        //    }
        //    //if (rblMnuVdc.SelectedValue == "0")
        //    //{
        //    //    if (!ddlMnuVdc.Items.Contains(ddlMnuVdc.Items.FindByText("None")))
        //    //    {
        //    //        ddlMnuVdc.Items.Insert(0, "None");
        //    //        conName = new List<string>();
        //    //        con = new List<string>();
        //    //        conName.Add("mnu");
        //    //        con.Add("None");
        //    //        ddlMnuVdc.Items[0].Value = ClsCommon.CodeDecode("mnu", "mnucode", conName, con, "");
        //    //        ddlMnuVdc.Items[0].Selected = true;
        //    //    }
        //    //    else
        //    //    {
        //    //        ClsBind.FxComboSelectecIndex(ref ddlMnuVdc, "None", "txt");
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    if (!ddlMnuVdc.Items.Contains(ddlMnuVdc.Items.FindByText("None")))
        //    //    {
        //    //        ddlMnuVdc.Items.Insert(0, "None");
        //    //        conName = new List<string>();
        //    //        con = new List<string>();
        //    //        conName.Add("vdc");
        //    //        con.Add("None");
        //    //        ddlMnuVdc.Items[0].Value = ClsCommon.CodeDecode("vdc", "vdccode", conName, con, "");
        //    //        ddlMnuVdc.Items[0].Selected = true;
        //    //    }
        //    //    else
        //    //    {
        //    //        ClsBind.FxComboSelectecIndex(ref ddlMnuVdc, "None", "txt");
        //    //    }
        //    //}
        //    ddlMnuVdc.Items.Insert(0, "None");
        //    ddlMnuVdc.Items[0].Value = "-1";
        //    ddlMnuVdc.Items[0].Selected = true;
        //    BindArea();
        //}

        //public void FxBindArea()
        //{

        //    conName = new List<string>();
        //    con = new List<string>();

        //    conName.Add("ZONEID");
        //    con.Add(ddlZone.SelectedValue);
        //    conName.Add("DISTRICTID");
        //    con.Add(ddlDistrict.SelectedValue);
        //    conName.Add("MNUVDC");
        //    con.Add(rblMnuVdc.SelectedValue);
        //    if (rblMnuVdc.SelectedValue == "0")
        //    {
        //        conName.Add("MNUCODE");
        //        con.Add(ddlMnuVdc.SelectedValue);
        //    }
        //    else
        //    {
        //        conName.Add("VDCCODE");
        //        con.Add(ddlMnuVdc.SelectedValue);
        //    }
        //    conName.Add("WARDNO");
        //    con.Add(txtWardNo.Text);
        //    //conName.Add("EDESC");
        //    //con.Add("85");
        //    ClsBind.FxLoadCombo(ref   ddlArea, "AREA", "EDESC", "AREACODE", conName, con);

        //    ddlArea.Items.Insert(0, "");
        //    ddlArea.Items[0].Value = "-1";
        //    ddlArea.Items[0].Selected = true;
        //}

        //public void FxBindTole()
        //{

        //    conName = new List<string>();
        //    con = new List<string>();

        //    conName.Add("ZONEID");
        //    con.Add(ddlZone.SelectedValue);
        //    conName.Add("DISTRICTID");
        //    con.Add(ddlDistrict.SelectedValue);
        //    conName.Add("MNUVDC");
        //    con.Add(rblMnuVdc.SelectedValue);
        //    if (rblMnuVdc.SelectedValue == "0")
        //    {
        //        conName.Add("MNUCODE");
        //        con.Add(ddlMnuVdc.SelectedValue);
        //    }
        //    else
        //    {
        //        conName.Add("VDCCODE");
        //        con.Add(ddlMnuVdc.SelectedValue);
        //    }
        //    conName.Add("WARDNO");
        //    con.Add(txtWardNo.Text);
        //    conName.Add("AREACODE");
        //    con.Add(ddlArea.SelectedValue);

        //    ClsBind.FxLoadCombo(ref   ddlTole, "TOLE", "EDESC", "TOLEID", conName, con);

        //    ddlTole.Items.Insert(0, "None");
        //    ddlTole.Items[0].Value = "-1";
        //    ddlTole.Items[0].Selected = true;
        //}

        //public void FxBindZoneDistrict()
        //{
        //    clsZoneBll objZone = new clsZoneBll();
        //    objZone.ID = ClsConvertTo.Int32(ddlZone.SelectedValue);
        //    DataTable dtZone = objZone.GetZone();

        //    if (dtZone.Rows.Count > 0)
        //    {
        //        txtEAddress.Text = dtZone.Rows[0]["EDESCRIPTION"].ToString();
        //        txtNAddress.Text = dtZone.Rows[0]["NDESCRIPTION"].ToString();

        //    }
        //}

        #endregion

     


    }
}