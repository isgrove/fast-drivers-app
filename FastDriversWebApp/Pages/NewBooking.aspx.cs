using FastDriversWebApp.Models;
using FastDriversWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastDriversWebApp.Pages
{
    public partial class NewBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFindSessions_Click(object sender, EventArgs e)
        {
            if(calBookingDate.SelectedDate == null || ddlStartTime.SelectedValue == "" 
                 || txtSuburb.Text == "")
            {
                Response.Write("<script> alert('Select booking date, start time and enter suburb " +
                    "to display the avaiable sessions')");
            }
            else
            {
                LoadGrid();
            }
        }
        private void LoadGrid()
        {
            AvailableSessions sessions = new AvailableSessions();
            gvAvailableSessions.DataSource = sessions.GetAllAvailableSessions
                (calBookingDate.SelectedDate, ddlStartTime.SelectedValue, txtSuburb.Text);
            gvAvailableSessions.DataBind();
        }
        /* First we will book this session for a static customer ID. You check and pick one 
         * customerID from your DB. and then once we know how to grab the customerid once they login
         * passing data between pages we will change that part of the query
         */

        protected void gvAvailableSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //will retrieve the row for which the button has been clicked
                GridViewRow row = gvAvailableSessions.Rows[rowIndex];
                Booking newBooking = new Booking();
                newBooking.AvailabilityId = Convert.ToInt32(row.Cells[2].Text);
                newBooking.PickUpAddress = txtAddress.Text;
                newBooking.Suburb = txtSuburb.Text;
                newBooking.PostCode = txtPostcode.Text;
                newBooking.State = ddlState.SelectedValue;
                newBooking.CustomerId = Convert.ToInt32(Session["CustomerId"].ToString());
                int returnValue = newBooking.InsertBooking();
                if(returnValue> 0) {
                    Response.Write("<script>alert('Booking confirmed')</script>");
                    Response.Redirect("CustomerBookings.aspx");
                } else
                {
                    Response.Write("<script> alert('New Booking cannot be confirmed, please try again')</script>");
                }

            }

        }
    }
}