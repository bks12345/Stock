<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NumericTextBox.ascx.cs" Inherits="Stock.Ensure.UserControls.Common.NumericTextBox" %>

        <asp:TextBox ID="TextBox1" runat="server" Width="195px"
             onkeypress="return IsNumeric(event,this);" ondrop="return false;" 
            onpaste="return false;"></asp:TextBox>
       

