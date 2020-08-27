<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Upload.ascx.cs" Inherits="Stock.Ensure.UserControls.Common.Upload1" %>
            <div class="">
                    <asp:UpdatePanel ID="upanelAttach" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="form-group">
                                <div class="col-md-6">
                                    <asp:FileUpload runat="server" ID="fileUpload" multiple="multiple" />
                                </div>
                                <div class="col-md-6">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary" OnClick="btnUpload_Click" />
                                </div>
                            </div>
                            <div class="form-group">

                                <div class="col-md-12 col-sm-12 col-xs-12">
                                    <asp:ListBox ID="lbAttachment" runat="server" AutoPostBack="true" DataTextField="DOCUMENTNAME" DataValueField="ID" Style="height: 225px!important; width: 100%!important;"></asp:ListBox>
                                </div>

                                <div class="col-md-12 col-xs-12 col-sm-12 text-right" style="margin-top: 10px">
                                    <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="View" CssClass="btn btn-primary" />
                                    <asp:Button ID="btnShowList" runat="server" Style="display: none" OnClick="btnShowList_Click" />
                                </div>

                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnShowList" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="lbAttachment" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>