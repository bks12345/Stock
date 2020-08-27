using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stock.BllDalClasses.BllClass.Common;
//using Ensure.BllDalClasses.BllClass.Process;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Stock;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Web.UI.HtmlControls;
using Stock.BllDalClasses.BllClass.User;
using System.Web.Services;
using Newtonsoft.Json;
using Stock.DalClass.Common;

namespace Stock
{
    public partial class StockFront : System.Web.UI.Page
    {
        public string MENUNAME
        {
            get
            {
                if (ViewState["MENUNAME"] != null)
                {
                    return Convert.ToString(ViewState["MENUNAME"]);
                }
                else
                {
                    return "";
                }

            }
            set
            {
                ViewState["MENUNAME"] = value;
            }
        }
        public string PrmUserID
        {
            get
            {
                if (ViewState["PrmUserID"] != null)
                {
                    return ViewState["PrmUserID"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["PrmUserID"] = value;
            }
        }
        public string PrmKey
        {
            get
            {
                if (ViewState["PrmKey"] != null)
                {
                    return ViewState["PrmKey"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["PrmKey"] = value;
            }
        }

        int day = 0;
        bool isSubMenu = false;
        clsCommonEnumerator.ClaimStatus objClmSts = new clsCommonEnumerator.ClaimStatus();
        DataTable allCategories = new DataTable();
        public static List<HyperLink> hyperLinkLists = new List<HyperLink>();
        clsCommonEnumerator.Department objEnumDept = new clsCommonEnumerator.Department();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["for"]))
                {
                    if (Request.QueryString["for"] == "logout")
                    {
                        btnLogout_Click(sender, e);
                    }
                }
                if (ClsCommon.NepaliFont == "Mercantile")
                {
                    lnkNepaliFont.Attributes.Remove("href");
                    lnkNepaliFont.Attributes.Add("href", "Design/css1/Mercantil.css");
                }
            }

            //Prof.Visible = false;
            if (!(bool)Application["isStart"])
            {
                ////Application["isStart"] = false;
                ClsCommon.UserName = "";
                ClsCommon.BranchCode = "";
                Response.Redirect("/Login.aspx");
            }
            if (ClsCommon.UserName == "")
                Response.Redirect("/Login.aspx");
            else
            {
                if (!IsPostBack)
                {
                    clsCommonDal objCmn = new clsCommonDal();

                    ClsCommon.ServerDate = objCmn.GetDate();

                    lblCurrentUsername.Text = ".";// "User Name : " + ClsCommon.UserName;
                    lblUserName.Text = ClsCommon.UserName;

                    //below line is commented by sundar on 19may2017.
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('Welcome " + ClsCommon.UserName + "!');", true);

                    /* whether to check expiryday or not added by Sujeeb 2017-jan-31*/

                    if (ClsCommon.EXPIRYDAY > 0) // EXPIRYDAY is greater than zero for checking expiryday
                    {
                        if (!checkvalidDate())
                        {
                            if (day <= 0)
                            {

                                ////Application["isStart"] = false;
                                ClsCommon.UserName = "";
                                ClsCommon.BranchCode = "";
                                int _expi = 1;
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('Your password has been expired! Please contact your ADMINISTRATOR!');", true);

                                if (ClsCommon.CompanyId == (int)Enum_Company.NLGI)
                                    Response.Redirect("/Ensure/User/changepassword.aspx");
                                else
                                    Response.Redirect("/Login.aspx?expiry=" + _expi);


                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate2_", "alert('Your Password will expire in " + day.ToString() + " days!!\\nPlease Change your password as soon as possible!!');", true);
                                lblAlert.Visible = true;
                                lblAlert.Text = "Your Password will expire in " + day.ToString() + " days!! Please Change your password as soon as possible!!";
                                if (day == 3)
                                    Response.Redirect("/Ensure/User/changepassword.aspx");
                                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "openPage('/Ensure/User/changepassword.aspx');", true);
                            }
                        }
                        else
                        {
                            lblAlert.Visible = false;
                            lblAlert.Text = "";
                        }
                    }
                    //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "onPageLoad();", true);

                    //FetchImage();
                    Image1.Visible = true;
                    Image1.ImageUrl = "~/Ensure/Handlers/ImgHandler.ashx";
                    Image1.AlternateText = ClsCommon.CompanyName;
                    Timer1_Tick(sender, e);

                    // for displaying user image ----------------------------------
                    List<string> conName = new List<string>();
                    List<string> con = new List<string>();
                    conName.Add("id");
                    con.Add(ClsCommon.UserCode);
                    int emp_id = ClsConvertTo.Int32(ClsCommon.CodeDecode("tbluser", "id", conName, con, ""));
                    imgUser.Visible = true;
                    //System.Data.SqlClient.SqlDataReader rdr = null;
                    //System.Data.SqlClient.SqlConnection conn = null;
                    //System.Data.SqlClient.SqlCommand selcmd = null;

                    //clsCommonDal objCmn = new clsCommonDal();
                    //conn = new SqlConnection(objCmn.GetConnectionString());
                    //selcmd = new System.Data.SqlClient.SqlCommand("select Image from tblHR_employee where Emp_Id='" + emp_id + "'", conn);
                    //conn.Open();
                    //rdr = selcmd.ExecuteReader();
                    //while (rdr.Read())
                    //{
                    //    if (rdr["Image"] == DBNull.Value)
                    //    {
                    //        imgUser.ImageUrl = "~/Design/img1/dash-user.jpg";
                    //        //ImgUser2.ImageUrl = "~/Design/img1/dash-user.jpg";
                    //    }
                    //    else
                    //    {
                    //        imgUser.ImageUrl = "~/Ensure/Handlers/StaffImgHandler.ashx?empid=" + emp_id;
                    //        //ImgUser2.ImageUrl = "~/Ensure/Handlers/StaffImgHandler.ashx?empid=" + emp_id;
                    //    }
                    //}
                    //-------------------------------------------------------------------------

                    fxEncodedUserId();
                    lblNotificationCnt.Text = hdnNotificationNo.Value.ToString();



                    //UpdatePanel6.Update();
                }

            }
        }
        [WebMethod]
        public static string FxRegisterNotification()
        {
            //using (var connection111 = new SqlConnection(ConfigurationManager.ConnectionStrings["dbensureConnectionString"].ConnectionString))
            //{
            //    connection111.Open();
            //    using (SqlCommand command = new SqlCommand(@"select [id],[description] from dbo.tbl_NewsAndEventsLog", connection111))
            //    {
            //        command.Notification = null;
            //        SqlDependency.Start(ConfigurationManager.ConnectionStrings["dbensureConnectionString"].ConnectionString);
            //        SqlDependency dependency = new SqlDependency(command);
            //        dependency.OnChange += new OnChangeEventHandler(dependency_Onchange);
            //        if (connection111.State == ConnectionState.Closed)
            //            connection111.Open();
            //        using (var reader = command.ExecuteReader())
            //        {
            return "1";
            //        }
            //    }
            //}
        }
      

        private void FxOpenForm(ControlCollection ctrls, int sts)
        {
            HyperLink hp = new HyperLink();
            if (sts == 6 || sts == 7 || sts == 8)
                hp.ID = "l" + 5;
            else
                hp.ID = "l" + sts;
            foreach (Control ctrl in ctrls)
            {

                if (ctrl is HyperLink)
                {

                    if (((HyperLink)ctrl).ID == hp.ID)
                    {
                        pageContainer.Attributes.Remove("src");
                        pageContainer.Attributes.Add("src", ((HyperLink)ctrl).Attributes["href"]);
                        //pageContainer.Src = ((HyperLink)ctrl).Attributes["href"];
                        break;
                    }
                }
                FxOpenForm(ctrl.Controls, sts);
            }

        }

        private void FxRemoveLink(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {

                if (ctrl is HyperLink)
                {
                    //if (((HyperLink)ctrl).ID == id)
                    //{
                    ((HyperLink)ctrl).Attributes.Remove("href");
                    ((HyperLink)ctrl).Attributes.Remove("target");
                    ((HyperLink)ctrl).Attributes.Remove("class");
                    //}
                }
                FxRemoveLink(ctrl.Controls);
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            
        }
      

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            keephistory();
            MyHub obj = new MyHub();
            obj.Disconnect(ClsCommon.UserName.ToString(), ClsConvertTo.Int32(ClsCommon.UserCode.ToString()));
            ClsCommon.En_SumInsured = 0;
            ClsCommon.NepaliFont = "";
            ClsCommon.CompanyId = 0;
            ClsCommon.CompanyName = "";
            ClsCommon.BranchCode = "";
            ClsCommon.BranchId = 0;
            ClsCommon.UserName = "";
            ClsCommon.UserCode = "";
            ClsCommon.GroupCode = "";
            ClsCommon.IsAdmin = false;
            ClsCommon.SystemType = 0;
            ViewState.Clear();
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            keephistory();
            MyHub obj = new MyHub();
            obj.Disconnect(ClsCommon.UserName.ToString(), ClsConvertTo.Int32(ClsCommon.UserCode.ToString()));
            ClsCommon.En_SumInsured = 0;
            ClsCommon.NepaliFont = "";
            ClsCommon.CompanyId = 0;
            ClsCommon.CompanyName = "";
            ClsCommon.BranchCode = "";
            ClsCommon.BranchId = 0;
            ClsCommon.UserName = "";
            ClsCommon.UserCode = "";
            ClsCommon.GroupCode = "";
            ClsCommon.IsAdmin = false;
            ClsCommon.SystemType = 0;
            ClsCommon.LoginTry = 0;
            ViewState.Clear();
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "window.location.href.replace('/Login.aspx');", true);
        }
        private void keephistory()
        {
            ClsLoginHistory objhistory = new ClsLoginHistory();
            objhistory.USERID = ClsConvertTo.Int32(ClsCommon.UserCode);
            objhistory.LOGOUT_DATE = ClsConvertTo.DateTime(ClsCommon.ServerDate);
            objhistory.LOGOUT_TIME = ClsConvertTo.DateTime(ClsCommon.ServerDateTime).ToShortTimeString();


            objhistory.COMP_USER = ClsSecurity.GetComputername();// from common.cs it gets the name of the computer

            objhistory.BRANCHID = ClsCommon.BranchId;
            objhistory.UserName = ClsCommon.UserName;

            objhistory.COMP_IP = ClsSecurity.GetIP4Address(); // from common.cs it gets the IP of the compute
            objhistory.COMP_NAME = Environment.UserName;
            objhistory.ISSUCCESS = 1;
            objhistory.insertupdateUserHistory();
        }
      
       
        public void fxEncodedUserId()
        {
            int userid = ClsConvertTo.Int32(ClsCommon.UserCode) * 99;
            //byte[] encodedPassword = new UTF8Encoding().GetBytes(userid.ToString());
            //byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            //string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            string PrmUserId = ClsCrypto.GetEncryptedQueryString(userid.ToString());
            string Prmkey = ClsCrypto.Key;
            PrmKey = Prmkey;
            PrmUserID = PrmUserId;
        }
        public bool checkvalidDate()
        {
            bool returnValue = true;
            ClsUserBll objUser = new ClsUserBll();
            DataTable dt = objUser.getPassHistory();
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    TimeSpan dateDiff = ClsConvertTo.DateTime(dt.Rows[0]["EXPIRYDATE"].ToString()) - ClsConvertTo.DateTime(ClsCommon.ServerDate);
                    //ClsConvertTo.DateTime(ClsCommon.ServerDate);
                    day = ClsConvertTo.Int32(dateDiff.TotalDays);
                    //DateDifference diff = new DateDifference(ClsConvertTo.DateTime(ClsCommon.ServerDate), ClsConvertTo.DateTime(dt.Rows[0]["EXPIRYDATE"].ToString()));
                    //string[] strSplit = diff.ToString().Split(' ');
                    if (day <= ClsCommon.EXPIRYDAY)
                    {
                        returnValue = false;
                    }
                    else
                    {
                        returnValue = true;
                    }
                }

            }
            return returnValue;

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            
        }

      

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ClsSecurity.FxGetSecurityPermission("Re-Insurance", "Treaty", "Print"))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('You have no permission!');", true);
                    return;

                }
                //if (!PRINT)
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Sorry,No Print Permission!');", true);
                //    return;
                //}

                //if (ddlStatus.SelectedValue == "0")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Please save data!');", true);
                //      return;

                //}
                string rptFile = string.Empty;
                string _DocID = hdnDocumentid.Value;
                string _DeptID = hdnDepartmentid.Value;
                string _FacID = hdnFacId.Value;
                if (ClsConvertTo.Int32(_DeptID) == (int)objEnumDept.Fire)
                {
                    rptFile = "/Ensure/Reports/Process/Reinsurance/rptFacOfferLetter_Fire.rpt";
                }
                else if (ClsConvertTo.Int32(_DeptID) == (int)objEnumDept.Motor)
                {
                    rptFile = "/Ensure/Reports/Process/Reinsurance/rptFacOfferLetter_motor.rpt";
                }
                else if (ClsConvertTo.Int32(_DeptID) == (int)objEnumDept.Marine)
                {
                    rptFile = "/Ensure/Reports/Process/Reinsurance/rptFacOfferLetter_Marine.rpt";
                }
                else if (ClsConvertTo.Int32(_DeptID) == (int)objEnumDept.Miscellaneous)
                {
                    rptFile = "/Ensure/Reports/Process/Reinsurance/rptFacOfferLetter_misc.rpt";
                }
                else
                {
                    rptFile = "/Ensure/Reports/Process/Reinsurance/rptFacOfferLetter_Eng.rpt";
                }
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "window.open('/Ensure/Reports/RptTreatyDeclarationTemplates.aspx?PrmReportName=" + rptFile + "&&PrmOpenFrom=OFFER_LETTER_REPORTS" + "&&PrmDocumentID=" + _DocID + "&&PrmDepartmentID=" + _DeptID + "&&PrmFacID=" + _FacID + "','Graph');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;

            }
        }

        protected void imgRefresh_Click(object sender, ImageClickEventArgs e)
        {
            //GetPPWNotifications();
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "CallMyFunction1", "getPPWNotifications()", true);

        }

        protected void btnOk_Edit_Click(object sender, EventArgs e)
        {
            List<string> conName = new List<string>();
            List<string> con = new List<string>();
            conName.Add("documentno");
            con.Add(txtPolicyNo.Text.Trim());
            int docid = ClsConvertTo.Int32(ClsCommon.CodeDecode("docissue", "docid", conName, con, ""));
            if (docid <= 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "btnAdd_", "alert('This policy does not exists!');", true);
                return;
            }
            else
            {
                pageContainer.Attributes.Remove("src");
                pageContainer.Attributes.Add("src", "Ensure/Process/UnderwritingEX/frmWizA.aspx?DOCID=" + docid + "&&TASK=forceedit");
                //ScriptManager.RegisterStartupScript(this, GetType(), "btnAdd_", "document.getElementById(\"pageContainer\").src =  = \"Ensure/Process/UnderwritingEX/frmWizA.aspx?DOCID=" + docid + "&&TASK=forceedit\";", true);
            }
        }
       
    }
}