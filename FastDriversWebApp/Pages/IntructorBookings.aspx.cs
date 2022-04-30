using FastDriversWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastDriversWebApp.Pages
{
    public partial class IntructorBookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["InstructorId"] != null)
                {
                    LinkButton signUp = (LinkButton)Master.FindControl("lbtnSignUp");
                    LinkButton login = (LinkButton)Master.FindControl("lbtnLogin");
                    LinkButton acceptedBookings = (LinkButton)Master.FindControl("lbtnAcceptedBookings");
                    //LinkButton newBooking = (LinkButton)Master.FindControl("lbtnNewBooking");
                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    signUp.Visible = false;
                    login.Visible = false;
                    acceptedBookings.Visible = true;
                    // newBooking.Visible = true;
                    logout.Visible = true;
                    Instructor currentInstructor = new Instructor();
                    currentInstructor.InstructorId = Convert.ToInt32(Session["InstructorId"].ToString());
                    gvBookings.DataSource = currentInstructor.AllBookings().DefaultView;
                    gvBookings.DataBind();
                    //first of all instead of bringing DataTable bring only list
                    //then one by one create

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void gvBookings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Instructor currentInstructor = new Instructor();
            currentInstructor.InstructorId = Convert.ToInt32(Session["InstructorID"].ToString());
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvBookings.Rows[rowIndex];
            int bookingId = Convert.ToInt32(row.Cells[2].Text);
            if (e.CommandName == "Accept")
            {
                currentInstructor.AcceptBooking(bookingId);
            }
            else if (e.CommandName == "Reject")
            {
                currentInstructor.AcceptBooking(bookingId);
            }
            gvBookings.DataSource = currentInstructor.AllBookings().DefaultView;
            gvBookings.DataBind();
        }
    }
}