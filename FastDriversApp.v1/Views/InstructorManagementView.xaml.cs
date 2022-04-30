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
    /// Interaction logic for InstructorManagementView.xaml
    /// </summary>
    public partial class InstructorManagementView : Page
    {
        public InstructorManagementView()
        {
            InitializeComponent();
            //connect to DB - connectionstring
            //write the query for Instructors 
            //set the data set records to Datagrid
            //you could extract as a method
            //you could extract them as a class having methods
            this.DataContext = new InstructorManagementViewModel();

        }
    }
}
