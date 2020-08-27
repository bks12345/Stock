<%@ Page Title="" Language="C#" MasterPageFile="~/Stock/main.Master" AutoEventWireup="true" CodeBehind="DashboardNew.aspx.cs" Inherits="Stock.DashboardNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
       /* .main-dash{position:relative;}*/
.main-dashboard {height: 300px;width: 300px;top: 35vh;position: absolute;left: 36%;}
.main-dashboard ul {position: relative;list-style:none;}
.main-dashboard .text li {background: #ccc none repeat scroll 0 0;border-radius: 20px 0 0 20px;/*font-size: 15px;*/font-size:13px;padding: 5px 0 5px 20px;position: absolute;}

.main-dashboard .text li:first-child {left: -73px;top: 90px;transform: rotate(360deg);width: 100px;}
.main-dashboard .text li:nth-child(2) {left: -65px;top: 10px;transform: rotate(27deg);width: 110px;}
.main-dashboard .text li:nth-child(3) {left: -25px;top: -65px;transform: rotate(55deg);width: 130px;}
.main-dashboard .text li:nth-child(4) {left: 76px;top: -104px;transform: rotate(90deg);width: 140px;}
.main-dashboard .text li:nth-child(5) {right: -19px;top: -65px;transform: rotate(126deg);width: 130px;}
.main-dashboard .text li:nth-child(6) {right: -59px;top: 10px;transform: rotate(155deg);width: 110px;}
.main-dashboard .text li:nth-child(7) {right: -67px;top: 90px;transform: rotate(180deg);width: 100px;}
.main-image {height: auto;width: 100%;}
.new-image li a {display: block;height: 40px;width: 40px;}
.new-image img {width: 100%;}
.main-dashboard .new-image li {position: absolute;}

.main-dashboard .new-image li:first-child {left: -120px;top: 77px;}
.main-dashboard .new-image li:nth-child(2) {left: -105px;top: -35px;}
.main-dashboard .new-image li:nth-child(3) {left: -30px;top: -150px;}
.main-dashboard .new-image li:nth-child(4) {left: 127px;top: -212px;}
.main-dashboard .new-image li:nth-child(5) {right: -22px;top: -160px;}
.main-dashboard .new-image li:nth-child(6) {right: -105px;top: -35px;}
.main-dashboard .new-image li:nth-child(7) {right: -115px;top: 75px;}

.main-dashboard .text li:nth-child(5) a {display: block;transform: rotate(180deg) translate(60px, 0px);}
.main-dashboard .text li:nth-child(6) a {display: block;transform: rotate(180deg) translate(18px, 0px);}
.main-dashboard .text li:nth-child(7) a {display: block;transform: rotate(180deg) translate(20px, 0px);}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
      
    </asp:ScriptManager>
    <div class="row fixed-header">
        <div class="col-sm-12 col-md-12">
            <div class="page-header-container fixed-padding">
                <h4 class="page-header">Home</h4>
            </div>
        </div>
    </div>
    <div class="fixed-container fixed-padding main-dash">
        <div class="row">
            <div class="col-md-12 col-xs-12 col-sm-12">
                <div class="main-dashboard" style="display:none;">

                    <ul class="text">
                        <li><a href="#">Cattle</a></li>
                        <li><a href="#">Micro Business</a></li>
                        <li><a href="#">Micro Health</a></li>
                        <li><a href="#">Micro Household</a></li>
                        <li><a href="#">Micro PA</a></li>
                        <li><a href="#">Serious Illness</a></li>
                        <li><a href="#">Tarkari Bari</a></li>
                    </ul>

                    
                    <ul class="new-image">
                        <li><a href="#"><img src="Design/img1/dashImg/cattle.png" /></a></li>
                        <li><a href="#"><img src="Design/img1/dashImg/business.png" /></a></li>
                        <li><a href="#"><img src="Design/img1/dashImg/health.png" /></a></li>
                        <li><a href="#"><img src="Design/img1/dashImg/household.png" /></a></li>
                        <li><a href="#"><img src="Design/img1/dashImg/accident.png" /></a></li>
                        <li><a href="#"><img src="Design/img1/dashImg/illness.png" /></a></li>
                        <li><a href="#"><img src="Design/img1/dashImg/bari.png" /></a></li>
                    </ul>
                    
                <img src="Design/img1/dashImg/insurance-dash.png" class="main-image" />
                </div>
            </div>

            </div>
        </div>
</asp:Content>

