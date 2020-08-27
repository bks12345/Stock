<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DefaultPopup.ascx.cs"
    Inherits="Stock.Ensure.UserControls.Common.DefaultPopup" %>

     <%--<table id="DecimalOnly" class="customvalidatorcalloutstyle ajax__validatorcallout_popup_table"
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
                    <span id="msg"></span>
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
        function errorMsg(msg,obj) {
            var newObj = obj;
            document.getElementById('msg').innerHTML = msg;
            document.getElementById("DecimalOnly").style.display =  "inline";
            if (document.getElementById("DecimalOnly").style.display == "inline") {
                document.getElementById("DecimalOnly").style.position = "absolute";
//                if (!ret) {
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
                    // alert(newObj.clientWidth);
                    document.getElementById("DecimalOnly").style.left = p.x + newObj.clientWidth + "px";
                    document.getElementById("DecimalOnly").style.top = p.y + "px";
//                }
            }
        }
        function HideMenu() { }
    </script>--%>

<a href="#" data-toggle="modal" data-target="#myModal" style="display:none;"
    id="lnkAreaPopup" runat="server">
    <img src="../../../../Design/Icon/setting.png" />
</a>
<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
    aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">
                    Error</h4>
            </div>
            <div class="modal-body">
                <span id="msg"></span>
            </div>
            <div class="modal-footer">
             <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    Ok</button>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    function openPopup(msg) {
        Sys.Application.add_init(function () {
            document.getElementById('msg').innerHTML = msg;
            $('#myModal').modal('show');
        });
    }
    function HideMenu() { }
</script>
