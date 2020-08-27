<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<frameset id="frmMainPage" name="Main" rows="100,*" framespacing="0" noresize="true" border="0" frameborder="0">
    <frame id="frmHeading" src="/Ensure/Master/heading.aspx" scrolling="no" border="0" frameborder="0"></frame>
    <frameset id="frmMain" cols="250,*" scrolling="yes" framespacing="0" noresize="true" border="0" frameborder="0">
        <frame id="frmSidebar" src="/Ensure/Master/mnuUnder.aspx" name="sidebar"  scrolling="yes" border="0" frameborder="0"></frame>
        <frameset id="frmRemaining" rows="50,*" framespacing="0" noresize="true" border="0" frameborder="0">
            <frame id="frmMenu"  src="Ensure/Master/menu.aspx" scrolling="no" border="0" frameborder="0"></frame>
            <frame id="frmContent"  src="Ensure/Master/content.aspx" name="content" scrolling="yes" border="0" frameborder="0"></frame>
        </frameset>
        
    </frameset>
    
</frameset>
</html>
