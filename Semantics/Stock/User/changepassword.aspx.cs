using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stock.BllDalClasses.BllClass.Common;
using Stock.BllDalClasses.BllClass.User;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Configuration;
using System.Text;
using System.Net;
//using System.Web.Mail;
using System.Net.Mail;

namespace Stock.Ensure.User
{
    public partial class changepassword : System.Web.UI.Page
    {
        string _password = "";
        string _staffusername = "";
      
        string _randomKey = "";
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

        
        //string id = string.Empty;
        //string userName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["id"] = ClsCommon.UserCode;
            GetPassword();
            if (!IsPostBack)
            {
                PAGEID = 125;
                FxSecurityAccess();
            }
        }

        public void FxSecurityAccess()
        {
            //DataTable dt = ClsSecurity.FxGetPageSecurityForUser(PAGEID);
            //if (dt.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {

            //        if (ClsConvertTo.Int32(dt.Rows[i]["SecuritySno"]) == (int)Enum_Security_Setup_User_Entry.Change_Password)
            //            EDIT = ClsConvertTo.Boolean(dt.Rows[i]["HASPERMISSION"]);

            //    }
            //}
            //else
            //{

                EDIT = true;

            //}
        }

        protected void GetPassword()
        {
            ClsUserBll objUser = new ClsUserBll();
            DataTable dt_user = new DataTable();
            dt_user = objUser.GetUser(ClsConvertTo.Int32(ClsCommon.UserCode));
            lbluserID.Text = dt_user.Rows[0]["USERNAME"].ToString();
            Session["PreviousPassword"] = dt_user.Rows[0]["password"].ToString();

            lbllastupdatedate.Text = DBNullHandler.FormatDateTime(dt_user.Rows[0]["UDT"]).ToString();
            //Session["PreviousPassword"] = Decrypt(dt_user.Rows[0][3].ToString(), true); // This is used to decrypt the password
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            //if (!EDIT)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate", "alert('You have no permission to Change Password!');", true);
            //    return;
            //}
            txtNewPassword.Style.Add("border", " ");
            txtPrevPassword.Style.Add("border", " ");
            txtConfirmPassword.Style.Add("border", " ");


            byte[] encodedPassword = new UTF8Encoding().GetBytes(txtPrevPassword.Text);
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
            string encoded = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();

            string txtprevPassword = encoded;
            string txtnewPassword = txtNewPassword.Text.ToString();
            string txtconfirmPassword = txtConfirmPassword.Text.ToString();
            if (txtPrevPassword.Text == txtnewPassword)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Previous password and New Password Should Not be Same!!!');", true);
                return;
            }
            string PreviousPassword = Session["PreviousPassword"].ToString();


            if (txtprevPassword != "" && txtnewPassword != "" && txtconfirmPassword != "")
            {
                if (PreviousPassword == txtprevPassword)
                {
                    if (txtnewPassword == txtconfirmPassword)
                    {
                        byte[] encodedPasswordNew = new UTF8Encoding().GetBytes(txtnewPassword.ToString());
                        byte[] hashNew = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPasswordNew);
                        string encodedNew = BitConverter.ToString(hashNew).Replace("-", string.Empty).ToLower();
                        _password = txtNewPassword.Text.Trim();
                        ClsUserBll objUser = new ClsUserBll();
                        objUser.ID = ClsConvertTo.Int32(ClsCommon.UserCode);
                        //objUser.PASSWORD = Encrypt(txtnewPassword.ToString(), true);  //used to encrypt the password
                        objUser.PASSWORD = encodedNew;
                        objUser.UUID = ClsCommon.UserCode;
                        objUser.UDT = ClsConvertTo.DateTime(ClsCommon.ServerDate);
                        string message = objUser.updateUserPassword();
                        if(message != null)
                        {
                            if (message.Contains("error"))
                            {
                                string[] strSplit = message.Split('/');
                                ScriptManager.RegisterStartupScript(this, GetType(), "btnSave_", "alert('Error occured while Updating Password!!!\\nError No. : " + strSplit[1].ToString() + "');", true);
                                Clear();
                            }
                            else
                            {
                                if (message.ToLower() == "update")
                                {
                                    if (ClsCommon.SendActivationCode == 1)
                                    {
                                        fxSendEmailMessage();
                                    }
                                    Clear();
                                    string msg = " Password Changed successfully!Please Login with new password";
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
                                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ScriptKey", "alert('"+msg+"');window.location='Login.aspx'; ", true);
                                    //ShowMessage_Redirect(this.Page, msg, "../Login.aspx");

                                    //Response.Write("<script> alert('"+msg+"');window.location='Login.aspx'; </script>");
                                    //ScriptManager.RegisterStartupScript(this, GetType(), "", "confirmReport();", true);

                                    string url = "../../Login.aspx";
                                    string script = "{ alert('";
                                    script += msg;
                                    script += "');";
                                    script += "window.top.location.href = '";
                                    script += url;
                                    script += "'; }";
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", script, true);
                                   
                                   
                                }
                               
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('your new password and confirm password doesnot match!!!');", true);
                        txtNewPassword.Style.Add("border", "solid 1px red");
                        txtPrevPassword.Focus();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('your previous password is not valid!!!');", true);
                    txtPrevPassword.Style.Add("border", "solid 1px red");
                    txtPrevPassword.Focus();
                }
            }
            else
            {
                if (txtprevPassword == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Please provide your previous password!!!');", true);
                    txtPrevPassword.Style.Add("border", "solid 1px red");
                    txtPrevPassword.Focus();
                }
                else if (txtnewPassword == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Please provide your new password!!!');", true);
                    txtNewPassword.Style.Add("border", "solid 1px red");
                    txtNewPassword.Focus();
                }
                else if (txtconfirmPassword == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "", "alert('Please provide your confirm password!!!');", true);
                    txtConfirmPassword.Style.Add("border", "solid 1px red");
                    txtConfirmPassword.Focus();
                }
            }
        }
        protected void btnShowOmc_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
        public void ShowMessage_Redirect(System.Web.UI.Page page, string Message, string Redirect_URL)
        {
            string alertMessage = "<script language=\"javascript\" type=\"text/javascript\">";

            alertMessage += "alert('" + Message + "');";
            alertMessage += "window.location.href=\"";
            alertMessage += Redirect_URL;
            alertMessage += "\";";
            alertMessage += "</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + alertMessage + "');", true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "", "alert();", true);
            //ClientScript.RegisterClientScriptBlock(GetType(), "alertMessage ", alertMessage);

        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            txtNewPassword.Text = "";
            txtPrevPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtPrevPassword.Focus();
            txtNewPassword.Style.Add("border", " ");
            txtPrevPassword.Style.Add("border", " ");
            txtConfirmPassword.Style.Add("border", " ");
        }


        private void fxSendEmailMessage()
        {
            List<string> conName1 = new List<string>();
            List<string> conVal1 = new List<string>();
            conName1 = new List<string>();
            conVal1 = new List<string>();
            conName1.Add("id");
            conVal1.Add(ClsCommon.UserCode);
            string _EmpId = ClsCommon.CodeDecode("tbluser", "emp_id", conName1, conVal1, "");
            string _username = ClsCommon.CodeDecode("tbluser", "userid", conName1, conVal1, "");
            int empId = ClsConvertTo.Int32(_EmpId);


            List<string> conName2 = new List<string>();
            List<string> conVal2 = new List<string>();
            conName2 = new List<string>();
            conVal2 = new List<string>();
            conName2.Add("Emp_Id");
            conVal2.Add(_EmpId);
          

            string _fname = ClsCommon.CodeDecode("tblHR_employee", "firstname", conName2, conVal2, "");
            string _middlename = ClsCommon.CodeDecode("tblHR_employee", "middlename", conName2, conVal2, "");
            string _lastname = ClsCommon.CodeDecode("tblHR_employee", "lastname", conName2, conVal2, "");
            string _staffEmail = ClsCommon.CodeDecode("tblHR_employee", "Email", conName2, conVal2, "");
            //_EmpId = ClsConvertTo.Int32(ddlstaff.SelectedValue);
            string _staffName = "";
            if (_middlename == "")
            {
                _staffName = _fname + " " + _lastname;
            }
            else
            {
                _staffName = _fname + " " + _middlename + " " + _lastname;
            }

            //List<string> conName2 = new List<string>();
            //List<string> conVal2 = new List<string>();
            //conName2 = new List<string>();
            //conVal2 = new List<string>();
            //conName2.Add("Emp_Id");
            //conVal2.Add(ddlstaff.SelectedValue);
            //string _username = ClsCommon.CodeDecode("tbluser", "userid", conName2, conVal2, "");
            //RandomActivationCode(); 
            ClsSendMail objMail = new ClsSendMail();
            objMail.RandomActivationCode(ref _randomKey);
            string msgRrt = objMail.SendActivationEmail(_staffEmail, _staffName, empId, _username, _password,ref _randomKey);
            if (string.IsNullOrEmpty(msgRrt))
            {

                ClsUserBll obj = new ClsUserBll();
                obj.EMPID = empId;
                obj.ACTIVATIONCODE = _randomKey;
                obj.UpdateUserActivationCode();

                ClsUserBll obj1 = new ClsUserBll();
                obj1.EMPID = empId;
                obj1.FLAG = 1;
                obj1.UpdateUserIsActivate();
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('Confirmation email has been sent.!');", true);


            }
            else
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('"+msgRrt+"');", true);
        }

        //private bool SendActivationEmail(string userEmail, string name, int empId, string usrname, string pass)
        //{
        //    try
        //    {
        //        string _email = "";
        //        string _Password = "";
        //        string ActivationUrl = string.Empty;

        //        #region Sender Details
        //        List<string> conName = new List<string>();
        //        List<string> conVal = new List<string>();
        //        conName = new List<string>();
        //        conVal = new List<string>();
        //        conName.Add("ISENABLED");
        //        conVal.Add("1");
        //        string _Port = ClsCommon.CodeDecode("DEF_SMTP_SETUP", "port", conName, conVal, "");
        //        string _host = ClsCommon.CodeDecode("DEF_SMTP_SETUP", "hostname", conName, conVal, "");
        //        _email = ClsCommon.CodeDecode("DEF_SMTP_SETUP", "email", conName, conVal, "");
        //        _Password = ClsCommon.CodeDecode("DEF_SMTP_SETUP", "password", conName, conVal, "");
        //        #endregion

        //        //MailAddress from = new MailAddress(_email, "Admin");
        //        //MailAddress to = new MailAddress(userEmail, name);
        //        //MailMessage msg = new MailMessage(from, to);

        //        MailMessage msg;
        //        msg = new MailMessage();
        //        SmtpClient smtp = new SmtpClient(_Port);
        //        //emailId = txtEmailId.Text.Trim();
        //        //sender email address
        //        msg.From = new MailAddress(ClsCommon.CompanyName + " " + _email);
        //        //Receiver email address
        //        msg.To.Add(name + " " + userEmail);
        //        msg.Subject = "Confirmation email for account activation";


        //        string _empId = ClsCrypto.GetEncryptedQueryString(empId.ToString());

        //        /*For Testing: Replace the local host path with your lost host path
        //         *For Live: Replace local host path wtih your live domain address 
        //         */
        //        ActivationUrl = ("http://localhost:6465/activateaccount.aspx?EmpID=" + _empId + "&ActivationCode=" + _randomKey);

        //        //string companyName = "";
        //        //string Address = "";
        //        //string contact = "";
        //        //string fax = "";
        //        //string email = "";
        //        //string website = "";
        //        //clsCompProfileBll objCompProfile = new clsCompProfileBll();
        //        //DataTable dt_CompanyProfile = new DataTable();
        //        //dt_CompanyProfile = objCompProfile.GetCompanyProfile();
        //        //if (dt_CompanyProfile != null)
        //        //{
        //        //    if (dt_CompanyProfile.Rows.Count > 0)
        //        //    {
        //        //        Address = dt_CompanyProfile.Rows[0]["AddressEng"].ToString();
        //        //        companyName = dt_CompanyProfile.Rows[0]["CompanyNameEng"].ToString();
        //        //        //lblPoBox.Text = dt_CompanyProfile.Rows[0]["CompanyNameEng"].ToString();
        //        //        contact = dt_CompanyProfile.Rows[0]["Phone1"].ToString() + "," + dt_CompanyProfile.Rows[0]["Phone2"].ToString();
        //        //        fax = dt_CompanyProfile.Rows[0]["fax"].ToString();
        //        //        email = dt_CompanyProfile.Rows[0]["email"].ToString();
        //        //        website = dt_CompanyProfile.Rows[0]["website"].ToString();
        //        //    }
        //        //}

        //        //string body = "Hello " + name + ",";
        //        //body += "<br /><br />Please click the following link to activate your account";
        //        //body += "<br /><a href = '" + ActivationUrl + "'>Click here to activate your account.</a>";
        //        //body += "<br /><br />Thanks" + ",";
        //        //body += "<br /><br />" + "<b>" + companyName + "</b>";
        //        //body += "<br /><br />" + Address;
        //        //body += "<br />" + contact;
        //        //body += "<br />" + email;
        //        //body += "<br />" + website;

        //        string body = "<html><head><title></title></head>"
        //            + "<body style=\"margin:0; padding:0;\">"
        //            + "<div style=\"width: 750px;\">"
        //            + "<h1 style=\"padding:10px; text-align:center; background:#005099; margin:0; font-size:32px; text-transform:capitalize; color:#fff;\">" + ClsCommon.CompanyName + "</h1>"
        //            + "<div style=\"padding:20px 40px;\">"
        //            + "<p style=\"font-size:25px;\">Hi <strong> " + name + "</strong>, just one more step!</p>"
        //            + "<p style=\"font-size:18px;\">We just need to verify email address to complete Signup Process.</p>"
        //            + "<form style=\"text-align:center;font-weight:bold;\">"
        //             + "<p>Username: " + usrname + "</p>"
        //            + "<p>Email id: " + userEmail + "</p>"
        //            + "<p style=\"margin-bottom:25px;\">Password:" + pass + "</p>"
        //            + "<a style=\" background:#008a00; color:#fff; padding:10px; border:1px solid #008a00;text-decoration:none;font-weight:normal;\" href = '" + ActivationUrl + "'>Verify Your Email</a>"
        //            //+ "<button style=\" background:#008a00; color:#fff; padding:10px; border:1px solid #008a00;\">Veirify Your Email</button>"
        //            + "</form>"
        //            + "</div>"
        //            + "<div style=\" border-top: 1px solid #ccc; bottom: 0; position: absolute; width: 750px; padding:10px 0;\">"

        //            + "<div style=\"width:100%; float:left;  text-align:center;\">"

        //            + "<p style=\" margin-top: 10px;\">&copy; 2016 copyright. All Rights Reserved</p>"

        //            + "</div>"

        //            + "</div>"

        //            + "</div>"
        //            + "</body>"
        //            + "</html>";


        //        msg.Body = body;



        //        //msg.Body = "Hi " + name + "!\n" +
        //        //      "Thanks for showing interest and registring in <a href='asdf'>Ensure<a> " +
        //        //      " Please <a href='" + ActivationUrl + "'>click here to activate</a>  your account and enjoy our services. \nThanks!";
        //        msg.IsBodyHtml = true;
        //        smtp.Credentials = new NetworkCredential(_email, _Password);
        //        //smtp= new SmtpClient(_Port);
        //        //smtp.Port = ClsConvertTo.Int32(_Port);
        //        smtp.Host = _host;
        //        smtp.EnableSsl = true;
        //        smtp.Send(msg);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
        //        return false;

        //    }


        //}
        public void RandomActivationCode()
        {
            string Password = "";
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789~!@";
            var random = new Random();
            var result = new string(
            Enumerable.Repeat(chars, 16)
                  .Select(s => s[random.Next(s.Length)])
                  .ToArray());
            Password = result.ToString();

            _randomKey = Password;


        }

        #region For Password Encryption
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            string key = "Syed Moshiur Murshed"; //(string)settingsReader.GetValue("SecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = "Syed Moshiur Murshed";//(string)settingsReader.GetValue("SecurityKey", typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        #endregion

        protected void txtPrevPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPrevPassword.Text.Trim() != "")
            {
                txtPrevPassword.Style.Add("border", " ");
            }
            else
            {
                txtPrevPassword.Style.Add("border", "solid 1px red");
            }
        }

        protected void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtNewPassword.Text.Trim() != "")
            {
                txtNewPassword.Style.Add("border", " ");
            }
            else
            {
                txtNewPassword.Style.Add("border", "solid 1px red");
            }
        }

        protected void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != "")
            {
                txtConfirmPassword.Style.Add("border", " ");
            }
            else
            {
                txtConfirmPassword.Style.Add("border", "solid 1px red");
            }
        }
    }
}