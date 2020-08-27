<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="activateaccount.aspx.cs" Inherits="Ensure.activateaccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   <link href="Design/css1/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Design/css1/stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="Design/css1/font-awesome.css" rel="stylesheet" type="text/css" />
    <style>
    .copyright2 {
  border-top: 1px solid #ccc;
  bottom: 0;
  position: absolute;
  width: 100%;
  padding:10px 0;
}
.copyright1 > p {
  margin-top: 10px;
}
.login-logo {
  display: inline-block;
  height: auto;
  text-align: center;
  width: 85px;
}
.login-content p {
  margin-bottom: 0;
}
.login-logo > img {
  height: auto;
  width: 100%;
}
.log-btn {
  background: #1e4377 none repeat scroll 0 0;
}
.log-icon1, .log-icon2 {
  color: #000000;
  position: absolute;
  right: 25px;
  top: 4px;
}
.login-content1 {
  padding: 50px;
}
.login-content1 h3{background:none; color:#000;}
.login-mid a {
  text-decoration: underline;
}
.login-mid a:hover {
  text-decoration: none;
}
    </style>
</head>
<body id="login-form">
  
    <form id="form1" runat="server" class="form-horizontal">
    <div class="container-fluid login-page">
        <div class="login-content">
            <div class="row">
                <div class="col-sm-6 col-sm-offset-3 login-content1">
                    <div class="form-group text-center">
                        <h3>
                            <asp:Label ID="lblCompanyName" runat="server" Text="Label"></asp:Label></h3>
                    </div>
                        <div class="form-group" style="margin-bottom:10px!important;">
                        <div class="col-md-4 col-xs-12 col-sm-4 text-center">
                            <a class="login-logo">
                              <asp:Image ID="Image1" runat="server" class="img-responsive"></asp:Image>
                          <%--  <img src="Design/img1/premium-logo.png" class="img-responsive" alt="logo" />--%>
                            </a>
                            </div>
                            
                        <div class="col-md-8 col-xs-12 col-sm-8">
                            <p>Head Office: 
                                <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label></p>
                            
                            <p>Tel: 
                                <asp:Label ID="lblPh" runat="server" Text="Label"></asp:Label> 
                                <asp:Label ID="lblFax" runat="server" Text="Label"></asp:Label></p>
                            <p>Email: 
                                <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></p>
                            <p>web: 
                                <asp:Label ID="lblWebSite" runat="server" Text="Label"></asp:Label></p>
                        </div>
                        </div>
                       
                         <div class="form-group text-center">
                        <h3>
                            <asp:Label ID="lblMessage" ForeColor="#008a00" runat="server" Text=""></asp:Label></h3>
                    </div>
                        <%--for national only ends--%>
                    <div class="login-mid">
                        <div class="form-group text-center">
                           <a href="Login.aspx">Move to Login Page</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        
        <div class="row copyright2">
            <div class="col-md-6 ">
                <div class="copyright1">
                    <%--<h5>Powered By</h5>--%>
                    <a href="http://www.arhant.com/" alt="images">
                        <img src="Design/img1/arhant_logo.png" alt="arhant-logo"/></a>
                </div>
            </div>
            <div class="col-md-6 text-right ">
                <div class="copyright1">
                    <p>© 2015 copyright. All Rights Reserved</p>
                </div>
            </div>
        </div>

    </div>
    </form>
</body>
</html>
