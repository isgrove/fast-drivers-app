using FastDriversWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FastDriversWebApp.Models
{
    public class CompletedBookings
    {
        //  Gets all of the completed bookings (id = 4) where the payment status is pending (id = 1)
        public DataTable AllCompletedBookings()
        {
            string sql = "SELECT b.bookingId, c.firstName + ' ' + c.lastName as [Customer Name]," +
                " i.firstName + ' ' + i.lastName as [Instructor Name], b.street, b.suburb, b.postcode, b.state" +
                " FROM Customer c, Booking b , availability a, instructor i" +
                " WHERE b.availabilityId = a.availabilityId" +
                " AND a.instructorId = i.instructorId" +
                " AND c.customerId = b.customerId" +
                " AND b.bookingStatusId = 4" +
                " AND b.paymentStatusId = 1";
            SQLHelper helper = new SQLHelper();
            DataTable bookingsTable = helper.ExecuteSQL(sql);
            return bookingsTable;
        } 
    }
}