using FastDriversWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastDriversWebApp.Pages
{
    public partial class AllRejectedBookings : System.Web.UI.Page
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
                    LinkButton completedBookings = (LinkButton)Master.FindControl("lbtnAllCompletedBookings");
                    LinkButton rejectedBookings = (LinkButton)Master.FindControl("lbtnAllRejectedBookings");
                    signUp.Visible = false;
                    login.Visible = false;
                    logout.Visible = true;
                    completedBookings.Visible = true;
                    rejectedBookings.Visible = true;

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
            RejectedBookings rejectedBookings = new RejectedBookings();
            gvRejectedBookings.DataSource = rejectedBookings.AllRejectedBookings().DefaultView;
            gvRejectedBookings.DataBind();
        }

        protected void gvRejectedBookings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvRejectedBookings.Rows[rowIndex];

            if (e.CommandName == "Find")
            {
                DateTime bookingDate = Convert.ToDateTime(row.Cells[9].Text);
                string street = row.Cells[4].Text;
                string suburb = row.Cells[5].Text;
                string postcode = row.Cells[6].Text;
                string state = row.Cells[7].Text;
                string time = row.Cells[10].Text;
                int customerId = Convert.ToInt32(row.Cells[2].Text);


                Session.Add("suburb", suburb);
                Session.Add("street", street);
                Session.Add("postcode", postcode);
                Session.Add("state", state);
                Session.Add("customerId", customerId);
                AvailableSessions allSessions = new AvailableSessions();
                gvAvailableSessions.DataSource = allSessions.GetAllAvailableSessions(bookingDate, time, suburb);
                gvAvailableSessions.DataBind();
            }
            RefreshGrid();
        }

        protected void gvAvailableSessions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Confirm")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAvailableSessions.Rows[rowIndex];
                Booking newBooking = new Booking();
                newBooking.AvailabilityId = Convert.ToInt32(row.Cells[2].Text);
                newBooking.PickUpAddress = Session["street"].ToString();
                newBooking.Suburb = Session["suburb"].ToString();
                newBooking.PostCode = Session["postcode"].ToString();
                newBooking.State = Session["state"].ToString();
                newBooking.CustomerId = Convert.ToInt32(Session["customerId"]);

                int returnValue = newBooking.InsertBooking();

                Session.Remove("suburb");
                Session.Remove("street");
                Session.Remove("postcode");
                Session.Remove("state");
                Session.Remove("customerId");

                if(returnValue > 0)
                {
                    Response.Write("<script>alert('Booking Confirmed');</scirpt>");
                }
                else
                {
                    Response.Write("<script>alert('New booking cannot be confirmed');</scirpt>");
                }
            }
        }
    }
}