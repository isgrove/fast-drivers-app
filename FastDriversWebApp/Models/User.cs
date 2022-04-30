using FastDriversWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FastDriversWebApp.Models
{
    public class User
    {

        public string Email { get; set; }
        public string Password { get; set; }
        private SQLHelper _db;

        public User()
        {
            _db = new SQLHelper();
        }
        public int CheckCustomer()
        {
            string sql = "SELECT customerId from Customer where " +
            " email = @Email and password= @Password";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Email", DbType.String);
            objParams[0].Value = this.Email;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = this.Password;
            DataTable dataTable = _db.ExecuteSQL(sql, objParams);
            int id = -1;
            if (dataTable.Rows.Count > 0)
            {
                id = Convert.ToInt32(dataTable.Rows[0][0]);
            }
            return id;
        }
        public int CheckInstructor()
        {
            string sql = "SELECT instructorId from Instructor where " +
            " email = @Email and password= @Password";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Email", DbType.String);
            objParams[0].Value = this.Email;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = this.Password;
            DataTable dataTable = _db.ExecuteSQL(sql, objParams);
            int id = -1;
            if (dataTable.Rows.Count > 0)
            {
                id = Convert.ToInt32(dataTable.Rows[0][0]);
            }
            return id;
        }
        public int CheckStaff()
        {
            string sql = "SELECT staffId from Staff where " +
            " email = @Email and password= @Password";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Email", DbType.String);
            objParams[0].Value = this.Email;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = this.Password;
            DataTable dataTable = _db.ExecuteSQL(sql, objParams);
            int id = -1;
            if (dataTable.Rows.Count > 0)
            {
                id = Convert.ToInt32(dataTable.Rows[0][0]);
            }
            return id;
        }
    }
}