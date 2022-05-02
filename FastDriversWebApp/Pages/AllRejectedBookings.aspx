<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllRejectedBookings.aspx.cs" Inherits="FastDriversWebApp.Pages.AllRejectedBookings" %>

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
                                    <h3>All Rejected Bookings</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView ID="gvRejectedBookings"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" OnRowCommand="gvRejectedBookings_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Find Sessions">
                                            <ItemTemplate>
                                                <asp:Button ID="btnFindSessions" runat="server" Height="40px" Width="80px"
                                                    Text="Find" CommandName="Find"
                                                    CommandArgument="<%#Container.DataItemIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView ID="gvAvailableSessions"
                                    CssClass="table table-striped table-bordered"
                                    runat="server" OnRowCommand="gvAvailableSessions_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Confirm Action">
                                            <ItemTemplate>
                                                <asp:Button ID="btnConfirm" runat="server" Height="40px" Width="80px"
                                                    Text="Confirm" CommandName="Confirm"
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
