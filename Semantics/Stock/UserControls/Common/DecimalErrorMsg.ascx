<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DecimalErrorMsg.ascx.cs" Inherits="Stock.Ensure.UserControls.Common.DecimalErrorMsg" %>
<script src="/Design/js1/jquery.1.11.1.min.js" type="text/javascript"></script>
<table id="DecimalOnly" class="customvalidatorcalloutstyle ajax__validatorcallout_popup_table"
        cellspacing="0" cellpadding="0" border="0" width="200px" style="display: none;
   position: absolute; z-index: 1000;">
        <tbody>
            <tr class="ajax__validatorcallout_popup_table_row">
                <td class="ajax__validatorcallout_callout_cell">
                    <table class="ajax__validatorcallout_callout_table" cellspacing="0" cellpadding="0"
                        border="0">
                        <tbody>
                            <tr class="ajax__validatorcallout_callout_table_row">
                                <td class="ajax__validatorcallout_callout_arrow_cell">
                                    <div class="ajax__validatorcallout_innerdiv">
                                        <div style="width: 14px;">
                                        </div>
                                        <div style="width: 13px;">
                                        </div>
                                        <div style="width: 12px;">
                                        </div>
                                        <div style="width: 11px;">
                                        </div>
                                        <div style="width: 10px;">
                                        </div>
                                        <div style="width: 9px;">
                                        </div>
                                        <div style="width: 8px;">
                                        </div>
                                        <div style="width: 7px;">
                                        </div>
                                        <div style="width: 6px;">
                                        </div>
                                        <div style="width: 5px;">
                                        </div>
                                        <div style="width: 4px;">
                                        </div>
                                        <div style="width: 3px;">
                                        </div>
                                        <div style="width: 2px;">
                                        </div>
                                        <div style="width: 1px;">
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td class="ajax__validatorcallout_icon_cell">
                    <img border="0" src="../../../../../Design/Icon/information (2).png">
                </td>
                <td class="ajax__validatorcallout_error_message_cell">
                    Enter numbers / decimal numbers only!
                </td>
                <td class="ajax__validatorcallout_close_button_cell">
                    <div class="ajax__validatorcallout_innerdiv">
                        <img src="../../../../../Design/Icon/close_small_icon.gif" onclick="closeDecErr();">
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <script type="text/javascript">
        function closeDecErr() {
            document.getElementById("DecimalOnly").style.display = "none";
            return false;
        }
    var specialKeys = new Array();
    specialKeys.push(8); //Backspace

    /*from himal dai*/
    $(document).ready(function () {
        $.fn.getCursorPosition = function () {
            var input = this.get(0);
            if (!input) return; // No (input) element found
            if ('selectionStart' in input) {
                // Standard-compliant browsers
                return input.selectionStart;
            } else if (document.selection) {
                // IE
                input.focus();
                var sel = document.selection.createRange();
                var selLen = document.selection.createRange().text.length;
                sel.moveStart('character', -input.value.length);
                return sel.text.length - selLen;
            }
        }
    });
    /**/
    function cancelDel(evt, obj, lenBeforedot, decimalLen) {
        if (lenBeforedot == undefined)
            lenBeforedot = 12;
        var len = obj.value.length;
        var index = obj.value.indexOf('.');
        if (index <= lenBeforedot && len > lenBeforedot) {
            var cp = $(obj).getCursorPosition();
            var CharAfterdot = (len) - index-1;
            var charCode = (evt.which) ? evt.which : evt.keyCode 
//            if (len > lenBeforedot && index <= lenBeforedot && (charCode == 8 || charCode == 46 )) {
//                errorMsg(false, obj);
//                return false;
            //            }
            var checkBckSpc = index - lenBeforedot + 1 +  lenBeforedot;
//len greater than 13 and cp is 13 then no back space
            if (len > lenBeforedot + 1 && charCode == 8 && cp == checkBckSpc) {
                errorMsg(false, obj);
                return false;
            }
            var checkdel = index - lenBeforedot  + lenBeforedot;
            //len greater than 13 and cp is 12 then no delete
            if (len > lenBeforedot + 1 && charCode == 46 && cp == checkdel) {
                errorMsg(false, obj);
                return false;
            }
        }
        return true;
    }
    function isDecimal(evt, obj, lenBeforedot, decimalLen) {
        if (lenBeforedot == undefined)
            lenBeforedot = 12;
        var charCode = (evt.which) ? evt.which : evt.keyCode
        if (charCode == 37 || charCode == 39) {
            return true;
        }
        else if (charCode > 31 && (charCode < 48 || charCode > 57) && !(charCode == 46 || charCode==45)) {
            errorMsg(false, obj);
            return false;
        } 
        else {
            var len = obj.value.length;
            var index = obj.value.indexOf('.');
            //            if (len > lenBeforedot && index <= lenBeforedot && (charCode == 8 || charCode == 46 )) {
            //                errorMsg(false, obj);
            //                return false;
            //            }
            /*from himal dai*/
            var cp = $(obj).getCursorPosition();
            /**/
            /***********************for minus**************************************************/
            var indexOfMinus = obj.value.indexOf('-');
            if (cp == 0 && charCode == 45 && indexOfMinus < 0)
                return true;
            else if (charCode == 45||(cp==0 && indexOfMinus>-1)) {
                errorMsg(false, obj);
                return false;
            }
            else {
                /*************************************************************************/
                if (index >= 0 && charCode == 46 && evt.which != 0) {
                    errorMsg(false, obj);
                    return false;
                }
                else if (index == 0 && len == 1 && (charCode == 8 || (charCode == 46 && evt.which == 0))) {
                    errorMsg(true, obj);
                }
                else if (index == cp && (charCode == 46 && evt.which == 0) && len == cp + 1) {
                    errorMsg(true, obj);
                }
                else if (index == cp && (charCode == 46 && evt.which == 0)) {
                    errorMsg(false, obj);
                    return false;
                }
                else if (index == cp - 1 && charCode == 8 && len == cp) {
                    errorMsg(true, obj);
                }
                else if (index == cp - 1 && charCode == 8) {
                    errorMsg(false, obj);
                    return false;
                }
                else {
                    errorMsg(true, obj);
                }
                if (index >= 0 && index <= lenBeforedot) {
                    var CharAfterdot = (len) - index;
                    if (CharAfterdot > parseInt(decimalLen)) {
                        if (charCode == 8 || (charCode == 46 && evt.which == 0))
                            errorMsg(true, obj);
                        else {
                            /*from himal dai*/
                            if (index != lenBeforedot && index >= cp) {
                                errorMsg(true, obj);
                                return true;
                            }
                            else {
                                errorMsg(false, obj);
                                return false;
                            }
                            /**/
                            errorMsg(false, obj);
                            return false;
                        }
                    }
                    else {
                        errorMsg(true, obj);
                        return true;
                    }
                }
                else {
                    if (cp < lenBeforedot) {
                        if (charCode == 8 || (charCode == 46 && evt.which == 0))
                            errorMsg(true, obj);
                        else {
                            if (index >= lenBeforedot - 1) {
                                errorMsg(false, obj);
                                return false;
                            }
                        }
                    }
                    else if (cp == lenBeforedot && charCode == 46)
                        errorMsg(true, obj);
                    else if (cp == lenBeforedot && index == -1 && (charCode == 8 || (charCode == 46 && evt.which == 0)))
                        errorMsg(true, obj);
                    else {
                        errorMsg(false, obj);
                        return false;
                    }
                }
            }
        }
        return true;
    }

    function errorMsg(ret, obj) {
        var newObj = obj;
        
        //document.getElementById("DecimalOnly").style.display = ret ? "none" : "inline";
//        if (document.getElementById("DecimalOnly").style.display == "inline") {
//            document.getElementById("DecimalOnly").style.position = "absolute";
        if (!ret) {
            var p = {};
            p.x = obj.offsetLeft;
            p.y = obj.offsetTop;
            while (obj.offsetParent) {
                p.x = p.x + obj.offsetParent.offsetLeft;
                p.y = p.y + obj.offsetParent.offsetTop;
                if (obj == document.getElementsByTagName("body")[0]) {
                    break;
                }
                else {
                    obj = obj.offsetParent;
                }
            }
            //                alert(newObj.clientWidth);
            //            document.getElementById("DecimalOnly").style.left = p.x + newObj.clientWidth + "px";
            //            document.getElementById("DecimalOnly").style.top = p.y + "px";
        }
        return ret;
    }
</script>