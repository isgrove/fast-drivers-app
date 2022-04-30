using System.Windows;
//MVVM - Model - View - ViewModel
//MVC - Model View Controller

namespace FastDriversApp.v1.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //This is the place to create the static Logger object
        //for logging via NLog
        public MainWindow()
        {
            InitializeComponent();
            contentFrame.Navigate(new CustomerManagementView());
        }

        private void btnInstructorManagement_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new InstructorManagementView());
        }

        private void btnCustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new CustomerManagementView());
        }

        private void btnBookingManagement_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new BookingManagementView());
        }
    }
}
