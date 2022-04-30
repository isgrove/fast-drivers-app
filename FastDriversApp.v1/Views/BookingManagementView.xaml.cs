using FastDriversApp.v1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FastDriversApp.v1.Views
{
    /// <summary>
    /// Interaction logic for BookingManagementView.xaml
    /// </summary>
    public partial class BookingManagementView : Page
    {
        public BookingManagementView()
        {
            InitializeComponent();
            this.DataContext = new BookingManagementViewModel();
        }

        private void dgCompletedBookings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
