using FastDriversWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastDriversWebApp.Pages
{
    public partial class AllCompletedBookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["StaffId"] != null)
                {
                    LinkButton signUp = (LinkButton)Master.FindControl("lbtnSignUp");
                    LinkButton login = (LinkButton)Master.FindControl("lbtnLogin");
                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    signUp.Visible = false;
                    login.Visible = false;
                    logout.Visible = true;

                    RefreshGrid();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        private void RefreshGrid()
        {
            CompletedBookings completedBookings = new CompletedBookings();
            gvCompletedBookings.DataSource = completedBookings.AllCompletedBookings().DefaultView;
            gvCompletedBookings.DataBind();
        }

        protected void gvCompletedBookings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvCompletedBookings.Rows[rowIndex];
            int bookingId = Convert.ToInt32(row.Cells[2].Text);
            Booking booking = new Booking();
            booking.BookingId = bookingId;
            if (e.CommandName == "Approve")
            {
                booking.ApproveBooking();
            }
            else if (e.CommandName == "Reject")
            {
                booking.RejectBooking();
            }
            RefreshGrid();
        }
    }
}