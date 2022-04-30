using FastDriversWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FastDriversWebApp.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
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
        public int TransmissionTypeId { get; set; }
        private SQLHelper _db;



        public Instructor()
        {
            _db = new SQLHelper();
        }
        //Refactoring of the code is when a programmer realises that maybe extracting a part of code
        //as a method and then eventually extract that method into a new class
        //without changing the execution of your programs is called refactoring

        public DataTable AllBookings()
        {
            string sql = "SELECT b.bookingId, c.firstName + ' ' + c.lastName as [Customer Name], b.street, b.suburb," +
            " b.postcode, b.state from Customer c, Booking b , availability a, instructor i" +
            " WHERE b.availabilityId = a.availabilityId" +
            " AND a.instructorId = i.instructorId" +
            " AND c.customerId = b.customerId" +
            " AND i.instructorId = @InstructorId" +
            " AND b.bookingStatusId = 1";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@InstructorId", DbType.Int32);
            objParams[0].Value = this.InstructorId;
            DataTable bookings = _db.ExecuteSQL(sql, objParams);
            return bookings;
        }
        public DataTable AllAcceptedBookings()
        {
            string sql = "SELECT b.bookingId, c.firstName + ' ' + c.lastName as [Customer Name], b.street, b.suburb," +
            " b.postcode, b.state from Customer c, Booking b , availability a, instructor i" +
            " WHERE b.availabilityId = a.availabilityId" +
            " AND a.instructorId = i.instructorId" +
            " AND c.customerId = b.customerId" +
            " AND i.instructorId = @InstructorId" +
            " AND b.bookingStatusId = 2";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@InstructorId", DbType.Int32);
            objParams[0].Value = this.InstructorId;
            DataTable bookings = _db.ExecuteSQL(sql, objParams);
            return bookings;
        }
        public int AcceptBooking(int bookingId)
        {
            int returnValue = 0;
            string sql = "UPDATE Booking set bookingStatusId = 2 " +
                "WHERE bookingId = @BookingId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@BookingId", DbType.Int32);
            objParams[0].Value = bookingId;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }
        public int RejectBooking(int bookingId)
        {
            int returnValue = 0;
            string sql = "UPDATE Booking set bookingStatusId = 3 " +
                "WHERE bookingId = @BookingId";
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@BookingId", DbType.Int32);
            objParams[0].Value = bookingId;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }
        public int CompleteBooking(int bookingId, int kilometers)
        {
            int returnValue = 0;
            string sql = "UPDATE Booking set bookingStatusId = 4, kilometres = @Kilometers " +
                "WHERE bookingId = @BookingId";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Kilometers", DbType.Int32);
            objParams[0].Value = kilometers;
            objParams[1] = new SqlParameter("@BookingId", DbType.Int32);
            objParams[1].Value = bookingId;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }
    }
}