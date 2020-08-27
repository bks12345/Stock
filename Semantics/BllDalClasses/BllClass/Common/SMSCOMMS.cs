using System;
using System.Threading;
using System.ComponentModel;
using System.IO.Ports;
using System.Net;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using Ensure.DalClass.Common;
using Ensure.BllDalClasses.BllClass.Common;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class SMSCOMMS
{
    private SerialPort SMSPort;
    private Thread SMSThread;
    private Thread ReadThread;
    public static bool _Continue = false;
    public static bool _ContSMS = false;
    private bool _Wait = false;
    public static bool _ReadPort = false;
    public delegate void SendingEventHandler(bool Done);
    public event SendingEventHandler Sending;
    public delegate void DataReceivedEventHandler(string Message);
    public event DataReceivedEventHandler DataReceived;

    public  string CLASSNAME { get; set; }
    public string POLICYNO { get; set; }
    public string CLAIMNO { get; set; }
    public  string EXPIRYDT { get; set; }
    public  string MOBILENO { get; set; }
    public  string PHONENO { get; set; }
    public  string INSUREDNAME { get; set; }
    public string SURVEYORNAME { get; set; }
    public string SURVEYTYPE { get; set; }
    public  decimal AMOUNT1 { get; set; }
    public  decimal AMOUNT2 { get; set; }
    public  decimal AMOUNT3 { get; set; }
    public  decimal AMOUNT4 { get; set; }
    public  string CHEQUENO { get; set; }
    public  string BILLNO { get; set; }
    public  string RECEIVER { get; set; }
    public  int DOCID { get; set; }
    public  int CLAIMID { get; set; }
    public  int RENEWALID { get; set; }
    public int SMSTYPE { get; set; }
    public string IP { get; set; }
    public string PORT { get; set; }
    public string PINNO { get; set; }
    public bool ISRESEND { get; set; }
    public DateTime DATE { get; set; }
    //public SMSCOMMS(ref string COMMPORT)
    //{
    //    SMSPort = new SerialPort();
    //    SMSPort.PortName = COMMPORT;
    //    SMSPort.BaudRate = 9600;
    //    SMSPort.Parity = Parity.None;
    //    SMSPort.DataBits = 8;
    //    SMSPort.StopBits = StopBits.One;
    //    SMSPort.Handshake = Handshake.RequestToSend;
    //    SMSPort.DtrEnable = true;
    //    SMSPort.RtsEnable = true;
    //    SMSPort.NewLine = System.Environment.NewLine;
    //    ReadThread = new Thread(
    //        new System.Threading.ThreadStart(ReadPort));
    //}

    public static string SendSMS(string CellNumber, string SMSMessage)
    {
        #region previous code
        //string MyMessage = null;
        ////Check if Message Length <= 160
        //if (SMSMessage.Length <= 160)
        //    MyMessage = SMSMessage;
        //else
        //    MyMessage = SMSMessage.Substring(0, 160);
        //if (SMSPort.IsOpen == true)
        //{
        //    SMSPort.WriteLine("AT+CMGS=" + CellNumber + "r");
        //    _ContSMS = false;
        //    SMSPort.WriteLine(
        //    MyMessage + System.Environment.NewLine + (char)(26));
        //    _Continue = false;
        //    if (Sending != null)
        //        Sending(false);
        //}
        //return false;
        #endregion previous code



        string tag = "B";
        //string ac = "MIR222ARHN";
        //string user = "arhant";
        //string pw = "ARH!23";
        string ac = "";
        string user = "";
        string pw = "";
        string anotherUrl = "";
        string dt = DateTime.Now.ToString("yyyyMMddHHmmss");
    //    string anotherUrl = "http://api.miracleinfo.com.np/sms/smssend.php?" +
    //"tag=" + tag +
    //"&ac=" + ac +
    //"&dt=" + dt +
    //"&mob=" + CellNumber +
    //"&msg=" + SMSMessage +
    //"&u=" + user +
    //"&p=" + pw;

        try
        {
            ClsSmsProviderBll objSms = new ClsSmsProviderBll();
            DataTable dtSms = new DataTable();
            dtSms = objSms.FxSmsProviderGet();
            if (dtSms != null)
            {
                if (dtSms.Rows.Count > 0)
                {
                    ac = dtSms.Rows[0]["ACCOUNTNAME"].ToString();
                    user = dtSms.Rows[0]["USERNAME"].ToString();
                    pw = dtSms.Rows[0]["PASSWORD"].ToString();
                }
            }
            anotherUrl = "http://api.miracleinfo.com.np/sms/smssend.php?" +
    "tag=" + tag +
    "&ac=" + ac +
    "&dt=" + dt +
    "&mob=" + CellNumber +
    "&msg=" + SMSMessage +
    "&u=" + user +
    "&p=" + pw;
            WebRequest request = HttpWebRequest.Create(anotherUrl);
            // Get the response back  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            switch (dataString)
            {
                case "0":
                    return "ERROR!";
                    break;
                case "1":
                    return "SMS SENT SUCCESSFULLY!";
                    break;
                case "2":
                    return "INVALID TAG!";
                    break;
                case "3":
                    return "MISSING PARAMETER!";
                    break;
                case "4":
                    return "NULL PARAMETER!";
                    break;
                case "5":
                    return "INVALID ACCESS CODE!";
                    break;
                case "6":
                    return "INVALID USERNAME/PASSWORD!";
                    break;
                case "7":
                    return "Message length exceed more than 255 characters!";
                    break;
                case "8":
                    return "Invalid values in parameters like date incorrect format, mobile != 13 digits!";
                    break;
                case "9":
                    return "Balance not enough.!";
                    break;
                default:
                    return "ERROR IN COMMUNICATION!";
                    break;
            }
            response.Close();
            s.Close();
            readStream.Close();

            //inform the user
            return "SMS sent successfully!";
        }
        catch (Exception)
        {
            //if sending request or getting response is not successful, Ozeki NG - SMS Gateway Server may not be running
            return "Error while sending SMS!";
        }
    }
    public static string SendSMSNew(string CellNumber, string SMSMessage)
    {
        clsSmsProviderBll objSmsProvider = new clsSmsProviderBll();
        DataTable dt = objSmsProvider.TblSmsParam_ValueProviderSetupget();
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                string txtParam_1 = dt.Rows[0]["PARAMETER_1"].ToString();
                string txtvalue_1 = dt.Rows[0]["VALUE_1"].ToString();

                string txtParam_2 = dt.Rows[0]["PARAMETER_2"].ToString();
                string txtvalue_2 = dt.Rows[0]["VALUE_2"].ToString();

                string txtParam_3 = dt.Rows[0]["PARAMETER_3"].ToString();
                string txtvalue_3 = dt.Rows[0]["VALUE_3"].ToString();

                string txtParam_4 = dt.Rows[0]["PARAMETER_4"].ToString();
                string txtvalue_4 = dt.Rows[0]["VALUE_4"].ToString();

                string txtParam_5 = dt.Rows[0]["PARAMETER_5"].ToString();
                string txtvalue_5 = dt.Rows[0]["VALUE_5"].ToString();

                string txtParam_6 = dt.Rows[0]["PARAMETER_6"].ToString();
                string txtvalue_6 = dt.Rows[0]["VALUE_6"].ToString();

                StringBuilder _str = new StringBuilder();
                _str.AppendFormat(@txtParam_1, txtvalue_1);
                _str.AppendLine();
                _str.AppendFormat(txtParam_2, txtvalue_2);
                _str.AppendLine();
                _str.AppendFormat(txtParam_3, txtvalue_3);
                _str.AppendLine();
                _str.AppendFormat(txtParam_4, txtvalue_4);
                _str.AppendLine();
                _str.AppendFormat(txtParam_5, txtvalue_5);
                _str.AppendLine();
                _str.AppendFormat(txtParam_6, txtvalue_6);
                _str.AppendLine();
                string _st = _str.ToString().Replace("{{receiver}}", CellNumber);
                _st = _st.Replace("{{text}}", SMSMessage);
                _st = _st.Replace("\r\n", "");

                //using (var client = new HttpClient())
                //{
                //    client.DefaultRequestHeaders.Accept.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //    client.BaseAddress = new Uri(_st);
                //    var response = client.GetAsync("").Result;

                //    var res = "";
                //    if (response.IsSuccessStatusCode)
                //    {
                //        using (HttpContent content = response.Content)
                //        {
                //            // ... Read the string.
                //            Task<string> result = content.ReadAsStringAsync();
                //            res = result.Result;
                            
                //            DataTable dtValue = (DataTable)JsonConvert.DeserializeObject(res, (typeof(DataTable)));
                //            if (dtValue != null)
                //            {
                //                if (dtValue.Rows.Count > 0)
                //                { 
                //                    if(dtValue.Rows[0]["response_code"].ToString() == "200")
                //                    {

                //                        return "NEW SMS sent successfully!";
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}

                WebRequest request = HttpWebRequest.Create(_st);
            // Get the response back  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            switch (dataString)
            {
                case "0":
                    return "ERROR!";
                    break;
                case "1":
                    return "SMS SENT SUCCESSFULLY!";
                    break;
                case "2":
                    return "INVALID TAG!";
                    break;
                case "3":
                    return "MISSING PARAMETER!";
                    break;
                case "4":
                    return "NULL PARAMETER!";
                    break;
                case "5":
                    return "INVALID ACCESS CODE!";
                    break;
                case "6":
                    return "INVALID USERNAME/PASSWORD!";
                    break;
                case "7":
                    return "Message length exceed more than 255 characters!";
                    break;
                case "8":
                    return "Invalid values in parameters like date incorrect format, mobile != 13 digits!";
                    break;
                case "9":
                    return "Balance not enough.!";
                    break;
                default:
                    if (dataString.Contains("\"response_code\": 200"))
                        return "SMS sent successfully!";
                    else
                        return "ERROR IN COMMUNICATION!";
                    break;
            }
            response.Close();
            s.Close();
            readStream.Close();

            return "SMS sent successfully!";
            }
        }

        return "SMS provider configuration has not been done yet!";
    }


    public  string SmsFormat()
    {
        try
        {
            List<string> conName = new List<string>();
            List<string> con = new List<string>();
            int EnableSms = ClsConvertTo.Int32(ClsCommon.CodeDecode("companyprofile", "EnableSms", conName, con, ""));
            if (EnableSms == 1)
            {
                clsDocIssueInfo cls = new clsDocIssueInfo();
                if (DOCID > 0)
                {
                    cls.DocID = ClsConvertTo.Int32(DOCID);
                    DataTable dt = cls.Get_ClassName();
                    if (dt != null)
                    {
                        CLASSNAME = dt.Rows[0]["classname"].ToString();
                    }
                }
                string txt = "", msg = "";
                if (ISRESEND)
                    txt = "Re: ";
                ClsSmsFormatBll objFormat = new ClsSmsFormatBll();
                objFormat.SMSTYPECODE = SMSTYPE;
                objFormat.ISLOCK = 0;
                DataTable dtNew = objFormat.SmsFormat_Get();
                if (dtNew != null)
                {
                    if (dtNew.Rows.Count > 0)
                    {
                        txt = txt + dtNew.Rows[0]["smsformat"].ToString();
                        txt = txt.Replace("{{DT}}", DateTime.Now.ToString("yyyyMMddHHmmss"));
                        txt = txt.Replace("{{CLASSNAME}}", CLASSNAME);
                        txt = txt.Replace("{{POLICYNO}}", POLICYNO);
                        txt = txt.Replace("{{EXPIRYDT}}", EXPIRYDT);
                        txt = txt.Replace("{{MOBILENO}}", MOBILENO);
                        txt = txt.Replace("{{PHONENO}}", PHONENO);
                        txt = txt.Replace("{{INSUREDNAME}}", INSUREDNAME);
                        txt = txt.Replace("{{SURVEYORNAME}}", SURVEYORNAME);
                        txt = txt.Replace("{{AMOUNT1}}", AMOUNT1.ToString());
                        txt = txt.Replace("{{AMOUNT2}}", AMOUNT2.ToString());
                        txt = txt.Replace("{{AMOUNT3}}", AMOUNT3.ToString());
                        txt = txt.Replace("{{AMOUNT4}}", AMOUNT4.ToString());
                        txt = txt.Replace("{{CHEQUENO}}", CHEQUENO);
                        txt = txt.Replace("{{BILLNO}}", BILLNO);
                        txt = txt.Replace("{{CLAIMNO}}", CLAIMNO);
                        txt = txt.Replace("{{IP}}", IP);
                        txt = txt.Replace("{{PORT}}", PORT);
                        txt = txt.Replace("{{PINNO}}", PINNO);
                        txt = txt.Replace("{{SURVEYTYPE}}", SURVEYTYPE);
                        txt = txt.Replace("{{DATE}}", DBNullHandler.FormatDateTime(DATE));
                        txt = txt.Replace("{{COMPANYNAME}}", ClsCommon.CompanyName);
                        msg = SMSCOMMS.SendSMSNew(RECEIVER, txt);


                        ClsSmsLogBll objSmsLog = new ClsSmsLogBll();
                        objSmsLog.DOCID = DOCID;
                        objSmsLog.CLAIMID = CLAIMID;
                        objSmsLog.MOBILENO = RECEIVER;
                        objSmsLog.MESSAGE = txt;
                        objSmsLog.SENDTYPE = SMSTYPE;
                        objSmsLog.renewalid = RENEWALID;
                        objSmsLog.InsertUpdateSmsLog();
                        return msg;
                    }
                }
            }
            return "";
        }
        catch (Exception)
        {
            //if sending request or getting response is not successful, Ozeki NG - SMS Gateway Server may not be running
            return "Error while sending SMS!";
        }
    }

    private void ReadPort()
    {
        string SerialIn = null;
        byte[] RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
        string SMSMessage = null;
        int Strpos = 0;
        string TmpStr = null;
        while (SMSPort.IsOpen == true)
        {
            if ((SMSPort.BytesToRead != 0) & (SMSPort.IsOpen == true))
            {
                while (SMSPort.BytesToRead != 0)
                {
                    SMSPort.Read(RXBuffer, 0, SMSPort.ReadBufferSize);
                    SerialIn =
                        SerialIn + System.Text.Encoding.ASCII.GetString(
                        RXBuffer);
                    if (SerialIn.Contains(">") == true)
                    {
                        _ContSMS = true;
                    }
                    if (SerialIn.Contains("+CMGS:") == true)
                    {
                        _Continue = true;
                        if (Sending != null)
                            Sending(true);
                        _Wait = false;
                        SerialIn = string.Empty;
                        RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
                    }
                }
                if (DataReceived != null)
                    DataReceived(SerialIn);
                SerialIn = string.Empty;
                RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
            }
        }
    }

    
    //public bool SendSMS(string CellNumber, string SMSMessage)
    //{
    //    string MyMessage = null;
    //    if (SMSMessage.Length <= 160)
    //    {
    //        MyMessage = SMSMessage;
    //    }
    //    else
    //    {
    //        MyMessage = SMSMessage.Substring(0, 160);
    //    }
    //    if (SMSPort.IsOpen == true)
    //    {
    //        SMSPort.WriteLine("AT+CMGS=" + CellNumber + "r");
    //        _ContSMS = false;
    //        SMSPort.WriteLine(
    //            MyMessage + System.Environment.NewLine + (char)(26));
    //        _Continue = false;
    //        if (Sending != null)
    //            Sending(false);
    //    }
    //    return false;
    //}

    public void Open()
    {
        if (SMSPort.IsOpen == false)
        {
            SMSPort.Open();
            ReadThread.Start();
        }
    }

    public void Close()
    {
        if (SMSPort.IsOpen == true)
        {
            SMSPort.Close();
        }
    }

    //public static string BindMobNo(string Task, int DOCID, int ACCID)
    //{
    //    if (Task == "renew")
    //    {
    //        dbBankAssuranceEntities db = new dbBankAssuranceEntities();
    //        var dt = (from cu in db.tblCustomerSetups
    //                  where cu.ID == ACCID
    //                  select new
    //                  {
    //                      cu.ACCNO,
    //                      cu.FULLNAME,
    //                      cu.MOBILENO
    //                  }).FirstOrDefault();
    //        return dt.MOBILENO;
    //    }
    //    return "";
    //}
    //public static string BindMsg(string Task, int DOCID, int ACCID)
    //{
    //    if (Task == "renew")
    //    {
    //        dbBankAssuranceEntities db = new dbBankAssuranceEntities();
    //        var dt = (from cu in db.tblCustomerSetups
    //                  where cu.ID == ACCID
    //                  select new
    //                  {
    //                      cu.ACCNO,
    //                      cu.FULLNAME,
    //                      cu.MOBILENO
    //                  }).FirstOrDefault();
    //        var dt2 = (from pm in db.TBLPOLICYMASTERs
    //                   where (pm.DOCUMENTID == DOCID && pm.ACCOUNTID == ACCID)
    //                   join ins in db.defRICompanies on pm.INSCOMPID equals ins.ID
    //                   join br in db.MSBRANCHes on pm.BRANCHID equals br.BRANCHID
    //                   select new
    //                   {
    //                       pm.DOCUMENTNO,
    //                       pm.ISSDATE,
    //                       pm.ENDDATE,
    //                       insuranceComp = ins.NAME,
    //                       branch = br.ENAME,
    //                       branchAdd = br.ADDRESS,
    //                       branchPh = br.TELNO
    //                   }).FirstOrDefault();
    //        string msg = "Dear Mr./Mrs. " + dt.FULLNAME + ", Your policy (" + dt2.DOCUMENTNO + ") issued on " + DBNullHandler.FormatDateTime(dt2.ISSDATE)
    //            + " is going to expire on " + DBNullHandler.FormatDateTime(dt2.ENDDATE) + ". Please visit our office "
    //            + ClsCommon.CompanyName + " at " + dt2.branchAdd + " or contact in this no. " + dt2.branchPh + " for further information. Thank You!";
    //        return msg;
    //    }
    //    return "";
    //}
    //public static string InsertSmsLog( ref tblSmsLog sl)
    //{
    //    using (dbBankAssuranceEntities db = new dbBankAssuranceEntities())
    //    {
    //        using (var dbTrans = db.Database.BeginTransaction())
    //        {
    //            try
    //            {
    //                db.tblSmsLogs.Add(sl);
    //                db.SaveChanges();
    //                dbTrans.Commit();
    //                return "";
    //            }
    //            catch (Exception ex)
    //            {
    //                dbTrans.Rollback();
    //                return ex.Message;
    //            }
    //        }
    //    }
    //}

}