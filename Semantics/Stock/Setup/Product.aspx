<%@ Page Title="" Language="C#" MasterPageFile="~/Stock/main.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Stock.Stock.Setup.Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
                <Scripts>
                    <asp:ScriptReference Path="~/Design/js1/FixFocus.js" />
                </Scripts>
            </asp:ScriptManager>
            <div class="row fixed-header">
                <div class="col-sm-12 col-md-12">
                    <div class="page-header-container">
                        <h4 class="page-header">Survey Type</h4>
                    </div>
                </div>
            </div>
            <div class="fixed-container fixed-padding">
                <div class="row cont-pad-top1">
                    <div class="col-md-3 col-sm-4 col-xs-12">
                        <div class="panel panel-default">
                            <div class="panel-heading text-center list-header">
                                <asp:Label ID="Label1" runat="server" Text="Survey Type List"></asp:Label>
                            </div>
                            <asp:ListBox ID="lbSurveyorType" runat="server" AutoPostBack="True" DataTextField="EDESCRIPTION" DataValueField="PRODUCTID" OnSelectedIndexChanged="lbSurveyorType_SelectedIndexChanged"
                                CssClass="form-control" Style="min-height: 200px;"></asp:ListBox>
                        </div>
                    </div>
                    <div class="col-md-4 col-sm-8 col-xs-12">
                        <asp:Panel ID="pnlEntry" runat="server">
                            <div class="form-group">
                                <div class="col-md-5 col-sm-5 col-xs-12">
                                    <asp:Label ID="lblEName" runat="server" Text="Survey Type(In Eng)" CssClass="control-label"></asp:Label>
                                    <span class="important">*</span>
                                </div>
                                <div class="col-md-7 col-sm-7 col-xs-12">
                                    <asp:TextBox ID="txtEName" runat="server" CssClass="form-control"  MaxLength="100" TabIndex="2" OnCHange="return Validate(this,false);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-5 col-sm-5 col-xs-12">
                                    <asp:Label ID="lblNName" runat="server" Text="Survey Type(In Nep)" CssClass="control-label"></asp:Label>
                                    <span class="important">*</span>
                                </div>
                                <div class="col-md-7 col-sm-7 col-xs-12">
                                    <asp:TextBox ID="txtNName" runat="server" CssClass="form-control nepalifont" Font-Names="FONTASY"  MaxLength="100"
                                        TabIndex="3" OnCHange="return Validate(this,false);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-5 col-sm-5 col-xs-2">
                                    <asp:Label ID="Label2" runat="server" Text="Lock" CssClass="control-label"></asp:Label>
                                   
                                </div>
                                 <div class="col-md-7 col-sm-7 col-xs-10">
                                    <asp:CheckBox ID="chkislock" runat="server" />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-5 col-sm-5 col-xs-12">
                                    <asp:Label ID="Label3" runat="server" Text="Entry By" CssClass="control-label"></asp:Label>
                                   
                                </div>
                                  <div class="col-md-7 col-sm-7 col-xs-12">
                                    <asp:TextBox ID="txtenteredby" runat="server" textmode="MultiLine" CssClass="form-control enter-text-box"
                                        MaxLength="50" TabIndex="5"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                               <div class="col-md-5 col-sm-5 col-xs-12">
                                    <asp:Label ID="Label4" runat="server" Text="Last upt. By" Tooltip="Last Updated By" CssClass="control-label"></asp:Label>
                                    
                                </div>
                                  <div class="col-md-7 col-sm-7 col-xs-12">
                                    <asp:TextBox ID="txtupdatedby" runat="server" textmode="MultiLine" CssClass="form-control enter-text-box"
                                        MaxLength="50" TabIndex="5"></asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="text-right btn-block">
                            <asp:Button ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click" CssClass="btn btn-primary" TabIndex="1" />
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="btn btn-primary" TabIndex="4" />
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-primary" TabIndex="5" OnClientClick="return ValidateForm();" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-primary" TabIndex="6" />
                        </div>
                    </div>
                </div>
                
                <div class="row">
                    <div class="col-md-12 col-sm-12 col-xs-12">
                        <span class="important"><b>Note 1 :</b> Surveyor Type must be unique. </span>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
     <script src="/Design/js1/Ensure/FromValidation.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        function HideMenu() { }
        function ValidateForm() {
            var oForm1 = document.forms["form1"];

            var txtEName = oForm1["ContentPlaceHolder1_txtEName"];
            if (!Validate(txtEName, false)) return false;
            var txtNName = oForm1["ContentPlaceHolder1_txtNName"];
            if (!Validate(txtNName, false)) return false;

            return true;
        }

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);

        function BeginRequestHandler(sender, args) {
            var oControl = args.get_postBackElement(); oControl.disabled = true;
        }

    </script>
</asp:Content>
