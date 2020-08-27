<%@ Page Title="" Language="C#" MasterPageFile="~/Ensure/main.Master" AutoEventWireup="true" CodeBehind="newsletter1.aspx.cs" Inherits="Stock.newsletter1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>
    .well 
    {
        background:#55C3DA;
  border: medium none;
  border-radius: 0 30px 0 0;
  margin-bottom: 20px;
  min-height: 20px;
  padding: 0px;
 
}

.news-header { padding:15px 0; font-family: Arial; font-weight:bold;}
.news-header p {
  margin-bottom: 0;
}
.something 
{
    background:#ffffff;
    border-radius: 95px 0 0 0;
    padding: 35px 10px 10px 35px;
    margin-left:30px;
    border:1px solid #eee;
    }
    .something h4 {
  border-radius: 25px 0 0;
  padding: 10px;
}

.bg-custom {
  margin-bottom: 0;
}
.news-header h1 {
  color: #000000;
  font-size: 25px;
  margin: 0;
  text-transform: capitalize;
  padding-left:100px;
}
 .table-design
        {
            height: 32vh !important;
        }
        h1 > p {
  font-size: 16px;
  padding-left: 35px;
}
   

 
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-8">
                <div class="well">
                    <%--<div class="row">
                        <div class="col-sm-12">
                            <div class="news-header text-center">
                                <a href="#">
                                    <img src="Design/img1/arhant_logo.png" /></a>
                                <p style="margin-top:10px;">
                                    Address: Thaiba, Lalitpur Nepal</p>
                                <p>
                                    Telephone: 123-4567890</p>
                                <p>
                                    Website: abc@xyz.com</p>
                            </div>
                        </div>
                    </div>--%>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="news-header" style="padding: 25px 15px 25px 35px;">
                            <div class="row">
                                <div class="col-sm-3">
                                <a href="#">
                                    <img src="Design/img1/arhant_logo.png" /></a>
                               
                                </div>
                                <div class="col-sm-9">
                                <h1>Arhant Solution
                                <p>Thaiba, Lalitpur</p></h1>
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                    <div class="something">
                        <div class="row">
                            <div class="col-sm-12 text-center">
                                <h4 class="bg-info">
                                    Letter of Agreement</h4>
                            </div>
                        </div>
                        <%--<div class="row">
                            <div class="col-sm-8" style="border-right:2px solid #eeeeee;">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Name of something" CssClass="col-sm-12 control-label"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="def-14, kathmandu Nepal" CssClass="col-sm-12 control-label"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" Text=" something@something.com" CssClass="col-sm-12 control-label"></asp:Label>
                                </div>
                            
                            </div>
                            <div class="col-sm-4">
                            
                                <div class="form-group">
                                    <asp:Label ID="Label2" runat="server" Text="Quotation #" CssClass="col-sm-6 text-right"></asp:Label>
                                    <asp:Label ID="Label6" runat="server" Text="123456" CssClass="col-sm-6 text-right"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label4" runat="server" Text="Date" CssClass="col-sm-6 text-right"></asp:Label>
                                    <asp:Label ID="Label7" runat="server" Text="9 August 2015" CssClass="col-sm-6 text-right"></asp:Label>
                                </div>
                            </div>
                        </div>--%>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" Text="Name of something" CssClass="col-sm-12 control-label"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label3" runat="server" Text="def-14, kathmandu Nepal" CssClass="col-sm-12 control-label"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label5" runat="server" Text=" something@something.com" CssClass="col-sm-12 control-label"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 50px;">
                            <div class="col-sm-12">
                                <p>
                                    Dear something,</p>
                             
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                    
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                    
                                     
                               
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="table-design">
                                    <table id="rpt2" cellspacing="0" class="stripe row-border order-column" width="100%">
                                        <thead>
                                            <tr>
                                                <th>
                                                    <asp:Label ID="Label17" runat="server" Text="SNo." Width="50px"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="Label7" runat="server" Text="GL Code" Width="50px"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="Label27" runat="server" Text="SL Code" Width="50px"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="Label14" runat="server" Text="AccID" Width="100px"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="Label24" runat="server" Text="Account Head" Width="200px"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="Label4" runat="server" Text="catid" Width="100px"></asp:Label>
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <th>
                                                    <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                                </th>
                                                <th>
                                                    <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                                                    </th>
                                                    <th>
                                                        <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                                                </th>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                             
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                    
                                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                                    
                                   
                            </div>
                        </div>
                        <div class="row" style="margin-top: 50px;">
                            <div class="col-sm-4 text-center pull-right">
                                <p>
                                    Regards</p>
                                <p>
                                    Something</p>
                                     <p>
                                     Thaiba, Lalitpur Nepal</p>
                                <p>
                                    123-4567890</p>
                                <p>
                                    abc@xyz.com</p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <p class="copyright text-center bg-custom">
                                © 2015 <a href="#">Arhant Solution.</a> All Right Reserved</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

       <%--for row select rebinding--%>
      <script type="text/javascript">
          function HideMenu() { };
          var prm = Sys.WebForms.PageRequestManager.getInstance();
          prm.add_endRequest(function () {

              $('.table-design table tbody tr').click(function () {
                  $('.table-design table tbody tr.select_table').removeClass('select_table');
                  $(this).addClass('select_table');
              });
          });
    </script>
</asp:Content>
