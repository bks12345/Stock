<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Stock.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title><link href="Design/css1/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <%-- <link href="Design/css/stylesheet.css" rel="stylesheet" type="text/css" />
    <link href="Design/css/kishan-style.css" rel="stylesheet" type="text/css" />--%>
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

    </style>
     
</head>
<body  id="login-form">
    <%--<div class="container">
    <form id="form1" runat="server" class="form-horizontal">
    <div class="Login" style="width:20%; margin:0 auto; padding:10px 0px">
        <div class="row">
               <h4>Please Sign In</h4>
        </div>
        <div class="form-group">
            <div class="col-md-12">
                <div class="form-group">
                    <asp:TextBox ID="txtusername" runat="server" placeholder="UserName"  CssClass ="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtpassword" runat="server"  TextMode="Password" placeholder="Password"  CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-12">
            <div class="form-group">
              <asp:CheckBox  ID="chkrememberme"  runat="server" /> <label>Remember Me</label>
         
        </div>
        </div>
        </div>
        <div class="row">
        <asp:Button ID="btnLogin" runat="server" Text="Log in" class="btn btn-primary col-md-12" OnClick="btnLogin_OnClick" />
        </div>
    </div>
    </form>
    </div>--%>
    <asp:Label ID="lblmsz" runat="server" Text="" Visible="false"></asp:Label>
    <form id="form1" runat="server" class="form-horizontal">
    <div class="container-fluid login-page">
        <div class="login-content">
            <div class="row">
                <div class="col-sm-4 col-sm-offset-4 login-content1">
                    <div class="form-group text-center">
                        <h3>
                            <asp:Label ID="lblCompanyName" runat="server" Text="Label"></asp:Label></h3>
                    </div>
                        <div class="form-group" style="margin-bottom:10px!important;">
                        <div class="col-md-4 col-xs-12 col-sm-4 text-center">
                            <a class="login-logo">
                            <asp:Image ID="Image1" runat="server" class="img-responsive"></asp:Image>
                            <%--<img src="Design/img1/premium-logo.png" class="img-responsive" alt="logo" />--%>
                            </a>
                            </div>
                            
                        <div class="col-md-8 col-xs-12 col-sm-8">
                            <p>Head Office: 
                                <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label><%--Narayan Chaur Naxal--%></p>
                            
                            <p>Tel: 
                                <asp:Label ID="lblPh" runat="server" Text="Label"></asp:Label><%--4412543, 4410648--%> FAX: 
                                <asp:Label ID="lblFax" runat="server" Text="Label"></asp:Label><%--977-1-4413442--%></p>
                            <p>Email: 
                                <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label><%--prem ier@picl.com.np--%></p>
                            <p>web: 
                                <asp:Label ID="lblWebSite" runat="server" Text="Label"></asp:Label><%--www.premier.insurance.com.np--%></p>
                        </div>
                        </div>
                        <%--for national only--%>
                        <%--<div class="form-group">
                        <div class="col-md-12 col-xs-12 col-sm-12 text-center">
                            <a class="login-logo">
                            <asp:Image ID="Image2" runat="server" class="img-responsive"></asp:Image>
                            </a>
                            <p>Head Office: 
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></p>
                            
                            <p>Tel: 
                                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>FAX: 
                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></p>
                            <p>Email: 
                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></p>
                            <p>web: 
                                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></p>
                            </div>
                            
                        </div>--%>
                        <%--for national only ends--%>
                    <div class="login-mid">
                        <div class="form-group">
                            <div class="col-md-12 login-icon">
                                <asp:TextBox ID="txtusername" runat="server" placeholder="UserName" CssClass="form-control log-user" TabIndex="1"></asp:TextBox>
                                <span class="fa fa-user log-icon1"></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12 login-icon">
                                <asp:TextBox ID="txtemail" runat="server" placeholder="Email" CssClass="form-control log-user" TabIndex="1"></asp:TextBox>
                                <span class="fa fa-envelope-o log-icon1"></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12 login-icon1">
                                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" placeholder="Password" CssClass="form-control log-user" TabIndex="2"></asp:TextBox>
                                <span class="fa fa-key log-icon2"></span>
                            </div>
                        </div>
                        <%--<div class="form-group text-center">
                            <div class="log-remb">
                                <asp:CheckBox ID="chkrememberme" runat="server" TabIndex="3" />
                                <label>Remember Me</label>
                            </div>
                        </div>--%>
                        <div class="form-group">
                            <div class="col-md-12 text-right">
                                <asp:Button ID="btnLogin" runat="server" Text="Log in" class="btn btn-primary log-btn" OnClick="btnLogin_OnClick" TabIndex="4" />
                                <asp:Button ID="Button1" runat="server" Text="Log in" class="btn btn-primary log-btn" OnClick="Button1_OnClick" TabIndex="4" Visible="false" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12">
                                <asp:Label ID="Label1" runat="server" Text="Current Date: "></asp:Label>
                                <asp:Label ID="lblCurrentDate" runat="server" Text=""></asp:Label>
                            </div>
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
                        <img src="Design/img1/semantic_icon.png" alt="arhant-logo"/></a>
                </div>
            </div>
            <div class="col-md-6 text-right ">
                <div class="copyright1">
                    <p><span>(Version 1.0)</span> © 2015 copyright. All Rights Reserved</p>
                </div>
            </div>
        </div>

    </div>
    </form>
</body>
</html>