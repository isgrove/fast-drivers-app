using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class Booking : INotifyPropertyChanged
    {
        private int _bookingId;
        private string _customerFirstName;
        private string _customerLastName;
        private string _street;
        private string _suburb;
        private string _postCode;
        private string _state;
        private string _instructorFirstName;
        private string _instructorLastName;
        private DateTime _bookingDate;
        private string _bookingTime;
        private string _bookingStatus;
        private string _paymentStatus;
        private string _transmissionType;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public int BookingId
        {
            get { return _bookingId; }
            set { _bookingId = value; }
        }
        public string CustomerFirstName
        {
            get { return _customerFirstName; }
            set
            {
                _customerFirstName = value;
                OnPropertyChanged("CustomerFirstName");
            }
        }
        public string CustomerLastName
        {
            get { return _customerLastName; }
            set
            {
                _customerLastName = value;
                OnPropertyChanged("CustomerLastName");
            }
        }
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }
        public string Suburb
        {
            get { return _suburb; }
            set
            {
                _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }
        public string PostCode
        {
            get { return _postCode; }
            set
            {
                _postCode = value;
                OnPropertyChanged("PostCode");
            }
        }
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }
        public string InstructorFirstName
        {
            get { return _instructorFirstName; }
            set
            {
                _instructorFirstName = value;
                OnPropertyChanged("InstructorFirstName");
            }
        }
        public string InstructorLastName
        {
            get { return _instructorLastName; }
            set
            {
                _instructorLastName = value;
                OnPropertyChanged("InstructorLastName");
            }
        }
        public DateTime BookingDate
        {
            get { return _bookingDate; }
            set
            {
                _bookingDate = value;
                OnPropertyChanged("BookingDate");
            }
        }
        public string BookingTime
        {
            get { return _bookingTime; }
            set
            {
                _bookingTime = value;
                OnPropertyChanged("BookingTime");
            }
        }
        public string BookingStatus
        {
            get { return _bookingStatus; }
            set
            {
                _bookingStatus = value;
                OnPropertyChanged("BookingStatus");
            }
        }
        public string PaymentStatus
        {
            get { return _paymentStatus; }
            set
            {
                _paymentStatus = value;
                OnPropertyChanged("PaymentStatus");
            }
        }


        public string TransmissionType
        {
            get { return _transmissionType; }
            set
            {
                _transmissionType = value;
                OnPropertyChanged("TransmissionType");
            }
        }

        public Booking()
        {
            _db = new SQLHelper();
        }
        public Booking(DataRow dr)
        {
            this.BookingId = Convert.ToInt32(dr["bookingId"].ToString());
            this.CustomerFirstName = dr["customerFirstName"].ToString();
            this.CustomerLastName = dr["customerLastName"].ToString();
            this.Street = dr["street"].ToString();
            this.Suburb = dr["suburb"].ToString();
            this.State = dr["state"].ToString();
            this.PostCode = dr["postCode"].ToString();
            this.BookingDate = Convert.ToDateTime(dr["bookingDate"].ToString());
            this.InstructorFirstName = dr["instructorFirstName"].ToString();
            this.InstructorLastName = dr["instructorLastName"].ToString();
            this.BookingTime = dr["bookingTime"].ToString();
            this.BookingStatus = dr["bookingStatus"].ToString();
            this.PaymentStatus = dr["paymentStatus"].ToString();
            this.TransmissionType = dr["typeName"].ToString();
            _db = new SQLHelper();
        }
        public int ChangeBookingStatus()
        {
            return 0;
        }
        public int ChangePaymentStatus(int paymentStatusId)
        {
            string sql = "UPDATE Booking" +
                " SET paymentStatusId = @PaymentStatusId" +
                " WHERE bookingId = @BookingId";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@PaymentStatusId", DbType.Int32);
            objParams[0].Value = paymentStatusId;
            objParams[1] = new SqlParameter("@BookingId", DbType.Int32);
            objParams[1].Value = this.BookingId;
            int returnValue = _db.ExecuteNonQuery(sql, objParams);
            return returnValue;
        }
        public int AddBooking(int availabilityId, int customerId, BookingRequest request)
        {
            int returnValue = 0;
            string insertSql = "INSERT INTO BOOKING(availabilityId, customerId, street, suburb, postcode, state, bookingStatusId, paymentStatusId, kilometres)" +
                " VALUES(@AvailabilityId, @CustomerId, @Street, @Suburb, @Postcode, @State, 1, 1, 0)";
            SqlParameter[] objParams = new SqlParameter[6];
            objParams[0] = new SqlParameter("@AvailabilityId", DbType.Int32);
            objParams[0].Value = availabilityId;
            objParams[1] = new SqlParameter("@CustomerId", DbType.Int32);
            objParams[1].Value = customerId;
            objParams[2] = new SqlParameter("@Street", DbType.String);
            objParams[2].Value = availabilityId;
            objParams[3] = new SqlParameter("@Suburb", DbType.String);
            objParams[3].Value = availabilityId;
            objParams[4] = new SqlParameter("@Postcode", DbType.String);
            objParams[4].Value = availabilityId;
            objParams[5] = new SqlParameter("@State", DbType.String);
            objParams[5].Value = availabilityId;
            returnValue = _db.ExecuteNonQuery(insertSql, objParams);
            return returnValue;

        }
    }
}