<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="FastDriversWebApp.Pages.Registration" %>
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
                                    <img width="150px" src="../Images/newuser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                 <center>
                                    <h3> New Customer Registration</h3>
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
                                <label> First Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtFName" runat="server"
                                        placeholder="First Name" />

                                </div>
                            </div>
                            <div class="col-6">
                                <label> Last Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtLName" runat="server"
                                        placeholder="Last Name" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <label> Birth date</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtBirthDate" runat="server"
                                        placeholder="Birth Date" TextMode="Date" />
                                </div>
                            </div>
                            <div class="col-3">
                                 <label> Licence Number </label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtLNumber" runat="server"
                                        placeholder="Licence Number" />
                                </div>
                            </div>
                            <div class="col-3">
                                <label> Phone Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server"
                                        placeholder="Phone Number"  TextMode="Number" />
                                </div>
                            </div>
                            <div class="col-3">
                                <label> Email</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"
                                        placeholder="Email"  TextMode="Email" />
                                </div>
                            </div>

                        </div>
                        <div class="row">
                              <div class="col-6">
                                <label> Credit Card Name </label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtCCName" runat="server"
                                        placeholder="Name on Credit Card" />

                                </div>
                            </div>
                            <div class="col-6">
                                <label> Address Line (Example 3 George Street)</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server"
                                        placeholder="Address" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                              <div class="col-3">
                                <label> Credit Card Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtCCNumber" runat="server"
                                        placeholder="Credit Card Number" />

                                </div>
                            </div>
                            <div class="col-1">
                                <label> Month</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtCCMonth" runat="server"
                                        placeholder="Month" TextMode="Number" />
                                </div>
                            </div>
                              <div class="col-1">
                                <label> Year</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtCCYear" runat="server"
                                        placeholder="Year" TextMode="Number" />

                                </div>
                            </div>
                            <div class="col-1">
                                <label> CVV</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtCVV" runat="server"
                                        placeholder="CVV"  TextMode="Number"/>
                                </div>
                            </div>
                              <div class="col-2">
                                <label> Suburb</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtSuburb" runat="server"
                                        placeholder="Suburb" />

                                </div>
                            </div>
                             <div class="col-2">
                                <label> Post Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPostCode" runat="server"
                                        placeholder="Post Code" />

                                </div>
                            </div>
                            <div class="col-2">
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
                            <div class="col-12 mx-auto">
                                <center>
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg"
                                        ID="btnRegister" runat="server" Text="Sign Up" 
                                        OnClick="btnRegister_Click" />
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
