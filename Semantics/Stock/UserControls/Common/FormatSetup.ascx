<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FormatSetup.ascx.cs" Inherits="Ensure.Ensure.UserControls.Common.FormatSetup" %>
<style type="text/css">
    .rptTable, .rptHeader th { font-weight:normal; background-color:#337AB7 ; border: 1px solid #FFFFFF;border-collapse: collapse;color: #FFFFFF;font-family: Arial;font-size: 12px; padding: 10px;}
    .rptRow td {background-color: #EDEDED;border: 1px solid #FFFFFF;border-collapse: collapse;color: #000000;/*padding-left: 15px;*/ padding:3px;}
    .rptRow2 td {background-color: #FFF;border: 1px solid #FFFFFF;border-collapse: collapse;color: #000000;/*padding-left: 15px;*/ padding:3px;}
    .noBorder td{ border:none;}
    ul {list-style: outside none none;padding: 0;}
    li {float: right;}
    li:first-child{margin-bottom: 5px;}
    body {overflow-x:hidden}
</style>
<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
<ContentTemplate>--%>
<div class="col-md-12">
    <asp:GridView ID="gdvFormatSetup" runat="server" AutoGenerateColumns="False" OnRowDataBound="gdvFormatSetup_RowDataBound">
        <AlternatingRowStyle CssClass="rptRow2" />
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" OnCheckedChanged="chkSelect_CheckedChanged" runat="server"
                        Checked='<%#Convert.ToBoolean(Eval("checked").ToString()) %>' AutoPostBack="True" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Table Name">
                <ItemTemplate>
                    <asp:Label ID="lblTblName" runat="server" Text='<%#Eval("name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Display">
                <ItemTemplate>
                    <asp:RadioButtonList ID="rblDiplay" runat="server" RepeatDirection="Horizontal" CssClass="noBorder">
                        <asp:ListItem>Code</asp:ListItem>
                        <asp:ListItem>Alias</asp:ListItem>
                    </asp:RadioButtonList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Separator">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlSeparator" runat="server">
                        <asp:ListItem Value="">None</asp:ListItem>
                        <asp:ListItem Value="/">/</asp:ListItem>
                        <asp:ListItem Value="-">-</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sort">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlSort" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
                        <asp:ListItem Value="">None</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="rptHeader" />
        <RowStyle CssClass="rptRow" />
    </asp:GridView>
    <div class="row">
        <br />
        <div class="col-md-12">
            <asp:Button ID="btnEg" runat="server" Text="View Example" OnClick="btnEg_Click" CssClass="btn btn-primary" />
        </div>
    </div>
    <div class="form-group row">
    <br />
        <asp:Label ID="lblEg" runat="server" Text="Eg:" CssClass="control-label col-md-1 col-sm-1 col-xs-1"></asp:Label>
        <div class="col-md-8 col-sm-8 col-xs-8">
            <asp:TextBox ID="txtEg" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnDone" runat="server" Text="Done" OnClick="btnDone_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="btn btn-primary" />
        </div>
    </div>
</div>

        
<%--<script src="../../../../Design/Scripts/js/bootstrap.min.js" type="text/javascript"></script>--%>
<%--</ContentTemplate>
</asp:UpdatePanel>--%>
