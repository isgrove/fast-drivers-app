using FastDriversApp.v1.Commands;
using FastDriversApp.v1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FastDriversApp.v1.ViewModels
{
    public class AddCustomerViewModel
    {
        private Customer _newCustomer;
        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(this.AddMethod, true);
                }
                return _addCommand;
            }
            set { _addCommand = value; }
        }
        public void AddMethod()
        {
            string message = NewCustomer.InsertCustomer();
            MessageBox.Show(message);
        }

        public Customer NewCustomer
        {
            get { return _newCustomer; }
            set { _newCustomer = value; }
        }
        public AddCustomerViewModel()
        {
            NewCustomer = new Customer();
        }
    }
}
