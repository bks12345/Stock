<%@ Page Title="" Language="C#" MasterPageFile="~/Stock/main.Master" AutoEventWireup="true" CodeBehind="PurchaseEntry.aspx.cs" Inherits="Stock.Stock.Process.PurchaseEntry" %>

<%@ Register TagPrefix="aspp" TagName="DecimalOnlyError" Src="~/Stock/UserControls/Common/DecimalErrorMsg.ascx" %>
<%@ Register TagPrefix="uc" TagName="ucNumericErrMsg" Src="~/Stock/UserControls/Common/NumericErrorMsg.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .table-design {
            height: 30vh;
        }

        .toggleme1 {
            width: 99.9% !important;
        }

        #ContentPlaceHolder1_AutoCompleteExtender1_completionListElem {
            height: 250px;
            overflow: scroll;
            width: 100% !important;
        }

        @media (max-width:980px ) {
            .toggleme {
                left: 34.5%;
                top: 5.2%;
            }

            .search-form {
                height: auto;
            }
        }

        @media (max-width:768px ) {
            .toggleme {
                left: 0 !important;
                top: 4.3% !important;
                width: 100% !important;
            }

            /*.normal-marg {
                margin-top: 75px;
            }*/
        }

        .btn-addon {
            border: none;
            background: url('../../../Design/img1/search-icon.png') no-repeat center;
        }

        #ContentPlaceHolder1_lbAccCat {
            height: 50px !important;
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

        @media (max-width: 1024px) {
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

        .btn-popup {
            background: url(../../../Design/img1/search-icon.png) center no-repeat;
            border: none;
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
                <h4 class="page-header" style="margin-bottom: 0!important;">Purchase Entry</h4>
            </div>
        </div>
    </div>
    <div class="fixed-container cont-pad-top">
        <div class="">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="col-md-4 col-sm-4 col-xs-12 search-section search-form">
                        <div class="col-md-12">
                            <asp:Panel ID="pnlyeardetail" runat="server">
                                <div class="form-group normal-marg">
                                    <asp:Label ID="Label1" runat="server" Text="Fiscal Year" CssClass=" col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:DropDownList ID="ddlFiscalYr" runat="server" CssClass="form-control" DataTextField="FISCALYEAR"
                                            DataValueField="ID" AutoPostBack="true"
                                            TabIndex="1">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Branch" CssClass=" col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:DropDownList ID="ddlBranch" runat="server"  AutoPostBack="true" CssClass="form-control"
                                            DataTextField="ENAME" DataValueField="BRANCHID"
                                            TabIndex="2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" Text="Trans. No" ToolTip="Transaction No" CssClass=" col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:TextBox ID="txttransactionno" runat="server" onkeypress="return IsNumeric(event,this);" CssClass="form-control" Enabled="false"
                                            TabIndex="5"></asp:TextBox>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="form-group">
                                <div class="col-sm-12 text-right">
                                    <asp:Button ID="btnNewVoucher" runat="server" OnClick="btnNewVoucher_Click" Text="New" CssClass="btn btn-primary"
                                        TabIndex="8" />
                                    <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" CssClass="btn btn-primary"
                                        TabIndex="9" />
                                </div>
                            </div>
                            <asp:Panel ID="pnlEntry" runat="server">

                                <div class="form-group" style="border-top: 1px solid rgb(204, 204, 204); padding-top: 6px; margin-top: 11px ! important;">
                                    <asp:Label ID="Label6" runat="server" Text="Pay Date" CssClass=" col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-4 col-sm-4 col-xs-12 padd1" style="padding-right: 0;">
                                        <asp:TextBox ID="txtEDate" runat="server"  CssClass="form-control" AutoPostBack="True"
                                            TabIndex="6"></asp:TextBox>
                                        <asp:CalendarExtender ID="calEdate" runat="server" Enabled="True" TargetControlID="txtEDate"
                                            Format="dd-MMM-yyyy"></asp:CalendarExtender>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12 padd2" style="padding-left: 0;">
                                        <asp:TextBox ID="txtNDate" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <%--<div class="form-group">
                                    <asp:Label ID="Label7" runat="server" Text="Date in Nepali" CssClass="col-md-4 col-sm-12 col-xs-4 control-label"></asp:Label>
                                    <div class="col-md-8 col-sm-12 col-xs-8">
                                        <asp:TextBox ID="txtNDate" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:CalendarExtender ID="calNdate" runat="server" Enabled="false" TargetControlID="txtNDate"
                                            Format="dd-MMM-yyyy">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>--%>

                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Party Name" CssClass=" col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <div class="input-group">
                                             <asp:TextBox ID="txtpartyname" runat="server" CssClass="form-control"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <asp:HiddenField ID="hdnpartyid" runat="server" />
                                <asp:HiddenField ID="hdnaccountid" runat="server" />
                                <asp:HiddenField ID="hdnECSIPSid" runat="server" />



                                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                                    aria-hidden="true" data-backdrop="static">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                    <span aria-hidden="true">&times;</span></button>
                                                <h4 class="modal-title" id="myModalLabel">Vendor Name</h4>
                                            </div>
                                            <div class="modal-body">
                                                <iframe id="IframeEdit1" name="frame" frameborder="0" scrolling="auto" src=""
                                                    style="width: 100%; height: 300px;"></iframe>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <div class="form-group">
                                    <asp:Label ID="Label26" runat="server" Text="VAT Options" CssClass=" col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:DropDownList ID="ddlVatOption" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlVatOption_SelectedIndexChanged" CssClass="form-control" TabIndex="3">
                                            <asp:ListItem Selected="True" Value="0">Vatable</asp:ListItem>
                                            <asp:ListItem Value="1">Non-Vatable</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label27" runat="server" Text="Purchase Type" CssClass=" col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:DropDownList ID="ddlPurchaseType" runat="server" CssClass="form-control" TabIndex="3">
                                            <asp:ListItem Value="-1">None</asp:ListItem>
                                            <asp:ListItem Value="0">Import</asp:ListItem>
                                            <asp:ListItem Value="1">Capital</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label22" runat="server" Text="Bill Date" CssClass=" col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-4 col-sm-4 col-xs-12 padd1" style="padding-right: 0;">
                                        <asp:TextBox ID="txtBillDate" runat="server"  CssClass="form-control" AutoPostBack="True"
                                            TabIndex="6"></asp:TextBox>
                                        <asp:CalendarExtender runat="server" Enabled="True" TargetControlID="txtBillDate"
                                            Format="dd-MMM-yyyy"></asp:CalendarExtender>
                                    </div>
                                    <div class="col-md-4 col-sm-4 col-xs-12 padd2" style="padding-left: 0;">
                                        <asp:TextBox ID="txtNBillDate" runat="server" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label7" runat="server" Text="Bill Type" CssClass=" col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:DropDownList ID="ddlBillType" runat="server" CssClass="form-control" TabIndex="3">
                                            <asp:ListItem Selected="True" Value="1">VAT Bill</asp:ListItem>
                                            <asp:ListItem Value="2">PAN Bill</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label33" runat="server" Text="Bill No." CssClass=" col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:TextBox ID="txtBillNumber" runat="server" onkeypress="return IsNumeric(event,this);" MaxLength="50" CssClass="form-control"
                                            TabIndex="5"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label28" runat="server" Text="Remarks" CssClass=" col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"
                                            TabIndex="5" Style="width: 100%!important; resize: none!important; height: 40px!important;"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group" style="border-top: 1px solid rgb(204, 204, 204); padding-top: 6px; margin-top: 11px ! important;">
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="Label20" runat="server" Text="Payment Type" CssClass="control-label"></asp:Label>
                                    </div>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:DropDownList ID="ddlpaymenttype" TabIndex="1" runat="server" CssClass="form-control" DataValueField="id" DataTextField="PaymentType"  AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <asp:Label ID="Label21" runat="server" Text="Bank" CssClass="col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <asp:CheckBox ID="chkBankName" runat="server" AutoPostBack="True"   />
                                            </span>
                                            <asp:DropDownList ID="ddlChequeBank" runat="server" CssClass="form-control" DataTextField="ACCOUNTDESC" DataValueField="ACCOUNTCODE">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="lblChequeDate" runat="server" Text="Cheque Date" CssClass="control-Label">
                                        </asp:Label>
                                    </div>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:TextBox ID="txtChequeDate" runat="server" CssClass="form-control" onchange="return ValidationWithExpression(this,'date',false);"
                                            AutoPostBack="true" TabIndex="7"></asp:TextBox>
                                        <asp:CalendarExtender ID="ceChequedate" runat="server" TargetControlID="txtChequeDate"
                                            Format="dd-MMM-yyyy"></asp:CalendarExtender>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="lblCheqNo" runat="server" Text="Cheque No." CssClass=" control-label">
                                        </asp:Label>
                                    </div>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:TextBox ID="txtCheqNo" runat="server" CssClass="form-control" TabIndex="8" MaxLength="40" AutoPostBack="true">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-4 col-sm-4 col-xs-12">
                                        <asp:Label ID="lblCheqAmt" runat="server" Text="Amount" CssClass="control-label">
                                        </asp:Label>
                                    </div>
                                    <div class="col-md-8 col-sm-8 col-xs-12">
                                        <asp:TextBox ID="txtCheqAmt" onkeypress="return isDecimal(event,this,13,2);"
                                            ondrop="return false;" onpaste="return false;" runat="server" CssClass="form-control"
                                            TabIndex="9" AutoPostBack="true">
                                        </asp:TextBox>
                                    </div>
                                </div>

                            </asp:Panel>

                        </div>
                    </div>
                    <div class="form-group" style="display: none;">
                        <div class="col-sm-12 col-xs-12 col-md-12">
                            <asp:Button ID="btngetinfo" runat="server" data-toggle="modal" data-target="#myModalicon1" OnClientClick="OpenBankInfo();" Text="Get Bank Info" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="col-md-8 col-sm-8 col-xs-12 search-output search-form">
                <div class="row searc-nav-tab toggleme" style="left: 34.2%; top: 5.7%;">
                    <div class="col-md-2 col-sm-2 toggleClass visible-md visible-sm visible-lg">
                        <span id="tblcontents" class="menu-button"><%--Table of Contents--%></span>
                    </div>
                    <div class=" col-md-7 col-sm-10 col-xs-12">
                        <div class="search-icon-label">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblHeading" runat="server" Text=""></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:Panel runat="server" ID="panelEntry2">
                                    <div class="row" style="margin-top: 10px;">
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <div class="panel panel-default">
                                                <div class="panel-heading text-center list-header">
                                                    <asp:Label ID="Label8" runat="server" Text="Item" CssClass="control-label"></asp:Label>
                                                </div>
                                                <div class="input-group">
                                                    <asp:TextBox ID="txtitem"   runat="server" CssClass="form-control"
                                                        TabIndex="11" AutoPostBack="true"></asp:TextBox>
                                                    <asp:AutoCompleteExtender ServiceMethod="SearchCustomers" MinimumPrefixLength="1"
                                                        CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" TargetControlID="txtitem"
                                                        ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                                    </asp:AutoCompleteExtender>
                                                    <div class="input-group-addon">
                                                        <asp:Button ID="txtitemsearch" OnClick="txtitemsearch_Click"  runat="server" Text="" CssClass="btn-addon" />
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                                        <asp:ListBox ID="lbitems" runat="server" CssClass="form-control textarea-height"
                                                            DataTextField="EDESCRIPTION" DataValueField="PRODUCTID" AutoPostBack="true"
                                                            Style="border: none; height: 55px !important;" TabIndex="12"></asp:ListBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6 col-sm-6 col-xs-12">
                                            <div class="form-group">
                                                <asp:Label ID="lblDrAmt" runat="server" Text="Rate" CssClass="col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtrate" runat="server" AutoPostBack="true" OnTextChanged="txtrate_TextChanged"   onkeypress="return isDecimal(event,this,15,2);"
                                                        ondrop="return false;" onpaste="return false;" CssClass="form-control"
                                                        TabIndex="15"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblChequeNo" runat="server" Text="Quantity" CssClass="col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtquantity" runat="server" OnTextChanged="txtquantity_TextChanged"  onkeypress="return IsNumeric(event,this);" AutoPostBack="true" CssClass="form-control" MaxLength="20"
                                                        TabIndex="17"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="Label3" runat="server" Text="Amount" CssClass="col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtamount" runat="server" CssClass="form-control" MaxLength="20" Enabled="false"
                                                        TabIndex="17"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group" style="display:none;">
                                                <asp:Label ID="Label23" runat="server" Text="Is vatable" CssClass="col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:CheckBox ID="chkisvatable" runat="server" />
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-md-12 col-sm-12 col-xs-12 text-right">
                                                    <asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click" Text="Add"   CssClass="btn btn-primary"
                                                        TabIndex="21" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnbind" runat="server" Text="Show"  OnClick="btnbind_Click"
                                        Style="display: none" />
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12">
                                            <div class="table-design" style="margin-bottom: 20px; margin-top: 10px;">
                                                <table id="rpt2" class="stripe row-border order-column" cellspacing="0" width="100%">
                                                    <thead>
                                                        <tr>
                                                            <th>
                                                                <asp:Label ID="Label12" runat="server" Text="SN" Width="20px"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="Label14" runat="server" Text=" Items" Width="200px"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="Label17" runat="server" Text="Rate" Width="200px"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="Label18" runat="server" Text="Quantity" Width="120px"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="Label19" runat="server" Text="Amount" Width="120px"></asp:Label>
                                                            </th>
                                                            <th style="display: none">
                                                                <asp:Label ID="Label10" runat="server" Text="itemid" Width="120px"></asp:Label>
                                                            </th>
                                                            <th>
                                                                <asp:Label ID="Label25" runat="server" Text="isvatable" Width="120px"></asp:Label>
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Repeater ID="rptpurchaseentry" runat="server">
                                                            <ItemTemplate>
                                                                <tr style="cursor: pointer;" onclick="Select(this,<%# Eval("ROWNUMBER")%>);">
                                                                    <td>
                                                                        <asp:Label ID="lblEntry" runat="server" Text='<%#Eval("ROWNUMBER") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label13" runat="server" Text='<%#Eval("item") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label15" runat="server" Text='<%#Eval("rate") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Label16" runat="server" Text='<%#Eval("quantity") %>'></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblamount" runat="server" Text='<%#Eval("amount") %>'></asp:Label>
                                                                    </td>
                                                                    <td style="display: none">
                                                                        <asp:Label ID="Label9" runat="server" Text='<%#Eval("itemid") %>'></asp:Label>
                                                                    </td>
                                                                     <td>
                                                                        <asp:Label ID="Label29" runat="server" Text='<%#Eval("isvatable") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-offset-6 col-sm-offset-0 col-xs-offset-0  col-md-6 col-sm-12 col-xs-12">
                                            <div class="form-group">
                                                <asp:Label ID="lblTotDeb" runat="server" Text="Total Amount" CssClass="col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txttotal" runat="server" CssClass="form-control" Enabled="false"
                                                        TabIndex="24"></asp:TextBox>
                                                </div>
                                            </div>
                                             <div class="form-group" >
                                                <asp:Label ID="lblTotCr" runat="server" Text="Discount %" CssClass="col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                                <div class="col-md-2 col-sm-2 col-xs-12">
                                                    <asp:TextBox ID="txtdisperc" runat="server" AutoPostBack="true" onkeypress="return isDecimal(event,this,2,2);" OnTextChanged="txtdisperc_TextChanged" CssClass="form-control" Enabled="true"
                                                        TabIndex="25"></asp:TextBox>
                                                </div>
                                                <div class="col-md-6 col-sm-6 col-xs-12">
                                                    <asp:TextBox ID="txtdiscountamt" runat="server" CssClass="form-control" Enabled="false"
                                                        TabIndex="25"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="Label11" runat="server" Text="VAT %" CssClass="col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                                <div class="col-md-2 col-sm-2 col-xs-12 padd1" style="padding-right: 0;">
                                                    <asp:TextBox ID="txtvatper" runat="server" AutoPostBack="true" onkeypress="return IsNumeric(event,this);"   CssClass="form-control" Enabled="true"
                                                        TabIndex="25"></asp:TextBox>
                                                </div>
                                                <div class="col-md-6 col-sm-6 col-xs-12 padd2" style="padding-left: 0;">
                                                    <asp:TextBox ID="txtvatamt" runat="server" CssClass="form-control" onkeypress="return isDecimal(event,this,13,2);"  AutoPostBack="true"
                                                        TabIndex="25"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="Label24" runat="server" Text="Net Payable" CssClass="col-md-4 col-sm-4 col-xs-12 control-label"></asp:Label>
                                                <div class="col-md-8 col-sm-8 col-xs-12">
                                                    <asp:TextBox ID="txtnetpayable" runat="server" CssClass="form-control" Enabled="false"
                                                        TabIndex="24"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <%-- <div class="form-group" >
                                            <asp:Label ID="Label20" runat="server" Text="Net Payable" CssClass="col-md-4 col-sm-4 col-xs-4 control-label"></asp:Label>
                                            <div class="col-md-8 col-sm-8 col-xs-8">
                                                <asp:TextBox ID="txtnetpayable" runat="server"  CssClass="form-control" Enabled="false"
                                                    TabIndex="24"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <div class="form-group" style="display: none">
                                            <asp:Label ID="lblid" runat="server" Text="ID" CssClass="col-md-4 col-sm-4 col-xs-4 control-label"></asp:Label>
                                            <div class="col-md-8 col-sm-8 col-xs-8">
                                                <asp:TextBox ID="txtid" runat="server" CssClass="form-control" Enabled="false"
                                                    TabIndex="24"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    </div>

                           
                            
                               
                           
                                </asp:Panel>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <!-- Modal -->
                        

                        <!-- Modal (Get Bank Info) -->
                        <div class="modal fade" id="myModalicon1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static">
                            <div class="modal-dialog" id="common-modal6">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" onclick="ClosePopup();" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                        <h4 style="margin: 0;">Payee Bank Account Info</h4>
                                    </div>
                                    <div class="modal-body">
                                        <iframe id="IframeEdit6" name="frame" frameborder="0" width="100%" scrolling="auto"></iframe>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Modal (Get Bank Info) -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnrownum" runat="server" />


    <asp:HiddenField ID="hdnBankname" runat="server" />
    <asp:HiddenField ID="hdnbranch" runat="server" />
    <asp:HiddenField ID="hdnAcno" runat="server" />
    <asp:HiddenField ID="hdnAcHolderName" runat="server" />
    <asp:HiddenField ID="hdnBankCode" runat="server" />
    <asp:HiddenField ID="hdnNatureOfPayment" runat="server" />
    <asp:HiddenField ID="hdnRemarks" runat="server" />
    <asp:HiddenField ID="hdnisbankdetails" runat="server" />


    <div class="row fixed-footer">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"   OnClientClick="$('#search-loading').show();$('#empty').show(); return ValidateForm();" CssClass="btn btn-default"
                TabIndex="27" />
            <asp:Button ID="btnPrint" runat="server" Text="Print"   CssClass="btn btn-default"
                TabIndex="28" />
            <asp:Button ID="btnClear"  OnClick="btnClear_Click" runat="server"   Text="Clear" CssClass="btn btn-default"
                TabIndex="29" />
        </div>
    </div>

    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
            <!-- for pre-loading -->
            <div id="search-loading">
                <img alt="image-loader" src="../../../Design/img1/ajax-loader-bar.gif">
            </div>
            <div id="empty">
            </div>
            <!-- /pre-loading -->
        </ContentTemplate>
    </asp:UpdatePanel>


    <!-- for popup window block             -->
    <asp:HiddenField ID="hdnOpenFrom" runat="server" />


    <!-- for popup window block  -->



    <aspp:DecimalOnlyError ID="DecimalOnlyError1" runat="server" />
    <uc:ucNumericErrMsg ID="NumericChk" runat="server" />
    <asp:Button ID="btnShow" runat="server" Text="Show" Style="display: none" />
    <script src="/Design/js1/jquery.1.11.1.min.js" type="text/javascript"></script>
    <script src="/Design/js1/Ensure/FromValidation.js" type="text/javascript"></script>
    <script>
        function ChangePopup() {
            var partyid = document.getElementById('<%=hdnpartyid.ClientID %>').value;

            var frame = $get('IframeEdit1');
            frame.src = "";
            // constModule = module;

            document.getElementById('IframeEdit1').style.height = (window.outerHeight * 0.5) + "px";
            document.getElementById('IframeEdit1').style.width = (window.outerWidth * 0.388) + "px";
            frame.src = "";


            frame.src = "../../Setup/Account/VendorName.aspx?Id=" + partyid;

            frame.src = frame.src + "&&OPENAS=POPUP";


        }
        function BrowseAccountHead(prmType) {
            document.getElementById("<%=hdnOpenFrom.ClientID %>").value = prmType;
        }
    </script>
    <script type="text/javascript">
        function ddlpaymodechange() {
            var _selectedvalue = document.getElementById("<%=ddlpaymenttype.ClientID %>").value;
            if (_selectedvalue == '1') {
                document.getElementById("<%=txtCheqNo.ClientID %>").disabled = false;

               }

               if (_selectedvalue == '2') {
                   document.getElementById("<%=btngetinfo.ClientID %>").click();
                document.getElementById("<%=txtCheqNo.ClientID %>").disabled = true;

            }
            if (_selectedvalue == '3') {
                document.getElementById("<%=btngetinfo.ClientID %>").click();
                document.getElementById("<%=txtCheqNo.ClientID %>").disabled = true;
            }
        }
        function OpenBankInfo() {
            var accid = document.getElementById("<%=hdnaccountid.ClientID %>").value;

            document.getElementById('IframeEdit6').style.height = (window.outerHeight * 0.35) + "px";
            document.getElementById('common-modal6').style.width = (window.outerWidth * 0.4) + "px";  //page-header
            var frame = document.getElementById('IframeEdit6');
            frame.src = "../../Process/Account/BankPaymentInfo.aspx?OPENAS=POPUP" + "&&NatureofId=9" + "&&AccountId=" + accid;
        }
    </script>
    <script type="text/javascript">

        function getinfo(hdnBankname, hdnbranch, hdnAcno, hdnAcHolderName, hdnBankCode, hdnNatureOfPayment, hdnRemarks, hdnisbankdetails) {
            //alert(hdnBankname + ' : ' + hdnbranch + ' : ' + hdnAcno + ' : ' + hdnAcHolderName + ' : ' + hdnBankCode + ' : ' + hdnNatureOfPayment + ' : ' + hdnRemarks + ' : ' + hdnisbankdetails);
            document.getElementById("<%=hdnBankname.ClientID %>").value = hdnBankname;
            document.getElementById("<%=hdnbranch.ClientID %>").value = hdnbranch;
            document.getElementById("<%=hdnAcno.ClientID %>").value = hdnAcno;
            document.getElementById("<%=hdnAcHolderName.ClientID %>").value = hdnAcHolderName;
            document.getElementById("<%=hdnBankCode.ClientID %>").value = hdnBankCode;
            document.getElementById("<%=hdnNatureOfPayment.ClientID %>").value = hdnNatureOfPayment;
            document.getElementById("<%=hdnRemarks.ClientID %>").value = hdnRemarks;
            document.getElementById("<%=hdnisbankdetails.ClientID %>").value = hdnisbankdetails;
            ClosePopup();
        }
        function ClosePopup() {

            //alert(hdnBankname + ' : ' + hdnbranch + ' : ' + hdnAcno + ' : ' + hdnAcHolderName + ' : ' + hdnBankCode + ' : ' + hdnNatureOfPayment + ' : ' + hdnRemarks + ' : ' + hdnisbankdetails);
            $('#myModalicon1').modal('hide');
        }

    </script>
    <script type="text/javascript">
        function HideMenu() { };

        $('.menu-button').on('click', function () {
            $('.searc-nav-tab').toggleClass('toggleme1');
        });
    </script>

    <%--for row select rebinding--%>
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {

            $('.table-design table tbody tr').click(function () {
                $('.table-design table tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(document).delegate('.input-group-addon', 'click', function () {
                $('.fixed-header').css('z-index', '-1024');
            });
            $(document).delegate('.zIndex', 'click', function () {
                $('.fixed-header').css('z-index', '1024');
            });
        });


    </script>
    <script type="text/javascript" language="javascript">
        function Select(obj, ID) {
            document.getElementById("<%=hdnrownum.ClientID %>").value = ID;
            document.getElementById("<%=btnbind.ClientID %>").click();

        }

        function ValidateForm() {
            var oForm1 = document.forms["form1"];
            var txtBillNumber = oForm1["ContentPlaceHolder1_txtBillNumber"];
            if (!Validate(txtBillNumber, false)) return false;
            //var txtvatper = oForm1["ContentPlaceHolder1_txtvatper"];
            //if (!Validate(txtvatper, false)) return false;

        }


    </script>
</asp:Content>

