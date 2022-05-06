using FastDriversWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FastDriversWebApp.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int AvailabilityId { get; set; }
        public int CustomerId {get; set;}
        public string PickUpAddress { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }
        public int BookingStatusId { get; set; }
        public int PaymentStatusId { get; set; }
        public int Kilometres { get; set; }

        private SQLHelper _db;

        public Booking()
        {
            _db = new SQLHelper();
        }
        public Booking(DataRow dr)
        {
            this.BookingId = Convert.ToInt32(dr["bookingId"].ToString());
            this.AvailabilityId = Convert.ToInt32(dr["availabilityId"].ToString());
            this.CustomerId = Convert.ToInt32(dr["customerId"].ToString());
            this.PickUpAddress = dr["pickupAddress"].ToString();
            this.Suburb = dr["suburb"].ToString();
            this.PostCode = dr["postcode"].ToString();
            this.State = dr["state"].ToString();
            this.BookingStatusId = Convert.ToInt32(dr["bookingStatusId"].ToString());
            this.PaymentStatusId = Convert.ToInt32(dr["paymentStatusId"].ToString());
            this.Kilometres = Convert.ToInt32(dr["kilometres"].ToString());
            _db = new SQLHelper();
        }
        public int InsertBooking()
        {
            int returnValue = 0;
            string sql = "INSERT INTO Booking(availabilityId, customerId, street, suburb, postcode, " +
                    "state, bookingStatusId,paymentStatusId, kilometres)" +
                    " values(" + this.AvailabilityId + ", "+ this.CustomerId + ", '" + this.PickUpAddress + "'," +
                    " '" + this.Suburb + "' ,'" + this.PostCode + "', '" + this.State
                     + "', 1, 1, 0)";
            returnValue = _db.ExecuteNonQuery(sql);
            string updateSql = "update availability set status = 'NA' where " +
                   "availablityId = " + this.AvailabilityId;
            return returnValue;
        }
        public int ApproveBooking()
        {
            string sql = "UPDATE booking SET paymentStatusId = 2 WHERE bookingId = @BookingId";
            int returnValue = 0;
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@BookingId", DbType.Int32);
            objParams[0].Value = this.BookingId;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }
        public int RejectBooking()
        {
            string sql = "UPDATE booking SET paymentStatusId = 3 WHERE bookingId = @BookingId";
            int returnValue = 0;
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@BookingId", DbType.Int32);
            objParams[0].Value = this.BookingId;
            returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }
    }
}