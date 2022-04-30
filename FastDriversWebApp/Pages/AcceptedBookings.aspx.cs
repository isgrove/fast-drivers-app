using FastDriversWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastDriversWebApp.Pages
{
    public partial class AcceptedBookings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["InstructorId"] != null)
                {
                    LinkButton signUp = (LinkButton)Master.FindControl("lbtnSignUp");
                    LinkButton login = (LinkButton)Master.FindControl("lbtnLogin");
                    //LinkButton newBooking = (LinkButton)Master.FindControl("lbtnNewBooking");
                    LinkButton logout = (LinkButton)Master.FindControl("lbtnLogout");
                    signUp.Visible = false;
                    login.Visible = false;
                    // newBooking.Visible = true;
                    logout.Visible = true;
                    Instructor currentInstructor = new Instructor();
                    currentInstructor.InstructorId = Convert.ToInt32(Session["InstructorId"].ToString());
                    gvAcceptedBookings.DataSource = currentInstructor.AllAcceptedBookings().DefaultView;
                    gvAcceptedBookings.DataBind();
                    //first of all instead of bringing DataTable bring only list
                    //then one by one create

                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void gvAcceptedBookings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Instructor currentInstructor = new Instructor();
            currentInstructor.InstructorId = Convert.ToInt32(Session["InstructorID"].ToString());
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvAcceptedBookings.Rows[rowIndex];
            if (e.CommandName == "Complete")
            {
                // Could use TryParse and then notify user that only numbers can be entered in the textbox
                int kilometers = Convert.ToInt32(((TextBox) row.FindControl("txtKilometers")).Text.Trim());
                int bookingId = Convert.ToInt32(row.Cells[2].Text);
                currentInstructor.CompleteBooking(bookingId, kilometers);
            }
            
            gvAcceptedBookings.DataSource = currentInstructor.AllAcceptedBookings().DefaultView;
            gvAcceptedBookings.DataBind();
        }
    }
}