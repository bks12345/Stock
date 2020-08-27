<%@ Page Title="" MasterPageFile="~/Ensure/main.Master" Language="C#" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="Stock.Ensure.User.changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Design/js1/FixFocus.min.js" />
        </Scripts>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row fixed-header">
                <div class="col-sm-12 col-md-12">
                    <div class="page-header-container">
                        <h4 class="page-header">Change Password</h4>
                    </div>
                </div>
            </div>
            <div class="fixed-container fixed-padding">
                <div class="row cont-pad-top">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <div class="form-group">
                            <asp:Label ID="lblUsername" runat="server" Text="Username" CssClass="col-md-2 col-sm-3 col-xs-6 control-label"></asp:Label>
                            <div class="col-sm-3 col-md-2 col-xs-6">
                                <asp:Label ID="lbluserID" runat="server" Text="admin" CssClass="control-label"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2 col-xs-6 col-sm-3">
                                <asp:Label ID="lblPrevPassword" runat="server" Text="Previous Password" CssClass=" control-label"></asp:Label>
                                <span class="important">*</span>
                            </div>
                            <div class="col-md-2 col-xs-6 col-sm-3">
                                <asp:TextBox ID="txtPrevPassword" runat="server" CssClass="form-control"
                                    TextMode="Password" TabIndex="1" MaxLength="32" OnCHange="return Validate(this,false);"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2 col-xs-6 col-sm-3  ">
                                <asp:Label ID="lblNewPassword" runat="server" Text="New Password" CssClass="control-label"></asp:Label>
                                <span class="important">*</span>
                            </div>
                            <div class="col-md-2 col-xs-6 col-sm-3 ">
                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" OnCHange="return Validate(this,false);"
                                    TextMode="Password" TabIndex="2" MaxLength="32" AutoPostBack="True" OnTextChanged="txtNewPassword_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2 col-xs-6 col-sm-3  ">
                                <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" CssClass="control-label"></asp:Label>
                                <span class="important">*</span>
                            </div>
                            <div class="col-md-2 col-xs-6 col-sm-3 ">
                                <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" OnCHange="return Validate(this,false);"
                                    TextMode="Password" TabIndex="3" MaxLength="32" AutoPostBack="True" OnTextChanged="txtConfirmPassword_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 col-xs-12 col-sm-6 text-right">
                        <asp:Button ID="btnApply" runat="server" Text="Apply" CssClass="btn btn-primary" OnClientClick="return ValidateForm();" TabIndex="4" OnClick="btnApply_Click" />
                        <asp:Button ID="btnClose" runat="server" Text="Cancel" CssClass="btn btn-primary" TabIndex="5" OnClick="btnClose_Click" />
                    </div>
                </div>

                <div class="row" style="margin: 15px 0 0;">
                    <div class="form-group">
                        <div class="col-md-12 col-xs-12 col-sm-12" style="padding-left: 0;">
                            <div class="col-md-2 col-xs-12 col-sm-2 text-left">
                                <asp:Label ID="Label1" runat="server" Text="Last Password Change Date:"></asp:Label>
                            </div>
                            <div class="col-md-2 col-xs-12 col-sm-2">
                                <asp:Label ID="lbllastupdatedate" runat="server" Text="" style="color: red;"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnShowOmc" runat="server" Text="showOMC" OnClick="btnShowOmc_Click"
                Style="display: none;" CausesValidation="False" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="/Design/js1/Ensure/FromValidation.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function confirmReport() {
            alert("hi");
            if (confirm("Do you want to Print the report?")) {
                document.getElementById("<%=btnShowOmc.ClientID %>").click();
                return true;
            } else {
                return false;
            }
            window.location('changepassword.aspx');




        }
    </script>
    <script type="text/javascript" language="javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
        function BeginRequestHandler(sender, args) {
            var oControl = args.get_postBackElement(); oControl.disabled = true;
        }

        function HideMenu() {
        }

        function ValidateForm() {
            var oForm1 = document.forms["form1"];

            var txtPrevPassword = oForm1["ContentPlaceHolder1_txtPrevPassword"];
            if (!Validate(txtPrevPassword, false)) return false;

            var txtNewPassword = oForm1["ContentPlaceHolder1_txtNewPassword"];
            if (!Validate(txtNewPassword, false)) return false;

            var txtConfirmPassword = oForm1["ContentPlaceHolder1_txtConfirmPassword"];
            if (!Validate(txtConfirmPassword, false)) return false;

            return true;
        }
    </script>
</asp:Content>
