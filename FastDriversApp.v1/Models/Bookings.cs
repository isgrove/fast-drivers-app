using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    class Bookings : List<Booking>
    {
        public Bookings()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "SELECT b.bookingId, c.FirstName as CustomerFirstName, c.LastName as CustomerLastName, b.Street, b.Suburb, b.State," +
                " b.Postcode, a.AvailableDate as BookingDate, i.FirstName as [InstructorFirstName], i.LastName as [InstructorLastName]," +
                " bs.BookingStatus, ps.PaymentStatus, t.TypeName, ts.StartTime as [bookingTime]" +
                " FROM Booking b, Customer c, Availability a, Instructor i, BookingStatus bs, PaymentStatus ps, TransmissionType t," +
                " TimeSlot ts" +
                " WHERE c.CustomerId = b.CustomerId" +
                " AND i.InstructorId = a.InstructorId" +
                " AND b.AvailabilityId = a.AvailabilityId" +
                " AND b.PaymentStatusId = ps.PaymentStatusId" +
                " AND b.BookingStatusId = bs.BookingStatusId" +
                " AND t.TransmissionTypeId = i.TransmissionTypeId" +
                " AND a.TimeSlotId = ts.TimeSlotId";
            DataTable bookingsTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in bookingsTable.Rows)
            {
                Booking booking = new Booking(dr);
                this.Add(booking);
            }
        }
    }
}
