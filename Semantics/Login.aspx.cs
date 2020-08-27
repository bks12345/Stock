using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Stock.BllDalClasses.BllClass.Common;
using Stock.BllClass.Common;
using Stock.BllDalClasses.BllClass.User;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.Net.NetworkInformation;
using System.Web.Security;
using Stock.BllClass.Setup.Company;
using System.IO;
//using Ensure.BllDalClasses.BllClass.Process;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Stock.DalClass.Common;


namespace Stock
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                clsCommonDal objCmn = new clsCommonDal();
                ClsCommon.ServerDate = objCmn.GetDate();
                lblCurrentDate.Text = DBNullHandler.FormatDateTime(ClsCommon.ServerDate);

                    clsCompProfileBll objCompProfile = new clsCompProfileBll();
                    DataTable dt_CompanyProfile = new DataTable();
                    dt_CompanyProfile = objCompProfile.GetCompanyProfile();
                    if (dt_CompanyProfile != null)
                        if (dt_CompanyProfile.Rows.Count > 0)
                        {
                            Image1.Visible = true;
                            Image1.ImageUrl = "~/Ensure/Handlers/ImgHandler.ashx";
                            Image1.AlternateText = dt_CompanyProfile.Rows[0]["CompanyNameEng"].ToString();
                            lblAddress.Text = dt_CompanyProfile.Rows[0]["AddressEng"].ToString();
                            lblCompanyName.Text = dt_CompanyProfile.Rows[0]["CompanyNameEng"].ToString();
                            lblPh.Text = dt_CompanyProfile.Rows[0]["Phone1"].ToString() + "," + dt_CompanyProfile.Rows[0]["Phone2"].ToString();
                            lblFax.Text = dt_CompanyProfile.Rows[0]["fax"].ToString();
                            lblEmail.Text = dt_CompanyProfile.Rows[0]["email"].ToString();
                            lblWebSite.Text = dt_CompanyProfile.Rows[0]["website"].ToString();
                            //ClsCommon.getipaddress = ClsSecurity.GetIP4Address();

                            //if (ClsConvertTo.Int32(dt_CompanyProfile.Rows[0]["chkip"].ToString()) == 1)
                            //{
                            //    validateipaddress();
                            //}
                        }
                    if (!string.IsNullOrEmpty(Request.QueryString["expiry"]))
                    {
                        int _exp = ClsConvertTo.Int32(Request.QueryString["expiry"].ToString());
                        if (_exp == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate2_", "alert('Your Password has been expired. Please contact administrator!!'); window.location = '" + Page.ResolveUrl("~/Login.aspx") + "';", true);
                            return;
                        }
                    }
                //}
            }
        }
        private void validateipaddress()
        {
            // string getipaddr = ClsSecurity.GetIP4Address();
            ClsUserBll objbll = new ClsUserBll();
            objbll.IP_ADDR = ClsCommon.getipaddress;
            string msg = objbll.checkip();
            if (msg != null)
            {
                if (msg == "false")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate2_", "alert('You Dont have permission....Contact to Your System Admin!!');", true);
                    lblmsz.Visible = true;
                    lblmsz.Text = "Access Denied.....Please Contact System Administrator";
                    form1.Visible = false;
                    btnLogin.Visible = false;

                    return;
                }
                else if (msg == "true")
                {
                    lblmsz.Visible = false;
                    form1.Visible = true;
                    btnLogin.Visible = true;
                }
            }
        }
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            //if (ClsCommon.UserName != "")
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "alert('Already logged in by user : " + ClsCommon.UserName + "! Logout first!!');", true);
            //    return;
            //}

            //SingleSessionPreparation.CreateAndStoreSessionToken(txtusername.Text);
            FxLogin();
        }

        protected void Button1_OnClick(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\ISEMANTICS");

            // Creates the file I want to save, rather than having it in a location in my web application.
            using (FileStream fs = File.Create("C:\\ISEMANTICS\\temp.txt"))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                fs.Write(info, 0, info.Length);
            }
        }

        private void FxLogin()
        {
            


            ClsUserBll objuserbll = new ClsUserBll();
            clsCompProfileBll objCompProfile = new clsCompProfileBll();
            DataTable dt = new DataTable();
            DataTable dtcompany = new DataTable();
            objuserbll.USERID = txtusername.Text;
            byte[] encodedPassword = new UTF8Encoding().GetBytes(txtpassword.Text);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            objuserbll.PASSWORD = encoded;//txtpassword.Text;       
            //objuserbll.PASSWORD = txtpassword.Text;
            objuserbll.EMAIL = txtemail.Text.Trim();
            dt = objuserbll.GetLogin(objuserbll);
            dtcompany = objCompProfile.GetCompanyProfile();
            if (dtcompany != null)
            {
                if (dtcompany.Rows.Count > 0)
                {
                   
                    ClsCommon.NepaliFont = dtcompany.Rows[0]["FontFamily"].ToString();
                    ClsCommon.CompanyId = ClsConvertTo.Int32(dtcompany.Rows[0]["id"].ToString());
                    ClsCommon.CompanyName = dtcompany.Rows[0]["CompanyNameEng"].ToString();
                    ClsCommon.CompanyName_Nep = dtcompany.Rows[0]["CompanyNameNep"].ToString();
                
                    ClsCommon.VatReg = dtcompany.Rows[0]["VatReg"].ToString();
                 

                    //ClsCommon.AttachmentPath = dtcompany.Rows[0]["AttachmentPath"].ToString();
                    
                }
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["locked"].ToString() == "1")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('Your Account has been locked! Please contact your ADMINISTRATOR!');", true);
                        return;
                    }
                    if (dt.Rows[0]["msg"].ToString() == "Password Expire")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('Your password has been expired! Please contact your ADMINISTRATOR!');", true);
                        return;
                    }
                    ClsCommon.LoginTry = 0;
                    int brachid = ClsConvertTo.Int32(dt.Rows[0]["BRANCHCODE"].ToString());
                    int UserID = ClsConvertTo.Int32(dt.Rows[0]["ID"].ToString());
                    string username = dt.Rows[0]["UserName"].ToString();
                    Session["branchid"] = brachid;
                    Session["username"] = username;
                    Session["id"] = UserID;
                    getuserdata(dt);
                    //keephistory(1);
                    Response.Redirect("/StockFront.aspx");
                }
                else
                {
                    ClsCommon.LoginTry++;
                    keephistory(0);
                    try
                    {
                        Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                        Graphics graphics = Graphics.FromImage(bitmap as System.Drawing.Image);
                        graphics.CopyFromScreen(25, 25, 25, 25, bitmap.Size);
                        if (!System.IO.Directory.Exists(("C:/IEnsure/LoginTry/")))
                            System.IO.Directory.CreateDirectory(("C:/IEnsure/LoginTry/"));
                        bitmap.Save("C:/IEnsure/LoginTry/" + txtusername.Text + string.Format(@"{0}", DateTime.Now.Ticks) + ".bmp", ImageFormat.Bmp);
                    }
                    catch (Exception)
                    {
                    }
                    if (ClsCommon.LoginTry >= 3)
                    {
                        objuserbll.LockUser();
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('Your Account has been locked because of  3 times unsuccessfull password trial! Please contact ADMINISTRATOR!');", true);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('login Not Sucessfully!');", true);
                }
            }
        }
        private string GetIpValue()
        {
            string ip = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if(string.IsNullOrEmpty(ip))
            {
                ip = Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }
        private string GetIpAdd()
        {
            string ip = Request.UserHostAddress;
            if(ip!=null)
            {
                Int64 macinfo = new Int64();
                string macSrc = macinfo.ToString("X");
                if(macSrc=="0")
                {
                    if (ip != "127.0.0.1")
                        return ip;
                }
            }
            return ip;
        }
        private void keephistory(int issuccess)
        {
            ClsLoginHistory objhistory = new ClsLoginHistory();
            objhistory.USERID = ClsConvertTo.Int32(Session["id"]);
            objhistory.LOGIN_DATE = ClsConvertTo.DateTime(ClsCommon.ServerDate);
            objhistory.LOGOUT_DATE = ClsConvertTo.DateTime("18-oct-1980");
            objhistory.LOGIN_TIME = ClsConvertTo.DateTime(ClsCommon.ServerDateTime).ToShortTimeString();


            objhistory.COMP_USER = ClsSecurity.GetComputername();// from common.cs it gets the name of the computer

            objhistory.BRANCHID = ClsConvertTo.Int32(Session["branchid"]);
            objhistory.UserName = ClsConvertTo.String(Session["username"]);

            objhistory.COMP_IP = ClsSecurity.GetIP4Address() + ", " + GetIpValue() + ", " + GetIpAdd(); // from common.cs it gets the IP of the compute
            objhistory.COMP_NAME = Environment.UserName;
            objhistory.ISSUCCESS = issuccess;
            string msg = objhistory.insertupdateUserHistory();
            if (msg == null)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('Some problem Occured during Saving Login History!');", true);
                return;
            }
        }

        private void getuserdata(DataTable dt)
        {
            ClsCommon.BranchCode = dt.Rows[0]["BRANCHCODE"].ToString();
            List<string> conName = new List<string>();
            List<string> con = new List<string>();
            conName.Add("branchcode");
            con.Add(ClsCommon.BranchCode);
            ClsCommon.BranchId = ClsConvertTo.Int32(ClsCommon.CodeDecode("msbranch", "branchid", conName, con, ""));
            ClsCommon.UserName = dt.Rows[0]["USERNAME"].ToString();
            ClsCommon.UserCode = dt.Rows[0]["ID"].ToString();
            ClsCommon.IsAdmin = ClsConvertTo.Boolean(dt.Rows[0]["IsAdmin"].ToString());

            clsCompProfileBll objSystemType = new clsCompProfileBll();
            ClsCommon.SystemType = objSystemType.GetCompanySystemType();
            List<string> conName1 = new List<string>();
            List<string> con1 = new List<string>();
            ClsCommon.BranchName = dt.Rows[0]["BranchName"].ToString();
       
            //ClsCommon.DefaultLogInPage = ClsConvertTo.Int32(dt.Rows[0]["defaultloginpage"]);
          
        }


    }
}