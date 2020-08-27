using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Stock.Ensure.Process.UserControls
{
    public class MyEventArgs : EventArgs
    {
        public MyEventArgs()
        { }

        public string Message { get; set; }
        public DataTable dtMessage { get; set; }
        public Boolean boolean_Msg { get; set; }
    }
}