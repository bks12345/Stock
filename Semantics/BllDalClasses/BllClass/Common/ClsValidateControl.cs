using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Stock.BllDalClasses.BllClass.Common
{
    public class ClsValidateControl
    {
        public static Boolean FxIsValidDate(string prmDate)
        {
            TextBox txt = new TextBox();           
            return FxIsValidDate(prmDate, ref txt);
        }
        public static Boolean FxIsValidDate(string prmDate, ref TextBox txt)
        {
            try
            {
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(prmDate);
                return true;
            }
            catch
            {
                txt.Text = ClsCommon.ServerDate;
                return false;
            }
        }
        public static Boolean FxIsFutureDate(string prmDate)
        {
            try
            {
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(prmDate);
                

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static Boolean FxIsNumeric(string prmValue)
        {
            return FxIsNumeric(prmValue, false);
        }
        
        public static Boolean FxIsNumeric(string prmValue, Boolean IsCompulsory)
        {
            try
            {
                if (prmValue.Trim() != "")
                {
                    decimal _val = Convert.ToDecimal(prmValue);
                }
                else
                {
                    if (IsCompulsory)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ee)
            {
                return false;
            }
        }
        public static Boolean FxIsBlankControl(TextBox txt )
        {            
            if (txt.Text.Trim() == "")
                return true;
            else
                return false;
        }
        public static Boolean FxIsBlankControl(DropDownList ddl)
        {
            if (ClsConvertTo.Int32(ddl.SelectedValue)< 1)
                return true;
            else
                return false;
        }
    }
}