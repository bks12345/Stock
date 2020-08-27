using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Stock.BllDalClasses.BllClass.Common
{
    public sealed class ExceptionUtility
    { 
        // All methods are static, so this can be private 
        private ExceptionUtility()
        { }

        // Log an Exception 
        public static void LogException(Exception exc, string source)
        {
            if (exc.InnerException != null)
            {
                // Include logic for logging exceptions
                // Get the absolute path to the log file
                string logFile = "~/App_Data/ErrorLog.txt";
                logFile = HttpContext.Current.Server.MapPath(logFile);
                // Open the log file for append and write the log
                StreamWriter sw = new StreamWriter(logFile, true);
                sw.WriteLine("********** {0} **********", DateTime.Now);
                sw.Write("Inner Exception: ");
                sw.WriteLine(exc.InnerException.Message);
                if (exc.InnerException.StackTrace != null)
                {
                    sw.WriteLine("Inner Stack Trace: ");
                    sw.WriteLine(exc.InnerException.StackTrace);
                }
                sw.Close();
            }
        }

        // Notify System Operators about an exception 
        public static void NotifySystemOps(Exception exc)
        {
            // Include code for notifying IT system operators
        }
    }
}