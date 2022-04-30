using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastDriversWebApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx");
        }

        protected void lbtnLogin_Click(object sender, EventArgs e)
        {
            //in this method we will redirect the control
            //to the new page we added "Login.aspx".
            //Browser - Client - Request
            //ASP.Net - Server - Responds
            Response.Redirect("Login.aspx");
        }

        protected void lbtnAcceptedBookings_Click(object sender, EventArgs e)
        {
            Response.Redirect("AcceptedBookings.aspx");
        }
        protected void lbtnNewBooking_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewBookings.aspx");
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("CustomerId");
            Session.Remove("InstructorId");
            Session.Remove("StaffId");
            Session.RemoveAll(); // Removes all of the sessions
            //Session.Abandon(); // Removes the current session
            //Session.Clear(); // Only removes the values, not the variables themseleves

            Response.Redirect("HomePage.aspx");
        }
    }
}