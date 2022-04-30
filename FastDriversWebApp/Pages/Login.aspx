<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FastDriversWebApp.Pages.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container">
       <div class="row">
           <div class="col-md-6 mx-auto">
               <div class="card">
                   <div class="card-body">
                       <div class="row">
                           <div class="col">
                               <center>
                                   <img width="150px" src="../Images/login.png" />
                               </center>
                           </div>
                       </div>                       
                       <div class="row">
                           <div class="col">
                               <center>
                                    <h3> Member Login</h3>
                               </center>
                           </div>
                       </div>
                       <div class="row">
                           <div class="col">
                             <hr />
                           </div>
                       </div>
                       <div class="row">
                           <div class="col">
                               <label> UserName</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="txtUserName"
                                       runat="server" placeholder="Username">
                                   </asp:TextBox>
                               </div>
                               <label> Password</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="txtPassword"
                                       runat="server" placeholder="Password" 
                                       TextMode="Password">
                                   </asp:TextBox>
                               </div>
                               <div class="form-group">
                                   <asp:Button CssClass="btn btn-success btn-block btn-lg"
                                       runat="server" Text="Login" ID="btnLogin" 
                                       OnClick="btnLogin_Click"/>
                               </div>
                                <div class="form-group">
                                   <asp:Button CssClass="btn btn-info btn-block btn-lg"
                                       runat="server" Text="Sign Up" ID="btnSignUp" />
                               </div>
                           </div>
                       </div>

                   </div>
               </div>
           </div>
       </div>
   </div>
</asp:Content>
