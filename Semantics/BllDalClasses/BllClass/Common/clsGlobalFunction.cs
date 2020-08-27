using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;

namespace Stock.BllDalClasses.BllClass.Common
{
    public class clsGlobalFunction
    {
        

        public void FxDatas(string j, ref int i, string datatype)
        {
            if (datatype == "int")
            {
                if (j.ToString().Trim() != "")
                {
                    i = ClsConvertTo.Int32(j);
                }
                else
                {
                    i = 0;
                }
            }
            else i = 0;
        }
        public void FxDatas(string j, ref double i, string datatype)
        {
            if (datatype == "int")
            {
                if (j.ToString().Trim() != "")
                {
                    i = Convert.ToDouble(j);
                }
                else
                {
                    i = 0;
                }
            }
            else i = 0;
        }

   

       
  
        
    }
}