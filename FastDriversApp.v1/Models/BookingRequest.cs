using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class BookingRequest : INotifyPropertyChanged
    {
        // remeber you can extract this into a new class and call it Address
        private string _street;
        private string _suburb;
        private string _postcode;
        private string _state;
        private DateTime _bookingDate;
        private string _bookingTime;
        private string _type;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                // Can use nameof instead of "Street"
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
        public string Postcode
        {
            get { return _postcode; }
            set
            {
                _postcode = value;
                OnPropertyChanged("Postcode");
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
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }
        public BookingRequest()
        {

        }
    }
}
