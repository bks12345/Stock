using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ensure.BllDalClasses.BllClass.Common;
using Ensure.BllDalClasses.BllClass.User;
using Ensure.BllClass.Setup.Company;
using System.Data;
using Ensure.BllDalClasses.BllClass.Setup.Staff;

namespace Ensure
{
    public partial class activateaccount : System.Web.UI.Page
    {
        public int empId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    //lblPoBox.Text = dt_CompanyProfile.Rows[0]["CompanyNameEng"].ToString();
                    lblPh.Text = dt_CompanyProfile.Rows[0]["Phone1"].ToString() + "," + dt_CompanyProfile.Rows[0]["Phone2"].ToString();
                    lblFax.Text = dt_CompanyProfile.Rows[0]["fax"].ToString();
                    lblEmail.Text = dt_CompanyProfile.Rows[0]["email"].ToString();
                    lblWebSite.Text = dt_CompanyProfile.Rows[0]["website"].ToString();
                }
            if (!IsPostBack)
            {
                fxActivateAccount();
            }

        }

        private void fxActivateAccount()
        {
            try
            {
                if (Request.QueryString["EmpID"] != null && Request.QueryString["ActivationCode"]!=null)
                {
                    empId = int.Parse(ClsCrypto.GetDecryptedQueryString(Request.QueryString["EmpID"].ToString()));
                    string activationCode = Request.QueryString["ActivationCode"].ToString();
                    List<string> conName1 = new List<string>();
                    List<string> conVal1 = new List<string>();
                    conName1 = new List<string>();
                    conVal1 = new List<string>();
                    conName1.Add("Emp_id");
                    conVal1.Add(empId.ToString());
                    string _activaCode = ClsCommon.CodeDecode("tbluser", "ACTIVATIONCODE", conName1, conVal1, "");
                    string _IsActivate = ClsCommon.CodeDecode("tbluser", "ISACTIVATE", conName1, conVal1, "");

                    if (activationCode == _activaCode)
                    {
                        //List<string> conName = new List<string>();
                        //List<string> conVal = new List<string>();
                        //conName = new List<string>();
                        //conVal = new List<string>();
                        //conName.Add("Emp_id");
                        //conVal.Add(empId.ToString());
                       
                        if (_IsActivate == "1")
                        {
                            lblMessage.Text = "Your account has already been activated!";
                            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('Your Account has already been activated!');", true);
                            return;
                        }
                        else
                        {

                            ClsUserBll obj = new ClsUserBll();
                            obj.EMPID = empId;
                            obj.FLAG = 0;
                            if (obj.UpdateUserIsActivate())
                            {
                                //lblMessage.Text = "Thank You.Your account has been activated. You can <a href='login.aspx'>Login</a> now! ";
                                lblMessage.Text = "Thank You.Your account has been activated.";
                                //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('Thank You.Your account has been activated!!');", true);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('Something wrong occured!');", true);
                            }


                        }

                    }
                    else
                    {
                        lblMessage.Text = "Sorry!! Activation Code does not match.";
                        //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnCreate_", "alert('Sorry!! Activation Code doesnot match.');", true);
                    }



                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave", "alert('" + ex.Message + "');", true);
                return;

            }

        }
    }
}