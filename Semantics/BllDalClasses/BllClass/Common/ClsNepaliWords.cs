using System;
using System.Collections.Generic;
using System.Text;
using Stock.BllDalClasses.BllClass.Common;


 public   class ClsNepaliWords
    {
        public string FxNepaliWords(double prmAmt)
        {
            string _leftpart = "";
            string _rightpart = "";
            string _firstletter = "";
            string[] vDelim = { "." };
            string _amt = prmAmt.ToString("0.00");
            
            string[] vArr = _amt.Split(vDelim, StringSplitOptions.RemoveEmptyEntries);
            _leftpart = vArr[0].ToString();
            _rightpart = vArr[1].ToString();
            string _prefix = "";
            string _inwords = "";
            int _len = _leftpart.Length;
            if (_len == 11)
            {
                _firstletter = _leftpart.Substring(0, 2);
                if (ClsConvertTo.Int32(_firstletter) > 0)
                {
                    _prefix = " ca{ ";
                    _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(_firstletter)) + _prefix;
                }
                    _leftpart = _leftpart.Substring(2, 9);
                    _len = _leftpart.Length;
            }
            if (_len == 10)
            {
                _firstletter = _leftpart.Substring(0,1);
                if (ClsConvertTo.Int32(_firstletter) > 0)
                {
                    _prefix = " ca{ ";
                    _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(_firstletter)) + _prefix;
                }
                    _leftpart = _leftpart.Substring(1, 9);
                    _len = _leftpart.Length;
            }
            if (_len == 9)
            {
                _firstletter = _leftpart.Substring(0, 2);
                if (ClsConvertTo.Int32(_firstletter) > 0)
                {
                    _prefix = " s/f]* ";
                    _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(_firstletter)) + _prefix;
                }
                    _leftpart = _leftpart.Substring(2, 7);
                    _len = _leftpart.Length;
            }
            if (_len == 8)
            {
                _firstletter = _leftpart.Substring(0, 1);
                if (ClsConvertTo.Int32(_firstletter) > 0)
                {
                    _prefix = " s/f]* ";
                    _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(_firstletter)) + _prefix;
                }
                    _leftpart = _leftpart.Substring(1, 7);
                    _len = _leftpart.Length;
            }
            if (_len == 7)
            {
                _firstletter = _leftpart.Substring(0, 2);
                if (ClsConvertTo.Int32(_firstletter) > 0)
                {
                    _prefix = " nfv ";
                    _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(_firstletter)) + _prefix;
                }
                    _leftpart = _leftpart.Substring(2, 5);
                    _len = _leftpart.Length;
            }
            if (_len == 6)
            {
                _firstletter = _leftpart.Substring(0, 1);
                if (ClsConvertTo.Int32(_firstletter) > 0)
                {
                    _prefix = " nfv ";
                    _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(_firstletter)) + _prefix;
                }
                    _leftpart = _leftpart.Substring(1, 5);
                    _len = _leftpart.Length;
            }
            if (_len == 5)
            {
                _firstletter = _leftpart.Substring(0, 2);
                if (ClsConvertTo.Int32(_firstletter) > 0)
                {
                    _prefix = " xhf/ ";
                    _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(_firstletter)) + _prefix;
                }
                    _leftpart = _leftpart.Substring(2, 3);
                    _len = _leftpart.Length;
            }
            if (_len == 4)
            {
                _firstletter = _leftpart.Substring(0, 1);
                if (ClsConvertTo.Int32(_firstletter) > 0)
                {
                    _prefix = " xhf/ ";
                    _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(_firstletter)) + _prefix;
                }
                    _leftpart = _leftpart.Substring(1, 3);
                    _len = _leftpart.Length;
            }
            if (_len == 3)
            {
                _firstletter = _leftpart.Substring(0, 1);
                if (ClsConvertTo.Int32(_firstletter) > 0)
                {
                    _prefix = " ;o ";
                    _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(_firstletter)) + _prefix;
                }
                    _leftpart = _leftpart.Substring(1, 2);
                    _len = _leftpart.Length;
            }
            if (_len <= 2)
            {
                if (ClsConvertTo.Int32(_rightpart) > 0)
                {
                    _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(_leftpart)) + " / ";
                }
                else
                {
                    _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(_leftpart)) + "dfq .";
                }
            }
            if (ClsConvertTo.Int32(_rightpart) > 0)
            {
                _inwords = _inwords + FxNepaliText(ClsConvertTo.Int32(ClsConvertTo.Int32(_rightpart))) + "k};f dfq .";
            }
            return _inwords;
        }

        public string FxNepaliText(int prmAmt)
        {
            switch (prmAmt)
            {
                case 1 :
                    return " Ps ";
                case 2:
                    return " bÚO{ ";                   
                case 3:
                    return " tLg ";
                case 4:
                    return " rf/ ";
                case 5:
                    return " kf¤r ";
                case 6:
                    return " % ";
                case 7:
                    return " ;ft ";
                case 8:
                    return " cf& ";
                case 9:
                    return " gf} ";
                case 10:
                    return " b; ";
                case 11:
                    return " P#f/ ";
                case 12:
                    return " afx| ";
                case 13:
                    return " t]x| ";
                case 14:
                    return " rf}w ";
                case 15:
                    return " kGw| ";
                case 16:
                    return " ;f]x| ";
                case 17:
                    return " ;q ";
                case 18:
                    return " c&f/ ";
                case 19:
                    return " pGgfO{; ";
                case 20:
                    return " aL; ";
                case 21:
                    return " PSsfO; ";
                case 22:
                    return " afO; ";
                case 23:
                    return " t]O; ";
                case 24:
                    return " rf}aL; ";
                case 25:
                    return " kRrL; ";
                case 26:
                    return " %AaL; ";
                case 27:
                    return " ;QfO; ";
                case 28:
                    return " c¶fO{; ";
                case 29:
                    return " pgfGtL; ";
                case 30:
                    return " tL; ";
                case 31:
                    return " PstL; ";
                case 32:
                    return " aQL; ";
                case 33:
                    return " t]QL; ";
                case 34:
                    return " rf}tL; ";
                case 35:
                    return " k}tL; ";
                case 36:
                    return " %QL; ";
                case 37:
                    return " ;}tL; ";
                case 38:
                    return " c&tL; ";
                case 39:
                    return " pgfGrfnL; ";
                case 40:
                    return " rfnL; ";
                case 41:
                    return " PsrfnL; ";
                case 42:
                    return " aofnL; ";
                case 43:
                    return " qLrfnL; ";
                case 44:
                    return " rf}jfnL; ";
                case 45:
                    return " k}tfnL; ";
                case 46:
                    return " %ofnL; ";
                case 47:
                    return " ;trfnL; ";
                case 48:
                    return " c&rfnL; ";
                case 49:
                    return " pgfGrf; ";
                case 50:
                    return " krf; ";
                case 51:
                    return " PsfpGg ";
                case 52:
                    return " afpGg ";
                case 53:
                    return " qLkGg ";
                case 54:
                    return " rf}jGg ";
                case 55:
                    return " krkGg ";
                case 56:
                    return " %kGg ";
                case 57:
                    return " ;GtfpGg ";
                case 58:
                    return " cG&fpGg ";
                case 59:
                    return " pgfG;f&L ";
                case 60:
                    return " ;f&L ";
                case 61:
                    return " Ps;f&L ";
                case 62:
                    return " af;f&L ";
                case 63:
                    return " qL;f&L ";
                case 64:
                    return " rf};f&L ";
                case 65:
                    return " k};f&L ";
                case 66:
                    return " %};f&L ";
                case 67:
                    return " ;&;f&L ";
                case 68:
                    return " c&;f&L ";
                case 69:
                    return " pgfG;Q/L ";
                case 70:
                    return " ;Q/L ";
                case 71:
                    return " PsQ/ ";
                case 72:
                    return " axQ/ ";
                case 73:
                    return " qLxQ/ ";
                case 74:
                    return " rf}xQ/ ";
                case 75:
                    return " krxQ/ ";
                case 76:
                    return " %}xQ/ ";
                case 77:
                    return " ;txQ/ ";
                case 78:
                    return " c&xQ/ ";
                case 79:
                    return " pgfgc;L ";
                case 80:
                    return " c;L ";
                case 81:
                    return " Psf;L ";
                case 82:
                    return " aof;L ";
                case 83:
                    return " qLof;L ";
                case 84:
                    return " rf}/f;L ";
                case 85:
                    return " krf;L ";
                case 86:
                    return " %}of;L ";
                case 87:
                    return " ;Qf;L ";
                case 88:
                    return " c&f;L ";
                case 89:
                    return " pgfGgAa] ";
                case 90:
                    return " gAa] ";
                case 91:
                    return " PsfgJj] ";
                case 92:
                    return " aofgJj] ";
                case 93:
                    return " qLofgAa ";
                case 94:
                    return " rf}/fgAa] ";
                case 95:
                    return " kGrfgAa] ";
                case 96:
                    return " %ofgAa] ";
                case 97:
                    return " ;GtfgAa] ";
                case 98:
                    return " cG&fgAa] ";
                case 99:
                    return " pgfG;o ";
            }
            return " ";
        }
    }

   

