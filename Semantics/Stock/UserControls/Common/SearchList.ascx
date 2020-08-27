<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchList.ascx.cs"
    Inherits="Ensure.Ensure.UserControls.Common.SearchList" %>
<div class="panel panel-default">
    <div class="panel-heading text-center list-header">
        <asp:Label ID="Label49" runat="server" Text="Owner"></asp:Label>
       
    </div>
     <div class="input-group">
            <asp:TextBox ID="txtName" runat="server" AutoPostBack="True" OnTextChanged="txtName_TextChanged"
                class="lg-input" CssClass="form-control"></asp:TextBox>
            <div class="input-group-addon" style="margin-top: -4px;">
                <a href="#" TabIndex="-1">
                    <img src="../../../../../Design/img1/search-icon.png" /></a>
            </div>
        </div>
    <asp:ListBox ID="lbName" runat="server" AutoPostBack="True" DataTextField="TITLE"
        DataValueField="ACCOUNTNAMECODE" OnSelectedIndexChanged="lbName_SelectedIndexChanged"
        CssClass="form-control" Style="min-height: 200px;"></asp:ListBox>
</div>
