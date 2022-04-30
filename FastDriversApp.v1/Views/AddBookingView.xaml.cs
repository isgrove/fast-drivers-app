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
    /// Interaction logic for AddBookingView.xaml
    /// </summary>
    public partial class AddBookingView : Page
    {
        private CustomerManagementViewModel _vm;
        public AddBookingView(CustomerManagementViewModel vm)
        {
            InitializeComponent();
            this._vm = vm;
            this.DataContext = new AddBookingViewModel(this._vm);
        }
    }
}
