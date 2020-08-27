using Stock.BllDalClasses.BllClass.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Stock.Ensure.UserControls.Common
{
    public partial class Upload1 : System.Web.UI.UserControl
    {
        public event EventHandler MyEvent;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnMyEvent(EventArgs e)
        {
            if (MyEvent != null)
                MyEvent(this, e);
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    HttpFileCollection hfc = Request.Files;
            //    DataTable dt = new DataTable("NameTBl");
            //    for (int i = 0; i < hfc.Count; i++)
            //    {
            //        HttpPostedFile hpf = hfc[i];

            //        dt = GetDocs(hpf);
            //    }
            //    ClientPortalFileUpload.ClientPortalFileUpload wsCPFileUpload = new ClientPortalFileUpload.ClientPortalFileUpload();
            //    string msg = wsCPFileUpload.fxGetFilePath(ref dt, hdnClaimId.Value);
            //    string msg1 = "";
            //    if (msg != "")
            //    {
            //        ClsdocumentBll objdocbll = new ClsdocumentBll();


            //        if (ViewState["TblDocs"] != null)
            //        {
            //            DataTable dt1 = (DataTable)ViewState["TblDocs"];
            //            for (int j = 0; j < dt1.Rows.Count; j++)
            //            {
            //                objdocbll.docid = ClsConvertTo.Int32(hdnDocListID.Value);// do not use hdnClaimId.Value here; changes by sunila
            //                objdocbll.flepath = msg;
            //                objdocbll.AttachmntType = (int)Enum_Attachment.Client;
            //                objdocbll.FileData = (byte[])dt1.Rows[j]["FILEDATA"];
            //                objdocbll.filetype = dt1.Rows[j]["filetype"].ToString();
            //                objdocbll.CLAIMID = ClsConvertTo.Int32(hdnClaimId.Value);
            //                List<string> conname = new List<string>();
            //                List<string> conval = new List<string>();
            //                conname.Add("claimid");
            //                conval.Add(objdocbll.CLAIMID.ToString());
            //                objdocbll.BRANCHID = ClsConvertTo.Int32(ClsCommon.CodeDecode("tmclaimregproc", "branchid", conname, conval, ""));
            //                objdocbll.SUBBRANCHID = ClsConvertTo.Int32(ClsCommon.CodeDecode("tmclaimregproc", "subbranchid", conname, conval, ""));
            //                objdocbll.FISCALID = ClsConvertTo.Int32(ClsCommon.CodeDecode("tmclaimregproc", "fiscalid", conname, conval, ""));
            //                objdocbll.DOCUMENTNAME = dt1.Rows[j]["DOCUMENTNAME"].ToString();
            //                objdocbll.ID = _fileId;
            //                objdocbll.dtdoc = dt1;
            //                objdocbll.DOCUMENTLISTID = ClsConvertTo.Int32(hdnDocListID.Value);
            //                msg1 = objdocbll.insertupdatedocs();
            //            }
            //            if (msg1 != null)
            //            {

            //                #region Update ReDocumentName

            //                if (objdocbll.dtdoc != null)
            //                {
            //                    if (objdocbll.dtdoc.Rows.Count > 0)
            //                    {
            //                        for (int i = 0; i < objdocbll.dtdoc.Rows.Count; i++)
            //                        {
            //                            DataTable dt2 = new DataTable();
            //                            objdocbll.docid = ClsConvertTo.Int32(hdnDocListID.Value);
            //                            objdocbll.DOCUMENTNAME = objdocbll.dtdoc.Rows[i]["DOCUMENTNAME"].ToString();
            //                            dt2 = objdocbll.cpPolicyDocumentget();
            //                            if (dt2 != null)
            //                            {
            //                                if (dt2.Rows.Count > 0)
            //                                {
            //                                    _fileId = ClsConvertTo.Int32(dt2.Rows[0]["ID"].ToString());
            //                                    ClsdocumentBll objDoc1 = new ClsdocumentBll();
            //                                    objDoc1.ID = _fileId;
            //                                    objDoc1.DOCUMENTNAME = _fileId.ToString() + objdocbll.dtdoc.Rows[i]["filetype"].ToString();

            //                                    string msg2 = objDoc1.UpdateReDocumentName();
            //                                    objDoc1.CLAIMID = ClsConvertTo.Int32(hdnClaimId.Value);
            //                                    objDoc1.DOCUMENTLISTID = ClsConvertTo.Int32(hdnDocListID.Value);
            //                                    string msg4 = objDoc1.UpdateClaimDocsClientPortal();
            //                                    if (msg4 != null)
            //                                    {
            //                                        fxClientDashboard();
            //                                        checkWhetherUploadedorNot();
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //                #endregion
            //                fxBindListBox();
            //                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "btnSave_", "docView(" + hdnDocListID.Value + "," + hdnIsAccept.Value + ",'" + hdnDocName.Value + "');", true);
            //            }
            //        }
            //    }


            //    ViewState["TblDocs"] = null;
            //    ViewState["Sn"] = null;
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this, GetType(), "btnErr_", "alert('" + ex.Message + "')", true);
            //}
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            if (lbAttachment.SelectedValue == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "btnErr_", "alert('Please select an item from the list!!');", true);
                return;
            }
            List<string> conname = new List<string>();
            List<string> conval = new List<string>();
            //conname.Add("claimid");
            //conval.Add(hdnClaimId.Value);

            int BRANCHID = ClsConvertTo.Int32(ClsCommon.CodeDecode("tmclaimregproc", "branchid", conname, conval, ""));
            int SUBBRANCHID = ClsConvertTo.Int32(ClsCommon.CodeDecode("tmclaimregproc", "subbranchid", conname, conval, ""));
            int FISCALID = ClsConvertTo.Int32(ClsCommon.CodeDecode("tmclaimregproc", "fiscalid", conname, conval, ""));

            //hdnDocListID.Value = lbAttachment.SelectedValue;
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "popupOpener", "var popup=window.open('DocumentViewer.aspx?DOCUMENTID=" + lbAttachment.SelectedValue +
               "&&BRANCHID=" + BRANCHID + "&&FISCALID=" + FISCALID + "&&SUBBRANCHID=" + SUBBRANCHID + "');popup.focus();", true);
        }

        protected void btnShowList_Click(object sender, EventArgs e)
        {
            //if (hdnTask.Value == "UPLOAD")
            //{
            //    if (ClsCommon.USERTYPE == (int)Enum_Client_UserType.Surveyor)
            //    {
            //        btnUpload.Visible = false;
            //        fileUpload.Visible = false;
            //        btnView.Visible = true;
            //    }
            //    else
            //    {
            //        btnUpload.Visible = true;
            //        fileUpload.Visible = true;
            //        btnView.Visible = false;
            //    }
            //}
            //else if (hdnTask.Value == "VIEW")
            //{
            //    btnUpload.Visible = false;
            //    fileUpload.Visible = false;
            //    btnView.Visible = true;
            //}
            //else if (hdnTask.Value == "VIEW/UPLOAD")
            //{
            //    if (ClsCommon.USERTYPE == (int)Enum_Client_UserType.Surveyor)
            //    {
            //        btnUpload.Visible = false;
            //        fileUpload.Visible = false;
            //        btnView.Visible = true;
            //    }
            //    else
            //    {
            //        btnUpload.Visible = true;
            //        fileUpload.Visible = true;
            //        btnView.Visible = true;
            //    }
            //}
            //fxBindListBox();
        }
    }
}