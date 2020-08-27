<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NumericErrorMsg.ascx.cs" Inherits="Stock.Ensure.UserControls.Common.NumericErrorMsg" %>
<style type="text/css">
.customvalidatorcalloutstyle div, .customvalidatorcalloutstyle td {
        border: 1px solid #2670C9;
        background-color: #408AE3;
        }
        .customvalidatorcalloutstyle .ajax__validatorcallout_error_message_cell {
        font-family: Verdana;
        font-size: 11px;
        padding: 9px;
        border-right: medium none !important;
        border-left: medium none !important;
        width: 100%;
        color: white;
        font-weight: bold;
        }
        .customvalidatorcalloutstyle .ajax__validatorcallout_close_button_cell .ajax__validatorcallout_innerdiv {
        border: medium none !important;
        text-align: center;
        width: 12px;
        padding: 1px;
        cursor: pointer;
        opacity: 0.9;
        }
        .customvalidatorcalloutstyle .ajax__validatorcallout_icon_cell {
        width: 20px;
        padding: 2px;
        margin: 0px;
        border-right: medium none !important;
        }
            .customvalidatorcalloutstyle .ajax__validatorcallout_callout_cell {
        width: 20px;
        height: 100%;
        text-align: right;
        vertical-align: middle;
        border: medium none !important;
        background-color: transparent !important;
        padding: 0px;
        margin: 0px;
        }
        .ajax__validatorcallout_innerdiv {
    background-color: transparent !important;
    border-bottom: medium none !important;
    border-left: medium none !important;
    border-right: medium none !important;
    font-size: 1px;
    left: 1px;
    margin: 0;
    padding: 0;
    position: relative;
    width: 15px;
}
.ajax__validatorcallout_popup_table_row {
    background-color: transparent;
    height: 100%;
    margin: 0;
    padding: 0;
    vertical-align: top;
}
.ajax__validatorcallout_callout_cell {
    background-color: transparent !important;
    border: medium none !important;
    height: 100%;
    margin: 0;
    padding: 0;
    text-align: right;
    vertical-align: top;
    width: 20px;
}
.ajax__validatorcallout_callout_table {
    background-color: transparent;
    border: medium none;
    height: 100%;
    margin: 0;
    padding: 0;
}
.ajax__validatorcallout_callout_table_row {
    background-color: transparent;
    margin: 0;
    padding: 0;
}
.ajax__validatorcallout_callout_arrow_cell {
    background-color: transparent !important;
    border: medium none !important;
    font-size: 1px;
    margin: 0;
    padding: 8px 0 0;
    text-align: right;
    vertical-align: top;
}
.ajax__validatorcallout_callout_arrow_cell .ajax__validatorcallout_innerdiv {
    background-color: transparent !important;
    border-bottom: medium none !important;
    border-left: medium none !important;
    border-right: medium none !important;
    font-size: 1px;
    left: 1px;
    margin: 0;
    padding: 0;
    position: relative;
    width: 15px;
}
.ajax__validatorcallout_callout_arrow_cell .ajax__validatorcallout_innerdiv div {
    border-bottom: medium none !important;
    border-right: medium none !important;
    border-top: medium none !important;
    height: 1px;
    margin: 0 0 0 auto;
    overflow: hidden;
    padding: 0;
}
</style>
<div>

    <table id="NumbersOnly" class="customvalidatorcalloutstyle ajax__validatorcallout_popup_table"
        cellspacing="0" cellpadding="0" border="0" width="200px" style="display:none;
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
                    Enter numbers only!
                </td>
                <td class="ajax__validatorcallout_close_button_cell">
                    <div class="ajax__validatorcallout_innerdiv">
                        <img src="../../../../../Design/Icon/close_small_icon.gif" onclick="closeNumErr();">
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    <script type="text/javascript">
//        function closeNumErr() {
//            document.getElementById("NumbersOnly").style.display = "none";
//            return false;
//        }
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        specialKeys.push(9);//tab
        function IsNumeric(e, obj) {
            var newObj = obj;
            var keyCode = e.which ? e.which : e.keyCode
            if (keyCode == 37 || keyCode == 39) {
                return true;
            }
            else
                if (keyCode == 46 && e.which == 0)
                    return true;
                else if (keyCode > 31 && (keyCode < 48 || keyCode > 57) || (keyCode == 46)) {
                    //                document.getElementById("NumbersOnly").style.display = "inline";
                    //                if (document.getElementById("NumbersOnly").style.display == "inline") {
                    //                    document.getElementById("NumbersOnly").style.position = "absolute";
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
                    //                    document.getElementById("NumbersOnly").style.left = p.x + newObj.clientWidth + "px";
                    //                    document.getElementById("NumbersOnly").style.top = p.y + "px";
                    return false;
                    //                }
                }
                else {
                    //                document.getElementById("NumbersOnly").style.display = "none";
                    return true
                }
        }
    </script>
</div>