using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class Customers : List<Customer>
    {
        private SQLHelper _db;
        public Customers()
        {
            _db = new SQLHelper();
            string sql = "SELECT customerId, firstName, lastName, licenceNumber, " +
                " phone, email from Customer";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach(DataRow dr in dataTable.Rows)
            {
                Customer newCustomer = new Customer(dr);
                this.Add(newCustomer);
            }
        }
        //Overloeaded Parameterised contructor to build the list of the customers whose first name matches the search text
        public Customers(string searchText)
        {
            _db = new SQLHelper();
            string sql = "SELECT customerId, firstName, lastName, licenceNumber, phone, email" +
                " FROM Customer" +
                " WHERE firstName like '%" + searchText + "%'";
            DataTable dataTable = _db.ExecuteSQL(sql);
            foreach (DataRow dr in dataTable.Rows)
            {
                Customer newCustomer = new Customer(dr);
                this.Add(newCustomer);
            }
        }
    }
}
