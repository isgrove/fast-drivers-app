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
    public class InstructorManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Instructor> _instructors;
        private Instructor _selectedInstructor;
        private PreferredSuburb _selectedSuburb;
        private ObservableCollection<PreferredSuburb> _preferredSuburbs;
        private ObservableCollection<TransmissionType> _transmissionTypes;
        public event PropertyChangedEventHandler PropertyChanged;
        private PreferredSuburb _instructorSuburb;
        private RelayCommand _addSuburbCommand;
        private RelayCommand _removeSuburbCommand;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public RelayCommand AddSuburbCommand
        {
            get
            {
                if (_addSuburbCommand == null)
                {
                    _addSuburbCommand = new RelayCommand(this.AddSuburbMethod, true);
                }
                return _addSuburbCommand;
            }
            set { _addSuburbCommand = value; }
        }
        public RelayCommand RemoveSuburbCommand
        {
            get
            {
                if (_removeSuburbCommand == null)
                {
                    _removeSuburbCommand = new RelayCommand(this.RemoveSuburbMethod, true);
                }
                return _removeSuburbCommand;
            }
            set { _removeSuburbCommand = value; }
        }
        public ObservableCollection<Instructor> Instructors
        {
            get { return _instructors; }
            set { _instructors = value; }
        }
        public ObservableCollection<PreferredSuburb> PreferredSuburbs
        {
            get { return _preferredSuburbs; }
            set
            {
                _preferredSuburbs = value;
                OnPropertyChanged("PreferredSuburbs");
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
        public Instructor SelectedInstructor
        {
            get { return _selectedInstructor; }
            set
            {
                _selectedInstructor = value;
                OnPropertyChanged("SelectedInstructor");
                PreferredSuburbs allSuburbs = new PreferredSuburbs(SelectedInstructor.InstructorId);
                this.PreferredSuburbs = new ObservableCollection<PreferredSuburb>(allSuburbs);
            }
        }
        public PreferredSuburb SelectedSuburb
        {
            get { return _selectedSuburb; }
            set
            {
                _selectedSuburb = value;
                OnPropertyChanged("SelectedSuburb");
            }
        }
        public PreferredSuburb InstructorSuburb
        {
            get { return _instructorSuburb; }
            set { _instructorSuburb = value; }
        }

        public void AddSuburbMethod()
        {
            // TODO: Create an INFO log here
            int returnedValue = InstructorSuburb.InsertSuburb(SelectedInstructor.InstructorId);
            if (returnedValue > 0)
            {
                MessageBox.Show("Suburb added \nRows affected: " + returnedValue);
            }
            else
            {
                MessageBox.Show("Suburb couldn't be added \nRows affected: " + returnedValue);
            }
            this.InstructorSuburb.Suburb = String.Empty;

        }

        public void RemoveSuburbMethod()
        {
            // TODO: Create an INFO log here
            int returnedValue = SelectedSuburb.DeleteSuburb(SelectedInstructor.InstructorId);
            if (returnedValue > 0)
            {
                MessageBox.Show("Suburb remove \nRows affected: " + returnedValue);
            }
            else
            {
                MessageBox.Show("Suburb couldn't be removed \nRows affected: " + returnedValue);
            }

        }

        public InstructorManagementViewModel()
        {
            Instructors allInstructors = new Instructors();
            this.Instructors = new ObservableCollection<Instructor>(allInstructors);
            InstructorSuburb = new PreferredSuburb();
            TransmissionTypes transmissionTypes = new TransmissionTypes();
            this.TransmissionTypes = new ObservableCollection<TransmissionType>(transmissionTypes);
            
        }
    }
}
