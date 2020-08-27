using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FriendlyErrorMsg.Text = "A problem has occurred on this web site. Please try again. " +
                "If this error continues, please contact support.";
            ErrorDetailedMsg.Text = Request.QueryString["msg"];
        }
    }
}