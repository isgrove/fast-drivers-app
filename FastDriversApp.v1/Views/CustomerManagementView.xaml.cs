using FastDriversApp.v1.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace FastDriversApp.v1.Views
{
    /// <summary>
    /// Interaction logic for CustomerManagementView.xaml
    /// </summary>
    public partial class CustomerManagementView : Page
    {
        static CustomerManagementViewModel vm;
        public CustomerManagementView()
        {
            InitializeComponent();
            vm = new CustomerManagementViewModel();
            this.DataContext = vm;
            
            //I need the logic for C# code to connect to DB
            //and write the query and execute it
            //and transfer the results of this query to the datagrid
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Views/AddCustomerView.xaml", UriKind.Relative));
        }

        private void btnNewBooking_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBookingView(vm));
        }
    }
}
