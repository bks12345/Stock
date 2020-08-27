using Ensure.BllDalClasses.BllClass.Common;
using Ensure.BllDalClasses.BllClass.Process;
using Ensure.Reports;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ensure
{
    public partial class PdfConvertTest : System.Web.UI.Page
    {
        string mesg { get; set; }
       static string[] m_messge;
               ArrayList al = new ArrayList();

               static List<string> lstMessgae = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnConvetPDF_Click(object sender, EventArgs e)
        {
            string strmsg="";
            int _pdfConverter = 1;
            clsDocIssueInfo obj = new clsDocIssueInfo();
            obj.POLICYNO = txtPolicy.Text.Trim();
            DataTable dt = new DataTable();
            dt = obj.GetDocidBypolicyNo();
            if(dt!=null)
            {
                if(dt.Rows.Count>0)
                {
                    for(int i=0;i<dt.Rows.Count;i++)
                    {
                        int _docId = ClsConvertTo.Int32(dt.Rows[i]["Docid"].ToString());
                        Report rp = new Report();
                       
                        rp.FxOpenUWtemplates_XSD(_docId, 0, _pdfConverter, ref strmsg);
                        lstMessgae.Add(strmsg);
                        //al.Add(strmsg);
                        //m_messge[i] = m_messge[i] + ","; 
                        
                    }

                    if (lstMessgae.Count > 0)
                    {
                        Repeater1.DataSource = lstMessgae;
                        Repeater1.DataBind();
                        lstMessgae.Clear();
                    }
                    //foreach(string lstm1 in lstMessgae)
                    //{
                    //    ltrFileName.Text = lstm1.ToString() + "<br>";
                    //}
                   
                 
                   

                }
            }
           
           
           
        }

       private void GetFileName()
        {
           if(lstMessgae.Count>0)
           {
               Repeater1.DataSource = lstMessgae;
               Repeater1.DataBind();
           }
        }
    }
}