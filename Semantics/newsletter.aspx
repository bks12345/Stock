<%@ Page Title="" Language="C#" MasterPageFile="~/Ensure/main.Master" AutoEventWireup="true" CodeBehind="newsletter.aspx.cs" Inherits="Stock.newsletter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    
.news-header { padding:15px 0; background:#337ab7; color:#ffffff; font-family: Arial; font-weight:bold;}
.news-header > a { display:block; margin-bottom:5px;}
.news-address { margin-bottom:0;}
.news-header img { border: 1px solid #ffffff; padding: 5px; border-radius: 5px;}
/*.news-content { background-color: #52b152; text-align:center; margin-top:20px; -webkit-box-shadow: 0 5px 10px 0 #000000; box-shadow: 0 5px 10px 0 #000000;}*/
.news-content { text-align:center; padding:10px;}
.news-content .caption {color:#ffffff!important;}
.news-bimage { margin-bottom: 10px;}
.news-footer {background-color: #52b152; padding:10px 0; min-height:80px; color:#000000;}
.copyright { padding-top:20px;}
.copyright > a {color:#ffffff;}
.news-footer .social-icon li { float:left; list-style:none;}
.news-footer .social-icon li a {display:inline-block; color:rgba(0,0,0,0.6); font-size:20px; margin:0 10px;}

</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-8">
                <div class="well text-center well-sm">
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="news-header">
                                <a href="#">
                                    <img src="Design/img1/arhant_logo.png" /></a>
                                <p class="news-address">
                                    Address: Thaiba, Lalitpur Nepal</p>
                                <p>
                                    Telephone: 123-4567890</p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <%--<div class="thumbnail news-content">
                          
                            <img src="..." alt"" />
                            <div class="caption">
                                <h3>
                                    Heading</h3>
                                <p>
                                    Content goes here</p>
                                <p>
                                    <a href="#" class="btn btn-primary" role="button">Button</a> <a href="#" class="btn btn-default"
                                        role="button">Button</a></p>
                            </div>
                        </div>--%>
                            <div class="thumbnail news-content">
                                <strong>Hey Sunil,</strong>
                                <p>
                                    Here's some of our latest, hottest offers on website design recommended for you!
                                    Snap them before price starts shooting up!</p>
                                <img src="Design/img1/banner.jpg" alt="images" class="news-bimage" />
                                <p>  Here's some of our latest, hottest offers on website design recommended for you!
                                    Snap them before price starts shooting up!  Here's some of our latest, hottest offers on website design recommended for you!
                                    Snap them before price starts shooting up!  Here's some of our latest, hottest offers on website design recommended for you!
                                    Snap them before price starts shooting up!  Here's some of our latest, hottest offers on website design recommended for you!
                                    Snap them before price starts shooting up!</p>
                                     
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-md-4">
                            <div class="thumbnail">
                                <img src="Design/img1/policyimg3.png" alt="images" />
                                <div class="caption">
                                    <h3>
                                        Heading</h3>
                                    <p>
                                        Content goes here</p>
                                    <p>
                                        <a href="#" class="btn btn-primary" role="button">Button</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-4">
                            <div class="thumbnail">
                                <img src="Design/img1/policyimg2.png" alt="images" />
                                <div class="caption">
                                    <h3>
                                        Heading</h3>
                                    <p>
                                        Content goes here</p>
                                    <p>
                                        <a href="#" class="btn btn-primary" role="button">Button</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-4">
                            <div class="thumbnail">
                                <img src="Design/img1/policyimg1.png" alt="images" />
                                <div class="caption">
                                    <h3>
                                        Heading</h3>
                                    <p>
                                        Content goes here</p>
                                    <p>
                                        <a href="#" class="btn btn-primary" role="button">Button</a>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12">
                            <div class="news-footer">
                                <div class="row">
                                    <div class="col-sm-4 col-sm-offset-4">
                                        <ul class="social-icon">
                                            <li><a href="#"><span class="fa fa-facebook-square"></span></a></li>
                                            <li><a href="#"><span class="fa fa-twitter-square"></span></a></li>
                                            <li><a href="#"><span class="fa fa-google-plus-square"></span></a></li>
                                            <li><a href="#"><span class="fa fa-linkedin-square"></span></a></li>
                                        </ul>
                                    </div>
                                </div>
                                <p class="copyright">
                                    © 2015 <a href="#">Arhant Solution.</a> All Right Reserved</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
