<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FastDriversWebApp.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <img src="../Images/banner1.jpg" class="img-fluid" />
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                        <h2> Our Features</h2>
                        <p> <b> Our 3 Primary Features </b> </p>
                    </center>
                </div>
            </div>
            <div class="row">
                <div class="col-4">
                    <center>
                        <img width="150px" src="../Images/bookonline.png" />
                        <h4> Book online</h4>
                        <p class="text-justify">Book your driving lessons
                            online with Fast drivers with a lot of options to choose
                            from to suit your needs!!!
                        </p>
                    </center>
                </div>
                  <div class="col-4">
                    <center>
                        <img width="150px" src="../Images/search.jpg" />
                        <h4> Search Sessions</h4>
                        <p class="text-justify">Book your driving lessons
                            online with Fast drivers with a lot of options to choose
                            from to suit your needs!!!
                        </p>
                    </center>
                </div>
                  <div class="col-4">
                    <center>
                        <img width="150px" src="../Images/notify.jpg" />
                        <h4> Mobile Notification</h4>
                        <p class="text-justify">Book your driving lessons
                            online with Fast drivers with a lot of options to choose
                            from to suit your needs!!!
                        </p>
                    </center>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
