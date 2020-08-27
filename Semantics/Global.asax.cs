using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Stock.BllDalClasses.BllClass.Common;
using System.Net.NetworkInformation;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.Web.UI;

namespace Stock
{
    public class Global : System.Web.HttpApplication
    {
        public static bool isStart { get; set; }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
           
            if (Request.HttpMethod == "GET")
            {
                if (
                    //Request.AppRelativeCurrentExecutionFilePath.EndsWith("RiReportPreview.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("GeneralReportPreview.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("ClaimReportPreview.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("SubRptTemplates.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("RptTreatyDeclarationTemplaes.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("RptTemplates.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("RptRenewalTemplates.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("RPTHistoryReportTemplates.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("RptClaimTemplates.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("SurveyorAppointRpt.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("ClaimPaidDetailsRpt.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("ClaimNoteRpt.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("ClaimMemoRpt.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("ClaimFollowUp.aspx")
                    //|| Request.AppRelativeCurrentExecutionFilePath.EndsWith("SectionRpt.aspx")
                    //|| 
                    Request.AppRelativeCurrentExecutionFilePath.EndsWith("CrystalImageHandler.aspx"))
                { }
                else if (Request.AppRelativeCurrentExecutionFilePath.EndsWith(".aspx"))
                {
                    Response.Filter = new Dropthings.Web.Util.ScriptDeferFilter(Response);
                }
            }

            //Ping _ping = new Ping();
            //try
            //{

            //    PingReply _rply = _ping.Send("202.52.234.178");
            //    Response.Write("status: " + _rply.Status.ToString() + "<br/>");
            //    Response.Write("RoundTrip Time: " + _rply.RoundtripTime.ToString() + "<br/>");
            //}
            //catch (Exception ex)
            //{
            //    //Response.Write(ex.Message);
            //}

            
        }
        void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            if (HttpContext.Current.Profile != null)
            {
                if (ClsCommon.IdleTimeOut > 0)
                {
                    if (ClsCommon.LastReqDateTime == ClsConvertTo.DateTime(""))
                    {
                        ClsCommon.LastReqDateTime = DateTime.Now;
                    }

                    TimeSpan span = DateTime.Now.Subtract(ClsCommon.LastReqDateTime);

                    decimal min = ClsConvertTo.Decimal(span.Days) * 24 * 60 + ClsConvertTo.Decimal(span.Hours) * 60 + ClsConvertTo.Decimal(span.Minutes) + ClsConvertTo.Decimal(span.Seconds) / 60;
                    //Configuration config = WebConfigurationManager.OpenWebConfiguration("~/Web.Config");
                    //SessionStateSection section = (SessionStateSection)config.GetSection("system.web/sessionState");
                    //int timeout = (int)section.Timeout.TotalMinutes;
                    if (min > ClsCommon.IdleTimeOut)
                    {
                        ClsCommon.LastReqDateTime = ClsConvertTo.DateTime("");
                        //Response.Redirect("~/SemanticsFront.aspx?for=logout");
                        //string url = Server.MapPath("~/SemanticsFront.aspx");
                        //url = url + "?for=logout";

                        Response.Write("<script language='javascript'>window.top.location.replace(window.location.protocol+'//'+window.location.host+'/'+'SemanticsFront.aspx?for=logout');</script>");
                        //Response.Write("<script>window.parent.location.href ='/Login.aspx';</script>");
                    }
                    else
                    {
                        ClsCommon.LastReqDateTime = DateTime.Now;
                    }
                }
            }
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["dbensureConnectionString"].ConnectionString);
            Application["isStart"] = true;
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["dbensureConnectionString"].ConnectionString);
            Application["isStart"] = false;
        }

        void Application_Error(object sender, EventArgs e)
        {
            #region 1st try
            //// Code that runs when an unhandled error occurs
            //// Code that runs when an unhandled error occurs

            //// Get the exception object.
            //Exception exc = Server.GetLastError();

            //// Handle HTTP errors
            //if (exc.GetType() == typeof(HttpException))
            //{
            //    // The Complete Error Handling Example generates
            //    // some errors using URLs with "NoCatch" in them;
            //    // ignore these here to simulate what would happen
            //    // if a global.asax handler were not implemented.
            //    if (exc.Message.Contains("NoCatch") || exc.Message.Contains("maxUrlLength") || exc.Message.Contains("File does not exist"))
            //        return;

            //    //Redirect HTTP errors to HttpError page
            //    Server.Transfer("~/HttpErrorPage.aspx");
            //}

            //// For other kinds of errors give the user some information
            //// but stay on the default page
            //Response.Write("<h2>Global Page Error</h2>\n");
            //Response.Write(
            //    "<p>" + exc.Message + "</p>\n");
            //Response.Write("Return to the <a href='DashBoard.aspx'>" +
            //    "Default Page</a>\n");

            //// Log the exception and notify system operators
            //ExceptionUtility.LogException(exc, "DefaultPage");
            //ExceptionUtility.NotifySystemOps(exc);

            //// Clear the error from the server
            //Server.ClearError();
            #endregion 1st try
            Exception exc = Server.GetLastError();
            if (exc is HttpUnhandledException)
            {
                // Pass the error on to the error page.
                //Server.Transfer("~/HttpErrorPage.aspx?handler=Application_Error%20-%20Global.asax&&error=" + exc.Message + "&&inner=" + exc.InnerException, true);
                //Server.TransferRequest("~/HttpErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
                //Session["error"] = exc;
                Server.Transfer("~/HttpErrorPage.aspx?handler=Application_Error%20-%20Global.asax", true);
            }
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            ////// Code that runs when a session ends. 
            ////// Note: The Session_End event is raised only when the sessionstate mode
            ////// is set to InProc in the Web.config file. If session mode is set to StateServer 
            ////// or SQLServer, the event is not raised.
            ////// You've handled the error, so clear it. Leaving the server in an error state can cause unintended side effects as the server continues its attempts to handle the error.
            ////Server.ClearError();

            ////// Possible that a partially rendered page has already been written to response buffer before encountering error, so clear it.
            ////Response.Clear();

            ////// Finally redirect, transfer, or render a error view
            //System.Web.Profile.ProfileBase curSession = HttpContext.Current.Profile;
            //curSession["UserName"] = "";
            //Context.Server.ClearError();
            //Context.Response.AddHeader("Location", "/SemanticsFront.aspx?for=logout");
            //Context.Response.TrySkipIisCustomErrors = true;
            //Context.Response.StatusCode = (int)System.Net.HttpStatusCode.Redirect;
            //// End now end the current request so we dont leak.
            //Context.Response.Output.Close();
            //Context.Response.End();
            //this.Response.Redirect("~/frmWizA.aspx");
        }
        //protected void Application_AcquireRequestState(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string lcReqPath = Request.Path.ToLower();

        //        // Session is not stable in AcquireRequestState - Use Current.Session instead.
        //        System.Web.SessionState.HttpSessionState curSession = HttpContext.Current.Session;

        //        // If we do not have a OK Logon (remember Session["LogonOK"] = null; on logout, and set to true on logon.)
        //        //  and we are not already on loginpage, redirect.

        //        // note: on missing pages curSession is null, Test this without 'curSession == null || ' and catch exception.
        //        if (lcReqPath != "/SemanticsFront.aspx" &&
        //            (curSession == null || curSession["UserName"] == ""))
        //        {
        //            // Redirect nicely
        //            Context.Server.ClearError();
        //            Context.Response.AddHeader("Location", "/SemanticsFront.aspx?for=logout");
        //            Context.Response.TrySkipIisCustomErrors = true;
        //            Context.Response.StatusCode = (int)System.Net.HttpStatusCode.Redirect;
        //            // End now end the current request so we dont leak.
        //            Context.Response.Output.Close();
        //            Context.Response.End();
        //            return;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        // todo: handle exceptions nicely!
        //    }
        //}
        //void Application_PostAcquireRequestState(object sender, EventArgs e)
        //{
        //        bool forceLogout = false;
        //    HttpContext context = ((HttpApplication)sender).Context;
        //    if (context.Session != null && !string.IsNullOrEmpty(context.Profile["UserName"].ToString()))
        //    {
        //        if (context.Session["userLoggedInAt"] == null)
        //            forceLogout = true;
        //        else if (!(context.Session["userLoggedInAt"] is DateTime))
        //            forceLogout = true;
        //        else if (DateTime.UtcNow > ((DateTime)context.Session["userLoggedInAt"]).AddMinutes(30))
        //            forceLogout = true;

        //        if (forceLogout)
        //        {
        //            FormsAuthentication.SignOut();
        //            FormsAuthentication.RedirectToLoginPage();
        //        }
        //    }
        //}

    }
}
