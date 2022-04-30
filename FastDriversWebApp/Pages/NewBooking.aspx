<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewBooking.aspx.cs" Inherits="FastDriversWebApp.Pages.NewBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class ="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="../Images/bookonline.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                 <center>
                                    <h3> New Booking</h3>
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                               <hr />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-6">
                                <label> Pick-up Address Line(Example: 3. George Street)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server"
                                        placeholder="Pickup address" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label> Suburb </label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtSuburb" runat="server"
                                        placeholder="Suburb" />
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-3">
                                <label> Postcode</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPostcode" runat="server"
                                        placeholder="Postcode" />
                                </div>
                            </div>
                             <div class="col-3">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlState" 
                                        runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="NSW" Value="NSW" />
                                         <asp:ListItem Text="ACT" Value="ACT" />
                                         <asp:ListItem Text="VIC" Value="VIC" />
                                         <asp:ListItem Text="QLD" Value="QLD" />
                                         <asp:ListItem Text="WA" Value="WA" />
                                         <asp:ListItem Text="NT" Value="NT" />
                                         <asp:ListItem Text="SA" Value="SA" />
                                         <asp:ListItem Text="TAS" Value="TAS" />
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label>Start Time </label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlStartTime" 
                                        runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="9:00AM" Value="9:00:00" />
                                         <asp:ListItem Text="10:00AM" Value="10:00:00"/>
                                         <asp:ListItem Text="11:00AM" Value="11:00:00" />
                                         <asp:ListItem Text="12:00" Value="12:00:00" />
                                         <asp:ListItem Text="1:00PM" Value="13:00:00"/>
                                         <asp:ListItem Text="2:00PM" Value="14:00:00"/>
                                         <asp:ListItem Text="3:00PM" Value="15:00:00"/>
                                         <asp:ListItem Text="4:00PM" Value="16:00:00" />
                                         <asp:ListItem Text="5:00PM" Value="17:00:00"/>
                                         <asp:ListItem Text="6:00PM" Value="18:00:00" />
                                         <asp:ListItem Text="7:00PM" Value="19:00:00" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-6">
                                <label> Booking Date</label>
                                <div class="form-group">
                                    <asp:Calendar ID="calBookingDate" runat="server">

                                    </asp:Calendar>
                                </div>

                            </div>
                        </div>
                         <div class="row">
                            <div class="col-12 mx-auto">
                                <center>
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg"
                                        ID="btnFindSessions" runat="server" Text="Find Sessions" 
                                        OnClick="btnFindSessions_Click"
                                         />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3> Available Sessions </h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView ID="gvAvailableSessions" 
                                    CssClass="table table-striped table-bordered"
                                    runat="server"
                                    OnRowCommand="gvAvailableSessions_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:Button ID="btnConfirm" runat="server" Text="Confirm"
                                                    CommandName="Select" 
                                                    CommandArgument="<%#Container.DataItemIndex %>"
                                                    />
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
</asp:Content>
