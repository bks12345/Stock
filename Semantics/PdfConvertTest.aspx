<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PdfConvertTest.aspx.cs" Inherits="Ensure.PdfConvertTest" %>
<%@ Reference VirtualPath="~/Ensure/Reports/RptTemplates.aspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:TextBox ID="txtPolicy" runat="server"></asp:TextBox>
        <asp:Button ID="btnConvetPDF" OnClick="btnConvetPDF_Click" runat="server" Text="PDF" />
        <asp:Label ID="lblFileName" runat="server" Text=""></asp:Label>
        <asp:literal ID="ltrFileName" runat="server"></asp:literal>

        <asp:Repeater ID="Repeater1" runat="server">
    <HeaderTemplate>
        <table cellspacing="0" rules="all" border="1">
            <tr>
                <th>
                    File Name
                </th>
            </tr>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <%# Container.DataItem %>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
    </div>
    </form>
</body>
</html>

