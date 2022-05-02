using FastDriversWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FastDriversWebApp.Models
{
    public class RejectedBookings
    {
        public DataTable AllRejectedBookings()
        {
            // TODO: pls fix
            string sql = "SELECT b.bookingId, c.customerId, c.firstName + ' ' + c.lastName as [Customer Name]," +
                " b.street, b.suburb, b.postcode, b.state, i.firstName + ' ' + i.lastName as [Instructor Name]," +
                " a.availableDate, t.startTime" +
                " FROM Customer c, Booking b , Availability a, Instructor i, TimeSlot t" +
                " WHERE b.availabilityId = a.availabilityId" +
                " AND a.instructorId = i.instructorId" +
                " AND c.customerId = b.customerId" +
                " AND b.bookingStatusId = 2" +
                " AND b.paymentStatusId = 1" +
                " AND a.timeSlotId = t.timeSlotId";
            SQLHelper helper = new SQLHelper();
            DataTable bookingsTable = helper.ExecuteSQL(sql);
            return bookingsTable;
        }
    }
}