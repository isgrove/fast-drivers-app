using FastDriversApp.v1.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDriversApp.v1.Models
{
    public class Instructor : INotifyPropertyChanged
    {
        private int _instructorId;
        private string _firstName;
        private string _lastName;
        private string _street;
        private string _suburb;
        private string _postCode;
        private string _state;
        private string _email;
        private string _phone;
        private string _licenceNumber;
        private string _password;
        private string _transmissionTypeName;
        private DateTime _dob;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public int InstructorId
        {
            get { return _instructorId; }
            set { _instructorId = value; }

        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }
        public string Suburb
        {
            get { return _suburb; }
            set
            {
                _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }
        public string PostCode
        {
            get { return _postCode; }
            set
            {
                _postCode = value;
                OnPropertyChanged("PostCode");
            }
        }
        public string LicenceNumber
        {
            get { return _licenceNumber; }
            set
            {
                _licenceNumber = value;
                OnPropertyChanged("LicenceNumber");
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        public string TransmissionTypeName
        {
            get { return _transmissionTypeName; }
            set
            {
                _transmissionTypeName = value;
                OnPropertyChanged("TransmissionTypeName");
            }
        }
        public DateTime Dob
        {
            get { return _dob; }
            set { _dob = value; }
        }
        public Instructor()
        {
            _db = new SQLHelper();
        }
        public Instructor(DataRow dr)
        {
            _db = new SQLHelper();
            this.InstructorId = Convert.ToInt32(dr["instructorId"].ToString());
            this.FirstName = dr["firstName"].ToString();
            this.LastName = dr["lastName"].ToString();
            this.LicenceNumber = dr["licenceNumber"].ToString();
            this.Phone = dr["phone"].ToString();
            this.Email = dr["email"].ToString();
            this.Street = dr["street"].ToString();
            this.Suburb = dr["suburb"].ToString();
            this.State = dr["state"].ToString();
            this.PostCode = dr["postCode"].ToString();
            this.Dob = Convert.ToDateTime(dr["dob"].ToString());
            this.TransmissionTypeName = dr["transmissionType"].ToString();
         }

    }
}
