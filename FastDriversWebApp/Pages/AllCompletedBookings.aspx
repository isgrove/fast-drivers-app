<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllCompletedBookings.aspx.cs" Inherits="FastDriversWebApp.Pages.AllCompletedBookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                <h3> All Completed Bookings</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView ID="gvCompletedBookings"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" OnRowCommand="gvCompletedBookings_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Approve Action">
                                            <ItemTemplate>
                                                <asp:Button ID="btnApprove" runat="server" Height="40px" Width="80px"
                                                    Text="Approve" CommandName="Approve"
                                                    CommandArgument="<%#Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Reject Action">
                                            <ItemTemplate>
                                                <asp:Button ID="btnReject" runat="server" Height="40px" Width="80px"
                                                    Text="Reject" CommandName="Reject"
                                                    CommandArgument="<%#Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

