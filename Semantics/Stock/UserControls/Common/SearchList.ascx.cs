using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ensure.BllDalClasses.BllClass.Process;
using System.Data;
using Ensure.Ensure.Process.UserControls;
using Ensure.BllDalClasses.BllClass.Common;

namespace Ensure.Ensure.UserControls.Common
{
    public partial class SearchList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            FxBindList();
        }
        public event EventHandler MyEvent;
        protected void OnMyEvent(EventArgs e)
        {
            if (MyEvent != null)
                MyEvent(this, e);
        }
        protected void lbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsDocIssueBll objDocIss = new clsDocIssueBll();
            objDocIss.ACCOUNTNAMECODE = ClsConvertTo.Int64(lbName.SelectedValue);
            DataTable dt = objDocIss.GetAccByName();
            if (dt.Rows.Count > 0)
                txtName.Text = dt.Rows[0]["TITLE"].ToString();
            MyEventArgs mea = new MyEventArgs();
            mea.dtMessage = dt;
            OnMyEvent(mea);
        }

        public void FxBindList()
        {
            clsDocIssueBll objDocIss = new clsDocIssueBll();
            objDocIss.Title = txtName.Text;
            DataTable dt = objDocIss.GetAccByName();
            if (dt.Rows.Count <= 0)
            {
                //lbName.DataSource = null;
                //lbName.DataBind();
                ScriptManager.RegisterStartupScript(this, GetType(), "lbName", "alert('No Record Found!');", true);
            }
            else
            {
                lbName.DataSource = dt;
                lbName.DataBind();
            }
        }
    }
}