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
    public class BookingManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Booking> _allCompletedBookings;
        private ObservableCollection<Booking> _allPaymentRejectedBookings;
        private Booking _selectedBooking;
        private ObservableCollection<TransmissionType> _transmissionTypes;
        private ObservableCollection<BookingStatus> _bookingStatuses;
        private ObservableCollection<PaymentStatus> _paymentStatuses;
        private PaymentStatus _selectedPayment;
        private ObservableCollection<TimeSlot> _timeSlots;
        private RelayCommand _updateCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public RelayCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(this.UpdateMethod, true);
                }
                return _updateCommand;
            }
            set { _updateCommand = value; }
        }
        public ObservableCollection<Booking> AllCompletedBookings
        {
            get { return _allCompletedBookings; }
            set
            {
                _allCompletedBookings = value;
                OnPropertyChanged("AllCompletedBookings");
            }
        }
        public ObservableCollection<Booking> AllPaymentRejectedBookings
        {
            get { return _allPaymentRejectedBookings; }
            set
            {
                _allPaymentRejectedBookings = value;
                OnPropertyChanged("AllPaymentRejectedBookings");
            }
        }
        public Booking SelectedBooking
        {
            get { return _selectedBooking; }
            set
            {
                _selectedBooking = value;
                OnPropertyChanged("SelectedBooking");
            }

        }
        public ObservableCollection<TransmissionType> TransmissionTypes
        {
            get { return _transmissionTypes; }
            set
            {
                _transmissionTypes = value;
            }
        }
        public ObservableCollection<BookingStatus> BookingStatuses
        {
            get { return _bookingStatuses; }
            set
            {
                _bookingStatuses = value;
            }
        }
        public ObservableCollection<PaymentStatus> PaymentStatuses
        {
            get { return _paymentStatuses; }
            set
            {
                _paymentStatuses = value;
            }
        }
        public PaymentStatus SelectedPayment
        {
            get { return _selectedPayment; }
            set
            {
                _selectedPayment = value;
                OnPropertyChanged("SelectedPayment");
            }

        }
        public ObservableCollection<TimeSlot> TimeSlots
        {
            get { return _timeSlots; }
            set
            {
                _timeSlots = value;
            }
        }
        public void UpdateMethod()
        {
            int returnValue = SelectedBooking.ChangePaymentStatus(SelectedPayment.PaymentStatusId);
            if (returnValue > 0)
            {
                MessageBox.Show("Payment status updated successfully!");
            }
            else
            {
                MessageBox.Show("Payment status could not be updated, please try again!");
            }
            UpdateCompletedBookings();
            UpdatePaymentRejectedBookings();
        }
        private void UpdateCompletedBookings()
        {
            CompletedBookings allBookings = new CompletedBookings();
            this.AllCompletedBookings = new ObservableCollection<Booking>(allBookings);
        }
        private void UpdatePaymentRejectedBookings()
        {
            RejectedBookings allRejectedBookings = new RejectedBookings();
            this.AllPaymentRejectedBookings = new ObservableCollection<Booking>(allRejectedBookings);
        }
        public BookingManagementViewModel()
        {
            UpdateCompletedBookings();
            UpdatePaymentRejectedBookings();
            TransmissionTypes transmissionTypes = new TransmissionTypes();
            this.TransmissionTypes = new ObservableCollection<TransmissionType>(transmissionTypes);
            BookingStatuses bookingStatuses = new BookingStatuses();
            this.BookingStatuses = new ObservableCollection<BookingStatus>(bookingStatuses);
            PaymentStatuses paymentStatuses = new PaymentStatuses();
            this.PaymentStatuses = new ObservableCollection<PaymentStatus>(paymentStatuses);
            TimeSlots timeSlots = new TimeSlots();
            this.TimeSlots = new ObservableCollection<TimeSlot>(timeSlots);
        }
    }
}
