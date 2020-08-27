<%@ Control Language="C#" AutoEventWireup="true"  CodeBehind="Address.ascx.cs" Inherits="Ensure.Ensure.UserControls.Common.Area" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<style type="text/css">
    /* .leftArea{ float:left; margin-left:10px; width:475px; margin-top:9px;}
    .rightArea{}
    
        .firstChild .leftLiArea{width:236px;}
        .firstChild .rightLiArea { margin-right:10px;}
        .ward{ width:83px;}*/
    .ModalPopupBG
    {
        background-color: black;
        filter: alpha(opacity=50) !important;
        opacity: 0.7;
        border: 2px solid black;
        top: -20px !important;
        left: -20px !important;
        position: absolute !important;
        z-index: 101 !important;
        background-position: top;
        margin: -30px;
    }
    #light1 .popupClose
    {
        color: black;
        float: right;
        font-size: 12px;
        font-weight: bold;
        margin-right: 5px;
        margin-top: 3px;
        width: 37px;
    }
    iframe
    {
        height: 100%;
        width: 100%;
        -moz-transition: 2s;
    }
    .white_content
    {
        width: 270px;
        border: 2px solid #BFCDDB;
        background-color: white;
        z-index: 1002;
        overflow: auto;
        border-radius: 5px; /*  display:absolute;
           margin-top:-10%;*/
        position: absolute !important;
    }
    .PopupHeader
    {
        height: 25px;
        background-color: #CCDAE7;
        width: 260px;
    }
    
    .content
    {
        padding: 12px;
    }
    .style1
    {
        width: 27px;
    }
    
    @media (max-width: 800px)
    {
        .margintop
        {
            margin-top: 5px !important;
        }
    }
    #myModal
    {
        -webkit-margin-before: 0.8em !important;
        -webkit-margin-after: 0.8em !important;
    }
 /*   @font-face {font-family: 'fontasy1';src: url('/Design/fonts1/fontasy/newfontasy/nepali/FONTASYHIMALITTNORMAL.eot') format('embedded-opentype'), url('/Design/fonts1/fontasy/newfontasy/nepali/FONTASYHIMALITTNORMAL.ttf') format('truetype'), url('/Design/fonts1/fontasy/newfontasy/nepali/FONTASYHIMALITTNORMAL.svg#FONTASYHIMALITTNORMAL') format('svg');font-weight: normal;font-style: normal;}
.nepalifont {font-family: "fontasy1" !important;font-size: 12px !important;padding: 0 0 0 5px !important;}*/
</style>
<link href="../../../Design/css1/layout.css" rel="stylesheet" />
<%--<asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
</asp:ScriptManager>--%>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>--%>
<div class="row">
    <div class="col-md-12 col-xs-12 col-sm-12">
        <!-- left part starts -->
        <div class="form-group">
            <div class="col-sm-6 col-xs-12 col-md-6">
                <div class="col-sm-4 col-md-4 col-xs-4">
                    <asp:Label ID="lblZone" runat="server" Text="Zone" CssClass="control-label"></asp:Label>
                    <span class="important">*</span>
                </div>
                <div class="col-sm-8 col-md-8 col-xs-8">
                    <asp:DropDownList ID="ddlZone" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged"
                        DataTextField="EDESCRIPTION" DataValueField="ID" CssClass="form-control" OnCHange="return Validate(this,true);">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-12 margintop">
                <div class="col-sm-4 col-md-4 col-xs-4 ">
                    <asp:Label ID="lblDistrict" runat="server" Text="District" CssClass="control-label"></asp:Label>
                    <span class="important">*</span>
                </div>
                <div class="col-sm-8 col-md-8 col-xs-8">
                    <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"
                        DataTextField="EDESCRIPTION" DataValueField="ID" CssClass="form-control" OnCHange="return Validate(this,true);">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-6 col-xs-12 col-sm-6">
                <div class="col-sm-4 col-md-4 col-xs-4">
             
                    <asp:RadioButtonList ID="rblMnuVdc"  runat="server" AutoPostBack="True" EnableViewState="true"  OnSelectedIndexChanged="rblMnuVdc_SelectedIndexChanged"
                        RepeatDirection="Horizontal" CssClass="col-md-10 col-xs-10 col-sm-10">
                        <asp:ListItem Selected="True" Value="0">MNU</asp:ListItem>
                        <asp:ListItem Value="1">VDC</asp:ListItem>
                    </asp:RadioButtonList>
                    
  
                    <%--<span class="important">*</span>--%>
                </div>
                <div class="col-md-8 col-sm-8 col-xs-8">
                    <div class="input-group">
                        <asp:DropDownList ID="ddlMnuVdc" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="ddlMnuVdc_SelectedIndexChanged"
                            CssClass="form-control">
                        </asp:DropDownList>
                        <span class="input-group-addon" id="iGroup"><a href="#" tabindex="-1" data-toggle="modal" data-target="#myModal"
                            onclick="return ChangeSrcA('MnuVdc',this)">
                            <img src="../../../../Design/img1/setting.png" /><%--
                    <img src="../../../../Design/Icon/setting.png" />--%>
                        </a></span>
                    </div>
                </div>
                <%-- <div class="col-md-1 col-sm-1 col-xs-1">--%>
                <%--DataTextField="NAME" DataValueField="ID"<asp:ImageButton ID="ibtnMnuVdc" runat="server" ImageUrl="~/Design/Icon/setting.png"
                                type="button" data-toggle="modal" data-target="#myModal" data-backdrop="static"
                                OnClientClick="return ChangeSrcA('MnuVdc')" />
                            <asp:ModalPopupExtender ID="ibtnMnuVdc_ModalPopupExtender" runat="server" CancelControlID="popupClose"
                                PopupControlID="light1" PopupDragHandleControlID="PopupHeader" Drag="True" BehaviorID="modalpopupMnuVdc"
                                BackgroundCssClass="ModalPopupBG" TargetControlID="ibtnMnuVdc" DynamicServicePath=""
                                Enabled="True">
                            </asp:ModalPopupExtender>--%>
                <%-- <a href="#" data-toggle="modal" data-target="#myModal" onclick="return ChangeSrcA('MnuVdc')"><img src="../../../../Design/Icon/setting.png" />
                    </a>--%>
                <%-- </div>--%>
            </div>
            <div class="col-md-6 col-xs-12 col-sm-6 margintop">
                <div class="col-sm-4 col-md-4  col-xs-4">
                    <asp:Label ID="lblWardNo" runat="server" Text="Ward No." CssClass="control-label"></asp:Label>
                    <%--<span class="important">*</span>--%>
                </div>
                <div class="col-sm-8 col-md-8 col-xs-8">
                    <asp:TextBox ID="txtWardNo" runat="server" MaxLength="5" AutoPostBack="True" OnTextChanged="txtWardNo_TextChanged"
                        CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-6 col-xs-12 col-sm-6">
               <%-- <asp:Label ID="lblAddress" runat="server" Text="Address" CssClass="col-sm-4 col-md-4 col-xs-4 control-label"
                    Style="margin-top: 20px;"></asp:Label>--%>
                    <div class="col-sm-4 col-md-4 col-xs-4 ">
                     <asp:Label ID="lblAddress" runat="server" Text="Address (Eng.)" CssClass="control-label"></asp:Label>
                        <span class="important">*</span>
                        </div>
                <div class="col-sm-8 col-md-8 col-xs-8">
                   <%-- <strong>
                        <asp:Label ID="lblEng" runat="server" Text="In English" CssClass="control-label"></asp:Label></strong>
                    <strong></strong>--%>
                    <asp:TextBox ID="txtEAddress" runat="server" CssClass="form-control" OnCHange="return Validate(this,true);"  placeholder="Address in English"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 col-xs-12 col-sm-6 margintop">
                <%--<strong>
                    <asp:Label ID="lblNep" runat="server" Text="In Nepali" CssClass="col-sm-8 col-sm-offset-4  col-md-8 col-md-offset-4 col-xs-8 col-xs-offset-4 control-label"></asp:Label>
                    </strong>--%>
                     <div class="col-sm-4 col-md-4 col-xs-4 ">
                     <asp:Label ID="lblAddressNep" runat="server" Text="Address (Nep.)" CssClass="control-label"></asp:Label>
                        <span class="important">*</span>
                        </div>
                <div class="col-sm-7 col-md-8 col-xs-8 ">
                    <asp:TextBox ID="txtNAddress" runat="server" CssClass="form-control nepalifont" OnCHange="return Validate(this,true);"  placeholder="g]kfnLdf &]ufgf"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-6 col-md-6 col-xs-12">
                <div class="col-sm-4 col-md-4  col-xs-4">
                    <asp:Label ID="lblArea" runat="server" Text="Area" CssClass="control-label"></asp:Label>
                    <%--<span class="important">*</span>--%>
                </div>
                <div class="col-sm-8 col-md-8 col-xs-8">
                    <div class="input-group">
                        <%--<asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged"
                            DataValueField="AREACODE" DataTextField="EDESC" CssClass="form-control" OnCHange="return ValidateFromForm(this,true);">
                        </asp:DropDownList>--%>
                        <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged"
                            DataValueField="AREACODE" DataTextField="EDESC" CssClass="form-control">
                        </asp:DropDownList>
                        <span class="input-group-addon"><a href="#" tabindex="-1" data-toggle="modal" data-target="#myModal"
                            onclick="return ChangeSrcA('Area',this)">
                            <img src="../../../../Design/img1/setting.png" /></a></span>
                    </div>
                </div>
                <%--
            <div class="col-md-1 col-sm-1 col-xs-1">--%>
                <%--<asp:ImageButton ID="ibtnArea" runat="server" ImageUrl="~/Design/Icon/setting.png"
                                type="button" data-toggle="modal" data-target="#myModal" data-backdrop="static"
                                OnClientClick="return ChangeSrcA('Area')" />
                            <asp:ModalPopupExtender ID="ibtnArea_ModalPopupExtender" runat="server" CancelControlID="popupClose"
                                PopupControlID="light1" PopupDragHandleControlID="PopupHeader" Drag="True" BehaviorID="modalpopupArea"
                                BackgroundCssClass="ModalPopupBG" TargetControlID="ibtnArea" DynamicServicePath=""
                                Enabled="True">
                            </asp:ModalPopupExtender>--%>
                <%-- <a href="#" data-toggle="modal" data-target="#myModal" onclick="return ChangeSrcA('Area')"><img src="../../../../Design/Icon/setting.png" />--%>
                <%--     </a>
            </div>--%>
            </div>
            <div class="col-md-6 col-xs-12 col-sm-6 margintop" style="display: none;">
                <div class="col-sm-7 col-sm-offset-4  col-md-8 col-md-offset-4 col-xs-7 col-xs-offset-4 ">
                    <asp:TextBox ID="txtNArea" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 col-xs-12 col-sm-6 margintop">
                <div class="col-sm-4 col-md-4 col-xs-4">
                    <asp:Label ID="lblTole" runat="server" Text="Tole" CssClass=" control-label"></asp:Label>
                    <%--<span class="important">*</span>--%>
                </div>
                <div class="col-sm-8 col-md-8 col-xs-8 ">
                    <div class="input-group">
                        <asp:DropDownList ID="ddlTole" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTole_SelectedIndexChanged"
                            DataTextField="EDESC" DataValueField="TOLEID" CssClass="form-control">
                        </asp:DropDownList>
                        <span class="input-group-addon"><a href="#" tabindex="-1" data-toggle="modal" data-target="#myModal"
                            onclick="return ChangeSrcA('Tole',this)">
                            <img src="../../../../Design/img1/setting.png" />
                        </a></span>
                    </div>
                </div>
                <%--   <div class="col-md-1 col-sm-1 col-xs-1">--%>
                <%--<asp:ImageButton ID="ibtnTole" runat="server" ImageUrl="~/Design/Icon/setting.png"
                                type="button" data-toggle="modal" data-target="#myModal" data-backdrop="static"
                                OnClientClick="return ChangeSrcA('Tole')" />--%>
                <%-- <asp:ModalPopupExtender ID="ibtnTole_ModalPopupExtender" runat="server" CancelControlID="popupClose"
                                PopupControlID="light1" PopupDragHandleControlID="PopupHeader" Drag="True" BehaviorID="modalpopupTole"
                                BackgroundCssClass="ModalPopupBG" TargetControlID="ibtnTole" DynamicServicePath=""
                                Enabled="True">
                            </asp:ModalPopupExtender>--%>
                <%-- </div>--%>
            </div>
        </div>
        <div class="form-group" style="display: none;">
            <div class="col-md-6 col-xs-12 col-sm-6 margintop">
                <div class="col-sm-7 col-sm-offset-4  col-md-8 col-md-offset-4 col-xs-8 col-xs-offset-4 ">
                    <asp:TextBox ID="txtNTole" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-6 col-xs-12 col-sm-6">
                <asp:Label ID="lblHouseNo" runat="server" Text="House No." CssClass="col-sm-4 col-md-4 col-xs-4 control-label"></asp:Label>
                <div class="col-sm-8 col-md-8  col-xs-8">
                    <asp:TextBox ID="txtHouseNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6 col-xs-12 col-sm-6 margintop">
                <asp:Label ID="lblPlotNo" runat="server" Text="Plot No." CssClass="col-sm-4 col-md-4 col-xs-4 control-label"></asp:Label>
                <div class="col-sm-8 col-md-8 col-xs-8">
                    <asp:TextBox ID="txtPlotNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <!--right part starts -->
</div>
<%--        <div id="light1"></div>--%>
<asp:Button ID="btnRefreshZone" runat="server" CausesValidation="False" Style="display: none;"
    OnClick="btnRefreshZone_Click" />
<asp:Button ID="btnRefreshDistrict" runat="server" Style="display: none;" CausesValidation="False"
    OnClick="btnRefreshDistrict_Click" />
<asp:Button ID="btnRefreshMnuVdc" runat="server" Style="display: none;" CausesValidation="False"
    OnClick="btnRefreshMnuVdc_Click" />
<asp:Button ID="btnRefreshArea" runat="server" Style="display: none;" CausesValidation="False"
    OnClick="btnRefreshArea_Click" />
<asp:Button ID="btnRefreshTole" runat="server" Style="display: none;" CausesValidation="False"
    OnClick="btnRefreshTole_Click" />
<!-- Modal -->
<%-- </ContentTemplate>--%>
<%--<Triggers>
    <asp:AsyncPostBackTrigger ControlID="btnRefreshZone" EventName="Click" />
    </Triggers>--%>
<%--</asp:UpdatePanel>--%>
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
    aria-hidden="true" data-backdrop="static">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="CloseArea();">
                    <span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title" id="myModalLabel">
                    <asp:Label ID="lblTitle" runat="server"></asp:Label></h4>
            </div>
            <div class="modal-body">
                <iframe id="IframeEdit1" name="frame" frameborder="0" scrolling="auto" src=""></iframe>
            </div>
        </div>
    </div>
</div>
<%--<script src="../../../Design/js1/Ensure/FromValidation.js" type="text/javascript"></script>--%>
<script type="text/javascript">
//    $('#myModal').on('shown.bs.modal', function () {
//        $('#myInput').focus()
//    })

</script>
<script type="text/javascript">
    var constModule;var midid;
    function ChangeSrcA(module, obj) {
        midid = obj.parentNode.parentNode.firstElementChild.id.split('_')[1];
            document.getElementById('ContentPlaceHolder1_'+midid+'_lblTitle').innerHTML = module;
            var frame = $get('IframeEdit1');
            frame.src = "";
            constModule = module;
            document.getElementById('IframeEdit1').style.height = (window.outerHeight * 0.6) + "px";
            if (module == 'Zone') {
                frame.src = "";
                frame.src = '<%=ResolveUrl("../../Setup/Underwriting/Area/Zone.aspx") %>';
            }
            else if (module == 'District') {
                frame.src = "";
                frame.src = '<%=ResolveUrl("../../Setup/Underwriting/Area/District.aspx") %>';
            }
            else if (module == 'MnuVdc') {

                frame.src = "";
                var list = document.getElementById('ContentPlaceHolder1_' + midid + '_rblMnuVdc'); //Client ID of the radiolist
                var inputs = list.getElementsByTagName("input");
                if (inputs[0].checked) {
                    document.getElementById('ContentPlaceHolder1_'+midid+'_lblTitle').innerHTML = "Municipality";
                    frame.src = '<%=ResolveUrl("../../Setup/Underwriting/Area/Municipality.aspx") %>';
                    frame.src = frame.src + "?ID=" + document.getElementById('ContentPlaceHolder1_'+midid+'_ddlDistrict').value;
                }
                else if (inputs[1].checked) {
                    document.getElementById('ContentPlaceHolder1_'+midid+'_lblTitle').innerHTML = "VDC";
                    frame.src = '<%=ResolveUrl("../../Setup/Underwriting/Area/VDC.aspx") %>';
                    frame.src = frame.src + "?ID=" + document.getElementById('ContentPlaceHolder1_'+midid+'_ddlDistrict').value;
                }
            }
            else if (module == 'Area') {
                frame.src = '<%=ResolveUrl("../../Setup/Underwriting/Area/Area.aspx") %>';
                frame.src = frame.src + "?ID=" + document.getElementById('ContentPlaceHolder1_' + midid + '_ddlMnuVdc').value + "&&DISTRICTID=" + document.getElementById('ContentPlaceHolder1_' + midid + '_ddlDistrict').value + "&&WARDNO=" + document.getElementById('ContentPlaceHolder1_' + midid + '_txtWardNo').value + "&&ZONEID=" + document.getElementById('ContentPlaceHolder1_' + midid + '_ddlZone').value;

                var list = document.getElementById('ContentPlaceHolder1_'+midid+'_rblMnuVdc'); //Client ID of the radiolist
                var inputs = list.getElementsByTagName("input");
                if (inputs[0].checked) {
                    frame.src = frame.src + "&&RBL=" + inputs[0].value;
                }
                else if (inputs[1].checked) {
                    frame.src = frame.src + "&&RBL=" + inputs[1].value;
                }
            }
            else if (module == 'Tole') {
                frame.src = '<%=ResolveUrl("../../Setup/Underwriting/Area/Tole.aspx") %>';
                frame.src = frame.src + "?ID=" + document.getElementById('ContentPlaceHolder1_' + midid + '_ddlArea').value + "&&DISTRICTID=" + document.getElementById('ContentPlaceHolder1_' + midid + '_ddlDistrict').value + "&&MNUVDCID=" + document.getElementById('ContentPlaceHolder1_' + midid + '_ddlMnuVdc').value + "&&WARDNO=" + document.getElementById('ContentPlaceHolder1_' + midid + '_txtWardNo').value + "&&ZONEID=" + document.getElementById('ContentPlaceHolder1_' + midid + '_ddlZone').value;
                var list = document.getElementById('ContentPlaceHolder1_'+midid+'_rblMnuVdc'); //Client ID of the radiolist
                var inputs = list.getElementsByTagName("input");
                if (inputs[0].checked) {
                    frame.src = frame.src + "&&RBL=" + inputs[0].value;
                }
                else if (inputs[1].checked) {
                    frame.src = frame.src + "&&RBL=" + inputs[1].value;
                }
            }
            frame.src = frame.src + "&&OPENAS=POPUP";
            if (document.getElementById('ContentPlaceHolder1_ctl02_lblTitle') != undefined) {
                document.getElementById('ContentPlaceHolder1_ctl02_lblTitle').innerHTML = document.getElementById('ContentPlaceHolder1_' + midid + '_lblTitle').innerHTML;
            }
    }
    function CloseArea() {
        if (constModule == 'Zone') {
            document.getElementById('ContentPlaceHolder1_' + midid + '_btnRefreshZone').click();
        }
        else if (constModule == 'District') {
            document.getElementById('ContentPlaceHolder1_' + midid + '_btnRefreshDistrict').click();
        }
        else if (constModule == 'MnuVdc') {
            document.getElementById('ContentPlaceHolder1_' + midid + '_btnRefreshMnuVdc').click();
        }
        else if (constModule == 'Area') {
        document.getElementById('ContentPlaceHolder1_' + midid + '_btnRefreshArea').click();
        }
        else if (constModule == 'Tole') {
            document.getElementById('ContentPlaceHolder1_' + midid + '_btnRefreshTole').click();
        }
    }
    function getMnuVdc() {
        var list = document.getElementById("rblMnuVdc"); //Client ID of the radiolist

        alert('ok');
        var inputs = list.getElementsByTagName("input");

        var selected;
        for (var i = 0; i < inputs.length; i++) {
            if (inputs[i].checked) {
                selected = inputs[i];
                break;
            }
        }
        if (selected) {
            alert(selected.value);
        }
    }
</script>

