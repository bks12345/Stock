<%@ Page Title="" Language="C#" MasterPageFile="~/Stock/main.Master" AutoEventWireup="true" CodeBehind="PurchaseSearch.aspx.cs" Inherits="Stock.Stock.SearchEngine.PurchaseSearch" %>


<%@ Register TagPrefix="aspp" TagName="DecimalOnlyError" Src="~/Stock/UserControls/Common/DecimalErrorMsg.ascx" %>
<%@ Register TagPrefix="uc" TagName="ucNumericErrMsg" Src="~/Stock/UserControls/Common/NumericErrorMsg.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .DTFC_RightWrapper {
            position: 0 !important;
        }

        .dataTables_scrollBody {
            height: 62.6vh !important;
        }

        .toggleme1 {
            width: 98.7% !important;
        }

        .table-design {
            height: 70vh;
        }

        .search-form {
            height: 82vh !important;
        }

        #Iframe {
            width: 100% !important;
        }

        @media (max-width: 768px) {
            .toggleme {
                left: 0 !important;
                top: 4.6% !important;
                width: 100% !important;
            }

            .right-fixed {
                right: -26%;
            }

            .collect-marg {
                margin-top: 20px;
            }

            .search-output, .search-form {
                height: auto !important;
            }
        }

        @media (max-width: 1024px) {
            .no-padding1 {
                padding-left: 5px;
            }

            .toggleme {
                width: 66% !important;
                top: 3.9% !important;
            }

            .toggleme1 {
                width: 100% !important;
            }
        }

        @media (max-width: 824px) {
            .toggleme {
                width: 100% !important;
            }
        }

        .search-form {
            height: 82.5vh;
        }

        @media screen and (max-height:600px) {
            .search-form {
                height: 76.5vh !important;
            }

            .fixed-container {
                height: 81.2vh !important;
            }
        }

        @media only screen and (max-width:767px) and (min-width: 0px) {
            .requistion-search {
	            height: auto !important;
            }
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Design/js1/FixFocus.min.js" />
        </Scripts>
    </asp:ScriptManager>
    <div class="row fixed-header">
        <div class="col-sm-12 col-md-12">
            <div class="page-header-container">
                <h4 class="page-header" style="margin-bottom: 0!important;">Purchase Search</h4>
            </div>
        </div>
    </div>
    <div class="fixed-container cont-pad-top">
        <div class="">
            <div class="col-md-4 col-sm-4 col-xs-12 search-section search-form requistion-search">
                <div class="form-group collect-marg">
                    <asp:Label ID="lblBranch" runat="server" Text="Branch" CssClass="col-sm-12 col-md-4 col-xs-12 control-label"></asp:Label>
                    <div class="col-sm-12 col-md-8 col-xs-12">
                        <asp:DropDownList ID="ddlBranch" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged" DataTextField="ENAME" DataValueField="BRANCHID" TabIndex="1">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblFiscalYear" runat="server" Text="Fiscal Year" CssClass="col-sm-12 col-md-4 col-xs-12 control-label"></asp:Label>
                    <div class="col-sm-12 col-xs-12 col-md-8">
                        <asp:DropDownList ID="ddlFiscalYr" AutoPostBack="true" runat="server" CssClass="form-control" TabIndex="2" OnSelectedIndexChanged="ddlFiscalYr_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblFrom" runat="server" Text="Date From" CssClass="col-sm-12 col-md-4 col-xs-12 control-label"></asp:Label>
                    <div class="col-sm-12 col-md-8 col-xs-12">
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control" TabIndex="3"
                            AutoPostBack="true" onchange="return isDate(this,false);"></asp:TextBox>
                        <asp:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" Enabled="True"
                            TargetControlID="txtFrom" Format="dd-MMM-yyyy"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblTo" runat="server" Text="Date To" CssClass="col-sm-12 col-xs-12 col-md-4 control-label"></asp:Label>
                    <div class="col-sm-12 col-xs-12 col-md-8">
                        <asp:TextBox ID="txtTo" runat="server" CssClass="form-control" TabIndex="4"
                            AutoPostBack="true" onchange="return isDate(this,false);"></asp:TextBox>
                        <asp:CalendarExtender ID="txtTo_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtTo"
                            Format="dd-MMM-yyyy"></asp:CalendarExtender>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblBillNo" runat="server" Text="Bill No." CssClass="col-sm-12 col-xs-12 col-md-4 control-label"></asp:Label>
                    <div class="col-sm-12 col-md-8 col-xs-12">
                        <asp:TextBox ID="txtBillNo" runat="server" onkeypress="return IsNumeric(event,this);" CssClass="form-control" MaxLength="100" TabIndex="6"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group" style="display: none">
                    <asp:Label ID="Label24" runat="server" Text="Party Name" CssClass="col-sm-12 col-xs-12 col-md-4 control-label"></asp:Label>
                    <div class="col-sm-12 col-md-8 col-xs-12">
                        <asp:TextBox ID="txtpartyname" runat="server" CssClass="form-control" MaxLength="100" TabIndex="6"></asp:TextBox>
                    </div>
                </div>

            </div>
            <div class="col-md-8 col-sm-12 col-xs-12 col-sm-8 search-output search-form">
                <div class="row searc-nav-tab toggleme" style="left: 34.3%; top: 5.7%;">
                    <div class="col-md-2 col-sm-2 toggleClass visible-lg visible-md visible-sm">
                        <span id="tblcontents" class="menu-button " style="left: 13%!important;"></span>
                    </div>
                    <div class=" col-md-7 col-sm-7 col-xs-7">
                        <div class="search-icon-label">
                            <asp:Label ID="lblDocumentNo" Font-Bold="true" ForeColor="Red" runat="server" Style="font-size: 11px;"></asp:Label>
                            <asp:Label ID="lblTransactionNo" Font-Bold="true" ForeColor="Red" runat="server"
                                Style="font-size: 11px;"></asp:Label>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-3 col-xs-5">
                        <div class="row pull-right right-fixed">
                            <%--<div class="col-md-1 col-sm-1 col-xs-1">
                                <asp:HyperLink ID="lnkTopEdit" runat="server" ToolTip="Edit" Onclick="PrintReport('Edit','TOP');"><img src="../../../Design/img1/claim.png"  class="search-icon"  /></asp:HyperLink>
                            </div>
                            <div class="col-md-1 col-sm-1 col-xs-1">
                                <asp:HyperLink ID="lnkTopPrint" runat="server" ToolTip="Print" Onclick="PrintReport('Policy','TOP');"><img src="../../../Design/img1/printer.png"  class="search-icon"  /></asp:HyperLink>
                            </div>
                            <div class="col-md-1 col-sm-1 col-xs-1">
                                <asp:HyperLink ID="lnkTopRegClaim" runat="server" ToolTip="Register" Onclick="PrintReport('Claim','TOP');"><img src="../../../Design/img1/register1.png"  class="search-icon" /></asp:HyperLink>
                            </div>
                            <div class="col-md-1 col-sm-1 col-xs-1">
                                <asp:HyperLink ID="lnkTopAppBill" runat="server" ToolTip="Approve" Onclick="PrintReport('Approve','TOP');"><img src="../../../Design/img1/approve.png"  class="search-icon" /></asp:HyperLink>
                            </div>
                            <div class="col-md-1 col-sm-1 col-xs-1">
                                <asp:HyperLink ID="lnkTopPrintVat" runat="server" ToolTip="Vat" Onclick="PrintReport('vat','TOP');"><img src="../../../Design/img1/vat.png"  class="search-icon" /></asp:HyperLink>
                            </div>
                            <div class="col-md-1 col-sm-1 col-xs-1">
                                <asp:HyperLink ID="lnkTopReceiptAndVat" runat="server" ToolTip="Print Receipt + Vat"
                                   ><img src="../../../Design/img1/printvat.png"  class="search-icon" /></asp:HyperLink>
                            </div>--%>
                        </div>
                    </div>
                </div>
                <div class="row" style="display: none">
                    <div class="col-md-12 output-generate-table">
                        <div class="progress">
                            <div class="progress-bar" role="progressbar" aria-valuenow="60" aria-valuemin="0"
                                aria-valuemax="100" style="width: 60%;">
                                60%
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row toggle-margin" style="margin-top: 23px;">
                    <div class="col-md-12 col-xs-12 col-sm-12 no-padding1 removepadding">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="<%--col-md-12 col-xs-12 col-sm-12 no-padding--%>">
                                    <div class="table-design">

                                        <table id="rpt" class="stripe row-border order-column" cellspacing="0" width="100%">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        <asp:Label ID="Label72" runat="server" Text="S.N." Width="20px"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="Label42" runat="server" Text="PurchaseID" Width="100px"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="Label23" runat="server" Text="Transaction No" Width="100px"></asp:Label>
                                                    </th>
                                                  
                                                    <th>
                                                        <asp:Label ID="Label16" runat="server" Text="Vat Option" Width="100px"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="Label19" runat="server" Text="Purchase Type" Width="100px"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="Label45" runat="server" Text="Total Amount" Width="150px"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="Label46" runat="server" Text="Discount Amount" Width="100px"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="Label11" runat="server" Text="Vat Amount" Width="100px"></asp:Label>
                                                    </th>
                                                   
                                                    <th>
                                                        <asp:Label ID="Label6" runat="server" Text="Net Amount" Width="100px"></asp:Label>
                                                    </th>

                                                    <th>
                                                        <asp:Label ID="Label3" runat="server" Text="Eng Date" Width="100px"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="Label4" runat="server" Text="Nep Date" Width="100px"></asp:Label>
                                                    </th>

                                                    <th>
                                                        <asp:Label ID="Label10" runat="server" Text="Remarks" Width="100px"></asp:Label>
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="rptpurchasedetail" runat="server">
                                                    <ItemTemplate>
                                                        <%--  <tr onmousedown="HideMenu('contextMenu');" onmouseup="HideMenu('contextMenu');" oncontextmenu="ShowMenu('contextMenu',event,<%#Eval("transactionId") %>,'<%#Eval("TRANSACTIONNO") %>',<%#Eval("docid") %>,'<%#Eval("DocumentNo") %>');"
                                                        onclick="Select(this,<%#Eval("transactionId") %>,'<%#Eval("TRANSACTIONNO") %>',<%#Eval("docid") %>,'<%#Eval("DocumentNo") %>');">--%>
                                                        <%--<tr style="cursor: pointer;" onclick="Select(this,<%# Eval("ROWNUMBER")%>);">--%>
                                                        <tr onmousedown="HideMenu('contextMenu');" onmouseup="HideMenu('contextMenu');" oncontextmenu="ShowMenu('contextMenu',event,'<%#Eval("PurchaseID") %>');">
                                                            <td>
                                                                <asp:Label ID="lblSno" runat="server" Text='<%#Eval("ROWNUMBER") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblInsuredName" runat="server" Text='<%#Eval("PurchaseID") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label22" runat="server" Text='<%#Eval("Transactionno") %>'></asp:Label>
                                                            </td>
                                                           
                                                            <td>
                                                                <asp:Label ID="Label17" runat="server" Text='<%#Eval("vatoption") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label18" runat="server" Text='<%#Eval("Purchasetype") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("pAmount") %>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("pdiscAmt") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label8" runat="server" Text='<%#Eval("pVatAmt") %>'></asp:Label>
                                                            </td>
                                                           
                                                            <td>
                                                                <asp:Label ID="Label9" runat="server" Text='<%#Eval("pNetAmt") %>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label13" runat="server" Text='<%#DataBinder. Eval(Container.DataItem, "pdate", "{0:M/d/yyyy}") %>'></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label14" runat="server" Text='<%#DataBinder. Eval(Container.DataItem, "ndate", "{0:M/d/yyyy}") %>'></asp:Label>
                                                            </td>

                                                            <td>
                                                                <asp:Label ID="Label15" runat="server" Text='<%#Eval("Remarks") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <asp:LinkButton ID="lnkGoToFirst" runat="server" ToolTip="Go To First"
                                    CssClass="btntable"><span class="fa fa-backward"></span></asp:LinkButton>
                                <asp:LinkButton ID="lnkBtnPrev" runat="server" ToolTip="Prev"
                                    CssClass="btntable"><span class="fa fa-step-backward"></span></asp:LinkButton>
                                <asp:LinkButton ID="lnkBtnNext" runat="server" ToolTip="Next"
                                    CssClass="btntable"><span class="fa fa-step-forward"></span></asp:LinkButton>
                                <asp:LinkButton ID="lnkGoToLast" runat="server" ToolTip="Go To Last"
                                    CssClass="btntable"><span class="fa fa-forward"></span></asp:LinkButton>
                                <asp:Label ID="lblPages" runat="server" CssClass="label-number"></asp:Label>
                                <asp:HiddenField ID="hdnPg" runat="server" Value="1" />
                                <asp:Button ID="btnprint" runat="server" OnClick="btnprint_Click" Text="Print" Style="display: none" />
                                <asp:Button ID="btnChequePrint" runat="server" OnClick="btnChequePrint_Click" Text="Print" Style="display: none" />
                                <!-- for pre-loading -->
                                <div id="search-loading">
                                    <img alt="image-loader" src="../../Design/img1/ajax-loader-bar.gif">
                                </div>
                                <div id="empty">
                                </div>
                                <!-- /pre-loading -->
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="fixed-footer">
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" CssClass="btn btn-default"
                    OnClientClick="$('#search-loading').show();$('#empty').show();return ValidateForm();"
                    TabIndex="24" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-default"
                    TabIndex="25" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnMid" runat="server" />
    <asp:HiddenField ID="hdnDocid" runat="server" />
    <asp:HiddenField ID="hdnPurchaseID" runat="server" />
    <aspp:DecimalOnlyError ID="DecimalOnlyError1" runat="server" />
    <uc:ucNumericErrMsg ID="NumericChk" runat="server" />
    <div id="contextMenu" style="display: none; z-index: 1027;">
        <!-- added -->
        <ul class="click-menu">
            <li>
                <asp:HyperLink ID="lnkEditPolicy" Onclick="PrintReport();" runat="server">Voucher Print</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="lnkChequePrint" Onclick="PrintCheque();" runat="server">Cheque Print</asp:HyperLink>
            </li>
            <%-- //Onclick="PrintReport('Approve','CM');"--%>
        </ul>
    </div>


    <script src="/Design/js1/jquery.1.11.1.min.js" type="text/javascript"></script>
    <script src="/Design/js1/Ensure/FromValidation.js" type="text/javascript"></script>
    <script type="text/javascript">
        var width = screen.availWidth;
        if (width > 1000 || width <= 1200) {
            document.getElementById("pageContainer").style.width = "60% !important";
        }
    </script>

    <script language="javascript" type="text/javascript">

        function HideMenu() { };

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //  bindform();
        });
        var isSearchpnl = false;
        var msg;
        /************************to find which updatepanel has been updated************************/
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(pageLoadedHandler);
        function pageLoadedHandler(sender, args) {
            var updatedPanels = args.get_panelsUpdated();
            for (i = 0; i < updatedPanels.length; i++) {
                if (updatedPanels[i].id == "ContentPlaceHolder1_UpdatePanel1") {
                    isSearchpnl = true;
                    break;
                }
                else
                    isSearchpnl = false;
            }
        }
        /************************to set message for alert************************/
        function setmsg(ss) {
            msg = ss
        }
        /************************to alert msg only after css of table has been loaded completely************************/
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
        function EndRequestHandler(sender, args) {
            if (isSearchpnl) {
                //  bindform();
                if (msg != undefined) {
                    alert(msg);
                    msg = undefined;
                }
            }
            /************************to enable search btn which has been disabled after 1st click************************/
            document.getElementById('ContentPlaceHolder1_btnSearch').removeAttribute('disabled');
        }
        /************************to disable the control so that it cannot do postback on double click************************/
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        function BeginRequestHandler(sender, args) { var oControl = args.get_postBackElement(); oControl.disabled = true; }

        function ShowMenu(control, e, ID) {
            //SECURITY

            var posx = e.clientX + window.pageXOffset + 'px'; //Left Position of Mouse Pointer
            var posy = e.clientY + window.pageYOffset + 'px'; //Top Position of Mouse Pointer
            document.getElementById(control).style.position = 'absolute';
            document.getElementById(control).style.display = 'inline';
            document.getElementById(control).style.left = posx;
            document.getElementById(control).style.top = posy;
            document.getElementById("<%=hdnPurchaseID.ClientID %>").value = ID;
        }
        function HideMenu(control) {
            document.getElementById(control).style.display = 'none';
        }
        function PrintReport() {
            //alert('a');
            document.getElementById("<%=btnprint.ClientID %>").click();
         }
         function PrintCheque() {

             document.getElementById("<%=btnChequePrint.ClientID %>").click();
         }
    </script>
    <%--for alter msg in form having repeaters--%>

    <%--for row select rebinding--%>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('.table-design table tbody tr').click(function () {
                $('.table-design table tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });

            $('.table-design table tbody').on('contextmenu', 'tr', function () {
                $('.table-design table tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
                return true;
            });

        });
    </script>

    <script type="text/javascript">

        $('.menu-button').on('click', function () {
            $('.searc-nav-tab').toggleClass('toggleme1');
        });
    </script>
</asp:Content>
