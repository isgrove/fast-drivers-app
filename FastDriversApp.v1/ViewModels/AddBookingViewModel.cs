using FastDriversApp.v1.Commands;
using FastDriversApp.v1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastDriversApp.v1.ViewModels
{
    public class AddBookingViewModel : INotifyPropertyChanged
    {
        private Customer _selectedCustomer;
        private TimeSlot _selectedTime;
        private ObservableCollection<AvailableSession> _availableSessions;
        private ObservableCollection<TimeSlot> _timeSlots;
        private ObservableCollection<TransmissionType> _transmissionTypes;
        private AvailableSession _selectedSession;
        private RelayCommand _findCommand;
        private RelayCommand _confirmCommand;
        private BookingRequest _request;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public RelayCommand FindCommand
        {
            get
            {
                if (_findCommand == null)
                {
                    _findCommand = new RelayCommand(this.FindMethod, true);
                }
                return _findCommand;
            }
            set { _findCommand = value; }
        }
        public RelayCommand ConfirmCommand
        {
            get
            {
                if (_confirmCommand == null)
                {
                    _confirmCommand = new RelayCommand(this.ConfirmMethod, true);
                }
                return _confirmCommand;
            }
            set { _confirmCommand = value; }
        }
        public ObservableCollection<AvailableSession> AvailableSessions
        {
            get { return _availableSessions; }
            set
            {
                _availableSessions = value;
                OnPropertyChanged("AvailableSessions");
            }
        }
        public ObservableCollection<TimeSlot> TimeSlots
        {
            get { return _timeSlots; }
            set
            {
                _timeSlots = value;
                OnPropertyChanged("TimeSlots");
            }
        }
        public ObservableCollection<TransmissionType> TransmissionTypes
        {
            get { return _transmissionTypes; }
            set
            {
                _transmissionTypes = value;
                OnPropertyChanged("TransmissionTypes");
            }
        }
        public BookingRequest Request
        {
            get { return _request; }
            set
            {
                _request = value;
                OnPropertyChanged("Request");
            }
        }
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; }
        }
        public TimeSlot SelectedTime
        {
            get { return _selectedTime; }
            set
            {
                _selectedTime = value;
                OnPropertyChanged("SelectedTime");
            }
        }
        public AvailableSession SelectedSession
        {
            get { return _selectedSession; }
            set
            {
                _selectedSession = value;
                OnPropertyChanged("SelectedSession");
            }
        }
        private void FindMethod()
        {
            AvailableSessions sessions = new AvailableSessions(Request.BookingDate, SelectedTime.StartTime, Request.Suburb);
            this.AvailableSessions = new ObservableCollection<AvailableSession>(sessions);
        }
        private void ConfirmMethod()
        {
            Booking newBooking = new Booking();

            int availabilityId = SelectedSession.AvailabilityId;
            int customerId = SelectedCustomer.CustomerId;
            BookingRequest bookingRequest = Request;

            newBooking.AddBooking(availabilityId, customerId, bookingRequest);
        }
        public AddBookingViewModel(CustomerManagementViewModel cvm)
        {
            SelectedCustomer = new Customer();
            if (cvm.SelectedCustomer != null)
            {
                SelectedCustomer = cvm.SelectedCustomer;
                Request = new BookingRequest();
                TimeSlots timeSlots = new TimeSlots();
                this.TimeSlots = new ObservableCollection<TimeSlot>(timeSlots);
                TransmissionTypes transmissionTypes = new TransmissionTypes();
                this.TransmissionTypes = new ObservableCollection<TransmissionType>(transmissionTypes);
            }
            else
            {
                MessageBox.Show("No customer selected");
            }
        }
    }
}
