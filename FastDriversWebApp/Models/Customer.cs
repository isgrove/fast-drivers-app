using FastDriversWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FastDriversWebApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LicenceNumber { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
        private SQLHelper _db;
        public string CCName { get; set; }
        public string CCNumber { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int CVV { get; set; }

        public Customer()
        {
            _db = new SQLHelper();
        }
        private void GeneratePassword()
        {
            this.Password = "welcome";
        }
        public string InsertCustomer()
        {
            GeneratePassword();
            string sql = "INSERT INTO CUSTOMER(firstName, lastName, licenceNumber, email, phone, address, suburb," +
                " postcode, state, dob, ccName, ccNumber, ccExpiryMonth, ccExpiryYear, CVV, password) " +
                " VALUES(@FirstName, @LastName, @LicenceNumber, @Email, @Phone, @Address, @Suburb, " +
                " @PostCode, @State, @Dob, @CCName, @CCNumber, @CCExpiryMonth, @CCExpiryYear, @Cvv, @Password)";
            SqlParameter[] objParams = new SqlParameter[16];
            objParams[0] = new SqlParameter("@FirstName", DbType.String);
            objParams[0].Value = this.FirstName;
            objParams[1] = new SqlParameter("@LastName", DbType.String);
            objParams[1].Value = this.LastName;
            objParams[2] = new SqlParameter("@LicenceNumber", DbType.String);
            objParams[2].Value = this.LicenceNumber;
            objParams[3] = new SqlParameter("@Email", DbType.String);
            objParams[3].Value = this.Email;
            objParams[4] = new SqlParameter("@Phone", DbType.String);
            objParams[4].Value = this.Phone;
            objParams[5] = new SqlParameter("@Address", DbType.String);
            objParams[5].Value = this.Address;
            objParams[6] = new SqlParameter("@Suburb", DbType.String);
            objParams[6].Value = this.Suburb;
            objParams[7] = new SqlParameter("@PostCode", DbType.String);
            objParams[7].Value = this.PostCode;
            objParams[8] = new SqlParameter("@State", DbType.String);
            objParams[8].Value = this.State;
            objParams[9] = new SqlParameter("@Dob", DbType.DateTime);
            objParams[9].Value = this.Dob;
            objParams[10] = new SqlParameter("@CCName", DbType.String);
            objParams[10].Value = this.CCName;
            objParams[11] = new SqlParameter("@CCNumber", DbType.String);
            objParams[11].Value = this.CCNumber;
            objParams[12] = new SqlParameter("@CCExpiryMonth", DbType.Int32);
            objParams[12].Value = this.ExpiryMonth;
            objParams[13] = new SqlParameter("@CCExpiryYear", DbType.Int32);
            objParams[13].Value = this.ExpiryYear;
            objParams[14] = new SqlParameter("@Cvv", DbType.Int32);
            objParams[14].Value = this.CVV;
            objParams[15] = new SqlParameter("@Password", DbType.String);
            objParams[15].Value = this.Password;
            int rowsAffected = _db.ExecuteNonQuery(sql, objParams);
            if(rowsAffected >= 1)
            {
                return "New Customer Registered Successfully!!!";
            }
            return "Registration was not successful, please try again!";




        }


    }
}