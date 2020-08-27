<%@ Page Language="C#" MasterPageFile="~/Ensure/main.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Stock.Ensure.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #search-loading {
            left: 19%;
            top: 40%;
        }

        .fixed-container {
            margin: 0 !important;
        }

        h1 {
            margin: 0 0 10px;
            text-transform: uppercase;
            font-weight: bold;
            font-size: 24px;
            line-height: 26px;
        }
        h2 {
            background: #f47721;
            color: #fff;
            margin: 0;
            padding: 10px 0;
            margin: 0 0 10px; 
        }
        h3 {
            margin: 0 0 10px;
            padding: 0 0 5px;
            font-size: 20px;
            line-height: 22px;
            position: relative;
        }
        h3:after {
            position: absolute;
            content: '';
            left: 0;
            bottom: 0;
            height: 2px;
            width: 150px;
            background: #e55207;
        }
        p,li,span {
            font-size: 15px;
            line-height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Design/js1/FixFocus.min.js" />
        </Scripts>
    </asp:ScriptManager>
    <div class="fixed-container">
        <div class="row cont-pad-top1">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="col-md-12 col-sm-12 col-xs-12" style="margin: 0 0 20px;">
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <h1>About Us</h1>
                            <p>Incepted in 2008, Arhant Solution is one of the leading IT companies based in Kathmandu, Nepal. 
                                It is a subsidiary of ICTC Group of companies 
                                established with the objective to provide innovating and cutting edge solutions web applicaiton development.</p>
                            <h3>Our Products</h3
                            <ul>
                                <li>IEnsure (Web Based Insurance Application)</li>
                                <li>Ensure (Desktop Based Insurance Application)</li>
                                <%--<li>Microinsurance</li>
                                <li>Sworojgar</li>--%>
                            </ul>
                        </div>
                        <div class="col-md-6 col-sm-6 col-xs-12 text-center" style="margin: 0 0 15px;">
                            <img src="Design/img1/Arhant.jpg" alt="Arhant Solution"/>
                            <h4>(Version 1.0)</h4>
                        </div>
                    </div>
                    
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="col-md-12 col-sm-12 col-xs-12 text-center">
                            <h2>Contact Us</h2>
                        </div>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <h3>Location</h3>
                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d525.0606976778374!2d85.32217138827811!3d27.711936064620804!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x39eb1906b94c8d8f%3A0x32be7920c9440541!2sICTC+Pvt.+Ltd.!5e0!3m2!1sen!2snp!4v1538459029076" 
                                width="100%" height="200" frameborder="0" style="border:0"></iframe>
                        </div>
                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <h3>Contact Details</h3>
                            <p>Hattisar-Kathmandu, Nepal</p>
                            <span>014444864, 014444868</span>
                        </div>
                    </div>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <script src="/Design/js1/jquery.1.11.1.min.js" type="text/javascript"></script>
</asp:Content>
