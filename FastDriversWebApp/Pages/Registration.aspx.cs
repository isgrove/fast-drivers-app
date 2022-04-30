using FastDriversWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FastDriversWebApp.Pages
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //1. We build a Customer object from the data provided on the Web page
            //2. Call the method"InsertCustomer()" with the new Customer object
            DateTime dob = DateTime.ParseExact(txtBirthDate.Text.Trim(), "yyyy-MM-dd", null);
           Customer newCustomer = new Customer()
            {
                FirstName = txtFName.Text,
                LastName =txtLName.Text,
                Address = txtAddress.Text,
                Suburb = txtSuburb.Text,
                PostCode = txtPostCode.Text,
                Phone = txtPhone.Text,
                Email = txtEmail.Text, 
                State = ddlState.SelectedValue,
                LicenceNumber = txtLNumber.Text, 
                Dob = dob,
                CCName = txtCCName.Text,
                CCNumber = txtCCNumber.Text,
                ExpiryMonth = Convert.ToInt32(txtCCMonth.Text),
                ExpiryYear = Convert.ToInt32(txtCCYear.Text),
                CVV = Convert.ToInt32(txtCVV.Text)
            };
            string message = newCustomer.InsertCustomer();
            Response.Write(message);
            //Integration testing 
        }
    }
}