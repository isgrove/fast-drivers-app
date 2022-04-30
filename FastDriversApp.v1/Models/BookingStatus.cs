using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class BookingStatus : INotifyPropertyChanged
    {
        private int _bookingStatusId;
        private string _bookingStatus;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public int BookingStatusId
        {
            get { return _bookingStatusId; }
            set
            {
                _bookingStatusId = value;
                OnPropertyChanged("BookingStatusId");
            }
        }

        public string Status
        {
            get { return _bookingStatus; }
            set
            {
                _bookingStatus = value;
                OnPropertyChanged("Status");
            }
        }
        public BookingStatus()
        {
            _db = new SQLHelper();
        }
        public BookingStatus(DataRow dr)
        {
            this.BookingStatusId = Convert.ToInt32(dr["bookingStatusId"].ToString());
            this.Status = dr["bookingStatus"].ToString();
            _db = new SQLHelper();
        }
    }
}
