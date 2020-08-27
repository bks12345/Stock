using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace Stock.Ensure.UserControls.Common
{
    public partial class DefaultPopup : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void OnError(string msg)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", "openPopup('" + msg + "');", true);
        }
    }
}