<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ImportBtn.ascx.cs" Inherits="Stock.Ensure.UserControls.Common.ImportBtn" %>
<asp:FileUpload ID="FileUpload1" runat="server" />
<asp:RadioButtonList ID="rbHDR" runat="server" Visible="false">
    <asp:ListItem Text = "Yes" Value = "Yes" Selected = "True" >
    </asp:ListItem>
    <asp:ListItem Text = "No" Value = "No"></asp:ListItem>
</asp:RadioButtonList>