using FastDriversWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastDriversWebApp.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Email = txtUserName.Text,
                Password = txtPassword.Text
            };
            int id = -1;
            id = user.CheckCustomer();
            if (id > 0)
            {
                Session.Add("CustomerId", id);
                //Session variable is added with the name : CustomerId
                //and the value of id gets set to CustomerId Session variable
                Response.Redirect("CustomerBookings.aspx");
            }
            else
            {
                id = user.CheckInstructor();
                if (id > 0)
                {
                    Session.Add("InstructorId", id);
                    //Session variable is added with the name : CustomerId
                    //and the value of id gets set to CustomerId Session variable
                    Response.Redirect("IntructorBookings.aspx");
                }
                else
                {
                    id = user.CheckStaff();
                    if (id > 0)
                    {
                        Session.Add("StaffId", id);
                        //Session variable is added with the name : CustomerId
                        //and the value of id gets set to CustomerId Session variable
                        Response.Redirect("AllCompletedBookings.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Username or password incorrect')</script>");
                    }
                }
            }
        }
    }
}