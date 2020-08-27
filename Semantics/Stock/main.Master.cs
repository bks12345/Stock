using Stock.BllDalClasses.BllClass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock.Stock
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ClsCommon.NepaliFont == "Mercantile")
                {
                    lnkNepaliFont.Attributes.Remove("href");
                    lnkNepaliFont.Attributes.Add("href", "../Design/css1/Mercantil.css");
                }
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
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
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "window.location.href.replace('../../Login.aspx');", true);
        }
    }
}