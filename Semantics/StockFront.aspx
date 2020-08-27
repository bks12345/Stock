<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockFront.aspx.cs" Inherits="Stock.StockFront" %>

<!DOCTYPE html>
<!--[if IE 8]> <html lang="en" class="ie8 no-js"> <![endif]-->
<!--[if IE 9]> <html lang="en" class="ie9 no-js"> <![endif]-->
<!--[if !IE]><!-->
<html xmlns="http://www.w3.org/1999/xhtml" lang="en" class="no-js">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>SEMANTICS</title>
    <!-- Bootstrap -->
    <link href="Design/css1/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Design/css1/font-awesome.css" rel="stylesheet" type="text/css" />
    <%--<link href="Design/css1/sticky-table.css" rel="stylesheet" type="text/css" />--%>
    <link href="Design/img1/fav-icon.png" rel="shortcut icon" />
    <%--<link id="themeStyle" href="Design/css1/layout.css" rel="stylesheet" type="text/css" />--%>
    <%--<link href="Design/css1/themes/blue.css" rel="stylesheet" type="text/css" />--%>
    <link href="Design/css1/layout.css" rel="stylesheet" type="text/css" />
    <link id="lnkNepaliFont" href="Design/css1/Fontasy.css" runat="server" rel="stylesheet" />
    <link href="Design/css1/responsive-media-query.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
      <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->


    <%--<SCRIPT type="text/javascript">
    window.history.forward();Claim Advance Payment
    function noBack() { window.history.forward(); }
</SCRIPT>--%>

    <style>
        h3 {
            margin: 0;
            padding: 5px 0;
            background: #00c9ff;
        }

            h3 a {
                font-size: 14px;
                padding: 10px;
                display: block;
            }

                h3 a:hover {
                    text-decoration: none;
                }

            h3 .hvr-push {
                display: block;
                animation: none !important;
            }

        .logged:before {
            display: block;
            float: left;
            position: relative;
            top: -6px;
            content: "";
            height: 32px;
            width: 32px;
            margin-right: 8px;
        }

        .mp-level.sidebar {
            margin: 40px 0 0;
        }
    </style>
</head>
<body onunload="HandleClose();">
    <form runat="server">
        <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ScriptManager>
        <nav class="navbar navbar-fixed-top navbar-ensure" role="navigation">
            <div class="container-fluid">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand ensure-logo" href="#">
                        <asp:Image ID="Image1" runat="server"></asp:Image>
                        <%--<img src="Design/img1/arhant_logo.png" alt="Arhant Solution"/>--%>
                    </a>

                </div>
                <div id="WelcomeUser" style="margin: -8px 0 0 65px; width: 30%; float: left;">
                    <h5>
                        <asp:Label ID="lblCurrentUsername" runat="server" Text="" ForeColor="#000"></asp:Label>
                    </h5>
                </div>

                <%--<div id="Reload1">reload</div>--%>
                <div id="navbar" class="navbar-collapse collapse">

                    <ul class="nav navbar-nav navbar-right nav-pills">


                        <li>
                            <div class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">
                                    <img src="Design/img1/hash-icon.png" class="google_icon" />
                                </a>
                                <div class="dropdown-menu shortcut-drop " aria-labelledby="dLabel">
                                    <ul class="shortcut-drop-inner ">
                                        <li><a id="a162" runat="server" class="shortcuts shortcuts1 mp-ref" href="Ensure/Process/UnderwritingEX/frmWizA.aspx"
                                            target="target" title="Issue Policy"><span class="description">Policy Issue</span></a></li>
                                        <li><a id="a177" runat="server" class="shortcuts shortcuts6 mp-ref" href="Ensure/SearchEngine/DebitSearchEngine.aspx" target="target"
                                            title="Proforma search"><span class="description">Proforma Search</span></a></li>
                                        <li><a id="a172" runat="server" class="shortcuts shortcuts3 mp-ref" href="Ensure/SearchEngine/NewPolicySearch.aspx"
                                            target="target" title="Policy Search"><span class="description">Policy Search</span></a></li>
                                        <li><a id="a167" runat="server" class="shortcuts shortcuts2 mp-ref" href="Ensure/Process/Collection/NewCollection.aspx"
                                            target="target" title="Premium Collection"><span class="description">Collection</span></a></li>
                                        <li><a id="a182" runat="server" class="shortcuts shortcuts5 mp-ref" href="Ensure/SearchEngine/collectionsearch.aspx"
                                            target="target" title="Collection Search"><span class="description">Collection Search</span></a></li>
                                        <li><a id="a176" runat="server" class="shortcuts shortcuts7 mp-ref" href="Ensure/Setup/Underwriting/UW/PremiumCalculator.aspx"
                                            target="target" title="Premium Calculator"><span class="description">Premium Calculator</span></a></li>
                                        <li><a id="a239" runat="server" class="shortcuts shortcuts4 mp-ref" href="Ensure/Process/Claim/AddClaim.aspx"
                                            target="target" title="Claim Registration"><span class="description">Claim Registration</span></a></li>
                                        <li><a id="a244" runat="server" class="shortcuts shortcuts8 mp-ref" href="Ensure/SearchEngine/ClaimSearch.aspx"
                                            target="target" title="Claim Search"><span class="description">Claim Search</span></a></li>
                                        <li><a id="a263" runat="server" class="shortcuts shortcuts9 mp-ref" href="Ensure/Process/Claim/ClaimAssignment.aspx"
                                            target="target" title="Claim Assignment"><span class="description">Claim Assignment</span></a></li>
                                        <li><a id="a293" runat="server" class="shortcuts shortcuts10 mp-ref" href="Ensure/Process/Account/voucher-listing.aspx"
                                            target="target" title="Voucher Listing"><span class="description">Voucher Listing</span></a></li>
                                        <li><a id="a294" runat="server" class="shortcuts shortcuts11 mp-ref" href="Ensure/Process/Account/ledger-report.aspx"
                                            target="target" title="Ledger Report"><span class="description">Ledger Report</span></a></li>
                                        <li><a id="a295" runat="server" class="shortcuts shortcuts12 mp-ref" href="Ensure/Process/Account/trial-balance.aspx"
                                            target="target" title="Trial Balance"><span class="description">Trial Balance</span></a></li>
                                    </ul>
                                </div>
                            </div>
                        </li>
                        <li class="news_notification">
                            <%-- <a href="#" class="insu-icon hvr-buzz">--%>
                            <a href="#" class="insu-icon bell-icon">
                                <img alt="dashboard" src="Design/img1/bell1.png" title="Dashboard" class="notification-icon open-notification" />
                            </a>
                            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                <ContentTemplate>
                                    <a href="#" class="badge top-notification top-notification2 open-notification1">
                                        <asp:Label ID="lblNotificationCnt" runat="server" Text="0"></asp:Label>
                                    </a>
                                  <%--  <asp:Button ID="btnhidden" runat="server" OnClick="btnhidden_OnClick" Style="display: none" TabIndex="58" />--%>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </li>

                        <li>

                            <a href="StockFront.aspx">
                                <img alt="dashboard" src="Design/img1/dashboard.png" title="Home"></a>

                        </li>

                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">
                                <asp:Image ID="imgUser" class="user-icon" runat="server" Height="35px" Width="35px"></asp:Image>
                                <%--<span class="user-icon"></span><asp:Label ID="lblUser" runat="server"></asp:Label>--%>
                            </a>
                            <ul class="dropdown-menu account-drop" role="menu">
                                <li><a href="#"><span class="fa fa-user"></span>Profile</a></li>
                                <li><a href="Ensure/User/changepassword.aspx" target="target"><span class="fa fa-cog"></span>Change Password</a></li>
                                <li>
                                    <asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click"><span class="fa fa-power-off"></span>Log Out</asp:LinkButton>

                                    <asp:Button ID="btnLogout" runat="server" Text="Show" Style="display: none" OnClick="btnLogout_Click" />
                                </li>
                                <%--<li><a href="#"><span class="fa fa-power-off"></span>Log Out</a></li>--%>
                                <li class="divider"></li>
                                <li class="dropdown-header">Nav header</li>
                                <li><a href="#">Separated link</a></li>
                                <li><a href="#">One more separated link</a></li>

                            </ul>
                        </li>
                    </ul>
                    <%--<form  class="form-inline navbar-form <%--navbar-right navbar-left sdiv-top">--%>


                    <%-- for search shortcut --%>
                    <div class="form-group col-sm-3 col-md-2">
                        <div class="input-group top-sdiv" style="display: none;">
                            <input type="text" class="form-control top-search" id="exampleInputAmount" placeholder="Search...">
                            <div class="input-group-addon">
                                <a href="#">
                                    <img src="../../../Design/img1/search-icon-blue.png" /></a>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </nav>


        <p class="pwexpire" style="position: absolute; top: 30px; left: 15vw; z-index: 9999;">
            <asp:Label ID="lblAlert" runat="server" CssClass="blink" ForeColor="Red"></asp:Label>
        </p>

        <i id="right-navigator" class="right-info-navigator lft-arrow rft-arrow" title="Menu Toggle"></i>

        <i id="right-arrow" class="right-info-navigator arrow-right-bar"></i>

        <div class="page-container">
            <div class="page-sidebar navbar-collapse sidebar collapsable sidebar12">
                <span class="mp-ref default" style="background: #00c9ff; font-size: 14px; padding: 10px; display: block;">
                    <%--<asp:Image ID="ImgUser2" class="user-icon" runat="server" Height="35px" Width="35px"></asp:Image>--%>
                    <asp:Label ID="lblUserName" runat="server" ToolTip=" Login User Name " Font-Bold="true"></asp:Label>
                </span>

                <asp:Panel ID="pnlMenus" runat="server">
                    <ul id="mp-menu" class="nav nav-sidebar">
                        <li><a class="mp-ref default email " href="#">Stock</a>
                            <div class="mp-level sidebar">
                                <h4 class="icons-display default email"></h4>
                                <a class="mp-back" href="#">back</a>
                                <ul class="nav nav-sidebar">
                                    <li><a id="a2" runat="server" class="icons-display mp-ref" href="Stock/Process/PurchaseEntry.aspx" target="target">Purchase Entry</a></li>
                                    <li><a id="a4" runat="server" class="icons-display mp-ref" href="Stock/Process/SalesEntry.aspx" target="target">Sales Entry</a></li>
                                   
                                </ul>
                            </div>
                        </li>
                        <li><a class="mp-ref default account " href="#">Set Up</a>
                            <div class="mp-level sidebar">
                                <h4 class="icons-display default email"></h4>
                                <a class="mp-back" href="#">back</a>
                                <ul class="nav nav-sidebar">
                                    <li><a id="a17" runat="server" class="icons-display mp-ref" href="Stock/Setup/Product.aspx" target="target">Make Product</a></li>
                                    <li><a id="a19" runat="server" class="icons-display mp-ref" href="Ensure/Email/addcontact.aspx" target="target">Branch</a></li>
                                </ul>
                            </div>
                        </li>

                       

                        <li><a class="mp-ref default account " href="#">Account</a>
                            <div class="mp-level sidebar">
                                <h4 class="icons-display default account"></h4>
                                <a class="mp-back" href="#">back</a>
                                <ul class="nav nav-sidebar">
                                    <li><a id="a48" runat="server" class="icons-display mp-ref" href="Ensure/Process/Account/chart_of_account.aspx"
                                        target="target">Account Chart Definition</a>
                                    </li>
                                    <li><a id="a49" runat="server" class="icons-display mp-ref" href="Ensure/Process/Account/account_head-creation.aspx"
                                        target="target">Account Head Creation</a>
                                    </li>
                                    <%--<li><a id="a52" runat="server"   class="icons-display mp-ref" href="Ensure/Process/Account/opening_transfer.aspx"
                                        target="target">Opening Balance Transfer</a>
                                    </li>--%>
                                    <li><a id="a237" runat="server" class="icons-display mp-ref" href="Ensure/Process/Account/OpeningTransfer_New.aspx"
                                        target="target">Opening Balance Transfer</a>
                                    </li>
                                    <li><a id="a50" runat="server" class="icons-display mp-ref" href="Ensure/Process/Account/normal-voucher-entry.aspx"
                                        target="target">Normal Voucher Entry</a>
                                    </li>
                                    <li><a id="a129" runat="server" class="icons-display mp-ref" href="Ensure/Process/Account/PurchaseEntry_New.aspx"
                                        target="target">Purchase Entry</a> </li>
                                    <li><a id="a36" runat="server" class="icons-display mp-ref" href="Ensure/Process/Collection/disbursement.aspx"
                                        target="target">Disbursement</a>
                                    </li>


                                    <li><a class="icons-display mp-ref " href="#">Setup</a>
                                        <div class="mp-level sidebar">
                                            <h4 class="icons-display default"></h4>
                                            <a class="mp-back" href="#">back</a>
                                            <ul class="nav nav-sidebar">
                                                <li><a id="a54" runat="server" class="icons-display mp-ref" href="Ensure/Setup/Account/voucher-type.aspx"
                                                    target="target">Voucher Type</a>
                                                </li>
                                                <li><a id="a38" runat="server" class="icons-display mp-ref" href="Ensure/Setup/Account/DisbursementType.aspx"
                                                    target="target">Disbursement Type</a>
                                                </li>
                                                <li><a id="a55" runat="server" class="icons-display mp-ref" href="Ensure/Setup/Account/account-type-setting.aspx"
                                                    target="target">Account Type Setting</a>
                                                </li>
                                                <li><a id="a56" runat="server" class="icons-display mp-ref" href="Ensure/Setup/Account/TransactionType.aspx"
                                                    target="target">Transaction Type</a>
                                                </li>
                                                <li><a id="a57" runat="server" class="icons-display mp-ref" href="Ensure/Setup/Account/account-type-mapping.aspx"
                                                    target="target">Account Type Mapping</a>
                                                </li>
                                                <li><a id="a58" runat="server" class="icons-display mp-ref" href="Ensure/Setup/Account/VendorName.aspx" target="target">Vendor Setup</a>
                                                </li>
                                                <li><a id="a120" runat="server" class="icons-display mp-ref" href="~/Ensure/Setup/Account/PurchaseItems.aspx"
                                                    target="target">Purchase Items</a>
                                                </li>
                                                <li><a id="a156" runat="server" class="icons-display mp-ref" href="Ensure/Process/Account/AccountHeadMapping.aspx"
                                                    target="target">Account Head Mapping</a> </li>

                                            </ul>
                                        </div>
                                    </li>
                                    <li><a class="icons-display mp-ref " href="#">Search/Reports</a>
                                        <div class="mp-level sidebar">
                                            <h4 class="icons-display default"></h4>
                                            <a class="mp-back" href="#">back</a>
                                            <ul class="nav nav-sidebar">
                                                <li><a id="a63" runat="server" class="icons-display mp-ref" href="Ensure/Process/Account/ledger-report.aspx"
                                                    target="target">Ledger Report</a>
                                                </li>
                                                <li><a id="a64" runat="server" class="icons-display mp-ref" href="Ensure/Process/Account/trial-balance.aspx"
                                                    target="target">Trial Balance</a>
                                                </li>
                                                <li><a id="a66" runat="server" class="icons-display mp-ref" href="Ensure/Process/Account/voucher-listing.aspx"
                                                    target="target">Voucher Listing</a>
                                                </li>
                                                <li><a id="a151" runat="server" class="icons-display mp-ref" href="Ensure/Process/Account/AccountSearch.aspx"
                                                    target="target">Account Search</a>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>

                                </ul>
                            </div>
                        </li>
                        <li><a class="mp-ref default searchEngine " href="#">Search Engine</a>
                            <div class="mp-level sidebar">
                                <h4 class="icons-display default searchEngine"></h4>
                                <a class="mp-back" href="#">back</a>
                                <ul class="nav nav-sidebar">

                                    <li><a id="a32" runat="server" visible="true" class="icons-display mp-ref" href="Stock/SearchEngine/PurchaseSearch.aspx"
                                        target="target">Purchase Search</a>
                                    </li>
                                    <li><a id="a83" runat="server" class="icons-display mp-ref" href="Stock/SearchEngine/SalesSearch.aspx"
                                        target="target">Sales Search</a>
                                    </li>
                                    <li><a id="a86" runat="server" class="icons-display mp-ref" href="Ensure/Process/Account/voucher-listing.aspx"
                                        target="target">Voucher Listing</a>
                                    </li>
                                   
                                </ul>
                            </div>
                        </li>
                        <li><a class="mp-ref default reports " href="#">Reports Search</a>
                            <div class="mp-level sidebar">
                                <h4 class="icons-display default reports"></h4>
                                <a class="mp-back" href="#">back</a>
                                <ul class="nav nav-sidebar">
                                    <li><a class="icons-display mp-ref " href="#">Setups</a>
                                        <div class="mp-level sidebar">
                                            <h4 class="icons-display default"></h4>
                                            <a class="mp-back" href="#">back</a>
                                            <ul class="nav nav-sidebar">
                                                <li><a id="a92" runat="server" href="Ensure/SearchEngine/ReportSearch/ReportSetup.aspx" target="target" class="mp-ref">Report Setup</a>
                                                </li>
                                                <li><a id="a93" runat="server" href="Ensure/SearchEngine/ReportSearch/ControlSetups.aspx" target="target"
                                                    class="mp-ref">Report Control Setup</a>
                                                </li>
                                                <li><a id="a94" runat="server" href="Ensure/SearchEngine/ReportSearch/MapReportControl.aspx" target="target"
                                                    class="mp-ref">Map Report Control</a>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>
                                    <li><a id="a95" runat="server" class="icons-display mp-ref" href="Ensure/SearchEngine/ReportSearch/GeneralReport.aspx"
                                        target="target">General Report</a>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li><a class="mp-ref default email " href="#">Email</a>
                            <div class="mp-level sidebar">
                                <h4 class="icons-display default email"></h4>
                                <a class="mp-back" href="#">back</a>
                                <ul class="nav nav-sidebar">
                                    <li><a id="a253" runat="server" class="icons-display mp-ref" href="Ensure/Email/emailsetting.aspx" target="target">Email Setting</a></li>
                                    <li><a id="a254" runat="server" class="icons-display mp-ref" href="Ensure/Email/addcontact.aspx" target="target">Add Contact</a></li>
                                    <li><a id="a255" runat="server" class="icons-display mp-ref" href="Ensure/Email/sendemail.aspx" target="target">Send Email</a></li>
                                    <li><a id="a256" runat="server" class="icons-display mp-ref" href="Ensure/Email/emailhistory.aspx" target="target">Email History</a></li>
                                </ul>
                            </div>
                        </li>
                        <li><a id="a37" runat="server" visible="true" class="mp-ref default about " href="AboutUs.aspx" target="_blank">About Us</a>
                        </li>
                    </ul>
                    <div class="short-icons" style="display: none;">
                        <h4>Shortcuts</h4>
                        <ul>
                            <li><a id="a257" runat="server" class="shortcuts shortcuts1" href="Ensure/Process/UnderwritingEX/frmWizA.aspx"
                                target="target" title="Issue Policy"></a></li>
                            <li><a id="a258" runat="server" class="shortcuts shortcuts2" href="Ensure/Process/Collection/NewCollection.aspx"
                                target="target" title="Premium Collection"></a></li>
                            <li><a id="a259" runat="server" class="shortcuts shortcuts3" href="Ensure/SearchEngine/NewPolicySearch.aspx"
                                target="target" title="Policy Search"></a></li>
                            <li><a id="a260" runat="server" class="shortcuts shortcuts4" href="Ensure/SearchEngine/ClaimSearch.aspx"
                                target="target" title="Claim Search"></a></li>
                            <li><a id="a261" runat="server" class="shortcuts shortcuts6" href="Ensure/SearchEngine/DebitSearchEngine.aspx" target="target"
                                title="Debit advice search"></a></li>
                            <li><a id="a262" runat="server" class="shortcuts shortcuts5" href="Ensure/SearchEngine/collectionsearch.aspx"
                                target="target" title="Collection Search"></a></li>
                            <li><a class="shortcuts shortcuts6" href="Ensure/Process/issuepolicysingle/IssuePolicySingle.aspx" target="target"
                                title="Issuepolicysigle"></a></li>
                            <li><a class="shortcuts shortcuts6" href="Ensure/Process/issuepolicysingle/IssuePolicySingleUser.aspx" target="target"
                                title="IssuepolicysigleUser"></a></li>
                            <li><a class="shortcuts shortcuts6" href="linkpage1.aspx" target="target"
                                title="LinkPage"></a></li>
                            <li><a class="shortcuts shortcuts6" href="GalleryPage.aspx" target="target"
                                title="LinkPage"></a></li>
                        </ul>
                    </div>
                </asp:Panel>
            </div>


            <div class="modal fade" id="PolicyModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
                data-backdrop="static" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close" onclick="closePopup();">
                                <span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblType" runat="server" Text="Enter Policy No."></asp:Label>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-4 col-sm-4 col-xs-4 text-left">
                                    <asp:Label ID="Label28" Text="Policy No." runat="server" CssClass="control-label"></asp:Label>
                                </div>
                                <div class="col-md-8 col-sm-8 col-xs-8">
                                    <asp:TextBox ID="txtPolicyNo" CssClass="form-control" runat="server">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Label ID="lblNote" runat="server" CssClass="pull-left" Font-Size="Small" ForeColor="Red">
                            </asp:Label>
                            <asp:Button ID="btnOk_Edit" CssClass="btn btn-primary" runat="server" Text="Ok" OnClientClick="return ValidatePopUp();" OnClick="btnOk_Edit_Click" />
                            <button type="button" class="btn btn-primary" data-dismiss="modal" aria-label="Close"
                                onclick="closePopup();">
                                <span aria-hidden="true">Cancel</span></button>
                        </div>
                        <%--</ContentTemplate>
                                            </asp:UpdatePanel>--%>
                    </div>
                </div>
            </div>
            <iframe id="pageContainer" class="page-wrapper" name="target" src="DashboardNew.aspx" runat="server"
                frameborder="0"></iframe>
            <div class="right-bar">
                <div class="right-sidebar-inner">
                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingOne">
                                <h4 class="panel-title">
                                    <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                        <span class="fa fa-calendar"></span>Latest News and Events
                                    </a>
                                </h4>
                            </div>
                            <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                <div class="panel-body">
                                    <table id="tbl">
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingTwo">
                                <h4 class="panel-title">
                                    <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo" style="display: inline-block;">
                                        <span class="fa fa-pencil-square-o"></span>PPW Notifications
                                    </a>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <span>
                                                <asp:ImageButton ID="imgRefresh" runat="server" OnClick="imgRefresh_Click" ImageUrl="~/Design/img1/refresh.png" />
                                            </span>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </h4>
                            </div>
                            <asp:HiddenField ID="hdnClaimTxt" runat="server" />
                            <asp:HiddenField ID="hdnUpdatePnlId" runat="server" />
                            <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                <div class="panel-body">
                                    <table id="tbl1">
                                    </table>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading" role="tab" id="headingThree">
                                <h4 class="panel-title">
                                    <a id="lnkOnlineUser" class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree" style="display: inline-block;"
                                        onclick="ShowOnlineUsers();">
                                        <span class="fa fa-circle online-icon"></span>Online Team Member
                                    </a>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>

                                            <span>
                                                <asp:ImageButton ID="imgRefreshMember" runat="server" ImageUrl="~/Design/img1/refresh.png" />
                                            </span>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </h4>
                            </div>
                            <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                                <div class="panel-body">
                                    <table id="tbluser">
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdnUrl" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="hdnNewEventId" runat="server" />
                <asp:HiddenField ID="hdnNewEventReadId" runat="server" />
                <asp:HiddenField ID="hdnDate" runat="server" />
                <asp:HiddenField ID="hdnUserId" runat="server" />
                <asp:HiddenField ID="hdnDocumentid" runat="server" />
                <asp:HiddenField ID="hdnFacId" runat="server" />
                <asp:HiddenField ID="hdnDepartmentid" runat="server" />
                <asp:HiddenField ID="hdnNotificationNo" runat="server" />

                <asp:Button ID="btnShow" runat="server" Text="showNCD" OnClick="btnShow_Click"
                    Style="display: none" CausesValidation="False" />
                <asp:Button ID="btnPrint" runat="server" Text="showNCD" OnClick="btnPrint_Click"
                    Style="display: none" CausesValidation="False" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <!-- Modal -->
        <div class="modal fade" id="NewsModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" onclick="closepopup()" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">News and Events</h4>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel ID="UPNL1" runat="server">
                            <ContentTemplate>
                                <div class="row cont-pad-top1">
                                    <div class="col-md-12 col-sm-12 col-xs-12">
                                        <div class="form-group">
                                            <asp:Label ID="lblClassCode" runat="server" Text="Posted by" CssClass=" col-md-4 col-sm-4 col-xs-4 control-label"></asp:Label>
                                            <div class=" col-md-8 col-sm-8 col-xs-8">
                                                <asp:Label ID="lblPostedBy" runat="server" Text="" CssClass="control-label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="Label2" runat="server" Text="Department" CssClass=" col-md-4 col-sm-4 col-xs-4 control-label"></asp:Label>
                                            <div class=" col-md-8 col-sm-8 col-xs-8">
                                                <asp:Label ID="lblDept" runat="server" Text="" CssClass="control-label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="Label3" runat="server" Text="Date" CssClass=" col-md-4 col-sm-4 col-xs-4 control-label"></asp:Label>
                                            <div class=" col-md-8 col-sm-8 col-xs-8">
                                                <asp:Label ID="lblDate" runat="server" Text="" CssClass="control-label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="Label4" runat="server" Text="Subject" CssClass=" col-md-4 col-sm-4 col-xs-4 control-label"></asp:Label>
                                            <div class=" col-md-8 col-sm-8 col-xs-8">
                                                <asp:Label ID="lblSubject" runat="server" Text="" CssClass="control-label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <asp:Label ID="Label5" runat="server" Text="Message" CssClass=" col-md-4 col-sm-4 col-xs-4 control-label"></asp:Label>
                                            <div class=" col-md-8 col-sm-8 col-xs-8">
                                                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="control-label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class=" col-md-12 col-sm-12 col-xs-12 text-right">
                                               <%-- <asp:Button ID="btnOk" CssClass="btn btn-primary" runat="server" Text="OK" OnClick="btnOk_Click" />--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>


        <div id="divusers" class="users">
        </div>


        <!-- for pre-loading -->
        <div id="target-loading">
            <img alt="image-loader" src="Design/img1/ajax-loader.gif">
        </div>
        <div id="empty">
        </div>
        <!-- /pre-loading -->



        <script src="Design/js1/jquery.1.11.1.min.js" type="text/javascript"></script>
        <script src="Scripts/jquery.signalR-2.2.2.js"></script>
        <script src="Scripts/jquery.signalR-2.2.2.min.js"></script>
        <script src="/signalR/hubs"></script>
        <script type="text/javascript">
            
            

            function ValidatePopUp() {//compulsary
                var oForm1 = document.forms["form1"]; //compulsary
                var txtPolicyNo = oForm1["ContentPlaceHolder1_txtPolicyNo"];
                if (!Validate(txtPolicyNo, false)) return false;
                return true; //compulsary
            } //compulsary


            $(function () {
               <%-- var Companyid = '<%=Ensure.BllDalClasses.BllClass.Common.ClsCommon.CompanyId%>';
                var ShowConnectedUsers = '<%=Ensure.BllDalClasses.BllClass.Common.ClsCommon.ConnectedUsers%>';
                var IsAdmin = '<%=Ensure.BllDalClasses.BllClass.Common.ClsCommon.IsAdmin%>'.toLowerCase();

                FxRegisterNotification();
                getData();//fetching news & events--%>

            });
            function ShowOnlineUsers() {
                if (document.getElementById('lnkOnlineUser').className != "collapsed")
                    HideOnlineUsers();
                else {
                    ShowConnectedUsers = 1;
                    //proxy created on the fly
                    var job = $.connection.myHub;

                    //registerClientMethods(job, ShowConnectedUsers);

                    //Declare a function on the job hub so the server can invoke it
                    job.client.displayStatus = function () {
                        //getData();
                        //getPPWNotifications();
                    };
                    //start the connection
                    $.connection.hub.start();
                    $.connection.hub.start().done(function () {
                        FxGetUserName(job);
                    });
                }
            }
            function HideOnlineUsers() {
                ShowConnectedUsers = 0;
                $.connection.hub.stop();
            }
            function DisconnectOnlineUsers() {
                Hub.server.getAllActiveConnections().done(function (connections) {
                    $.map(connections, function (itemConnected) {
                        $("#tbluser").append("<tr><td >" + itemConnected.UserName + "</td></tr>");
                    });
                });
            }
            function FxGetUserName(Hub) {
                $("#tbluser").empty();
                $.ajax({
                    url: 'SemanticsFront.aspx/GetUserName',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    type: "POST",
                    success: function (data) {
                        var obj = JSON.parse(data.d);
                        $.each(obj, function (i, item) {
                            Hub.server.connect(item.UName, item.UID);


                            Hub.server.getAllActiveConnections().done(function (connections) {
                                $.map(connections, function (itemConnected) {
                                    $("#tbluser").append("<tr><td >" + itemConnected.UserName + "</td></tr>");
                                });
                            });

                            //var disc = $('<div class="Welcome_User"> Welcome "' + item.UName + '" </div>');
                            //$(disc).hide();
                            //$('#WelcomeUser').prepend(disc);
                            //$(disc).fadeIn(200).delay(2000).fadeOut(200);
                        });
                    }
                });
            }
            function registerClientMethods(chatHub, ShowConnectedUsers) {

                // Calls when user successfully logged in
                chatHub.client.onConnected = function (id, userName, allUsers, messages) {

                    // Add All Users
                    if (ShowConnectedUsers == 1) {
                        for (i = 0; i < allUsers.length; i++) {
                            AddUser(chatHub, allUsers[i].ConnectionId, allUsers[i].UserName);
                        }
                    }
                }

                // On New User Connected
                chatHub.client.onNewUserConnected = function (id, name) {
                    if (ShowConnectedUsers == 1) {
                        AddUser(chatHub, id, name);
                    }
                }

                // On User Disconnected
                chatHub.client.onUserDisconnected = function (id, userName, allUsers) {
                    //alert('User disconnected : ' + userName);
                    $("table[id$='tbluser']").html("");

                    //alert(allUsers.length);
                    if (ShowConnectedUsers == 1) {
                        for (i = 0; i < allUsers.length; i++) {
                            AddUser(chatHub, allUsers[i].ConnectionId, allUsers[i].UserName);
                        }
                    }
                    /*;*/
                    /* var disc = $('<div class="disconnect">"' + userName + '" logged off.</div>');
 
                     $(disc).hide();
                     $('#divusers').prepend(disc);
                     $(disc).fadeIn(200).delay(2000).fadeOut(200);*/
                }

            }

            //<img class="online-image" src="Design/img1/dash-user.jpg" alt="...">

            function AddUser(chatHub, id, name) {
                $("#tbluser").append("<tr><td >"
                         + name + "</td></tr>"
                         );

            }
            function FxRegisterNotification() {
                //var $tbl = $('#tbl');
                //$("#contentHolder").empty();
                $.ajax({
                    url: 'SemanticsFront.aspx/FxRegisterNotification',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    type: "POST",
                    success: function (data) {

                    },
                    error: OnErrorCall
                });
                function OnErrorCall(response) {
                    alert(Error);
                    console.log(Error);
                }
            }

            function getData() {
                var $tbl = $('#tbl');
                $("#contentHolder").empty();
                $.ajax({
                    url: 'SemanticsFront.aspx/GetData',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    type: "POST",
                    success: function (data) {
                        //$("#tbl").removeData();
                        $("#tbl").find("td").text("");
                        if (data.d.length > 0) {
                            //alert('before json' +  data.d.length);
                            var obj = JSON.parse(data.d);
                            document.getElementById("<%=hdnNotificationNo.ClientID%>").value = obj.length;
                            <%--document.getElementById("<%=btnhidden.ClientID%>").click();--%>


                            $.each(obj, function (i, item) {
                                $("#tbl").append("<tr><td  style=\"display: none\" >"
                                      + item.readLogId + "</td><td style=\"display: none\">"
                                        + item.readLogDate + "</td><td style=\"display: none\">"
                                          + item.to_uid + "</td><td style=\"display: none\">"
                                     + item.ID + "</td><td>"
                                    + '[' + item.NewsDate + '] ' + item.USERNAME + "</td></tr>"
                                     );
                                $("#tbl").append("<tr><td  style=\"display: none\" >"
                                      + item.readLogId + "</td><td style=\"display: none\">"
                                        + item.readLogDate + "</td><td style=\"display: none\">"
                                          + item.to_uid + "</td><td style=\"display: none\">"
                                     + item.ID + "</td><td><a onclick=\"callme('" + item.ID + "','" + item.readLogId + "','" + item.readLogDate + "','" + item.to_uid + "');\">"
                                    + '....' + item.TILE + "</a></td></tr>"
                                     );
                                //$("#tbl").append("<tr><td> </td><td ><a  onclick=\"callme('" + item.ID + "','" + item.readLogId + "','" + item.readLogDate + "','" + item.to_uid + "');\">"
                                //     + item.TILE + "</a></td></tr>"
                                //     );
                            });
                        }

                    },
                    error: OnErrorCall
                });
                function OnErrorCall(response) {
                    alert(Error);
                    console.log(Error);
                }
            }
        </script>

        <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->

        <script src="Design/js1/bootstrap.min.js" type="text/javascript"></script>
        <!-- Include all compiled plugins (below), or include individual files as needed -->
        <script src="Design/js1/layout.js" type="text/javascript"></script>
        <%--<script src="Design/Scripts/ui-tree.js" type="text/javascript"></script>--%>

        <script type="text/javascript">
            //for pagecontainer src url
            function openPage(url) {
                document.getElementById("pageContainer").src = url;
            }

            $(document).ready(function () {
                $('.dropdown-toggle').dropdown();

                // for active on menu ends
                /******************************************************************************/
                // for active on menu
                $('#mp-menu li').click(function () {
                    $(this).closest('ul').children('li.active').removeClass('active');
                    $(this).addClass('active');

                });

                // for hide back and menu title
                $("#right-navigator").click(function () {

                    $(".mp-back").toggleClass("coll-heading");
                });

                $("#right-navigator").click(function () {

                    $(".default").toggleClass("coll-heading");
                });

                // for hide back and menu title ends

                // for hover effect on menu 
                $("#mp-menu .mp-ref").hover(
                      function () {
                          $(this).addClass("hvr-push");
                      }, function () {
                          $(this).removeClass("hvr-push");
                      }
                    );
                // for hover effect on menu ends

                // for inside icon on menu
                $("#mp-menu li:has(ul)").each(function () {
                    $(this).addClass("inside-icon")
                }
                    );
                // for inside icon on menu ends

                // for margin in nav-sidbar inside
                $("#mp-menu li:has(div)").each(function () {
                    $(this).addClass("inside-nav")
                }
                    );
                // for margin in nav-sidbar inside ends
                //  $('#cal').focus();
            });
            $(window).on('load', function () {
                $('#cal').focus();
            });

            // for claim search toggle
            $('.search-drop').click(function () {
                $('.search-inner').slideToggle();
            });

            $('.search-drop_New').click(function () {
                $('.search-inner_New').slideToggle();
            });

            // for claim search toggle ends

            // for claim arrow change while clicking
            $('#claim_arrow').on('click', function () {
                if ($('.search-inner').is(':visible')) {
                    $('#claim_arrow').removeClass("claim_img1").addClass('claim_img');
                }
                else {
                    $('#claim_arrow').removeClass("claim_img").addClass('claim_img1');
                };
            });


            $('#claim_arrow_New').on('click', function () {
                if ($('.search-inner_New').is(':visible')) {
                    $('#claim_arrow_New').removeClass("claim_img1").addClass('claim_img');
                }
                else {
                    $('#claim_arrow_New').removeClass("claim_img").addClass('claim_img1');
                };
            });
            // for claim arrow change while clicking

            //for right notification bar responsive at below width 768px

            $(".navbar-header > button").click(function () {
                $(".right-bar").toggleClass("top-right");
            });

            //for right notification bar responsive at below width 768px ends

            //for right bar show/hide
            $(document).ready(function () {
                $('#right-arrow').click(function () {

                    $('.right-bar').toggleClass('right-bar1');
                });
                $('.open-notification, .open-notification1').click(function () {
                    $('.right-bar').addClass('right-bar1');
                });

                $('.help').click(function () {
                    $(this).removeAttr('target');
                });

                /******   for notification bell*******/

                var prm = Sys.WebForms.PageRequestManager.getInstance();

                prm.add_endRequest(function () {
                    // re-bind your jQuery events here
                    if ($("span#lblNotificationCnt").text() == "0" || $("span#lblNotificationCnt").text() == null) {
                        // alert('0');
                        $(".insu-icon.bell-icon").removeClass("ripple-wrapper");
                    }
                    else {
                        // alert('other');
                        $(".insu-icon.bell-icon").addClass("ripple-wrapper");
                    }
                });
                /******   for notification bell ends*******/

            });


         <%--script for responsive top notification--%>
            $(window).resize(function () {
                console.log('resize called');
                var width = $(window).width();
                // for add class .noti_top_icon in top notification.
                if (width >= 768 && width <= 1010) {
                    $('#noti2').addClass('noti_top');
                    $('#noti2 > ul').addClass('noti_top_icon');
                }
                else {
                    $('#noti2').removeClass('noti_top');
                    $('#noti2 > ul').removeClass('noti_top_icon');
                };
                // for add class .noti_top_icon in top notification ends

                // for .noti_top_icon1 display none in custom width.
                if (width >= 1010) {
                    $(".noti_top_icon1").css("display", "");
                };

                if (width <= 767) {
                    $(".noti_top_icon1").css("display", "");
                };

                // for .noti_top_icon1 display none in custom width ends.


            })
            .resize();//trigger the resize event on page load.

            // for .noti_top_icon show and hide.
            $(document).ready(function () {
                $(".noti_top1").click(function () {
                    $(".noti_top_icon").slideToggle();
                });
            });
            // for .noti_top_icon show and hide ends.
            <%--script for responsive top notification end--%>
        </script>
        <script type="text/javascript">
            //    function onPageLoad() {
            //        document.getElementById("pageContainer").src = "DashBoard.aspx";
            //    }
            function loadIframe() {
                //alert(document.getElementsByName("target").src);
                if ((document.getElementById("pageContainer").contentWindow.location.href).match(/DashBoard.aspx.*/))
                    document.getElementById("pageContainer").src = "DashBoard.aspx";
            }
        </script>
    </form>

    <%--for responsive iframe--%>
    <script type="text/javascript">
        // Find all iframes
        var $iframes = $("iframe");

        // Find &#x26; save the aspect ratio for all iframes
        $iframes.each(function () {
            $(this).data("ratio", this.height / this.width)
            // Remove the hardcoded width &#x26; height attributes
    .removeAttr("width")
    .removeAttr("height");
        });

        // Resize the iframes when the window is resized
        $(window).resize(function () {
            $iframes.each(function () {
                // Get the parent container&#x27;s width
                var width = $(this).parent().width();
                $(this).width(width)
      .height(width * $(this).data("ratio"));
            });
            // Resize to fix all iframes on page load.

            //added for windows reload when browser width change
            $(window).bind('resize', function (e) {
                if (window.RT)
                    clearTimeout(window.RT);

                $(this).toggleClass('lft-arrow');
                var btnWidth = 0, pwWidth = 0;
                var $pageWrapper = $('.page-wrapper');
                var $rsb = $('.sidebar'), rsbr = Number($rsb.css('left').replace('px', ''));
                var defaultWidth = $('.sidebar').outerWidth();
                var pwml = Number($pageWrapper.css('margin-left').replace('px', '')),
        pwmr = Number($pageWrapper.css('margin-right').replace('px', ''));
                btnWidth = defaultWidth;
                pwWidth = $('.page-container').width() - $('.right-sidebar').outerWidth(true) - defaultWidth - pwml - pwmr - rsbr;
                $rsb.addClass('collapsable');

                $pageWrapper.animate({ width: pwWidth }, 500);
                $rsb.animate({ width: btnWidth + 'px' }, 500);
            });
            //added for windows reload when browser width change ends

        }).resize();
    </script>
    <script type="text/javascript">
        function callme(ID, READLOGID, READLOGDATE, USERID) {

            document.getElementById("<%=hdnNewEventId.ClientID %>").value = ID;

            document.getElementById("<%=hdnNewEventReadId.ClientID %>").value = READLOGID;

            document.getElementById("<%=hdnDate.ClientID %>").value = READLOGDATE;

            document.getElementById("<%=hdnUserId.ClientID %>").value = USERID;

            document.getElementById("<%=btnShow.ClientID %>").click();

            $('#NewsModal').modal('show');
        }

        function PrintOfferLetter(DOCID, FACID, DEPTID) {

            document.getElementById("<%=hdnDocumentid.ClientID %>").value = DOCID;

            document.getElementById("<%=hdnFacId.ClientID %>").value = FACID;

            document.getElementById("<%=hdnDepartmentid.ClientID %>").value = DEPTID;



            document.getElementById("<%=btnPrint.ClientID %>").click();


        }
        function closepopup() {
          
        }
        function HandleClose() {
            //alert('closing');
            document.getElementById("<%=btnLogout.ClientID %>").click();
        }
        <%-- var sessionTimeout = "<%= Session.Timeout %>";

        $(document).ready(HandleSessionEnd());

        function HandleSessionEnd() {
            sessionTimeout = sessionTimeout - 1;
            if (sessionTimeout >= 0) {
                //call the function again after 1 minute delay
                window.setTimeout("HandleSessionEnd()", 60000);
            }
            else {
                document.getElementById("<%=btnLogout.ClientID %>").click();
            }
        }--%>
    </script>
</body>
</html>
