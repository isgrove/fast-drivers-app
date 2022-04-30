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
    public class CustomerManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Customer> _customers;
        private Customer _selectedCustomer;
        private string _searchText;
        private RelayCommand _searchCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged("Customers");
            }
        }
        public RelayCommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(this.SearchMethod, true);
                }
                return _searchCommand;
            }
            set { _searchCommand = value; }
        }
        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; }
        }
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }
        }
        public void SearchMethod()
        {
            Customers allCustomers = new Customers(SearchText);
            this.Customers = new ObservableCollection<Customer>(allCustomers);
        }
        public CustomerManagementViewModel()
        {
            Customers allCustomers = new Customers();
            this.Customers = new ObservableCollection<Customer>(allCustomers);
        }
    }
}
